namespace Itmo.ObjectOrientedProgramming.Lab1.Ships;

public abstract record ShipState
{
    public sealed record Success : DamageResult;

    public sealed record Destroyed : DamageResult;
    public sealed record CrewDeath : DamageResult;
}