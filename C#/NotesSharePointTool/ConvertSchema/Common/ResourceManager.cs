using System;
using System.Windows.Forms;
namespace RJ.Tools.NotesTransfer.Engines.Resource
{
	public class ResourceManager
    {
        #region private property
        private static string Caption
        {
            get
            {
                return ResourceManager.GetMessage(Resources.StringTable.ToolCaption);
            }
        }

#endregion 

#region method
	#region GetException
		public static RJException GetException(System.Enum ExceptType)
		{
            RJException exception;
			MessageResourceManager manager = ResManager.GetMessageResourceManager(ExceptType);
			exception = manager.GetException(ExceptType);
			return exception;
		}
        public static RJException GetException(System.Enum ExceptType, Exception innerEx)
		{
            RJException exception;
			MessageResourceManager manager = ResManager.GetMessageResourceManager(ExceptType);
			exception = manager.GetException(ExceptType ,innerEx);
			return exception;
		}

        public static RJException GetException(System.Enum ExceptType, params string[] args)
		{
            RJException exception;
			MessageResourceManager manager = ResManager.GetMessageResourceManager(ExceptType);
			exception = manager.GetException(ExceptType, args);
			return exception;
		}
        public static RJException GetException(System.Enum ExceptType, Exception innerEx, params string[] args)
		{
            RJException exception;
			MessageResourceManager manager = ResManager.GetMessageResourceManager(ExceptType);
			exception = manager.GetException(ExceptType,innerEx, args);
			return exception;
		}
	#endregion

	#region GetMessage
		public static string GetMessage(Enum MessageType)
		{
			MessageResourceManager manager = ResManager.GetMessageResourceManager(MessageType);
			string message = manager.GetMessage(MessageType);
			return message;
		}

		public static string GetMessage(Enum MessageType, params string[] args)
		{
			MessageResourceManager manager = ResManager.GetMessageResourceManager(MessageType);
			string message = manager.GetMessage(MessageType, args);
			return message;
		}

	
	#endregion

        #region GetStringByKey

        public static string GetStringByKey(string key, Type type)
        {
            MessageResourceManager manager = ResManager.GetMessageResourceManager(type);
            string message = manager.GetByKey(key);
            return message;
        }

        public static string GetStringByKey(string key, Type type, params string[] args)
        {
            MessageResourceManager manager = ResManager.GetMessageResourceManager(type);
            string message = manager.GetByKey(key, args);
            return message;
        }

	#endregion

	#region ShowMessage
		public static void ShowMessage(IWin32Window owner, Enum MessageType)
		{
			MessageResourceManager manager = ResManager.GetMessageResourceManager(MessageType);
			MessageBoxInfo info=manager.GetMessageBoxInfo(MessageType);
			if (owner == null)
			{
				MessageBox.Show(info.Message, Caption, info.Button,info.Icon);
			}
			else
			{
				MessageBox.Show(owner, info.Message, Caption, info.Button, info.Icon);
			}
		}
		public static void ShowMessage(IWin32Window owner, Enum MessageType,params string[] args)
		{
			MessageResourceManager manager = ResManager.GetMessageResourceManager(MessageType);
			MessageBoxInfo info = manager.GetMessageBoxInfo(MessageType,args);
			if (owner == null)
			{
				MessageBox.Show(info.Message, Caption, info.Button, info.Icon);
			}
			else
			{
				MessageBox.Show(owner, info.Message, Caption, info.Button, info.Icon);
			}
		}
		public static DialogResult ShowMessage(IWin32Window owner, Enum MessageType,MessageBoxDefaultButton defaultButton, params string[] args)
		{
			MessageResourceManager manager = ResManager.GetMessageResourceManager(MessageType);
			MessageBoxInfo info = manager.GetMessageBoxInfo(MessageType, false, defaultButton,args);
			if (owner == null)
			{
				return MessageBox.Show(info.Message, Caption, info.Button,info.Icon,info.DefaultButton );
			}
			else
			{
				return MessageBox.Show(owner, info.Message, Caption, info.Button, info.Icon, info.DefaultButton);
			}
		}
		public static void ShowMessage(IWin32Window owner, Exception ex)
		{
			if (owner == null)
			{
				MessageBox.Show(ex.Message, Caption, MessageBoxButtons.OK , MessageBoxIcon.Error);
			}
			else
			{
				MessageBox.Show(owner, ex.Message, Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

	#endregion
#endregion

	}
}
