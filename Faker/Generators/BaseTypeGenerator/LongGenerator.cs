using System;

namespace Faker.Generators
{
    public class LongGenerator: IGenerator
    {
        public object GenerateRandomValue()
        {
            Random random = new Random();
            return random.Next();
        }
    }
}