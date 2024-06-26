﻿using Post.Desktop.Components;
using Post.Desktop.Models;
using Post.Desktop.Services;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using static Post.Desktop.Components.MessageWindow;

namespace Post.Desktop.Windows;

/// <summary>
/// Interaction logic for Selling.xaml
/// </summary>
public partial class Selling : Window
{ 
    DispatcherTimer dispatcherTimer = new DispatcherTimer();
    public string lang = Post.Desktop.Properties.Settings.Default.languageCode;


    int activeTextboxIndex = 4;
    public string message = "";

    public Selling()
    {
        dispatcherTimer.Tick += DispatcherTimer_Tick;
        dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
        dispatcherTimer.Start();
        InitializeComponent();
    }

    private void DispatcherTimer_Tick(object? sender, EventArgs e)
    {
        tb_Clock.Text = DateTime.Now.ToString("hh:mm:ss tt");
        date.Text = DateTime.Now.ToLongDateString();
    }

    private void btnShutDown(object sender, RoutedEventArgs e)
    {
        lang = Post.Desktop.Properties.Settings.Default.languageCode;
        message = lang switch
        {
            "uz" => "Ilovadan chiqmoqchimisiz?",
            "ru" => "Вы хотите выйти из приложения?",
            "en" => "Are you sure exit app?",
            "uz-Cyrl" => "Иловадан чиқмоқчимисиз?"
        };
        var messageBox = new MessageWindow(message, MessageType.Confirmation, MessageButtons.YesNo);
        var result = messageBox.ShowDialog();
        if (result == true)
        {
            Application.Current.Shutdown();
        }
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

    private void Exit_Button_Click(object sender, RoutedEventArgs e)
    {
        lang = Post.Desktop.Properties.Settings.Default.languageCode;
        message = lang switch
        {
            "uz" => "Profildan chiqmoqchimisiz?",
            "ru" => "Вы хотите выйти из системы?",
            "en" => "Do you want to log out?",
            "uz-Cyrl" => "Профилдан чиқмоқчимисиз?"
        };
        var messageBox = new MessageWindow(message, MessageType.Confirmation, MessageButtons.YesNo);
        var result = messageBox.ShowDialog();
        if (result == true)
        {
            using var tokenService = new TokenService();
            tokenService.RemoveCreditionals();

            Login login = new Login();
            this.Close();
            login.ShowDialog();
        }
    }

    private void Setting_Button_Click_1(object sender, RoutedEventArgs e)
    {
        Setting setting = new Setting();
        setting.ShowDialog();
    }

    private void remove_Btn_Click(object sender, RoutedEventArgs e)
    {
        switch (activeTextboxIndex)
        {
            case 1: CutText(ref naqd); break;
            case 2: CutText(ref plastik); break;
            case 3: CutText(ref chegirma); break;
            case 4: CutText(ref barcode_input); break;
        }
    }

    private void CutText(ref TextBox textbox)
    {
        if (textbox == null || textbox.Text.Length == 0) return;
        if (textbox.Text.Length == 1)
        {
            textbox.Text = "";
            return;
        }

        textbox.Text = textbox.Text.Substring(0, textbox.Text.Length - 1);
    }

    private void buyers_Click(object sender, RoutedEventArgs e)
    {
        Buyers buyers = new Buyers();
        buyers.ShowDialog();

        if (!string.IsNullOrEmpty(buyers.BuyerName))
        {
            tb_buyer_name.Text = buyers.BuyerName; 
        }
    }

    private void nation_Button_Click(object sender, RoutedEventArgs e)
    {
        NationWindow nationWindow = new NationWindow();
        nationWindow.ShowDialog();
    }

    private void scaner_Btn_Click(object sender, RoutedEventArgs e)
    {
        barcode_input.Focus();
    }

    private void print_Btn_Click(object sender, RoutedEventArgs e)
    {

    }

    private void refresh_Btn_Click(object sender, RoutedEventArgs e)
    {
        total_Price.Text = "0";
        naqd.Text = "0";
        plastik.Text = "0";
        chegirma.Text = "0";
        barcode_input.Clear();
    }

    private void naqd_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
    {
        e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
    }

    private void naqd_TextChanged(object sender, TextChangedEventArgs e)
    {
        SetTotalPrice();
    }

    private void nation_Click(object sender, RoutedEventArgs e)
    {

    }

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        for (int i = 0; i < 20; i++)
        {
            ProductComponent component = new ProductComponent();
            stp_Product.Children.Add(component);
        }
    }

    private void return_Click(object sender, RoutedEventArgs e)
    {

    }

    private void search_Click(object sender, RoutedEventArgs e)
    {
        ProductSearchWindow productSearchWindow = new ProductSearchWindow();
        productSearchWindow.ShowDialog();
    }
}
