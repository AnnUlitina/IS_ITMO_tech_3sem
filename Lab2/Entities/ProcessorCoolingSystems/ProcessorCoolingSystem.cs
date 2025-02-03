using Itmo.ObjectOrientedProgramming.Lab2.Services.Specificators;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.ProcessorCoolingSystems;

public class ProcessorCoolingSystem : IProcessorCoolingSystem
{
    protected internal ProcessorCoolingSystem(ProcessorCoolingSystemSpecificator specificator)
    {
        ProcessorCoolingSystemSpecification = specificator;
    }

    public ProcessorCoolingSystemSpecificator ProcessorCoolingSystemSpecification { get; set; }
}