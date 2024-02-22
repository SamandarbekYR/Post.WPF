using Post.Desktop.Services;
using Post.Desktop.Windows;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using static Post.Desktop.Components.MessageWindow;

namespace Post.Desktop.Components;

/// <summary>
/// Interaction logic for ProductComponent.xaml
/// </summary>
public partial class ProductComponent : UserControl
{
    public ProductComponent()
    {
        InitializeComponent();
    }

    private void UserControl_Loaded(object sender, RoutedEventArgs e)
    {
        SetData();
    }
    private void Border_MouseEnter(object sender, MouseEventArgs e)
    {
        product_Border.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ECECEC"));
    }

    private void Border_MouseLeave(object sender, MouseEventArgs e)
    {
        product_Border.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Transparent"));
    }

    public void SetData()
    {
        total_price.Content = decimal.Parse(product_price.Content.ToString()!) * int.Parse(product_Count.Text);
    }
     
    public void Calculate(string productPrice, string productQuantity)
    {
        decimal price = decimal.Parse(productPrice);
        decimal quantity = decimal.Parse(productQuantity);

        decimal totalPrice = price * quantity;

        total_price.Content = totalPrice.ToString();
    }

    private void Delete_Button_Click(object sender, System.Windows.RoutedEventArgs e)
    {
        string lang = Post.Desktop.Properties.Settings.Default.languageCode;
        string message = lang switch
        {
            "uz" => "Ushbu maxsulot o'chirisinmi?",
            "ru" => "Удалить этот продукт?",
            "en" => "Delete this product?",
            "uz-Cyrl" => "Ушбу махсулот у́чирилсинми?"
        };
        var messageBox = new MessageWindow(message, MessageType.Confirmation, MessageButtons.YesNo);
        var result = messageBox.ShowDialog();
        if (result == true)
        {
            Selling selling = GetSellingWindow();
            selling.stp_Product.Children.Remove(this);
        }
        
    }

    private void plus_btn_Click(object sender, System.Windows.RoutedEventArgs e)
    {
        int count = int.Parse(product_Count.Text);
        count++;
        product_Count.Text = count.ToString();
        Calculate(product_price.Content.ToString()!, product_Count.Text);
    }

    private void minus_btn_Click(object sender, System.Windows.RoutedEventArgs e)
    {
        int count = int.Parse(product_Count.Text);
        if (count > 1)
        {
            count--;
            product_Count.Text = count.ToString();
            Calculate(product_price.Content.ToString()!, product_Count.Text);
        }
    }

    public static Selling GetSellingWindow()
    {
        Selling selling = null!;

        foreach (Window window in Application.Current.Windows)
        {
            Type type = typeof(Selling);
            if (window != null && window.DependencyObjectType.Name == type.Name)
            {
                selling = (Selling)window;
                if (selling != null)
                {
                    break;
                }
            }
        }
        return selling!;
    }

}
