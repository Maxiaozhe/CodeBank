using System;
using System.Collections.Generic;

namespace RJ.Tools.NotesTransfer.Engines.Resource
{
    /// <summary>
    /// リソースマネージャを実装する
    /// </summary>
    internal class ResManager
	{

        private static object locker = new object();
		/// <summary>
		/// メッセージリソースマネジャーリスト
		/// </summary>
		private static Dictionary<Type, System.Resources.ResourceManager> _MessageResSet = new Dictionary<Type, System.Resources.ResourceManager>();
		/// <summary>
		/// メッセージリソースマネジャーを取得する
		/// </summary>
		/// <param name="MessageType"></param>
		/// <returns></returns>
        internal static MessageResourceManager GetMessageResourceManager(System.Enum MessageType)
		{
            lock (locker)
            {
                System.Resources.ResourceManager msgManager = null;
                Type baseType = MessageType.GetType();
                if (_MessageResSet.ContainsKey(MessageType.GetType()))
                {
                    msgManager = _MessageResSet[baseType];
                    msgManager.IgnoreCase = true;
                }
                else
                {
                    if (HasResources(baseType))
                    {
                        msgManager = new System.Resources.ResourceManager(baseType);
                        msgManager.IgnoreCase = true;
                        _MessageResSet.Add(baseType, msgManager);
                    }
                    else
                    {
                        return null;
                    }
                }
                return new MessageResourceManager(msgManager);
            }
		}
        /// <summary>
        /// メッセージリソースマネジャーを取得する
        /// </summary>
        /// <param name="MessageType"></param>
        /// <returns></returns>
        internal static MessageResourceManager GetMessageResourceManager(Type type)
        {
            lock (locker)
            {
                System.Resources.ResourceManager msgManager = null;
                if (_MessageResSet.ContainsKey(type))
                {
                    msgManager = _MessageResSet[type];
                    msgManager.IgnoreCase = true;
                }
                else
                {
                    if (HasResources(type))
                    {
                        msgManager = new System.Resources.ResourceManager(type);
                        msgManager.IgnoreCase = true;
                        _MessageResSet.Add(type, msgManager);
                    }
                    else
                    {
                        return null;
                    }
                }
                return new MessageResourceManager(msgManager);
            }
        }
		/// <summary>
		/// リソースファイルが存在するか？
		/// </summary>
		/// <param name="Type"></param>
		/// <returns></returns>
        internal static bool HasResources(Type resType)
		{
            lock (locker)
            {
                string str = resType.FullName + ".resources";
                foreach (string file in resType.Assembly.GetManifestResourceNames())
                {
                    if (file.ToLower() == str.ToLower())
                    {
                        return true;
                    }
                }
                return false;
            }
		}
		/// <summary>
		/// リソースを解放する
		/// </summary>
        internal static void ReleaseResources()
		{
            lock (locker)
            {
                foreach (Type key in _MessageResSet.Keys)
                {
                    System.Resources.ResourceManager manager = _MessageResSet[key];
                    if (manager != null)
                    {
                        manager.ReleaseAllResources();
                    }
                }
                _MessageResSet.Clear();
            }
		}

	}
}
