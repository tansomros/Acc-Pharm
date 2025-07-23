Imports BigLion
Public Class Regulations
    Inherits Page
    Public dtDoc As New DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Dim ctlD As New DownloadController
        'Select Case Request("p")
        '    Case "d"  'download
        '        Page.Title = "เอกสารดาวน์โหลด"
        '    Case "m" 'manual
        '        Page.Title = "คู่มือการใช้งาน"
        '    Case "r" 'regulations
        '        Page.Title = "ระเบียบ/ ประกาศ / ข้อบังคับ"
        '    Case Else
        '        Page.Title = "เอกสารดาวน์โหลด"
        'End Select

        If Not IsPostBack Then
            'Select Case Request("p")
            '    Case "d"  'download
            '        Page.Title = "เอกสารดาวน์โหลด"
            '        lblTitle.Text = "เอกสารดาวน์โหลด"
            '        dtDoc = ctlD.Download_GetByCategory(1, "2")
            '    Case "m" 'manual
            '        Page.Title = "คู่มือการใช้งาน"
            '        lblTitle.Text = "คู่มือการใช้งาน"
            '        dtDoc = ctlD.Download_GetByCategory(2, "2")
            '    Case "r" 'regulations
            Page.Title = "ระเบียบ/ ประกาศ / ข้อบังคับ"
            lblTitle.Text = "ระเบียบ/ ประกาศ / ข้อบังคับ"
            dtDoc = ctlD.Download_GetByCategory(3, "2")
            '    Case Else
            '        Page.Title = "เอกสารดาวน์โหลด"
            '        lblTitle.Text = "เอกสารดาวน์โหลด"
            '        dtDoc = ctlD.Download_GetByCategory(1, "2")
            'End Select
        End If
    End Sub
End Class