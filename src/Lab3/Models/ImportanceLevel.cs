namespace Itmo.ObjectOrientedProgramming.Lab3.Models;

public record ImportanceLevel
{
    public sealed record High(int ImportanceValue = 3) : ImportanceLevel;

    public sealed record Middle(int ImportanceValue = 5) : ImportanceLevel;

    public sealed record Low(int ImportanceValue = 10) : ImportanceLevel;
}