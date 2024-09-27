using System;
using System.Windows;

namespace PR1
{
    public partial class Task2Window : Window
    {
        public Task2Window()
        {
            InitializeComponent();
        }

        private void CheckString_Click(object sender, RoutedEventArgs e)
        {
            string input = StringInput.Text;
            int result;

            if (int.TryParse(input, out result))
            {
                ResultText.Text = "1 (целое число)";
            }
            else if (double.TryParse(input, out double resultDouble) && input.Contains("."))
            {
                ResultText.Text = "2 (вещественное число)";
            }
            else
            {
                ResultText.Text = "0 (не число)";
            }
        }
    }
}