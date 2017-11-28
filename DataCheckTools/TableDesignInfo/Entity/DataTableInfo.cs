using TableDesignInfo.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rex.Tools.Test.DataCheck.Entity
{
    public class DataTableInfo
    {
        private string _tableName;
        private string _sheetName;
        private string _displayName;
        private string _comment;

        public string TableName
        {
            get
            {
                return this._tableName;
            }
        }

        public string SheetName
        {
            get
            {
                return this._sheetName;
            }
        }

        public string DisplayName
        {
            get
            {
                return this._displayName;
            }
        }

        public string Comment
        {
            get
            {
                return this._comment;
            }
        }

        internal DataTableInfo(DataRow row)
        {
            this._tableName = Utility.DBToString(row["TableName"]);
            this._displayName = Utility.DBToString(row["DisplayName"]);
            if (row.Table.Columns.Contains("SheetName"))
            {
                this._sheetName = Utility.DBToString(row["SheetName"]);
            }
            else
            {
                this._sheetName = this._displayName;
            }
            this._comment = Utility.DBToString(row["Comment"]);
        }
    }
}
