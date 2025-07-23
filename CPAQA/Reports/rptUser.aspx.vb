Imports BigLion
Public Class rptUser
    Inherits Page
    Public dtUser As New DataTable
    Dim ctlR As New UserController
    Public enc2 As New CryptographyEngine
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Dim fileName As String = ""
        fileName = "รายงานข้อมูล_User.xls"
        dtUser = ctlR.User_GetForExport(Request("grp"), Request("key"), Request.Cookies("userid").Value)

        Response.AppendHeader("content-disposition", "attachment;filename=" & fileName)
        Response.Charset = ""
        Response.ContentType = "application/vnd.ms-excel"

    End Sub
End Class