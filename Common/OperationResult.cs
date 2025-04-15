using System;

namespace NginxProxyManager.SDK.Common
{
    /// <summary>
    /// Represents the result of an operation
    /// </summary>
    /// <typeparam name="T">The type of the result</typeparam>
    public class OperationResult<T>
    {
        /// <summary>
        /// Gets whether the operation was successful
        /// </summary>
        public bool IsSuccess { get; }

        /// <summary>
        /// Gets the result of the operation
        /// </summary>
        public T Result { get; }

        /// <summary>
        /// Gets the error that occurred during the operation
        /// </summary>
        public Exception Error { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="OperationResult{T}"/> class with a successful result
        /// </summary>
        /// <param name="result">The result of the operation</param>
        public OperationResult(T result)
        {
            IsSuccess = true;
            Result = result;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OperationResult{T}"/> class with an error
        /// </summary>
        /// <param name="error">The error that occurred during the operation</param>
        public OperationResult(Exception error)
        {
            IsSuccess = false;
            Error = error ?? throw new ArgumentNullException(nameof(error));
        }

        /// <summary>
        /// Creates a successful operation result
        /// </summary>
        /// <param name="result">The result of the operation</param>
        /// <returns>A successful operation result</returns>
        public static OperationResult<T> Success(T result)
        {
            return new OperationResult<T>(result);
        }

        /// <summary>
        /// Creates a failed operation result
        /// </summary>
        /// <param name="error">The error that occurred during the operation</param>
        /// <returns>A failed operation result</returns>
        public static OperationResult<T> Failure(Exception error)
        {
            return new OperationResult<T>(error);
        }
    }
} 