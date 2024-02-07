using System.Windows;

namespace Post.Desktop.Windows;

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
