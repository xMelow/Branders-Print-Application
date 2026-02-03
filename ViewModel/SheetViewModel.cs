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
    public ICommand SelectAllColumnsCommand { get; }
    private bool _allSelected = true;
    public bool AllSelected
    {
        get => _allSelected;
        set
        {
            if (_allSelected != value)
            {
                _allSelected = value;
                OnPropertyChanged();
                SetAllColumns(value);
            }
        }
    }

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

        SelectAllColumnsCommand = new RelayCommand(ToggleSelectAll);
        SheetPrintAllCommand = new RelayCommand(PrintAllCommand);
        SheetPrintSelectedCommand = new RelayCommand(PrintSelectedCommand);
    }

    private void ToggleSelectAll()
    {
        AllSelected = !AllSelected;
    }

    private void SetAllColumns(bool select)
    {
        foreach (var col in Columns)
        {
            col.IsSelected = select;
        }
    }

    private void PrintAllCommand()
    {
        Console.WriteLine($"Button clicked for sheet {Name} Print all");

        Dictionary<string, string> data = new Dictionary<string, string>();
        List<Label> labels = _labelController.CreateLabels(data);
        
        _printController.PrintLabels(labels);
    }

    private void PrintSelectedCommand()
    {
        // Todo: Get excel data form tables
        Dictionary<string, string> data = new Dictionary<string, string>
        {
            { Name , "DF"},
        };
        List<Label> labels = _labelController.CreateLabels(data);
        Console.WriteLine("labels: " + labels.Count);
        
        _printController.PrintLabels(labels);
    }
}