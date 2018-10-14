using System;

namespace ConsoleApplication
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var faker = new Faker.Faker();
            Foo foo = faker.Create<Foo>();
            Foo foo1 = new Foo();
            Console.WriteLine(foo._age);
        }
    }
}