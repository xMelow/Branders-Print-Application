namespace Branders.Viewmodels;

public class SheetColumnViewModel : BaseViewModel
{
    public string ColumnName { get; }
    private bool _isSelected;

    public bool IsSelected
    {
        get => _isSelected;
        set
        {
            _isSelected = value;
            OnPropertyChanged();
        }
    }

    public SheetColumnViewModel(string columnName)
    {
        ColumnName = columnName;
        _isSelected = true;
    }
}
