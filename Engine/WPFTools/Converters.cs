using System.Globalization;
using System.Windows.Data;

namespace RECOVER.Engine.WPFTools;

public class HalfAndOriginValueConverter : IMultiValueConverter
{
    public static readonly HalfAndOriginValueConverter Instance = new HalfAndOriginValueConverter();
    
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        if (values.Length == 0 || values.Any(d => d is not double))
        {
            return null;
        }

        return (double)values[0] / 2 + (double)values[1] * (double)values[2];
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}

public class NegateValueConverter : IValueConverter
{
    public static readonly NegateValueConverter Instance = new NegateValueConverter();
    
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
    public static readonly NegativeDoubleConvert Instance = new NegativeDoubleConvert();
    
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