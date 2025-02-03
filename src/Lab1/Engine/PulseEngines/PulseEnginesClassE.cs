using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Engine.PulseEngines;

public class PulseEnginesClassE : PulseEngines
{
    public PulseEnginesClassE()
        : base(20, 200000, 1000)
    {
    }

    public override double FuelConsumption(double currentDistance)
    {
        return currentDistance * Math.Exp(1000);
    }
}