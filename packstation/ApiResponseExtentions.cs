namespace packstation
{
    public class ApiResponseExtentions
    {
        public static ApiResponse Success(object data, string message = "Success")
        => new ApiResponse
        {
            Status = true,
            Message = message,
            Data = data
        };

        public static ApiResponse Fail(string message, List<string> errors = null)
            => new ApiResponse
            {
                Status = false,
                Message = message,
                Errors = errors ?? new List<string>()
            };
    }
}
