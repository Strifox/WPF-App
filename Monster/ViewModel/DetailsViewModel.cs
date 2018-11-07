using Autofac;
using Monster.Model.Models;
using Monster.UI.Data;
using Monster.UI.Startup;
using Monster.UI.View;
using Monster.UI.ViewModel.Commands;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Monster.UI.ViewModel
{
    public class DetailsViewModel : ViewModelBase
    {
        #region Commands

        public ICommand SaveNoteCommand => new CommandHandler(() => { SaveNoteAsync(); });
        public ICommand DeleteNoteCommand => new CommandHandler(() => { DeleteNoteAsync(); });

        #endregion


        #region Note

        private readonly INoteDataService _noteDataService;
        public ObservableCollection<Note> Notes { get; set; }


        public string Title { get; set; }
        public string Content { get; set; }

        #endregion

        #region Constructor

        public DetailsViewModel()
        {

        }

        public DetailsViewModel(INoteDataService noteDataService)
        {
            Notes = new ObservableCollection<Note>();
            _noteDataService = noteDataService;
        }

        #endregion

        private Note _selectedNote;
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

        public async void SaveNoteAsync()
        {
            if (!string.IsNullOrEmpty(Title) && !string.IsNullOrWhiteSpace(Title) && !string.IsNullOrEmpty(Content) && !string.IsNullOrWhiteSpace(Content))
                await _noteDataService.SaveNoteAsync(Title, Content);

            LoadNoteAsync();
        }

        public async void LoadNoteAsync()
        {
            var notes = await _noteDataService.GetAllNotesAsync(Globals.LoggedInUser.Id);
            Notes.Clear();
            foreach (var note in notes)
            {
                Notes.Add(note);
            }
        }

        public async void DeleteNoteAsync()
        {
            if (_selectedNote == null)
                return;

            await _noteDataService.DeleteNoteAsync(_selectedNote);
            LoadNoteAsync();
        }
    }
}
