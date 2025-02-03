namespace Itmo.ObjectOrientedProgramming.Lab1.Engine.JumpEngines;

public class JumpEngine : IJumpEngine
{
    private double _startWorkingFuel;
    private double _availableFuel;
    private double _fuelTankCapacity;
    private double _fuelConsumptionRate;
    private double _limitJumpDistance;

    protected JumpEngine(double startWorkingFuel, double fuelTankCapacity, double fuelConsumptionRate, double limitJumpDistance)
    {
        _startWorkingFuel = startWorkingFuel;
        _fuelTankCapacity = fuelTankCapacity;
        _availableFuel = fuelTankCapacity;
        _fuelConsumptionRate = fuelConsumptionRate;
        _limitJumpDistance = limitJumpDistance;
    }

    public double SpentFuel => _fuelTankCapacity - _availableFuel;

    public virtual double FuelConsumption(double currentDistance) // общий расход топлива
    {
        double fuel = _fuelConsumptionRate * currentDistance;
        fuel += _startWorkingFuel;
        return fuel;
    }

    public void ChangeFuel(double fuel) // тратим топливо
    {
        _availableFuel -= fuel;

        if (_availableFuel <= 0)
        {
            _availableFuel = 0;
        }
    }

    public StateEngine Travel(double distance) // потратить топливо на расстояние
    {
        if (distance > _limitJumpDistance)
            return new StateEngine.NotEnoughJumpRange();
        ChangeFuel(FuelConsumption(distance));
        if (_availableFuel == 0) return new StateEngine.Stalled();
        return new StateEngine.Working();
    }

    /*   public virtual PulseEngineType PulseEngineType { get; }*/
}