using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Validators;

public static class HousingOfTheSystemUnitValidator
{
    public static void Validator(ComputerBuilderBase computerBuilderBase)
    {
        if (computerBuilderBase.HousingOfTheSystemUnit?.HousingOfTheSystemUnitSpecification.HousingOfTheSystemUnitType != null
            && computerBuilderBase.HousingOfTheSystemUnit.HousingOfTheSystemUnitSpecification.HousingOfTheSystemUnitType != computerBuilderBase.Motherboard?.MotherBoardSpecification.FormFactor)
        {
            computerBuilderBase.BuildResult = new BuildResult.Failed();
        }

        computerBuilderBase.BuildResult = new BuildResult.Success();
    }
}