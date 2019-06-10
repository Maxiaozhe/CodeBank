using Maxz.PoemSystem.Engine.Modules;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Maxz.PoemSystem.Tools.Controls
{
    public class DataImports
    {
        public void ImportBookIndex(string fileName, string bookName, int bookNo)
        {
            string buffer = System.IO.File.ReadAllText(fileName, System.Text.Encoding.UTF8);
            IEnumerable<M_BookIndex> bookIndexs = ReadBookIndex(buffer, bookName, bookNo);
            LinqSqlHelp.AddBookIndex(bookIndexs);
        }

        private IEnumerable<M_BookIndex> ReadBookIndex(string text, string bookName, int bookNo)
        {
            List<M_BookIndex> bookIndexes = new List<M_BookIndex>();
            Regex regex = new Regex(@"(卷(?<sectionNo>[0-9]+)(?<title>[^卷]+))");
            MatchCollection matches = regex.Matches(text);
            foreach (Match m in matches)
            {
                int sectNo = 0;
                string sectName = "";
                if (!int.TryParse(m.Groups["sectionNo"].Value, out sectNo))
                {
                    continue;
                }
                sectName = m.Groups["title"].Value.Trim();
                bookIndexes.Add(new M_BookIndex()
                {
                    BookName = bookName,
                    BookNo = bookNo,
                    SectionNo = sectNo,
                    SectionName = sectName
                });
            }
            return bookIndexes.AsEnumerable();
        }

        public void ImportBook(string fileName, int bookNo)
        {
            List<M_Poem> poems = ReadTangshiBook(fileName, bookNo);
            LinqSqlHelp.AddPoems(poems);
        }

        public void ImportCiBook(string fileName, int bookNo)
        {
            List<M_Poem> poems = ReadSongciBook(fileName, bookNo);
            LinqSqlHelp.AddPoems(poems);
        }

        private List<M_Poem> ReadTangshiBook(string fileName, int bookNo)
        {
            using (StreamReader reader = new StreamReader(fileName, System.Text.Encoding.UTF8))
            {
                string text = reader.ReadLine();
                Regex regex = new Regex(@"卷(?<SecNo>[0-9]+)_(?<No>[0-9]+)\s*【(?<title>[^】]+)】(?<auth>[^\r]+)");
                List<M_Poem> poems = new List<M_Poem>();
                M_Poem poemItem = null;
                int sectNo = 0;
                int no = 0;
                string title = "";
                string auth = "";
                StringBuilder content = null;
                while (text != null)
                {
                    if (regex.IsMatch(text))
                    {
                        if (poemItem != null)
                        {
                            poemItem.MainBody = FormatPoemText(content.ToString());
                            poems.Add(poemItem);
                        }
                        Match m = regex.Match(text);
                        sectNo = int.Parse(m.Groups["SecNo"].Value);
                        no = int.Parse(m.Groups["No"].Value);
                        title = m.Groups["title"].Value.Trim();
                        auth = m.Groups["auth"].Value.Trim();
                        content = new StringBuilder();
                        poemItem = new M_Poem()
                        {
                            BookNo = bookNo,
                            SectionNo = sectNo,
                            PoemNo = no,
                            Title = title,
                            Author = auth,
                            Dynasty = "唐"
                        };
                    }
                    else
                    {
                        if (content != null)
                        {
                            content.AppendLine(text.Trim());
                        }
                    }
                    text = reader.ReadLine();
                }
                //最後の内容
                if (poemItem != null)
                {
                    poemItem.MainBody = FormatPoemText(content.ToString());
                    poems.Add(poemItem);
                }
                return poems;
            }
        }


        private List<M_Poem> ReadSongciBook(string fileName, int bookNo)
        {
            using (StreamReader reader = new StreamReader(fileName, System.Text.Encoding.UTF8))
            {
                List<M_Poem> poems = new List<M_Poem>();
                List<M_Author> Auths = LinqSqlHelp.GetAllAuthor();
                List<M_Cipai> Cipais = LinqSqlHelp.GetAllCipai();
                M_Poem poemItem = null;
                int sectNo = 0;
                int no = 0;
                string title = "";
                string auth = "";
                string cipai="";
                StringBuilder content = null;
                string text = reader.ReadLine();

                while (text != null)
                {
                    //作成者変更
                    string tempAuth;
                    if (TryParseAuth(Auths, text, out tempAuth))
                    {
                        sectNo++;
                        if (poemItem != null)
                        {
                            poemItem.MainBody = FormatPoemText(content.ToString());
                            poemItem.Title = title;
                            FormatCiPoemItem(poemItem);
                            poems.Add(poemItem);
                        }
                        auth = tempAuth;
                        poemItem = null;
                        no = 0;
                        text = reader.ReadLine();
                        continue;
                    }

                    string tempCipai;
                    string tempTitle;
                    if (TryParseCipai(Cipais, text, out tempCipai, out tempTitle))
                    {
                        if (poemItem != null)
                        {
                            poemItem.MainBody = FormatPoemText(content.ToString());
                            FormatCiPoemItem(poemItem);
                            poems.Add(poemItem);
                        }
                        no++;
                        cipai = tempCipai;
                        title = tempTitle;
                        content = new StringBuilder();
                        poemItem = new M_Poem()
                        {
                            BookNo = bookNo,
                            SectionNo = sectNo,
                            PoemNo = no,
                            Cipai=cipai,
                            Title = title,
                            Author = auth,
                            Dynasty = "宋",
                            PoemType="词"
                        };
                    }
                    else
                    {
                        if (content != null)
                        {
                            content.AppendLine(text.Trim());
                        }
                    }
                    text = reader.ReadLine();
                }
                //最後の内容
                if (poemItem != null)
                {
                    poemItem.MainBody = FormatPoemText(content.ToString());
                    poems.Add(poemItem);
                }
                return poems;
            }
        }

        private string FormatPoemText(string content)
        {
            Regex regex1 = new Regex(@"^\s*\n|\s*\n$");
            Regex regex2 = new Regex(@"[\r\n]{3,}");
            //前後の改行を除く
            content = regex1.Replace(content,"");
            return regex2.Replace(content, "\r\n\r\n");
        }

        private void FormatCiPoemItem(M_Poem poem)
        {
            string poemText = FormatPoemText(poem.MainBody);
            string foreword = GetForeword(poemText);
            string mainBody = GetMainBody(poemText);
            if (string.IsNullOrWhiteSpace(poem.Title))
            {
                poem.Title = GetFirstSentence(mainBody);
            }
            if (!string.IsNullOrWhiteSpace(foreword))
            {
                poem.Foreword = foreword;
            }
            if (!string.IsNullOrWhiteSpace(mainBody))
            {
                poem.MainBody = mainBody;
            }
        }

        /// <summary>
        /// 序言を取得する
        /// </summary>
        /// <returns></returns>
        private string GetForeword(string wordText)
        {
            Regex regex = new Regex(@"^\s*\[(?<foreword>[^\]]+)\]|^\s*（(?<foreword>[^）]+)）");
            Match m = regex.Match(wordText);
            if (m.Success)
            {
                return m.Groups["foreword"].Value;
            }
            else
            {
                return string.Empty;
            }
        }
        /// <summary>
        /// 本文から最初の段落を取得
        /// </summary>
        /// <param name="wordText"></param>
        /// <returns></returns>
        private string GetFirstSentence(string wordText)
        {
            Regex regex = new Regex(@"^[^，。、！？；,!?]+");
            if (regex.IsMatch(wordText))
            {
                return regex.Match(wordText).Value;
            }
            else
            {
                return wordText;
            }
        }

        private string GetMainBody(string wordText)
        {
            Regex regex = new Regex(@"^\s*\[([^\]]+)\]|^\s*（([^）]+)）");
            Regex regex1 = new Regex(@"^\s*\n|\s*\n$");
            string mainBody = regex.Replace(wordText,"");
            mainBody = regex1.Replace(mainBody, "");
            return mainBody;
        }

        private bool TryParseAuth(List<M_Author> auths, string text, out string auth)
        {
            auth = null;
            if (string.IsNullOrWhiteSpace(text)) return false;
            text = text.Replace(" ", "");
            if (text.Length > 7)
            {
                return false;
            }
            if (text.Equals("无名氏"))
            {
                auth = text;
                return true;
            }
            var authItem = LinqSqlHelp.GetAuthor(auths, text);
            if (authItem != null)
            {
                auth = authItem.Author;
                return true;
            }
            return false;
        }

        private bool TryParseCipai(List<M_Cipai> ciPais, string text, out string cipai, out string title)
        {
            cipai = null;
            title = null;
            if (string.IsNullOrWhiteSpace(text)) return false;
            text = text.Trim();
            Regex regex = new Regex(@"^(?<cipai>[^（]+)（(?<title>[^）]+)）|^(?<cipai>[^（]+)");
            Match m = regex.Match(text);
            if (!m.Success)
            {
                return false;
            }
            cipai = m.Groups["cipai"].Value;
            if (m.Groups["title"] != null)
            {
                title = m.Groups["title"].Value.Trim();
            }
            if (cipai.Equals("失调名"))
            {
                return true;
            }
            var cipaiItem = LinqSqlHelp.GetCipai(ciPais, cipai);
            if (cipaiItem != null)
            {
                cipai = cipaiItem.Cipai;
                return true;
            }
            return false;
        }
    }

}
