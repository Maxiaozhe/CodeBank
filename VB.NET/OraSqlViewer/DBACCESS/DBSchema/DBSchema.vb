Imports utility = SQLViewer.DBAccess.Common.ToolUtility
Imports System.Collections.Generic
Imports Oracle.DataAccess.Client

Namespace DBSchema
    Public Class DBSchemaControler
        Public Function GetDbSchema(ByVal schema As DBAccess.DataBase.DatabaseCollections) As String()
            Dim dba As DataBase.OraSqlServer = Nothing
            Dim retList As New List(Of String)
            Try
                dba = New DataBase.OraSqlServer()
                Dim dtt As DataTable = dba.GetDbSchemas(DataBase.DatabaseCollections.Users)
                For Each row As DataRow In dtt.Rows
                    Dim user As String = utility.DBToString(row.Item(0))
                    If Me.HasObjects(user) = True Then
                        retList.Add(user)
                    End If
                Next
                Return retList.ToArray()
            Catch ex As Exception
                Throw ex
            Finally
                If Not dba Is Nothing Then
                    dba.Close()
                End If
            End Try

        End Function



        Public Function GetUsers() As String()
            Try
                Dim userList As String() = GetDbSchema(DataBase.DatabaseCollections.Users)
                Return userList
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function HasObjects(ByVal owner As String) As Boolean
            Dim dba As DataBase.OraSqlServer = Nothing
            Dim cmd As OracleCommand = Nothing
            Try
                dba = New DataBase.OraSqlServer()
                cmd = dba.CreateCommand()
                cmd.CommandText = My.Resources.GetObjectCount
                cmd.Parameters.Add(":OWNER", owner)
                Dim dtt As DataTable = dba.SelectSql(cmd, "NUM")
                Dim count As Integer = utility.DBToInteger(dtt.Rows(0).Item(0))
                If count > 0 Then
                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                Throw ex
            Finally
                If Not dba Is Nothing Then
                    dba.Close()
                End If
            End Try
        End Function


        Public Function GetTables(ByVal userName As String) As DataTable
            Dim dba As DataBase.OraSqlServer = Nothing
            Dim cmd As OracleCommand = Nothing
            Try
                dba = New DataBase.OraSqlServer()
                cmd = dba.CreateCommand()
                cmd.CommandText = My.Resources.GetTables
                cmd.Parameters.Add(":OWNER", userName)
                Dim dtt As DataTable = dba.SelectSql(cmd, "TABLES")
                Return dtt
            Catch ex As Exception
                Throw ex
            Finally
                If Not dba Is Nothing Then
                    dba.Close()
                End If
            End Try

        End Function


        Public Function GetViews(ByVal owner As String) As DataTable
            Dim dba As DataBase.OraSqlServer = Nothing
            Dim cmd As OracleCommand = Nothing
            Try
                dba = New DataBase.OraSqlServer()
                cmd = dba.CreateCommand()
                cmd.CommandText = My.Resources.GetViews
                cmd.Parameters.Add(":OWNER", owner)
                Dim dtt As DataTable = dba.SelectSql(cmd, "VIEWS")
                Return dtt
            Catch ex As Exception
                Throw ex
            Finally
                If Not cmd Is Nothing Then
                    cmd.Dispose()
                    cmd = Nothing
                End If
                If Not dba Is Nothing Then
                    dba.Close()
                End If
            End Try


        End Function
      
        Public Function GetStoreProcedures(ByVal Owner As String) As DataTable
             Dim dba As DataBase.OraSqlServer = Nothing
            Dim cmd As OracleCommand = Nothing
            Try
                dba = New DataBase.OraSqlServer()
                cmd = dba.CreateCommand()
                cmd.CommandText = My.Resources.GetStoreProcedure
                cmd.Parameters.Add(":OWNER", Owner)
                Dim dtt As DataTable = dba.SelectSql(cmd, "PROCEDURES")
                Return dtt
            Catch ex As Exception
                Throw ex
            Finally
                If Not cmd Is Nothing Then
                    cmd.Dispose()
                    cmd = Nothing
                End If
                If Not dba Is Nothing Then
                    dba.Close()
                End If
            End Try
        End Function
        Public Function GetFunctions(ByVal Owner As String) As DataTable
            Dim dba As DataBase.OraSqlServer = Nothing
            Dim cmd As OracleCommand = Nothing
            Try
                dba = New DataBase.OraSqlServer()
                cmd = dba.CreateCommand()
                cmd.CommandText = My.Resources.GetFunction
                cmd.Parameters.Add(":OWNER", Owner)
                Dim dtt As DataTable = dba.SelectSql(cmd, "FUNCTIONS")
                Return dtt
            Catch ex As Exception
                Throw ex
            Finally
                If Not cmd Is Nothing Then
                    cmd.Dispose()
                    cmd = Nothing
                End If
                If Not dba Is Nothing Then
                    dba.Close()
                End If
            End Try

        End Function
        Public Function GetPackages(ByVal Owner As String) As DataTable
            Dim dba As DataBase.OraSqlServer = Nothing
            Dim cmd As OracleCommand = Nothing
            Try
                dba = New DataBase.OraSqlServer()
                cmd = dba.CreateCommand()
                cmd.CommandText = My.Resources.GetPackages
                cmd.Parameters.Add(":OWNER", Owner)
                Dim dtt As DataTable = dba.SelectSql(cmd, "PACKAGES")
                Return dtt
            Catch ex As Exception
                Throw ex
            Finally
                If Not cmd Is Nothing Then
                    cmd.Dispose()
                    cmd = Nothing
                End If
                If Not dba Is Nothing Then
                    dba.Close()
                End If
            End Try

        End Function
        Public Function GetPackageBodies(ByVal Owner As String) As DataTable
            Dim dba As DataBase.OraSqlServer = Nothing
            Dim cmd As OracleCommand = Nothing
            Try
                dba = New DataBase.OraSqlServer()
                cmd = dba.CreateCommand()
                cmd.CommandText = My.Resources.GetPackageBodies
                cmd.Parameters.Add(":OWNER", Owner)
                Dim dtt As DataTable = dba.SelectSql(cmd, "PACKAGEBODIES")
                Return dtt
            Catch ex As Exception
                Throw ex
            Finally
                If Not cmd Is Nothing Then
                    cmd.Dispose()
                    cmd = Nothing
                End If
                If Not dba Is Nothing Then
                    dba.Close()
                End If
            End Try

        End Function
        Public Function GetSeqences(ByVal Owner As String) As DataTable
            Dim dba As DataBase.OraSqlServer = Nothing
            Dim cmd As OracleCommand = Nothing
            Try
                dba = New DataBase.OraSqlServer()
                cmd = dba.CreateCommand()
                cmd.CommandText = My.Resources.GetSequence
                cmd.Parameters.Add(":OWNER", Owner)
                Dim dtt As DataTable = dba.SelectSql(cmd, "SEQENCE")
                Return dtt
            Catch ex As Exception
                Throw ex
            Finally
                If Not cmd Is Nothing Then
                    cmd.Dispose()
                    cmd = Nothing
                End If
                If Not dba Is Nothing Then
                    dba.Close()
                End If
            End Try

        End Function
    End Class
End Namespace


