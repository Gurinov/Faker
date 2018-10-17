using System;

namespace Faker.Generators
{
    public class CharGenerator : IGenerator
    {
        private Random random;

        public CharGenerator()
        {
            random = new Random();
        }

        public object GenerateRandomValue()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return chars[random.Next(chars.Length)];
        }
    }
}