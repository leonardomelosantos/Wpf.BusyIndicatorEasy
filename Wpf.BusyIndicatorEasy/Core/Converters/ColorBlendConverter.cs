﻿using System;
using System.Windows.Data;
using System.Windows.Media;

namespace Wpf.BusyIndicatorEasy.Core.Converters
{
    public class ColorBlendConverter : IValueConverter
    {
        private double _blendedColorRatio = 0;

        public double BlendedColorRatio
        {
            get { return _blendedColorRatio; }

            set
            {
                if (value < 0d || value > 1d)
                    throw new ArgumentException(
                        "BlendedColorRatio must greater than or equal to 0 and lower than or equal to 1 ");

                _blendedColorRatio = value;
            }
        }

        public Color BlendedColor { get; set; }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null || value.GetType() != typeof (Color))
                return null;

            Color color = (Color) value;
            return new Color()
            {
                A = this.BlendValue(color.A, this.BlendedColor.A),
                R = this.BlendValue(color.R, this.BlendedColor.R),
                G = this.BlendValue(color.G, this.BlendedColor.G),
                B = this.BlendValue(color.B, this.BlendedColor.B)
            };
        }

        private byte BlendValue(byte original, byte blend)
        {
            double blendRatio = this.BlendedColorRatio;
            double sourceRatio = 1 - blendRatio;

            double result = (((double) original)*sourceRatio) + (((double) blend)*blendRatio);
            result = Math.Round(result);
            result = Math.Min(255d, Math.Max(0d, result));
            return System.Convert.ToByte(result);
        }

        public object ConvertBack(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}