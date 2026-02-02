using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Branders.Viewmodels;

public class BaseViewModel
{
    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string prop = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}