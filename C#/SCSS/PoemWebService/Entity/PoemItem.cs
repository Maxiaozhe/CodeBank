using Maxz.PoemSystem.Engine.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PoemWebService.Entity
{
    [Serializable]
    [DataContract]
    public class PoemItem
    {
        [DataMember]
        public long ID { get; set; }
        [DataMember]
        public int SubID { get; set; }
        [DataMember]
        public string Cipai { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string Author { get; set; }
        [DataMember]
        public string Dynasty { get; set; }
        [DataMember]
        public string Body { get; set; }
        [DataMember]
        public string Yun { get; set; }
        [DataMember]
        public string TitleNode { get; set; }
        [DataMember]
        public string Footer { get; set; }
        [DataMember]
        public string Comment { get; set; }
        [DataMember]
        public string Html { get; set; }
        public PoemItem()
        {

        }
        public PoemItem(M_Poem poem)
        {
            this.ID = poem.ID;
            this.SubID = poem.PoemNo.HasValue? poem.PoemNo.Value:0;
            this.Title = poem.Title;
            this.Author = poem.Author;
            this.Dynasty = poem.Dynasty;
            this.Body = poem.MainBody;
            this.Cipai = poem.Cipai;
            this.TitleNode = poem.Foreword;
            this.Footer = poem.Comment;
        }
        public PoemItem(M_Poem2 poem)
        {
            this.ID = poem.ID;
            this.SubID = poem.SubID;
            this.Title = poem.Title;
            this.Author = poem.Author;
            this.Dynasty = poem.Dynasty;
            this.Body = poem.MainBody;
            this.TitleNode = poem.TitleNote;
            this.Footer = poem.Footer;
            this.Comment = poem.Comment;
        }
        public M_Poem2 ToPoem2()
        {
            return new M_Poem2()
            {
                ID = this.ID,
                SubID = this.SubID,
                Author = this.Author,
                Dynasty = this.Dynasty,
                Yun = this.Yun,
                Title = this.Title,
                TitleNote = this.TitleNode,
                MainBody = this.Body,
                Footer = this.Footer,
                Comment = this.Comment,
                Html = this.Html
            };
        } 
    }
}
