namespace Itmo.ObjectOrientedProgramming.Lab1.Engine;

public record StateEngine
{
    public sealed record Working : StateEngine;

    public sealed record Stalled : StateEngine;

    public sealed record NotEnoughJumpRange : StateEngine;
}