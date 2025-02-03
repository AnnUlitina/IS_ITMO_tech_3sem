using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Engine.PulseEngines;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Space;

public class NebulaeOfNitrineParticles : Spaces
{
    public NebulaeOfNitrineParticles(IEnumerable<IObstacleInSpace>? obstacleInSpace, IEnumerable<double>? segmentsPath)
        : base(obstacleInSpace, segmentsPath)
    {
    }

    protected override DamageResult ResultDistanceTraveled(Ship ship)
    {
        if (ship == null)
            return new SpaceState.NotExistShip();
        if (ship.PulseEngine is PulseEnginesClassE)
            return new SpaceState.NotEnoughPulseEngineClassE();

        if (SegmentsPath != null)
        {
            // для текущего пути маршрута
            foreach (double segment in SegmentsPath)
            {
                StateEngine stateEngine = ship.ResultDistanceTraveled(segment);

                // проверка на хватит ли топлива
                if (stateEngine != new StateEngine.Working())
                {
                    return new SpaceState.EngineStalled();
                }
            }
        }

        return new SpaceState.Success();
    }

    protected override DamageResult СollisionOfAShipWithObstacles(Ship? ship)
    {
        if (ship == null)
            return new SpaceState.NotExistShip();

        if (ObstacleInSpaces == null)
            return new SpaceState.Success();
        foreach (IObstacleInSpace obstacleInSpace in ObstacleInSpaces)
        {
            DamageResult result = new ShipState.Success();

            // космокиты
            if (obstacleInSpace is IObstaclesInTheNitrineParticle)
            {
                if (!ship.HasAntinitrinoEmitter)
                    result = ship.TakeDamage(obstacleInSpace.GiveDamage(ship).Damage);
            }

            if (result != new ShipState.Success())
                return result;
        }

        return new SpaceState.Success();
    }
}