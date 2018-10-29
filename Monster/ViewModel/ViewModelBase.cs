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

        /// <summary>
        /// Close one window and opens new window
        /// </summary>
        ///  <param name="open"> Type in what window to open </paramref>
        ///  <param name="close">Type in what window to close</param>
        public static void OpenAndCloseWindow(Window open, Window close)
        {
            close.Close();
            open.Show();
        }

    }
}
