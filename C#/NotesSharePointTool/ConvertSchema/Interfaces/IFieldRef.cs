using RJ.Tools.NotesTransfer.Engines.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJ.Tools.NotesTransfer.Engines.Interfaces
{
    public interface IFieldRef
    {
        /// <summary>
        /// 列の一意の名前
        /// </summary>
        string Name { get; }
        /// <summary>
        /// SP側生成される列の内部名前
        /// </summary>
        string RealName { get; set; }
        /// <summary>
        /// SPフィールド種別
        /// </summary>
        SPFieldType TargetType { get; }
        /// <summary>
        /// SP側生成される列のGUID
        /// </summary>
        string Id { get; set; }
        /// <summary>
        /// タイトル
        /// </summary>
        string Title { get; }
        /// <summary>
        ///　共通フィールドかどうか
        /// </summary>
        bool IsSharedField { get; }
    }
}
