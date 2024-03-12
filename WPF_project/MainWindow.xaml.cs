using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
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

namespace WPF_project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int currentRow = 1;
        Label[] labelArray = null;
        Label currentLabel;
        public MainWindow()
        {
            InitializeComponent();

            CreateNewRow();
            
        }

        private void reverseButton_Click(object sender, RoutedEventArgs e)
        {
            Array.Reverse(labelArray);

            foreach (Label label in labelArray)
            {
               
            }
        }

        private void inputTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            //if(e.Key == Key.Space) 
            //{
            //    CreateNewRow();
            //}
            //else
            //{
            //    UpdateList(((Char)e.Key));
            //}

            if (e.Key == Key.Space)
            {
                CreateNewRow();
            }
            else if (e.Key >= Key.A && e.Key <= Key.Z)
            {
                char character = (char)('A' + (e.Key - Key.A));
                UpdateList(character);
            }
            else if (e.Key >= Key.D0 && e.Key <= Key.D9)
            {
                char character = (char)('0' + (e.Key - Key.D0));
                UpdateList(character);
            }
            else if (e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
            {
                char character = (char)('0' + (e.Key - Key.NumPad0));
                UpdateList(character);
            }

        }

        //private void Grid_TextInput(object sender, TextCompositionEventArgs e)
        //{
        //    Char keyChar = (Char)System.Text.Encoding.ASCII.GetBytes(e.Text)[0];
        //    Debug.WriteLine(keyChar);
        //}

        public void CreateNewRow()
        {
            currentLabel = new Label();
            labelArray[currentRow] = currentLabel;
            myGrid.Children.Add(currentLabel);
            currentLabel.SetValue(Grid.RowProperty, currentRow);
            currentRow++;

        }

        public void UpdateList(char newchar)
        {
            string currentLabelText = currentLabel.Content as string;
            currentLabel.Content = currentLabelText + newchar;
        }
    }
}
