using System.Text.Json;

namespace ClassLibrary1
{
    public class ErrorInternal
    {
        public string Message { get; set; }
        public string StackTrace { get; set; }

        public override string ToString()
        {
            var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase};
            return JsonSerializer.Serialize(this,options);
        }
    }
}