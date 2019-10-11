using System;
using System.Linq.Expressions;
using JetBrains.Annotations;

namespace Khaos.Core.Extensions
{
    public static class TypeExtensions
    {
        public static Func<T, R> GetFieldGetter<T, R>([NotNull] string fieldName)
        {
            Check.NotNull(fieldName, nameof(fieldName));
            
            var paramExpression = Expression.Parameter(typeof(T), "arg");
            var memberExpression = Expression.PropertyOrField(paramExpression, fieldName);
            var accessor = Expression.Lambda(typeof(Func<T, R>), memberExpression, paramExpression);

            return (Func<T, R>) accessor.Compile();
        }

        public static Action<T> GetFieldSetter<T>([NotNull] string fieldName)
        {
            Check.NotNull(fieldName, nameof(fieldName));
            
            var paramExpression = Expression.Parameter(typeof(T), "arg");
            var memberExpression = Expression.PropertyOrField(paramExpression, fieldName);
            var setter = Expression.Lambda(typeof(Action<T>), memberExpression, paramExpression);

            return (Action<T>) setter.Compile();
        }
    }
}
