using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJ.Tools.NotesTransfer.Engines.Interfaces
{
   public interface ILogWriter
    {
       /// <summary>
       /// 例外
       /// </summary>
       /// <param name="ex"></param>
        void Write(Exception ex);
       /// <summary>
       /// 処理ログ
       /// </summary>
       /// <param name="task"></param>
       /// <param name="message"></param>
       /// <param name="sucess"></param>
       /// <param name="startDate"></param>
       /// <param name="endDate"></param>
       void Write(IMigrateTask task, string message, bool sucess, DateTime startDate, DateTime endDate);
       /// <summary>
       /// 操作ログ
       /// </summary>
       /// <param name="message">メッセージ</param>
       void Write(string message);
       /// <summary>
       /// 操作ログ
       /// </summary>
       /// <param name="taskId"></param>
       /// <param name="message"></param>
       void Write(string taskId,string message);
    }
}
