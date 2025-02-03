using Itmo.ObjectOrientedProgramming.Lab1.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

public class AntimatterFlares : IObstaclesNebulaOfIncreasedDensity
{
    private const int _damage = 1;

    public AntimatterFlares()
    {
    }

    public ObstaclesState.ObstacleDamage GiveDamage(Ship? ship)
    {
        return new ObstaclesState.ObstacleDamage(_damage);
    }
}