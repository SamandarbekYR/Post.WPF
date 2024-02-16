using Post.Desktop.Models;
using System.Windows;
using System.Windows.Controls;

namespace Post.Desktop.Windows;

/// <summary>
/// Interaction logic for Selling.xaml
/// </summary>
public partial class Selling : Window
{
    int activeTextboxIndex = 0;
    public Selling()
    {
        InitializeComponent();
    }

    private void btnShutDown(object sender, RoutedEventArgs e)
    {
        this.Close();
    }

    private void SetTotalPrice()
    {
        //if (vm != null)
        //{
        //    var totalPrice = vm.Transactions.Sum(tr => tr.TotalPrice);
        //    if (!string.IsNullOrEmpty(chegirma.Text))
        //    {
        //        totalPrice -= decimal.Parse(chegirma.Text.Replace(" ", ""));
        //    }
        //    if (totalPrice > 0)
        //    {
        //        total.Text = totalPrice.ToString().ToMoneyFormat();
        //    }
        //    else
        //    {
        //        total.Text = "0";
        //    }
        //}
    }

    private void WriteNumberToTextbox(string number)
    {
        switch (activeTextboxIndex)
        {
            case 1:
                {
                    naqd.Text = naqd.Text.ToMoneyFormat();
                }
                break;
            case 2:
                {
                    plastik.Text = plastik.Text.ToMoneyFormat();
                }
                break;
            case 3:
                {
                    chegirma.Text = chegirma.Text.ToMoneyFormat();
                }
                break;
            case 4:
                {
                    barcode_input.Text += number;
                }
                break;
        }
        SetTotalPrice();
    }

    private void Numbers_Button_Click(object sender, RoutedEventArgs e)
    {
        var button = (Button)sender;
        WriteNumberToTextbox(button.Content.ToString() ?? "");
    }

    private void tb_Gotfokus(object sender, RoutedEventArgs e)
    {
        activeTextboxIndex = int.Parse(((TextBox)sender).Uid);
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {

    }

    private void Exit_Button_Click(object sender, RoutedEventArgs e)
    {
        
    }

    private void Button_Click_1(object sender, RoutedEventArgs e)
    {

    }

    private void Setting_Button_Click_1(object sender, RoutedEventArgs e)
    {
        Setting setting = new Setting();
        Application.Current.MainWindow.Opacity = 0.9;
        setting.ShowDialog();
        Application.Current.MainWindow.Opacity = 1;
    }
}
