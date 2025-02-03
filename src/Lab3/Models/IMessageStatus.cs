using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models;

public interface IMessageStatus
{
    void MarkAsRead(Message message);
}