using System;

namespace ORMDemo.Custom_Attributes
{
    /// <summary>
    /// Specifies the mapping between properties in DTO (Data Transfer Object) and POCO (Plain Old CLR Object) classes.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class MappingAttribute : Attribute
    {
        /// <summary>
        /// Gets the name of the corresponding property in the destination class (POCO).
        /// </summary>
        public string PropertyName { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MappingAttribute"/> class with the specified property name.
        /// </summary>
        /// <param name="propertyName">The name of the corresponding property in the destination class (POCO).</param>
        public MappingAttribute(string propertyName)
        {
            PropertyName = propertyName;
        }
    }
}
