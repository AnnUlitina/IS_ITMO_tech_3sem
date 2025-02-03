using Itmo.ObjectOrientedProgramming.Lab2.Entities.Motherboards.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Motherboards.Factory;

public class SupportedDDRStandardBuilderFactory : IMotherboardBuilderFactory
{
    private ISupportedDDRStandard _supportedDdrStandard;

    public SupportedDDRStandardBuilderFactory(ISupportedDDRStandard supportedDdrStandard)
    {
        _supportedDdrStandard = supportedDdrStandard;
    }

    public IMotherboardBuilder Create()
    {
        return new MotherboardBuilder();
    }
}