using System;
using System.Collections;
using System.Collections.Generic;
using Faker;

namespace ListPlugin
{
    public class ListPlugin : IPlugin
    {
        public Type type
        {
            get { return typeof(List<>); }
        }
        public object GenerateRandomValue(Type type)
        {
            return (IList)Activator.CreateInstance(type);
        }
    }
}