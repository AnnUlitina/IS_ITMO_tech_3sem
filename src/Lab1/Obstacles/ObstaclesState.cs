namespace Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

public abstract record ObstaclesState
{
    public sealed record ObstacleDamage(double Damage) : ObstaclesState;
}