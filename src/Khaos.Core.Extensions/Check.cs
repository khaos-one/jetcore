using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using JetBrains.Annotations;

namespace Khaos.Core.Extensions
{
    [DebuggerStepThrough]
    public static class Check
    {
        public static void NotNull<T>([NoEnumeration] T param, [InvokerParameterName, NotNull] string paramName)
            where T : class
        {
            if (param == null)
            {
                NotNull(paramName, nameof(paramName));
                throw new ArgumentNullException(paramName);
            }
        }

        public static void NotDefault<T>(T param, [InvokerParameterName, NotNull] string paramName)
            where T : struct, IEquatable<T>
        {
            if (param.Equals(default))
            {
                NotNull(paramName, nameof(paramName));
                throw new ArgumentException("Provided argument value is default.", paramName);
            }
        }

        public static void NotDefault(Guid param, [InvokerParameterName, NotNull] string paramName)
        {
            if (param.Equals(Guid.Empty))
            {
                NotNull(paramName, nameof(paramName));
                throw new ArgumentException("Provided argument value is default.", paramName);
            }
        }

        public static void NotEnumDefault<T>(T param, [InvokerParameterName, NotNull] string paramName)
            where T : Enum
        {
            if (param.Equals(default))
            {
                NotNull(paramName, nameof(paramName));
                throw new ArgumentException("Provided argument enum value is default.", paramName);
            }
        }

        public static void NotNullOrWhiteSpace(string param, [InvokerParameterName, NotNull] string paramName)
        {
            NotNull(param, paramName);

            if (string.IsNullOrWhiteSpace(param))
            {
                NotNull(paramName, nameof(paramName));
                throw new ArgumentException("Provided argument value is empty or whitespace.", paramName);
            }
        }

        public static void NotNullAndHasNoNulls<T>([NotNull] ICollection<T> collection,
            [InvokerParameterName, NotNull] string paramName)
            where T : class
        {
            NotNull(collection, nameof(collection));

            if (collection.Any(x => x.Equals(null)))
            {
                NotNull(paramName, nameof(paramName));
                throw new ArgumentException("Some collection items are null.", paramName);
            }
        }
    }
}