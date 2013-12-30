using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Mathematically.Quartermaster.Domain
{
    public static class ExtensionMethods
    {
        [DebuggerStepThrough]
        public static void ForEach<T>(this IEnumerable<T> enumeration, Action<T> action)
        {
            foreach (T item in enumeration)
            {
                action(item);
            }
        }
    }
}
