using System.Net.Sockets;
using System.Text;
using System.Windows;
using System.Windows.Xps.Serialization;
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
            // placeholder to not waste labels
            Console.WriteLine("Printing... "  + label.TsplContent);
            //PrintLabel(label);
        }
    }

    private void PrintLabel(Label label)
    {
        string printerFlorHostname = "PRN-Flor";
        int port = 9100;
        
        try
        {
            using (TcpClient client = new TcpClient(printerFlorHostname, port))
            {
                byte[] data = Encoding.ASCII.GetBytes(label.TsplContent);
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