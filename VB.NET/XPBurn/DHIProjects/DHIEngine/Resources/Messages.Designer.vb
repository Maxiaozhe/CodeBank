﻿'------------------------------------------------------------------------------
' <auto-generated>
'     このコードはツールによって生成されました。
'     ランタイム バージョン:4.0.30319.42000
'
'     このファイルへの変更は、以下の状況下で不正な動作の原因になったり、
'     コードが再生成されるときに損失したりします。
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

Imports System

Namespace My.Resources
    
    'このクラスは StronglyTypedResourceBuilder クラスが ResGen
    'または Visual Studio のようなツールを使用して自動生成されました。
    'メンバーを追加または削除するには、.ResX ファイルを編集して、/str オプションと共に
    'ResGen を実行し直すか、または VS プロジェクトをビルドし直します。
    '''<summary>
    '''  ローカライズされた文字列などを検索するための、厳密に型指定されたリソース クラスです。
    '''</summary>
    <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0"),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute()>  _
    Friend Class Messages
        
        Private Shared resourceMan As Global.System.Resources.ResourceManager
        
        Private Shared resourceCulture As Global.System.Globalization.CultureInfo
        
        <Global.System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")>  _
        Friend Sub New()
            MyBase.New
        End Sub
        
        '''<summary>
        '''  このクラスで使用されているキャッシュされた ResourceManager インスタンスを返します。
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend Shared ReadOnly Property ResourceManager() As Global.System.Resources.ResourceManager
            Get
                If Object.ReferenceEquals(resourceMan, Nothing) Then
                    Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager("DHI.Engine.Messages", GetType(Messages).Assembly)
                    resourceMan = temp
                End If
                Return resourceMan
            End Get
        End Property
        
        '''<summary>
        '''  厳密に型指定されたこのリソース クラスを使用して、すべての検索リソースに対し、
        '''  現在のスレッドの CurrentUICulture プロパティをオーバーライドします。
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend Shared Property Culture() As Global.System.Globalization.CultureInfo
            Get
                Return resourceCulture
            End Get
            Set
                resourceCulture = value
            End Set
        End Property
        
        '''<summary>
        '''  CDを書き込みしています。（{0}%） に類似しているローカライズされた文字列を検索します。
        '''</summary>
        Friend Shared ReadOnly Property BlockProgress() As String
            Get
                Return ResourceManager.GetString("BlockProgress", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  CDの書き込みが完了しました。 に類似しているローカライズされた文字列を検索します。
        '''</summary>
        Friend Shared ReadOnly Property BurnComplete() As String
            Get
                Return ResourceManager.GetString("BurnComplete", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  ファイルを読み取りできません。 に類似しているローカライズされた文字列を検索します。
        '''</summary>
        Friend Shared ReadOnly Property CantReadFile() As String
            Get
                Return ResourceManager.GetString("CantReadFile", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  ファイルのフォーマットを認識することができません。 に類似しているローカライズされた文字列を検索します。
        '''</summary>
        Friend Shared ReadOnly Property CantRecognizeFormat() As String
            Get
                Return ResourceManager.GetString("CantRecognizeFormat", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  XMLデータにエラーがあります。処理を引続きますか？ に類似しているローカライズされた文字列を検索します。
        '''</summary>
        Friend Shared ReadOnly Property IsContinue() As String
            Get
                Return ResourceManager.GetString("IsContinue", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  このシステムにCD-ROMドライブがありません。 に類似しているローカライズされた文字列を検索します。
        '''</summary>
        Friend Shared ReadOnly Property NotCDROM() As String
            Get
                Return ResourceManager.GetString("NotCDROM", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  ファイル{0}が存在しません。 に類似しているローカライズされた文字列を検索します。
        '''</summary>
        Friend Shared ReadOnly Property NotFindFile() As String
            Get
                Return ResourceManager.GetString("NotFindFile", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  出力ファイルを選択してください。 に類似しているローカライズされた文字列を検索します。
        '''</summary>
        Friend Shared ReadOnly Property NotSelectedFile() As String
            Get
                Return ResourceManager.GetString("NotSelectedFile", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  CD書き込みを準備しています。しばらくおまちください。 に類似しているローカライズされた文字列を検索します。
        '''</summary>
        Friend Shared ReadOnly Property PreparingBurn() As String
            Get
                Return ResourceManager.GetString("PreparingBurn", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  XMLデータの整合性チェックを完了しました。 に類似しているローカライズされた文字列を検索します。
        '''</summary>
        Friend Shared ReadOnly Property XmlCheckComplete() As String
            Get
                Return ResourceManager.GetString("XmlCheckComplete", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  XMLデータの整合性チェックを完了しました。エラーが発生しました。 に類似しているローカライズされた文字列を検索します。
        '''</summary>
        Friend Shared ReadOnly Property XmlCheckFailed() As String
            Get
                Return ResourceManager.GetString("XmlCheckFailed", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  XMLデータの整合性をチェックしています。 に類似しているローカライズされた文字列を検索します。
        '''</summary>
        Friend Shared ReadOnly Property XMLChecking() As String
            Get
                Return ResourceManager.GetString("XMLChecking", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Xmlファイルを取り込みしました。 に類似しているローカライズされた文字列を検索します。
        '''</summary>
        Friend Shared ReadOnly Property XmlImported() As String
            Get
                Return ResourceManager.GetString("XmlImported", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Xmlファイルを取り込みしています。 に類似しているローカライズされた文字列を検索します。
        '''</summary>
        Friend Shared ReadOnly Property XmlImporting() As String
            Get
                Return ResourceManager.GetString("XmlImporting", resourceCulture)
            End Get
        End Property
    End Class
End Namespace