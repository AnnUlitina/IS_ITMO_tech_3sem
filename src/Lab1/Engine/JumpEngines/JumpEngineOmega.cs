using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Engine.JumpEngines;

public class JumpEngineOmega : JumpEngine
{
    public JumpEngineOmega()
    : base(15, 100000, 30, 200)
    {
    }

    public override double FuelConsumption(double currentDistance)
    {
        return 2 * (currentDistance * Math.Log(currentDistance));
    }
}