using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Specificators;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Processors;

public interface IProcessorBuilder
{
    public IProcessorBuilder WithCoreFrequency(string coreFrequency);

    public IProcessorBuilder WithCoreCount(string coreCount);

    public IProcessorBuilder WithSocket(string socket);

    public IProcessorBuilder WithEmbeddedVideoCore(string embeddedVideoCore);

    public IProcessorBuilder WithSupportedMemoryFrequencies(IEnumerable<string> supportedMemoryFrequencies);

    public IProcessorBuilder WithThermalDesignPower(string thermalDesignPower);

    public IProcessorBuilder WithPowerConsumption(string powerConsumption);
    public IProcessorBuilder WithName(string name);
    public IProcessorBuilder Direct(ProcessorSpecificator processorSpecificator);
    IProcessor Build();
}