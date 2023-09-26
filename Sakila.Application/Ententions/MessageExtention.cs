using Sakila.Application.Dtos.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;

namespace Sakila.Application.Ententions
{
    internal static class MessageExtention<T>
    {
        internal static BaseResponse<T> ResultErrorValidator(ValidationResult result)
        {
            var rep = new BaseResponse<T>();
            rep.Status = 400;
            foreach (var er in result.Errors)
            {
                rep.ErrorCode += $", {er.ErrorCode}";
                rep.ErrorMessage += $", {er.ErrorMessage}";
            }
            if(rep.ErrorMessage.Length > 1)
            {
                rep.ErrorCode = rep.ErrorCode.Substring(2, rep.ErrorCode.Length-2);
                rep.ErrorMessage = rep.ErrorMessage.Substring(2, rep.ErrorMessage.Length - 2);
            }
            return rep;
        }
        internal static BaseResponse<T> ResultOK(T data)
        {
            var rep = new BaseResponse<T>();
            rep.Status = 200;
            rep.Data = data;
            return rep;
        }

    }
}
