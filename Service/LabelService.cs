using Branders.Domain;

namespace Branders.Service;

public class LabelService
{
    public LabelService()
    {
        
    }

    public List<Label> CreateLabels(Dictionary<string, string> data)
    {
        List<Label> labels = new List<Label>();
        
        foreach (string key in data.Keys)
        {
            labels.Add(new Label(key, data[key]));
        }
        return labels;
    }
}