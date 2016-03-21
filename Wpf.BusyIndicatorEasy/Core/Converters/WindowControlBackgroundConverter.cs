using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace Wpf.BusyIndicatorEasy.Core.Converters
{
    public class WindowControlBackgroundConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            Brush backgroundColor = (Brush) values[0];
            double opacity = (double) values[1];

            if (backgroundColor != null)
            {
                if (backgroundColor.ReadLocalValue(Brush.OpacityProperty) ==
                    System.Windows.DependencyProperty.UnsetValue)
                {
                    backgroundColor = backgroundColor.Clone();
                    backgroundColor.Opacity = opacity;
                }
            }
            return backgroundColor;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}