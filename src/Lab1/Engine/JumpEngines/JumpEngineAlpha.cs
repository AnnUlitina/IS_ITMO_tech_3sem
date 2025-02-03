namespace Itmo.ObjectOrientedProgramming.Lab1.Engine.JumpEngines;

public class JumpEngineAlpha : JumpEngine
{
    public JumpEngineAlpha()
        : base(7, 6000, 10, 100)
    {
    }

    public override double FuelConsumption(double currentDistance) // общий расход топлива
    {
        return 3 * currentDistance;
    }
}