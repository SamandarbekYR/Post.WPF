using Haley.Utils;
using System.Windows;

namespace Post.Desktop;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        LangUtils.Register();
        ChangeCulture("uz");
        base.OnStartup(e);
    }

    public static void ChangeCulture(string code)
    {

        ResourceDictionary dict = new ResourceDictionary();
        string culture = Post.Desktop.Properties.Settings.Default.languageCode;
        switch (culture)
        {
            case "uz":
                dict.Source = new Uri("Languages/LangUzb.xaml", UriKind.RelativeOrAbsolute);
                break;
            case "en":
                dict.Source = new Uri("Languages/LangEng.xaml", UriKind.RelativeOrAbsolute);
                break;
            case "ru":
                dict.Source = new Uri("Languages/LangRus.xaml", UriKind.RelativeOrAbsolute);
                break;
            case "uz-Cyrl":
                dict.Source = new Uri("Languages/LangUzb-Kril.xaml", UriKind.RelativeOrAbsolute);
                break;
            default:
                dict.Source = new Uri("Languages/LangUzb.xaml", UriKind.RelativeOrAbsolute);
                break;
        }
        Application.Current.Resources.MergedDictionaries.Add(dict);
    }
}
