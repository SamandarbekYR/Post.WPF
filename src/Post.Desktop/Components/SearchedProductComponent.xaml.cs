using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Post.Desktop.Components;

/// <summary>
/// Interaction logic for SearchedProductComponent.xaml
/// </summary>
public partial class SearchedProductComponent : UserControl
{
    public SearchedProductComponent()
    {
        InitializeComponent();
    }

    private void Border_MouseEnter(object sender, MouseEventArgs e)
    {
        product_Border.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ECECEC"));
    }

    private void Border_MouseLeave(object sender, MouseEventArgs e)
    {
        product_Border.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("White"));
    }

    private void Select_Button_Click(object sender, RoutedEventArgs e)
    {

    }
}
