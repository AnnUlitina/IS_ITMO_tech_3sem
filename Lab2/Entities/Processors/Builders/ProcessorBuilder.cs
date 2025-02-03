using Itmo.ObjectOrientedProgramming.Lab2.Services.Specificators;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Processors.Builders;

public class ProcessorBuilder : ProcessorBuilderBase
{
    protected override IProcessor Create(
        ProcessorSpecificator processorSpecificator)
    {
        return new Processor(
            processorSpecificator);
    }
}