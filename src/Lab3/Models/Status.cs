namespace Itmo.ObjectOrientedProgramming.Lab3.Models;

public record Status
{
    public sealed record Read : Status;

    public sealed record Unread : Status;
}