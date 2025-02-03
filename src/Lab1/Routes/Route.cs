using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Space;

namespace Itmo.ObjectOrientedProgramming.Lab1.Routes;

public class Route
{
    private IEnumerable<Spaces>? _spacesList;
    public Route(IEnumerable<Spaces>? spacesList)
    {
        _spacesList = spacesList;
    }

    public IEnumerable<Spaces>? SpacesList => _spacesList;

    public DamageResult Fly(Ship ship)
    {
        DamageResult damageResult = new SpaceState.Success();

        if (_spacesList != null)
        {
            foreach (Spaces space in _spacesList)
            {
                damageResult = space.GetResult(ship);
                if (damageResult != new SpaceState.Success())
                    return damageResult;
            }
        }

        return damageResult;
    }

    public void Add(Spaces spaces)
    {
        _spacesList = _spacesList?.Append(spaces);
    }
}