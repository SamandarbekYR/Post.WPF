using System.Windows;
using System.Windows.Media.Effects;

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
        public void ShowMealOrdersWindow()
        {
            BlurEffect blur = new BlurEffect();
            blur.Radius = 15; // You can adjust the blur radius as needed
            Effect = blur;
        }

        private void btnSettings(object sender, RoutedEventArgs e)
        {
            Settings settings = new Settings();
            ShowMealOrdersWindow();
            settings.ShowDialog();
            Effect = null;
        }

        private void btnBuyers(object sender, RoutedEventArgs e)
        {
            Loan loan = new Loan();
            loan.ShowDialog();
        }
    }
}
