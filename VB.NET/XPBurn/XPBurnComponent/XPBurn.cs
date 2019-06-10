using System;
using System.Windows.Forms;
using XPBurn;
using XPBurn.COM;
using System.Diagnostics;
using System.Collections;
using System.Runtime.InteropServices;
using System.IO;
using System.Threading;

namespace XPBurn
{
	/// <summary>
	/// This class can burn DATA CDs.  Simply instantiate a version, call <see cref="AddFile(System.String, System.String)" /> 
	/// with the files to be written, and finally call <see cref="RecordDisc(System.Boolean, System.Boolean)" /> to write the 
	/// data to the CD.
	/// </summary>
	public class XPBurnCD
	{
    #region Private Fields

    // Property backing stores
    
    unsafe uint** fProgressCookie;
    XPBurnIStorage fRootStorage;    
    bool fIsBurning;
    bool fIsErasing;
    RecordType fActiveFormat;
    SupportedRecordTypes fSupportedFormats;
    int fBurnerDrive;
    string fVendor;
    string fProductID;
    string fRevision;
    bool fSimulate;
    bool fEjectAfterBurn;
    RecorderType fRecorderType;

    // End property backing stores

    // Backing stores which need to be cloned before returning

    ArrayList fMusicRecorderDrives;
    ArrayList fDataRecorderDrives;
    Hashtable fFiles;

    // END backing stores which need to be cloned before returning

    // Internal fields

    IDiscMaster fDiscMaster;
    IDiscRecorder fActiveRecorder;
    IJolietDiscMaster fDataDiscWriter;
    IRedbookMaster fMusicDiscWriter;
    // TODO: Should be List<IDiscRecorder>
    ArrayList fMusicRecorders;
    // TODO: Should be List<IDiscRecorder>
    ArrayList fDataRecorders;
    byte[] fBuffer;
    ArrayList fFileNames;
    int fFileListOffset;
    bool fFullErase;
    XPBurnMessageQueue fMessageQueue;

    #endregion

    #region Private Methods

    private void RecordDiscThread()
    {
      fDiscMaster.SetActiveDiscRecorder(fActiveRecorder);
      CreateIStorage();
      fDataDiscWriter.AddData(fRootStorage, 1);
      fDiscMaster.RecordDisc(fSimulate, fEjectAfterBurn);
      fIsBurning = false;
    }

    private void EnumerateDiscRecorders()
    {
      Guid guidFormatID;
      IUnknown pUnknown;
      IEnumDiscRecorders pEnumDiscRecorders;
      IDiscRecorder pRecorder;
      string pbstrPath;
      uint pcFetched;

      if ((fSupportedFormats == SupportedRecordTypes.sfBoth) || (fSupportedFormats == SupportedRecordTypes.sfData))
      {
        guidFormatID = GUIDS.IID_IJolietDiscMaster;
        fDiscMaster.SetActiveDiscMasterFormat(ref guidFormatID, out pUnknown);

        fDataDiscWriter = pUnknown as IJolietDiscMaster;
        if (fDataDiscWriter != null)
        {
          fDiscMaster.EnumDiscRecorders(out pEnumDiscRecorders);
          pcFetched = 1;
          pEnumDiscRecorders.Next(1, out pRecorder, out pcFetched);
          while(pcFetched == 1)
          {
            fDataRecorders.Add(pRecorder);
            pRecorder.GetPath(out pbstrPath);
            fDataRecorderDrives.Add(pbstrPath);
            pEnumDiscRecorders.Next(1, out pRecorder, out pcFetched);
          }
        }
      }
      
      if (fDataRecorders.Count == 0)
      {
          throw new XPBurnException(XPBurn.Resource.NotCDRW);
      }                                                            
    }
    
    
    private void SetDrive(int driveIndex)
    {
      switch(fActiveFormat)
      {
        case RecordType.afMusic:
          if ((driveIndex > fMusicRecorders.Count) || (driveIndex < 0))
          {
            throw new XPBurnException(String.Format(Resource.CantSetDriver,driveIndex.ToString()));
          }

          fActiveRecorder = (IDiscRecorder)fMusicRecorders[driveIndex];

          break;
        case RecordType.afData:
          if ((driveIndex > fDataRecorders.Count) || (driveIndex < 0))
          {
              throw new XPBurnException(String.Format(Resource.CantSetDriver, driveIndex.ToString()));
          }

          fActiveRecorder = (IDiscRecorder)fDataRecorders[driveIndex];

          break;     
      }

      fCancel = false;
      fBurnerDrive = driveIndex;

      fActiveRecorder.GetDisplayNames(out fVendor, out fProductID, out fRevision);

      int typeCode;
      fActiveRecorder.GetRecorderType(out typeCode);

      switch(typeCode)
      {
        case 0x1:
          fRecorderType = RecorderType.rtCDR;
          break;
        case 0x2:
          fRecorderType = RecorderType.rtCDRW;
          break;
      }
    }

   

    private void CreateIStorage()
    {
      fRootStorage = new XPBurnIStorage("RootStorage");
      
      fFileNames = new ArrayList(fFiles.Count);
      foreach(string filename in fFiles.Keys)
      {
        fFileNames.Add(filename);
      }

      fFileListOffset = 0;
      fFileNames.Sort();

      fBuffer = new byte[1048576];
      while(fFileListOffset < fFileNames.Count)
      {
        StreamHelper(fRootStorage, "", (string)fFileNames[fFileListOffset]);
      }
    }

    private void WriteStream(XPBurnIStorage storage, string streamName)
    {
      string fileToWrite = (string)fFileNames[fFileListOffset];

      if (File.Exists(fileToWrite))
      {
        string shortName = Path.GetFileName(streamName);
        storage.CreateFileStream(fileToWrite, shortName);
      }
    }

    private void StreamHelper(XPBurnIStorage storage, string path, string filename)
    {
      string nestedFilename;
      string subStorageName;
      string pathRoot = "";
      string filePath;
      int index;
      XPBurnIStorage newStorage;      

      if (Path.IsPathRooted(filename))
      {
        pathRoot = Path.GetPathRoot(filename);
        filePath = filename.Remove(filename.IndexOf(pathRoot), pathRoot.Length);        
      }
      else
        filePath = filename;
     
      index = filePath.IndexOf(Path.DirectorySeparatorChar);
      if (index != -1)
      {
        nestedFilename = filePath.Substring(index + 1, filePath.Length - (index + 1));
        subStorageName = filePath.Substring(0, index);

        newStorage = storage.CreateStorageDirectory(subStorageName);

        StreamHelper(newStorage, path + subStorageName + Path.DirectorySeparatorChar, nestedFilename);
      }
      else
      {
        WriteStream(storage, filePath);
        fFileListOffset++;
      }
      if (fFileListOffset < fFileNames.Count)
      {
        if (path != "")
        {
          nestedFilename = (string)fFiles[fFileNames[fFileListOffset]];
          index = nestedFilename.IndexOf(path);
          if (index != -1)
          {
            StreamHelper(storage, path, nestedFilename.Substring(index + path.Length, nestedFilename.Length - (index + path.Length)));
          }
        }
      }
    }

    #endregion

    #region Internal Fields

    internal bool fCancel;

    #endregion

    #region Constructors

    /// <summary>
    /// The constructor for the burn component.  This call does a lot of work under the covers,
    /// including communicating with imapi to find out whether there is an XP compatible cd drive attached.
    /// </summary>
    unsafe public XPBurnCD()
    {
      IEnumDiscMasterFormats pEnumDiscFormats;
      uint pcFetched;
      Guid guidFormatID;
     
      fCancel = false;
      fIsBurning = false;
      uint cookieValue = (uint)10;
      uint* tempCookie = &cookieValue;      
      fProgressCookie = &tempCookie;
    
      Debug.WriteLine(@"8/30/2003 6:59p.m. version 1");

      fMessageQueue = new XPBurnMessageQueue(this);

      fMusicDiscWriter = null;
      fMusicRecorderDrives = new ArrayList();
      fMusicRecorders = new ArrayList();
      fDataDiscWriter = null;
      fDataRecorderDrives = new ArrayList();
      fDataRecorders = new ArrayList();
      
      fFiles = new Hashtable();

      try
      {
        fDiscMaster = (IDiscMaster)new MSDiscMasterObj();        
      }
      catch(COMException)
      {
        throw new XPBurnException(Resource.NoMAPI);
      }

      fDiscMaster.Open();
            
      fDiscMaster.ProgressAdvise(new XPBurnProgressEvents(fMessageQueue), fProgressCookie);     

      fDiscMaster.EnumDiscMasterFormats(out pEnumDiscFormats);

      pcFetched = 1;
      while(pcFetched == 1)
      {
        pEnumDiscFormats.Next(1, out guidFormatID, out pcFetched);
        if (guidFormatID == GUIDS.IID_IJolietDiscMaster)
        {
          fSupportedFormats = ((SupportedRecordTypes)((int)fSupportedFormats | 1));
        }
        else
        {
          if (guidFormatID == GUIDS.IID_IRedbookDiscMaster)
          {
            fSupportedFormats = ((SupportedRecordTypes)((int)fSupportedFormats | 2));
          }
        }
      }

      if (fSupportedFormats == SupportedRecordTypes.sfNone)
      {
        fDiscMaster.Close();
        throw new XPBurnException(Resource.NoSupport);
      }

     
      EnumerateDiscRecorders();

      fBurnerDrive = 0;
      fActiveFormat = RecordType.afData;

      SetDrive(fBurnerDrive);
    }

    #endregion

    #region Public Events

    /// <summary>
    /// This event occurs when some sort of plug and play activity has been detected.  
    /// It may change both the number of CD recorders, the number of recorder drives, and possibly, 
    /// it may indicate the removal of the recorder on which the component is currently acting.
    /// </summary>
    public event NotifyPnPActivity RecorderChange;
    /// <summary>
    /// This event occurs as the first step of the burn process, while data which has been added through 
    /// AddFile is being staged.
    /// </summary>
    public event NotifyCDProgress AddProgress;
    /// <summary>
    /// This event is the third step in the burn process (for data CDs), and is the main burning phase.  
    /// While this phase executes, the staged area will be written to the CD.
    /// </summary>
    public event NotifyCDProgress BlockProgress;
    /// <summary>
    /// This event is the third step in the burn process (for music CDs).  Currently it will never be invoked.
    /// </summary>
    public event NotifyCDProgress TrackProgress;
    /// <summary>
    /// This event is the second step in the burn process, it is called once with an estimated time it will take 
    /// before the recorder starts writing data to the CD.
    /// </summary>
    public event NotifyEstimatedTime PreparingBurn;
    /// <summary>
    /// This event occurs as the fourth and final step of the burn process.  It is called once with an estimated time 
    /// it will take before the burn is completely finished (it is during this step that the recorder is writing the 
    /// table of contents of the CD).
    /// </summary>
    public event NotifyEstimatedTime ClosingDisc;
    /// <summary>
    /// This event occurs after all four stages of the burn process have completed.  
    /// After this event occurs the burner may burn again.
    /// </summary>
    public event NotifyCompletionStatus BurnComplete;
    /// <summary>
    /// This event occurs after an erase has completed.
    /// </summary>
    public event NotifyCompletionStatus EraseComplete;

    #endregion

    #region Public Properties

    /// <summary>
    /// Reads or writes the current cancel state of the component.  If this value is set to true, 
    /// then RecordDisc will stop executing and throw an exception indicating that the user cancelled the burn.
    /// </summary>
    public bool Cancel
    {
      get { return fCancel; }
      set { fCancel = value; }
    }

    /// <summary>
    /// Reads whether the currently selected BurnerDrive is erasing a CD.  Notice that this value is only
    /// set by this component, so if another program is erasing a CD on the currently selected drive this value
    /// will be set to false.  This property is read-only; however, you can use the Cancel property to cancel 
    /// an active erase (so long as it was initiated by this component).
    /// </summary>
    public bool IsErasing
    {
      get { return fIsErasing; }
    }

    /// <summary>
    /// Reads whether the currently selected BurnerDrive is burning a CD.  Notice that this value is only 
    /// set by this component, so if another program is writing to a CD on the currently selected drive this 
    /// value will be set to false.  This property is read-only; however, you can use the Cancel property to 
    /// cancel an active burn (so long as it was initiated by this component).
    /// </summary>
    public bool IsBurning
    {
      get { return fIsBurning; }      
    }

    // TODO: Should really return List<string>
    /// <summary>
    /// Reads a <b>copy</b> of the recorder drives available on the system.  
    /// This may change in the same way that the NumberOfDrives property may change.  
    /// Use the values returned in this ArrayList to set the BurnerDrive property.
    /// </summary>
    public ArrayList RecorderDrives
    {
      get 
      { 
        ArrayList recorderDrives = null, resultDrives;

        switch(fActiveFormat)
        {
          case RecordType.afMusic:
            recorderDrives = fMusicRecorderDrives;
            break;
          case RecordType.afData:
            recorderDrives = fDataRecorderDrives;
            break;
        }

        resultDrives = new ArrayList(recorderDrives.Count);
        foreach(string s in recorderDrives)
        {
          resultDrives.Add(s.Clone());
        }
  
        return resultDrives;
      }
    }

    /// <summary>
    /// Reads the current number of drives on the system.  It's possible that this number will change throughout 
    /// the course of the existence of the component if a USB device (for example), is added or removed.  
    /// The event (RecorderChange) is meant to indicate that this may have happened.
    /// </summary>
    public int NumberOfDrives
    {
      get 
      {
        int result = 0;

        switch(fActiveFormat)
        {
          case RecordType.afMusic:
            result = fMusicRecorderDrives.Count;
            break;
          case RecordType.afData:
            result = fDataRecorderDrives.Count;
            break;
        }

        return result;
      }
    }

    /// <summary>
    /// Reads or writes the active format for recording.  This is largely useless in the current implementation 
    /// as the only valid recording type is afData (afMusic is currently unsupported).
    /// </summary>
    public RecordType ActiveFormat
    {
      get { return fActiveFormat; } 
      set 
      {
        Guid formatGUID;
        IUnknown pUnknown;

        if (value == RecordType.afMusic)
        {
          if ((fSupportedFormats == SupportedRecordTypes.sfMusic) || (fSupportedFormats == SupportedRecordTypes.sfBoth))
          {
            formatGUID = GUIDS.IID_IRedbookDiscMaster;
          }
          else
          {
            throw new XPBurnException(Resource.NoafMusic);
          }
        }
        else
        {
          if (value == RecordType.afData)
          {
            formatGUID = GUIDS.IID_IJolietDiscMaster;
          }
          else
          {
              throw new XPBurnException(Resource.NoafData);
          }
        }

        fDiscMaster.SetActiveDiscMasterFormat(ref formatGUID, out pUnknown);

        switch(value)
        {
          case RecordType.afData:
            fDataDiscWriter = pUnknown as IJolietDiscMaster;
            if (fDataDiscWriter == null)
            {
              throw new XPBurnException(Resource.NoSupportFormat);
            }
            break;
          case RecordType.afMusic:
            fMusicDiscWriter = pUnknown as IRedbookMaster;
            if (fMusicDiscWriter == null)
            {
                throw new XPBurnException(Resource.NoSupportFormat);
            }
            break;
        }        

      }
    }

    // TODO: Should really return List<string>
    /// <summary>
    /// Reads a copy of the list of files that are currently set to be burned to CD.  
    /// Changing this list will not affect the list stored internally by the component.  
    /// In order to change that list, use the AddFile and RemoveFile procedures.
    /// </summary>
    public ArrayList FilesToBrun
    {
      get 
      {
        ArrayList resultFileList;

        resultFileList = new ArrayList(fFiles.Count);
        foreach(string s in fFiles.Values)
        {
          resultFileList.Add(s);
        }
  
        return resultFileList;       
      }
    }

    /// <summary>
    /// Reads or writes the current burner drive.  Depending on the computer that 
    /// the component is running on the string returned may either be a drive letter, 
    /// or a fully qualified device name (/dev/CDRom1).  In order to write to this value, 
    /// use one of the strings returned by RecorderDrives.
    /// </summary>
    public string BurnerDrive
    {
      get 
      {
        ArrayList recorderDrives = null;

        switch(fActiveFormat)
        {
          case RecordType.afData:
            recorderDrives = fDataRecorderDrives;
            break;
          case RecordType.afMusic:
            recorderDrives = fMusicRecorderDrives;
            break;
        }

        if (recorderDrives.Count > 0)
        {
          return (string)recorderDrives[fBurnerDrive];
        }
        else
        {
          throw new XPBurnException("There are no drives on this system which burn the active format");
        }
      }
      set 
      { 
        ArrayList recorderDrives = null;
        int index;

        switch(fActiveFormat)
        {
          case RecordType.afMusic:
            recorderDrives = fMusicRecorderDrives;
            break;
          case RecordType.afData:
            recorderDrives = fDataRecorderDrives;
            break;
        }
        
        if (recorderDrives.Count > 0)
        {
          index = recorderDrives.IndexOf(value);
          if (index != -1)
          {
            SetDrive(index);
          }
          else
          {
            throw new XPBurnException("Unable to set drive to " + value + ". It either does not exist or cannot burn the current format");
          }
        }
        else
        {
          throw new XPBurnException("There are no drives on this system which burn the active format");
        }

      }
    }

    /// <summary>
    /// Reads the vendor of the currently selected recorder.  
    /// This string is set by the manufacturer of the recorder.
    /// </summary>
    public string Vendor
    {
      get { return fVendor; }
    }

    /// <summary>
    /// Reads the product ID of the currently selected recorder.  
    /// This string is set by the manufacturer of the recorder. 
    /// </summary>
    public string ProductID
    {
      get { return fProductID; }
    }

    /// <summary>
    /// Reads the revision of the currently selected recorder.  
    /// This string is set by the manufacturer of the recorder (through the driver).
    /// </summary>
    public string Revision
    {
      get { return fRevision; } 
    }

    /// <summary>
    /// Reads the currently selected burner's type.  This may be rtCDR or rtCDRW.  
    /// If it's rtCDRW then the recorder supports erasing media, if it's rtCDR then it doesn't.
    /// </summary>
    public RecorderType RecorderType
    {
      get { return fRecorderType; }
    }

    /// <summary>
    /// Reads information about the media inserted in the currently selected recorder.  
    /// This information includes whether the CD is blank, writable, erasable (RW), or usable.
    /// </summary>
    public Media MediaInfo
    {
      get 
      { 
        int mediaType, mediaFlags;
        Media result;

        if ((fIsErasing) || (fIsBurning))
          throw new XPBurnException("It's not possible to get media information while burning or erasing the media");

        fActiveRecorder.OpenExclusive();
        try
        {
          fActiveRecorder.QueryMediaType(out mediaType, out mediaFlags);
          result.isBlank = ((mediaFlags & CONSTS.MEDIA_BLANK) == CONSTS.MEDIA_BLANK);
          result.isReadWrite = ((mediaFlags & CONSTS.MEDIA_RW) == CONSTS.MEDIA_RW);
          result.isWritable = ((mediaFlags & CONSTS.MEDIA_WRITABLE) == CONSTS.MEDIA_WRITABLE);
          result.isUsable = !((mediaFlags & CONSTS.MEDIA_UNUSABLE) == CONSTS.MEDIA_UNUSABLE);

          return result;
        }
        finally
        {
          fActiveRecorder.Close();
        }
      }
    }

    /// <summary>
    /// Reads the maximum write speed for the currently selected recorder.  
    /// This number will be 4, 8, 10, etc. representing a 4x, 8x, or 10x CD recorder drive.
    /// </summary>
    unsafe public uint MaxWriteSpeed
    {
      get 
      { 
        IPropertyStorage ppPropStg;
        PROPSPEC rgPropID;
        PROPVARIANT rgPropVar;
        string propertyID;

        propertyID = "MaxWriteSpeed";
        fActiveRecorder.GetRecorderProperties(out ppPropStg);
        rgPropID = new PROPSPEC();
        rgPropVar = new PROPVARIANT();
        rgPropID.ulKind = 0;
        rgPropID.__unnamed.lpwstr = (char*)Marshal.StringToCoTaskMemUni(propertyID);        

        try
        {
          ppPropStg.ReadMultiple(1, ref rgPropID, ref rgPropVar);
          return rgPropVar.__unnamed.__unnamed.__unnamed.ulVal;
        }
        finally
        {
          Marshal.FreeCoTaskMem(new IntPtr(rgPropID.__unnamed.lpwstr));
        }
      }
    }

    // TODO: Refactor getters into single method which takes string for property name
    /// <summary>
    /// Reads the currently selected recorder's write speed.  This is usually equal to the MaxWriteSpeed, however, 
    /// it is occasionally lower if the CD recorder is unreliable at it's max speed.  
    /// This property will be read/write in the future.
    /// </summary>
    unsafe public uint WriteSpeed
    {
      get 
      { 
        IPropertyStorage ppPropStg;
        PROPSPEC rgPropID;
        PROPVARIANT rgPropVar;
        string propertyID;

        propertyID = "WriteSpeed";
        fActiveRecorder.GetRecorderProperties(out ppPropStg);
        rgPropID = new PROPSPEC();
        rgPropVar = new PROPVARIANT();
        rgPropID.ulKind = 0;
        rgPropID.__unnamed.lpwstr = (char*)Marshal.StringToCoTaskMemUni(propertyID);        

        try
        {
          ppPropStg.ReadMultiple(1, ref rgPropID, ref rgPropVar);          
          return rgPropVar.__unnamed.__unnamed.__unnamed.ulVal;
        }
        finally
        {
          Marshal.FreeCoTaskMem(new IntPtr(rgPropID.__unnamed.lpwstr));
        }
      }
    }

    /// <summary>
    /// Reads the current recorder setting for the number of blank audio blocks to put in 
    /// between tracks when writing a music CD.  The default value is 150.
    /// </summary>
    unsafe public byte AudioGapSize
    {
      get 
      { 
        IPropertyStorage ppPropStg;
        PROPSPEC rgPropID;
        PROPVARIANT rgPropVar;
        string propertyID;

        propertyID = "AudioGapSize";
        fActiveRecorder.GetRecorderProperties(out ppPropStg);
        rgPropID = new PROPSPEC();
        rgPropVar = new PROPVARIANT();
        rgPropID.ulKind = 0;
        rgPropID.__unnamed.lpwstr = (char*)Marshal.StringToCoTaskMemUni(propertyID);        

        try
        {
          ppPropStg.ReadMultiple(1, ref rgPropID, ref rgPropVar);
          return rgPropVar.__unnamed.__unnamed.__unnamed.bVal;
        }
        finally
        {
          Marshal.FreeCoTaskMem(new IntPtr(rgPropID.__unnamed.lpwstr));
        }
      }
    }


    // BEGIN: Media information properties

    /// <summary>
    /// Reads the volume name of the CD in the currently selected recorder.  
    /// This property will be read/write in the future.
    /// </summary>
    unsafe public string VolumeName
    {
      get 
      { 
        IPropertyStorage ppPropStg;
        PROPSPEC rgPropID;
        PROPVARIANT rgPropVar;
        string propertyID;

        propertyID = "VolumeName";
        fDataDiscWriter.GetJolietProperties(out ppPropStg);
        rgPropID = new PROPSPEC();
        rgPropVar = new PROPVARIANT();
        rgPropID.ulKind = 0;        
        rgPropID.__unnamed.lpwstr = (char*)Marshal.StringToCoTaskMemUni(propertyID);        

        try
        {          
          ppPropStg.ReadMultiple(1, ref rgPropID, ref rgPropVar);
          return Marshal.PtrToStringBSTR(new IntPtr(rgPropVar.__unnamed.__unnamed.__unnamed.bstrVal));
        }
        finally
        {
          Marshal.FreeCoTaskMem(new IntPtr(rgPropID.__unnamed.lpwstr));
          Marshal.FreeBSTR(new IntPtr(rgPropVar.__unnamed.__unnamed.__unnamed.bstrVal));
        }
      }
    }

    /// <summary>
    /// Reads the amount of space on the disc currently inserted in the recorder.
    /// </summary>
    public int DiscSpace
    {
      get 
      { 
        int pnBlocks, pnBlockBytes;

        if (fActiveFormat == RecordType.afData)
        {
          fDataDiscWriter.GetTotalDataBlocks(out pnBlocks);
          fDataDiscWriter.GetDataBlockSize(out pnBlockBytes);

          return pnBlocks * pnBlockBytes;
        }
        else
        {
            throw new XPBurnException(Resource.CantGetDickSize);
        }
      }
    }

    /// <summary>
    /// Reads the amount of free disc space on a given CD.  
    /// Notice that this number doesn't change based on the files which are currently in the file table 
    /// (but not burned to CD).  
    /// </summary>
    public int FreeDiscSpace
    {
      get 
      {
        int pnBlocks, pnBlockBytes;

        if (fActiveFormat == RecordType.afData)
        {
          fDataDiscWriter.GetUsedDataBlocks(out pnBlocks);
          fDataDiscWriter.GetDataBlockSize(out pnBlockBytes);
          return pnBlocks * pnBlockBytes;
        }
        else
        {
          throw new XPBurnException(Resource.CantGetDickSize);
        }
      }
    }

    // END: Media information properties

    // BEGIN: NYI Advanced properties
    // TODO: Impelement these properties
    
    // property Sessions
    // property LastTrack
    // property StartTrack
    // property NextWritable
    // property FreeBlocks
    // property TotalSize
   
    // END: NYI Advanced properties

    #endregion   

    #region Protected Internal methods
        
    /// <summary>
    /// This method is called when some Plug and Play activity has occurred.  This may mean that the set of discs available has changed, it may mean that the disc has been completely removed from the system.
    /// </summary>
    protected internal void OnRecorderChange()
    {
      EnumerateDiscRecorders();

      NotifyPnPActivity tempDel = RecorderChange;
      if (tempDel != null)
        tempDel();
    }

    /// <summary>
    /// This method is called periodically when burning either a music or data disc to report progress on buffering the data.  In invokes <see cref="AddProgress"/>.
    /// </summary>
    /// <param name="nCompletdSteps">The number of steps that have been completed.</param>
    /// <param name="nTotalSteps">The total number of steps required to finish adding all of the data to the disc.</param>
    protected internal void OnAddProgres(int nCompletdSteps, int nTotalSteps)
    {
      NotifyCDProgress tempDel = AddProgress;
      if (tempDel != null)
        tempDel(nCompletdSteps, nTotalSteps);
    }

    /// <summary>
    /// This method is called periodically when burning a data disc to report progress on the blocks being burned.  It invokes <see cref="BlockProgress"/>
    /// </summary>
    /// <param name="nCompletedSteps">The number of stpes that have been completed.</param>
    /// <param name="nTotalSteps">The total number of steps required to burn all of the blocks.</param>
    protected internal void OnBlockProgress(int nCompletedSteps, int nTotalSteps)
    {
      NotifyCDProgress tempDel = BlockProgress;
      if (tempDel != null)
        tempDel(nCompletedSteps, nTotalSteps);
    }

    /// <summary>
    /// This method is called periodically when burning a music disc to report progress on the tracks being burned.  It invokes <see cref="TrackProgress"/>.
    /// </summary>
    /// <param name="nCompletedSteps">The number of steps that have been completed.</param>
    /// <param name="nTotalSteps">The number of steps in the entire track burning process.</param>
    protected internal void OnTrackProgress(int nCompletedSteps, int nTotalSteps)
    {
      NotifyCDProgress tempDel = TrackProgress;
      if (tempDel != null)
        tempDel(nCompletedSteps, nTotalSteps);
    }

    /// <summary>
    /// This method is called with an esimated time of how long it will take to prepare the media for burning.  It invokes <see cref="PreparingBurn"/>.
    /// </summary>
    /// <param name="nEstimatedSeconds">The estimated number of seconds required to prepare the media for burning.</param>
    protected internal void OnPreparingBurn(int nEstimatedSeconds)
    {
      NotifyEstimatedTime tempDel = PreparingBurn;
      if (tempDel != null)
        tempDel(nEstimatedSeconds);
    }

    /// <summary>
    /// This method is called when a closing operation has finished.  It invoke <see cref="ClosingDisc"/>.
    /// </summary>
    /// <param name="nEstimatedSeconds">The estimated number of seconds required to finish closing the disc.</param>
    protected internal void OnClosingDisc(int nEstimatedSeconds)
    {
      NotifyEstimatedTime tempDel = ClosingDisc;
      if (tempDel != null)
        tempDel(nEstimatedSeconds);
    }

    /// <summary>
    /// This method is called when a burn operation has finished.  It invokes <see cref="BurnComplete"/>.
    /// </summary>
    /// <param name="status">The HRESULT that has been returned by the underlying IMAPI call.</param>
    protected internal void OnBurnComplete(uint status)
    {
      NotifyCompletionStatus tempDel = BurnComplete;
      if (tempDel != null)
        tempDel(status);
    }

    /// <summary>
    /// This method is called when an erase operation has finished.  It invokes <see cref="EraseComplete"/>.
    /// </summary>
    /// <param name="status">The HRESULT that has been returned by the underlying IMAPI call.</param>
    protected internal void OnEraseComplete(uint status)
    {
      NotifyCompletionStatus tempDel = EraseComplete;
      if (tempDel != null)
        tempDel(status);
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Ejects the CD tray.  This cannot be called when the CD Writer is burning or erasing a CD.
    /// </summary>
    public void Eject()
    {
      if ((fIsErasing) || (fIsBurning))
        throw new XPBurnException(Resource.CantEject);

      fActiveRecorder.OpenExclusive();
      try
      {
        fActiveRecorder.Eject();
      }
      finally
      {
        fActiveRecorder.Close();
      }
    }

    private void EraseDiscThread()
    {
      fActiveRecorder.OpenExclusive();
      try
      {        
        fActiveRecorder.Erase(fFullErase);
      }
      finally
      {
        fActiveRecorder.Close();
      }
      fIsErasing = false;
      fMessageQueue.BeginInvoke(new NotifyCompletionStatus(fMessageQueue.OnEraseComplete), new object[] { (uint)0 });
    }

    /// <summary>
    /// Erases the CD if the recorder is a CDRW and the media type is read write.
    /// </summary>
    /// <param name="eraseType">Either a quick or full delete</param>
    public void Erase(EraseKind eraseType)
    {
      if ((fIsErasing) || (fIsBurning))
        throw new XPBurnException(Resource.BurningOrErasing);

      if ((fRecorderType == RecorderType.rtCDRW) && (MediaInfo.isReadWrite))
      {
        fFullErase = (eraseType == EraseKind.ekFull);
        Thread eraseThread = new Thread(new ThreadStart(EraseDiscThread));
        fIsErasing = true;
        eraseThread.Start();
      }
      else
      {
        throw new XPBurnException(Resource.CantErase);
      }
    }

    /// <summary>
    /// Adds a file to a list that will written to the CD when <see cref="RecordDisc(System.Boolean, System.Boolean)" /> is called
    /// </summary>
    /// <param name="filename">The fully qualified path and filename of the file to burn to CD</param>
    /// <param name="nameOnCD">The relative name of the file to write to the CD</param>
    public void AddFile(string filename, string nameOnCD)
    {
      string cdName, root;

      if (fIsBurning)
        throw new XPBurnException(Resource.CantChangeFile);

      if ((filename == null) || (nameOnCD == null) || (filename == "") || (nameOnCD == ""))
      {
        throw new ArgumentException(Resource.NotFileName);
      }

      if (File.Exists(filename))
      {                
        root = Path.GetPathRoot(nameOnCD);
        cdName = nameOnCD.Substring(root.Length, nameOnCD.Length - root.Length);
        fFiles.Add(filename, cdName);
      }
      else
      {
        throw new FileNotFoundException(String.Format(Resource.NotExistsFile,filename));
      }
    }
    /// <summary>
    /// Clear Burn Files
    /// </summary>
    public void ClearFiles()
    {
        if (fFiles != null)
        {
            fFiles.Clear();
        }
    }
    /// <summary>
    /// Removes a file from the list to be burned (executes in O(1)).  This file
    /// must have previously been added via AddFile
    /// </summary>
    /// <param name="filename">The name of the file on disk to be removed</param>    
    public void RemoveFile(string filename)
    {      
      if (filename != null)
      {
        if (fFiles.ContainsKey(filename))
        {
          fFiles.Remove(filename);
        }
      }    
    }

    /// <summary>
    /// Use this method to actually burn the files added through AddFile to the CD.
    /// </summary>
    /// <remarks>Make sure that there is media in the CD burner before calling this method</remarks>
    /// <param name="simulate">When set to true, the burner performs all actions (including progress events) just as if a 
    /// real burn was occuring, but no data is written to the disc</param>
    /// <param name="ejectAfterBurn">When set to true, the CD tray is ejected after the burn completes</param>
    public void RecordDisc(bool simulate, bool ejectAfterBurn)
    {
        if ((fIsBurning) || (fIsErasing))
        {
            throw new XPBurnException(Resource.BurningOrErasing);
        }
        if (!this.MediaInfo.isWritable)
        {
            this.Eject();
            throw new XPBurnException(Resource.NoCDRDisk);
        }
          fIsBurning = true;
          fSimulate = simulate;
          fEjectAfterBurn = ejectAfterBurn;
          
          Thread burnThread = new Thread(new ThreadStart(RecordDiscThread));
          burnThread.Start();
    }

    // TODO: Implement these methods
    // public void AddFolder(string folderName, string folderNameOnCD);
    // END: NYI methods

    #endregion

	}
    public class CDImageFile
    {
        private string _LocalFilePath = @"";
        private string _CDFileName = @"";
       /// <summary>
       /// ローカルファイルパス
       /// </summary>
        public string LocalFilePath
        {
            get 
            { 
                return LocalFilePath; 
            }
            set 
            { 
                LocalFilePath = value; 
            }
        }

        public string CDFileName
        {
            get
            {
                return _CDFileName;
            }
            set
            {
                _CDFileName = value;
            }
        }
	    
        public CDImageFile(){}

        public CDImageFile(string filePath ,string CDFile) {
            _LocalFilePath = filePath;
            _CDFileName = CDFileName;
        }

        public bool IsMatch(CDImageFile obj)
        {
            if (obj != null) return false;
            return (obj.CDFileName == this._CDFileName && obj.LocalFilePath == this._LocalFilePath);
        }

    }
}
