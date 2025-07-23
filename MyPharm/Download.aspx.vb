Imports BigLion
Public Class Download
    Inherits Page
    Public dtDoc As New DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Dim ctlD As New DownloadController
        Select Case Request("p")
            Case "d"  'download
                Page.Title = "เอกสารดาวน์โหลด"
            Case "m" 'manual
                Page.Title = "คู่มือการใช้งาน"
            Case Else
                Page.Title = "เอกสารดาวน์โหลด"
        End Select

        If Not IsPostBack Then
            Select Case Request("p")
                Case "d"  'download
                    Page.Title = "เอกสารดาวน์โหลด"
                    lblTitle.Text = "เอกสารดาวน์โหลด"
                    dtDoc = ctlD.Download_GetByCategory(1, "1")
                Case "m" 'manual
                    Page.Title = "คู่มือการใช้งาน"
                    lblTitle.Text = "คู่มือการใช้งาน"
                    dtDoc = ctlD.Download_GetByCategory(2, "1")
                Case Else
                    Page.Title = "เอกสารดาวน์โหลด"
                    lblTitle.Text = "เอกสารดาวน์โหลด"
                    dtDoc = ctlD.Download_GetByCategory(1, "1")
            End Select
        End If
    End Sub
End Class