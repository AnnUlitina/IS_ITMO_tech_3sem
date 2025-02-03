namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public record TypesSupportedFormFactorsMotherboard
{
    public record Atx : TypesSupportedFormFactorsMotherboard;
    public record MicroAtx : TypesSupportedFormFactorsMotherboard;
    public record Eatx : TypesSupportedFormFactorsMotherboard;
    public record MiniAtx : TypesSupportedFormFactorsMotherboard;
    public record MiniItx : TypesSupportedFormFactorsMotherboard;
    public record MiniStx : TypesSupportedFormFactorsMotherboard;
}