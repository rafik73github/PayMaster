using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace PayMaster
{

    class IfNegative : IValueConverter
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
