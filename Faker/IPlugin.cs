using System;

namespace Faker
{
    public interface IPlugin
    {
        Type type { get; } 
        void GenerateRandomValue(); 
    }
}