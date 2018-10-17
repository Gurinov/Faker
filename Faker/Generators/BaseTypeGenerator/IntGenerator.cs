using System;

namespace Faker.Generators
{
    public class IntGenerator : IGenerator
    {
        private Random random;

        public IntGenerator()
        {
            random = new Random();
        }
        public object GenerateRandomValue()
        {
            return random.Next();
        }
    }
}