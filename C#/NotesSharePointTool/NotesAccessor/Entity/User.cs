using RJ.Tools.NotesTransfer.Engines.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RJ.Tools.NotesTransfer.Engines.Interfaces;

namespace RJ.Tools.NotesTransfer.Engines.Notes.Entity
{
    public class User:IUser
    {
        public string SourceUser
        {
            get;
            set;
        }

        public string TargetUser
        {
            get;
            set;
        }

        public string DisplayName
        {
            get;
            set;
        }
    }
}
