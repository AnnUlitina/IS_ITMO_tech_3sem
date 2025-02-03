using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Displays;

public class LoggingDisplay : IAddressee
{
    private Display _display;
    private IEnumerable<string> _log;

    public LoggingDisplay(Display display)
    {
        _display = display;
        _log = new List<string>();
    }

    public void ReceiveMessage(Message message)
    {
        ArgumentNullException.ThrowIfNull(message);
        _log = _log.Append("Receive message " + message.Body);
        _display.ReceiveMessage(message);
    }

    public void SetDisplayColor(Color color)
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

    public IEnumerable<Message> MessageFilter(IEnumerable<Message> messages)
    {
        return messages.OrderBy(messages => messages.Status).ToList();
    }
}