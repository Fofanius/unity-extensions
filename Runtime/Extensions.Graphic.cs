using System;
using UnityEngine;
using UnityEngine.UI;

namespace Fofanius.Extensions
{
    public static partial class Extensions
    {
        private static Color SetChannel(Color color, int channel, float value)
        {
            color[channel] = Mathf.Clamp01(value);
            return color;
        }

        public static Color SetAlpha(this Color color, float alpha) => SetChannel(color, 3, alpha);

        public static T SetColor<T>(this T graphic, Color color) where T : Graphic
        {
            if (!graphic) throw new ArgumentNullException(nameof(graphic));
            graphic.color = color;
            return graphic;
        }

        public static T SetAlpha<T>(this T graphic, float a) where T : Graphic
        {
            if (!graphic) throw new ArgumentNullException(nameof(graphic));
            graphic.color = graphic.color.SetAlpha(a);
            return graphic;
        }

        public static Image SetSprite(this Image image, Sprite sprite)
        {
            if (!image) throw new ArgumentNullException(nameof(image));

            image.sprite = sprite;
            return image;
        }

        public static Image SetEnabledIfHasSprite(this Image image)
        {
            if (!image) throw new ArgumentNullException(nameof(image));

            image.enabled = image.sprite;
            return image;
        }
    }
}