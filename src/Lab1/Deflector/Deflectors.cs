namespace Itmo.ObjectOrientedProgramming.Lab1.Deflector;

public class Deflectors : IDeflector
{
    private double _health;
    protected Deflectors(double hitPoint)
    {
        _health = hitPoint;
    }

    public DamageResult State()
    {
        return _health >= 0 ? new DeflectorState.Success() : new DeflectorState.Destroyed();
    }

    public DeflectorState.RestDamage TakeDamage(double damage)
    {
        double result = _health - damage;
        if (result > 0)
        {
            _health = result;
            return new DeflectorState.RestDamage(0);
        }

        _health = 0;
        return new DeflectorState.RestDamage(-result);
    }
}