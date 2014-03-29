using System;
using System.Collections.Generic;
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

namespace TestApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Student student = new Student { Name = "John" };
            SchoolClass myClass = new SchoolClass();

            myClass.Students = new List<Student>()
            {
                new Student{Name= "Mike"}, 
                new Student{Name ="Joe"},
                new Student{Name ="Silvester"}
            };

            this.DataContext = student;
            dataGrid1.DataContext = myClass;
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("School created");
        }
        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("School details displayed");
        }
        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("School objects saved to database");
        }
        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("School objects modified");
        }
    }
}
