using RJ.Tools.NotesTransfer.Engines.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RJ.Tools.NotesTransfer.Engines.Common
{
    public static class Log
    {
        private static ILogWriter _logWriter;

        public static void Init(ILogWriter writer)
        {
            _logWriter = writer;
        }

        /// <summary>
        /// 例外
        /// </summary>
        /// <param name="ex"></param>
        public static void Write(Exception ex)
        {
            if (_logWriter != null)
            {
                _logWriter.Write(ex);
            }
        }
 
        /// <summary>
        /// 処理ログ
        /// </summary>
        /// <param name="task"></param>
        /// <param name="message"></param>
        /// <param name="sucess"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        public static void Write(IMigrateTask task, string message, bool sucess, DateTime startDate, DateTime endDate)
        {
            if (_logWriter != null)
            {
                _logWriter.Write(task,message,sucess,startDate,endDate);
            }
        }

        /// <summary>
        /// 操作ログ
        /// </summary>
        /// <param name="message"></param>
        public static void Write(string message)
        {
            if (_logWriter != null)
            {
                _logWriter.Write(message);
            }
        }

     
        /// <summary>
        /// 操作ログ
        /// </summary>
        /// <param name="message"></param>
        public static void Write(string taskId, string message)
        {
            if (_logWriter != null)
            {
                _logWriter.Write(taskId, message);
            }
        }
    }
}
