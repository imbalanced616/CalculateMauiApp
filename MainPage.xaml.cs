using static System.Net.Mime.MediaTypeNames;
using System.Data.SqlTypes;

namespace CalculateMauiApp;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}
    private void ButtonProc_Clicked(object sender, EventArgs e)
    {
        string s = txtCalc.Text;

        char[] operat = { '+', '-', '*', '/' };

        if (s.Contains('+') || s.Contains('-') || s.Contains('*') || s.Contains('/'))
        {
            var data = s.Split(operat, StringSplitOptions.None);
            double arg1 = double.Parse(data[0]);
            double arg2 = double.Parse(data[1]);
            double percent = arg1 * arg2 / 100;
            txtCalc.Text = s.Replace(arg2.ToString(), percent.ToString());
        }
        else DisplayAlert("Уведомление!", "Введите действие, например: \"+\", \"-\", \"*\" или \"/\".", "OK");
    }
    private void ButtonClear_Clicked(object sender, EventArgs e)
    {
        txtCalc.Text = "0";
    }
    private void ButtonClearOne_Clicked(object sender, EventArgs e)
    {
        if (txtCalc.Text.Length > 1) txtCalc.Text = txtCalc.Text.Remove(txtCalc.Text.Length - 1);
        else txtCalc.Text = "0";
    }
    private void ButtonNumbers_Clicked(object sender, EventArgs e)
    {
        Button b = (Button)sender;
        string s = (string)b.Text;
        if (txtCalc.Text == "0" || txtCalc.Text == "∞") txtCalc.Text = s;
        else txtCalc.Text += s;
    }
    private void ButtonZap_Clicked(object sender, EventArgs e)
    {
        txtCalc.Text += ",";
    }
    private void ButtonPlusMinus_Clicked(object sender, EventArgs e)
    {
        if (txtCalc.Text != "0" && txtCalc.Text[..1] != "-") txtCalc.Text = txtCalc.Text.Insert(0, "-");
        else if (txtCalc.Text[..1] == "-") txtCalc.Text = txtCalc.Text[..1].Replace("-", txtCalc.Text[1..]);
    }
    private void ButtonPlus_Clicked(object sender, EventArgs e)
    {
        string str = txtCalc.Text;
        if (str == "0") txtCalc.Text = "0";
        else if (str.Contains('+') == false && str.Contains('-') == false && str.Contains('*') == false && str.Contains('/') == false) txtCalc.Text += "+";
    }
    private void ButtonMinus_Clicked(object sender, EventArgs e)
    {
        string str = txtCalc.Text;
        if (str == "0") txtCalc.Text = "0";
        else if (str.Contains('+') == false && str.Contains('-') == false && str.Contains('*') == false && str.Contains('/') == false) txtCalc.Text += "-";
    }
    private void ButtonUmn_Clicked(object sender, EventArgs e)
    {
        string str = txtCalc.Text;
        if (str == "0") txtCalc.Text = "0";
        else if (str.Contains('+') == false && str.Contains('-') == false && str.Contains('*') == false && str.Contains('/') == false) txtCalc.Text += "*";
    }
    private void ButtonDelen_Clicked(object sender, EventArgs e)
    {
        string str = txtCalc.Text;
        if (str == "0") txtCalc.Text = "0";
        else if (str.Contains('+') == false && str.Contains('-') == false && str.Contains('*') == false && str.Contains('/') == false) txtCalc.Text += "/";
    }
    private void ButtonOneDelenX_Clicked(object sender, EventArgs e)
    {
        double str = double.Parse(txtCalc.Text);
        if (str == 0) txtCalc.Text = "0";
        else txtCalc.Text = Math.Round(1/str, 5).ToString();
    }
    private void ButtonStep_Clicked(object sender, EventArgs e)
    {
        double str = double.Parse(txtCalc.Text);
        if (str == 0) txtCalc.Text = "0";
        else txtCalc.Text = Math.Pow(2, str).ToString();
    }
    private void ButtonKor_Clicked(object sender, EventArgs e)
    {
        double str = double.Parse(txtCalc.Text);
        if (str == 0) txtCalc.Text = "0";
        else
        {
            if (txtCalc.Text[..1] == "-") DisplayAlert("Уведомление!", "Исходное значение было отрицательным, поэтому корень из этого числа вычислить не получилось!", "OK");
            else
            {
                double result = Math.Round(Math.Sqrt(str), 5);
                txtCalc.Text = result.ToString();
            }
        }
    }
    private void ButtonRavno_Clicked(object sender, EventArgs e)
    {
        try
        {
            string s = txtCalc.Text;

            char[] operat = { '+', '-', '*', '/' };

            if (s.Contains('+') ||  s.Contains('-') || s.Contains('*') || s.Contains('/')) 
            {
                var data = s.Split(operat, StringSplitOptions.None);
                double arg1 = double.Parse(data[0]);
                double arg2 = double.Parse(data[1]);

                if (s.Contains('-')) txtCalc.Text = Math.Round(arg1 - arg2).ToString();
                else if (s.Contains('+')) txtCalc.Text = Math.Round(arg1 + arg2).ToString();
                else if (s.Contains('*')) txtCalc.Text = Math.Round(arg1 * arg2).ToString();
                else txtCalc.Text = Math.Round(arg1 / arg2, 5).ToString();
            }
            else DisplayAlert("Уведомление!", "Введите действие, например: \"+\", \"-\", \"*\" или \"/\".", "OK");
        }
        catch (Exception ex)
        {
            DisplayAlert("Ошибка!", ex.ToString(), "OK");
            txtCalc.Text = "0";
        }
    }
}
