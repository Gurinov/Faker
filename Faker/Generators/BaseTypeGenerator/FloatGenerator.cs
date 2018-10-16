using System;

namespace Faker.Generators
{
    public class FloatGenerator: IGenerator
    {
        public object GenerateRandomValue()
        {
            Random random = new Random();
            return random.Next();
        }
    }
}