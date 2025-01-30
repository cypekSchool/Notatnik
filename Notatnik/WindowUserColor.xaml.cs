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

namespace Notatnik
{
    /// <summary>
    /// Logika interakcji dla klasy UserColor.xaml
    /// </summary>
    public partial class WindowUserColor : Window
    {
        public byte R { get; set; }
        public byte G { get; set; }
        public byte B { get; set; }
        public WindowUserColor()
        {
            InitializeComponent();
        }

        private void Button_Click_Confirm(object sender, RoutedEventArgs e)
        {
            byte r, g, b;
            if (byte.TryParse(TextBox_R.Text, out r)) R = r;
            if (byte.TryParse(TextBox_G.Text, out g)) G = g;
            if (byte.TryParse(TextBox_B.Text, out b)) B = b;
            Close();
        }
    }
}
