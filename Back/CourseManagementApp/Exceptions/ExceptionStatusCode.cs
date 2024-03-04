using System.Net;

namespace CourseManagementApp.Exceptions
{
    public static class ExceptionStatusCode
    {
        private static Dictionary<Type, HttpStatusCode> exceptionStatusCodes = new Dictionary<Type, HttpStatusCode>
        {
            {typeof(Exception), HttpStatusCode.InternalServerError},
            {typeof(InvalidTokenException), HttpStatusCode.Unauthorized},
            {typeof(LoginException), HttpStatusCode.Unauthorized}
        };

        public static HttpStatusCode GetExceptionStatusCode(Exception ex)
        {
            bool exceptionFound = exceptionStatusCodes.TryGetValue(ex.GetType(), out var statusCode);
            return exceptionFound ? statusCode : HttpStatusCode.InternalServerError;
        }
    }
}
