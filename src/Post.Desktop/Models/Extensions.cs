namespace Post.Desktop.Models;

public static class Extensions
{
    public static string ToMoneyFormat(this string text)
    {
        if (text == null)
            return string.Empty;

        if (text.Length < 3)
            return text;



        return double.Parse(text.Replace(" ", ""))
                       .ToString("C").Replace("$", "")
                       .Replace(",", " ")
                       .Split('.')[0];
    }

    private static string Reverse(string text)
    {
        string reversed = string.Empty;
        foreach (char c in text.Reverse())
        {
            reversed += c;
        }

        return reversed;
    }
}
