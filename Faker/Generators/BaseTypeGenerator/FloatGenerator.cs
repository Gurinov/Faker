using System;

namespace Faker.Generators
{
    public class FloatGenerator: IGenerator
    {
        private Random random;

        public FloatGenerator()
        {
            random = new Random();
        }
        
        public object GenerateRandomValue()
        {
            return random.Next();
        }
    }
}