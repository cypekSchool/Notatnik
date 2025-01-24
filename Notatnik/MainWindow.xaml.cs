using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Notatnik
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

        private void MenuItem_Click_New(object sender, RoutedEventArgs e)
        {
            notepadTextBox.Text = string.Empty;
        }

        private void MenuItem_Click_Author(object sender, RoutedEventArgs e)
        {
            WindowAuthor windowAuthor = new();
            windowAuthor.Show();
        }

        private void MenuItem_Click_App(object sender, RoutedEventArgs e)
        {
            WindowApp windowApp = new();
            windowApp.Show();
        }
    }
}