namespace Itmo.ObjectOrientedProgramming.Lab1.Engine.JumpEngines;

public class JumpEngineGamma : JumpEngine
{
    public JumpEngineGamma()
        : base(10, 9000, 15, 150)
    {
    }

    public override double FuelConsumption(double currentDistance)
    {
        return 3 * currentDistance * currentDistance;
    }
}