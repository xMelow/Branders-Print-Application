using System.Net.Sockets;
using System.Text;
using System.Windows;
using Branders.Domain;

namespace Branders.Service;

public class PrintService
{
    private string printerSettings = "";
    
    public PrintService()
    {
        
    }

    public void PrintLabels(List<Label> labels)
    {
        foreach (var label in labels)
        {
            PrintLabel(label);
        }
    }

    private void PrintLabel(Label label)
    {
        string tspl = label.PrintTSPL + label.DrawTSPL;
        
        string printerFlorHostname = "PRN-Flor";
        int port = 9100;

        Console.WriteLine(tspl);

        try
        {
            using (TcpClient client = new TcpClient(printerFlorHostname, port))
            {
                byte[] data = Encoding.ASCII.GetBytes(tspl);
                var stream = client.GetStream();
                stream.Write(data, 0, data.Length);
                stream.Close();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error sending label to printer: {ex.Message}");
        }
    
    }
}