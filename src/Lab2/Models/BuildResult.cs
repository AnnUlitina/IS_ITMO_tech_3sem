namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public record BuildResult
{
    public record Success : BuildResult;

    public record Failed : BuildResult;

    public record WorksWithoutWarrantyService : BuildResult;
}