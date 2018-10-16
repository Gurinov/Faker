using System;
using System.Collections;

namespace Faker.Generators.CustomTypeGenerator
{
    public class ListGenerator : IArrayGenerator
    {
        public object GenerateRandomArray(Type type)
        {
            return (IList) Activator.CreateInstance(type);
        }
    }
}