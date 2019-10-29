using System;
using System.Collections.Generic;
using System.Linq;

namespace Backend
{
    public partial class Records
    {
        public Records()
        {
            Comments = new HashSet<Comments>();
        }
        private Records(long id, string title, string text, string email, string time, int commentsNr)
        {
            Id = id;
            Title = title;
            Text = text;
            Email = email;
            Time = time;
            CommentsNr = commentsNr;
        }

        public long Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string Email { get; set; }
        public string Time { get; set; }
        public long? CommentsNr { get; set; }


        public virtual ICollection<Comments> Comments { get; set; }

        public static List<Records> ConvertList(List<Records> records)
        {
            var list = new List<Records>();
            foreach (var item in records)
            {
                list.Add(new Records(item.Id, item.Title, item.Text, item.Email, item.Time,
                item.Comments.Count));//.Select(x => new List<Comments>(x.Email, x.Id, x.Text, x.Time, x.FkRecord))));
            }
            return list;
        }
    }
}
