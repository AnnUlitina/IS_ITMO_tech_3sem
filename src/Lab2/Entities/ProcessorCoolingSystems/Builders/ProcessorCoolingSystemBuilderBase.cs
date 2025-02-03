using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Specificators;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.ProcessorCoolingSystems.Builders;

public abstract class ProcessorCoolingSystemBuilderBase : IProcessorCoolingSystemBuilder
{
    private ProcessorCoolingSystemSpecificator _processorCoolingSystemSpecificator;
    protected ProcessorCoolingSystemBuilderBase()
    {
        _processorCoolingSystemSpecificator = new ProcessorCoolingSystemSpecificator();
    }

    public IProcessorCoolingSystemBuilder WithThermalDesignPower(string thermalDesignPower)
    {
        _processorCoolingSystemSpecificator.ThermalDesignPower = thermalDesignPower;
        return this;
    }

    public IProcessorCoolingSystemBuilder WithSupportedSockets(IEnumerable<string> supportedSockets)
    {
        _processorCoolingSystemSpecificator.SupportedSockets = supportedSockets;
        return this;
    }

    public IProcessorCoolingSystemBuilder WithOverallDimensions(string overallDimensions)
    {
        _processorCoolingSystemSpecificator.OverallDimensions = overallDimensions;
        return this;
    }

    public IProcessorCoolingSystemBuilder WithName(string name)
    {
        _processorCoolingSystemSpecificator.Name = name;
        return this;
    }

    public IProcessorCoolingSystemBuilder Direct(ProcessorCoolingSystemSpecificator processorCoolingSystemSpecificator)
    {
        WithThermalDesignPower(processorCoolingSystemSpecificator.ThermalDesignPower);
        WithSupportedSockets(processorCoolingSystemSpecificator.SupportedSockets);
        WithOverallDimensions(processorCoolingSystemSpecificator.OverallDimensions);
        WithName(processorCoolingSystemSpecificator.Name);
        return this;
    }

    public IProcessorCoolingSystem Build()
    {
        return Create(_processorCoolingSystemSpecificator);
    }

    protected abstract IProcessorCoolingSystem Create(ProcessorCoolingSystemSpecificator processorCoolingSystemSpecificator);
}