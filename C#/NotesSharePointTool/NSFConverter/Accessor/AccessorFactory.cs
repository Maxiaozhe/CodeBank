
using RJ.Tools.NotesTransfer.Engines.Common;
using RJ.Tools.NotesTransfer.Engines.Enums;
using RJ.Tools.NotesTransfer.Engines.Interfaces;
using RJ.Tools.NotesTransfer.Engines.Notes.Controls;
using RJ.Tools.NotesTransfer.Engines.Sharepoint.Controls;
using RJ.Tools.NotesTransfer.Engines.SqlServer;
using RJ.Tools.NotesTransfer.Engines.SqlServer.Control;
using RS = RJ.Tools.NotesTransfer.Engines.Resources;
using RSM = RJ.Tools.NotesTransfer.Engines.Resource.ResourceManager;

namespace RJ.Tools.NotesTransfer.UI.Accessor
{
    public class AccessorFactory
    {
        /// <summary>
        /// ノーツアクセサーのインスタンスを取得する
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static NotesAccessor GetNotesAccessor()
        {
            return NotesAccessor.CreateInstance();
        }

        public static SpAccessor GetSpAccessor(string webSite, string userId, string password)
        {
            return SpAccessor.CreateInstance(webSite, userId, password);
        }

        /// <summary>
        /// SQL Accessorのインスタンスを取得する
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="server"></param>
        /// <param name="userId"></param>
        /// <param name="password"></param>
        /// <param name="database"></param>
        /// <returns></returns>
        public static SqlAccessor GetSqlAccessor(AuthenticateMode mode, string server, string userId, string password, string database)
        {
            if (mode == AuthenticateMode.SqlServer)
            {
                return SqlAccessor.CreateInstance(server, userId, password, database, Config.ConnectTimeout, Config.CommandTimeout);
            }
            else
            {
                return SqlAccessor.CreateInstance(server, database, Config.ConnectTimeout, Config.CommandTimeout);
            }
        }
        /// <summary>
        /// SQL Accessorのインスタンスを取得する
        /// </summary>
        /// <returns></returns>
        public static SqlAccessor GetSqlAccessor()
        {
            AuthenticateMode mode = (AuthenticateMode)Config.DBAuthenticateMode;
            if (string.IsNullOrEmpty(Config.SqlServer) || string.IsNullOrEmpty(Config.DataBaseName))
            {
                throw RSM.GetException(RS.Exceptions.NotConfiged);
            }
            return GetSqlAccessor(mode, Config.SqlServer, Config.DBUserId, Config.DBPassWord, Config.DataBaseName);
        }
        /// <summary>
        /// ログWriterのインスタンスを取得する
        /// データベース接続できない場合、NULLで返す
        /// </summary>
        /// <returns></returns>
        public static ILogWriter GetLogWriter()
        {
            SqlAccessor sqlAccessor = null;
            try
            {
                sqlAccessor = GetSqlAccessor();
            }
            catch
            {
                return null;
            }
            SqlEventWriter logWriter = new SqlEventWriter();
            logWriter.Init(GetSqlAccessor());
            return logWriter;
        }

    }
}
