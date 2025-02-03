using Itmo.ObjectOrientedProgramming.Lab2.Entities.BIOSes;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.HousingOfTheSystemUnits;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Motherboards;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PowerUnits;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ProcessorCoolingSystems;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Processors;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.RandomAccessMemories;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Specificators;

namespace Itmo.ObjectOrientedProgramming.Lab2;

public abstract class ComputerBuilderBase : IComputerBuilder
{
    public BuildResult BuildResult { get; set; } = new BuildResult();
    public Motherboard? Motherboard { get; set; }
    public Processor? Processor { get; set; }
    public ProcessorCoolingSystem? ProcessorCoolingSystem { get; set; }
    public RandomAccessMemory? RandomAccessMemory { get; set; }
    public HousingOfTheSystemUnit? HousingOfTheSystemUnit { get; set; }
    public PowerUnit? PowerUnit { get; set; }
    public Bios? Bios { get; set; }

    public abstract IComputerBuilder WithMotherboard(MotherboardSpecificator motherboard);

    public abstract IComputerBuilder WithProcessor(ProcessorSpecificator processor);

    public abstract IComputerBuilder WithProcessorCoolingSystem(ProcessorCoolingSystemSpecificator processorCoolingSystem);

    public abstract IComputerBuilder WithRandomAccessMemory(RandomAccessMemoriesSpecificator randomAccessMemory);

    public abstract IComputerBuilder WithHousingOfTheSystemUnit(HousingOfTheSystemUnitSpecificator housingOfTheSystemUnit);

    public abstract IComputerBuilder WithPowerUnit(PowerUnitSpecificator powerUnit);
    public abstract IComputerBuilder WithBios(BiosSpecificator bios);
    public abstract IComputerBuilder Direct(Specificator specificator);

    public IComputer? Build()
    {
        return Create(
            Motherboard,
            Processor,
            ProcessorCoolingSystem,
            RandomAccessMemory,
            HousingOfTheSystemUnit,
            PowerUnit,
            Bios);
    }

    protected abstract IComputer? Create(
        Motherboard? motherboard,
        Processor? processor,
        ProcessorCoolingSystem? processorCoolingSystem,
        RandomAccessMemory? randomAccessMemory,
        HousingOfTheSystemUnit? housingOfTheSystemUnit,
        PowerUnit? powerUnit,
        Bios? bios);
}