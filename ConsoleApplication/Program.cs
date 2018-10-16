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
            Console.WriteLine(foo._bar._sumbol);
            Console.WriteLine(foo._bar._newDouble);

            string intArrToString = "bar _intList = ";
            foreach (int i in foo._bar._intList)
            {
                intArrToString += i + "; ";
            }
            Console.WriteLine(intArrToString);
            Console.WriteLine(foo._bar._dateTime);

            
        }
    }
}