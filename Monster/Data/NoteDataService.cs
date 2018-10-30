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
        private AccountContext context = new AccountContext();

        public NoteDataService(Func<AccountContext> contextCreator) => _contextCreator = contextCreator;

        public async Task<List<Note>> GetAllNotesAsync()
        {
            using (var context = _contextCreator())
            {
                return await context.Notes.AsNoTracking().ToListAsync();
            }
        }

        //public IEnumerable<Note> GetAll()
        //{
        //    using (var context = _contextCreator())
        //    {
        //        return context.Notes.AsNoTracking().ToList();
        //    }
        //}

        public async Task SaveNote(string title, string content)
        {
            Note note = new Note(title, content);
            context.Notes.Add(note);
            await context.SaveChangesAsync();
        }
    }
}
