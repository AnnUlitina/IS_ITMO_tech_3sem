using Itmo.ObjectOrientedProgramming.Lab1.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

public class Meteorites : IObstaclesInOrdinarySpace
{
    private const double _damage = 30;
    private uint _meteoritesCount;

    public Meteorites(uint meteoritesCount)
    {
        _meteoritesCount = meteoritesCount;
    }

    public ObstaclesState.ObstacleDamage GiveDamage(Ship? ship)
    {
        return new ObstaclesState.ObstacleDamage(_damage * _meteoritesCount);
    }

    /* public DamageResult GiveDamage(Ship ship)
     {
         if (ship != null && ship.HasAntinitrinoEmitter == false)
         {
             ship.TakeDamage(_damage * _meteoritesCount);
         }
     }*/
}