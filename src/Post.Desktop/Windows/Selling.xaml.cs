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

namespace Post.Desktop.Windows
{
    /// <summary>
    /// Interaction logic for Selling.xaml
    /// </summary>
    public partial class Selling : Window
    {
        public Selling()
        {
            InitializeComponent();
        }

        private void btnShutDown(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
