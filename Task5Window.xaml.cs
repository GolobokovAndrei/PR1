using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace PR1
{
    public partial class Task5Window : Window
    {
        private int[,] array;

        public Task5Window()
        {
            InitializeComponent();
        }

        private void GenerateArray_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(ColumnTextBox.Text, out int m) && int.TryParse(RowTextBox.Text, out int n))
            {
                array = GenerateRandomArray(m, n);
                DisplayArray(OriginalArrayDataGrid, array, m);
                DisplaySortedArrays(m);
                DisplayMinMaxValues();
            }
            else
            {
                MessageBox.Show("Введите корректные значения для M и N");
            }
        }

        private int[,] GenerateRandomArray(int m, int n)
        {
            Random rand = new Random();
            int[,] result = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    result[i, j] = rand.Next(-10, 11);
                }
            }
            return result;
        }

        private List<RowData> ConvertArrayToList(int[,] array, int columns)
        {
            var rows = array.GetLength(0);
            var result = new List<RowData>();

            for (int i = 0; i < rows; i++)
            {
                var row = new RowData(columns);
                for (int j = 0; j < columns; j++)
                {
                    row.Values[j] = array[i, j];
                }
                result.Add(row);
            }
            return result;
        }

        private void DisplayArray(DataGrid dataGrid, int[,] array, int columns)
        {
            dataGrid.AutoGenerateColumns = false;
            dataGrid.Columns.Clear();

            for (int i = 0; i < columns; i++)
            {
                dataGrid.Columns.Add(new DataGridTextColumn
                {
                    Header = $"Column {i}",
                    Binding = new System.Windows.Data.Binding($"Values[{i}]")
                });
            }

            dataGrid.ItemsSource = ConvertArrayToList(array, columns);
        }

        private void DisplaySortedArrays(int columns)
        {
            var sortedAsc = array.Cast<int>().OrderBy(x => x).ToArray();
            var sortedDesc = array.Cast<int>().OrderByDescending(x => x).ToArray();

            DisplaySortedArray(SortedAscDataGrid, sortedAsc, columns);
            DisplaySortedArray(SortedDescDataGrid, sortedDesc, columns);
        }

        private void DisplaySortedArray(DataGrid dataGrid, int[] sortedArray, int columns)
        {
            int rows = array.GetLength(0);
            int[,] sorted2DArray = new int[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    sorted2DArray[i, j] = sortedArray[i * columns + j];
                }
            }

            DisplayArray(dataGrid, sorted2DArray, columns);
        }

        private void DisplayMinMaxValues()
        {
            int maxValue = array.Cast<int>().Max();
            int minValue = array.Cast<int>().Min();

            MaxValueTextBlock.Text = maxValue.ToString();
            MinValueTextBlock.Text = minValue.ToString();
        }
    }

    public class RowData
    {
        public List<int> Values { get; set; }

        public RowData(int columns)
        {
            Values = new List<int>(new int[columns]);
        }
    }
}
