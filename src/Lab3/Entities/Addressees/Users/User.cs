using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressees.Users;

public class User : IAddressee
{
    protected internal User()
    {
        ReceivedMessages = new List<Message>();
        MessageStatus = new ReadMessageStatus(new Status.Unread());
    }

    public IEnumerable<Message> ReceivedMessages { get; set; }
    public ReadMessageStatus MessageStatus { get; set; }

    public void ReceiveMessage(Message message)
    {
        ReceivedMessages = ReceivedMessages.Append(message);
    }

    public void ChangeMessageStatus(Message message)
    {
        MessageStatus.MarkAsRead(message);
    }

    // public List<Message> GetMessagesByImportance(ImportanceLevel importanceLevel, Message message)
    // {
    //     // Фильтрация сообщений по уровню важности
    //     foreach (var message in ReceivedMessages)
    //     {
    //         if (message.ImportanceLevel < importanceLevel)
    //         {
    //
    //         }
    //     }
    // }
    public IEnumerable<Message> MessageFilter(IEnumerable<Message> messages)
    {
        return messages.OrderBy(messages => messages.Status).ToList();
    }
}