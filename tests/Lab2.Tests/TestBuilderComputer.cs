using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Specificators;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class TestBuilderComputer
{
    private ComputerBuilder _computerBuilder;

    public TestBuilderComputer()
    {
        _computerBuilder = new ComputerBuilder();
    }

    public static Specificator DefaultSpecification1()
    {
        var defaultProcessorSpecificator = new ProcessorSpecificator(
            name: "Core i7-4790",
            coreFrequency: "4400",
            coreCount: "4",
            socket: "LGA1150",
            embeddedVideoCore: "Intel HD Graphics 4600",
            supportedMemoryFrequencies: new List<string>() { "3", "4" },
            thermalDesignPower: "84",
            powerConsumption: "88");
        var defaultMotherboardSpecificator = new MotherboardSpecificator(
            "GIGABYTE B760",
            new BiosSpecificator("BIOS", "4", "AMI", new List<string>() { "LGA1700" }),
            "LGA1700",
            "A320",
            "Atx",
            "5",
            "4",
            "4",
            new List<string>() { "4" });
        var defaultProcessorCoolingSustemSpecificator = new ProcessorCoolingSystemSpecificator(
            thermalDesignPower: "260",
            supportedSockets: new List<string>() { "LGA1150", "LGA1151", "LGA1700" },
            overallDimensions: "322",
            name: "DEEPCOOL AK620 ZERO DARK");
        var defaultRandomAccessMemorySpecificator = new RandomAccessMemoriesSpecificator(
            availableMemorySizeAmount: "16",
            formFactor: "Dimm",
            supportedDdrStandardVersion: new List<string>() { "4" },
            powerConsumption: "30",
            name: "Patriot Viper Venom",
            pair: new List<string>() { "520", "1.2" });
        var defaultHousingOfTheSystemSpecificator = new HousingOfTheSystemUnitSpecificator(
            "DEEPCOOL MATREXX 55 MESH",
            "460",
            "215",
            "345",
            new List<string>() { "Atx" },
            "Desktop");
        var defaultPowerUnitSpecificator = new PowerUnitSpecificator(
            "650",
            "MSI MAG A650BN");
        var defaultBiosSpecificator = new BiosSpecificator(
            "BIOS",
            "4",
            "AMI",
            new List<string>() { "LGA1700" });
        return new Specificator(
            motherboard: defaultMotherboardSpecificator,
            processor: defaultProcessorSpecificator,
            processorCoolingSystem: defaultProcessorCoolingSustemSpecificator,
            randomAccessMemory: defaultRandomAccessMemorySpecificator,
            housingOfTheSystemUnit: defaultHousingOfTheSystemSpecificator,
            powerUnit: defaultPowerUnitSpecificator,
            biosName: defaultBiosSpecificator);
    }

    public static Specificator DefaultSpecification2()
    {
        var defaultProcessorSpecificator = new ProcessorSpecificator(
            "Core i5-4590",
            "5",
            "3",
            "LGA1700",
            "Yes",
            new List<string>() { "3" },
            "84",
            "65");
        var defaultMotherboardSpecificator = new MotherboardSpecificator(
            "GIGABYTE B762",
            new BiosSpecificator("BIOS", "3", "AMI", new List<string>() { "LGA1700" }),
            "LGA1700",
            "B560",
            "Atx",
            "5",
            "4",
            "4",
            new List<string>() { "4" });
        var defaultProcessorCoolingSustemSpecificator = new ProcessorCoolingSystemSpecificator(
            "260",
            new List<string>() { "LGA1150", "LGA1151", "LGA1700", "LGA1155", "LGA1200" },
            "321",
            "DEEPCOOL GAMMAXX 400 EX");
        var defaultRandomAccessMemorySpecificator = new RandomAccessMemoriesSpecificator(
            "16",
            "Dimm",
            new List<string>() { "3" },
            "360",
            "Patriot Viper Elite II",
            new List<string>() { "266", "1.2" });
        var defaultHousingOfTheSystemSpecificator = new HousingOfTheSystemUnitSpecificator(
            "Cougar Duoface Pro RGB",
            "390",
            "190",
            "345",
            new List<string>() { "Eatx" },
            "Desktop");
        var defaultPowerUnitSpecificator = new PowerUnitSpecificator(
            "100",
            "MSI MAG A40BN");
        var defaultBiosSpecificator = new BiosSpecificator(
            "UEFI",
            "3",
            "UEFI",
            new List<string>() { "LGA1700" });

        return new Specificator(
            motherboard: defaultMotherboardSpecificator,
            processor: defaultProcessorSpecificator,
            processorCoolingSystem: defaultProcessorCoolingSustemSpecificator,
            randomAccessMemory: defaultRandomAccessMemorySpecificator,
            housingOfTheSystemUnit: defaultHousingOfTheSystemSpecificator,
            powerUnit: defaultPowerUnitSpecificator,
            biosName: defaultBiosSpecificator);
    }

    [Fact]
    public void TestBuildingCorrectBuilding()
    {
        // Arrange

        // Act
        _computerBuilder.Direct(DefaultSpecification1());
        _computerBuilder.Build();
        BuildResult result = _computerBuilder.BuildResult;

        // Assert
        Assert.Equal(new BuildResult.Success(), result);
    }

    [Fact]
    public void TestSecondISBuilding()
    {
        // Arrange

        // Act
        _computerBuilder.Direct(DefaultSpecification2());
        _computerBuilder.Build();
        BuildResult result = _computerBuilder.BuildResult;

        // Assert
        Assert.Equal(new BuildResult.Success(), result);
    }
}