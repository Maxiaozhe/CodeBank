using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RSM = RJ.Tools.NotesTransfer.Engines.Resource.ResourceManager;

namespace RJ.Tools.NotesTransfer.Engines.Common
{
    /// <summary>
    /// 処理プログレスレポーター
    /// </summary>
    public class ProgressReporter
    {
        public delegate void ReportHandler(object sender, ReportEventArgs args);

        #region Field
        private ReportHandler _reportHandler;
        private int _processCount;
        private int _sucessCount;
        private int _stepCount;
        private double _stepRate;
        private string _taskName;
        private int _processPercentage = 0;
        #endregion

        #region Property

        /// <summary>
        /// ステップ件数
        /// </summary>
        public int SetpCount
        {
            get
            {
                return this._stepCount;
            }
        }
        /// <summary>
        /// ステップ処理件数
        /// </summary>
        public int ProcessedCount
        {
            get
            {
                return this._processCount;
            }
        }

        /// <summary>
        /// ステップ進歩率
        /// </summary>
        public int StepPercentage
        {
            get
            {
                if (this._stepCount == 0) return 0;
                int percent = (int)((double)this._processCount * 100 / this._stepCount);
                if (percent > 100) return 100;
                return percent;
            }
        }
        /// <summary>
        /// 総進歩率
        /// </summary>
        public int ProcessPercentage
        {
            get
            {
                return this._processPercentage;
            }
        }
        #endregion

        #region Constructor
        public ProgressReporter(string taskName, ReportHandler reportHandler)
        {
            this._taskName = taskName;
            this._reportHandler = reportHandler;
        }
        #endregion

        #region Method


        /// <summary>
        /// 処理ステップ設定
        /// </summary>
        /// <param name="stepRate"></param>
        /// <param name="stepCount"></param>
        public void SetStep(double stepRate, int stepCount, Enum messageId, params string[] args)
        {
            this._processPercentage = (int)(this._processPercentage + this._stepRate);
            this._stepCount = stepCount;
            this._stepRate = stepRate;
            this._processCount = 0;
            this._sucessCount = 0;
            string message = string.Empty;
            if (this._reportHandler == null) return;
            if (args == null || args.Length == 0)
            {
                message = RSM.GetMessage(messageId);
            }
            else
            {
                message = RSM.GetMessage(messageId, args);
            }
            int parcent = this._processPercentage + (int)(this._stepRate * StepPercentage / 100);
            ReportEventArgs eventArgs = new ReportEventArgs(
                    this._taskName, parcent, this.SetpCount, this._sucessCount, this._processCount, message);
            this._reportHandler(this, eventArgs);
        }

        /// <summary>
        /// 進歩報告
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="messageId"></param>
        /// <param name="isSucess"></param>
        /// <param name="args"></param>
        public void ReportStep(Enum messageId, bool isSucess, params string[] args)
        {
            if (this._reportHandler == null) return;
            string message = string.Empty;
            if (args == null || args.Length == 0)
            {
                message = RSM.GetMessage(messageId);
            }
            else
            {
                message = RSM.GetMessage(messageId, args);
            }
            this._processCount++;
            if (isSucess) this._sucessCount++;
            int parcent = this._processPercentage + (int)(this._stepRate * StepPercentage / 100);
            ReportEventArgs eventArgs = new ReportEventArgs(
                    this._taskName, parcent, this.SetpCount, this._sucessCount, this._processCount, message);
            this._reportHandler(this, eventArgs);

        }
        /// <summary>
        /// エベント報告
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="messageId"></param>
        /// <param name="args"></param>
        public void Report(Enum messageId, params string[] args)
        {
            if (this._reportHandler == null) return;
            string message = string.Empty;
            if (args == null || args.Length == 0)
            {
                message = RSM.GetMessage(messageId);
            }
            else
            {
                message = RSM.GetMessage(messageId, args);
            }
            int parcent = this._processPercentage + (int)(this._stepRate * StepPercentage / 100);
            ReportEventArgs eventArgs = new ReportEventArgs(
                this._taskName, parcent, this.SetpCount, this._sucessCount, this._processCount, message);
            this._reportHandler(this, eventArgs);
        }
        #endregion




    }

    public class ReportEventArgs
    {
        private int _stepCount;
        private int _processedCount;
        private string _message;
        private int _sucessCount;
        private int _progressPercentage;
        private string _taskName;
        #region Property
        /// <summary>
        /// ステップ件数
        /// </summary>
        public int SetpCount
        {
            get
            {
                return this._stepCount;
            }
        }
        /// <summary>
        /// ステップ処理件数
        /// </summary>
        public int ProcessedCount
        {
            get
            {
                return this._processedCount;
            }
        }
        /// <summary>
        /// 成功件数
        /// </summary>
        public int SucessCount
        {
            get
            {
                return this._sucessCount;
            }
        }
        /// <summary>
        /// 失敗件数
        /// </summary>
        public int FailedCount
        {
            get
            {
                return this._processedCount - this._sucessCount;
            }
        }
        /// <summary>
        /// 総処理パセンテージ
        /// </summary>
        public int ProgressPercentage
        {
            get
            {
                return this._progressPercentage;
            }
        }

        /// <summary>
        /// メッセージ
        /// </summary>
        public string Message
        {
            get
            {
                return this._message;
            }
        }
        public string TaskName
        {
            get
            {
                return this._taskName;
            }
        }
        public ReportEventArgs(string task, int percent, int total, int sucess, int processed, string message)
        {
            this._taskName = task;
            this._progressPercentage = percent;
            this._stepCount = total;
            this._processedCount = processed;
            this._sucessCount = sucess;
            this._message = message;
        }

        #endregion
    }
}
