using System;
using System.IO;
using System.Security.Cryptography;
namespace RJ.Tools.NotesTransfer.Engines.Security
{
	/// <summary>
	/// 暗号化用モジュール
	/// </summary>
	internal class Encryptor
	{
		#region static 変数
		private static string IV = @"kaOuHZ4QfYil+1/lCgh4gg==";
		private static string KEY = @"Nqwx+Jswm9WPkm46c2k4Xw3cfgLQgbmDSO/dS0hPlJc=";
		#endregion

		/// <summary>
		/// 文字を暗号する
		/// </summary>
		internal static string Encode(string Buffer)
		{
			try
			{
				RijndaelManaged Rijn = new RijndaelManaged();
				byte[] bytIV = Convert.FromBase64String(IV);
				byte[] bytKey = Convert.FromBase64String(KEY);
				byte[] bytBuffer = System.Text.Encoding.UTF8.GetBytes(Buffer);
				string enBuffer = "";
				ICryptoTransform Encrypt =	Rijn.CreateEncryptor(bytKey,bytIV);
				using (MemoryStream stream = new MemoryStream())
				{
					using (CryptoStream enStream = new CryptoStream(stream, Encrypt, CryptoStreamMode.Write))
					{
						enStream.Write(bytBuffer, 0, bytBuffer.Length);
						enStream.FlushFinalBlock();
						byte[] bytencode = stream.ToArray();
						enBuffer = Convert.ToBase64String(bytencode);
					}
				}
				return enBuffer;
			}
			catch (Exception)
			{

				return Buffer;
			}
			
		}

		/// <summary>
		/// 文字の暗号化を解除する
		/// </summary>
		internal static string Decode(string EncodedBuffer)
		{
			try
			{
				byte[] bytIV = Convert.FromBase64String(IV);
				byte[] bytKey = Convert.FromBase64String(KEY);
				byte[] bytBuffer = Convert.FromBase64String(EncodedBuffer);
				string deBuffer = "";
				RijndaelManaged Rijn = new RijndaelManaged();
				ICryptoTransform deCrypt = Rijn.CreateDecryptor(bytKey, bytIV);
				using (MemoryStream stream = new MemoryStream(bytBuffer))
				{
					using (CryptoStream csStream = new CryptoStream(stream, deCrypt, CryptoStreamMode.Read))
					{
						byte[] bytDeBuffer = new byte[(int)bytBuffer.Length];
						csStream.Read(bytDeBuffer, 0, bytBuffer.Length);
						deBuffer = System.Text.Encoding.UTF8.GetString(bytDeBuffer).TrimEnd('\0');
					}
				}
				return deBuffer;
			}
			catch (Exception)
			{
				return EncodedBuffer;
			}
			

		}
	}
}
