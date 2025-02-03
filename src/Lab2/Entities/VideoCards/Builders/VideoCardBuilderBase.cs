using Itmo.ObjectOrientedProgramming.Lab2.Services.Specificators;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.VideoCards.Builders;

public abstract class VideoCardBuilderBase : IVideoCardBuilder
{
    private VideoCardSpecificator _videoCardSpecificator;

    protected VideoCardBuilderBase()
    {
        _videoCardSpecificator = new VideoCardSpecificator();
    }

    public IVideoCardBuilder WithHightVideoCard(string hightVideoCard)
    {
        _videoCardSpecificator.HightVideoCard = hightVideoCard;
        return this;
    }

    public IVideoCardBuilder WithWidthVideoCard(string widthVideoCard)
    {
        _videoCardSpecificator.WidthVideoCard = widthVideoCard;
        return this;
    }

    public IVideoCardBuilder WithVideoMemoryAmount(string videoMemoryAmount)
    {
        _videoCardSpecificator.VideoMemoryAmount = videoMemoryAmount;
        return this;
    }

    public IVideoCardBuilder WithVersionConnectionOptions(string versionConnectionOptions)
    {
        _videoCardSpecificator.VersionConnectionOptions = versionConnectionOptions;
        return this;
    }

    public IVideoCardBuilder WithChipFrequency(string chipFrequency)
    {
        _videoCardSpecificator.ChipFrequency = chipFrequency;
        return this;
    }

    public IVideoCardBuilder WithPowerConsumption(string powerConsumption)
    {
        _videoCardSpecificator.PowerConsumption = powerConsumption;
        return this;
    }

    public IVideoCardBuilder Direct(VideoCardSpecificator videoCardSpecificator)
    {
        WithHightVideoCard(videoCardSpecificator.HightVideoCard);
        WithWidthVideoCard(videoCardSpecificator.WidthVideoCard);
        WithVideoMemoryAmount(videoCardSpecificator.VideoMemoryAmount);
        WithVersionConnectionOptions(videoCardSpecificator.VersionConnectionOptions);
        WithChipFrequency(videoCardSpecificator.ChipFrequency);
        WithPowerConsumption(videoCardSpecificator.PowerConsumption);

        return this;
    }

    public IVideoCard Build()
    {
        return Create(_videoCardSpecificator);
    }

    protected abstract IVideoCard Create(VideoCardSpecificator videoCardSpecificator);
}