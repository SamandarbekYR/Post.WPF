using System.Windows;
using System.Windows.Controls;

namespace Post.Desktop.Pages;

/// <summary>
/// Interaction logic for SettingLanguagePage.xaml
/// </summary>
public partial class SettingLanguagePage : Page
{
    public SettingLanguagePage()
    {
        InitializeComponent();
        string culture = Post.Desktop.Properties.Settings.Default.languageCode;
        switch (culture)
        {
            case "uz":
                TBlang.Text = "O'zbek tili";
                break;
            case "en":
                TBlang.Text = "English";
                break;
            case "ru":
                TBlang.Text = "Русскый";
                break;
            case "uz-Cyrl":
                TBlang.Text = "Ўзбек-Крил";
                break;
            default:
                TBlang.Text = "O'zbek tili";
                break;
        }
    }

    private void save_Click(object sender, RoutedEventArgs e)
    {
        if (languages.SelectedIndex == 0)
        {
            Properties.Settings.Default.languageCode = "uz";
            App.ChangeCulture("uz");
            TBlang.Text = "O'zbek tili";
            Properties.Settings.Default.Save();
        }

        else if (languages.SelectedIndex == 1)
        {
            Properties.Settings.Default.languageCode = "en";
            App.ChangeCulture("en");
            TBlang.Text = "English";
            Properties.Settings.Default.Save();
        }

        else if (languages.SelectedIndex == 2)
        {
            Properties.Settings.Default.languageCode = "ru";
            App.ChangeCulture("ru");
            TBlang.Text = "Русскый";
            Properties.Settings.Default.Save();
        }

        else if (languages.SelectedIndex == 3)
        {
            Properties.Settings.Default.languageCode = "uz-Cyrl";
            App.ChangeCulture("uz-Cyrl");
            TBlang.Text = "Ўзбек-Крил";
            Properties.Settings.Default.Save();
        }
    }
}
