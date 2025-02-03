using Itmo.ObjectOrientedProgramming.Lab1.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Engine.JumpEngines;
using Itmo.ObjectOrientedProgramming.Lab1.Engine.PulseEngines;
using Itmo.ObjectOrientedProgramming.Lab1.HullStrength;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships;

public class Augur : Ship
{
    /*
     * Боевой корабль. Оснащён импульсным двигателем класса E и прыжковым двигателем класса Alpha,
     * имеет дефлекторы класса 3, корпус класса прочности 3 и большие масса-габаритные характеристики.
     */
    private JumpEngineAlpha _jumpEngineAlpha;

    public Augur(JumpEngineAlpha jumpEngineAlpha)
        : base(new HullStrengthClass3(new DeflectorClass3()), new BigWeightOverallCharacterictics(), new PulseEnginesClassE())
    {
        _jumpEngineAlpha = jumpEngineAlpha;
    }

    public override IJumpEngine? HasJumpEngine => _jumpEngineAlpha;

    public double JumpSpentFuel => _jumpEngineAlpha.SpentFuel;

    public override decimal CostSpentFuel => FuelExchange.FuelCost(JumpSpentFuel, JumpSpentFuel);

    public override bool HasAntinitrinoEmitter => false;

    // топливо
    public StateEngine ResulJumpDistanceTraveled(double distance)
    {
        return _jumpEngineAlpha.Travel(distance);
    }
}