using System.Globalization;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Validators;

public static class ProcessorCoolingSystemValidator
{
    public static void Validator(ComputerBuilderBase computerBuilderBase)
    {
        var provider = new NumberFormatInfo();
        if (computerBuilderBase.ProcessorCoolingSystem != null &&
            int.Parse(computerBuilderBase.ProcessorCoolingSystem.ProcessorCoolingSystemSpecification.ThermalDesignPower, provider) <=
            int.Parse(computerBuilderBase.Processor?.ProcessorSpecificatorS.ThermalDesignPower ?? string.Empty, provider))
        {
            computerBuilderBase.BuildResult = new BuildResult.WorksWithoutWarrantyService();
        }

        if (computerBuilderBase.ProcessorCoolingSystem != null &&
            !computerBuilderBase.ProcessorCoolingSystem.ProcessorCoolingSystemSpecification.SupportedSockets.Contains(
                computerBuilderBase.Processor?.ProcessorSpecificatorS.Socket))
        {
            computerBuilderBase.BuildResult = new BuildResult.Failed();
        }

        computerBuilderBase.BuildResult = new BuildResult.Success();
    }
}