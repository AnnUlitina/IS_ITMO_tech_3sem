using Itmo.ObjectOrientedProgramming.Lab2.Services.Specificators;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.VideoCards;

public interface IVideoCardBuilder
{
    public IVideoCardBuilder WithHightVideoCard(string hightVideoCard);

    public IVideoCardBuilder WithWidthVideoCard(string widthVideoCard);

    public IVideoCardBuilder WithVideoMemoryAmount(string videoMemoryAmount);

    public IVideoCardBuilder WithVersionConnectionOptions(string versionConnectionOptions);

    public IVideoCardBuilder WithChipFrequency(string chipFrequency);

    public IVideoCardBuilder WithPowerConsumption(string powerConsumption);

    public IVideoCardBuilder Direct(VideoCardSpecificator videoCardSpecificator);

    IVideoCard Build();
}