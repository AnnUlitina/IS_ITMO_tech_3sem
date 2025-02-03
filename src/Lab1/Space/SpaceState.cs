namespace Itmo.ObjectOrientedProgramming.Lab1.Space;

public abstract record SpaceState
{
    public sealed record Success : DamageResult;

    public sealed record NotExistShip : DamageResult;

    public sealed record NotEnoughJumpRange : DamageResult;
    public sealed record NotEnoughAntinitrino : DamageResult;
    public sealed record NotEnoughPulseEngineClassE : DamageResult;
    public sealed record NotEnoughJumpEngines : DamageResult;
    public sealed record EngineStalled : DamageResult;
}