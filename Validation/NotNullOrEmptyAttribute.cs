using System;

namespace Fenix.Validation
{
    /// <summary>
    /// Atribut, který specifikuje typ zprávy
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class NotNullOrEmptyAttribute : Attribute
    {
    }
}
