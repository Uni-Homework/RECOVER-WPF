using System.Globalization;
using System.Windows.Data;

namespace RECOVER.Converter;

public class NegativeDoubleConvert : IMultiValueConverter
{
    public object Convert(object[] values, System.Type targetType, object parameter, CultureInfo culture)
    {
        double offset = parameter != null ? double.Parse(parameter.ToString()) : 0;
        return -(double)values[0] + (double)values[1]/2 - offset;
    }

    public object[] ConvertBack(object value, System.Type[] targetTypes, object parameter, CultureInfo culture)
    {
        return [-(double)value];
    }
}

public class HalfValueConverter : IValueConverter
{
    public object Convert(object value, System.Type targetType, object parameter, CultureInfo culture)
    {
        return (double)value / 2;
    }

    public object ConvertBack(object value, System.Type targetType, object parameter, CultureInfo culture)
    {
        return (double)value * 2;
    }
}

public class NegateValueConverter : IValueConverter
{
    public object Convert(object value, System.Type targetType, object parameter, CultureInfo culture)
    {
        return -(double)value;
    }

    public object ConvertBack(object value, System.Type targetType, object parameter, CultureInfo culture)
    {
        return -(double)value;
    }
}