using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Specificators;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Motherboards;

public interface IMotherboardBuilder
{
    public IMotherboardBuilder WithBIOS(BiosSpecificator bios);

    public IMotherboardBuilder WithProcessorSocket(string processorSocket);

    public IMotherboardBuilder WithChipset(string chipset);

    public IMotherboardBuilder WithSupportedDDRStandard(IEnumerable<string> supportedDdrStandard);

    public IMotherboardBuilder WithFormFactor(string formFactor);
    public IMotherboardBuilder WithNumberOfLinesSolderedOnThePCIEBoard(string numberOfLinesSolderedOnThePCIEBoard);

    public IMotherboardBuilder WithNumberOfPortsSolderedOnTheSATABoard(string numberOfPortsSolderedOnTheSATABoard);

    public IMotherboardBuilder WithNumberOfTablesUnderRAM(string numberOfTablesUnderRAM);

    public IMotherboardBuilder Direct(MotherboardSpecificator specificator);
    IMotherboard Build();
}