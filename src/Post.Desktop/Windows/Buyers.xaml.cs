using Post.Desktop.Components;
using System.Windows;
using System.Windows.Media;

namespace Post.Desktop.Windows;

/// <summary>
/// Interaction logic for Buyers.xaml
/// </summary>
public partial class Buyers : Window
{
    public Buyers()
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
    }

    private void new_customer_Click(object sender, RoutedEventArgs e)
    {

    }

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        for (int i = 0; i < 20; i++)
        {
            BuyerComponent buyerComponent = new BuyerComponent();
            stp_Buyers.Children.Add(buyerComponent);
        }
    }
}
