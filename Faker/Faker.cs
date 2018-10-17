using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Faker.Generators;

namespace Faker
{
    public class Faker
    {
        
        private readonly Dictionary<Type, IGenerator> _baseTypeGenerators;
        private Dictionary<Type, IPlugin> _plugins;
        private Stack<Type> _classStack;
        
        public Faker()
        {
            _baseTypeGenerators = new Dictionary<Type, IGenerator>();
            _plugins = new Dictionary<Type, IPlugin>();
            _classStack = new Stack<Type>();
            
            ICollection<IPlugin> plugins = GenericPluginLoader<IPlugin>.LoadPlugins(AppDomain.CurrentDomain.BaseDirectory + "..\\..\\..\\ConsoleApplication\\Plugins");
            if (plugins != null)
            {
                foreach(var item in plugins)
                {
                    _plugins.Add(item.type, item);
                }
            }
            
            _baseTypeGenerators.Add(typeof(bool), new BoolGenerator());
            _baseTypeGenerators.Add(typeof(double), new DoubleGenerator());
            _baseTypeGenerators.Add(typeof(float), new FloatGenerator());
            _baseTypeGenerators.Add(typeof(int), new IntGenerator());
            _baseTypeGenerators.Add(typeof(long), new LongGenerator());
            _baseTypeGenerators.Add(typeof(string), new StringGenerator());
            _baseTypeGenerators.Add(typeof(char), new CharGenerator());
        }
        
        public T Create<T>()
        {
            return (T) CreateObject(typeof(T));
        }

        private ConstructorInfo GetConstructorsWithMaxParametersCount(Type type)
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
            Stack<string> fieldsOnConstructor = new Stack<string>();

            
            if (type != null)
            {
                ConstructorInfo constructor = GetConstructorsWithMaxParametersCount(type);
                ParameterInfo[] constructorParameters = constructor.GetParameters();

                var inputParametes = new List<object>();
                foreach (ParameterInfo parameter in constructorParameters)
                {
                    if (!_classStack.Contains(parameter.ParameterType))
                    {
                        fieldsOnConstructor.Push(parameter.Name);
                        fieldsOnConstructor.Push("_" + parameter.Name);
                        _classStack.Push(parameter.ParameterType);
                        inputParametes.Add(GenerateValue(parameter.ParameterType));
                        _classStack.Pop();
                    }else
                    {
                        inputParametes.Add(null);
                    }
                }
                generatedObject = constructor.Invoke(inputParametes.ToArray());
                
                FieldInfo[] fields = type.GetFields();
                foreach (FieldInfo field in fields)
                {
                    if (!fieldsOnConstructor.Contains(field.Name) && !_classStack.Contains(field.FieldType))
                    {
                        _classStack.Push(field.FieldType);
                        field.SetValue(generatedObject, GenerateValue(field.FieldType));
                        _classStack.Pop();
                    }
                }
                
            }

            return generatedObject; 
        }

        private object GenerateValue(Type parameterType)
        {
            object generatedObject;
            if (_baseTypeGenerators.ContainsKey(parameterType))
            {
                generatedObject = _baseTypeGenerators[parameterType].GenerateRandomValue();
                return generatedObject;
            }else
                if (parameterType.IsGenericType && _plugins.ContainsKey(parameterType.GetGenericTypeDefinition()))
                {
                    IList generatedArray = (IList) _plugins[parameterType.GetGenericTypeDefinition()].GenerateRandomValue(parameterType);
                    for (int i =0; i < 5; i++)
                    {
                        generatedArray.Add(GenerateValue(parameterType.GenericTypeArguments[0]));
                    }
        
                    generatedObject = generatedArray;
                    return generatedObject;
                }else
                    if (_plugins.ContainsKey(parameterType))
                    {
                        generatedObject = _plugins[parameterType].GenerateRandomValue(parameterType);
                        return generatedObject;
                    }else
                        if (parameterType.IsClass && !parameterType.IsArray && !parameterType.IsGenericType)
                        {
                            generatedObject = CreateObject(parameterType);
                            return generatedObject;
                        }
          return null;
        }
    }
}                     