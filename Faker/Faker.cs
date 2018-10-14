using System;
using System.Reflection;
using ConsoleApplication;

namespace Faker
{
    public class Faker
    {
        public T Create<T>() where T : new()
        {
            Type type = typeof(T);
            return (T) CreateObject(typeof(T));
        }

        private object CreateObject(Type type)
        {
            /*var fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            string s = "";
            foreach (FieldInfo fieldInfo in fields)
            {
                if (fieldInfo.Name == "_age")
                {
                    s += "!!!";
                }
                s += fieldInfo.Name + ";  ";
            }*/
            object Obj = null;
            if (type != null)
            {
                ConstructorInfo ci = type.GetConstructor(new Type[] { });
                Obj = ci.Invoke(new object[] { });
                
                MethodInfo mi = type.GetMethod("ShowName");
                mi.Invoke (Obj, null); 
                
                PropertyInfo property = type.GetProperty((BindingFlags.Instance | BindingFlags.Public).;
            }

            return Obj; 
        }
    }
}                     