﻿using System.Windows;

namespace PR1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Task1Button_Click(object sender, RoutedEventArgs e)
        {
            Task1Window task1Window = new Task1Window();
            task1Window.Show();
        }

        private void Task2Button_Click(object sender, RoutedEventArgs e)
        {
            Task2Window task2Window = new Task2Window();
            task2Window.Show();
        }

        private void Task3Button_Click(object sender, RoutedEventArgs e)
        {
            Task3Window task3Window = new Task3Window();
            task3Window.Show();
        }

        private void Task4Button_Click(object sender, RoutedEventArgs e)
        {
            Task4Window task4Window = new Task4Window();
            task4Window.Show();
        }

        private void Task5Button_Click(object sender, RoutedEventArgs e)
        {
            Task5Window task5Window = new Task5Window();
            task5Window.Show();
        }
    }
}