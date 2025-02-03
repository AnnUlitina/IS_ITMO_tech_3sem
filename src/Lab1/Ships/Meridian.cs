using Itmo.ObjectOrientedProgramming.Lab1.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.Engine.PulseEngines;
using Itmo.ObjectOrientedProgramming.Lab1.HullStrength;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships;

public class Meridian : Ship
{
    /*
     * Добывающий корабль. Оснащён импульсным двигателем класса E и анти-нитринным излучателем,
     * имеет дефлекторы класса 2, корпус класса прочности 2 и средние масса-габаритные характеристики.
     */
    public Meridian()
        : base(
            new HullStrengthClass2(new DeflectorClass2()),
            new MiddleWeightOverallCharacteristics(),
            new PulseEnginesClassE())
    {
    }

    public override bool HasAntinitrinoEmitter => true;
}