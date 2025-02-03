using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Space;

public class OrdinarySpaces : Spaces
{
    public OrdinarySpaces(IEnumerable<IObstacleInSpace>? obstacleInSpace, IEnumerable<double>? segmentsPath)
        : base(obstacleInSpace, segmentsPath)
    {
    }
}