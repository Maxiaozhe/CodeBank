using Rex.Tools.Test.DataCheck.Common;
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

        internal DataTableInfo(DataRow row)
        {
            this._tableName = Utility.DBToString(row["物理名"]);
            this._displayName = Utility.DBToString(row["テーブル名"]);
            if (row.Table.Columns.Contains("シート名"))
            {
                this._sheetName = Utility.DBToString(row["シート名"]);
            }
            else
            {
                this._sheetName = this._displayName;
            }
            
        }
    }
}
