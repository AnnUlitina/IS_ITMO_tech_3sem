using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Specificators;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Processors.Builders;

public abstract class ProcessorBuilderBase : IProcessorBuilder
{
    private ProcessorSpecificator _processorSpecificator;

    protected ProcessorBuilderBase()
    {
        _processorSpecificator = new ProcessorSpecificator();
    }

    public IProcessorBuilder WithCoreFrequency(string coreFrequency)
    {
        _processorSpecificator.CoreFrequency = coreFrequency;
        return this;
    }

    public IProcessorBuilder WithCoreCount(string coreCount)
    {
        _processorSpecificator.CoreCount = coreCount;
        return this;
    }

    public IProcessorBuilder WithSocket(string socket)
    {
        _processorSpecificator.Socket = socket;
        return this;
    }

    public IProcessorBuilder WithEmbeddedVideoCore(string embeddedVideoCore)
    {
        _processorSpecificator.EmbeddedVideoCore = embeddedVideoCore;
        return this;
    }

    public IProcessorBuilder WithSupportedMemoryFrequencies(IEnumerable<string> supportedMemoryFrequencies)
    {
        _processorSpecificator.SupportedMemoryFrequencies = supportedMemoryFrequencies;
        return this;
    }

    public IProcessorBuilder WithThermalDesignPower(string thermalDesignPower)
    {
        _processorSpecificator.ThermalDesignPower = thermalDesignPower;
        return this;
    }

    public IProcessorBuilder WithPowerConsumption(string powerConsumption)
    {
        _processorSpecificator.PowerConsumption = powerConsumption;
        return this;
    }

    public IProcessorBuilder WithName(string name)
    {
        _processorSpecificator.Name = name;
        return this;
    }

    public IProcessorBuilder Direct(ProcessorSpecificator processorSpecificator)
    {
        WithCoreFrequency(processorSpecificator.CoreFrequency);
        WithCoreCount(processorSpecificator.CoreCount);
        WithSocket(processorSpecificator.Socket);
        WithEmbeddedVideoCore(processorSpecificator.EmbeddedVideoCore);
        WithSupportedMemoryFrequencies(processorSpecificator.SupportedMemoryFrequencies);
        WithThermalDesignPower(processorSpecificator.ThermalDesignPower);
        WithPowerConsumption(processorSpecificator.PowerConsumption);
        WithName(processorSpecificator.Name);
        return this;
    }

    public IProcessor Build()
    {
        return Create(
            _processorSpecificator);
    }

    protected abstract IProcessor Create(
        ProcessorSpecificator processorSpecificator);
}