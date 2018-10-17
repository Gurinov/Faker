using System;

namespace Faker.Generators
{
    public class LongGenerator: IGenerator
    {
        private Random random;

        public LongGenerator()
        {
            random = new Random();
        }
        public object GenerateRandomValue()
        {
            return random.Next();
        }
    }
}