Imports System.Drawing
Imports System.IO
Imports BigLion

Public Class Request
    Inherits System.Web.UI.Page
    Dim dt As New DataTable
    Dim ctlL As New RequestController
    Dim ctlM As New MasterController
    Dim ctlU As New UserController
    Private Const UploadDirectory As String = "~/imgRequest/"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsNothing(Request.Cookies("CPA")) Then
            Response.Redirect("Default.aspx")
        End If

        If Not IsPostBack Then
            If ctlL.PC_Request_GetStatusAlive(Request.Cookies("LoginLocationUID").Value) Then
                Response.Redirect("ResultPage.aspx?p=request&t=alive")
            End If
            'LoadRequestType()
        End If
        txtEmail.Attributes.Add("OnKeyPress", "return NotAllowThai();")
    End Sub
    'Private Sub LoadRequestType()
    '    ddlType.DataSource = ctlL.RequestType_Get
    '    ddlType.DataTextField = "Name"
    '    ddlType.DataValueField = "UID"
    '    ddlType.DataBind()
    'End Sub

    Private Sub LoadRequestData()
        dt = ctlL.PC_Request_GetByUID(Request("lid"))
        If dt.Rows.Count > 0 Then
            With dt.Rows(0)
                hdRequestUID.Value = String.Concat(.Item("UID"))
                txtCode.Text = String.Concat(.Item("Code"))
                txtFname.Text = String.Concat(.Item("RequestName"))
                ddlRequesterType.SelectedValue = String.Concat(.Item("RequestMasterUID"))
                'ddlType.SelectedValue = String.Concat(.Item("TypeUID"))
                chkStatus.Checked = ConvertStatusFlag2CHK(String.Concat(.Item("StatusFlag")))
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
        txtCode.Text = ctlM.RunningNumber_New(CODE_REQ)
        'If StrNull2Zero(hdRequestUID.Value) = 0 Then
        '    Select Case ddlType.SelectedValue
        '        Case "1"
        '            txtCode.Text = ctlM.RunningNumber_New(CODE_REQ_REQ)
        '        Case "2"
        '            txtCode.Text = ctlM.RunningNumber_New(CODE_REQ_RENEW)
        '        Case "3", "4", "5"
        '            txtCode.Text = ctlM.RunningNumber_New(CODE_REQ_UPD)
        '        Case "6", "7"
        '            txtCode.Text = ctlM.RunningNumber_New(CODE_REQ_CHK)
        '    End Select
        'End If

        ctlL.PC_Request_Save(StrNull2Zero(hdRequestUID.Value), txtCode.Text, Request.Cookies("LoginLocationUID").Value, 1, txtFname.Text, txtLname.Text, txtEmail.Text, txtLineID.Text, txtTel.Text, StrNull2Zero(ddlRequesterType.SelectedValue), txtRequesterOther.Text, Request.Cookies("UserID").Value)


        'Dim RequestUID As Integer

        If StrNull2Zero(hdRequestUID.Value) = 0 Then
            'Select Case ddlType.SelectedValue
            '    Case "1"
            ctlM.RunningNumber_Update(CODE_REQ)
            '    Case "2"
            '        ctlM.RunningNumber_Update(CODE_REQ_RENEW)
            '    Case "3", "4", "5"
            '        ctlM.RunningNumber_Update(CODE_REQ_UPD)
            '    Case "6", "7"
            '        ctlM.RunningNumber_Update(CODE_REQ_CHK)
            'End Select

            hdRequestUID.Value = ctlL.PC_Request_GetUID(txtCode.Text)

        End If

        ctlU.User_GenLogfile(Request.Cookies("UserID").Value, ACTTYPE_UPD, "Request", "บันทึก/แก้ไข Request :{RequestUID=" & hdRequestUID.Value & "}{RequestCode=" & txtCode.Text & "}", "service", Environment.MachineName, GetIPAddress())
        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalSuccess(this,'Success','บันทึกข้อมูลเรียบร้อย');", True)

    End Sub
End Class