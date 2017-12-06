using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanoria
{
    public static class Login
    {
        public static bool checkLoginData(string p_Username, string p_Password)
        {
            if (p_Username == Properties.Settings.Default.username && p_Password == Properties.Settings.Default.password)
                return true;
            else
                return false;
        }

        public static string newPassword(string p_oldPassword, string p_newPassword, string p_newPasswordRep)
        {
            if (p_oldPassword == Properties.Settings.Default.password)
            {
                if (p_newPassword != "" && p_newPassword != null)
                {
                    if (p_newPassword == p_newPasswordRep)
                    {
                        Properties.Settings.Default.password = p_newPassword;
                        Properties.Settings.Default.Save();
                        return "ok";
                    }
                    else
                        return "Passwords do not match!";
                }
                else
                    return "Please enter a valid new Password!";
            }
            else
                return "Please enter the correct Password you used so far!";
        }

        public static string newAccount(string p_Username, string p_Password, string p_PasswordRep)
        {
            if (p_Username != "" && p_Username != null)
            {
                Properties.Settings.Default.username = p_Username;
                Properties.Settings.Default.Save();
            }
            else
                return "Please enter a valid Username!";

            if (p_Password != "" && p_Password != null)
            {
                if (p_Password == p_PasswordRep)
                {
                    Properties.Settings.Default.password = p_Password;
                    Properties.Settings.Default.Save();
                    return "ok";
                }
                else
                    return "Passwords do not match!";
            }
            else
                return "Please enter a valid Password!";       
        }
    }
}
