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

namespace Sanoria
{
    public partial class ChangePasswordWindow : Window
    {
        public ChangePasswordWindow()
        {
            InitializeComponent();

            textBox.Focus();
            isLoaded = true;
        }

        string inOldPassword;
        string inNewPassword;
        string inNewPasswordRep;
        bool isLoaded = false;
        string result;

        public bool finished()
        {
            if (result == "ok")
                return true;
            else
                return false;
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            inOldPassword = textBox.Text;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            result = Login.newPassword(inOldPassword, inNewPassword, inNewPasswordRep);

            if (result == "ok")
                this.Close();
            else textBlock.Text = result;           
        }

        private void textBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (isLoaded && textBox.Text == "Old Password")
                textBox.Text = "";
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            result = "ok";
        }

        private void passwordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            inNewPassword = passwordBox.Password;
        }

        private void passwordBox_Copy_PasswordChanged(object sender, RoutedEventArgs e)
        {
            inNewPasswordRep = passwordBox_Copy.Password;
        }
    }
}
