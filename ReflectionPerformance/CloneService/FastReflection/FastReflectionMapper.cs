using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionPerformance.CloneService.FastReflection
{
    public class FastReflectionMapper
    {
        public Dictionary<Type,MappedClass> MappedClasses { get; set; }

        public FastReflectionMapper()
        {
            MappedClasses = new();
        }

        public MappedClass GetMappedClass<T>()
        {
            return MappedClasses[typeof(T)];
        }

        public void Map<T>()
        {
            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var constructor = GetConstructor(typeof(T));
            var mappedClass = new MappedClass(constructor);
            
            foreach (var prop in properties)
            {
                var getter = GetGetter(prop);
                var setter = GetSetter(prop);
                var mappedProperty = new MappedProperty(getter, setter);
                mappedClass.Properties.Add(mappedProperty);
            }
            MappedClasses.Add(typeof(T), mappedClass);
        }

        private Func<object, object> GetGetter(PropertyInfo info)
        {
            if(info == null) throw new ArgumentNullException("Parameter is null");
            ParameterExpression instance = Expression.Parameter(typeof(object));
            var propExpr = Expression.Property(Expression.Convert(instance, info.DeclaringType), info);
            var castExpr = Expression.Convert(propExpr, typeof(object));
            var body = Expression.Lambda<Func<object, object>>(castExpr, instance);
            return body.Compile();
        }

        private Action<object, object> GetSetter(PropertyInfo info)
        {
            if (info == null) throw new ArgumentNullException("PropertyInfo parameter is null");
            ParameterExpression objInstance = Expression.Parameter(typeof(object), "instance");     //The object to set the property on
            var convertedInstance = Expression.Convert(objInstance, info.DeclaringType);            //convert the object to its native type
            ParameterExpression parameter = Expression.Parameter(typeof(object), "param");          //the new value for the property
            var convertedParamter = Expression.Convert(parameter, info.PropertyType);               //Convert the value to its native type

            var body = Expression.Call(convertedInstance, info.GetSetMethod(), convertedParamter);  //Call the set method
            var parameters = new ParameterExpression[] { objInstance, parameter };                  //Specify the parameters

            return Expression.Lambda<Action<object, object>>(body, parameters).Compile();           //Compile to IL-code
        }

        private Func<object> GetConstructor(Type type)
        {
            var constructorMethod = (type.GetConstructor(Type.EmptyTypes));
            var newExpression = Expression.New(constructorMethod);
            var convertedExpression = Expression.Convert(newExpression, typeof(object));
            return Expression.Lambda<Func<object>>(newExpression).Compile();
        }
    }
}
