using System.Net;

namespace ProjectMarketPlace.Common
{
    public class CustomException : Exception
    {
        private HttpStatusCode _httpStatusCode { get; set; } = HttpStatusCode.BadRequest;
        public CustomException() { }
        public CustomException(string message, HttpStatusCode httpStatusCode = HttpStatusCode.BadRequest) : base(message) 
        {
            _httpStatusCode = httpStatusCode;
        }
        public CustomException(string message, Exception exception) : base(message, exception)
        {
            _httpStatusCode = HttpStatusCode.InternalServerError;
        }
        public CustomException(string message, Exception exception, HttpStatusCode httpStatusCode = HttpStatusCode.BadRequest) : base(message, exception)
        {
            _httpStatusCode = httpStatusCode;
        }
        public CustomException(string message, HttpStatusCode? httpStatusCode, Exception? exception) : base(message, exception)
        {
            _httpStatusCode = (HttpStatusCode)((httpStatusCode.HasValue) ? httpStatusCode : HttpStatusCode.BadRequest);
        }
        public CustomException(string message) : base(message)
        {
            _httpStatusCode = HttpStatusCode.BadRequest;
        }
        public CustomException(Exception? exception) : base(exception!.Message, exception)
        {
            _httpStatusCode = HttpStatusCode.InternalServerError;
        }
        public CustomException(string message, HttpStatusCode? httpStatusCode) : base(message)
        {
            _httpStatusCode = (HttpStatusCode)((httpStatusCode.HasValue) ? httpStatusCode : HttpStatusCode.BadRequest);
        }
    }
}

