namespace Itmo.ObjectOrientedProgramming.Lab1.Engine.PulseEngines;

public class PulseEngines : IPulseEngine
{
    private double _startWorkingFuel;
    private double _availableFuel;
    private double _fuelTankCapacity;
    private double _fuelConsumptionRate;

    protected PulseEngines(double startWorkingFuel, double fuelTankCapacity, double fuelConsumptionRate)
    {
        _startWorkingFuel = startWorkingFuel;
        _fuelTankCapacity = fuelTankCapacity;
        _availableFuel = fuelTankCapacity;
        _fuelConsumptionRate = fuelConsumptionRate;
    }

    public double SpentFuel => _fuelTankCapacity - _availableFuel;

    public StateEngine State()
    {
        return _availableFuel >= 0 ? new StateEngine.Working() : new StateEngine.Stalled();
    }

    public virtual double FuelConsumption(double currentDistance)
    {
        double fuel = _fuelConsumptionRate * currentDistance;
        fuel += _startWorkingFuel;
        return fuel;
    }

    public void ChangeFuel(double fuel)
    {
        _availableFuel -= fuel;

        if (_availableFuel <= 0)
        {
            _availableFuel = 0;
        }
    }

    public StateEngine Travel(double distance)
    {
        ChangeFuel(FuelConsumption(distance));
        if (_availableFuel == 0) return new StateEngine.Stalled();
        return new StateEngine.Working();
    }
}