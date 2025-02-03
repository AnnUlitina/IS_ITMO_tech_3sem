namespace Application.Models.ResultModel;

public class Result
{
    public Result(ResultType resultType, string message)
    {
        ResultType = resultType;
        Message = message;
    }

    public ResultType ResultType { get; } = new ResultType.None();
    public string Message { get; }
}