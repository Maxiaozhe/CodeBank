﻿//------------------------------------------------------------------------------
// <auto-generated>
//     このコードはツールによって生成されました。
//     ランタイム バージョン:4.0.30319.42000
//
//     このファイルへの変更は、以下の状況下で不正な動作の原因になったり、
//     コードが再生成されるときに損失したりします。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Rex.Tools.Test.DataCheck.Properties {
    using System;
    
    
    /// <summary>
    ///   ローカライズされた文字列などを検索するための、厳密に型指定されたリソース クラスです。
    /// </summary>
    // このクラスは StronglyTypedResourceBuilder クラスが ResGen
    // または Visual Studio のようなツールを使用して自動生成されました。
    // メンバーを追加または削除するには、.ResX ファイルを編集して、/str オプションと共に
    // ResGen を実行し直すか、または VS プロジェクトをビルドし直します。
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   このクラスで使用されているキャッシュされた ResourceManager インスタンスを返します。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Rex.Tools.Test.DataCheck.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   厳密に型指定されたこのリソース クラスを使用して、すべての検索リソースに対し、
        ///   現在のスレッドの CurrentUICulture プロパティをオーバーライドします。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   
        ///IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N&apos;COMMENT&apos; , N&apos;SCHEMA&apos;,N&apos;dbo&apos;, N&apos;TABLE&apos;,N&apos;{0}&apos;, N&apos;COLUMN&apos;,N&apos;{1}&apos;))
        ///EXEC sys.sp_addextendedproperty @name=N&apos;COMMENT&apos;, @value=N&apos;{2}&apos; , @level0type=N&apos;SCHEMA&apos;,@level0name=N&apos;dbo&apos;, @level1type=N&apos;TABLE&apos;,@level1name=N&apos;{0}&apos;, @level2type=N&apos;COLUMN&apos;,@level2name=N&apos;{1}&apos;
        ///GO
        /// に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string AddColumnComment {
            get {
                return ResourceManager.GetString("AddColumnComment", resourceCulture);
            }
        }
        
        /// <summary>
        ///   
        ///IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N&apos;MS_Description&apos; , N&apos;SCHEMA&apos;,N&apos;dbo&apos;, N&apos;TABLE&apos;,N&apos;{0}&apos;, N&apos;COLUMN&apos;,N&apos;{1}&apos;))
        ///EXEC sys.sp_addextendedproperty @name=N&apos;MS_Description&apos;, @value=N&apos;{2}&apos; , @level0type=N&apos;SCHEMA&apos;,@level0name=N&apos;dbo&apos;, @level1type=N&apos;TABLE&apos;,@level1name=N&apos;{0}&apos;, @level2type=N&apos;COLUMN&apos;,@level2name=N&apos;{1}&apos;
        ///GO
        /// に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string AddColumnDescription {
            get {
                return ResourceManager.GetString("AddColumnDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   
        ///EXEC sys.sp_addextendedproperty @name=N&apos;MS_Description&apos;, @value=N&apos;{1}&apos; , @level0type=N&apos;SCHEMA&apos;,@level0name=N&apos;dbo&apos;, @level1type=N&apos;TABLE&apos;,@level1name=N&apos;{0}&apos;
        ///GO
        /// に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string AddTableDescription {
            get {
                return ResourceManager.GetString("AddTableDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   ------------------------------CREATE TABLE:{0}【{1}】---------------------------------------------------
        ///IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N&apos;[dbo].[{0}]&apos;) AND type in (N&apos;U&apos;))
        ///BEGIN
        ///CREATE TABLE [dbo].[{0}](
        ///{2}{3}
        ///) ON [PRIMARY]
        ///END
        ///GO
        /// に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string CreateTable {
            get {
                return ResourceManager.GetString("CreateTable", resourceCulture);
            }
        }
        
        /// <summary>
        ///   IF  EXISTS (SELECT * FROM ::fn_listextendedproperty(N&apos;COMMENT&apos; , N&apos;SCHEMA&apos;,N&apos;dbo&apos;, N&apos;TABLE&apos;,N&apos;{0}&apos;, N&apos;COLUMN&apos;,N&apos;{1}&apos;))
        ///EXEC sys.sp_dropextendedproperty @name=N&apos;COMMENT&apos; , @level0type=N&apos;SCHEMA&apos;,@level0name=N&apos;dbo&apos;, @level1type=N&apos;TABLE&apos;,@level1name=N&apos;{0}&apos;, @level2type=N&apos;COLUMN&apos;,@level2name=N&apos;{1}&apos;
        ///GO に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string DropColumnComment {
            get {
                return ResourceManager.GetString("DropColumnComment", resourceCulture);
            }
        }
        
        /// <summary>
        ///   IF  EXISTS (SELECT * FROM ::fn_listextendedproperty(N&apos;MS_Description&apos; , N&apos;SCHEMA&apos;,N&apos;dbo&apos;, N&apos;TABLE&apos;,N&apos;{0}&apos;, N&apos;COLUMN&apos;,N&apos;{1}&apos;))
        ///EXEC sys.sp_dropextendedproperty @name=N&apos;MS_Description&apos; , @level0type=N&apos;SCHEMA&apos;,@level0name=N&apos;dbo&apos;, @level1type=N&apos;TABLE&apos;,@level1name=N&apos;{0}&apos;, @level2type=N&apos;COLUMN&apos;,@level2name=N&apos;{1}&apos;
        ///GO に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string DropColumnDescription {
            get {
                return ResourceManager.GetString("DropColumnDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N&apos;[dbo].[{0}]&apos;) AND type in (N&apos;U&apos;))
        ///DROP TABLE [dbo].[{0}]
        ///GO
        /// に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string DropTable {
            get {
                return ResourceManager.GetString("DropTable", resourceCulture);
            }
        }
        
        /// <summary>
        ///   IF  EXISTS (SELECT * FROM ::fn_listextendedproperty(N&apos;MS_Description&apos; , N&apos;SCHEMA&apos;,N&apos;dbo&apos;, N&apos;TABLE&apos;,N&apos;{0}&apos;, NULL,NULL))
        ///EXEC sys.sp_dropextendedproperty @name=N&apos;MS_Description&apos; , @level0type=N&apos;SCHEMA&apos;,@level0name=N&apos;dbo&apos;, @level1type=N&apos;TABLE&apos;,@level1name=N&apos;{0}&apos;
        ///GO
        /// に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string DropTableDescription {
            get {
                return ResourceManager.GetString("DropTableDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   /*作成済みの稼動キーNOを取得する*/
        /// SELECT 
        ///	OPERATION_PLAN_NO
        /// FROM 
        ///	ACTION_HISTORY_OPERATION 
        /// Where 
        ///	 FACILITY_CODE=@FACILITY_CODE
        /// AND OPERATION_DATE=@OPERATION_DATE に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string GetNewOperationNo {
            get {
                return ResourceManager.GetString("GetNewOperationNo", resourceCulture);
            }
        }
        
        /// <summary>
        ///   /*作成済みの計画キーNOを取得する*/
        /// SELECT 
        ///  PRODUCTION_PLAN_NO
        /// FROM 
        ///  ACTION_HISTORY_PRODUCTION 
        /// Where 
        ///  SCHEDULED_KEY_NO=@SCHEDULED_KEY_NO
        ///  に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string GetNewProductionNo {
            get {
                return ResourceManager.GetString("GetNewProductionNo", resourceCulture);
            }
        }
        
        /// <summary>
        ///   set search_path to information_schema;
        ///select 
        ///t.table_name as &quot;table_Name&quot;,
        ///c.column_name as &quot;column_Name&quot;,
        ///udt_name as &quot;DataType&quot;,
        ///character_maximum_length as &quot;Length&quot;,
        ///numeric_precision as &quot;NumericPrecision&quot;,
        ///numeric_scale as &quot;NumericScale&quot;,
        ///is_nullable as &quot;nullable&quot;,
        ///case when k.ordinal_position is null then false else true end as &quot;InPrimaryKey&quot;,
        ///c.ordinal_position as &quot;column_id&quot;,
        ///k.ordinal_position as &quot;index_column_id&quot;,
        ///&apos;&apos; as &quot;display_name&quot;,
        ///false as &quot;is_identity&quot;
        ///from tables as t
        ///inner  [残りの文字列は切り詰められました]&quot;; に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string GetNpgTableLayout {
            get {
                return ResourceManager.GetString("GetNpgTableLayout", resourceCulture);
            }
        }
        
        /// <summary>
        ///   select 
        ///t.name as table_Name,
        ///c.name as column_Name,
        ///tp.name as [DataType],
        ///CAST(CASE WHEN tp.name IN (N&apos;nchar&apos;, N&apos;nvarchar&apos;) AND c.max_length &lt;&gt; -1 THEN c.max_length/2 ELSE c.max_length END AS int) AS [Length],
        ///CAST(c.precision AS int) AS [NumericPrecision],
        ///CAST(c.scale AS int) AS [NumericScale],
        ///c.is_nullable as [nullable],
        ///CAST(ISNULL(cik.index_column_id, 0) AS bit) AS [InPrimaryKey],
        ///c.column_id as column_id,
        ///cik.index_column_id,
        ///p.value as [display_name],
        ///c.is_identity as [is_identity]
        ///from
        ///sys.tables [残りの文字列は切り詰められました]&quot;; に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string GetTableLayout {
            get {
                return ResourceManager.GetString("GetTableLayout", resourceCulture);
            }
        }
    }
}
