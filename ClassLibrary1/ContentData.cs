using System.Net;
using System.Text.Json;

namespace ClassLibrary1
{
    public class ContentData<T>
    {
        public static ContentData<T> GenerateValid(T input)
        {
            return new ContentData<T>()
            {
                Data = input,
                IsValid = true
            };
        }

        public static ContentData<T> GenerateErr(string errMsg)
        {
            return new ContentData<T>()
            {
                IsValid = false,
                ErrorDetails = new ErrorDetails()
                {
                    Message = errMsg,
                    // StatusCode = (int)HttpStatusCode.ServiceUnavailable
                    StatusCode = (int)HttpStatusCode.InternalServerError
                    // StatusCode = StatusCodes.Status408RequestTimeout
                    
                }
            };
        }

        public T Data { get; set; }
        public bool IsValid { get; set; }
        public ErrorDetails ErrorDetails { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}