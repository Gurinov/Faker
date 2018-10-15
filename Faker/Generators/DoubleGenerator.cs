using System;

namespace Faker.Generators
{
    public class DoubleGenerator: IGenerator
    {
        public object GenerateRandomValue()
        {
            Random random = new Random();
            return random.NextDouble();
        }
    }
}