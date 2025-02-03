using Itmo.ObjectOrientedProgramming.Lab1.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Engine.JumpEngines;
using Itmo.ObjectOrientedProgramming.Lab1.Engine.PulseEngines;
using Itmo.ObjectOrientedProgramming.Lab1.HullStrength;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships;

public class Ship : IShip
{
    private WeightOverallCharacteristics _weightOverallCharacteristics;
    private PulseEngines _pulseEngine;
    private PulseEngines? _jumpEngine;
    private HullStrengthClasses _hull;

    protected Ship(HullStrengthClasses hull, WeightOverallCharacteristics weightOverallCharacteristics, PulseEngines pulseEngine)
    {
        _hull = hull;
        _weightOverallCharacteristics = weightOverallCharacteristics;
        _pulseEngine = pulseEngine;
        _jumpEngine = null;
    }

    public PulseEngines PulseEngine => _pulseEngine;

    public virtual IJumpEngine? HasJumpEngine => null;

    public IDeflector? Deflector => _hull.Deflector;

    public virtual bool HasAntinitrinoEmitter { get; }

    public double PulseSpentFuel => _pulseEngine.SpentFuel;

    public virtual decimal CostSpentFuel => FuelExchange.FuelCost(PulseSpentFuel, null);

    public DamageResult StateShip()
    {
        if (_hull.State() != new ShipState.Success())
        {
            return new ShipState.Destroyed();
        }

        if (!Equals(_pulseEngine.State(), new ShipState.Success()))
        {
            return new ShipState.CrewDeath();
        }

        return new ShipState.Success();
    }

    public virtual StateEngine ResultDistanceTraveled(double distance)
    {
        return _pulseEngine.Travel(distance);
    }

    public virtual StateEngine ResultJumpDistanceTraveled(double distance)
    {
        if (_jumpEngine != null) return _jumpEngine.Travel(distance);
        return new StateEngine.NotEnoughJumpRange();
    }

    public DamageResult TakeDamage(double damage)
    {
        DamageResult result = _hull.TakeDamage(damage);
        if (result != new HullState.Success())
            return result;
        return new ShipState.Success();
    }

    public DamageResult TakePhotonicDamage(double damage)
    {
        DamageResult result = _hull.TakePhotonicDamage(damage);
        if (result != new HullState.Success())
            return result;
        return new ShipState.Success();
    }
}