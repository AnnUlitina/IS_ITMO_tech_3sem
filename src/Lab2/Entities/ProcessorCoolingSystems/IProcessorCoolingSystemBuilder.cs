using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Specificators;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.ProcessorCoolingSystems;

public interface IProcessorCoolingSystemBuilder
{
    IProcessorCoolingSystemBuilder WithThermalDesignPower(string thermalDesignPower);
    IProcessorCoolingSystemBuilder WithSupportedSockets(IEnumerable<string> supportedSockets);
    IProcessorCoolingSystemBuilder WithOverallDimensions(string overallDimensions);
    IProcessorCoolingSystemBuilder Direct(ProcessorCoolingSystemSpecificator processorCoolingSystemSpecificator);

    IProcessorCoolingSystem Build();
}