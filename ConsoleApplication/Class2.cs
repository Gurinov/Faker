namespace ConsoleApplication
{
    public class Class2
    {
        public Class1 class1;
        public string str1;
        public string str2;

        public Class2(Class1 class1, string str1, string str2)
        {
            this.class1 = class1;
            this.str1 = str1;
            this.str2 = str2;
        }

        public Class2(Class1 class1)
        {
            this.class1 = class1;
        }
    }
}