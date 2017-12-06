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

namespace Sanoria
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            passwordBox.Focus();

            Properties.Settings.Default.registration = true;
            Properties.Settings.Default.Save();

            // Case: New user
            if (Properties.Settings.Default.registration)
            {
                this.Hide();
                registerWindow = new RegisterWindow();
                registerWindow.Show();

                // Wait for end of registration
                dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
                dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
                dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 500);
                dispatcherTimer.Start();

                Properties.Settings.Default.registration = false;
                Properties.Settings.Default.Save();
            }
        }

        string inUsername;
        string inPassword;

        System.Windows.Threading.DispatcherTimer dispatcherTimer;

        ChangePasswordWindow changePasswordWindow;
        RegisterWindow registerWindow;
        ProgramWindow programWindow;

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            // Check Login Data (Start Logic or Retry)
            if (Login.checkLoginData(inUsername, inPassword))
            {
                this.Hide();
                programWindow = new ProgramWindow();
                programWindow.Show();
            }
            else
            {
                textBlock.Text = "Login failed! Wrong username or password.";
            }
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            if (registerWindow.finished())
            {
                this.Show();
                txtbUsername.Text = Properties.Settings.Default.username;
                dispatcherTimer.Stop();
            }
        }

        private void txtbUsername_TextChanged(object sender, TextChangedEventArgs e)
        {
            inUsername = txtbUsername.Text;
        }

        private void lblChangePassword_MouseUp(object sender, MouseButtonEventArgs e)
        {
            this.Hide();
            changePasswordWindow = new ChangePasswordWindow();
            changePasswordWindow.Show();

            // Wait for end of change Password
            dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick2);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 500);
            dispatcherTimer.Start();
        }

        private void dispatcherTimer_Tick2(object sender, EventArgs e)
        {
            if (changePasswordWindow.finished())
            {
                this.Show();
                dispatcherTimer.Stop();
            }
        }

        private void lblForgotPassword_MouseUp(object sender, MouseButtonEventArgs e)
        {
            textBlock.Text = "Please contact program administrator!";
        }

        private void lblChangePassword_MouseEnter(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblChangePassword_MouseLeave(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }

        private void lblForgotPassword_MouseEnter(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblForgotPassword_MouseLeave(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }

        private void passwordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            inPassword = passwordBox.Password;
        }
    }
}
