using System;
using System.Globalization;
using Microsoft.Maui.Controls;

namespace LabTestQ1.Converters
{
    public class ValueToTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double doubleValue)
            {
                if (doubleValue >= 80)
                    return "Excellent";
                if (doubleValue >= 40)
                    return "Passed";
                return "Failed";
            }
            return "Failed";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class ValueToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double doubleValue)
            {
                if (doubleValue >= 80)
                    return Colors.Green;
                if (doubleValue < 40)
                    return Colors.Red;
            }
            return Colors.Black; // Default for "Passed" range
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
