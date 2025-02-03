using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Specificators;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.RandomAccessMemories;

public interface IRandomAccessMemoryBuilder
{
    public IRandomAccessMemoryBuilder WithAvailableMemorySizeAmount(string availableMemorySizeAmount);

    public IRandomAccessMemoryBuilder WithFormFactor(string formFactor);

    public IRandomAccessMemoryBuilder WithSupportedDDRStandard(IEnumerable<string> supportedDdrStandardVersion);

    public IRandomAccessMemoryBuilder WithPowerConsumption(string powerConsumption);
    public IRandomAccessMemoryBuilder WithName(string name);
    public IRandomAccessMemoryBuilder WithPair(IEnumerable<string> pair);

    public IRandomAccessMemoryBuilder Direct(RandomAccessMemoriesSpecificator specificator);

    IRandomAccessMemory Build();
}