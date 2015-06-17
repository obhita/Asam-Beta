using System.Collections.Generic;

namespace Asam.Ppc.Domain
{
    public static class ListExtensions
    {
        /// <summary>
        /// Adds the range of items.
        /// </summary>
        /// <typeparam name="T">Type in list.</typeparam>
        /// <param name="list">The list.</param>
        /// <param name="itemsToAdd">The items to add.</param>
        public static void AddRange<T> ( this IList<T> list, IEnumerable<T> itemsToAdd )
        {
            foreach ( var item in itemsToAdd )
            {
                list.Add ( item );
            }
        }
    }
}
