using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Validators;

public static class RAMValidator
{
    public static void Validator(ComputerBuilderBase computerBuilderBase)
    {
        if (computerBuilderBase.Motherboard?.MotherBoardSpecification.SupportedStandardDDR != null &&
            computerBuilderBase.RandomAccessMemory?.RandomAccessMemoriesSpecification.SupportedDdrStandardVersion !=
            null &&
            computerBuilderBase.RandomAccessMemory.RandomAccessMemoriesSpecification.SupportedDdrStandardVersion !=
            computerBuilderBase.Motherboard.MotherBoardSpecification.SupportedStandardDDR)
        {
            computerBuilderBase.BuildResult = new BuildResult.Failed();
        }

        computerBuilderBase.BuildResult = new BuildResult.Success();
    }
}