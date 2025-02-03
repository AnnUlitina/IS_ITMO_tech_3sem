using Itmo.ObjectOrientedProgramming.Lab2.Services.Specificators;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Processors;

public class Processor : IProcessor
{
    public Processor(ProcessorSpecificator processorSpecificator)
    {
        ProcessorSpecificatorS = processorSpecificator;
    }

    public ProcessorSpecificator ProcessorSpecificatorS { get; }
}