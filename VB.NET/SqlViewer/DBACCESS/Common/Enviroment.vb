Namespace Common
    Public Class Enviroment
        Public Shared Property ConnectString() As String
            Get
                Return System.Configuration.ConfigurationManager.AppSettings.Get("ConnectString")
            End Get
            Set(ByVal Value As String)
                Try
                    SetSetting("ConnectString", Value)
                Catch ex As Exception

                End Try
            End Set
        End Property
        Public Shared Property CommandTimeout() As Integer
            Get
                Return CInt(System.Configuration.ConfigurationManager.AppSettings.Get("CommandTimeout"))
            End Get
            Set(ByVal Value As Integer)
                SetSetting("CommandTimeout", CStr(Value))
            End Set
        End Property

        Public Shared Function GetSetting(ByVal key As String) As String
            Dim doc As New System.Configuration.ConfigXmlDocument()
            doc.Load(System.AppDomain.CurrentDomain.SetupInformation.ConfigurationFile)
            Dim AppSettingNode As Xml.XmlNode = doc.DocumentElement.SelectSingleNode("/configuration/appSettings")
            Dim Addnode As Xml.XmlNode = AppSettingNode.SelectSingleNode("add[@key='" & key & "']")
            Dim attval As Xml.XmlAttribute = Nothing
            If Addnode Is Nothing Then
                Return ""
            Else
                attval = Addnode.Attributes.ItemOf("value")
                If Not attval Is Nothing Then
                    Return attval.Value
                Else
                    Return ""
                End If
            End If
        End Function

        Public Shared Sub SetSetting(ByVal key As String, ByVal value As String)
            Dim doc As New System.Configuration.ConfigXmlDocument()
            doc.Load(System.AppDomain.CurrentDomain.SetupInformation.ConfigurationFile)
            Dim AppSettingNode As Xml.XmlNode = doc.DocumentElement.SelectSingleNode("/configuration/appSettings")
            Dim Addnode As Xml.XmlNode = AppSettingNode.SelectSingleNode("add[@key='" & key & "']")
            Dim attkey As Xml.XmlAttribute = Nothing
            Dim attval As Xml.XmlAttribute = Nothing
            If Addnode Is Nothing Then
                Addnode = doc.CreateElement("add")
                attkey = doc.CreateAttribute("key")
                attkey.Value = key
                attval = doc.CreateAttribute("value")
                attval.Value = value
                Addnode.Attributes.Append(attkey)
                Addnode.Attributes.Append(attval)
                AppSettingNode.AppendChild(Addnode)
            Else
                attkey = Addnode.Attributes.ItemOf("key")
                attval = Addnode.Attributes.ItemOf("value")
                attkey.Value = key
                attval.Value = value
            End If
            doc.Save(System.AppDomain.CurrentDomain.SetupInformation.ConfigurationFile)
        End Sub

    End Class
End Namespace
