using Branders.Domain;

namespace Branders.Interfaces;

public interface IPrintController
{
    void PrintLabels(List<Label> labels);
}