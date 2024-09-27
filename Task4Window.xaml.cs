using System;
using System.Linq;
using System.Windows;

namespace PR1
{
    public partial class Task4Window : Window
    {
        public Task4Window()
        {
            InitializeComponent();
        }

        private void SwapParts_Click(object sender, RoutedEventArgs e)
        {
            string[] inputArray = ArrayInput.Text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int[] array = inputArray.Select(int.Parse).ToArray();

            if (int.TryParse(MInput.Text, out int m) && m < array.Length)
            {
                int n = array.Length - m;
                Reverse(array, 0, m - 1);
                Reverse(array, m, array.Length - 1);
                Reverse(array, 0, array.Length - 1);

                ResultText.Text = "Результат: " + string.Join(", ", array);
            }
            else
            {
                ResultText.Text = "Некорректные данные.";
            }
        }

        private void Reverse(int[] array, int start, int end)
        {
            while (start < end)
            {
                int temp = array[start];
                array[start] = array[end];
                array[end] = temp;
                start++;
                end--;
            }
        }
    }
}