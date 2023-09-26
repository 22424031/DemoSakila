using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sakila.Application.Dtos.Common
{
    public class BaseResponse<T>
    {
        public T Data { get; set; }
        public int Status { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
    }
}
