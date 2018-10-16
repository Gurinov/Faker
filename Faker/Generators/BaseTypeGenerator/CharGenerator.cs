using System;

namespace Faker.Generators
{
    public class CharGenerator : IGenerator
    {
        public object GenerateRandomValue()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            return chars[random.Next(chars.Length)];
        }
    }
}