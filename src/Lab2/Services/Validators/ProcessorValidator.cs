using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Validators;

public static class ProcessorValidator
{
    public static void Validator(ComputerBuilderBase computerBuilderBase)
    {
        if (Equals(
                computerBuilderBase.Processor?.ProcessorSpecificatorS.Socket,
                computerBuilderBase.Motherboard?.MotherBoardSpecification.ProcessorSocket) is false)
        {
            computerBuilderBase.BuildResult = new BuildResult.Failed();
        }

        computerBuilderBase.BuildResult = new BuildResult.Success();
    }
}