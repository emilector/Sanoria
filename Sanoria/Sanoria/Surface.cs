using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Sanoria
{
    public static class Surface
    {
        public static void modeRetryEdit(ref TextBlock textBlock7)
        {
            textBlock7.Visibility = Visibility.Visible;
            textBlock7.Text = "Attribute Name is already existant!";
        }

        public static void modeSelected(ref TextBlock textBlock5, ref TextBlock textBlock6, ref Canvas canvasEdit, ref TextBox txtbName_Copy, ref TextBox txtbValue_Copy, ref TextBox textBox_Copy, ref ListBox listBox, ref Data data, ref TextBlock textBlock5_Copy, ref TextBlock textBlock8, ref TextBlock textBlock9, ref Canvas canvasDelete, ref TextBlock infoBlock)
        {
            textBlock5.Visibility = Visibility.Hidden;
            textBlock6.Visibility = Visibility.Hidden;
            canvasEdit.Visibility = Visibility.Visible;
            canvasDelete.Visibility = Visibility.Visible;
            textBlock5_Copy.Visibility = Visibility.Hidden;
            textBlock9.Visibility = Visibility.Hidden;
            infoBlock.Visibility = Visibility.Hidden;

            textBlock8.Text = listBox.SelectedItem.ToString();
            txtbName_Copy.Text = listBox.SelectedItem.ToString();
            txtbValue_Copy.Text = data.map[data.getKeybyName(listBox.SelectedItem.ToString())].value;
            textBox_Copy.Text = data.map[data.getKeybyName(listBox.SelectedItem.ToString())].comment;
        }

        public static void modeStandart(ref TextBlock textBlock5, ref Canvas canvasEdit, ref TextBlock textBlock7, ref TextBlock textBlock5_Copy, ref Canvas canvasDelete)
        {
            textBlock5.Visibility = Visibility.Visible;
            canvasEdit.Visibility = Visibility.Hidden;
            textBlock7.Visibility = Visibility.Hidden;

            canvasDelete.Visibility = Visibility.Hidden;
            textBlock5_Copy.Visibility = Visibility.Visible;
        }

        public static void modeRetryCreation(ref TextBlock infoBlock)
        {
            infoBlock.Foreground = new SolidColorBrush(Colors.Red);
            infoBlock.Text = "Please enter valid Name and Value!";
            infoBlock.Visibility = Visibility.Visible;
        }

        public static void modeRetryCreation2(ref TextBlock infoBlock)
        {
            infoBlock.Foreground = new SolidColorBrush(Colors.Red);
            infoBlock.Text = "Attribute Name is already existant!";
            infoBlock.Visibility = Visibility.Visible;
        }

        internal static void modeCreationDone(ref TextBox textBox, ref TextBox txtbName, ref TextBox txtbValue)
        {
            textBox.Text = "";
            txtbName.Text = "";
            txtbValue.Text = "";
        }

        public static void initials(ref TextBlock txtbDate, ref TextBlock textBlock6, ref TextBlock textBlock9)
        {
            textBlock6.Foreground = new SolidColorBrush(Colors.Green);
            textBlock9.Foreground = new SolidColorBrush(Colors.Green);
            txtbDate.Text = DateTime.Today.ToString("d");
        }
    }
}
