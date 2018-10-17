using System;
using Faker;

namespace DateTimePlugin
{
    public class DateTimePlugin : IPlugin
    {
        private Random random;

        public Type type
        { 
            get { return typeof(DateTime); } 
        }

        public DateTimePlugin()
        {
            random = new Random();
        }

        public object GenerateRandomValue(Type type)
        {
            int year = random.Next(1990, 2018);
            int month = random.Next(1, 12);
            int day = random.Next(1, 27);
            int second = random.Next(1, 60);
            int minute = random.Next(1, 60);
            int hour = random.Next(1, 24);
            DateTime dateTime = new DateTime(year, month, day, hour, minute, second);
            return dateTime;
        }
    } 
}