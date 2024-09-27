using System;
using System.Linq;
using System.Windows;

namespace PR1
{
    public partial class Task3Window : Window
    {
        public Task3Window()
        {
            InitializeComponent();
        }

        private void OnFindNumbersClick(object sender, RoutedEventArgs e)
        {
            try
            {
                string input = InputArray.Text;

                var numbers = input.Split(',')
                                   .Select(n => n.Trim())
                                   .Where(n => int.TryParse(n, out _))
                                   .ToArray();

                var result = numbers.GroupBy(n => string.Concat(n.OrderBy(c => c)))
                                    .Where(g => g.Count() > 1)
                                    .SelectMany(g => g)
                                    .ToList();

                ResultBox.Text = result.Count > 0 ? string.Join(", ", result) : "Нет совпадающих чисел.";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}");
            }
        }
    }
}