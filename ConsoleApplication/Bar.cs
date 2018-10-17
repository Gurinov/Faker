using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class Bar
    {
        public char _sumbol;
        public double _newDouble;
        public List<int> _intList;
        public DateTime _dateTime;
        
        public char _sumbol2;
        public char _sumbol3;
        public DateTime _dateTime1;
       

        public Bar(char sumbol, double newDouble, List<int> intList, DateTime dateTime)
        {
            _sumbol = sumbol;
            _newDouble = newDouble;
            _intList = intList;
            _dateTime = dateTime;
        }

        public Bar(char sumbol, double newDouble, List<int> intList)
        {
            _sumbol = sumbol;
            _newDouble = newDouble;
            _intList = intList;
        }

        public Bar(char sumbol, double newDouble)
        {
            _sumbol = sumbol;
            _newDouble = newDouble;
        }
    }
}