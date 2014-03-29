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
using System.Windows.Shapes;
using TeamKyanite.SchoolObjects;

namespace TeamKyanite
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private SchoolDatabaseContext db;
        public LoginWindow()
        {
            InitializeComponent();
            this.db = new SchoolDatabaseContext();
        }
        public void CancelButtonClick(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        public void LoginButtonClick(object sender, RoutedEventArgs e)
        {
            string enteredUsername = this.userName.Text;
            string enteredPassword = this.password.Password;
            if (enteredUsername == "admin" && enteredPassword == "admin")
            {
                var mainWindow = new AdminMainWindow();
                mainWindow.Show();
                this.Close();

            }
            else if (AccountHelper.IsLoginDataValid(enteredUsername, enteredPassword))
            {
                var account = db.Accounts.First(a => a.Username == enteredUsername);
                Human holder = account.Holder;
                if (holder is Teacher)
                {
                    var mainWindow = new TeacherMainWindow(holder as Teacher);
                    mainWindow.Show();
                    this.Close();
                }
                else if (holder is Student)
                {
                    var mainWindow = new StudentMainWindow(holder as Student);
                    mainWindow.Show();
                    this.Close();
                }
                else
                {
                    throw new NotImplementedException("Current account type is not supported!");
                }

            }
            else
            {
                MessageBox.Show("Wrong username or password!");
            }
        }

        
    }
}
