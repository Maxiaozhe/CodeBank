Imports System.Xml

Public Class XmlElementTest

    Public Function getMyInfoXelem() As XElement
        Dim elem As XElement = <User>
                                   <lastname>ma</lastname>
                                   <firstname>xiaozhe</firstname>
                                   <usercode>maxz0001</usercode>
                                   <email>maxz@server.com</email>
                                   <telephone>081-1234-5678</telephone>
                                   <mobil>08012345678</mobil>
                                   <address>
                                        The White House 1600 Pennsylvania Avenue NW Washington, DC 20500
                                    </address>
                                   <postcode>273-0039</postcode>
                               </User>
        Return elem

    End Function

    Public Function GetFormList() As XElement
        Dim rdb As New FormLinqDataContext("Data Source=db12;Initial Catalog=RabitFlow_SBB;Persist Security Info=True;User ID=sa")
        Dim CateGolys = From c In rdb.ENVC0001 Where (c.TPCLASS = 0 OrElse c.TPCLASS = 3) And c.FGDEL = "0"c
        Dim XForm = <Categolys>
                        <%= From cate In CateGolys _
                            Select <Categoly IDCTG=<%= cate.IDCTG %>><%= cate.NMCTG %> _
                                <%= From frm In cate.FRMC1000.FRMF1000 Select <Form IDFRM=<%= frm.IDFRM %>><%= frm.NMFRM %></Form> %>_
                            </Categoly> _
                        %>
                    </Categolys>
        Return XForm
    End Function
End Class
