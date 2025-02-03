using Itmo.ObjectOrientedProgramming.Lab2.Services.Specificators;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.ProcessorCoolingSystems;

public interface IProcessorCoolingSystem
{
    public ProcessorCoolingSystemSpecificator ProcessorCoolingSystemSpecification { get; set; }
}