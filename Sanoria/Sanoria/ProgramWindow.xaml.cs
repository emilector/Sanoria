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
    public partial class ProgramWindow : Window
    {
        public ProgramWindow()
        {
            InitializeComponent();

            Surface.initials(ref txtbDate, ref textBlock6, ref textBlock9);

            sql = new SQL(ref data);
            data = new Data();
            xml = new XML(ref data);
        }

        Data data;
        SQL sql;
        XML xml;

        string m_name, m_value, m_comment, m_oldName;

        // Search Tool

        private void txtbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            SearchTool s = new SearchTool(ref txtbSearch, ref listBox, ref data);
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (txtbSearch.Text != "" && listBox.SelectedItems.Count != 0)
                labOutput.Content = data.map[data.getKeybyName(listBox.SelectedItem.ToString())].value;

            // Show Edit Attribute Stuff

            if (listBox.SelectedItems.Count != 0)
            {
                Surface.modeSelected(ref textBlock5, ref textBlock6, ref canvasEdit, ref txtbName_Copy, 
                    ref txtbValue_Copy, ref textBox_Copy, ref listBox, ref data, ref textBlock5_Copy, 
                    ref textBlock8, ref textBlock9, ref canvasDelete, ref infoBlock);

                m_oldName = listBox.SelectedItem.ToString();
            }
        }

        // Display all

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            sql.resetTable();
            sql.showTable(ref data);
        }

        // Add Attribute

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            if (data.checkifExistant(null, m_name))
            {
                Surface.modeRetryCreation2(ref infoBlock);
            }
            else if (m_name != "" && m_value != "" && m_name != null && m_value != null)
            {
                data.newStruct(data.map.Count, m_name, m_value, m_comment, txtbDate.Text);

                Surface.modeCreationDone(ref textBox, ref txtbName, ref txtbValue);

                infoBlock.Foreground = new SolidColorBrush(Colors.Green);
                infoBlock.Visibility = Visibility.Visible;
                infoBlock.Text = "Succesfully created attribute!";

                txtbSearch.Text = "";
                labOutput.Content = "";
            }
            else
            {
                Surface.modeRetryCreation(ref infoBlock);
            }
        }
            
        // Delete Attribute

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (listBox.SelectedItem != null)
            {
                data.deleteAttribute(listBox.SelectedItem.ToString());
                Surface.modeStandart(ref textBlock5, ref canvasEdit, ref textBlock7, ref textBlock5_Copy, ref canvasDelete);
                textBlock9.Text = "Succesfully deleted attribute '" + listBox.SelectedItem.ToString() + "'";
                textBlock9.Visibility = Visibility.Visible;

                txtbSearch.Text = "";
                labOutput.Content = "";
            }
        }

        // Edit Attribute

        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            if(txtbName_Copy.Text != "" && txtbValue_Copy.Text != "" && txtbValue_Copy.Text != null && txtbName_Copy.Text != null)
            {
                if (!data.changeAttribute(m_oldName, txtbName_Copy.Text, txtbValue_Copy.Text, textBox_Copy.Text))
                {
                    Surface.modeRetryEdit(ref textBlock7);
                }
                else
                {
                    Surface.modeStandart(ref textBlock5, ref canvasEdit, ref textBlock7, ref textBlock5_Copy, ref canvasDelete);
                    textBlock6.Foreground = new SolidColorBrush(Colors.Green);
                    textBlock6.Text = "Succesfully changed attribute '" + listBox.SelectedItem.ToString() + "'";
                    textBlock6.Visibility = Visibility.Visible;
                }
            }
            else
            {
                Surface.modeStandart(ref textBlock5, ref canvasEdit, ref textBlock7, ref textBlock5_Copy, ref canvasDelete);
                textBlock6.Foreground = new SolidColorBrush(Colors.Red);
                textBlock6.Text = "Name and Value can not be empty!";
                textBlock6.Visibility = Visibility.Visible;
            }

            txtbSearch.Text = "";
            labOutput.Content = "";
        }

        // Reset Data

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                data.resetData();

                MessageBox.Show("Succesfully deleted all Data!");
            }
            catch
            {
                throw new NotImplementedException("Failed deleting Data!");
            }
        }

        // Save and Exit

        private void btnExit_Click_1(object sender, RoutedEventArgs e)
        {
            xml.loadDatatoXML(ref data);
            System.Windows.Application.Current.Shutdown();
        }

        // Exit

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        // Text Changed +++

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            m_comment = textBox.Text;
        }

        private void txtbName_TextChanged(object sender, TextChangedEventArgs e)
        {
            m_name = txtbName.Text;
        }

        private void txtbValue_TextChanged(object sender, TextChangedEventArgs e)
        {
            m_value = txtbValue.Text;
        }
    }
}
