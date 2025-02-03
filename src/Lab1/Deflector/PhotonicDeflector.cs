namespace Itmo.ObjectOrientedProgramming.Lab1.Deflector;

public class PhotonicDeflector : IPhotonicDeflector
{
    private Deflectors _deflector;
    private double _flairs;
    public PhotonicDeflector(Deflectors deflector)
    {
        _deflector = deflector;
        _flairs = 6;
    }

    public DamageResult State()
    {
        if (_deflector.State() == new DeflectorState.Success())
            return _flairs > 0 ? new DeflectorState.Success() : new DeflectorState.CrewDeath();
        return _deflector.State();
    }

    public DamageResult TakePhotonicDamage(double damage)
    {
        _flairs -= damage;
        if (_flairs > 0)
        {
            return new DeflectorState.Success();
        }

        _flairs = 0;

        return new DeflectorState.CrewDeath();
    }

    public DeflectorState.RestDamage TakeDamage(double damage)
    {
        return _deflector.TakeDamage(damage);
    }
}