using System;
using UnityEngine;

namespace Fofanius.Extensions
{
    public static partial class Extensions
    {
        public static bool TryGetComponentInChildren<T>(this GameObject gameObject, out T result)
        {
            if (!gameObject) throw new ArgumentNullException(nameof(gameObject));
            result = gameObject.GetComponentInChildren<T>();
            return result != null;
        }

        public static bool TryGetComponentInParent<T>(this GameObject gameObject, out T result)
        {
            if (!gameObject) throw new ArgumentNullException(nameof(gameObject));
            result = gameObject.GetComponentInParent<T>();
            return result != null;
        }

        public static bool ContainsComponent<T>(this GameObject gameObject)
        {
            if (!gameObject) throw new ArgumentNullException(nameof(gameObject));
            return gameObject.GetComponent<T>() is not null;
        }
    }
}