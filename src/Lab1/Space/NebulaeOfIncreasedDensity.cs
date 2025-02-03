using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Space;

public class NebulaeOfIncreasedDensity : Spaces
{
    public NebulaeOfIncreasedDensity(IEnumerable<IObstacleInSpace>? obstacleInSpace, IEnumerable<double>? segmentsPath)
        : base(obstacleInSpace, segmentsPath)
    {
    }

    protected override DamageResult ResultDistanceTraveled(Ship ship)
    {
        if (ship == null)
            return new SpaceState.NotExistShip();
        if (ship.HasJumpEngine is not null)
            return new SpaceState.NotEnoughJumpEngines();
        if (SegmentsPath != null)
        {
            // для текущего пути маршрута
            foreach (double segment in SegmentsPath)
            {
                StateEngine stateEngine = ship.ResultJumpDistanceTraveled(segment);

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
            DamageResult result = new DeflectorState.CrewDeath();
            if (obstacleInSpace is AntimatterFlares)
            {
                result = ship.TakePhotonicDamage(obstacleInSpace.GiveDamage(ship).Damage);
            }

            if (result != new ShipState.Success())
                return result;
        }

        return new SpaceState.Success();
    }
}