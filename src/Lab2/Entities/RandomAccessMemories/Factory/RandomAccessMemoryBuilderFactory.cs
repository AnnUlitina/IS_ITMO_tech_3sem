using Itmo.ObjectOrientedProgramming.Lab2.Entities.RandomAccessMemories.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.RandomAccessMemories.Factory;

public class RandomAccessMemoryBuilderFactory : IRandomAccessMemoryBuilderFactory
{
    public IRandomAccessMemoryBuilder Create()
    {
        return new RandomAccessMemoryBuilder();
    }
}