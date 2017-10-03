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

namespace TCPMessenger
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Title = "TCP Messenger"; 
        }

        public Grid getGrid()
        {
            return grid; 
        }

        private void sendButton_Click(object sender, RoutedEventArgs e)
        {
            sendMessage(); 
        }

        private void textBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                sendMessage(); 
                e.Handled = true;
            }
        }

        private void exitMenuItem_Click(object sender, RoutedEventArgs e)
        {
            System.Environment.Exit(1);   
        }

        private void settingsMenuItem_Click(object sender, RoutedEventArgs e)
        {
            settingsWindow settingsWindow = new settingsWindow(this);
            settingsWindow.Title = "Settings"; 
            settingsWindow.Show();
        }

        private void sendMessage()
        {
            if (!String.IsNullOrWhiteSpace(ipTextBox.Text))
            {
                String oldConvo = convoBox.Text;
                convoBox.Text = oldConvo + "\nYou: " + textBox.Text;
                textBox.Text = "";
            }       
            else
            {
                MessageBox.Show("Enter an IP Address!");
            }
        }
    }
}
