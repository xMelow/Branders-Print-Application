using Branders.Domain;

namespace Branders.Service;

public class LabelService
{
    private readonly TsplTemplateService _templateService;
    
    public LabelService()
    {
        _templateService = new TsplTemplateService();
    }

    public List<Label> CreateLabels(Dictionary<string, List<string>> data)
    {
        List<Label> labels = new List<Label>();

        for (int i = 0; i < data.Values.Count; i++)
        {
            string tspl = _templateService.GenerateTsplFromTemplate(data);
            labels.Add(new Label(tspl));
        }
        Console.WriteLine(labels);
        return labels;
    }
}