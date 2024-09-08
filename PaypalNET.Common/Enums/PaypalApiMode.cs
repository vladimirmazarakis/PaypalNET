using PaypalNET.Common.Options;

namespace PaypalNET.Common.Enums
{
    /// <summary>
    /// Used to determine to which Endpoint to make requests to. See using: <see cref="PaypalApiOptions.Mode"/>
    /// </summary>
    public enum PaypalApiMode
    {
        Sandbox,
        Live
    }
}