using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace TODOsList.Models
{
    public class TodoItem
    {
        public string Text { get; private set; }
        public DateTime DateTaken { get; private set; }

        public TodoItem(string text, DateTime timeTaken)
        {
            this.Text = text;
            this.DateTaken = timeTaken;
        }

        public UIElement Render()
        {
            var container = new UniformGrid();
            container.HorizontalAlignment = HorizontalAlignment.Stretch;
            container.Columns = 3;

            //creating the TextBox for the Text of the Todo
            var textTextBox = new TextBlock();
            textTextBox.Text = this.Text;
            textTextBox.FontWeight = FontWeights.Bold;
            textTextBox.FontSize = 18;
            container.Children.Add(textTextBox);

            //creating the TextBox for the Text of the Todo
            var dateTextBox = new TextBlock();
            dateTextBox.Text = this.DateTaken.ToString();
            dateTextBox.FontSize = 14;
            container.Children.Add(dateTextBox);

            //creating the Delete button
            var deleteButton = new Button();
            deleteButton.Content = "X";
            container.Children.Add(deleteButton);

            return container;
        }

        public string Serialize()
        {
            return string.Format("{0}" + Environment.NewLine + "{1}", this.Text, this.DateTaken);
        }
    }
}
