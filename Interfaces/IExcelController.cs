using System.Data;

namespace Branders.Interfaces;

public interface IExcelController
{
    DataSet ImportExcelFile(string path);
}