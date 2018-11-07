using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace Monster.UI.ViewModel
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public static void OpenAndCloseWindow(Window open, Window close)
        {
            close.Close();
            open.Show();
        }
    }
}
