using Itmo.ObjectOrientedProgramming.Lab2.Services.Specificators;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Motherboards.Builders;

public class MotherboardBuilder : MotherboardBuilderBase
{
    protected override IMotherboard Create(
        MotherboardSpecificator motherBoardSpecificator)
    {
        return new Motherboard(motherBoardSpecificator);
    }
}