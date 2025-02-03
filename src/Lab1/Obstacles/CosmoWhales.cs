using Itmo.ObjectOrientedProgramming.Lab1.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

public class CosmoWhales : IObstaclesInTheNitrineParticle
{
    private const double _damage = 10000;

    public CosmoWhales()
    {
    }

    public ObstaclesState.ObstacleDamage GiveDamage(Ship? ship)
    {
        if (ship?.HasAntinitrinoEmitter == false)
        {
            ship.TakeDamage(_damage);
        }

        return new ObstaclesState.ObstacleDamage(_damage);
    }
}