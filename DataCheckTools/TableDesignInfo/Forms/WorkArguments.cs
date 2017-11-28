using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableDesignInfo.Forms
{
    public class WorkArguments
    {
        public WorkArguments(string command)
        {
            this.Command = command;
        }
        public string Command
        {
            get;
            set;
        }
        public object Args
        {
            get;
            set;
        }
    }

}
