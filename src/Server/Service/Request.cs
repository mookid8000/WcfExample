using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

namespace Server.Service
{
    [DataContract]
    [KnownType("GetKnownTypes")]
    public abstract class Request : IExtensibleDataObject
    {
        // reflects on all subtypes, avoiding each Request derivation to be explicitly added
        public static IEnumerable<Type> GetKnownTypes()
        {
            return Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => typeof (Request).IsAssignableFrom(t));
        }

        public ExtensionDataObject ExtensionData { get; set; }
    }
}