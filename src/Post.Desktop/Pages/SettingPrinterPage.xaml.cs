using Post.Desktop.Services;
using System.Windows;
using System.Windows.Controls;

namespace Post.Desktop.Pages;

/// <summary>
/// Interaction logic for SettingPrinterPage.xaml
/// </summary>
public partial class SettingPrinterPage : Page
{

    public string lang = Post.Desktop.Properties.Settings.Default.languageCode;
    public string message = "";
    PrintService service = new PrintService();

    public SettingPrinterPage()
    {
        InitializeComponent();
    }

    private void test_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            string selected = printers.SelectedItem.ToString()!;
            service.printerName = selected;
            service.Test();
        }
        catch (Exception)
        {
            message = lang switch
            {
                "uz" => "Tanlangan printer ishlamadi🤦‍♂️!",
                "ru" => "Выбранный принтер не работал🤦‍♂️!",
                "en" => "The selected printer did not work🤦‍♂️!",
                "uz-Cyrl" => "Танланган принтер ишламади🤦‍♂️!"
            };
            //var messageBox = new MaterialMessageBox(message, MessageType.Error, MessageButtons.Ok);
            //messageBox.ShowDialog();
        }
    }

    private void save_Click(object sender, RoutedEventArgs e)
    {
        string selected = printers.SelectedItem.ToString()!;
        service.SavePrinter(selected);
        connected.Text = selected;
    }

    private void printers_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        connected.Text = printers.SelectedItem.ToString();
    }

    private void Page_Loaded(object sender, RoutedEventArgs e)
    {
        connected.Text = service.GetSavedPrinterName();
        var list = service.ConnectedPrinters();
        printers.ItemsSource = list;
        printers.SelectedIndex = list.FindIndex(p => p == connected.Text);
    }
}
