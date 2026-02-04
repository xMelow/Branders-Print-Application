using Branders.Domain;

namespace Branders.Interfaces;

public interface ILabelController
{
    List<Label> CreateLabels(Dictionary<string, List<string>> data);
}