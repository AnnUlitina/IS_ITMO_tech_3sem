using Itmo.ObjectOrientedProgramming.Lab2.Entities.Motherboards.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Motherboards.Factory;

public class MotherboardBuilderFactory : IMotherboardBuilderFactory
{
    public IMotherboardBuilder Create()
    {
        return new MotherboardBuilder();
    }
}