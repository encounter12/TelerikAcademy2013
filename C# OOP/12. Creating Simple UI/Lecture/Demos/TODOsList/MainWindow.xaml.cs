using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using TODOsList.Models;

namespace TODOsList
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TodoList todoList;

        public MainWindow()
        {
            InitializeComponent();
            this.InitializeTodoList();
            var timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += (obj, args) =>
            {
                this.RenderTodos();
            };
            timer.Start();
        }

        private void InitializeTodoList()
        {
            var reader = new StreamReader("todo-items.txt");
            var serializedData = reader.ReadToEnd();
            this.todoList = TodoList.Deserialize(serializedData);
        }

        public void OnAddTodoButtonClick(object sender, RoutedEventArgs e)
        {
            var text = this.TodoTextBox.Text;
            var date = DateTime.Now;
            this.todoList.AddTodo(text, date);
            this.TodoTextBox.Text = "";
            this.RenderTodos();
        }

        private void RenderTodos()
        {
            this.TodosContainer.Children.Clear();
            this.TodosContainer.Children.Add(this.todoList.Render());
        }
        
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            StreamWriter writer = new StreamWriter("todo-items.txt",false);
            using (writer)
            {
                writer.Write(this.todoList.Serialize());
            }
        }

    }
}
