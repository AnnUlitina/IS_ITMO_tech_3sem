using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class ComponentsDoesNotExistsResultException : Exception
{
    public ComponentsDoesNotExistsResultException(string message)
        : base(message) { }

    public ComponentsDoesNotExistsResultException(string message, Exception innerException)
        : base(message, innerException) { }

    public ComponentsDoesNotExistsResultException() { }
}