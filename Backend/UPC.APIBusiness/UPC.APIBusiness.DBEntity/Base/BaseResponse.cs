using System;
using System.Collections.Generic;
using System.Text;

namespace DBEntity
{
    public class BaseResponse<TDataResponse>
    {
        public bool IsSuccess { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public TDataResponse Data { get; set; }
    }
}
