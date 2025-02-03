namespace Itmo.ObjectOrientedProgramming.Lab1.Deflector;

public interface IDeflector
{
    public DeflectorState.RestDamage TakeDamage(double damage);
}