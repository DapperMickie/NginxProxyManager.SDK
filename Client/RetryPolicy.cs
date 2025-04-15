namespace NginxProxyManager.SDK.Client
{
    /// <summary>
    /// Retry policy for HTTP requests
    /// </summary>
    public enum RetryPolicy
    {
        /// <summary>
        /// No retry policy
        /// </summary>
        None,

        /// <summary>
        /// Linear retry policy (fixed delay between retries)
        /// </summary>
        Linear,

        /// <summary>
        /// Exponential backoff retry policy (increasing delay between retries)
        /// </summary>
        ExponentialBackoff
    }
} 