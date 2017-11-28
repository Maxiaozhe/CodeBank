using System;
using System.Collections;
using System.Runtime.InteropServices;

using Microsoft.Win32.Security;
using Microsoft.Win32.Security.Win32Structs;


namespace AceApi
{
	public class PHSecurityDescriptor : SecurityDescriptor
	{
		public byte[] GetBuffer()
		{
			MakeSeflRelative(); // Makes the SD one contiguous buffer.
			int size = Size;
			byte[] Buffer = new byte[size];
			ICustomMarshaler sdm = SecurityDescriptorMarshaler.GetInstance(null);
			IntPtr pSD = sdm.MarshalManagedToNative(this);
			Marshal.Copy(pSD, Buffer, 0, size);
			return Buffer;
		}
        public static SecurityDescriptor GetSecurityDescriptor(byte[] AceBuffer)
        {

            IntPtr SecPtr = Win32.AllocGlobal(AceBuffer.Length);
            Marshal.Copy(AceBuffer, 0, SecPtr, AceBuffer.Length);
            SecurityDescriptor RecSec = new SecurityDescriptor(SecPtr);
            return RecSec;
        }

        // 2007/09/29 tianjian Modify 
        public void LoadSecurity(string owner, string[] users)
        {
            LoadSecurity(owner,users,false);
        }
		public void LoadSecurity(string owner, string[] users, bool useSid)
		{
			try
			{
				SetOwner(owner,useSid);
                AddUsers(users,useSid);
			}
			catch(System.Exception ex)
			{
                throw ex;
			}
		}

        // 2007/09/29 tianjian Modify 
        private void SetOwner(string sOwnerLoginName) 
        {
            SetOwner(sOwnerLoginName, false);
        }
        private void SetOwner(string sOwnerName, bool useSid)
		{
			Sid sid = null;

			try
			{
				sid = new Sid(sOwnerName,useSid);
				SetOwner(sid);
			}
			catch 
			{
                throw;
			}
		}

        // 2007/09/29 tianjian Modify 
        private void AddUsers(string[] users)
        {
            AddUsers(users, false);
        }
        private void AddUsers(string[] users, bool useSid)
		{
			Dacl dacl = new Dacl();
			if (users.Length > 0)
			{
				foreach (string user in users)
				{
					string sOperation = null;
					try
					{
						sOperation = "Creating a sid for: " + user;
						Sid sid = new Sid(user, useSid);
						sOperation = "Creating a new AceAccessAllowed";
						AceAccessAllowed ace = new AceAccessAllowed(sid, (AccessType)(FileAccessType.FILE_READ_DATA | FileAccessType.FILE_READ_ATTRIBUTES));
						sOperation = "Adding the ace to the DACL";
						dacl.AddAce(ace);
					}
					catch 
					{
                        throw;
					}
				}
			}
			SetDacl(dacl);
		}
	}
}
