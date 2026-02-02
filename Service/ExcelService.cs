using System.Data;
using System.IO;
using System.Text;
using ExcelDataReader;

namespace Branders.Service;

public class ExcelService
{
    public DataSet ImportExcelFile(string filePath)
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

        using var stream = File.Open(filePath, FileMode.Open, FileAccess.Read);
        using var reader = ExcelReaderFactory.CreateReader(stream);

        var result = reader.AsDataSet(new ExcelDataSetConfiguration()
        {
            ConfigureDataTable = _ => new ExcelDataTableConfiguration
            {
                UseHeaderRow = true
            }
        });
        
        if (result == null) 
            throw new InvalidOperationException("Could not load excel file");

        return result;
    }
}