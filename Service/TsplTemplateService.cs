using System.IO;
using System.Net;

namespace Branders.Service;

public class TsplTemplateService
{
    
    public string GenerateTsplFromTemplate(string templateName, Dictionary<string, string> data)
    {
        
        string template = GetTemplate(templateName);

        foreach (var item in data)
        {
            Console.WriteLine(item);
            template = template.Replace("variable", item.Value);
        }
        
        return "";
    }

    private string GetTemplate(string templateName)
    {
        string path = @"C:\Users\Flor\RiderProjects\Branders\Branders\Labels\" + templateName + ".txt";
        return File.ReadAllText(path);
    }
}