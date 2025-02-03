using Itmo.ObjectOrientedProgramming.Lab2.Services.Specificators;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Motherboards;

public class Motherboard : IMotherboard
{
    public Motherboard(
        MotherboardSpecificator motherBoardSpecificator)
    {
        MotherBoardSpecification = motherBoardSpecificator;
    }

    public MotherboardSpecificator MotherBoardSpecification { get; set; }
}