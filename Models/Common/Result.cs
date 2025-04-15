using System;
using System.Collections.Generic;

namespace NginxProxyManager.SDK.Models.Common
{
    public class Result<T>
    {
        public bool IsSuccess { get; }
        public T Data { get; }
        public string Error { get; }
        public Dictionary<string, string[]> ValidationErrors { get; }

        private Result(bool isSuccess, T data, string error = null, Dictionary<string, string[]> validationErrors = null)
        {
            IsSuccess = isSuccess;
            Data = data;
            Error = error;
            ValidationErrors = validationErrors;
        }

        public static Result<T> Success(T data) => new Result<T>(true, data);

        public static Result<T> Failure(string error) => new Result<T>(false, default, error);

        public static Result<T> ValidationFailure(Dictionary<string, string[]> validationErrors) => 
            new Result<T>(false, default, "Validation failed", validationErrors);

        public static Result<T> FromException(Exception ex) => 
            new Result<T>(false, default, ex.Message);
    }
} 