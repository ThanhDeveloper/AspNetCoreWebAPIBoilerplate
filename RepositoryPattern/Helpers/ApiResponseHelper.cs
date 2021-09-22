using Newtonsoft.Json;

namespace RepositoryPattern.Helpers
{
    public class ApiResponseHelper
    {
        public int StatusCode { get; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; }

        public ApiResponseHelper(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        private static string GetDefaultMessageForStatusCode(int statusCode)
        {
            switch (statusCode)
            {
                case 404:
                    return "Resource not found";

                case 500:
                    return "An unhandled error occurred";

                default:
                    return null;
            }
        }
    }
}
