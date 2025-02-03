using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Space;

public class Spaces : ISpace
{
    private IEnumerable<IObstacleInSpace>? _obstacleInSpace;
    private IEnumerable<double>? _segmentsPath;

    protected Spaces(IEnumerable<IObstacleInSpace>? obstacleInSpace, IEnumerable<double>? segmentsPath)
    {
        _obstacleInSpace = obstacleInSpace;
        _segmentsPath = segmentsPath;
    }

    public IEnumerable<double>? SegmentsPath => _segmentsPath;
    public IEnumerable<IObstacleInSpace>? ObstacleInSpaces => _obstacleInSpace;

    public static decimal SpentFuelCost(Ship ship)
    {
        if (ship != null) return ship.CostSpentFuel;
        return 0;
    }

    public void AddPath(double value)
    {
        _segmentsPath = _segmentsPath?.Append(value);
    }

    public void AddPath(IObstacleInSpace value)
    {
        _obstacleInSpace = _obstacleInSpace?.Append(value);
    }

    public DamageResult GetResult(Ship? ship)
    {
        DamageResult damageResult;
        DamageResult successResult = new ShipState.Success();

        if (ship == null)
            return new SpaceState.NotExistShip();

        damageResult = ship.StateShip();
        if (damageResult != successResult)
            return damageResult;

        // урон, проверка на прохождение препятствий
        damageResult = СollisionOfAShipWithObstacles(ship);

        if (damageResult != successResult)
            return damageResult;

        // проверка на хватит ли топлива
        damageResult = ResultDistanceTraveled(ship);
        if (damageResult != successResult)
        {
            return damageResult;
        }

        return new SpaceState.Success();
    }

    // проверка на хватит ли топлива
    protected virtual DamageResult ResultDistanceTraveled(Ship ship)
    {
        if (ship == null)
            return new SpaceState.NotExistShip();
        if (_segmentsPath != null)
        {
            // для текущего пути маршрута
            foreach (double segment in _segmentsPath)
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

    protected virtual DamageResult СollisionOfAShipWithObstacles(Ship? ship)
    {
        if (ship == null)
            return new SpaceState.NotExistShip();

        if (_obstacleInSpace == null)
            return new SpaceState.Success();
        foreach (IObstacleInSpace obstacleInSpace in _obstacleInSpace)
        {
            DamageResult result = ship.TakeDamage(obstacleInSpace.GiveDamage(ship).Damage);
            if (result != new ShipState.Success())
                return result;
        }

        return new SpaceState.Success();
    }
 }