using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressees.Messengers;

public class Messenger : IAddressee
{
    protected Messenger() { }

    public void ReceiveMessage(Message message)
    {
        Console.WriteLine("Messenger: " + message?.Body);
    }

    public IEnumerable<Message> MessageFilter(IEnumerable<Message> messages)
    {
        return messages.OrderBy(messages => messages.Status).ToList();
    }
}