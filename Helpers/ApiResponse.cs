using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuantumWebAPI.Models
{
    class ApiResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public object ResponseData { get; set; }

        public ApiResponse(bool status, string message, object data)
        {
            IsSuccess = status;
            Message = message;
            ResponseData = data;
        }
    }
}