Imports System.IO
Imports BigLion
Public Class NewsDetail
    Inherits Page
    Dim ctlN As New NewsController
    Public dtNew As New DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        GetData()
    End Sub
    Private Sub GetData()
        Dim dt As New DataTable
        Dim ctlN As New NewsController

        ctlN.News_UpdateReadCount(Request("NewsID"))
        dt = ctlN.News_GetByID(Request("NewsID"))

        If (dt.Rows.Count) Then
            With dt.Rows(0)
                Page.Title = Convert.ToString(.Item("NewsHead"))
                lblSubject.Text = "<h3 class='text-green'>" & Convert.ToString(.Item("NewsHead")) & "</h1>"
                lblDetail.Text = Convert.ToString(.Item("NewsDetail"))
                lblUpdated.Text = Convert.ToString(.Item("MWhen"))
                lblRead.Text = Convert.ToString(.Item("NewsRead"))

                If Convert.ToString(.Item("FilePath")) = "" Then
                    lblAttach.Text = ""
                Else
                    lblAttach.Text = "เอกสารแนบ: <a href='Images/News/" + .Item("NewsID").ToString() + "/" + .Item("FilePath").ToString() + "'>" + Path.GetFileNameWithoutExtension(.Item("FilePath").ToString()) + "</a>"


                    'lblAttach.Text = "เอกสารแนบ: <a href='Images/News/attachs/" + Item("FilePath").ToString() + "'>" + Item("FilePath").ToString() + "</a>"

                    'lblAttach.Text = "<a href='" & dt.Rows(0).Item("FilePath").ToString() + "' target='_blank'>" & Path.GetFileNameWithoutExtension((dt.Rows(0).Item("FilePath").ToString())) + "</a>"
                End If
            End With
        End If
        dt = Nothing
    End Sub

End Class