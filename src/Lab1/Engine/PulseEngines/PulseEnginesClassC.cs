namespace Itmo.ObjectOrientedProgramming.Lab1.Engine.PulseEngines;

public class PulseEnginesClassC : PulseEngines
{
    public PulseEnginesClassC()
        : base(10, 100000, 500)
    {
    }

    public override double FuelConsumption(double currentDistance)
    {
        return currentDistance * 500;
    }
}