namespace Itmo.ObjectOrientedProgramming.Lab1;

public record DamageResult
{
    internal sealed record Success : DamageResult;

    internal sealed record Destroyed : DamageResult;

    internal sealed record CrewDeath : DamageResult;

    internal sealed record NotExistPulseEngine : DamageResult;

    internal sealed record NotExistIntoSpace : DamageResult;

    internal sealed record NotExistShip : DamageResult;

    internal sealed record EngineStalled : DamageResult;

    internal sealed record NotEnoughJumpRange : DamageResult;
}