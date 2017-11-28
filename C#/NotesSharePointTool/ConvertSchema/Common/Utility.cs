using System;
using System.Data;
using Microsoft.VisualBasic.CompilerServices;
using System.Data.SqlClient;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
namespace RJ.Tools.NotesTransfer.Engines.Common
{
    /// <summary>
    /// クラス名：データ型変換用便利関数
    /// </summary>
    public static class Utility
    {
        #region メソッド
        public static bool DBToBoolean(object value)
        {
            if ((value == null) || (value is DBNull))
            {
                return false;
            }

            return Conversions.ToBoolean(value);
        }

        public static byte DBToByte(object value)
        {
            if ((value == null) || (value is DBNull))
            {
                return 0;
            }
            return Conversions.ToByte(value);
        }

        public static byte[] DBToByteList(object value)
        {
            if ((value == null) || (value is DBNull))
            {
                return null;
            }
            return (byte[])value;
        }


        public static DateTime? DBToDateTime(object value)
        {
            if ((value == null) || (value is DBNull))
            {
                return null;
            }
            return Conversions.ToDate(value);
        }


        public static decimal DBToDecimal(object value)
        {
            if ((value == null) || (value is DBNull))
            {
                return decimal.Zero;
            }
            return Conversions.ToDecimal(value);
        }

        public static double DBToDouble(object value)
        {
            if ((value == null) || (value is DBNull))
            {
                return 0.0;
            }
            return Conversions.ToDouble(value);
        }

        public static int DBToInteger(object value)
        {
            if ((value == null) || (value is DBNull))
            {
                return 0;
            }
            return Conversions.ToInteger(value);
        }

        public static long DBToLong(object value)
        {
            if ((value == null) || (value is DBNull))
            {
                return 0L;
            }
            return Conversions.ToLong(value);
        }

        public static float DBToSingle(object value)
        {
            if ((value == null) || (value is DBNull))
            {
                return 0f;
            }
            return Conversions.ToSingle(value);
        }

        public static string DBToString(object value)
        {
            if ((value == null) || (value is DBNull))
            {
                return "";
            }
            return Conversions.ToString(value);
        }

        public static object NVL(object value, object Defval)
        {
            if ((value == null) || (value is DBNull))
            {
                return Defval;
            }
            return value;
        }

        public static string SqlQuot(string rstrSQL)
        {
            string str = "";

            if (string.IsNullOrEmpty(rstrSQL))
            {
                return "''";
            }
            str = "N'" + rstrSQL.Replace("'", "''") + "'";
            return str;
        }

        public static object ToDBNull(DateTime value)
        {
            if (DateTime.Compare(value, DateTime.MinValue) == 0)
            {
                return DBNull.Value;
            }
            return value;
        }

        public static object ToDBNull(int value)
        {
            if (value == 0)
            {
                return DBNull.Value;
            }
            return value;
        }

        public static object ToDBNull(long value)
        {
            if (value == 0L)
            {
                return DBNull.Value;
            }
            return value;
        }

        public static object ToDBNull(object value)
        {
            if (value == null)
            {
                return DBNull.Value;
            }
            return value;
        }

        public static object ToDBNull(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return DBNull.Value;
            }
            return value;
        }

        public static SqlParameter AddParameter(this SqlCommand cmd, string paramName, object value)
        {
            object setObj = value;
            if (value == null)
            {
                setObj = DBNull.Value;
            }
            return cmd.Parameters.AddWithValue(paramName, setObj);
        }

        public static string ToString(this DataRow row, string columnName)
        {
            if (!row.Table.Columns.Contains(columnName))
            {
                return string.Empty;
            }
            return DBToString(row[columnName]);
        }

        /// <summary>
        /// Objectをシリアル化して、Base64文字列に変換する
        /// </summary>
        /// <param name="ObjectData"></param>
        /// <returns></returns>
        public static string ObjectToString(object ObjectData)
        {

            string serializStr = "";
            BinaryFormatter Formater = new BinaryFormatter();
            using (MemoryStream Stream = new System.IO.MemoryStream())
            {
                Formater.Serialize(Stream, ObjectData);
                byte[] bts = Stream.ToArray();
                serializStr = System.Convert.ToBase64String(bts);
            }
            return serializStr;
        }
        /// <summary>
        /// Base64文字列から、Objectのインスタンスを復元する
        /// </summary>
        /// <param name="serializString"></param>
        /// <returns></returns>
        public static object StringToObject(string serializString)
        {
            object ObjReturn = null;
            BinaryFormatter Formater = new BinaryFormatter();
            using (MemoryStream Stream = new System.IO.MemoryStream())
            {
                byte[] bts = Convert.FromBase64String(serializString);
                Stream.Write(bts, 0, bts.Length);
                Stream.Position = 0;
                ObjReturn = Formater.Deserialize(Stream);

            }
            return ObjReturn;
        }

        /// <summary>
        /// HASHコード連結計算
        /// </summary>
        /// <param name="h1"></param>
        /// <param name="h2"></param>
        /// <returns></returns>
        public static int CombineHashCode(int h1, int h2)
        {
            return ((h1 << 5) + h1) ^ h2;
        }


        #endregion
    }
}
