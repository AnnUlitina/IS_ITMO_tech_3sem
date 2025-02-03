namespace Itmo.ObjectOrientedProgramming.Lab1;

public class FuelExchange : IFuelCost
{
    private decimal _pulseEnginePrice;
    private decimal _jumpEnginePrice;

    protected FuelExchange(decimal pulseEnginePrice, decimal jumpEnginePrice)
    {
        PulseEnginePrice = pulseEnginePrice;
        JumpEnginePrice = jumpEnginePrice;
    }

    public decimal PulseEnginePrice
    {
        get => _pulseEnginePrice;
        set => _pulseEnginePrice = value;
    }

    public decimal JumpEnginePrice
    {
        get => _jumpEnginePrice;
        set => _jumpEnginePrice = value;
    }

    public decimal FuelCost(double? countFuelPulseEngine, double? countFuelJumpEngine)
    {
        return PulseCost(countFuelPulseEngine) + JumpCost(countFuelJumpEngine);
    }

    private decimal PulseCost(double? countFuelPulseEngine)
    {
        if (countFuelPulseEngine != null)
            return PulseEnginePrice * (decimal)countFuelPulseEngine;
        return 0;
    }

    private decimal JumpCost(double? countFuelJumpEngine)
    {
        if (countFuelJumpEngine != null)
            return JumpEnginePrice * (decimal)countFuelJumpEngine;
        return 0;
    }
}