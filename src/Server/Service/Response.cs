﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

namespace Server.Service
{
    [DataContract]
    [KnownType("GetKnownTypes")]
    public abstract class Response
    {
        public static IEnumerable<Type> GetKnownTypes()
        {
            return Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => typeof(Response).IsAssignableFrom(t));
        }
    }
}