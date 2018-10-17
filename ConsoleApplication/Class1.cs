namespace ConsoleApplication
{
    public class Class1
    {
        public Class2 class2;
        public int int1;
        public int int2;
        public int int3;

        public Class1(Class2 class2, int int1, int int2, int int3)
        {
            this.class2 = class2;
            this.int1 = int1;
            this.int2 = int2;
            this.int3 = int3;
        }

        public Class1(Class2 class2)
        {
            this.class2 = class2;
        }
    }
}