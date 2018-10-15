using System;

namespace Faker.Generators
{
    public class IntGenerator : IGenerator
    {
        public object GenerateRandomValue()
        {
            Random random = new Random();
            return random.Next();
        }
    }
}