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
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();

            textBox.Focus();
            isLoaded = true;
        }

        string inPassword;
        string inPasswordRep;
        string inUsername;

        string result;

        bool isLoaded = false;

        private void button_Click(object sender, RoutedEventArgs e)
        {
            result = Login.newAccount(inUsername, inPassword, inPasswordRep);

            if (result == "ok")
                this.Close();
            else textBlock.Text = result; 
        }

        public bool finished()
        {
            if (result == "ok")
                return true;
            else
                return false;
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            inUsername = textBox.Text;
        }

        private void textBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (isLoaded && textBox.Text == "Username")
                textBox.Text = "";
        }

        private void window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(result != "ok")
            System.Windows.Application.Current.Shutdown();
        }

        private void passwordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            inPassword = passwordBox.Password;
        }

        private void passwordBox_Copy_PasswordChanged(object sender, RoutedEventArgs e)
        {
            inPasswordRep = passwordBox_Copy.Password;
        }
    }
}
