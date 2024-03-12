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
        Label[] labelArray = null;
        Label currentLabel;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void reverseButton_Click(object sender, RoutedEventArgs e)
        {
            Array.Reverse(labelArray);

            foreach (Label label in labelArray)
            {
               
            }
        }

        public void CreateNewRow(int currentRow, string word)
        {
            currentLabel = new Label();
            currentLabel.SetValue(Grid.RowProperty, currentRow);
            currentLabel.Content = word;
            currentRow++;

        }

        public void UpdateList(char newchar)
        {
            string currentLabelText = currentLabel.Content as string;
            currentLabel.Content = currentLabelText + newchar;
        }

        private void inputTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string myText = inputTextBox.Text;
            string[] wordStringList = myText.Split(' ');
            myGrid.Items.Clear();
            foreach (string word in wordStringList)
            {
                Word newWord = new Word(word, word.Length);
                myGrid.Items.Add(newWord);
            }
            myGrid.Items.Refresh();
        }


        public class Word
        {
            public string WordText { get; set; }
            public int Length { get; set; }

            public Word(string word, int length)
            {
                WordText = word;
                Length = length;
            }
        }
    }
}
