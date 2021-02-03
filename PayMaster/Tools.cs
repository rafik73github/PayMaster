using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PayMaster
{
    class Tools
    {


        public static void NoSpaceTextbox(object sender, KeyEventArgs e)
        {
            e.Handled = e.Key == Key.Space;
        }

        public static void NumberValidatinTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex(@"[^0-9,]+");
            
            e.Handled = regex.IsMatch(e.Text);
            
        }

    }
}
