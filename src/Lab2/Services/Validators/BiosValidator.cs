using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Validators;

public static class BiosValidator
{
    public static void Validator(ComputerBuilderBase computerBuilderBase)
    {
        if (computerBuilderBase.Bios?.BiosSpecification.TypeBios != computerBuilderBase.Motherboard?.MotherBoardSpecification.Bios.TypeBios)
        {
            computerBuilderBase.BuildResult = new BuildResult.Failed();
        }

        if (computerBuilderBase.Bios?.BiosSpecification.VersionBios !=
            computerBuilderBase.Motherboard?.MotherBoardSpecification?.Bios.VersionBios)
        {
            computerBuilderBase.BuildResult = new BuildResult.Failed();
        }

        computerBuilderBase.BuildResult = new BuildResult.Success();
    }
}