using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressees.Groups;

public class Group : IAddressee
{
    private IEnumerable<IAddressee> _addressees;

    public Group(IEnumerable<IAddressee> addressees)
    {
        _addressees = addressees;
    }

    public void ReceiveMessage(Message message)
    {
        foreach (IAddressee addressee in _addressees)
        {
            addressee.ReceiveMessage(message);
        }
    }

    public IEnumerable<Message> MessageFilter(IEnumerable<Message> messages)
    {
        return messages.OrderBy(messages => messages.Status).ToList();
    }
}