using System.IO;
using System.Net;
using System.Text.RegularExpressions;

namespace Branders.Service;

public class TsplTemplateService
{
    public string GenerateTsplFromTemplate(string sheetName, string labelData)
    {
        string template = GetTemplate(sheetName);
        return template.Replace("variable", labelData);
    }

    private string GetTemplate(string sheetName)
    {
        string templateName = GetTemplateFromSheet(sheetName);
        string path = @"C:\Users\Flor\RiderProjects\Branders\Branders\Labels\" + templateName + ".txt";
        return File.ReadAllText(path);
    }

    private string GetTemplateFromSheet(string sheetName)
    {
        switch (sheetName)
        {
            case "Sheet1":
                return "TODO";
            case "Sheet2":
                return "TODO";
            case "Sheet3":
                return "I019532";
            case "Sheet4":
                return "I019184";
            case "Sheet5":
                return "I019181";
            case "Sheet6":
                return "I020451";
            case "Sheet7":
                return "TODO";
            case "Sheet8":
                return "I015163";
            case "Sheet9":
                return "I019451";
        }
        return "not found";
    }
}