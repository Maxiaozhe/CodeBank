Imports System.CodeDom
Imports System.CodeDom.Compiler

Imports Microsoft.VisualBasic

Public Class CodeDom
    Private mExpress As String = ""
    Private mCompilerError As String = ""
    Private mEvalor As ExpressBase = Nothing
    Public Sub New()

    End Sub
    Public ReadOnly Property CompilerError() As String
        Get
            Return mCompilerError
        End Get
    End Property
    Public Property Express() As String
        Get
            Return mExpress
        End Get
        Set(ByVal value As String)
            mExpress = value
        End Set
    End Property

    Public Function Compile() As Boolean
        mCompilerError = ""
        Dim source As String = String.Format(My.Resources.CodeDomSource, Me.mExpress)
        Dim Compiler As New VBCodeProvider
        Dim Options As New CompilerParameters
        Options.GenerateExecutable = False
        Options.GenerateInMemory = True
        Options.ReferencedAssemblies.Add("System.dll")
        Options.ReferencedAssemblies.Add("mscorlib.dll")
        Options.ReferencedAssemblies.Add("System.Windows.Forms.dll")
        Options.ReferencedAssemblies.Add("System.Data.dll")
        Options.ReferencedAssemblies.Add(System.Reflection.Assembly.GetAssembly(GetType(System.Data.Linq.Binary)).Location)
        Options.ReferencedAssemblies.Add("System.Xml.dll")
        Options.ReferencedAssemblies.Add("System.Drawing.dll")
        Options.ReferencedAssemblies.Add("System.Web.dll")

        Options.ReferencedAssemblies.Add(Me.GetType().Assembly.Location)
        Dim CompileResult As CompilerResults = Compiler.CompileAssemblyFromSource(Options, source)
        If CompileResult.Errors.HasErrors OrElse CompileResult.CompiledAssembly Is Nothing Then
            For Each Err As CompilerError In CompileResult.Errors
                mCompilerError &= Err.ErrorText & vbCrLf
            Next
            Return False
        End If
        mEvalor = TryCast(CompileResult.CompiledAssembly.CreateInstance("CodedomExpress", True), ExpressBase)
        If mEvalor Is Nothing Then
            Return False
        Else
            Return True
        End If
    End Function
    Public Function Eval(ByVal ParamArray params() As Object) As String
        If Me.mEvalor Is Nothing Then
            Return ""
        End If
        Return Me.mEvalor.Eval(params)
    End Function
End Class
Public MustInherit Class ExpressBase
    Public MustOverride Function Eval() As String
    Public MustOverride Function Eval(ByVal ParamArray params() As Object) As String
End Class
