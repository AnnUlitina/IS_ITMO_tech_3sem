using Itmo.ObjectOrientedProgramming.Lab2.Entities.ProcessorCoolingSystems.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.ProcessorCoolingSystems.Factory;

public class ProcessorCoolingSystemBuilderFactory : IProcessorCoolingSystemBuilderFactory
{
    public IProcessorCoolingSystemBuilder Create()
    {
        return new ProcessorCoolingSystemBuilder();
    }
}