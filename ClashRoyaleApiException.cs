namespace ClashRoyaleApi
{
    /// <summary>
    /// Thrown when the Clash Royale API returns a non-success HTTP response.
    /// The <see cref="Reason"/> property contains the machine-readable error code returned by the API.
    /// </summary>
    public class ClashRoyaleApiException : Exception
    {
        /// <summary>HTTP status code returned by the API.</summary>
        public int StatusCode { get; }

        /// <summary>
        /// Machine-readable error reason returned by the API (e.g. "notFound", "accessDenied", "badRequest").
        /// Empty string if the response body could not be parsed.
        /// </summary>
        public string Reason { get; }

        /// <param name="statusCode">HTTP status code.</param>
        /// <param name="reason">API reason string.</param>
        /// <param name="message">Human-readable error message from the API.</param>
        public ClashRoyaleApiException(int statusCode, string reason, string message)
            : base(string.IsNullOrEmpty(message) ? $"Clash Royale API error {statusCode}: {reason}" : message)
        {
            StatusCode = statusCode;
            Reason = reason;
        }
    }
}
