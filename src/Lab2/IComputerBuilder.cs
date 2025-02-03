using Itmo.ObjectOrientedProgramming.Lab2.Services.Specificators;

namespace Itmo.ObjectOrientedProgramming.Lab2;

public interface IComputerBuilder
{
    IComputerBuilder WithMotherboard(MotherboardSpecificator motherboard);
    IComputerBuilder WithProcessor(ProcessorSpecificator processor);
    IComputerBuilder WithProcessorCoolingSystem(ProcessorCoolingSystemSpecificator processorCoolingSystem);
    IComputerBuilder WithRandomAccessMemory(RandomAccessMemoriesSpecificator randomAccessMemory);
    IComputerBuilder WithHousingOfTheSystemUnit(HousingOfTheSystemUnitSpecificator housingOfTheSystemUnit);
    IComputerBuilder WithPowerUnit(PowerUnitSpecificator powerUnit);

    IComputer? Build();
}