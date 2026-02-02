using Branders.Domain;
using Branders.Interfaces;
using Branders.Service;

namespace Branders.Controller;

public class PrintController : IPrintController
{
    private readonly PrintService  _printService;
    
    public PrintController()
    {
        _printService = new PrintService();
    }

    public void PrintLabels(List<Label> labels)
    {
        _printService.PrintLabels(labels);
    }
}