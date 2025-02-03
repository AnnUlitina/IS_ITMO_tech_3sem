using Itmo.ObjectOrientedProgramming.Lab2.Entities.BIOSes;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.BIOSes.Factory;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.HousingOfTheSystemUnits;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.HousingOfTheSystemUnits.Factory;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Motherboards;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Motherboards.Factory;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PowerUnits;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PowerUnits.Factory;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ProcessorCoolingSystems;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ProcessorCoolingSystems.Factory;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Processors;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Processors.Factory;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.RandomAccessMemories;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.RandomAccessMemories.Factory;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Specificators;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Validators;

namespace Itmo.ObjectOrientedProgramming.Lab2;

public class ComputerBuilder : ComputerBuilderBase
{
    private IMotherboardBuilderFactory _motherboardBuilderFactory;
    private IProcessorBuilderFactory _processorBuilderFactory;
    private IProcessorCoolingSystemBuilderFactory _processorCoolingSystemBuilderFactory;
    private IRandomAccessMemoryBuilderFactory _randomAccessMemoryBuilderFactory;
    private IHousingOfTheSystemUnitsBuilderFactory _housingOfTheSystemUnitsBuilderFactory;
    private IPowerUnitBuilderFactory _powerUnitBuilderFactory;
    private IBiosBuilderFactory _biosBuilderFactory;

    protected internal ComputerBuilder()
    {
        _motherboardBuilderFactory = new MotherboardBuilderFactory();
        _processorBuilderFactory = new ProcessorBuilderFactory();
        _processorCoolingSystemBuilderFactory = new ProcessorCoolingSystemBuilderFactory();
        _randomAccessMemoryBuilderFactory = new RandomAccessMemoryBuilderFactory();
        _housingOfTheSystemUnitsBuilderFactory = new HousingOfTheSystemUnitBuilderFactory();
        _powerUnitBuilderFactory = new PowerUnitBuilderFactory();
        _biosBuilderFactory = new BIOSBuilderFactory();
    }

    public override IComputerBuilder WithMotherboard(MotherboardSpecificator motherboard)
    {
        Motherboard = _motherboardBuilderFactory.Create().Direct(motherboard).Build() as Motherboard;
        return this;
    }

    public override IComputerBuilder WithProcessor(ProcessorSpecificator processor)
    {
        Processor = _processorBuilderFactory.Create().Direct(processor).Build() as Processor;
        return this;
    }

    public override IComputerBuilder WithProcessorCoolingSystem(ProcessorCoolingSystemSpecificator processorCoolingSystem)
    {
        ProcessorCoolingSystem = _processorCoolingSystemBuilderFactory.Create().Direct(processorCoolingSystem).Build() as ProcessorCoolingSystem;
        return this;
    }

    public override IComputerBuilder WithRandomAccessMemory(RandomAccessMemoriesSpecificator randomAccessMemory)
    {
        RandomAccessMemory = _randomAccessMemoryBuilderFactory.Create().Direct(randomAccessMemory).Build() as RandomAccessMemory;
        return this;
    }

    public override IComputerBuilder WithHousingOfTheSystemUnit(HousingOfTheSystemUnitSpecificator housingOfTheSystemUnit)
    {
        HousingOfTheSystemUnit = _housingOfTheSystemUnitsBuilderFactory.Create().Direct(housingOfTheSystemUnit).Build() as HousingOfTheSystemUnit;
        return this;
    }

    public override IComputerBuilder WithBios(BiosSpecificator bios)
    {
        Bios = _biosBuilderFactory.Create().Direct(bios).Build() as Bios;
        return this;
    }

    public override IComputerBuilder WithPowerUnit(PowerUnitSpecificator powerUnit)
    {
        PowerUnit = _powerUnitBuilderFactory.Create().Direct(powerUnit).Build() as PowerUnit;
        return this;
    }

    public override IComputerBuilder Direct(Specificator specificator)
    {
        WithMotherboard(specificator.MotherBoardSpecification);
        WithProcessor(specificator.ProcessorSpecification);
        WithProcessorCoolingSystem(specificator.ProcessorCoolingSystemSpecification);
        WithRandomAccessMemory(specificator.RandomAccessMemorySpecification);
        WithHousingOfTheSystemUnit(specificator.HousingOfTheSystemUnitSpecification);
        WithPowerUnit(specificator.PowerUnitSpecification);
        WithBios(specificator.BiosNameSpecification);
        return this;
    }

    public BuildResult Validate()
    {
        var validator = new Validator(this);
        return validator.Run();
    }

    protected override IComputer? Create(
        Motherboard? motherboard,
        Processor? processor,
        ProcessorCoolingSystem? processorCoolingSystem,
        RandomAccessMemory? randomAccessMemory,
        HousingOfTheSystemUnit? housingOfTheSystemUnit,
        PowerUnit? powerUnit,
        Bios? bios)
    {
        BuildResult = Validate();
        if (BuildResult == new BuildResult.Success())
        {
            return new Computer(
                motherboard,
                processor,
                processorCoolingSystem,
                randomAccessMemory,
                housingOfTheSystemUnit,
                powerUnit,
                bios);
        }

        return default;
    }
}