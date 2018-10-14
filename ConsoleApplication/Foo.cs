using System;

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

        public void ShowName()
        {
            _age = -10;
        } 
        
        public Foo(int age, string name, bool isTrue)
        {
            _age = age;
            _name = name;
            _isTrue = isTrue;
        }
    }
    
    
}