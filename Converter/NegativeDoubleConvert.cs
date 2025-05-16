using System.Globalization;
using System.Windows.Data;

namespace RECOVER.Converter;

public class NegativeDoubleConvert : IMultiValueConverter
{
    public object Convert(object[] values, System.Type targetType, object parameter, CultureInfo culture)
    {
        return -(double)values[0] + (double)values[1]/2;
    }

    public object[] ConvertBack(object value, System.Type[] targetTypes, object parameter, CultureInfo culture)
    {
        return [-(double)value];
    }
}