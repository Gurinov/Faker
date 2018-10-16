using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Faker.Generators;
using Faker.Generators.CustomTypeGenerator;

namespace Faker
{
    public class Faker
    {
        
        private Dictionary<Type, IGenerator> baseTypeGenerator;
        private Dictionary<Type, IArrayGenerator> arrayTypeGenerator;
        public Faker()
        {
            baseTypeGenerator = new Dictionary<Type, IGenerator>();
            arrayTypeGenerator = new Dictionary<Type, IArrayGenerator>();

            baseTypeGenerator.Add(typeof(bool), new BoolGenerator());
            baseTypeGenerator.Add(typeof(double), new DoubleGenerator());
            baseTypeGenerator.Add(typeof(float), new FloatGenerator());
            baseTypeGenerator.Add(typeof(int), new IntGenerator());
            baseTypeGenerator.Add(typeof(long), new LongGenerator());
            baseTypeGenerator.Add(typeof(string), new StringGenerator());
            baseTypeGenerator.Add(typeof(char), new CharGenerator());
            
            arrayTypeGenerator.Add(typeof(List<>), new ArrayGenerator());
            arrayTypeGenerator.Add(typeof(Array), new ArrayGenerator());
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
            object generatedObject;
            if (baseTypeGenerator.ContainsKey(parameterType))
            {
                generatedObject = baseTypeGenerator[parameterType].GenerateRandomValue();
                return generatedObject;
            }else
                if (parameterType.IsGenericType && arrayTypeGenerator.ContainsKey(parameterType.GetGenericTypeDefinition()))
                {
                    IList generatedArray = (IList) arrayTypeGenerator[parameterType.GetGenericTypeDefinition()]
                        .GenerateRandomArray(parameterType);
                    for (int i =0; i < 5; i++)
                    {
                        generatedArray.Add(GenerateValue(parameterType.GenericTypeArguments[0]));
                    }
    
                    generatedObject = generatedArray;
                    return generatedObject;
                }else
                    if (parameterType.IsClass && !parameterType.IsArray)
                    {
                        generatedObject = CreateObject(parameterType);
                        return generatedObject;
                    }
          return null;
        }
    }
}                     