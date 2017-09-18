using System;
using System.Collections.Generic;
using System.Reflection;

namespace AD.Common
{
    /// <summary>
    /// Factory class - used to instantiate related types.
    /// The following are required:
    /// - ObjectTypeEnumT: this is an enum of all available types that the factory would instantiate
    /// - BaseInterfaceT: the interface that the types derive from
    /// - namespaceName: the namespace the types are part of
    /// - suffix: needed if names specified in the ObjectTypeEnumT require a suffix in order to 
    ///   match the type names
    /// </summary>
    /// <example> 
    ///   * Say, we need to instantiate a set of ISensor-derived classes, e.g. TemperatureSensor and HumiditySensor,
    ///   which are found in the MyTypes namespace.
    ///   * We would need an enum SensorType { Temperature, Humidity}
    ///   * We can then instantiate the factory type with: <code>  using SensorFactory = GenericFactory ((SensorType, ISensor)) </code>
    ///   * And instantiate the factory: 
    ///   <code>
    ///     var f = new SensorFactory("MyTypes", "Sensor");
    ///     ISensor s = f.CreateObject(SensorType.Temperature);
    ///   </code>
    /// </example>
    public class GenericFactory<ObjectTypeEnumT, BaseInterfaceT>
        where ObjectTypeEnumT : struct, IConvertible  // enum
        where BaseInterfaceT : class // since interface constraint is not supported
    {
        private readonly string _suffix;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="suffix">The suffix of the types</param>
        public GenericFactory(string suffix = "")
        {
            _suffix = suffix;
        }

        /// <summary>
        /// Creates a new object using the type specified via the enum variable and returns it via
        /// the base interface.
        /// </summary>
        /// <param name="type">The enum value describing the type to instantiate</param>
        /// <returns>A new object of the given type</returns>
        public BaseInterfaceT CreateObject(ObjectTypeEnumT type)
        {
            //return Instances.ContainsKey(type) ? Instances[type].CloneJson() : null;

            var assemblyName = typeof(BaseInterfaceT).GetTypeInfo().Assembly.ToString();
            var namespaceName = typeof(BaseInterfaceT).Namespace;

            BaseInterfaceT obj = null;

            var typeName = $"{namespaceName}.{type}{_suffix}, {assemblyName}";
            var adapterType = Type.GetType(typeName);
            if (adapterType != null)
            {
                obj = (BaseInterfaceT)Activator.CreateInstance(adapterType);
            }

            return obj;
        }
    }
}
