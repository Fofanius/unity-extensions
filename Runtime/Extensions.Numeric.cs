using System;
using System.Globalization;

namespace Fofanius.Extensions
{
    public static partial class Extensions
    {
        private static class NumberFormats
        {
            public static NumberFormatInfo SpacedThousandsFormat { get; }
            public static NumberFormatInfo DotDecimalsFormat { get; }

            static NumberFormats()
            {
                SpacedThousandsFormat = (NumberFormatInfo)CultureInfo.InvariantCulture.NumberFormat.Clone();
                SpacedThousandsFormat.NumberGroupSeparator = " ";

                DotDecimalsFormat = (NumberFormatInfo)CultureInfo.InvariantCulture.NumberFormat.Clone();
                DotDecimalsFormat.NumberDecimalSeparator = ".";
            }
        }

        public static string FormatAsAbbreviatedThousands(this int value, int roundToDigits = 0) => FormatAsAbbreviatedThousands((double)value, roundToDigits);
        public static string FormatAsAbbreviatedThousands(this float value, int roundToDigits = 0) => FormatAsAbbreviatedThousands((double)value, roundToDigits);

        public static string FormatAsAbbreviatedThousands(this double value, int roundToDigits = 0)
        {
            const int thousand = 1_000;

            var thousandsIndex = 0;
            while (value >= thousand)
            {
                thousandsIndex++;
                value /= thousand;
            }

            var suffix = thousandsIndex switch
            {
                1 => "K",
                2 => "M",
                3 => "B",
                4 => "T",
                5 => "Q",
                _ => "",
            };

            roundToDigits = Math.Clamp(roundToDigits, 0, 15);
            value = Math.Round(value, roundToDigits);

            return string.Concat(value.ToString(NumberFormats.DotDecimalsFormat), suffix);
        }

        public static string FormatWithSeparatedThousands(int value) => value.ToString("#,0", NumberFormats.SpacedThousandsFormat);
    }
}