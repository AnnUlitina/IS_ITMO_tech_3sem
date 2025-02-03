using Itmo.ObjectOrientedProgramming.Lab1.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

public class SmallAsteroids : IObstacleInSpace
{
    private const double _damage = 5;

    public SmallAsteroids(uint smallAsteroidsCount)
    {
        SmallAsteroidsCount = smallAsteroidsCount;
    }

    private uint SmallAsteroidsCount { get; set; }

    public ObstaclesState.ObstacleDamage GiveDamage(Ship? ship)
    {
        return new ObstaclesState.ObstacleDamage(_damage * SmallAsteroidsCount);
    }
}