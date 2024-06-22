using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Entity.Results
{
    public class Result<T>
    {
        public Result(T _value, string _message, int _statusCode, ErrorInformation errorInformation)
        {
            Value = _value;
            Message = _message;
            StatusCode = _statusCode;
            ErrorInformation = errorInformation;
        }

        public Result( string _message, int _statusCode, ErrorInformation errorInformation)
        {
            Message = _message;
            StatusCode = _statusCode;
            ErrorInformation = errorInformation;
        }
        public T Value { get; set; }

        public string Message { get; set; }
        public int StatusCode { get; set; }
        public ErrorInformation ErrorInformation { get; set; }

        public static Result<T> SuccessWithData(T _value, string _message = "Success", int statusCode = (int)HttpStatusCode.OK)
        {
            return new Result<T>(_value, _message, statusCode, null);
        }

        public static Result<T>SuccessWitoutData(string _message = "Success", int statusCode = (int)HttpStatusCode.OK) 
        {
            return new Result<T>( _message, statusCode, null);
        }
    }
}
