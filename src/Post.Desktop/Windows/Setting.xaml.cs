using Post.Desktop.Pages;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Post.Desktop.Windows;

/// <summary>
/// Interaction logic for Setting.xaml
/// </summary>
public partial class Setting : Window
{
    public Setting()
    {
        InitializeComponent();
        LangCursorBorder.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("White"));
        PageNavigator.Content = new SettingLanguagePage();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        int index = int.Parse(((Button)e.Source).Uid);


        switch (index)
        {
            case 0:
                PrinterCursorBorder.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Transparent"));
                LangCursorBorder.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("White"));
                PageNavigator.Content = new SettingLanguagePage();
                break;
            case 1:
                LangCursorBorder.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Transparent"));
                PrinterCursorBorder.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("White"));
                PageNavigator.Content = new SettingPrinterPage();
                break;
        }
    }

    private void close_Click(object sender, RoutedEventArgs e)
    {
        this.Close();
    }
}