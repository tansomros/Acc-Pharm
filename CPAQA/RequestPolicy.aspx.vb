Imports System.Drawing
Imports System.IO
Imports DevExpress.Web
Imports DevExpress.Web.Internal
Imports BigLion
Public Class RequestPolicy
    Inherits System.Web.UI.Page
    Dim dt As New DataTable
    Dim ctlL As New RequestController
    Dim ctlM As New MasterController
    Dim ctlU As New UserController
    Private Const UploadDirectory As String = "~/imgRequest/"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsNothing(Request.Cookies("CPAQA")) Then
            Response.Redirect("Default.aspx")
        End If

        If Not IsPostBack Then
            LoadRequestType()
            'If Not Request("rid") Is Nothing Then
            '    LoadRequestData()
            'Else
            '    hdLocationUID.Value = Request.Cookies("LoginLocationUID").Value
            '    If ctlL.Request_GetStatusAlive(Request.Cookies("LoginLocationUID").Value) Then
            '        Response.Redirect("ResultPage.aspx?p=request&t=alive")
            '    End If
            'End If
        End If
        txtEmail.Attributes.Add("OnKeyPress", "return NotAllowThai();")
    End Sub
    Private Sub LoadRequestType()
        ddlType.DataSource = ctlL.RequestType_Get
        ddlType.DataTextField = "Name"
        ddlType.DataValueField = "UID"
        ddlType.DataBind()
    End Sub

    Private Sub LoadRequestData()
        dt = ctlL.Request_GetByUID(Request("rid"))
        If dt.Rows.Count > 0 Then
            With dt.Rows(0)
                hdRequestUID.Value = String.Concat(.Item("UID"))
                hdLocationUID.Value = String.Concat(.Item("LocationUID"))
                txtCode.Text = String.Concat(.Item("Code"))
                txtFname.Text = String.Concat(.Item("FName"))
                txtLname.Text = String.Concat(.Item("LName"))
                txtEmail.Text = String.Concat(.Item("Email"))
                txtTel.Text = String.Concat(.Item("Tel"))
                txtLineID.Text = String.Concat(.Item("LineID"))
                ddlRequesterType.SelectedValue = String.Concat(.Item("RequesterType"))
                ddlType.SelectedValue = String.Concat(.Item("RequestType"))
                txtRequesterOther.Text = String.Concat(.Item("RequesterRemark"))
                ddlType.Enabled = False
            End With
        Else
        End If
    End Sub

    Protected Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        If txtFname.Text = "" Or txtLname.Text = "" Then
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','ท่านยังไม่ได้ระบุชื่อ-นามสกุลผู้ยื่นคำขอ');", True)
            Exit Sub
        End If
        If txtEmail.Text = "" Then
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','ท่านยังไม่ได้ระบุอีเมล');", True)
            Exit Sub
        End If
        If txtTel.Text = "" Then
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','ท่านยังไม่ได้ระบุเบอร์โทร');", True)
            Exit Sub
        End If

        If StrNull2Zero(hdRequestUID.Value) = 0 Then
            Select Case ddlType.SelectedValue
                Case "1"
                    txtCode.Text = ctlM.RunningNumber_New(CODE_REQ_NEW)
                Case "2"
                    txtCode.Text = ctlM.RunningNumber_New(CODE_REQ_RENEW)
                Case "3", "4"
                    txtCode.Text = ctlM.RunningNumber_New(CODE_REQ_UPD)
                Case "5", "6"
                    txtCode.Text = ctlM.RunningNumber_New(CODE_REQ_CHK)
            End Select
        End If

        ctlL.Request_Save(StrNull2Zero(hdRequestUID.Value), txtCode.Text, StrNull2Zero(hdLocationUID.Value), StrNull2Zero(ddlType.SelectedValue), txtFname.Text, txtLname.Text, txtEmail.Text, txtLineID.Text, txtTel.Text, StrNull2Zero(ddlRequesterType.SelectedValue), txtRequesterOther.Text, Request.Cookies("UserID").Value)


        'Dim RequestUID As Integer

        If StrNull2Zero(hdRequestUID.Value) = 0 Then
            Select Case ddlType.SelectedValue
                Case "1"
                    ctlM.RunningNumber_Update(CODE_REQ_NEW)
                Case "2"
                    ctlM.RunningNumber_Update(CODE_REQ_RENEW)
                Case "3", "4"
                    ctlM.RunningNumber_Update(CODE_REQ_UPD)
                Case "5", "6"
                    ctlM.RunningNumber_Update(CODE_REQ_CHK)
            End Select

            hdRequestUID.Value = ctlL.Request_GetUID(txtCode.Text)

        End If

        ctlU.User_GenLogfile(Request.Cookies("UserID").Value, ACTTYPE_UPD, "Request", "บันทึก/แก้ไข Request :{RequestUID=" & hdRequestUID.Value & "}{RequestCode=" & txtCode.Text & "}", "")

        If StrNull2Zero(hdRequestUID.Value) = 0 Then
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalSuccess(this,'Success','บันทึกข้อมูลเรียบร้อย');", True)
        Else
            Response.Redirect("RequestDetail.aspx?m=req&id=" & hdRequestUID.Value)
        End If

    End Sub

    'Protected Function SavePostedFile(ByVal uploadedFile As UploadedFile, ByVal UploadPath As String, ByVal UploadFileName As String) As String
    '    If (Not uploadedFile.IsValid) Then
    '        Return String.Empty
    '    End If

    '    Dim fileName As String = Path.ChangeExtension(UploadFileName, ".jpg")

    '    Dim fullFileName As String = CombinePath(UploadPath, fileName)
    '    Using original As Image = Image.FromStream(uploadedFile.FileContent)
    '        Using thumbnail As Image = New ImageThumbnailCreator(original).CreateImageThumbnail(New Size(350, 350))
    '            ImageUtils.SaveToJpeg(CType(thumbnail, Bitmap), fullFileName)
    '        End Using
    '    End Using
    '    UploadingUtils.RemoveFileWithDelay(fileName, fullFileName, 5)
    '    Return fileName
    'End Function
    'Protected Function CombinePath(ByVal UploadPath As String, ByVal fileName As String) As String
    '    Return Path.Combine(Server.MapPath(UploadPath), fileName)
    'End Function

End Class