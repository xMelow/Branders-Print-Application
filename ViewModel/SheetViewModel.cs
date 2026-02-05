using System.Collections.ObjectModel;
using System.Data;
using System.Windows.Input;
using Branders.Controller;
using Branders.Domain;
using Branders.Viewmodels.Command;

namespace Branders.Viewmodels;

public class SheetViewModel : BaseViewModel
{
    public string Name { get; set; }
    public DataView View { get; set; }
    public ObservableCollection<SheetColumnViewModel> Columns { get; set; } = new();
    
    private PrintController _printController;
    private LabelController _labelController;
    
    public ICommand SheetPrintAllCommand { get; }
    public ICommand SheetPrintSelectedCommand { get; }

    public SheetViewModel(DataTable dataTable)
    {
        Name = dataTable.TableName;
        View = new DataView(dataTable);

        foreach (DataColumn column in dataTable.Columns)
        {
            Columns.Add(new SheetColumnViewModel(column.ColumnName));
        }
        _printController = new PrintController();
        _labelController = new LabelController();

        SheetPrintAllCommand = new RelayCommand(PrintAllCommand);
        SheetPrintSelectedCommand = new RelayCommand(PrintSelectedCommand);
    }

    private void PrintAllCommand()
    {
        Dictionary<string, List<string>> data = new Dictionary<string, List<string>>
        {
            { Name, GetExcelData() }
        };
        List<Label> labels = _labelController.CreateLabels(data);
        
        _printController.PrintLabels(labels);
    }

    private void PrintSelectedCommand()
    {
        Dictionary<string, List<string>> data = new Dictionary<string, List<string>>
        {
            { Name, new List<string> {"DF", "Testing", "Flor"} }
        };
        
        List<Label> labels = _labelController.CreateLabels(data);
        
        _printController.PrintLabels(labels);
    }

    private List<string> GetExcelData()
    {
        List<string> data = new List<string>();

        Console.WriteLine(View.Table.Columns);

        // foreach (string labelData in excelDataList)
        // {
        //     data.Add(labelData);
        // }
        
        return data;
    }
}