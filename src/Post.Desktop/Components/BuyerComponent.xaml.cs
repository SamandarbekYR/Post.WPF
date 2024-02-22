using Post.Desktop.Windows;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Post.Desktop.Components;

/// <summary>
/// Interaction logic for BuyerComponent.xaml
/// </summary>
public partial class BuyerComponent : UserControl
{
    public BuyerComponent()
    {
        InitializeComponent();
    }

    private void Border_MouseEnter(object sender, MouseEventArgs e)
    {
        buyer_Border.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ECECEC"));
    }

    private void Border_MouseLeave(object sender, MouseEventArgs e)
    {
        buyer_Border.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Transparent"));
    }

    private void Choose_Button_Click(object sender, System.Windows.RoutedEventArgs e)
    {
        Buyers buyers = GetBuyersWindow();
        buyers.BuyerName = buyer_name.Content.ToString()!;
        buyers.Close();
    }

    public static Buyers GetBuyersWindow()
    {
        Buyers buyers = null!;

        foreach (Window window in Application.Current.Windows)
        {
            Type type = typeof(Buyers);
            if (window != null && window.DependencyObjectType.Name == type.Name)
            {
                buyers = (Buyers)window;
                if (buyers != null)
                {
                    break;
                }
            }
        }
        return buyers!;
    }
}
