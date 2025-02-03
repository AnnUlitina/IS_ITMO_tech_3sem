using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.DisplayDrivers;

public class DisplayDriverProxy : IDisplayDriver
{
    private ConcreteDisplayDriver _driver;
    private IEnumerable<string> _log;

    public DisplayDriverProxy(ConcreteDisplayDriver driver)
    {
        _driver = driver;
        _log = new List<string>();
    }

    public void ClearDisplay()
    {
        _log = _log.Append("ClearDisplay");
        Console.Clear();
    }

    public void SetDisplayColor(Color color)
    {
        _log = _log.Append("SetDisplayColor: " + color);
        _driver.SetDisplayColor(color);
    }

    public void WriteToDisplay(string text)
    {
        _log = _log.Append("Write to display: " + text);
        _driver.WriteToDisplay(text);
    }

    public void PrintLog()
    {
        foreach (string log in _log)
        {
            Console.WriteLine(log);
        }
    }
}