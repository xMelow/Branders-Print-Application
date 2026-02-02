using System.Collections.ObjectModel;
using System.Data;
using System.Windows.Input;
using Branders.Interfaces;
using Branders.Viewmodels.Command;
using Microsoft.Win32;

namespace Branders.Viewmodels;

public class MainWindowViewModel : BaseViewModel
{
    private readonly IExcelController _excelController;
    public ICommand ImportExcelCommand { get; }
    public ObservableCollection<SheetViewModel> Sheets { get; } = new();
    
    private DataTable? _selectedSheet { get; set; }
    public DataTable? SelectedSheet
    {
        get => _selectedSheet;
        set { 
            _selectedSheet = value; 
            OnPropertyChanged(); 
        }
    }

    public MainWindowViewModel(
        IExcelController excelController
    ) {
        _excelController = excelController;
        ImportExcelCommand = new RelayCommand(ImportExcelFile);
    }

    private void ImportExcelFile()
    {
        var path = GetExcelFilePath();
        if (string.IsNullOrEmpty(path)) return;
        
        var dataSet = _excelController.ImportExcelFile(path);
        
        Sheets.Clear();
        
        foreach (DataTable table in dataSet.Tables)
        {
            // assign data to column 
            Sheets.Add(new SheetViewModel(table));
        }

        // _selectedSheet.Columns.Add("IsSelected", typeof(bool));
    }

    private string GetExcelFilePath()
    {
        var dialog = new OpenFileDialog()
        {
            Filter = "Excel Files|*.xlsx; *.xls",
        };
        return dialog.ShowDialog() == true ? dialog.FileName : "";
    }
}