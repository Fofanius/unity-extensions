using System;

namespace Fofanius.Extensions
{
    public static partial class Extensions
    {
        public static void ThrowIfNull<T>(this T target, string message = null) where T : UnityEngine.Object
        {
            if (!target)
            {
                throw new ArgumentNullException(nameof(target), message);
            }
        }
    }
}