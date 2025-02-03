using Itmo.ObjectOrientedProgramming.Lab1.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

public interface IObstacleInSpace
{
    public ObstaclesState.ObstacleDamage GiveDamage(Ship? ship);
}