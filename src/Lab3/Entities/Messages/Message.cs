using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;

public class Message
{
    public Message(string heading, string body, ImportanceLevel importanceLevel)
    {
        Heading = heading;
        Body = body;
        ImportanceLevel = importanceLevel;
        Status = new Status.Unread();
    }

    public string Heading { get; set; }
    public string Body { get; set; }
    public ImportanceLevel ImportanceLevel { get; set; }

    public Status Status { get; set; }
}