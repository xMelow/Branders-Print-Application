using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Branders.Viewmodels;

public class RowItem : INotifyPropertyChanged
{
    private bool _isChecked;
    public string Name { get; set; }
    public bool IsChecked
    {
        get => _isChecked;
        set
        {
            if (_isChecked != value)
            {
                _isChecked = value;
                OnPropertyChanged();
            }
        }
    }
    
    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string name = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    } 
}