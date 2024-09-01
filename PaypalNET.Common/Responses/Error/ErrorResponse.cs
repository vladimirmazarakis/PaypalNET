using PaypalNET.Common.Models;

namespace PaypalNET.Common.Responses.Error
{
    public record ErrorResponse(string Name, string Message, string DebugId, List<ErrorDetail> Details, HATEOASLinkList Links);

    public record IdentityErrorResponse
    (string Name, string Message, string DebugId, List<ErrorDetail> Details, HATEOASLinkList Links
    , string Error, string ErrorDescription) 
    : ErrorResponse(Name, Message, DebugId, Details, Links);


    public record ErrorDetail(string Field, string Value, string Location, string Issue, string Description);
}