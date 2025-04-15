using System;
using System.Net;

namespace NginxProxyManager.SDK.Common
{
    /// <summary>
    /// Exception thrown when an HTTP request fails
    /// </summary>
    public class HttpRequestException : Exception
    {
        /// <summary>
        /// Gets the HTTP status code of the response
        /// </summary>
        public HttpStatusCode StatusCode { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpRequestException"/> class
        /// </summary>
        /// <param name="message">The error message</param>
        public HttpRequestException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpRequestException"/> class
        /// </summary>
        /// <param name="message">The error message</param>
        /// <param name="innerException">The inner exception</param>
        public HttpRequestException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpRequestException"/> class
        /// </summary>
        /// <param name="statusCode">The HTTP status code</param>
        /// <param name="message">The error message</param>
        public HttpRequestException(HttpStatusCode statusCode, string message) : base(message)
        {
            StatusCode = statusCode;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpRequestException"/> class
        /// </summary>
        /// <param name="statusCode">The HTTP status code</param>
        /// <param name="message">The error message</param>
        /// <param name="innerException">The inner exception</param>
        public HttpRequestException(HttpStatusCode statusCode, string message, Exception innerException) : base(message, innerException)
        {
            StatusCode = statusCode;
        }
    }
} 