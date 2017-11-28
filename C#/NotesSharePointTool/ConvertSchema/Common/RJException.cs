using System;
using System.Runtime.Serialization;

namespace RJ.Tools.NotesTransfer.Engines
{
	[Serializable]
	public class RJException:ApplicationException
	{
		#region 内部変数
			private System.Enum _MessageType;
		#endregion
		#region プロパティ
			public System.Enum MessageType
			{
				get { return _MessageType; }
				set { _MessageType = value; }
			}
		#endregion
		#region メソッド
			public RJException(System.Enum msgType, string message)
				: base(message)
			{
				_MessageType = msgType;
			}
			public RJException(System.Enum msgType, string message, Exception innerException)
				: base(message, innerException)
			{
				_MessageType = msgType;
			}

            protected RJException(SerializationInfo info, StreamingContext context)
			{
			}
		#endregion
	
	}

	
}
