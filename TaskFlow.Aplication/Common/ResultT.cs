namespace TaskFlow.Application.Common
{
    public class ResultT<T>
    {
        public bool Success { get; private set; }
        public string? Error { get; private set; }
        public T? Data { get; private set; }
        public static ResultT<T> Ok(T data) => new ResultT<T> { Success = true, Data = data };
        public static ResultT<T> Fail(string error) => new ResultT<T> { Success = false, Error = error };
    }
}
