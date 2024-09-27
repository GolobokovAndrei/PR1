using System;
using System.Windows;

namespace PR1
{
    public partial class Task1Window : Window
    {
        public Task1Window()
        {
            InitializeComponent();
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            string binaryInput = BinaryInput.Text;
            try
            {
                long decimalNumber = Convert.ToInt64(binaryInput, 2);
                if (decimalNumber % 15 == 0)
                {
                    ResultText.Text = "Число делится на 15";
                }
                else
                {
                    ResultText.Text = "Число не делится на 15";
                }
            }
            catch (Exception)
            {
                ResultText.Text = "Неверный ввод!";
            }
        }
    }
}
