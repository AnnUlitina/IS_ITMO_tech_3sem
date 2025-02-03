using Itmo.ObjectOrientedProgramming.Lab1.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Engine.JumpEngines;
using Itmo.ObjectOrientedProgramming.Lab1.Engine.PulseEngines;
using Itmo.ObjectOrientedProgramming.Lab1.HullStrength;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships;

public class Stella : Ship
{
    /*
     * Дипломатический корабль. Оснащён импульсным двигателем класса C и прыжковым двигателем класса Omega,
     * имеет дефлекторы класса 1, корпус класса прочности 1 и малые масса-габаритные характеристики.
     */
    private JumpEngineOmega _jumpEngineOmega;
    public Stella(JumpEngineOmega jumpEngineOmega)
        : base(new HullStrengthClass1(new DeflectorClass1()), new SmallWeightOverallCharacteristics(), new PulseEnginesClassC())
    {
        _jumpEngineOmega = jumpEngineOmega;
    }

    public double JumpSpentFuel => _jumpEngineOmega.SpentFuel;

    public override decimal CostSpentFuel => FuelExchange.FuelCost(JumpSpentFuel, JumpSpentFuel);

    public override bool HasAntinitrinoEmitter => false;
    public override IJumpEngine? HasJumpEngine => _jumpEngineOmega;
    public StateEngine ResulJumpDistanceTraveled(double distance)
    {
        return _jumpEngineOmega.Travel(distance);
    }
}