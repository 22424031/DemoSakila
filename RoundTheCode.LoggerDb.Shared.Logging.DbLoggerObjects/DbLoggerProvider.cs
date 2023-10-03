using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoundTheCode.LoggerDb.Shared.Logging.DbLoggerObjects
{
    public class DbLoggerProvider : ILoggerProvider
    {
        public readonly DbLoggerOptions _options;
        public DbLoggerProvider(IOptions<DbLoggerOptions> option)
        {
            _options = option.Value;
        }
        public ILogger CreateLogger(string categoryName)
        {
            return new DbLogger(this);
        }

        public void Dispose()
        {
           
        }
    }
}
