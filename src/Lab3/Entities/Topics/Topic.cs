using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Topics;

public class Topic
{
    private IEnumerable<IAddressee> _recipients;

    protected internal Topic(string name)
    {
        Name = name;
        _recipients = new List<IAddressee>();
    }

    public string Name { get; set; }

    public IAddressee? FindAddressee(IAddressee addressee)
    {
        foreach (IAddressee recipient in _recipients)
        {
            if (addressee == recipient)
            {
                return recipient;
            }
        }

        return null;
    }

    public void SendMessage(Message message, IEnumerable<IAddressee> currentAddressees)
    {
        foreach (IAddressee currentAddressee in currentAddressees)
        {
            FindAddressee(currentAddressee)?.ReceiveMessage(message);
        }
    }

    public void AddAddressee(IEnumerable<IAddressee> addressees)
    {
        foreach (IAddressee addressee in addressees)
        {
            _recipients = _recipients.Append(addressee);
        }
    }
}