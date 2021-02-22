using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payment.Api.Response
{
    public class BaseResponse<T>
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public bool IsSuccessful { get; set; }
        public T Data { get; set; }
    }
}
