using Itmo.ObjectOrientedProgramming.Lab2.Entities.Processors.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Processors.Factory;

public class ProcessorBuilderFactory : IProcessorBuilderFactory
{
    public IProcessorBuilder Create()
    {
        return new ProcessorBuilder();
    }
}