using System;

namespace Faker.Generators
{
    public class DoubleGenerator: IGenerator
    {
        private Random random;

        public DoubleGenerator()
        {
            random = new Random();
        }
        public object GenerateRandomValue()
        {
            return random.NextDouble();
        }
    }
}