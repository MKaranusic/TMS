namespace TMS.API.Utilities;

public static class Messages
{
    public const string ErrorConnectionStringNotFound = "Connectionstring not found";

    public static class GlobalErrorHandler
    {
        public const string General = "An unexpected error occurred. Please try again later.";
        public const string ValidationFailed = "The request validation failed. Please check your input and try again.";
        public const string InvalidRequest = "The request is invalid or malformed.";
        public const string Unauthorized = "You are not authorized to perform this action.";
        public const string NotFound = "The requested resource was not found.";
        public const string OperationNotAllowed = "This operation is not allowed.";
        public const string Timeout = "The request timed out. Please try again later.";
        public const string Database = "A database error occurred. Please try again later.";
        public const string UnsupportedAction = "The requested action is not supported.";
    }
}
