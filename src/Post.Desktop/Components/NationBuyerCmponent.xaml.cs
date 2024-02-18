using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Post.Desktop.Components;

/// <summary>
/// Interaction logic for NationBuyerCmponent.xaml
/// </summary>
public partial class NationBuyerCmponent : UserControl
{
    public NationBuyerCmponent()
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

    private void Payment_Button_Click(object sender, System.Windows.RoutedEventArgs e)
    {

    }
}
