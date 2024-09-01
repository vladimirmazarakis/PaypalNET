using System.Net;
using System.Runtime.Intrinsics.Arm;
using Newtonsoft.Json;
using PaypalNET.Common.Exceptions;
using PaypalNET.Common.Responses.Error;
using Refit;

namespace PaypalNET.Core.Utilities
{
    internal static class PaypalErrorHandler
    {
        private static JsonSerializerSettings _settings = JsonSerializerSettingsServer.GetSettings(); 

        public static PaypalServiceException HandleApiException(ApiException? exception)
        {
            if(exception is null)
            {
                return new PaypalServiceException("Exception was null.");
            }
            if(exception?.StatusCode is null)
            {
                return new PaypalServiceException("Status code was null.");
            }
            var statusCode = exception.StatusCode;

            bool isIdentityError = statusCode == HttpStatusCode.Unauthorized || statusCode == HttpStatusCode.Forbidden;
            ErrorResponse? errorResponse = null;
            if(!string.IsNullOrEmpty(exception?.Content))
            {
                Type errorType = isIdentityError ? typeof(IdentityErrorResponse) : typeof(ErrorResponse); 
                errorResponse = (ErrorResponse?)JsonConvert.DeserializeObject(exception.Content, type: errorType);
            }

            switch(statusCode)
            {
                case HttpStatusCode.BadRequest:
                    return new PaypalServiceException
                    (errorResponse?.Message
                    , statusCode
                    , errorResponse?.Name
                    , exception);

                case HttpStatusCode.Unauthorized:
                case HttpStatusCode.Forbidden:
                    IdentityErrorResponse? identityError = errorResponse as IdentityErrorResponse;
                    return new PaypalServiceException
                    ("Authentication failed, check your credentials."
                    , statusCode
                    , identityError?.Error
                    , exception);
                
                case HttpStatusCode.InternalServerError:
                case HttpStatusCode.BadGateway:
                    return new TransientPaypalServiceException
                    ("Paypal service is currently unavailable, try again later."
                    , statusCode
                    , errorResponse.Name
                    , exception);
                
                default:
                    return new PaypalServiceException
                    ("An unexpected error occurred while communicating with Paypal."
                    , statusCode
                    , errorResponse.Name
                    , exception);
            }
        }
    }
}