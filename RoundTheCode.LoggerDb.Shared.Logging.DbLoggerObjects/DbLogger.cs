using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoundTheCode.LoggerDb.Shared.Logging.DbLoggerObjects
{
    public class DbLogger : ILogger
    {
        private readonly DbLoggerProvider _dbLoggerProvider;
       public DbLogger(DbLoggerProvider dbLoggerProvider)
        {
            _dbLoggerProvider = dbLoggerProvider;
        }
        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return logLevel != LogLevel.None;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            if (!IsEnabled(logLevel))
            {
                //don't log the entry if it's not enabled
                return;
            }
            var threadId = Thread.CurrentThread.ManagedThreadId;
            //store record
            string conectionString = _dbLoggerProvider._options.ConnectionString;
            using (var connection = new MySqlConnection(conectionString))
            {
                connection.Open();

                var values = new JObject();
                if(_dbLoggerProvider?._options?.LogFields?.Any() ?? false)
                {
                    foreach(var logField in _dbLoggerProvider._options.LogFields)
                    {
                        switch (logField)
                        {
                            case "LogLevel":
                                if (!string.IsNullOrWhiteSpace(logLevel.ToString()))
                                {
                                    values["LogLevel"] = logLevel.ToString();
                                }
                                break;
                            case "ThreadId":
                                values["ThreadId"] = threadId;
                                break;
                            case "EventId":
                                values["EventId"] = eventId.Id;
                                break;
                            case "EventName":
                                if (!string.IsNullOrWhiteSpace(eventId.Name))
                                {
                                    values["EventName"] = eventId.Name;
                                }
                                break;
                            case "Message":
                                if (!string.IsNullOrWhiteSpace(formatter(state, exception)))
                                {
                                    values["Message"] = formatter(state, exception);
                                }
                                break;
                            case "ExceptionMessage":
                                if (exception != null &&
                                    !string.IsNullOrWhiteSpace(exception.Message))
                                {
                                    values["ExceptionMessage"] = exception?.Message;
                                }
                                break;
                            case "ExceptionStackTrace":
                                if (exception != null
                                    && !string.IsNullOrWhiteSpace(exception.StackTrace))
                                {
                                    values["ExceptionStackTrace"] = exception?.StackTrace;
                                }
                                break;
                            case "ExceptionSource":
                                if (exception != null
                                    && !string.IsNullOrWhiteSpace(exception.Source))
                                {
                                    values["ExceptionSource"] = exception?.Source;
                                }
                                break;
                        }
                    }
                }
                using(var command = new MySqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = string.Format("INSERT INTO {0} (LogLevel, ThreadId, EventId, EventName, ExceptionMessage, ExceptionStackTrace, ExceptionSource) " +
                            $"VALUES ('{values["LogLevel"]}', '{values["ThreadId"]}', '{values["EventId"]}', '{values["EventName"]}', '{values["ExceptionStackTrace"]}', '{values["ExceptionSource"]}', '{values["ExceptionMessage"]}')",
                            _dbLoggerProvider._options.LogTable);
                    //command.CommandText = string.Format("INSERT INTO {0} (Values) " +
                    //        "VALUES (@Values)",
                    //        _dbLoggerProvider._options.LogTable);
                    //command.Parameters.Add(new MySqlParameter("@Values",
                    //       JsonConvert.SerializeObject(values, new JsonSerializerSettings
                    //       {
                    //           NullValueHandling = NullValueHandling.Ignore,
                    //           DefaultValueHandling = DefaultValueHandling.Ignore,
                    //           Formatting = Formatting.None
                    //       })));
                    //command.Parameters.Add(new MySqlParameter("@LogLevel", values["LogLevel"]));
                    //command.Parameters.Add(new MySqlParameter("@ThreadId", values["ThreadId"]));
                    //command.Parameters.Add(new MySqlParameter("@EventId", values["EventId"]));
                    //command.Parameters.Add(new MySqlParameter("@EventName", values["EventName"]));
                    // command.Parameters.Add(new MySqlParameter("@Created", DateTimeOffset.Now));

                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
    }
}
