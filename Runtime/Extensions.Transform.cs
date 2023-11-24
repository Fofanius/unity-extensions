using System;
using UnityEngine;

namespace Fofanius.Extensions
{
    public static partial class Extensions
    {
        public static Transform ResetLocalPosition(this Transform target)
        {
            target.ThrowIfNull();

            target.localPosition = Vector3.zero;
            return target;
        }

        public static Transform ResetLocalRotation(this Transform target)
        {
            target.ThrowIfNull();

            target.localRotation = Quaternion.identity;
            return target;
        }

        public static Transform ResetLocalScale(this Transform target)
        {
            target.ThrowIfNull();

            target.localScale = Vector3.one;
            return target;
        }

        public static Transform ResetLocalParameters(this Transform transform) => transform.ResetLocalScale().ResetLocalRotation().ResetLocalPosition();

        public static Transform ResetPosition(this Transform target)
        {
            target.ThrowIfNull();

            target.position = Vector3.zero;
            return target;
        }

        public static Transform ResetRotation(this Transform target)
        {
            target.ThrowIfNull();

            target.rotation = Quaternion.identity;
            return target;
        }

        public static Transform ResetParameters(this Transform transform) => transform.ResetLocalScale().ResetRotation().ResetPosition();
    }
}