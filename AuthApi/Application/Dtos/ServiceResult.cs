namespace AuthApi.Application.Dtos;

public class ServiceResult
{
    public bool IsSuccessful { get; set; }
    public string Message { get; set; }
    public bool IsFailed {
        get { return !IsSuccessful; }
    }

    public ServiceResult() { }

    public ServiceResult(bool isSuccessful) {
        IsSuccessful = isSuccessful;
        Message = string.Empty;
    }

    public ServiceResult(bool isSuccessful, string message)
        : this(isSuccessful) {
        Message = message;
    }

    public static ServiceResult InternalServerError() {
        return new ServiceResult(false, "Internal server error");
    }
}

public class ServiceResult<T> : ServiceResult {
    public T Data { get; set; }

    public ServiceResult() { }

    public ServiceResult(bool isSuccessful) : base(isSuccessful) { }

    public ServiceResult(bool isSuccessful, string message) : base(isSuccessful, message) { }

    public ServiceResult(bool isSuccessful, string message, T data) : base(isSuccessful, message) {
        Data = data;
    }

    public ServiceResult(bool isSuccessful, T data) : base(isSuccessful, string.Empty) {
        Data = data;
    }
}