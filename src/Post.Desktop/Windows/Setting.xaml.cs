using Post.Desktop.Pages;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;
using System.Windows.Media;
using static Post.Desktop.Windows.BlurWindow.BlurEffect;

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

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        EnableBlur();
    }

    ////////////////////////////////////////////////////////////////

    [DllImport("user32.dll")]
    internal static extern int SetWindowCompositionAttribute(IntPtr hwnd, ref WindowCompositionAttributeData data);
    internal void EnableBlur()
    {
        var windowHelper = new WindowInteropHelper(this);

        var accent = new AccentPolicy();
        accent.AccentState = AccentState.ACCENT_ENABLE_BLURBEHIND;

        var accentStructSize = Marshal.SizeOf(accent);

        var accentPtr = Marshal.AllocHGlobal(accentStructSize);
        Marshal.StructureToPtr(accent, accentPtr, false);

        var data = new WindowCompositionAttributeData();
        data.Attribute = WindowCompositionAttribute.WCA_ACCENT_POLICY;
        data.SizeOfData = accentStructSize;
        data.Data = accentPtr;

        SetWindowCompositionAttribute(windowHelper.Handle, ref data);

        Marshal.FreeHGlobal(accentPtr);
    }
}