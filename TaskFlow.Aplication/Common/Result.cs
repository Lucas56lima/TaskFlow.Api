namespace TaskFlow.Application.Common
{
    public class Result
    {
        public bool Success { get; private set; }
        public string? Error { get; private set; }

        public static Result Ok() => new Result { Success = true };
        public static Result Fail(string error) => new Result { Success = false, Error = error };
    }
}
