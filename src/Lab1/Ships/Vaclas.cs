using Itmo.ObjectOrientedProgramming.Lab1.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Engine.JumpEngines;
using Itmo.ObjectOrientedProgramming.Lab1.Engine.PulseEngines;
using Itmo.ObjectOrientedProgramming.Lab1.HullStrength;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships;

public class Vaclas : Ship
{
    /*
     * Исследовательский корабль. Оснащён импульсным двигателем класса E и прыжковым двигателем класса Gamma,
     * имеет дефлекторы класса 1, корпус класса прочности 2 и средние масса-габаритные характеристики.
     */

    private JumpEngineGamma _jumpEngineGamma;

    public Vaclas(JumpEngineGamma jumpEngineGamma)
        : base(new HullStrengthClass2(new DeflectorClass1()), new MiddleWeightOverallCharacteristics(), new PulseEnginesClassE())
    {
        _jumpEngineGamma = jumpEngineGamma;
    }

    public double JumpSpentFuel => _jumpEngineGamma.SpentFuel;

    public override decimal CostSpentFuel => FuelExchange.FuelCost(JumpSpentFuel, JumpSpentFuel);
    public override bool HasAntinitrinoEmitter => false;
    public override IJumpEngine? HasJumpEngine => _jumpEngineGamma;
    public StateEngine ResulJumpDistanceTraveled(double distance)
    {
        return _jumpEngineGamma.Travel(distance);
    }
}