using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Specificators;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Motherboards.Builders;

public abstract class MotherboardBuilderBase : IMotherboardBuilder
{
    private MotherboardSpecificator _motherBoardSpecificator;

    protected MotherboardBuilderBase()
    {
        _motherBoardSpecificator = new MotherboardSpecificator();
    }

    public IMotherboardBuilder WithBIOS(BiosSpecificator bios)
    {
        _motherBoardSpecificator.Bios = bios;
        return this;
    }

    public IMotherboardBuilder WithProcessorSocket(string processorSocket)
    {
        _motherBoardSpecificator.ProcessorSocket = processorSocket;
        return this;
    }

    public IMotherboardBuilder WithChipset(string chipset)
    {
        _motherBoardSpecificator.Chipset = chipset;
        return this;
    }

    public IMotherboardBuilder WithSupportedDDRStandard(IEnumerable<string> supportedDdrStandard)
    {
        _motherBoardSpecificator.SupportedStandardDDR = supportedDdrStandard;
        return this;
    }

    public IMotherboardBuilder WithFormFactor(string formFactor)
    {
        _motherBoardSpecificator.FormFactor = formFactor;
        return this;
    }

    public IMotherboardBuilder WithNumberOfLinesSolderedOnThePCIEBoard(string numberOfLinesSolderedOnThePCIEBoard)
    {
        _motherBoardSpecificator.NumberOfLinesSolderedOnThePCIEBoard = numberOfLinesSolderedOnThePCIEBoard;
        return this;
    }

    public IMotherboardBuilder WithNumberOfPortsSolderedOnTheSATABoard(string numberOfPortsSolderedOnTheSATABoard)
    {
        _motherBoardSpecificator.NumberOfPortsSolderedOnTheSATABoard = numberOfPortsSolderedOnTheSATABoard;
        return this;
    }

    public IMotherboardBuilder WithNumberOfTablesUnderRAM(string numberOfTablesUnderRAM)
    {
        _motherBoardSpecificator.NumberOfTablesUnderRAM = numberOfTablesUnderRAM;
        return this;
    }

    public IMotherboardBuilder WithName(string name)
    {
        _motherBoardSpecificator.Name = name;
        return this;
    }

    public IMotherboardBuilder Direct(MotherboardSpecificator specificator)
    {
        WithChipset(specificator.Chipset);
        WithName(specificator.Name);
        WithBIOS(specificator.Bios);
        WithFormFactor(specificator.FormFactor);
        WithSupportedDDRStandard(specificator.SupportedStandardDDR);
        WithProcessorSocket(specificator.ProcessorSocket);
        WithNumberOfTablesUnderRAM(specificator.NumberOfTablesUnderRAM);
        WithNumberOfLinesSolderedOnThePCIEBoard(specificator.NumberOfLinesSolderedOnThePCIEBoard);
        WithNumberOfPortsSolderedOnTheSATABoard(specificator.NumberOfPortsSolderedOnTheSATABoard);
        return this;
    }

    public IMotherboard Build()
    {
        return Create(_motherBoardSpecificator);
    }

    protected abstract IMotherboard Create(MotherboardSpecificator motherBoardSpecificator);
}