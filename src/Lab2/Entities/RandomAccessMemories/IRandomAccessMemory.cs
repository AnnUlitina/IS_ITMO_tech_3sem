using Itmo.ObjectOrientedProgramming.Lab2.Services.Specificators;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.RandomAccessMemories;

public interface IRandomAccessMemory
{
    public RandomAccessMemoriesSpecificator RandomAccessMemoriesSpecification { get; }
}