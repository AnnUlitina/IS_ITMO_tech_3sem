using Itmo.ObjectOrientedProgramming.Lab1.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Space;

public interface ISpace
{
    public DamageResult GetResult(Ship ship);
}