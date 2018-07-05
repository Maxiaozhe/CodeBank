using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableDesignInfo.Controls
{
    /// <summary>
    /// 処理プログレスレポーター
    /// </summary>
    public abstract class ProgressReporter
    {
        public delegate void ReportHandler(object sender, ReportEventArgs args);

        #region Field
        private ReportHandler _reportHandler;
        private int _processCount;
        private int _totalCount;
        #endregion

        #region Property

        /// <summary>
        /// ステップ件数
        /// </summary>
        protected int TotalCount
        {
            get
            {
                return this._totalCount;
            }
        }
        /// <summary>
        /// ステップ処理件数
        /// </summary>
        protected int ProcessedCount
        {
            get
            {
                return this._processCount;
            }
        }

        /// <summary>
        /// ステップ進歩率
        /// </summary>
        protected int Percentage
        {
            get
            {
                if (this._totalCount == 0) return 0;
                int percent = (int)((double)this._processCount * 100 / this._totalCount);
                if (percent > 100) return 100;
                return percent;
            }
        }

        #endregion

        #region Constructor
        protected ProgressReporter(ReportHandler reportHandler)
        {
            this._reportHandler = reportHandler;
        }
        #endregion

        #region Method


        /// <summary>
        /// 処理ステップ設定
        /// </summary>
        /// <param name="stepRate"></param>
        /// <param name="stepCount"></param>
        protected void SetStep(int count, string message,params string[] args)
        {
            this._totalCount = count;
            this._processCount = 0;
            if (this._reportHandler == null) return;
            if (args != null && args.Length > 0)
            {
                message = string.Format(message, args);
            }
            ReportEventArgs eventArgs = new ReportEventArgs( this.Percentage, this.TotalCount, this._processCount, message);
            this._reportHandler(this, eventArgs);
        }

        /// <summary>
        /// 進歩報告
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="messageId"></param>
        /// <param name="isSucess"></param>
        /// <param name="args"></param>
        protected void ReportStep(string message, params string[] args)
        {
            if (this._reportHandler == null) return;
            if (args != null && args.Length > 0)
            {
                message = string.Format(message, args);
            }
            this._processCount++;
            ReportEventArgs eventArgs = new ReportEventArgs( this.Percentage, this.TotalCount,  this._processCount, message);
            this._reportHandler(this, eventArgs);

        }
        /// <summary>
        /// イベント報告
        /// </summary>
        /// <param name="messageId"></param>
        /// <param name="args"></param>
        protected void Report(string message, params string[] args)
        {
            if (this._reportHandler == null) return;
            if (args != null && args.Length > 0)
            {
                message = string.Format(message, args);
            }
            ReportEventArgs eventArgs = new ReportEventArgs( this.Percentage, this.TotalCount,  this._processCount, message);
            this._reportHandler(this, eventArgs);
        }
        #endregion
    }

    public class ReportEventArgs
    {
        private int _totalCount;
        private int _processedCount;
        private string _message;
        private int _progressPercentage;
        #region Property
        /// <summary>
        /// ステップ件数
        /// </summary>
        public int TotalCount
        {
            get
            {
                return this._totalCount;
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
      
        public ReportEventArgs(int percent, int total, int processed, string message)
        {
            this._progressPercentage = percent;
            this._totalCount = total;
            this._processedCount = processed;
            this._message = message;
        }

        #endregion
    }
}
