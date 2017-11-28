Imports System.Xml

Public Class XmlElementTest

    Public Function getMyInfoXelem() As XElement
        Dim elem As XElement = <User>
                                   <lastname>馬</lastname>
                                   <firstname>小哲</firstname>
                                   <usercode>maxz</usercode>
                                   <email>maxz@r-ts.co.jp</email>
                                   <telephone>0474074696</telephone>
                                   <mobil>08012345678</mobil>
                                   <address>千葉県船橋市印内2丁目8番29-101号</address>
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
