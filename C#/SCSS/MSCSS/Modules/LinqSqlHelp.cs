using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maxz.PoemSystem.Engine.Modules
{
    public static class LinqSqlHelp
    {
        private static string _currentConnection;

        public static string CurrentConnection
        {
            get
            {
                if (string.IsNullOrEmpty(_currentConnection))
                {
                    _currentConnection = Properties.Settings.Default.POEMDBConnectionString;
                }
                return _currentConnection;
            }
            set
            {
                _currentConnection = value;
            }
        }



        public static void AddBookIndex(IEnumerable<M_BookIndex> entities)
        {
            using (PoemDBDataContext context = new PoemDBDataContext(CurrentConnection))
            {
                context.M_BookIndex.InsertAllOnSubmit(entities);
                context.SubmitChanges();
            }
        }

        public static void AddPoem2(M_Poem2 poem)
        {
            using (PoemDBDataContext context = new PoemDBDataContext(CurrentConnection))
            {
                context.M_Poem2.InsertOnSubmit(poem);
                context.SubmitChanges();
            }
        }


        public static void AddPoem2(List<M_Poem2> poems, List<M_PoemImage> images)
        {
            using (PoemDBDataContext context = new PoemDBDataContext(CurrentConnection))
            {
                context.M_Poem2.InsertAllOnSubmit(poems);
                if (images.Count > 0)
                {
                    context.M_PoemImage.InsertAllOnSubmit(images);
                }
                context.SubmitChanges();
            }
        }


        public static void AddPoems(List<M_Poem> entities)
        {
            using (PoemDBDataContext context = new PoemDBDataContext(CurrentConnection))
            {
                context.M_Poem.InsertAllOnSubmit(entities);
                context.SubmitChanges();
            }
        }

        public static List<M_Author> GetAllAuthor()
        {
            using (PoemDBDataContext context = new PoemDBDataContext(CurrentConnection))
            {
                return context.M_Author.ToList();
            }
        }

        public static List<M_Cipai> GetAllCipai()
        {
            using (PoemDBDataContext context = new PoemDBDataContext(CurrentConnection))
            {
                return context.M_Cipai.ToList();
            }
        }

        public static M_Cipai GetCipai(List<M_Cipai> Cipais, string cipai)
        {
            if (string.IsNullOrWhiteSpace(cipai))
            {
                return null;
            }
            cipai = cipai.Replace(" ", "");
            return Cipais.Find(m => m.Cipai.Equals(cipai));
        }


        public static M_Author GetAuthor(List<M_Author> Authors, string author)
        {
            if (string.IsNullOrWhiteSpace(author))
            {
                return null;
            }
            author = author.Replace(" ", "");
            return Authors.Find(m => m.Author.Equals(author));

        }

        public static List<M_Poem> QueryPoem(string key)
        {
            using (PoemDBDataContext context = new PoemDBDataContext(CurrentConnection))
            {
                var result = from poem in context.M_Poem
                             where
                             (poem.Author.IndexOf(key) >= 0 ||
                              poem.Cipai.IndexOf(key) >= 0 ||
                              poem.MainBody.IndexOf(key) >= 0)
                             select poem;
                return result.ToList();
            }
        }

        public static long GetMaxId()
        {
            using(PoemDBDataContext context = new PoemDBDataContext(CurrentConnection))
            {
                var maxId = (from x in context.M_Poem2
                              select x.ID).Max();
                return maxId+1;              
            }
        }
    }
}
