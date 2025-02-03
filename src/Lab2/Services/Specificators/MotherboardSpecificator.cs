using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Specificators;

public class MotherboardSpecificator
{
    protected internal MotherboardSpecificator()
    {
        string str = string.Empty;
        Name = str;
        Bios = new BiosSpecificator();
        ProcessorSocket = str;
        Chipset = str;
        FormFactor = str;
        NumberOfLinesSolderedOnThePCIEBoard = str;
        NumberOfPortsSolderedOnTheSATABoard = str;
        NumberOfTablesUnderRAM = str;
        SupportedStandardDDR = new List<string>();
    }

    protected internal MotherboardSpecificator(
        string name,
        BiosSpecificator bios,
        string processorSocket,
        string chipset,
        string formFactor,
        string numberOfLinesSolderedOnThePCIEBoard,
        string numberOfPortsSolderedOnTheSATABoard,
        string numberOfTablesUnderRAM,
        IEnumerable<string> supportedStandardDDR)
    {
        Name = name;
        Bios = bios;
        ProcessorSocket = processorSocket;
        Chipset = chipset;
        FormFactor = formFactor;
        NumberOfLinesSolderedOnThePCIEBoard = numberOfLinesSolderedOnThePCIEBoard;
        NumberOfPortsSolderedOnTheSATABoard = numberOfPortsSolderedOnTheSATABoard;
        NumberOfTablesUnderRAM = numberOfTablesUnderRAM;
        SupportedStandardDDR = supportedStandardDDR;
    }

    public string Name { get; set; }
    public BiosSpecificator Bios { get; set; }
    public string ProcessorSocket { get; set; }
    public string Chipset { get; set; }
    public string FormFactor { get; set; }
    public string NumberOfLinesSolderedOnThePCIEBoard { get; set; }
    public string NumberOfPortsSolderedOnTheSATABoard { get; set; }
    public string NumberOfTablesUnderRAM { get; set; }
    public IEnumerable<string> SupportedStandardDDR { get; set; }
}