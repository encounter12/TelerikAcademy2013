﻿namespace TeamKyanite
{
    using System;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;

    /// <summary>
    /// Interaction logic for Queries.xaml
    /// </summary>
    public partial class Queries : Window
    {
        public Queries()
        {
            InitializeComponent();
        }

        private void Username_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= Username_GotFocus;
        }

        private void ClearButton(object sender, RoutedEventArgs e)
        {
            ViewData.Text = String.Empty;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
                    }
    }
}