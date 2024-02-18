using Post.Desktop.Components;
using System.Windows;
using System.Windows.Media;

namespace Post.Desktop.Windows;

/// <summary>
/// Interaction logic for NationWindow.xaml
/// </summary>
public partial class NationWindow : Window
{
    public NationWindow()
    {
        InitializeComponent();
    }
    private void close_Button_Click(object sender, RoutedEventArgs e)
    {
        this.Close();
    }

    private void TextBox_GotFocus(object sender, RoutedEventArgs e)
    {
        search_Border.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#00559A"));
        tb_Search.Text = "";
        tb_Search.Foreground = Brushes.Black;
        tb_Search.FontSize = 18;
    }
    private void tb_Search_LostFocus(object sender, RoutedEventArgs e)
    {
        search_Border.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Black"));
        tb_Search.Foreground = Brushes.Gray;
        tb_Search.FontSize = 15;
        tb_Search.Text = "Search...";
    }

    private void new_customer_Click(object sender, RoutedEventArgs e)
    {

    }

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        for (int i = 0; i < 20; i++)
        {
            NationBuyerCmponent nationBuyerCmponent = new NationBuyerCmponent();
            stp_Buyers.Children.Add(nationBuyerCmponent);
        }
    }
}
