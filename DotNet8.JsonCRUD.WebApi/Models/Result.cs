using DotNet8.JsonCRUD.WebApi.Enums;
using DotNet8.JsonCRUD.WebApi.Resources;

namespace DotNet8.JsonCRUD.WebApi.Models
{
    public class Result<T>
    {
        public T Data { get; set; }
        public EnumStatusCode StatusCode { get; set; }
        public bool IsSuccess { get; set; }
        public bool IsError { get; set; }
        public string message { get; set; }

        public static Result<T> Success(
            T data,
            EnumStatusCode statusCode = EnumStatusCode.Success,
            string message = "Success"
            ) =>
            new Result<T>
            {
                IsSuccess = true,
                StatusCode = statusCode,
                message = message,
                Data = data
            };

        public static Result<T> Success(
            string message = "Success",
            EnumStatusCode statusCode = EnumStatusCode.Success
            ) =>
            new Result<T>
            {
                IsSuccess = true,
                StatusCode = statusCode,
                message = message,
            };

        public static Result<T> Failure(
            string message = "Fail.",
            EnumStatusCode statusCode = EnumStatusCode.BadRequest
            ) =>
            new Result<T>
            {
                IsSuccess = false,
                StatusCode = statusCode,
                message = message
            };

        public static Result<T> Failure(
            Exception ex,
            EnumStatusCode statusCode = EnumStatusCode.InternalServerError
            ) =>
            new Result<T>
            {
                IsSuccess = false,
                StatusCode = statusCode,
                message = ex.ToString()
            };

        public static Result<T> ExecuteResult(int result) =>
            result > 0 ? Result<T>.Success(MessageResource.Success) : Result<T>.Failure(MessageResource.Invalid);

        public static Result<T> SaveSuccess() =>
            Result<T>.Success(MessageResource.SavingSuccess);

        public static Result<T> SaveFail() =>
            Result<T>.Success(MessageResource.SavingFail);

        public static Result<T> UpdateSuccess() =>
            Result<T>.Success(MessageResource.UpdateSuccessful);

        public static Result<T> UpdateFail() =>
            Result<T>.Failure(MessageResource.UpdateSuccessful);

        public static Result<T> DeleteSuccess() =>
            Result<T>.Success(MessageResource.DeleteSuccess);

        public static Result<T> DeleteFail() =>
            Result<T>.Failure(MessageResource.DeleteFail);

        public static Result<T> Duplicate() =>
            Result<T>.Failure(MessageResource.Duplicate);

        public static Result<T> NotFound() =>
            Result<T>.Failure(MessageResource.NotFound, EnumStatusCode.NotFound);
    }
}
