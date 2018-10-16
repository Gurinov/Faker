using System;

namespace Faker
{
    public interface IPlugin
    {
        Type type { get; } 
        object GenerateRandomValue(Type type); 
    }
}