using System;
using System.Drawing;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.DisplayDrivers;

public class ConcreteDisplayDriver : IDisplayDriver
{
    private Color _displayColor;
    private string _displayedMessage;

    public ConcreteDisplayDriver()
    {
        _displayedMessage = string.Empty;
        _displayColor = Color.White;
    }

    public void ClearDisplay()
    {
        _displayedMessage = string.Empty;
        Console.Clear();
    }

    public void SetDisplayColor(Color color)
    {
        _displayColor = color;
    }

    public void WriteToDisplay(string text)
    {
        _displayedMessage = text;
        Console.WriteLine(_displayedMessage);
    }
}