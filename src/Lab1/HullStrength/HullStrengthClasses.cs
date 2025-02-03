using Itmo.ObjectOrientedProgramming.Lab1.Deflector;

namespace Itmo.ObjectOrientedProgramming.Lab1.HullStrength;

public class HullStrengthClasses
{
    private double _health;
    private Deflectors? _deflector;
    protected HullStrengthClasses(double hitPoint, Deflectors? deflector)
    {
        _health = hitPoint;
        _deflector = deflector;
    }

    public IDeflector? Deflector => _deflector;

    public DamageResult State()
    {
        return _health <= 0 ? new HullState.Destroyed() : new HullState.Success();
    }

    public DamageResult TakeDamage(double damage)
    {
        if (_deflector != null)
        {
            damage = _deflector.TakeDamage(damage).Damage;
        }

        _health -= damage;
        if (_health <= 0)
            return new HullState.Destroyed();
        else return new HullState.Success();
    }

    public DamageResult TakePhotonicDamage(double damage)
    {
        if (_deflector != null)
        {
            DamageResult result = _deflector.State();
            if (result == new HullState.Success())
            {
                _deflector.TakeDamage(damage);
            }
        }

        return State();
    }
}