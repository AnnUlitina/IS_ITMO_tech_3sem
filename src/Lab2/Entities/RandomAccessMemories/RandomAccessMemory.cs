using Itmo.ObjectOrientedProgramming.Lab2.Services.Specificators;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.RandomAccessMemories;

public class RandomAccessMemory : IRandomAccessMemory
{
    public RandomAccessMemory(
        RandomAccessMemoriesSpecificator randomAccessMemoriesSpecificator)
    {
        RandomAccessMemoriesSpecification = randomAccessMemoriesSpecificator;
    }

    public RandomAccessMemoriesSpecificator RandomAccessMemoriesSpecification { get; }
}