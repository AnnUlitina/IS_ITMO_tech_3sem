using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Specificators;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.RandomAccessMemories.Builders;

public abstract class RandomAccessMemoryBuilderBase : IRandomAccessMemoryBuilder
{
    private RandomAccessMemoriesSpecificator _randomAccessMemoriesSpecificator;

    protected RandomAccessMemoryBuilderBase()
    {
        _randomAccessMemoriesSpecificator = new RandomAccessMemoriesSpecificator();
    }

    public IRandomAccessMemoryBuilder WithAvailableMemorySizeAmount(string availableMemorySizeAmount)
    {
        _randomAccessMemoriesSpecificator.AvailableMemorySizeAmount = availableMemorySizeAmount;
        return this;
    }

    public IRandomAccessMemoryBuilder WithFormFactor(string formFactor)
    {
        _randomAccessMemoriesSpecificator.FormFactor = formFactor;
        return this;
    }

    public IRandomAccessMemoryBuilder WithSupportedDDRStandard(IEnumerable<string> supportedDdrStandardVersion)
    {
        _randomAccessMemoriesSpecificator.SupportedDdrStandardVersion = supportedDdrStandardVersion;
        return this;
    }

    public IRandomAccessMemoryBuilder WithPowerConsumption(string powerConsumption)
    {
        _randomAccessMemoriesSpecificator.PowerConsumption = powerConsumption;
        return this;
    }

    public IRandomAccessMemoryBuilder WithName(string name)
    {
        _randomAccessMemoriesSpecificator.Name = name;
        return this;
    }

    public IRandomAccessMemoryBuilder WithPair(IEnumerable<string> pair)
    {
        _randomAccessMemoriesSpecificator.Pair = pair;
        return this;
    }

    public IRandomAccessMemoryBuilder Direct(RandomAccessMemoriesSpecificator specificator)
    {
        WithAvailableMemorySizeAmount(specificator.AvailableMemorySizeAmount);
        WithFormFactor(specificator.FormFactor);
        WithSupportedDDRStandard(specificator.SupportedDdrStandardVersion);
        WithPowerConsumption(specificator.PowerConsumption);
        WithName(specificator.Name);
        WithPair(specificator.Pair);
        return this;
    }

    public IRandomAccessMemory Build()
    {
        return Create(_randomAccessMemoriesSpecificator);
    }

    protected abstract IRandomAccessMemory Create(RandomAccessMemoriesSpecificator randomAccessMemoriesSpecificator);
}