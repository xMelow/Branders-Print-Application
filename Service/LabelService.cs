using Branders.Domain;

namespace Branders.Service;

public class LabelService
{
    private readonly TsplTemplateService _templateService;
    
    public LabelService()
    {
        _templateService = new TsplTemplateService();
    }

    public List<Label> CreateLabels(Dictionary<string, string> data)
    {
        List<Label> labels = new List<Label>();
        
        foreach (string value in data.Values)
        {
            string tspl = _templateService.GenerateTsplFromTemplate("I015163", data);
            Console.WriteLine(tspl);
            labels.Add(new Label(tspl));
        }
        return labels;
    }
}