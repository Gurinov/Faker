using System;
using System.Collections.Generic;
using System.Reflection;
using Faker.Generators;

namespace Faker
{
    public class Faker
    {
        
        private Dictionary<Type, IGenerator> baseTypeGenerator;

        public Faker()
        {
            baseTypeGenerator = new Dictionary<Type, IGenerator>();

            baseTypeGenerator.Add(typeof(bool), new BoolGenerator());
            baseTypeGenerator.Add(typeof(double), new DoubleGenerator());
            baseTypeGenerator.Add(typeof(float), new FloatGenerator());
            baseTypeGenerator.Add(typeof(int), new IntGenerator());
            baseTypeGenerator.Add(typeof(long), new LongGenerator());
            baseTypeGenerator.Add(typeof(string), new StringGenerator());
        }
        
        public T Create<T>()
        {
            return (T) CreateObject(typeof(T));
        }

        public ConstructorInfo getConstructorsWithMaxParametersCount(Type type)
        {
            int maxParametersCount = 0;
            int constructorsWithMaxParametersCount = 0;
            ConstructorInfo[] allConstructors = type.GetConstructors();
            for (int i = 0; i < allConstructors.Length; i++)
            {
                if (allConstructors[i].GetParameters().Length > maxParametersCount)
                {
                    maxParametersCount = allConstructors[i].GetParameters().Length;
                    constructorsWithMaxParametersCount = i;
                }
            }
            return allConstructors[constructorsWithMaxParametersCount];
        }
        
        private object CreateObject(Type type)
        {
            object generatedObject = null;
            
            if (type != null)
            {
                ConstructorInfo constructor = getConstructorsWithMaxParametersCount(type);
                ParameterInfo[] constructorParameters = constructor.GetParameters();
                // constructor.Invoke(new object[] { });

                var inputParametes = new List<object>();
                foreach (ParameterInfo parameter in constructorParameters)
                {
                    inputParametes.Add(GenerateValue(parameter.ParameterType));
                }
                generatedObject = constructor.Invoke(inputParametes.ToArray());
            }

            return generatedObject; 
        }

        private object GenerateValue(Type parameterType)
        {
            if (baseTypeGenerator.ContainsKey(parameterType))
            {
                object generatedObject = baseTypeGenerator[parameterType].GenerateRandomValue();
                return generatedObject;
            }
            return null;
        }
    }
}                     