using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SnakeGame.ViewModels;
using SnakeGame.GameObjects;

namespace SnakeGame.Views
{
    /// <summary>
    /// Interaction logic for SnakeGameControlxaml.xaml
    /// </summary>
    public partial class SnakeGameControlxaml : UserControl
    {
        public SnakeGameControlxaml()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            (this.DataContext as GameEngine).StartGame();
        }

        private void UserControl_KeyDown(object sender, KeyEventArgs e)
        {
            MoveDirections direction = MoveDirections.Right;
            switch (e.Key)
            {
                case Key.Left:
                    direction = MoveDirections.Left;
                    break;
                case Key.Right:
                    direction=MoveDirections.Right;
                    break;
                case Key.Up:
                    direction=MoveDirections.Up;
                    break;
                case Key.Down:
                    direction=MoveDirections.Down;
                    break;
            }
            (DataContext as GameEngine).ChangeDirection(direction);
        }
    }
}
