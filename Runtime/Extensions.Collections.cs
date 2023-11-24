using System;
using System.Collections.Generic;
using System.Linq;

namespace Fofanius.Extensions
{
    public static partial class Extensions
    {
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> collection) => collection == null || !collection.Any();


        public static T GetRandomItem<T>(this IEnumerable<T> collection)
        {
            if (collection.IsNullOrEmpty()) throw new ArgumentException($"Collection is null or empty!");
            return collection.ElementAt(UnityEngine.Random.Range(0, collection.Count()));
        }

        public static T GetRandomItemOrDefault<T>(this IEnumerable<T> collection, T defaultValue = default)
        {
            if (collection.IsNullOrEmpty()) return defaultValue;
            return collection.ElementAt(UnityEngine.Random.Range(0, collection.Count()));
        }

        public static IEnumerable<T> CallForEach<T>(this IEnumerable<T> collection, Action<T> action)
        {
            if (collection == null) throw new ArgumentNullException(nameof(collection));
            if (action == null) throw new ArgumentNullException(nameof(action));

            foreach (var entity in collection)
            {
                action(entity);
            }

            return collection;
        }

        public static IList<T> Swap<T>(this IList<T> collection, int i, int j)
        {
            if (collection.IsNullOrEmpty()) throw new ArgumentException("Collection is null or empty!");

            T value = collection[i];
            collection[i] = collection[j];
            collection[j] = value;

            return collection;
        }

        public static IList<T> TryAddAsUnique<T>(this IList<T> collection, T item)
        {
            if (collection == null) throw new ArgumentNullException(nameof(collection));

            if (!collection.Contains(item))
            {
                collection.Add(item);
            }

            return collection;
        }

        public static IList<T> ApplyRandomShuffle<T>(this IList<T> collection)
        {
            // SOURCE: https://stackoverflow.com/questions/273313/randomize-a-listt

            if (collection.IsNullOrEmpty()) throw new ArgumentNullException(nameof(collection));

            var n = collection.Count;
            while (n > 1)
            {
                n--;
                var k = UnityEngine.Random.Range(0, n + 1);
                collection.Swap(k, n);
            }

            return collection;
        }
    }
}