using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Post.Desktop.Components;

/// <summary>
/// Interaction logic for ProductComponent.xaml
/// </summary>
public partial class ProductComponent : UserControl
{
    public ProductComponent()
    {
        InitializeComponent();
    }
    private void Border_MouseEnter(object sender, MouseEventArgs e)
    {
        product_Border.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ECECEC"));
    }

    private void Border_MouseLeave(object sender, MouseEventArgs e)
    {
        product_Border.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Transparent"));
    }

    private void Delete_Button_Click(object sender, System.Windows.RoutedEventArgs e)
    {

    }
}
