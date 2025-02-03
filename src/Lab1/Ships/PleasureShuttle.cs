using Itmo.ObjectOrientedProgramming.Lab1.Engine.PulseEngines;
using Itmo.ObjectOrientedProgramming.Lab1.HullStrength;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships;

public class PleasureShuttle : Ship
{
    /*
     Простой корабль оснащённый импульсным двигателем класса C. Не имеет дефлекторов,
     имеет корпус класса прочности 1 и малые масса-габаритные характеристики.
    */
    public PleasureShuttle()
        : base(new HullStrengthClass1(null), new SmallWeightOverallCharacteristics(), new PulseEnginesClassC())
    {
    }

    public override bool HasAntinitrinoEmitter => false;
}