using Branders.Domain;
using Branders.Interfaces;
using Branders.Service;

namespace Branders.Controller;

public class LabelController : ILabelController
{
    private readonly LabelService _labelService;
    
    public LabelController()
    {
        _labelService = new LabelService();
    }

    public List<Label> CreateLabels(Dictionary<string, string> data)
    {
        return _labelService.CreateLabels(data);
    }
}