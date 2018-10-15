
namespace ConsoleApplication
{
    public class Foo
    {
        public int _age { get; set; }
        public string _name { get; set; }
        public bool _isTrue { get; set; }

        public Foo()
        {
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