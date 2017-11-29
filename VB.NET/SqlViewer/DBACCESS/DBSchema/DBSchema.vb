Imports utility = SQLViewer.DBAccess.Common.ToolUtility
Namespace DBSchema
    Public Class DBSchemaControler
        Public Function GetDataBases() As String()
            Dim dba As DataBase.SqlServer = Nothing
            Try
                dba = New DataBase.SqlServer()
                Dim sql As String = "Exec dbo.sp_MShasdbaccess"
                Dim dtt As DataTable = dba.SelectSql(sql, "db")
                Dim row As DataRow = Nothing
                Dim Dbs(dtt.Rows.Count - 1) As String
                Dim i As Integer = 0
                For Each row In dtt.Rows
                    Dbs(i) = utility.DBToString(row.Item("dbname"))
                    i += 1
                Next
                Return Dbs
            Catch ex As Exception
                Throw ex
            Finally
                If Not dba Is Nothing Then
                    dba.Close()
                End If
            End Try

        End Function
        Public Function GetTables(ByVal Database As String) As DataTable
            Dim dba As Database.SqlServer = Nothing
            Try
                Dim sb As New System.Text.StringBuilder()
                sb.Append(" USE " & Database & vbCrLf)
                sb.Append(" SELECT *")
                sb.Append(" INTO #TEMPCATE")
                sb.Append(" FROM   ::FN_LISTEXTENDEDPROPERTY(  'SV_CATEGOLY'  ,'USER'  ,'DBO'  ,'TABLE',DEFAULT, DEFAULT  , DEFAULT) ")
                sb.Append(vbCrLf)
                sb.Append(" SELECT  ")
                sb.Append(" OBJECT_NAME(ID) ObjName, ")
                sb.Append(" USER_NAME(UID) Owner,  ")
                sb.Append(" TYPE,  ")
                sb.Append(" OBJECTPROPERTY(ID, N'ISMSSHIPPED')  ")
                sb.Append(" FROM SYSOBJECTS  ")
                sb.Append(" WHERE TYPE= N'U' ")
                sb.Append(" AND PERMISSIONS(ID) & 4096 <> 0  ")
                sb.Append(" AND OBJECTPROPERTY(ID, N'ISMSSHIPPED')=0  ")
                sb.Append(" AND NOT EXISTS( SELECT * FROM #TEMPCATE WHERE OBJNAME= OBJECT_NAME(ID))")
                sb.Append(" Order By ")
                sb.Append(" ObjName ")
                sb.Append(vbCrLf)
                sb.Append(" DROP TABLE #TEMPCATE ")
                dba = New Database.SqlServer()
                Dim dtt As DataTable = dba.SelectSql(sb.ToString, "Tables")
                Return dtt
            Catch ex As Exception
                Throw ex
            Finally
                If Not dba Is Nothing Then
                    dba.Close()
                End If
            End Try
            
        End Function

        Public Function GetTables(ByVal Database As String, ByVal categolyName As String) As DataTable
            Dim dba As Database.SqlServer = Nothing
            Try
                Dim sb As New System.Text.StringBuilder()
                sb.Append(" USE " & Database & vbCrLf)
                sb.Append(" SELECT *")
                sb.Append(" INTO #TEMPCATE")
                sb.Append("  FROM ")
                sb.Append("  ::FN_LISTEXTENDEDPROPERTY( ")
                sb.Append(" 'SV_CATEGOLY' ")
                sb.Append(" ,'USER' ")
                sb.Append(" ,'DBO' ")
                sb.Append(" ,'TABLE' ")
                sb.Append(" , DEFAULT ")
                sb.Append(" , DEFAULT ")
                sb.Append(" , DEFAULT) ")
                sb.Append("  Where ")
                sb.Append("  value= " & utility.Quot(categolyName))
                sb.Append(vbCrLf)
                sb.Append(" SELECT  ")
                sb.Append(" OBJECT_NAME(ID) ObjName, ")
                sb.Append(" USER_NAME(UID) Owner,  ")
                sb.Append(" TYPE,  ")
                sb.Append(" OBJECTPROPERTY(ID, N'ISMSSHIPPED')  ")
                sb.Append(" FROM SYSOBJECTS  ")
                sb.Append(" WHERE TYPE= N'U' ")
                sb.Append(" AND PERMISSIONS(ID) & 4096 <> 0  ")
                sb.Append(" AND OBJECTPROPERTY(ID, N'ISMSSHIPPED')=0  ")
                sb.Append(" AND OBJECT_NAME(ID) IN  ")
                sb.Append("  (SELECT ")
                sb.Append("  objName ")
                sb.Append("  FROM ")
                sb.Append("  #TEMPCATE) ")
                sb.Append(" Order By ")
                sb.Append(" ObjName ")
                sb.Append(vbCrLf)
                sb.Append(" DROP TABLE #TEMPCATE ")

                dba = New Database.SqlServer()
                Dim dtt As DataTable = dba.SelectSql(sb.ToString, "Tables")
                Return dtt
            Catch ex As Exception
                Throw ex
            Finally
                If Not dba Is Nothing Then
                    dba.Close()
                End If
            End Try
            
        End Function

        Public Function GetViews(ByVal Database As String) As DataTable
            Dim dba As Database.SqlServer = Nothing
            Try
                Dim sb As New System.Text.StringBuilder()
                sb.Append(" USE " & Database & vbCrLf)
                sb.Append(" SELECT *")
                sb.Append(" INTO #TEMPCATE")
                sb.Append(" FROM   ::FN_LISTEXTENDEDPROPERTY(  'SV_CATEGOLY'  ,'USER'  ,'DBO'  ,'VIEW',DEFAULT, DEFAULT  , DEFAULT) ")
                sb.Append(vbCrLf)
                sb.Append(" SELECT  ")
                sb.Append(" OBJECT_NAME(ID) OBJNAME, ")
                sb.Append(" USER_NAME(UID) OWNER,  ")
                sb.Append(" TYPE,  ")
                sb.Append(" OBJECTPROPERTY(ID, N'ISMSSHIPPED')  ")
                sb.Append(" FROM SYSOBJECTS  ")
                sb.Append(" WHERE TYPE= N'V' ")
                sb.Append(" AND PERMISSIONS(ID) & 4096 <> 0  ")
                sb.Append(" AND OBJECTPROPERTY(ID, N'ISMSSHIPPED')=0  ")
                sb.Append(" AND NOT EXISTS( SELECT * FROM #TEMPCATE WHERE OBJNAME= OBJECT_NAME(ID))")
                sb.Append(" Order By ")
                sb.Append(" ObjName ")
                sb.Append(vbCrLf)
                sb.Append(" DROP TABLE #TEMPCATE ")
                dba = New Database.SqlServer()
                Dim dtt As DataTable = dba.SelectSql(sb.ToString, "Views")
                Return dtt
            Catch ex As Exception
                Throw ex
            Finally
                If Not dba Is Nothing Then
                    dba.Close()
                End If
            End Try


        End Function
        Public Function GetViews(ByVal Database As String, ByVal categolyName As String) As DataTable
            Dim dba As Database.SqlServer = Nothing
            Try
                Dim sb As New System.Text.StringBuilder()
                sb.Append(" USE " & Database & vbCrLf)
                sb.Append(" SELECT *")
                sb.Append(" INTO #TEMPCATE")
                sb.Append("  FROM ")
                sb.Append("  ::FN_LISTEXTENDEDPROPERTY( ")
                sb.Append(" 'SV_CATEGOLY' ")
                sb.Append(" ,'USER' ")
                sb.Append(" ,'DBO' ")
                sb.Append(" ,'VIEW' ")
                sb.Append(" , DEFAULT ")
                sb.Append(" , DEFAULT ")
                sb.Append(" , DEFAULT) ")
                sb.Append("  Where ")
                sb.Append("  value= " & utility.Quot(categolyName))
                sb.Append(vbCrLf)

                sb.Append(" SELECT  ")
                sb.Append(" OBJECT_NAME(ID) OBJNAME, ")
                sb.Append(" USER_NAME(UID) OWNER,  ")
                sb.Append(" TYPE,  ")
                sb.Append(" OBJECTPROPERTY(ID, N'ISMSSHIPPED')  ")
                sb.Append(" FROM SYSOBJECTS  ")
                sb.Append(" WHERE TYPE= N'V' ")
                sb.Append(" AND PERMISSIONS(ID) & 4096 <> 0  ")
                sb.Append(" AND OBJECTPROPERTY(ID, N'ISMSSHIPPED')=0  ")
                sb.Append(" AND OBJECT_NAME(ID) IN  ")
                sb.Append("  (SELECT ")
                sb.Append("  objName ")
                sb.Append("  FROM ")
                sb.Append("  #TEMPCATE )")
                sb.Append(" Order By ")
                sb.Append(" ObjName ")
                sb.Append(vbCrLf)
                sb.Append(" DROP TABLE #TEMPCATE ")

                dba = New Database.SqlServer()
                Dim dtt As DataTable = dba.SelectSql(sb.ToString, "Views")
                Return dtt
            Catch ex As Exception
                Throw ex
            Finally
                If Not dba Is Nothing Then
                    dba.Close()
                End If
            End Try
        End Function
        Public Function GetStoreProcedures(ByVal Database As String) As DataTable
            Dim dba As Database.SqlServer = Nothing
            Try
                Dim sb As New System.Text.StringBuilder()
                sb.Append(" USE " & Database & vbCrLf)
                sb.Append(" SELECT *")
                sb.Append(" INTO #TEMPCATE")
                sb.Append(" FROM   ::FN_LISTEXTENDEDPROPERTY(  'SV_CATEGOLY'  ,'USER'  ,'DBO'  ,'PROCEDURE',DEFAULT, DEFAULT  , DEFAULT) ")
                sb.Append(vbCrLf)
                sb.Append(" SELECT  ")
                sb.Append(" OBJECT_NAME(ID) OBJNAME,  ")
                sb.Append(" USER_NAME(UID) OWNER,  ")
                sb.Append(" OBJECTPROPERTY(ID, N'ISMSSHIPPED')  ")
                sb.Append(" FROM  ")
                sb.Append(" SYSOBJECTS  ")
                sb.Append(" WHERE ")
                sb.Append(" TYPE = N'P' AND PERMISSIONS(ID) & 32 <> 0  ")
                sb.Append(" AND OBJECTPROPERTY(ID, N'ISMSSHIPPED') =0 ")
                sb.Append(" AND NOT EXISTS( SELECT * FROM #TEMPCATE WHERE OBJNAME= OBJECT_NAME(ID))")
                sb.Append(" Order By ")
                sb.Append(" ObjName ")
                sb.Append(vbCrLf)
                sb.Append(" DROP TABLE #TEMPCATE ")
                dba = New Database.SqlServer()
                Dim dtt As DataTable = dba.SelectSql(sb.ToString, "Tables")
                Return dtt
            Catch ex As Exception
                Throw ex
            Finally
                If Not dba Is Nothing Then
                    dba.Close()
                End If
            End Try
        End Function
        Public Function GetStoreProcedures(ByVal Database As String, ByVal categolyName As String) As DataTable
            Dim dba As Database.SqlServer = Nothing
            Try
                Dim sb As New System.Text.StringBuilder()
                sb.Append(" USE " & Database & vbCrLf)
                sb.Append(" SELECT *")
                sb.Append(" INTO #TEMPCATE")
                sb.Append("  FROM ")
                sb.Append("  ::FN_LISTEXTENDEDPROPERTY( ")
                sb.Append(" 'SV_CATEGOLY' ")
                sb.Append(" ,'USER' ")
                sb.Append(" ,'DBO' ")
                sb.Append(" ,'PROCEDURE' ")
                sb.Append(" , DEFAULT ")
                sb.Append(" , DEFAULT ")
                sb.Append(" , DEFAULT) ")
                sb.Append("  Where ")
                sb.Append("  value= " & utility.Quot(categolyName))
                sb.Append(vbCrLf)
                sb.Append(" SELECT  ")
                sb.Append(" OBJECT_NAME(ID) OBJNAME,  ")
                sb.Append(" USER_NAME(UID) OWNER,  ")
                sb.Append(" OBJECTPROPERTY(ID, N'ISMSSHIPPED')  ")
                sb.Append(" FROM  ")
                sb.Append(" SYSOBJECTS  ")
                sb.Append(" WHERE ")
                sb.Append(" TYPE = N'P' AND PERMISSIONS(ID) & 32 <> 0  ")
                sb.Append(" AND OBJECTPROPERTY(ID, N'ISMSSHIPPED') =0 ")
                sb.Append(" AND OBJECT_NAME(ID) IN  ")
                sb.Append("  (SELECT ")
                sb.Append("  objName ")
                sb.Append("  FROM #TEMPCATE)")
                sb.Append(" ORDER BY ")
                sb.Append(" OBJNAME ")
                sb.Append(vbCrLf)
                sb.Append(" DROP TABLE #TEMPCATE ")

                dba = New Database.SqlServer()
                Dim dtt As DataTable = dba.SelectSql(sb.ToString, "Tables")
                Return dtt
            Catch ex As Exception
                Throw ex
            Finally
                If Not dba Is Nothing Then
                    dba.Close()
                End If
            End Try

        End Function
        Public Function GetFunctions(ByVal Database As String) As DataTable
            Dim dba As Database.SqlServer = Nothing
            Try
                Dim sb As New System.Text.StringBuilder()
                sb.Append(" USE " & Database & vbCrLf)
                sb.Append(" SELECT *")
                sb.Append(" INTO #TEMPCATE")
                sb.Append(" FROM   ::FN_LISTEXTENDEDPROPERTY(  'SV_CATEGOLY'  ,'USER'  ,'DBO'  ,'FUNCTION',DEFAULT, DEFAULT  , DEFAULT) ")
                sb.Append(vbCrLf)
                sb.Append(" SELECT * FROM (")
                sb.Append("  SELECT  ")
                sb.Append("  OBJECT_NAME(ID) AS OBJNAME ")
                sb.Append(" ,USER_NAME(UID) AS OWNER ")
                sb.Append(" ,TYPE ")
                sb.Append(" FROM SYSOBJECTS  ")
                sb.Append("  WHERE TYPE = N'IF'  ")
                sb.Append(" AND PERMISSIONS(ID) & 4096 <> 0  ")
                sb.Append(" AND OBJECTPROPERTY(ID, N'ISMSSHIPPED')=0 ")
                sb.Append(" UNION ALL ")
                sb.Append(" SELECT  ")
                sb.Append(" OBJECT_NAME(ID) AS OBJNAME ")
                sb.Append(" ,USER_NAME(UID) AS OWNER ")
                sb.Append(" ,TYPE ")
                sb.Append("  FROM SYSOBJECTS WHERE TYPE = N'TF' ")
                sb.Append("  AND PERMISSIONS(ID) & 4096 <> 0  ")
                sb.Append(" AND OBJECTPROPERTY(ID, N'ISMSSHIPPED')=0 ")
                sb.Append(" UNION ALL ")
                sb.Append(" SELECT  ")
                sb.Append("  OBJECT_NAME(ID) AS OBJNAME ")
                sb.Append(" ,USER_NAME(UID) AS OWNER ")
                sb.Append(" ,TYPE ")
                sb.Append(" FROM SYSOBJECTS  ")
                sb.Append(" WHERE TYPE = N'FN' AND PERMISSIONS(ID) & 32 <> 0  ")
                sb.Append(" AND OBJECTPROPERTY(ID, N'ISMSSHIPPED')=0 ")
                sb.Append(" ) A ")
                sb.Append(" Where ")
                sb.Append(" NOT EXISTS( SELECT * FROM #TEMPCATE WHERE OBJNAME= A.OBJNAME)")
                sb.Append(" ORDER BY ")
                sb.Append(" TYPE ")
                sb.Append(" ,OBJNAME ")
                sb.Append(vbCrLf)
                sb.Append(" DROP TABLE #TEMPCATE ")
                dba = New Database.SqlServer()
                Dim dtt As DataTable = dba.SelectSql(sb.ToString, "Tables")
                Return dtt
            Catch ex As Exception
                Throw ex
            Finally
                If Not dba Is Nothing Then
                    dba.Close()
                End If
            End Try

        End Function
        Public Function GetFunctions(ByVal Database As String, ByVal CategolyName As String) As DataTable
            Dim dba As Database.SqlServer = Nothing
            Try
                Dim sb As New System.Text.StringBuilder()
                sb.Append(" USE " & Database & vbCrLf)
                sb.Append(" SELECT *")
                sb.Append(" INTO #TEMPCATE")
                sb.Append("  FROM ")
                sb.Append("  ::FN_LISTEXTENDEDPROPERTY( ")
                sb.Append(" 'SV_CATEGOLY' ")
                sb.Append(" ,'USER' ")
                sb.Append(" ,'DBO' ")
                sb.Append(" ,'FUNCTION' ")
                sb.Append(" , DEFAULT ")
                sb.Append(" , DEFAULT ")
                sb.Append(" , DEFAULT) ")
                sb.Append("  Where ")
                sb.Append("  value= " & utility.Quot(CategolyName))
                sb.Append(vbCrLf)
                sb.Append(" Select * from (")
                sb.Append("  SELECT  ")
                sb.Append("  OBJECT_NAME(ID) AS OBJNAME ")
                sb.Append(" ,USER_NAME(UID) AS OWNER ")
                sb.Append(" ,TYPE ")
                sb.Append(" FROM SYSOBJECTS  ")
                sb.Append("  WHERE TYPE = N'IF'  ")
                sb.Append(" AND PERMISSIONS(ID) & 4096 <> 0  ")
                sb.Append(" AND OBJECTPROPERTY(ID, N'ISMSSHIPPED')=0 ")
                sb.Append(" UNION ALL ")
                sb.Append(" SELECT  ")
                sb.Append(" OBJECT_NAME(ID) AS OBJNAME ")
                sb.Append(" ,USER_NAME(UID) AS OWNER ")
                sb.Append(" ,TYPE ")
                sb.Append("  FROM SYSOBJECTS WHERE TYPE = N'TF' ")
                sb.Append("  AND PERMISSIONS(ID) & 4096 <> 0  ")
                sb.Append(" AND OBJECTPROPERTY(ID, N'ISMSSHIPPED')=0 ")
                sb.Append(" UNION ALL ")
                sb.Append(" SELECT  ")
                sb.Append("  OBJECT_NAME(ID) AS OBJNAME ")
                sb.Append(" ,USER_NAME(UID) AS OWNER ")
                sb.Append(" ,TYPE ")
                sb.Append(" FROM SYSOBJECTS  ")
                sb.Append(" WHERE TYPE = N'FN' AND PERMISSIONS(ID) & 32 <> 0  ")
                sb.Append(" AND OBJECTPROPERTY(ID, N'ISMSSHIPPED')=0 ")
                sb.Append(" ) A ")
                sb.Append(" Where ")
                sb.Append("  OBJNAME IN  ")
                sb.Append("  (SELECT ")
                sb.Append("  objName ")
                sb.Append("  FROM #TEMPCATE) ")
                sb.Append(" ORDER BY ")
                sb.Append(" TYPE ")
                sb.Append(" ,OBJNAME ")
                sb.Append(vbCrLf)
                sb.Append(" DROP TABLE #TEMPCATE ")
                dba = New Database.SqlServer()
                Dim dtt As DataTable = dba.SelectSql(sb.ToString, "Tables")
                Return dtt
            Catch ex As Exception
                Throw ex
            Finally
                If Not dba Is Nothing Then
                    dba.Close()
                End If
            End Try

        End Function
        Public Function GetCateGolys(ByVal Database As String, ByVal Type As CateGolyType) As DataTable
            Dim dba As Database.SqlServer = Nothing
            Try
                Dim sb As New System.Text.StringBuilder()
                sb.Append(" USE " & Database & vbCrLf)
                sb.Append("  SELECT Distinct")
                sb.Append("  value, ")
                sb.Append("  objtype ")
                sb.Append("  FROM ")
                sb.Append("  ::FN_LISTEXTENDEDPROPERTY( ")
                sb.Append(" 'SV_CATEGOLY' ")
                sb.Append(" ,'USER' ")
                sb.Append(" ,'DBO' ")
                Select Case Type
                    Case CateGolyType.TABLE
                        sb.Append(" ,'TABLE' ")
                    Case CateGolyType.VIEW
                        sb.Append(" ,'VIEW' ")
                    Case CateGolyType.PROCEDURE
                        sb.Append(" ,'PROCEDURE' ")
                    Case CateGolyType.FUNCTION
                        sb.Append(" ,'FUNCTION' ")
                End Select
                sb.Append(" , DEFAULT ")
                sb.Append(" , DEFAULT ")
                sb.Append(" , DEFAULT) ")
                dba = New Database.SqlServer()
                Dim dtt As DataTable = dba.SelectSql(sb.ToString, "Tables")
                Return dtt
            Catch ex As Exception
                Throw ex
            Finally
                If Not dba Is Nothing Then
                    dba.Close()
                End If
            End Try

        End Function
    End Class
End Namespace


