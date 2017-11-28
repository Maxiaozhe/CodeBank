using System;
using System.Diagnostics;
using System.IO;
using Microsoft.VisualBasic.Logging;
using System.Data;
using System.Text;

namespace Rex.Tools.Test.DataCheck
{
    /// <summary>
    /// Channels all output for the application.
    /// </summary>
    public class Logging
    {
        private static int m_ProcessID = 0;
        private static int m_Tab = 0;
        private static TraceSwitch m_TraceLevel = new TraceSwitch("LoggingLevel", "DataCheckTool Logging");
        private static string _Category = "-Common";
        private static string _OutputFile = "";
        private Logging()
        {

        }

        public static string OutputFileName
        {
            get
            {
                return _OutputFile;
            }
            set
            {
                _OutputFile = value;
                SetTraceListener();
            }

        }

        public static void Initialize()
        {
            if (m_ProcessID == 0)
            {
                SetTraceListener();
            }
        }

        private static void SetTraceListener()
        {
            System.Diagnostics.Trace.Listeners.Remove("LogWriter");
            Process process = System.Diagnostics.Process.GetCurrentProcess();
            _Category = process.ProcessName;
            m_ProcessID = process.Id;
            // If asked, we'll initialize with a process specific file name.
            BooleanSwitch tsUniqueLog = new BooleanSwitch("UniqueLog", "Generate separate log for each process instance");
            if (tsUniqueLog.Enabled && string.IsNullOrEmpty(_OutputFile))
            {
                string path = System.IO.Path.Combine(System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase, "log");
                string logName = string.Format("{0}-{1}", _Category, m_ProcessID);
                FileLogTraceListener myListener = new FileLogTraceListener("LogWriter");
                myListener.Location = LogFileLocation.Custom;
                myListener.Append = true;
                myListener.BaseFileName = logName;
                myListener.CustomLocation = path;
                myListener.LogFileCreationSchedule = LogFileCreationScheduleOption.Daily;
                System.Diagnostics.Trace.Listeners.Add(myListener);
                System.Diagnostics.Trace.AutoFlush = true;
            }
            else
            {
                //指定のファイル名でログを出力
               
                string path = System.IO.Path.Combine(System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase, "log");
                if (!System.IO.Directory.Exists(path))
                {
                    System.IO.Directory.CreateDirectory(path);
                }
                string fullName = System.IO.Path.Combine(path, _OutputFile);
                if (System.IO.File.Exists(fullName))
                {
                    System.IO.File.Delete(fullName);
                }
                DefaultTraceListener myListener = new DefaultTraceListener();
                myListener.Name = "LogWriter";
                myListener.LogFileName = fullName;
                System.Diagnostics.Trace.Listeners.Add(myListener);
                System.Diagnostics.Trace.AutoFlush = true;
            }
        }



        /// <summary>
        /// TraceListenerを追加する
        /// </summary>
        /// <param name="Listener"></param>
        public static void AddLogListener(TraceListener Listener)
        {
            Initialize();
            // If asked, we'll initialize with a process specific file name.
            BooleanSwitch tsUniqueLog = new BooleanSwitch("UniqueLog", "Generate separate log for each process instance");
            if (tsUniqueLog.Enabled)
            {
                System.Diagnostics.Trace.Listeners.Add(Listener);
                System.Diagnostics.Trace.AutoFlush = true;
            }
        }

        public static void Indent()
        {
            m_Tab++;
        }


        public static void UnIndent()
        {
            m_Tab--;
        }


        public static void Trace(string sMessage)
        {
            Initialize();
            if (m_TraceLevel.Level >= TraceLevel.Verbose)
                Log(sMessage, TraceLevel.Verbose);
        }

        public static void Trace(string sMessage, params string[] args)
        {
            Initialize();
            string message = string.Format(sMessage, args);
            if (m_TraceLevel.Level >= TraceLevel.Verbose)
                Log(message, TraceLevel.Verbose);
        }

        public static void Information(string sMessage)
        {
            Initialize();
            if (m_TraceLevel.Level >= TraceLevel.Info)
                Log(sMessage, TraceLevel.Info);
        }


        public static void Warning(string sMessage)
        {
            Initialize();
            if (m_TraceLevel.Level >= TraceLevel.Warning)
                Log(sMessage, TraceLevel.Warning);
        }


        public static void Error(string sMessage)
        {
            Initialize();
            if (m_TraceLevel.Level >= TraceLevel.Error)
                Log(sMessage, TraceLevel.Error);
        }


        public static void Exception(string sOffendingOperation, Exception ex)
        {
            Initialize();
            String ExInfo = ex.GetType().ToString() + " [" + ex.Message + "]";

            if (m_TraceLevel.Level >= TraceLevel.Verbose)
            {
                Log(sOffendingOperation + "  " + ExInfo + "\n" + ex.StackTrace, TraceLevel.Error);
            }
            else if (m_TraceLevel.Level >= TraceLevel.Error)
            {
                Log(sOffendingOperation + " " + ExInfo, TraceLevel.Error);
            }
        }

        public static void DbTrace(string sMessage)
        {
            Initialize();
            if (m_TraceLevel.Level >= TraceLevel.Error)
                Log(sMessage, TraceLevel.Verbose);
        }

        public static DateTime Start(string message)
        {
            Trace(message + " start");
            return DateTime.Now;
        }


        public static void Stop(string message, DateTime startTime)
        {
            message += " stop";
            if (startTime != DateTime.MinValue)
            {
                TimeSpan ts = new TimeSpan(DateTime.Now.Ticks - startTime.Ticks);
                message += ", duration: " + ts.ToString();
            }
            Trace(message);
        }


        public static DateTime Enter(Type type, string method)
        {
            return Enter(type, method, null);
        }


        public static DateTime Enter(Type type, string method, string data)
        {
            string message = type.ToString() + "::" + method + " enter";
            if (data != null && data.Length > 0)
                message += " (" + data + ")";
            Trace(message);

            return DateTime.Now;
        }


        public static void Leave(Type type, string method)
        {
            Leave(type, method, null);
        }


        public static void Leave(Type type, string method, string data)
        {
            Leave(type, method, data, DateTime.MinValue);
        }


        public static void Leave(Type type, string method, string data, DateTime enterTime)
        {
            string message = type.ToString() + "::" + method + " leave";
            if (enterTime != DateTime.MinValue)
            {
                TimeSpan ts = new TimeSpan(DateTime.Now.Ticks - enterTime.Ticks);
                message += ", duration: " + ts.ToString();
            }
            if (data != null && data.Length > 0)
                message += ", data: " + data;
            Trace(message);
        }


        public static void Called(Type type, string method)
        {
            Called(type, method, null);
        }


        public static void Called(Type type, string method, string data)
        {
            string message = type.ToString() + "::" + method + " called";
            if (data != null && data.Length > 0)
                message += " (" + data + ")";
            Trace(message);
        }

        public static void OutPutTableInf(string tableName,DataTable dttSource)
        {
            Initialize();
            StringBuilder sb = new StringBuilder();
            int index = 0;
            sb.AppendFormat("{0} [{1}]",tableName,dttSource.TableName);
            sb.AppendLine();
            foreach (DataColumn col in dttSource.Columns)
            {
                if (index > 0)
                {
                    sb.Append(",");
                }
                sb.Append(col.ColumnName);
                index++;
            }
            sb.AppendLine();
            Log(sb.ToString(), TraceLevel.Error);
        }


        public static void DataDiff(DataRow row,bool IsResult )
        {
            Initialize();
            StringBuilder sb = new StringBuilder(); 
            switch (row.RowState)
            {
                case DataRowState.Added:
                    if (IsResult)
                    {
                        sb.AppendLine("期待より足りない行");
                    }
                    else
                    {
                        sb.AppendLine("期待より多い行");
                    }
                    break;
                case DataRowState.Modified:
                    sb.AppendLine("差異あり");
                    break;
                default:
                    return;
            }
            int index = 0;
            foreach(DataColumn col in row.Table.Columns)
            {
                if (index > 0)
                {
                    sb.Append(",");
                }
                if (!row.IsNull(col))
                {
                    sb.Append(row[col].ToString());
                }
                else
                {
                    sb.Append("null");
                }
                index++;
            }
            sb.AppendLine();
            Log(sb.ToString(), TraceLevel.Error);
        }


        private static void Log(string str, TraceLevel level)
        {
            if (m_ProcessID != 0)
            {
                string tab = new string(' ', m_Tab * 4);
                string text = string.Format("{0:11}, {1:D6}-{2:D6}, {3}{4}: {5}",
                    System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fffff"),
                    m_ProcessID,
                    System.Threading.Thread.CurrentThread.GetHashCode(),
                    tab,
                    level.ToString(),
                    str);

                System.Diagnostics.Trace.WriteLine(text);
            }
        }
        
        public static void Write(string text)
        {
            Initialize();
            System.Diagnostics.Trace.Write(text);
        }

        public static void Write(string format, params string[] args)
        {
            Initialize();
            string text = string.Format(format, args);
            System.Diagnostics.Trace.Write(text);
        }

        public static void WriteLine(string text)
        {
            Initialize();
            System.Diagnostics.Trace.WriteLine(text);
        }

        public static void WriteLine(string format, params string[] args)
        {
            Initialize();
            string text = string.Format(format, args);
            System.Diagnostics.Trace.WriteLine(text);
        }

    }
}
