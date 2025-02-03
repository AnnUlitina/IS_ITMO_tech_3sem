namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Specificators;

public class VideoCardSpecificator
{
    protected internal VideoCardSpecificator()
    {
        string str = string.Empty;
        HightVideoCard = str;
        WidthVideoCard = str;
        VideoMemoryAmount = str;
        VersionConnectionOptions = str;
        ChipFrequency = str;
        PowerConsumption = str;
    }

    protected internal VideoCardSpecificator(
        string hightVideoCard,
        string widthVideoCard,
        string videoMemoryAmount,
        string versionConnectionOptions,
        string chipFrequency,
        string powerConsumption)
    {
        HightVideoCard = hightVideoCard;
        WidthVideoCard = widthVideoCard;
        VideoMemoryAmount = videoMemoryAmount;
        VersionConnectionOptions = versionConnectionOptions;
        ChipFrequency = chipFrequency;
        PowerConsumption = powerConsumption;
    }

    public string HightVideoCard { get; set; }
    public string WidthVideoCard { get; set; }
    public string VideoMemoryAmount { get; set; }
    public string VersionConnectionOptions { get; set; }
    public string ChipFrequency { get; set; }
    public string PowerConsumption { get; set; }
}