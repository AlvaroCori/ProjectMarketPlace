namespace ProjectMarketPlace.Common
{
    public class BaseResponse<T> where T : class
    {
        public string? Code { get; set; }
        public T? Result { get; set; }
        public DateTime TimeStamp { get; set; }
        public BaseResponse(T? result)
        {
            Code = "800";
            this.Result = result;
            TimeStamp = new DateTime();

        }

    }
}

﻿
