using Itmo.ObjectOrientedProgramming.Lab2.Entities.BIOSes;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.HousingOfTheSystemUnits;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Motherboards;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PowerUnits;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ProcessorCoolingSystems;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Processors;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.RandomAccessMemories;

namespace Itmo.ObjectOrientedProgramming.Lab2;

public class Computer : IComputer
{
    public Computer(
        Motherboard? motherboard,
        Processor? processor,
        ProcessorCoolingSystem? processorCoolingSystem,
        RandomAccessMemory? randomAccessMemory,
        HousingOfTheSystemUnit? housingOfTheSystemUnit,
        PowerUnit? powerUnit,
        Bios? bios)
    {
        Motherboard = motherboard;
        Processor = processor;
        ProcessorCoolingSystem = processorCoolingSystem;
        RandomAccessMemory = randomAccessMemory;
        HousingOfTheSystemUnit = housingOfTheSystemUnit;
        PowerUnit = powerUnit;
        Bios = bios;
    }

    public Motherboard? Motherboard { get; set; }
    public Processor? Processor { get; set; }
    public ProcessorCoolingSystem? ProcessorCoolingSystem { get; set; }
    public RandomAccessMemory? RandomAccessMemory { get; set; }
    public HousingOfTheSystemUnit? HousingOfTheSystemUnit { get; set; }
    public PowerUnit? PowerUnit { get; set; }
    public Bios? Bios { get; set; }
}