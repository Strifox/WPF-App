using Monster.DataAccess;
using Monster.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monster.UI.Data
{
    public class NoteDataService : INoteDataService
    {
        private readonly Func<AccountContext> _contextCreator;

        public NoteDataService(Func<AccountContext> contextCreator) => _contextCreator = contextCreator;

        public async Task<List<Note>> GetAllNotesAsync(int id)
        {
            using (var context = _contextCreator())
            {
                return await context.Notes.Where(x => x.LoggedInAccountId == id).ToListAsync();
            }
        }

        public async Task SaveNoteAsync(string title, string content)
        {
            using (var context = _contextCreator())
            {
                Note note = new Note(title, content);
                context.Notes.Add(note);
                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteNoteAsync(Note selectedNote)
        {
            using(var context = _contextCreator())
            {
                context.Notes.Attach(selectedNote);
                context.Notes.Remove(selectedNote);
                await context.SaveChangesAsync();
            }
        }

    }
}
