namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public record HousingOfTheSystemUnitType
{
    public record Desktop : HousingOfTheSystemUnitType;

    public record FootPrint : HousingOfTheSystemUnitType;

    public record SlimLine : HousingOfTheSystemUnitType;
    public record UltraSlimLine : HousingOfTheSystemUnitType;

    public record MiniTower : HousingOfTheSystemUnitType;

    public record MidiTower : HousingOfTheSystemUnitType;

    public record FullTower : HousingOfTheSystemUnitType;
}