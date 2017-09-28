using System;

namespace Logic.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class CommandAttributes : Attribute
    {
        public int Id { get; }
        public string Description { get; }
        public Type Type { get; }

        public CommandAttributes(int id, string description, Type type)
        {
            Id = id;
            Description = description;
            Type = type;
        }
    }
}
