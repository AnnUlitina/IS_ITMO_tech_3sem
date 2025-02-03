using Itmo.ObjectOrientedProgramming.Lab2.Services.Specificators;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.RandomAccessMemories.Builders;

public class RandomAccessMemoryBuilder : RandomAccessMemoryBuilderBase
{
    protected override IRandomAccessMemory Create(RandomAccessMemoriesSpecificator randomAccessMemoriesSpecificator)
    {
        return new RandomAccessMemory(randomAccessMemoriesSpecificator);
    }
}