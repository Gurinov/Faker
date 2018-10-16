using System;

namespace Faker.Generators.CustomTypeGenerator
{
    public interface IArrayGenerator
    {
        object GenerateRandomArray(Type type);
    }
}