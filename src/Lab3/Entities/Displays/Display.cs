using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.DisplayDrivers;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Displays;

public class Display : IAddressee
{
    private ConcreteDisplayDriver _concreteDisplayDriver;
    private string _displayMessage;
    protected internal Display(ConcreteDisplayDriver concreteDisplayDriver)
    {
        _concreteDisplayDriver = concreteDisplayDriver;
        _displayMessage = string.Empty;
    }

    public void SetDisplayColor(Color color)
    {
        _concreteDisplayDriver.SetDisplayColor(color);
    }

    public void DisplayClear()
    {
        _displayMessage = string.Empty;
        Console.Clear();
    }

    public void ReceiveMessage(Message message)
    {
        ArgumentNullException.ThrowIfNull(message);
        _displayMessage = message.Body;
        _concreteDisplayDriver.WriteToDisplay(_displayMessage);
    }

    public IEnumerable<Message> MessageFilter(IEnumerable<Message> messages)
    {
        return messages.OrderBy(messages => messages.Status).ToList();
    }
}