using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Routes;
using Itmo.ObjectOrientedProgramming.Lab1.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Space;

namespace Itmo.ObjectOrientedProgramming.Lab1.Playing;

public class Play
{
    private IEnumerable<Route>? _routesList;
    private IEnumerable<Ship>? _shipsList;
    private IEnumerable<DamageResult>? _statePlayList;

    public Play(IEnumerable<Route>? routesList, IEnumerable<Ship>? shipsList, IEnumerable<DamageResult>? statePlayList)
    {
        _routesList = routesList;
        _shipsList = shipsList;
        _statePlayList = statePlayList;
    }

    public Ship? Plays()
    {
        decimal minCostFuel = 10000;
        Ship? bestShip = null;
        if (_routesList == null || _shipsList == null)
        {
            return bestShip;
        }

        foreach (Route route in _routesList)
        {
            foreach (Ship ship in _shipsList)
            {
                if (route.Fly(ship) == new SpaceState.Success() && ship.CostSpentFuel > minCostFuel)
                {
                    decimal cost = ship.CostSpentFuel;
                    if (cost < minCostFuel)
                    {
                        minCostFuel = cost;
                        bestShip = ship;
                    }
                }
            }
        }

        return bestShip;
    }

    public void Player(Ship ship, Route route)
    {
        _statePlayList?.Append(route?.Fly(ship));
    }

    public void AddShip(Ship ship)
    {
        _shipsList = _shipsList?.Append(ship);
    }

    public void AddRoute(Route route)
    {
        _routesList = _routesList?.Append(route);
    }
}