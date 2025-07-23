Imports BigLion
Public Class Manual
    Inherits Page
    Public dtMan As New DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Dim ctlD As New NewsController
        'Select Case Request("p")
        '    Case "d"  'download
        '        Page.Title = "เอกสารดาวน์โหลด"
        '    Case "m" 'manual
        Page.Title = "คู่มือการใช้งาน"
        '    Case Else
        '        Page.Title = "เอกสารดาวน์โหลด"
        'End Select

        'If Not IsPostBack Then
        '    Select Case Request("p")
        '        Case "d"  'download
        '            Page.Title = "เอกสารดาวน์โหลด"
        '            lblTitle.Text = "เอกสารดาวน์โหลด"
        '            dtDoc = ctlD.Download_GetByCategory(1, "2")
        '        Case "m" 'manual
        Page.Title = "คู่มือการใช้งาน"
                    lblTitle.Text = "คู่มือการใช้งาน"
        dtMan = ctlD.Manual_GetActive()
        '        Case Else
        '            Page.Title = "เอกสารดาวน์โหลด"
        '            lblTitle.Text = "เอกสารดาวน์โหลด"
        '            dtDoc = ctlD.Download_GetByCategory(1, "2")
        '    End Select
        'End If
    End Sub
End Class