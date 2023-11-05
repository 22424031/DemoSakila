using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sakila.Application.Dtos.Hubs
{
    public class MessageInstance
    {
        public string Timestamp { get; set; }
        public string From { get; set; }
        public string Message { get; set; }
    }
}
