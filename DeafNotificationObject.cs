using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace RECOVER;

public abstract class DeafNotificationObject : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged = delegate { };

    private void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected virtual bool Set<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
    {
        if (Equals(field, value))
            return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}