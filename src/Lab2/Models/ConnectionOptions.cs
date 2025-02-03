namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public abstract record ConnectionOptions
{
    public sealed record Pcie : ConnectionOptions;

    public sealed record Sata : ConnectionOptions;
}