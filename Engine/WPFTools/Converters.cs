using System.Globalization;
using System.Windows.Data;

namespace RECOVER.Engine.WPFTools;

public class HalfValueConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return (double)value / 2;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return (double)value * 2;
    }
}

public class NegateValueConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return -(double)value;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return -(double)value;
    }
}

public class NegativeDoubleConvert : IMultiValueConverter
{
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        if (values.Length != 2 || !(values[0] is double) || !(values[1] is double))
            return 0.0;

        double value = (double)values[0];
        double offset = (double)values[1];
        double param = parameter != null ? System.Convert.ToDouble(parameter) : 0;

        return -(value - offset / 2) + param;
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}

public class OffsetValueConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return (double)value / 2 + 30;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return ((double)value - 30) * 2;
    }
}