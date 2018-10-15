using System;

namespace ConsoleApplication
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var faker = new Faker.Faker();
            Foo foo = faker.Create<Foo>();
            Console.WriteLine(foo._age);
            Console.WriteLine(foo._name);
            Console.WriteLine(foo._isTrue);
        }
    }
}