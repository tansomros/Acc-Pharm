Imports System.IO
Public Class Import
    Inherits System.Web.UI.Page
    Dim dt As New DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            lblResult.Visible = False
            lblAlert.Visible = False
        End If
    End Sub
    Private Sub cmdImport_Click(sender As Object, e As EventArgs) Handles cmdImport.Click

        If (Not FileUploadFile.HasFile) Then
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','กรุณาเลือกไฟล์ Excel ก่อน');", True)
            Exit Sub
        End If
        System.Threading.Thread.Sleep(3000)
        UpdateProgress1.Visible = True

        Dim sFileName As String = ""
        Select Case Request("m")
            Case "im1"
                sFileName = "LawTemplate.xls"
            Case "im2"
                sFileName = "LawPracticeTemplate.xls"
        End Select


        Dim connectionString As String = ""
        Try

            lblResult.Visible = False

            'Dim fileName As String = FileUploadFile.FileName
            Dim fileExtension As String = Path.GetExtension(FileUploadFile.PostedFile.FileName)
            Dim fileLocation As String = Server.MapPath("~/" + tmpUpload + "/" + sFileName)

            Dim objfile As FileInfo = New FileInfo(fileLocation)
            If objfile.Exists Then
                objfile.Delete()
            End If

            FileUploadFile.SaveAs(Server.MapPath("~/" + tmpUpload + "/" + sFileName))

            Response.Redirect("LawImport.aspx?m=" & Request("m"))
        Catch ex As Exception
            lblAlert.Text = "Error : " & ex.Message
            lblAlert.Visible = True
        End Try
    End Sub
End Class