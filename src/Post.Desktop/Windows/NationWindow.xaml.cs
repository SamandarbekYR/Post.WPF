using Post.Desktop.Components;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;
using static Post.Desktop.Windows.BlurWindow.BlurEffect;

namespace Post.Desktop.Windows;

/// <summary>
/// Interaction logic for NationWindow.xaml
/// </summary>
public partial class NationWindow : Window
{
    public NationWindow()
    {
        InitializeComponent();
    }
    private void close_Button_Click(object sender, RoutedEventArgs e)
    {
        this.Close();
    }

    private void TextBox_GotFocus(object sender, RoutedEventArgs e)
    {
        search_Border.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#00559A"));
        tb_Search.Text = "";
        tb_Search.Foreground = Brushes.Black;
        tb_Search.FontSize = 18;
    }
    private void tb_Search_LostFocus(object sender, RoutedEventArgs e)
    {
        search_Border.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Black"));
        tb_Search.Foreground = Brushes.Gray;
        tb_Search.FontSize = 15;
        tb_Search.Text = "Search...";
    }

    private void new_customer_Click(object sender, RoutedEventArgs e)
    {

    }

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        EnableBlur();
        for (int i = 0; i < 20; i++)
        {
            NationBuyerCmponent nationBuyerCmponent = new NationBuyerCmponent();
            stp_Buyers.Children.Add(nationBuyerCmponent);
        }
    }

    //////////////////////////////////////////////////////////////////////////////

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
