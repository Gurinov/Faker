using System;
using System.Collections;

namespace Faker.Generators.CustomTypeGenerator
{
    public class ArrayGenerator : IArrayGenerator
    {
        public object GenerateRandomArray(Type type)
        {
            return (IList)Activator.CreateInstance(type);
        }
    }
}