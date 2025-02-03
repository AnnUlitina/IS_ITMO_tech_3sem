using System.Globalization;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Validators;

public static class PowerUnitValidator
{
    public static void Validator(ComputerBuilderBase computerBuilderBase)
    {
        var provider = new NumberFormatInfo();
        if (computerBuilderBase.PowerUnit != null && computerBuilderBase.RandomAccessMemory != null &&
            int.Parse(computerBuilderBase.PowerUnit.PowerUnitSpecification.PeakLoad, provider) <=
            int.Parse(computerBuilderBase.RandomAccessMemory.RandomAccessMemoriesSpecification.PowerConsumption, provider))
        {
            computerBuilderBase.BuildResult = new BuildResult.Failed();
        }

        computerBuilderBase.BuildResult = new BuildResult.Success();
    }
}