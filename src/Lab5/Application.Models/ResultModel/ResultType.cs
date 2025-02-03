namespace Application.Models.ResultModel;

public record ResultType
{
    public sealed record None : ResultType;

    public sealed record Success : ResultType;

    public sealed record Failure : ResultType;
}