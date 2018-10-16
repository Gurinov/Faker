using System.Collections.Generic;

namespace ConsoleApplication
{
    public class Bar
    {
        public char _sumbol;
        public double _newDouble;
        public List<int> _intList;
        public int[] _intArr;

        public Bar(char sumbol, double newDouble, List<int> intList, int[] intArr)
        {
            _sumbol = sumbol;
            _newDouble = newDouble;
            _intList = intList;
            _intArr = intArr;
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