using System.Collections.ObjectModel;
using System.Data;
using System.Windows.Controls;
using System.Windows.Input;
using Branders.Controller;
using Branders.Viewmodels.Command;
using Label = Branders.Domain.Label;

namespace Branders.Viewmodels;

public class SheetViewModel : BaseViewModel
{
    public string Name { get; set; }
    public DataView View { get; set; }
    public ObservableCollection<SheetColumnViewModel> Columns { get; set; } = new();
    // public ObservableCollection<string> Columns { get; set; } = new();

    private SheetColumnViewModel _selectedColumn;

    public SheetColumnViewModel SelectedColumn
    {
        get => _selectedColumn;
        set
        {
            _selectedColumn = value;
            OnPropertyChanged(nameof(SelectedColumn));
        }
    }

    private PrintController _printController;
    private LabelController _labelController;
    
    public ICommand PrintAll { get; }
    public ICommand PrintSelected { get; }

    public SheetViewModel(DataTable dataTable)
    {
        Name = dataTable.TableName;
    
        if (!dataTable.Columns.Contains("IsSelected"))
        {
            DataColumn selectColumn = new DataColumn("IsSelected", typeof(bool));
            selectColumn.DefaultValue = false;
            dataTable.Columns.Add(selectColumn);
            selectColumn.SetOrdinal(0);
        }
        View = new DataView(dataTable);

        foreach (DataColumn column in dataTable.Columns)
        {
            if (column.ColumnName != "IsSelected")
            {
                Columns.Add(new SheetColumnViewModel(column.ColumnName));
            }
        }
        _printController = new PrintController();
        _labelController = new LabelController();

        PrintAll = new RelayCommand(PrintAllCommand);
        PrintSelected = new RelayCommand(PrintSelectedCommand);
    }

    private void PrintAllCommand()
    {
        Dictionary<string, List<string>> data = new Dictionary<string, List<string>>
        {
            { Name, GetExcelDataFromColumn() }
        };
        List<Label> labels = _labelController.CreateLabels(data);
        _printController.PrintLabels(labels);
    }

    private void PrintSelectedCommand()
    {
        Dictionary<string, List<string>> data = new Dictionary<string, List<string>>
        {
            // { Name, GetExcelDataFromSelectedItems() }
        };
        List<Label> labels = _labelController.CreateLabels(data);
        _printController.PrintLabels(labels);
    }

    private List<string> GetExcelDataFromColumn()
    {
        List<string> data = new List<string>();
        
        if (View.Table.Columns.Contains(SelectedColumn.ColumnName))
        {
            foreach (DataRowView dataRowView in View)
            {
                data.Add(dataRowView[SelectedColumn.ColumnName]?.ToString() ?? string.Empty);
            }
        }
        return data;
    }

    private List<string> GetExcelDataFromSelectedItems(DataGrid dataGrid)
    {
        List<string> data = new List<string>();

        foreach (DataRowView rowView in View)
        {
            Console.WriteLine(rowView);
        }
        return data;
    }
}