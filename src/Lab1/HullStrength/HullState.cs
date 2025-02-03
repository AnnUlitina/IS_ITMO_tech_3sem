namespace Itmo.ObjectOrientedProgramming.Lab1.HullStrength;

public abstract record HullState
{
    internal sealed record Destroyed : DamageResult;

    internal sealed record Success : DamageResult;
}