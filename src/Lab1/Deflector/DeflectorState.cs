namespace Itmo.ObjectOrientedProgramming.Lab1.Deflector;

public abstract record DeflectorState
{
    public sealed record Success : DamageResult;

    public sealed record Destroyed : DamageResult;

    public sealed record CrewDeath : DamageResult;

    public sealed record RestDamage(double Damage) : DamageResult;
    public sealed record Photon(double Damage) : DamageResult;
}