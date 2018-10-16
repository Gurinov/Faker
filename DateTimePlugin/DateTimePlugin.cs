using System;
using Faker;

namespace DateTimePlugin
{
    public class DateTimePlugin : IPlugin 
    { 
        #region IPlugin Members 
 
        public Type type
        { 
            get { return typeof(DateTime); } 
        }

        public void GenerateRandomValue()
        {
        }

        #endregion 
    } 
}