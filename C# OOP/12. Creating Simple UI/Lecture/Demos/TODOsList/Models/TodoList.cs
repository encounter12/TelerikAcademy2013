using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace TODOsList.Models
{
    class TodoList
    {
        private List<TodoItem> TodoItems { get; set; }

        public TodoList()
        {
            this.TodoItems = new List<TodoItem>();
        }

        public UIElement Render()
        {
            var list = new ListBox();
            foreach (var todoItem in this.TodoItems)
            {
                var renderedTodoItem = todoItem.Render();

                var listTodoItemItem = new ListBoxItem();
                listTodoItemItem.Content = renderedTodoItem;
                var deleteButtons = (renderedTodoItem as Panel).Children.OfType<Button>();
                foreach (var delButton in deleteButtons)
                {
                    delButton.Click += (snd, args) =>
                    {
                        this.TodoItems.Remove(todoItem);
                    };
                }

                list.Items.Add(listTodoItemItem);
            }
            return list;
        }

        public void AddTodo(string text, DateTime date)
        {
            var todoItem = new TodoItem(text, date);
            this.TodoItems.Add(todoItem);
        }

        public string Serialize()
        {
            StringBuilder builder = new StringBuilder();
            foreach (var todoItem in this.TodoItems)
            {
                builder.Append(todoItem.Serialize());
                builder.Append(Environment.NewLine);
            }
            return builder.ToString();
        }

        public static TodoList Deserialize(string serializedData)
        {
            var serializedTodoItems = serializedData.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            if (serializedTodoItems.Length % 2 == 1)
            {
                throw new ArgumentOutOfRangeException("The serialized data is invalid");
            }
            var todoList = new TodoList();
            for (var i = 0; i < serializedTodoItems.Length; i += 2)
            {
                todoList.AddTodo(serializedTodoItems[i], DateTime.Parse(serializedTodoItems[i + 1]));
            }
            return todoList;
        }
    }
}
