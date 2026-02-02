using System.Data;

namespace Branders.Viewmodels;

public class RowViewModel : BaseViewModel
{
    public DataRow Row { get; }
    private bool _isSelected;

    public bool IsSelected
    {
        get => _isSelected;
        set { _isSelected = value; OnPropertyChanged(); }
    }
    
    public RowViewModel(DataRow row)
    {
        Row = row;
    }
}