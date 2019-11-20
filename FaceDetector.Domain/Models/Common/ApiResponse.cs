namespace FaceDetector.Domain.Models.Common
{
    public class ApiResponse
    {
        public static string UserResponseMessage { get; set; } = null;
        public int BaseStatusCode { get; set; }
        public string Status { get; set; }
        public object Message { get; set; }
        public object Data { get; set; }

        public ApiResponse(bool success, int code)
        {
            Status = success ? "success" : "error";
            BaseStatusCode = code;
            Message = null;
            Data = null;
        }

        public ApiResponse(bool success, int code, string message)
            : this(success, code)
        {
            Message = message;
        }

        public ApiResponse(bool success, int code, string message, object data)
            : this(success, code, message)
        {
            Data = data;
        }
    }

}
