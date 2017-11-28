Imports System.DirectoryServices
Namespace RTS.Common.ActiveDirctroy
    Public Class AdAccess
        Private mDirEntry As DirectoryEntry
        Private mSearcher As DirectorySearcher
        Private AddressListBooks() As String = New String() {"CN=すべての連絡先,CN=All Address Lists,CN=Address Lists Container,CN=HAC,CN=Microsoft Exchange,CN=Services,CN=Configuration,DC=HAC,DC=Local", _
        "CN=既定のグローバル アドレス一覧,CN=All Global Address Lists,CN=Address Lists Container,CN=HAC,CN=Microsoft Exchange,CN=Services,CN=Configuration,DC=HAC,DC=Local", _
        "CN=All Contacts(VLV),CN=All System Address Lists,CN=Address Lists Container,CN=HAC,CN=Microsoft Exchange,CN=Services,CN=Configuration,DC=HAC,DC=Local", _
        "CN=NotesUsers,CN=All Address Lists,CN=Address Lists Container,CN=HAC,CN=Microsoft Exchange,CN=Services,CN=Configuration,DC=HAC,DC=Local"}
        'Private AddressListBooks() As String = New String() {"CN=NotesUsers,CN=All Address Lists,CN=Address Lists Container,CN=Microsoft Exchange,CN=Services,CN=Configuration"}
        Public ReadOnly Property DefaultDomain() As String
            Get
                Return CStr(mDirEntry.Properties.Item("name").Item(0))
            End Get
        End Property


        Public ReadOnly Property Root() As AdEntry
            Get
                Dim AD As New AdEntry
                AD.Name = CStr(mDirEntry.Properties.Item("name").Item(0))
                AD.Path = mDirEntry.Path
                AD.HaveChild = True
                Return AD
            End Get
        End Property


        Public ReadOnly Property rootDSE() As AdEntry
            Get
                Dim AD As New AdEntry
                AD.Name = "Configuration"
                Dim root As DirectoryEntry = New DirectoryEntry("LDAP://RootDSE")
                Dim config As String = "LDAP://" & root.Properties.Item("configurationNamingContext").Value.ToString()
                AD.Path = config
                AD.HaveChild = True
                Return AD
            End Get
        End Property

        Public Sub New(ByVal UserName As String, ByVal Password As String, ByVal LDAP As String)
            If UserName = "" Then
                mDirEntry = New DirectoryEntry()
            Else
                mDirEntry = New DirectoryEntry(LDAP, UserName, Password)
            End If
        End Sub
        Public Function GetChilds() As AdEntrys
            Dim child As DirectoryEntry
            Dim users As New AdEntrys()
            For Each child In mDirEntry.Children
                Dim user As New AdEntry()
                user.Path = child.Path
                user.Schema = child.SchemaClassName
                user.UserName = child.Username
                If child.Properties.Contains("name") Then
                    user.Name = CStr(child.Properties("name").Value)
                Else
                    user.Name = child.Name
                End If
                ' user.Password = child.Password
                If child.Children Is Nothing Then
                    user.HaveChild = False
                Else
                    user.HaveChild = True
                End If
                'Dim key As String

                'For Each key In child.Properties.PropertyNames
                '    Dim value As Object = child.Properties(key)
                'Next
                users.Add(user)
            Next
            Return users
        End Function
        Public Function GetChilds(ByVal Parent As AdEntry) As AdEntrys
            Try
                Dim child As DirectoryEntry
                Dim users As New AdEntrys()
                Dim entry As DirectoryEntry = Nothing
                If String.IsNullOrEmpty(Parent.UserName) Then
                    entry = New DirectoryEntry(Parent.Path)
                Else
                    entry = New DirectoryEntry(Parent.Path, Parent.UserName, Parent.Password)
                End If
                For Each child In entry.Children
                    Dim user As New AdEntry()
                    user.Path = child.Path
                    user.Schema = child.SchemaClassName
                    user.UserName = child.Username
                    user.Password = Parent.Password
                    If child.Properties.Contains("name") Then
                        user.Name = CStr(child.Properties("name").Value)
                    Else
                        user.Name = child.Name
                    End If
                    Dim s As DirectoryEntry
                    For Each s In child.Children
                        user.HaveChild = True
                        Exit For
                    Next
                    users.Add(user)
                Next
                Return users
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        Public Function GetPropertys(ByVal user As AdEntry) As PropertyCollection
            Dim entry As DirectoryEntry
            If String.IsNullOrEmpty(user.UserName) Then
                entry = New DirectoryEntry(user.Path)

            Else
                entry = New DirectoryEntry(user.Path, user.UserName, user.Password)

            End If
            Return entry.Properties
        End Function
        Public Function Search(ByVal Keyword As String, ByVal username As String, ByVal password As String, ByVal ldapPath As String) As DataSet
            Try
                Dim root As System.DirectoryServices.DirectoryEntry = Nothing
                If String.IsNullOrEmpty(username) Then
                    root = New DirectoryEntry()
                Else
                    root = New System.DirectoryServices.DirectoryEntry(ldapPath, username, password)
                End If

                Dim searcher As New System.DirectoryServices.DirectorySearcher(root)
                searcher.Filter = "(" & Keyword & ")"
                Dim results As SearchResultCollection
                results = searcher.FindAll()
                Dim ret As SearchResult
                Dim dtset As New DataSet()
                Dim dttab As New DataTable()
                Dim key As String
                Dim row As DataRow

                For Each ret In results

                    For Each key In ret.Properties.PropertyNames
                        If Not dttab.Columns.Contains(key) Then
                            dttab.Columns.Add(key, GetType(System.Object))
                        End If
                    Next key
                Next ret

                For Each ret In results

                    row = dttab.NewRow
                    For Each key In ret.Properties.PropertyNames
                        row.Item(key) = GetPropValue(ret, key)
                    Next key
                    dttab.Rows.Add(row)
                Next ret
                dtset.Tables.Add(dttab)
                Return dtset
            Catch ex As Exception
                System.Windows.Forms.MessageBox.Show(ex.Message)
            End Try
            Return Nothing
        End Function
        Public Function GetAllUser(ByVal username As String, ByVal password As String) As DataSet
            Dim root As System.DirectoryServices.DirectoryEntry = Nothing
            If String.IsNullOrEmpty(username) Then
                root = New DirectoryEntry()
            Else
                root = New System.DirectoryServices.DirectoryEntry("", username, password)
            End If

            Dim searcher As New System.DirectoryServices.DirectorySearcher(root)
            searcher.Filter = "(objectCategory=Person)"
            searcher.PropertiesToLoad.Add("cn")
            'searcher.PropertiesToLoad.Add("company")
            searcher.PropertiesToLoad.Add("department")
            searcher.PropertiesToLoad.Add("displayName")
            searcher.PropertiesToLoad.Add("objectsid")
            searcher.PropertiesToLoad.Add("userPrincipalName")
            searcher.PropertiesToLoad.Add("pysicalDeliveryOfficeName")
            searcher.PropertiesToLoad.Add("mail")
            searcher.PropertiesToLoad.Add("telephoneNumber")
            searcher.PropertiesToLoad.Add("distinguishedName")
            searcher.PropertiesToLoad.Add("sAMAccountName")
            searcher.PropertiesToLoad.Add("sn")
            searcher.PropertiesToLoad.Add("givenName")
            Dim results As SearchResultCollection
            results = searcher.FindAll()
            Dim ret As SearchResult
            Dim dts As New DataSet("Users")
            Dim dtt As New DataTable("Users")
            'dtt.Columns.Add("cn", GetType(System.String))
            'dtt.Columns.Add("Company", GetType(System.String))
            'dtt.Columns.Add("department", GetType(System.String))
            dtt.Columns.Add("displayName", GetType(System.String))
            'dtt.Columns.Add("UserName", GetType(System.String))
            'dtt.Columns.Add("pysicalDeliveryOfficeName", GetType(System.String))
            'dtt.Columns.Add("mail", GetType(System.String))
            'dtt.Columns.Add("telephoneNumber", GetType(System.String))
            'dtt.Columns.Add("distinguishedName", GetType(System.String))
            dtt.Columns.Add("sAMAccountName", GetType(System.String))
            dtt.Columns.Add("Firstname", GetType(System.String))
            dtt.Columns.Add("givenname", GetType(System.String))
            For Each ret In results
                Dim row As DataRow = dtt.NewRow
                With row
                    '.Item("cn") = NVL(GetPropValue(ret, "cn"), "")
                    '.Item("Company") = NVL(GetPropValue(ret, "Company"), "")
                    '.Item("department") = NVL(GetPropValue(ret, "department"), "")
                    .Item("displayName") = NVL(GetPropValue(ret, "displayName"), "")
                    '.Item("UserName") = NVL(GetPropValue(ret, "UserName"), "")
                    '.Item("pysicalDeliveryOfficeName") = NVL(GetPropValue(ret, "pysicalDeliveryOfficeName"), "")
                    '.Item("mail") = NVL(GetPropValue(ret, "mail"), "")
                    '.Item("telephoneNumber") = NVL(GetPropValue(ret, "telephoneNumber"), "")
                    '.Item("distinguishedName") = NVL(GetPropValue(ret, "distinguishedName"), "")
                    .Item("sAMAccountName") = NVL(GetPropValue(ret, "sAMAccountName"), "")
                    .Item("Firstname") = NVL(GetPropValue(ret, "sn"), "")
                    .Item("givenname") = NVL(GetPropValue(ret, "givenname"), "")
                End With
                dtt.Rows.Add(row)
            Next
            dts.Tables.Add(dtt)
            Return dts
        End Function

        Public Function GetAllUser(ByVal username As String, ByVal password As String, ByVal Allflag As Boolean) As DataSet
            Dim root As System.DirectoryServices.DirectoryEntry = Nothing
            If String.IsNullOrEmpty(username) Then
                root = New DirectoryEntry()
            Else
                root = New System.DirectoryServices.DirectoryEntry("", username, password)
            End If

            Dim searcher As New System.DirectoryServices.DirectorySearcher(root)
            searcher.Filter = "(objectCategory=Person)"
            If Allflag = False Then
                searcher.PropertiesToLoad.Add("cn")
                'searcher.PropertiesToLoad.Add("company")
                searcher.PropertiesToLoad.Add("department")
                searcher.PropertiesToLoad.Add("displayName")
                searcher.PropertiesToLoad.Add("objectsid")
                searcher.PropertiesToLoad.Add("userPrincipalName")
                searcher.PropertiesToLoad.Add("pysicalDeliveryOfficeName")
                searcher.PropertiesToLoad.Add("mail")
                searcher.PropertiesToLoad.Add("telephoneNumber")
                searcher.PropertiesToLoad.Add("distinguishedName")
                searcher.PropertiesToLoad.Add("sAMAccountName")
                searcher.PropertiesToLoad.Add("sn")
                searcher.PropertiesToLoad.Add("givenName")
            End If
            Dim results As SearchResultCollection
            results = searcher.FindAll()
            Dim ret As SearchResult
            Dim dts As New DataSet("Users")
            Dim dtt As New DataTable("Users")
            If Allflag = False Then
                dtt.Columns.Add("cn", GetType(System.String))
                ' dtt.Columns.Add("Company", GetType(System.String))
                dtt.Columns.Add("department", GetType(System.String))
                dtt.Columns.Add("displayName", GetType(System.String))
                dtt.Columns.Add("objectsid", GetType(System.String))
                dtt.Columns.Add("UserName", GetType(System.String))
                dtt.Columns.Add("pysicalDeliveryOfficeName", GetType(System.String))
                dtt.Columns.Add("mail", GetType(System.String))
                dtt.Columns.Add("telephoneNumber", GetType(System.String))
                dtt.Columns.Add("distinguishedName", GetType(System.String))
                dtt.Columns.Add("sAMAccountName", GetType(System.String))
                dtt.Columns.Add("Firstname", GetType(System.String))
                dtt.Columns.Add("givenname", GetType(System.String))
            Else
                For Each ret In results
                    Dim key As String = ""
                    For Each key In ret.Properties.PropertyNames
                        If Not dtt.Columns.Contains(key) Then
                            dtt.Columns.Add(key, GetType(System.Object))
                        End If
                    Next key
                Next
            End If
            For Each ret In results
                Dim row As DataRow = dtt.NewRow
                If Allflag = False Then
                    With row
                        .Item("cn") = NVL(GetPropValue(ret, "cn"), "")
                        '.Item("Company") = NVL(GetPropValue(ret, "Company"), "")
                        .Item("department") = NVL(GetPropValue(ret, "department"), "")
                        .Item("displayName") = NVL(GetPropValue(ret, "displayName"), "")
                        .Item("objectsid") = NVL(GetPropValue(ret, "objectsid"), "")
                        .Item("UserName") = NVL(GetPropValue(ret, "UserName"), "")
                        .Item("pysicalDeliveryOfficeName") = NVL(GetPropValue(ret, "pysicalDeliveryOfficeName"), "")
                        .Item("mail") = NVL(GetPropValue(ret, "mail"), "")
                        .Item("telephoneNumber") = NVL(GetPropValue(ret, "telephoneNumber"), "")
                        .Item("distinguishedName") = NVL(GetPropValue(ret, "distinguishedName"), "")
                        .Item("sAMAccountName") = NVL(GetPropValue(ret, "sAMAccountName"), "")
                        .Item("Firstname") = NVL(GetPropValue(ret, "sn"), "")
                        .Item("givenname") = NVL(GetPropValue(ret, "givenname"), "")
                    End With
                Else
                    Dim colname As String = ""
                    For Each colname In ret.Properties.PropertyNames
                        row.Item(colname) = GetPropValue(ret, colname)
                    Next colname
                End If
                dtt.Rows.Add(row)
            Next
            dts.Tables.Add(dtt)
            Return dts
        End Function
        Public Function GetPropValue(ByVal prop As SearchResult, ByVal PropName As String) As Object
            If prop.Properties.Item(PropName) Is Nothing Then
                Return Nothing
            Else
                If PropName.ToLower = "objectsid" Then
                    Dim sid As New System.Security.Principal.SecurityIdentifier(CType(prop.Properties.Item(PropName).Item(0), Byte()), 0)
                    Return sid.Value
                    
                End If
                Return prop.Properties.Item(PropName).Item(0)

            End If
        End Function
        Public Function NVL(ByVal value As Object, ByVal defval As Object) As Object
            If value Is Nothing Then
                Return defval
            Else
                Return value
            End If
        End Function
        Public Sub CreateContact(ByVal Ldap As String, ByVal userName As String, ByVal displayName As String, ByVal Email As String, ByVal notesID As String)
            Try
                Dim root As New DirectoryEntry(Ldap)
                Dim newContect As DirectoryEntry = root.Children.Add("CN=" & userName, "contact")
                Dim Path As String = newContect.Path
                If DirectoryEntry.Exists(Path) = False Then
                    newContect.Properties.Item("displayName").Add(displayName)
                    newContect.Properties.Item("name").Add(userName)
                    newContect.Properties.Item("mail").Add(Email)
                    Dim emailSplits As String() = Email.Split("@"c)
                    newContect.Properties.Item("mailNickname").Add(emailSplits(0))
                    Dim propValue As PropertyValueCollection = newContect.Properties.Item("proxyAddresses")
                    propValue.Add("SMTP:" & Email)
                    propValue.Add("NOTES:" & notesID)
                    newContect.Properties.Item("targetAddress").Add("SMTP:" & Email)
                    Dim names As String() = displayName.Split(" 　".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                    newContect.Properties.Item("sn").Add(names(0))
                    If names.Length > 1 Then
                        newContect.Properties.Item("givenName").Add(names(1))
                    End If
                    propValue = newContect.Properties.Item("showInAddressBook")
                    For Each address As String In Me.AddressListBooks
                        propValue.Add(address)
                    Next

                    'propValue = newContect.Properties("msExchPoliciesIncluded")
                    'propValue.Add("e2b26537-df8e-4019-bf28-91a7d1a9c1c8")
                    'propValue.Add("{26491cfc-9e50-4857-861b-0cb8df22b5d7}")

                    'newContect.Properties("msExchRecipientDisplayType").Add(6)

                    'propValue = newContect.Properties("msExchUMDtmfMap")
                    'propValue.Add("emailAddress:324785362524663")
                    'propValue.Add("lastNameFirstName:324785362524663")
                    'propValue.Add("firstNameLastName:324785362524663")
                    newContect.Properties("legacyExchangeDN").Add("/o=HAC/ou=Exchange Administrative Group (FYDIBOHF23SPDLT)/cn=Recipients/cn=Daisuke_nakagome0dfc6c98")
                    newContect.Properties("extensionAttribute1").Add("NOTES")

                    newContect.CommitChanges()
  
                Else
                    newContect = New DirectoryEntry(Path)
                    UpdateProperty(newContect.Properties.Item("displayName"), displayName)
                    UpdateProperty(newContect.Properties.Item("proxyAddresses"), "SMTP:" & Email, "NOTES:" & notesID)
                    UpdateProperty(newContect.Properties.Item("targetAddress"), "SMTP:" & Email)
                    newContect.CommitChanges()
                End If

            Catch ex As Exception
                Throw ex
            End Try
        End Sub
        Public Sub CreateUser(ByVal Ldap As String, ByVal userName As String, ByVal displayName As String, ByVal Email As String, ByVal notesID As String)
            Try
                Dim root As New DirectoryEntry(Ldap)
                Dim newUser As DirectoryEntry = root.Children.Add("CN=" & userName, "user")
                Dim Path As String = newUser.Path
                If DirectoryEntry.Exists(Path) = False Then
                    newUser.Properties.Item("userprincipalname").Add(Email)
                    newUser.Properties.Item("sAMAccountName").Add(userName)
                    newUser.Properties.Item("displayName").Add(displayName)
                    newUser.Properties.Item("name").Add(userName)
                    newUser.Properties.Item("mail").Add(Email)
                    Dim emailSplits As String() = Email.Split("@"c)
                    newUser.Properties.Item("mailNickname").Add(emailSplits(0))
                    Dim propValue As PropertyValueCollection = newUser.Properties.Item("proxyAddresses")
                    propValue.Add("SMTP:" & Email)
                    propValue.Add("NOTES:" & notesID)
                    newUser.Properties.Item("targetAddress").Add("NOTES:" & notesID)
                    Dim names As String() = displayName.Split(" 　".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                    newUser.Properties.Item("sn").Add(names(0))
                    If names.Length > 1 Then
                        newUser.Properties.Item("givenName").Add(names(1))
                    End If
                    'アカウント期限
                    newUser.Properties.Item("accountexpires").Value = 0
                    newUser.Properties.Item("extensionAttribute1").Add("Notes")
                    newUser.CommitChanges()
                    newUser.Invoke("SetPassword", "Password!")
                    newUser.Properties.Item("userAccountControl").Value = &H200
                    '変更必要
                    newUser.Properties("pwdLastSet").Value = 0
                    newUser.CommitChanges()
                    Dim homeDB As String = "CN=Mailbox Database,CN=First Storage Group,CN=InformationStore,CN=EX222,CN=Servers,CN=Exchange Administrative Group (FYDIBOHF23SPDLT),CN=Administrative Groups,CN=最初の組織,CN=Microsoft Exchange,CN=Services,CN=Configuration,DC=NG,DC=org"
                    Dim nativeObj As Object = newUser.NativeObject
                    newUser.Invoke("CreateMailbox", homeDB)
                    newUser.CommitChanges()
                Else
                    newUser = New DirectoryEntry(Path)
                    UpdateProperty(newUser.Properties.Item("displayName"), displayName)
                    UpdateProperty(newUser.Properties.Item("proxyAddresses"), "SMTP:" & Email, "NOTES:" & notesID)
                    newUser.CommitChanges()

                End If

            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Private Sub UpdateProperty(ByVal PropVal As PropertyValueCollection, ByVal ParamArray values() As String)
            PropVal.Clear()
            For i As Integer = 0 To values.Length - 1
                PropVal.Add(values(i))
            Next
        End Sub



        Public Function GetGlobalAddressList(ByVal keyword As String) As DataSet
            Try
                Dim root As DirectoryEntry = New DirectoryEntry(Me.rootDSE.Path)
                Dim searcher As New System.DirectoryServices.DirectorySearcher(root)
                searcher.Filter = "(" & keyword & ")"
                Dim results As SearchResultCollection
                results = searcher.FindAll()
                Dim ret As SearchResult
                Dim dtset As New DataSet()
                Dim dttab As New DataTable()
                Dim key As String
                Dim row As DataRow

                For Each ret In results

                    For Each key In ret.Properties.PropertyNames
                        If Not dttab.Columns.Contains(key) Then
                            dttab.Columns.Add(key, GetType(System.Object))
                        End If
                    Next key
                Next ret

                For Each ret In results

                    row = dttab.NewRow
                    For Each key In ret.Properties.PropertyNames
                        row.Item(key) = GetPropValue(ret, key)
                    Next key
                    dttab.Rows.Add(row)
                Next ret
                dtset.Tables.Add(dttab)
                Return dtset
            Catch ex As Exception
                System.Windows.Forms.MessageBox.Show(ex.Message)
            End Try
            Return Nothing
        End Function

        Public Function GetAddressBookList() As String
            Dim AddressList As String = ""
            Dim root As DirectoryEntry = New DirectoryEntry("LDAP://RootDSE")
            Dim configPath As String = root.Properties.Item("configurationNamingContext").Value.ToString()
            If String.IsNullOrEmpty(configPath) Then
                Return ""
            End If
            AddressList = "CN=All Address Lists,CN=Address Lists Container,CN=HAC,CN=Microsoft Exchange,CN=Services," & configPath
            Return AddressList
        End Function
    End Class
    Public Class AdEntry
        Public UserName As String
        Public Name As String
        Public Path As String
        Public Schema As String
        Public Password As String
        Public HaveChild As Boolean
    End Class
    Public Class AdEntrys
        Inherits System.Collections.ArrayList

        Default Public Shadows Property Item(ByVal index As Integer) As AdEntry
            Get
                Return CType(MyBase.Item(index), AdEntry)
            End Get
            Set(ByVal Value As AdEntry)
                MyBase.Item(index) = Value
            End Set
        End Property

        Public Shadows Function Add(ByVal value As AdEntry) As Integer
            MyBase.Add(value)
        End Function
    End Class
End Namespace
