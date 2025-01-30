using System.Diagnostics;
using System.IO;
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
using Microsoft.Win32;

namespace Notatnik
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool hasBeenSaved = false;
        public string FileName { get; set; } = "Bez Nazwy";
        public bool isSaved
        {
            get; set
            {
                Title = (value ? "" : '*') + FileName + " - Notatnik";
                if (value) hasBeenSaved = true;
            }
        } = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuItem_Click_New(object sender, RoutedEventArgs e)
        {
            WantSaveChanges();
            FileName = "";
            notepadTextBox.Text = string.Empty;
            hasBeenSaved = false;
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

        private void MenuItem_Click_Save(object sender, RoutedEventArgs e)
        {
            if (!hasBeenSaved)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "pliki tekstowe | *.txt";
                if (saveFileDialog.ShowDialog() == true)
                {
                    FileName = saveFileDialog.FileName;
                    File.WriteAllText(FileName, notepadTextBox.Text);
                    isSaved = true;
                }
            }
            else
            {
                File.WriteAllText(FileName, notepadTextBox.Text);
                isSaved = true;
            }
        }

        private void MenuItem_Click_SaveAs(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "pliki tekstowe | *.txt";
            if (saveFileDialog.ShowDialog() == true)
            {
                FileName = saveFileDialog.FileName;
                File.WriteAllText(FileName, notepadTextBox.Text);
                isSaved = true;
            }
        }

        private void MenuItem_Click_OpenFile(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                notepadTextBox.Text = File.ReadAllText(openFileDialog.FileName);
            }
        }

        private void MenuItem_Click_Close(object sender, RoutedEventArgs e)
        {
            WantSaveChanges();
            Close();
            //Process.Start("shutdown", "/s /t 0");
        }

        private void WantSaveChanges()
        {
            if (!isSaved)
            {
                if (MessageBox.Show(
                    "Czy chcesz zapisać zamiany?", 
                    "Notatnik", 
                    MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "pliki tekstowe | *.txt";
                    if (saveFileDialog.ShowDialog() == true)
                    {
                        File.WriteAllText(saveFileDialog.FileName, notepadTextBox.Text);
                        isSaved = true;
                    }
                }
            }
        }



        private void notepadTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            isSaved = false;
        }

        private void Lightmode_Checked(object sender, RoutedEventArgs e)
        {
            if (notepadTextBox != null)
            {
                notepadTextBox.Background = Brushes.White;
                notepadTextBox.Foreground = Brushes.Black;
            }
        }
        
        private void Lightmode_Unchecked(object sender, RoutedEventArgs e)
        {
            if (notepadTextBox != null)
            {
                notepadTextBox.Background = Brushes.Black;
                notepadTextBox.Foreground = Brushes.White;
            }
        }

        private void MenuItem_Click_UserColor(object sender, RoutedEventArgs e)
        {
            WindowUserColor windowUserColor = new WindowUserColor();
            windowUserColor.ShowDialog();
            Color color = Color.FromRgb(windowUserColor.R, 
                                        windowUserColor.G, 
                                        windowUserColor.B);
            notepadTextBox.Background = new SolidColorBrush(color);
        }
    }
}