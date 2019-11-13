using System;
using System.Collections.Generic;
using System.Text;

namespace Visitor
{
    internal static class ObserveCollectionExtension
    {
        internal static void AddRange<T>(this ObserveCollection<T> observeCollection, IEnumerable<T> items)
        {
            if (observeCollection == null)
            {
                throw new ArgumentException($"Parameter {nameof{observeCollec");
            }

            foreach (var item in items)
            {
                observeCollection.Add(item);
            }
        }
    }
}
