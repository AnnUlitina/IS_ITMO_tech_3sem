using Itmo.ObjectOrientedProgramming.Lab2.Services.Specificators;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.ProcessorCoolingSystems.Builders;

public class ProcessorCoolingSystemBuilder : ProcessorCoolingSystemBuilderBase
{
    protected override IProcessorCoolingSystem Create(ProcessorCoolingSystemSpecificator processorCoolingSystemSpecificator)
    {
        return new ProcessorCoolingSystem(processorCoolingSystemSpecificator);
    }
}