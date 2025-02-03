using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressees.Users;

public class ReadMessageStatus : IMessageStatus
{
    protected internal ReadMessageStatus(Status status)
    {
        Status = status;
    }

    private Status Status { get; set; }

    public void MarkAsRead(Message message)
    {
        if (message.Status == new Status.Unread())
        {
            message.Status = new Status.Read();
        }
        else
        {
            throw new ArgumentException("This message has already read.");
        }
    }
}