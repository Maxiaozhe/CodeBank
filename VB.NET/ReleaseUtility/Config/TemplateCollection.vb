Imports System.Runtime.Serialization
<Serializable()> _
Public Class TemplateCollection
    Inherits List(Of TemplateItem)
    Implements ISerializable
    Public Sub New()

    End Sub
    Protected Sub New(ByVal serializationInfo As SerializationInfo, ByVal context As StreamingContext)
        Dim Count As Integer = serializationInfo.GetInt32("Count")
        For i As Integer = 0 To Count - 1
            Dim item As TemplateItem = CType(serializationInfo.GetValue(CStr(i), GetType(TemplateItem)), TemplateItem)
            Me.Add(item)
        Next
    End Sub
    Public Sub GetObjectData(ByVal info As System.Runtime.Serialization.SerializationInfo, ByVal context As System.Runtime.Serialization.StreamingContext) Implements System.Runtime.Serialization.ISerializable.GetObjectData
        Dim index As Integer = 0
        info.AddValue("Count", Me.Count, GetType(Integer))
        For Each item As TemplateItem In Me
            info.AddValue(CStr(index), item, GetType(TemplateItem))
            index += 1
        Next
    End Sub

End Class

<Serializable()> _
Public Class TemplateItem
    Implements ISerializable

    Private mName As String
    Private mTreeRoot As TreeNode = Nothing
    Private mOption As OptionData = Nothing

    Public Property Name() As String
        Get
            Return Me.mName
        End Get
        Set(ByVal value As String)
            Me.mName = value
        End Set
    End Property

    Public ReadOnly Property TreeRoot() As TreeNode
        Get
            Return Me.mTreeRoot
        End Get

    End Property

    Public Property TempOption() As OptionData
        Get
            Return mOption
        End Get
        Set(ByVal value As OptionData)
            mOption = value
        End Set
    End Property

    Public Sub New()
        mName = ""
        mTreeRoot = New TreeNode

    End Sub

    Public Sub GetObjectData(ByVal info As System.Runtime.Serialization.SerializationInfo, ByVal context As System.Runtime.Serialization.StreamingContext) Implements System.Runtime.Serialization.ISerializable.GetObjectData
        info.AddValue("Name", mName, GetType(String))
        info.AddValue("TreeRoot", mTreeRoot, GetType(TreeNode))
        If Me.mOption Is Nothing Then
            Me.mOption = New OptionData()
        End If
        info.AddValue("Options", Utility.ObjectToString(Me.mOption), GetType(String))
    End Sub

    Protected Sub New(ByVal serializationInfo As SerializationInfo, ByVal context As StreamingContext)
        mName = CType(serializationInfo.GetValue("Name", GetType(String)), String)
        mTreeRoot = CType(serializationInfo.GetValue("TreeRoot", GetType(TreeNode)), TreeNode)
        Dim optionString As String = ""
        Try
            optionString = CStr(serializationInfo.GetValue("Options", GetType(String)))
        Catch
        End Try
        If String.IsNullOrEmpty(optionString) Then
            Me.mOption = New OptionData()
        Else
            Me.mOption = CType(Utility.StringToObject(optionString), OptionData)
        End If
    End Sub

    Public Function Match(ByVal TempItem As TemplateItem) As Boolean
        If TempItem Is Nothing Then
            Return False
        End If
        If Me.Name = TempItem.Name Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function GetFileCount() As Integer
        Dim countNumber As Integer = 0

        CountFiles(Me.mTreeRoot, countNumber)

        Return countNumber
    End Function

    Private Sub CountFiles(ByVal ParentNode As TreeNode, ByRef CountNumber As Integer)
        If ParentNode.Tag IsNot Nothing AndAlso TypeOf ParentNode.Tag Is String Then
            Dim path As String = CStr(ParentNode.Tag)
            If path <> "" Then
                CountNumber += 1
            End If
        End If
        If ParentNode.Nodes.Count > 0 Then
            For Each subNode As TreeNode In ParentNode.Nodes
                CountFiles(subNode, CountNumber)
            Next
        End If
    End Sub
End Class