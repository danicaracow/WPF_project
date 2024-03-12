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
        public MainWindow()
        {
            InitializeComponent();
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

        private void inputTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            myGrid.Items.Clear();
            string[] wordStringList = GetSplitText(inputTextBox.Text);
            foreach (string word in wordStringList)
            {
                Word newWord = new Word(word, word.Length);
                myGrid.Items.Add(newWord);
            }
        }

        private void reverseButton_Click(object sender, RoutedEventArgs e)
        {
            string[] wordStringList = GetSplitText(inputTextBox.Text);

            Array.Reverse(wordStringList);
            string reversedText = String.Join(" ", wordStringList);

            myGrid.Items.Clear();
            inputTextBox.Clear();
            inputTextBox.Text = reversedText;
        }

        private string[] GetSplitText(string text)
        {
            return text.Split(' ');
        }
    }
}
