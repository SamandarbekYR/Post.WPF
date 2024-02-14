using Post.Desktop.Pages;
using System.Windows;
using System.Windows.Controls;

namespace Post.Desktop.Windows
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        public Settings()
        {
            InitializeComponent();
        }
        private void btnxClose(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int index = int.Parse(((Button)e.Source).Uid);

            GridCursor.Margin = new Thickness(10 + (170 * index), 0, 0, 0);

            switch (index)
            {
                case 0:
                    main.Content = new LanguagaSetting();
                    break;
                case 1:
                    main.Content = new PrinterSetting();
                    break;
            }
        }
    }
}
