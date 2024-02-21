using Post.Desktop.Components;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;
using static Post.Desktop.Windows.BlurWindow.BlurEffect;

namespace Post.Desktop.Windows;

/// <summary>
/// Interaction logic for ProductSearchWindow.xaml
/// </summary>
public partial class ProductSearchWindow : Window
{
    public ProductSearchWindow()
    {
        InitializeComponent();
    }

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        EnableBlur();
        for (int i = 0; i < 5; i++)
        {
            SearchedProductComponent searchedProductComponent = new SearchedProductComponent();
            stp_Products.Children.Add(searchedProductComponent);
        }
    }

    private void close_btn_Click(object sender, RoutedEventArgs e)
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
        tb_Search.FontSize = 14;
        tb_Search.Text = (string)Application.Current.Resources["Search"];
    }

    /////////////////////////////////////////////////////////////////////////////


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
