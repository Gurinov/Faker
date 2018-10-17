
namespace ConsoleApplication
{
    public class Foo
    {
        public int _age;
        public string _name;
        public bool _isTrue;
        public Bar _bar;
        public int[] _ints;
        
        public int _int1;
        public float _float;
        public long _long;
        public int _int2;
        public string _str1;
        public string _str2;

        public Foo(int age, string name, bool isTrue, Bar bar)
        {
            _age = age;
            _name = name;
            _isTrue = isTrue;
            _bar = bar;
        }

        public Foo(int age, string name, bool isTrue)
        {
            _age = age;
            _name = name;
            _isTrue = isTrue;
        }
        public Foo(int age, string name)
        {
            _age = age;
            _name = name;
        }
        public Foo(int age, bool isTrue)
        {
            _age = age;
            _isTrue = isTrue;
        }
        public Foo(string name, bool isTrue)
        {
            _name = name;
            _isTrue = isTrue;
        }
        
    }
    
    
}