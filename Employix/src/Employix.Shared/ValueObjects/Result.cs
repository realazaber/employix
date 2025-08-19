namespace Employix.Shared.ValueObjects
{
    public class Result
    {
        public bool IsSuccess { get; }
        public string Message { get; }

        protected Result(bool successful, string message)
        {
            IsSuccess = successful;
            Message = message;
        }

        public static Result Success(string message) => new Result(true, message);
        public static Result Failure(string message) => new Result(false, message);
    }

    public class Result<T> : Result
    {
        public T Value { get; }

        private Result(bool successful, string message, T value = default!)
            : base(successful, message)
        {
            Value = value!;
        }

        public static Result<T> Success(T value, string message)
            => new Result<T>(true, message, value);

        public static new Result<T> Failure(string message)
            => new Result<T>(false, message);
    }
}
