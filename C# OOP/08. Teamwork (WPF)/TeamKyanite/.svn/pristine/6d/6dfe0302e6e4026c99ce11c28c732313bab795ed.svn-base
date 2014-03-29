using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TeamKyanite.SchoolObjects;

namespace TeamKyanite
{
    /// <summary>
    /// Interaction logic for AdminMainWindow.xaml
    /// </summary>
    public partial class AdminMainWindow : Window
    {
        public AdminMainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        public void ViewAllTeachers_Click(object sender, RoutedEventArgs e)
        {
            AllTeachersWindow teachersWindow = new AllTeachersWindow();
            teachersWindow.ShowDialog();
        }

        private void CreateSchool_Click(object sender, RoutedEventArgs e)
        {
            using (SchoolDatabaseContext context = new SchoolDatabaseContext())
            {

                if (!context.Database.Exists())
                {
                    School school = SchoolTest.CreateSchool();
                    context.Schools.Add(school);
                    context.SaveChanges();
                    MessageBox.Show("School database created");
                }
                else
                {
                    MessageBox.Show("School database already exists");
                }            
            }
        }

        private void ViewClasses_Click(object sender, RoutedEventArgs e)
        {
            SchoolClassesWindow classesListWindow = new SchoolClassesWindow();
            classesListWindow.ShowDialog();

        }
        private void ViewAllStudents_Click(object sender, RoutedEventArgs e)
        {
            AllStudentsWindow allStudentsListWindow = new AllStudentsWindow();
            allStudentsListWindow.ShowDialog();
        }

        private void Queries_Click(object sender, RoutedEventArgs e)
        {
            Queries queries = new Queries();
            queries.ShowDialog();
        }

        private void DeleteAll_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (SchoolDatabaseContext context = new SchoolDatabaseContext())
                {
                    if (context.Database.Exists())
                    {
                        SqlConnection.ClearAllPools();
                        context.Database.Delete();
                        MessageBox.Show("Whole database deleted");
                    }
                    else
                    {
                        MessageBox.Show("There is no database created");
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("The database could not be deleted. Try closing any existing connections!");
            }

        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
