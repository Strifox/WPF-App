using System.Collections.Generic;
using System.Threading.Tasks;
using Monster.DataAccess;
using Monster.Model.Models;

namespace Monster.UI.Data
{
    public interface INoteDataService
    {
        Task<List<Note>> GetAllNotesAsync();
        Task SaveNote(string title, string content);
    }
}