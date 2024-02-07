using System.Windows;

namespace Post.Desktop.Windows;

/// <summary>
/// Interaction logic for Login.xaml
/// </summary>
public partial class Login : Window
{
    public Login()
    {
        InitializeComponent();
    }

    private void btnShutDown(object sender, RoutedEventArgs e)
    {
        this.Close();
    }

    private void btnShowBtn(object sender, RoutedEventArgs e)
    {
        Console.WriteLine("d");
    }
}
