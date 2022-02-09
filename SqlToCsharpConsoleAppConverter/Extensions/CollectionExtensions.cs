using System;
using System.Collections.Generic;

namespace SqlToCsharpConsoleAppConverter.Extensions
{
    internal static class CollectionExtensions
    {
        internal static bool IsIn<T>(this T item, ICollection<T> collection)
        {
            return collection.Contains(item);
        }

        internal static bool IsIn(this object item, ICollection<Type> collection)
        {
            return collection.Contains(item.GetType());
        }
    }
}
