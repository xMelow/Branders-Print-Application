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
        foreach (var item in data)
        {
            foreach (var labelData in item.Value)
            {
                string tspl = _templateService.GenerateTsplFromTemplate(item.Key, labelData);
                labels.Add(new Label(tspl));
            }
        }
        return labels;
    }
}