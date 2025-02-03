using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Displays;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.DisplayDrivers;

public class LoggingDisplay : IAddressee
{
    private Display _display;
    private IEnumerable<string> _log;

    public LoggingDisplay(Display display)
    {
        this._display = display;
        _log = new List<string>();
    }

    public void ReceiveMessage(Message message)
    {
        if (message != null)
        {
            _log = _log.Append("Receive message " + message.Body);
            _display.ReceiveMessage(message);
        }
    }

    public void SetDisplayColor(ConsoleColor color)
    {
        _display.SetDisplayColor(color);
    }

    public void ClearDisplay()
    {
        _display.DisplayClear();
    }

    public void PrintLog()
    {
        foreach (string entry in _log)
        {
            Console.WriteLine(entry);
        }
    }
}