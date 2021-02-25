using System.Text.RegularExpressions;
using System.Windows.Input;

namespace PayMaster.Tools
{
    class ValidateText
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

        public static void LetterValidatinTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex(@"[^a-z-]+");

            e.Handled = regex.IsMatch(e.Text);

        }

    }
}
