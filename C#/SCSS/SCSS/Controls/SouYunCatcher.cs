using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CsQuery;
using Maxz.PoemSystem.Engine.Modules;


namespace Maxz.PoemSystem.Tools.Controls
{
    public class SouYunPoemCatcher : NetCatcher
    {
        private const string UrlFormat = @"http://sou-yun.com/Query.aspx?type=poem1&id={0}";

        public int Count { get; set; }

        private int _startId;

        private int _maxId;
        
        protected override int Parsentage
        {
            get
            {
                return (int)((double)this._count * 100 / (double)(this._maxId - this._startId));
            }
        }


        public void CatchResources(int startId, int maxId)
        {
            this._count = 0;
            this._startId = startId;
            this._maxId = maxId;
            for (int i = startId; i <= maxId; i++)
            {
                CatchWebSource(UrlFormat, i.ToString());
                System.Threading.Thread.Sleep(1000);
                
            }

        }


        protected override void Regist(System.IO.MemoryStream contentStream, string[] args)
        {
            this._count++;
            string content = System.Text.Encoding.UTF8.GetString(contentStream.ToArray());
            CQ cq = new CQ(content, HtmlParsingMode.Auto, HtmlParsingOptions.Default, DocType.HTML5);
            var poem = cq.Select(".poem");
            var contents = poem.Select(".content");
            List<M_Poem2> poems = new List<M_Poem2>();
            List<M_PoemImage> imgs = new List<M_PoemImage>();
            Regex regex = new Regex(@"(?<title>[^（]+)（(?<dynasty>[^·]+)·(?<auth>[^）]+)）\s(?<gelu>.*)(?=押)(押(?<yun>[^韵])韵){0,1}");
            for (int i = 0; i < contents.Length; i++)
            {
                CQ titleSmallNode = poem.Select(".title:eq(" + i + ") > .small");
                string smallNode = "";
                if (titleSmallNode.Length > 0)
                {
                    smallNode = titleSmallNode.Text();
                    titleSmallNode.Remove();
                }
                string titleText = poem.Select(".title:eq(" + i + ")").Text();
                Match m = regex.Match(titleText);
                string title = titleText;
                string author = "";
                string dynasty = "";
                string yun="";
                if (m.Success)
                {
                    title = m.Groups["title"].Value;
                    author = m.Groups["auth"].Value;
                    dynasty = m.Groups["dynasty"].Value;

                    if (m.Groups["yun"] != null)
                    {
                        yun = m.Groups["yun"].Value;
                    }
                }
                string titleNote = poem.Select(".title:eq(" + i + ") ~ .titleNote").Text();
                if (!string.IsNullOrEmpty(smallNode))
                {
                    titleNote += "\n" + smallNode;
                }
                string mainBody = poem.Select(".content:eq(" + i + ")").Text();
                string label = poem.Select(".content:eq(" + i + ") + .footer > .label").Text();
                string footer = poem.Select(".content:eq(" + i + ") + .footer > .comment").Text();
                string commentBar = poem.Select("div.comment").Text();
                string html = System.Web.HttpUtility.HtmlDecode(poem.Html());
                //入力チェック
                //Title
                if (!string.IsNullOrEmpty(title) && title.Length > 250)
                {
                    if (string.IsNullOrWhiteSpace(titleNote))
                    {
                        titleNote = title;
                    }
                    title = title.Substring(0, 250);
                }
                //Dynasty
                if(!string.IsNullOrEmpty(title) && dynasty.Length > 50)
                {
                    dynasty = dynasty.Substring(0, 50);
                }
                poems.Add(new M_Poem2()
                {
                    ID = int.Parse(args[0]),
                    SubID = i,
                    Title = title,
                    Yun=yun,
                    TitleNote = titleNote,
                    MainBody = mainBody,
                    Author = author,
                    Dynasty = dynasty,
                    Footer = label + footer,
                    Comment = commentBar,
                    Html = html
                });
                if (this.Report != null)
                {
                    Dictionary<string, string> result = new Dictionary<string, string>();
                    result["count"] = this._count.ToString();
                    result["message"] = string.Format("ID:{0}【{1}】{2}", args[0], title, author); ;
                    result["content"] = mainBody;
                    this.Report(this.Parsentage , result);
                }
            }


            //参照イメージ
            CQ refImgs = poem.Select(".picSSIcon , .picSSOn");
            for (int i = 0; i < refImgs.Length; i++)
            {
                string title = refImgs.Get(i).Attributes["title"];
                string url = "http://sou-yun.com" + refImgs.Get(i).Attributes["src"];
                imgs.Add(new M_PoemImage()
                {
                    ID = int.Parse(args[0]),
                    SubID = 0,
                    ImageId = i + 1,
                    Title = title,
                    ImageUrl = url
                });
            }
            LinqSqlHelp.AddPoem2(poems, imgs);
        }

        protected override string GetUrl(string UrlFormat, params string[] args)
        {
            return string.Format(UrlFormat, args);
        }



    }
}
