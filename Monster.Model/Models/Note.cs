using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monster.Model.Models
{
    public class Note
    {
        public int Id { get; set; }
        public int LoggedInAccountId { get; set; } = Globals.LoggedInUser.Id;
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime NoteDateTime { get; set; } = DateTime.Now;

        public virtual Account Account { get; set; }

        public Note(string title, string content)
        {
            Title = title;
            Content = content;
        }

        public Note()
        {

        }
    }
}
