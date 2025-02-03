namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Specificators;

public class Specificator
{
    protected internal Specificator(
        MotherboardSpecificator motherboard,
        ProcessorSpecificator processor,
        ProcessorCoolingSystemSpecificator processorCoolingSystem,
        RandomAccessMemoriesSpecificator randomAccessMemory,
        HousingOfTheSystemUnitSpecificator housingOfTheSystemUnit,
        PowerUnitSpecificator powerUnit,
        BiosSpecificator biosName)
    {
        MotherBoardSpecification = motherboard;
        ProcessorSpecification = processor;
        ProcessorCoolingSystemSpecification = processorCoolingSystem;
        RandomAccessMemorySpecification = randomAccessMemory;
        HousingOfTheSystemUnitSpecification = housingOfTheSystemUnit;
        PowerUnitSpecification = powerUnit;
        BiosNameSpecification = biosName;
    }

    public MotherboardSpecificator MotherBoardSpecification { get; set; }
    public ProcessorSpecificator ProcessorSpecification { get; set; }
    public ProcessorCoolingSystemSpecificator ProcessorCoolingSystemSpecification { get; set; }
    public RandomAccessMemoriesSpecificator RandomAccessMemorySpecification { get; set; }
    public HousingOfTheSystemUnitSpecificator HousingOfTheSystemUnitSpecification { get; set; }
    public PowerUnitSpecificator PowerUnitSpecification { get; set; }
    public BiosSpecificator BiosNameSpecification { get; set; }
}