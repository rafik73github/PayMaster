using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace PayMaster.Tool
{

    public class ConvertColorByNegative : IValueConverter
    {
        
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                double num = (double)value;
                if (num < 0)
                {
                    return Brushes.Red;
                }

                return Brushes.Black;
            }

            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        
    }
}
