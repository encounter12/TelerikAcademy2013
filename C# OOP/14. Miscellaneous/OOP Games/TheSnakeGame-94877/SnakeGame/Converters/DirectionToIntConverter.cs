using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SnakeGame.GameObjects;
using System.Globalization;
using System.Windows.Data;

namespace SnakeGame.Converters
{
    public class DirectionToIntConverter : IValueConverter
    {
        public object Convert(object value, Type targetType,
            object parameter, CultureInfo culture)
        {

            MoveDirections direction = (MoveDirections)value;
            if (targetType != typeof(double))
            {
                throw new ArgumentException("Invalid data");
            }
            double directionValue = 90;
            switch (direction)
            {
                case MoveDirections.Up:
                    directionValue = 270;
                    break;
                case MoveDirections.Right:
                    directionValue = 0;
                    break;
                case MoveDirections.Down:
                    directionValue = 90;
                    break;
                case MoveDirections.Left:
                    directionValue = 180;
                    break;
                default:
                    break;
            }
            return directionValue;
        }

        public object ConvertBack(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
