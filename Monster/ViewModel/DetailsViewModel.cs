using Autofac;
using Monster.Model.Models;
using Monster.UI.Data;
using Monster.UI.Startup;
using Monster.UI.View;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Monster.UI.ViewModel
{
    public class DetailsViewModel : ViewModelBase
    {
        private readonly INoteDataService _noteDataService;
        private Note _selectedNote;
        public ObservableCollection<Note> Notes { get; set; }


        public Note SelectedNote
        {
            get { return _selectedNote; }
            set
            {
                _selectedNote = value;
                OnPropertyChanged();
            }
        }

        public static void ShowDetailsWindow()
        {
            var bootstrapper = new Bootstrapper();
            var container = bootstrapper.Bootstrap();

            var detailswindow = container.Resolve<DetailsWindow>();
            detailswindow.Show();
        }

        public DetailsViewModel(INoteDataService noteDataService)
        {
            Notes = new ObservableCollection<Note>();
            _noteDataService = noteDataService;
        }

        public async Task LoadAsync()
        {
            var notes = await _noteDataService.GetAllNotesAsync();
            Notes.Clear();
            foreach (var note in notes)
            {
                Notes.Add(note);
            }

        }

    }
}
