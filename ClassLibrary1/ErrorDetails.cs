using System.Text.Json;

namespace ClassLibrary1
{
    public class ErrorDetails
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        

        public override string ToString()
        {
            var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase};
            return JsonSerializer.Serialize(this,options);
        }
    }
}