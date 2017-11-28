using RJ.Tools.NotesTransfer.Engines.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJ.Tools.NotesTransfer.Engines.Interfaces
{
    /// <summary>
    /// 移行タスクのインタフェース
    /// </summary>
    public interface IMigrateTask
    {

        #region Property
        string TaskId { get; }
        string TaskName { get; set; }
        string Description { get; set; }
        string DisplayName { get; set; }
        bool IsNew { get; }
        bool IsUseDefaultIcon { get; set; }
        string ListName { get; set; }
        IDatabase CurrentDb { get; set; }
        DateTime? LastExecuteTime { get; set; }
        SPListType ListType { get; set; }
        string NotesDbTitle { get; }
        string NotesFileName { get; }
        string NotesFilePath { get; }
        string NotesServer { get; }
        NotesDbType NotesTemplateType { get; }
        string NotesUrl { get; }
        string ReplicaId { get; }
        List<IField> SharedFields { get; }
        string SPListId { get; set; }
        string SPListUrl { get; set; }
        string SPSiteUrl { get; set; }
        TaskState State { get; }
        List<IForm> TargetForms { get; }
        List<IView> TargetViews { get; }
        List<IField> AllFields { get; }
        #endregion
        #region Method
        void ResetNotesDatabase(IDatabase notesDB);
        string SerializFields();
        
        IFieldRef FindField(string fieldName);
        /// <summary>
        /// リソースファイルのパスを取得する
        /// </summary>
        /// <param name="resType"></param>
        /// <returns></returns>
        string GetResourceFilePath(ResourceType resType);
        #endregion
    }
}
