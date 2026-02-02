using System.Data;
using Branders.Interfaces;
using Branders.Service;

namespace Branders.Controller;

public class ExcelController : IExcelController
{
    private readonly ExcelService _excelService;

    public ExcelController()
    {
        _excelService = new ExcelService();
    }
    
    public DataSet ImportExcelFile(string path)
    {
        return _excelService.ImportExcelFile(path);
    }
}