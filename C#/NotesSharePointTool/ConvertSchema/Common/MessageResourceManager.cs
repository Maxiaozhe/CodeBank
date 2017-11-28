using System;
using System.Windows.Forms;
namespace RJ.Tools.NotesTransfer.Engines.Resource
{
    #region MessageResourceManager Class
    public class MessageResourceManager
    {
        #region MessageKind
        /// <summary>
        /// メッセージ種別
        /// </summary>
        public enum MessageKind
        {
            /// <summary>
            /// 例外
            /// </summary>
            Exception,
            /// <summary>
            /// 警告
            /// </summary>
            Exclamation,
            /// <summary>
            /// 情報
            /// </summary>
            Information,
            /// <summary>
            /// 確認
            /// </summary>
            Question,
            /// <summary>
            /// その他
            /// </summary>
            Other
        }

        #endregion
        #region private fields
        private System.Resources.ResourceManager _ResManager;
        #endregion
        #region New
        internal MessageResourceManager(System.Resources.ResourceManager msgManger)
        {
            this._ResManager = msgManger;
        }
        #endregion
        #region GetMessageInfo
        /// <summary>
        /// メッセージボックスに表示するメッセージの内容を格納した MessageBoxInfo クラスのオブジェクトインスタンスを取得します。
        /// </summary>
        /// <param name="messageType">リソースの名前を表す列挙値</param>
        /// <returns>メッセージボックスの情報を返します。</returns>
        public MessageBoxInfo GetMessageBoxInfo(System.Enum messageType)
        {
            MessageBoxInfo info;
            info = this.GetMessageBoxInfo(messageType, false, MessageBoxDefaultButton.Button1);
            return info;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageType"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public MessageBoxInfo GetMessageBoxInfo(System.Enum messageType, params string[] args)
        {
            MessageBoxInfo info;
            info = this.GetMessageBoxInfo(messageType, false, MessageBoxDefaultButton.Button1, args);
            return info;
        }

        /// <summary>
        /// メッセージボックスに表示するメッセージの内容を格納した MessageBoxInfo クラスのオブジェクトインスタンスを取得します。
        /// </summary>
        /// <param name="messageType">リソースの名前を表す列挙値</param>
        /// <param name="cancel">キャンセルボタンを使用するかどうか</param>
        /// <param name="defaultButton">デフォルトボタン</param>
        /// <returns>メッセージボックスの情報を返します。</returns>
        public MessageBoxInfo GetMessageBoxInfo(System.Enum messageType,
                                                bool cancel,
                                                MessageBoxDefaultButton defaultButton)
        {
            MessageBoxInfo info;
            MessageBoxButtons button = MessageBoxButtons.OK;
            MessageBoxIcon icon = MessageBoxIcon.None;
            string message = this.GetMessage(messageType);
            switch (this.GetMessageKind(messageType))
            {
                case MessageKind.Exception:
                    icon = MessageBoxIcon.Error;
                    button = MessageBoxButtons.OK;
                    break;
                case MessageKind.Exclamation:
                    icon = MessageBoxIcon.Exclamation;
                    button = MessageBoxButtons.OK;
                    break;
                case MessageKind.Information:
                    icon = MessageBoxIcon.Information;
                    button = MessageBoxButtons.OK;
                    break;
                case MessageKind.Question:
                    icon = MessageBoxIcon.Question;
                    if (cancel)
                    {
                        button = MessageBoxButtons.YesNoCancel;
                    }
                    else
                    {
                        button = MessageBoxButtons.YesNo;
                    }
                    break;
                default:
                    break;
            }
            info = new MessageBoxInfo(message, icon, button, defaultButton);
            return info;
        }

        /// <summary>
        /// メッセージボックスに表示するメッセージの内容を格納した MessageBoxInfo クラスのオブジェクトインスタンスを取得します。
        /// </summary>
        /// <param name="messageType">リソースの名前を表す列挙値</param>
        /// <param name="cancel">キャンセルボタンを使用するかどうか</param>
        /// <param name="defaultButton">デフォルトボタン</param>
        /// <param name="args"></param>
        /// <returns>メッセージボックスの情報を返します。</returns>
        public MessageBoxInfo GetMessageBoxInfo(System.Enum messageType,
                                                bool cancel,
                                                MessageBoxDefaultButton defaultButton,
                                                params string[] args)
        {
            MessageBoxInfo info;
            MessageBoxButtons button = MessageBoxButtons.OK;
            MessageBoxIcon icon = MessageBoxIcon.None;
            string message = this.GetMessage(messageType, args);
            switch (this.GetMessageKind(messageType))
            {
                case MessageKind.Exception:
                    icon = MessageBoxIcon.Error;
                    button = MessageBoxButtons.OK;
                    break;
                case MessageKind.Exclamation:
                    icon = MessageBoxIcon.Exclamation;
                    button = MessageBoxButtons.OK;
                    break;
                case MessageKind.Information:
                    icon = MessageBoxIcon.Information;
                    button = MessageBoxButtons.OK;
                    break;
                case MessageKind.Question:
                    icon = MessageBoxIcon.Question;
                    if (cancel)
                    {
                        button = MessageBoxButtons.YesNoCancel;
                    }
                    else
                    {
                        button = MessageBoxButtons.YesNo;
                    }
                    break;
                default:
                    break;
            }
            info = new MessageBoxInfo(message, icon, button, defaultButton);
            return info;
        }

        #endregion
        #region GetMessageKind
        /// <summary>
        /// メッセージ種別を取得
        /// </summary>
        /// <param name="messageType"></param>
        /// <returns></returns>
        public MessageKind GetMessageKind(System.Enum messageType)
        {
            string str = messageType.GetType().FullName.ToLower();

            if (str.IndexOf(".exceptions") > -1)
            {
                return MessageKind.Exception;
            }
            if (str.IndexOf(".exclamations") > -1)
            {
                return MessageKind.Exclamation;
            }
            if (str.IndexOf(".informations") > -1)
            {
                return MessageKind.Information;
            }
            if (str.IndexOf(".questions") > -1)
            {
                return MessageKind.Question;
            }
            return MessageKind.Other;
        }
        #endregion
        #region GetMessage

        /// <summary>
        /// メッセージを取得する
        /// </summary>
        /// <param name="messageType"></param>
        /// <returns></returns>
        public string GetMessage(System.Enum messageType)
        {
            return this._ResManager.GetString(messageType.ToString());
        }

        /// <summary>
        /// メッセージを取得する
        /// </summary>
        /// <param name="messageType"></param>
        /// <param name="Args"></param>
        /// <returns></returns>
        public string GetMessage(object messageType, params string[] Args)
        {
            return string.Format(this._ResManager.GetString(messageType.ToString()), Args);
        }

        /// <summary>
        /// メッセージを取得する
        /// </summary>
        /// <param name="messageType"></param>
        /// <param name="Args"></param>
        /// <returns></returns>
        public string GetByKey(string key)
        {
            return this._ResManager.GetString(key);
        }

        /// <summary>
        /// メッセージを取得する
        /// </summary>
        /// <param name="messageType"></param>
        /// <param name="Args"></param>
        /// <returns></returns>
        public string GetByKey(string key, params string[] Args)
        {
            return string.Format(this._ResManager.GetString(key), Args);
        }

        #endregion
        #region GetException
        /// <summary>
        /// 例外のインスタンスを生成する
        /// </summary>
        /// <param name="ExceptType"></param>
        /// <returns></returns>
        public RJException GetException(System.Enum ExceptType)
        {
            String msg = GetMessage(ExceptType);
            return new RJException(ExceptType, msg);
        }
        /// <summary>
        /// 例外のインスタンスを生成する
        /// </summary>
        /// <param name="ExceptType"></param>
        /// <returns></returns>
        public RJException GetException(System.Enum ExceptType, Exception innerEx)
        {
            String msg = GetMessage(ExceptType);
            return new RJException(ExceptType, msg, innerEx);
        }
        /// <summary>
        /// 例外のインスタンスを生成する
        /// </summary>
        /// <param name="ExceptType">例外のリソースタイプ</param>
        /// <param name="Args">パラメタ変数</param>
        /// <returns></returns>
        public RJException GetException(System.Enum ExceptType, params string[] Args)
        {
            String msg = GetMessage(ExceptType, Args);
            return new RJException(ExceptType, msg);
        }
        /// <summary>
        /// 例外のインスタンスを生成する
        /// </summary>
        /// <param name="ExceptType">例外のリソースタイプ</param>
        /// <param name="Args">パラメタ変数</param>
        /// <param name="innerEx">内部例外</param>
        /// <returns></returns>
        public RJException GetException(System.Enum ExceptType, Exception innerEx, params string[] Args)
        {
            String msg = GetMessage(ExceptType, Args);
            return new RJException(ExceptType, msg, innerEx);
        }

        #endregion
    }
    #endregion
    #region MessageBoxInfo Class
    /// <summary>
    /// メッセージボックスを表示する内容を提供します。
    /// </summary>
    public class MessageBoxInfo
    {
        private MessageBoxButtons _button;
        private MessageBoxDefaultButton _defaultButton;
        private MessageBoxIcon _icon;
        private string _message;
        /// <summary>
        /// インスタンス初期化
        /// </summary>
        /// <param name="message">メッセージ</param>
        /// <param name="icon">アイコン</param>
        /// <param name="button">ボタン</param>
        internal MessageBoxInfo(string message, MessageBoxIcon icon, MessageBoxButtons button)
        {
            this._message = message;
            this._icon = icon;
            this._button = button;
        }
        /// <summary>
        /// インスタンス初期化
        /// </summary>
        /// <param name="message"></param>
        /// <param name="icon"></param>
        /// <param name="button"></param>
        /// <param name="defaultButton"></param>
        internal MessageBoxInfo(string message, MessageBoxIcon icon, MessageBoxButtons button, MessageBoxDefaultButton defaultButton)
        {
            this._message = message;
            this._icon = icon;
            this._button = button;
            this._defaultButton = defaultButton;
        }
        /// <summary>
        /// メッセージボックスボタン
        /// </summary>
        public MessageBoxButtons Button
        {
            get
            {
                return this._button;
            }
        }
        /// <summary>
        /// デフォルトボタン
        /// </summary>
        public MessageBoxDefaultButton DefaultButton
        {
            get
            {
                return this._defaultButton;
            }
        }
        /// <summary>
        /// アイコン
        /// </summary>
        public MessageBoxIcon Icon
        {
            get
            {
                return this._icon;
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
    }

    #endregion




}
