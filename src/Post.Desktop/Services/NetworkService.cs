using System.Net.NetworkInformation;

namespace Post.Desktop.Services;

internal static class NetworkService
{
    public static bool IsConnected()
    {
        try
        {
            using (var ping = new Ping())
            {
                var result = ping.Send("www.google.com");
                return (result.Status == IPStatus.Success);
            }
        }
        catch
        {
            return false;
        }
    }
}
