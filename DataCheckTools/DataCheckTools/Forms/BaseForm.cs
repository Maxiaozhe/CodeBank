using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rex.Tools.Test.DataCheck.Forms
{
    public partial class BaseForm : Form
    {
        private const string _messageCaption = "テストツール";

        public BaseForm()
        {
            InitializeComponent();
        }
        #region ShowMessage
        /// <summary>
        /// 情報を表示する
        /// </summary>
        /// <param name="message"></param>
        protected void ShowInfomation(string message)
        {
            MessageBox.Show(this, message, _messageCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        /// <summary>
        /// 情報を表示する
        /// </summary>
        /// <param name="messageFormat"></param>
        /// <param name="args"></param>
        protected void ShowInfomation(string messageFormat, params string[] args)
        {
            string message = string.Format(messageFormat, args);
            MessageBox.Show(this, message, _messageCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        /// <summary>
        /// 警告を表示する
        /// </summary>
        /// <param name="message"></param>
        protected void ShowWarning(string message)
        {
             MessageBox.Show(this, message, _messageCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        /// <summary>
        /// 警告を表示する
        /// </summary>
        /// <param name="messageFormat"></param>
        /// <param name="args"></param>
        protected void ShowWarning(string messageFormat, params string[] args)
        {
            string message = string.Format(messageFormat, args);
            MessageBox.Show(this, message, _messageCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        /// <summary>
        /// エラーを表示する
        /// </summary>
        /// <param name="message"></param>
        protected void ShowError(string message)
        {
             MessageBox.Show(this, message, _messageCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        /// <summary>
        /// エラーを表示する
        /// </summary>
        /// <param name="messageFormat"></param>
        /// <param name="args"></param>
        protected void ShowError(string messageFormat, params string[] args)
        {
            string message = string.Format(messageFormat, args);
            MessageBox.Show(this, message, _messageCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        /// <summary>
        /// 例外を表示する
        /// </summary>
        /// <param name="ex"></param>
        protected void ShowException(Exception ex)
        {
            MessageBox.Show(this, ex.Message, _messageCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        /// <summary>
        /// Yes/Noを表示する
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        protected DialogResult ShowQuestion(string message)
        {
           return MessageBox.Show(this, message, _messageCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
        /// <summary>
        /// Yes/Noを表示する
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        protected DialogResult ShowQuestion(string messageFormat, params string[] args)
        {
            string message = string.Format(messageFormat, args);
            return MessageBox.Show(this, message, _messageCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
        #endregion
    }
}
