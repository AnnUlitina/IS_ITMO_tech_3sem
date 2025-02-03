using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models;

public interface IAddressee
{
    void ReceiveMessage(Message message);
    IEnumerable<Message> MessageFilter(IEnumerable<Message> messages);
}