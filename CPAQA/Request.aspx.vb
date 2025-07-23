Imports System.Drawing
Imports System.IO
Imports DevExpress.Web
Imports DevExpress.Web.Internal
Imports BigLion
Public Class Request
    Inherits System.Web.UI.Page
    Dim dt As New DataTable
    Dim ctlR As New RequestController
    Dim ctlM As New MasterController
    Dim ctlU As New UserController
    Dim ctlL As New LocationController
    Private Const UploadDirectory As String = "~/imgRequest/"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsNothing(Request.Cookies("CPAQA")) Then
            Response.Redirect("Default.aspx")
        End If

        If Not IsPostBack Then
            'LoadRequestType()
            pnPolicy.Visible = False
            pnChange.Visible = False
            If Not Request("rid") Is Nothing Then
                LoadRequestData()
            Else
                hdLocationUID.Value = Request.Cookies("LoginLocationUID").Value

                If ctlR.Request_GetStatusAlive(Request.Cookies("LoginLocationUID").Value) Then
                    Response.Redirect("ResultPage.aspx?p=request&t=alive")
                End If
            End If
            txtLitigation.Text = ctlL.Location_GetLitigation(StrNull2Zero(hdLocationUID.Value))
        End If
        txtEmail.Attributes.Add("OnKeyPress", "return NotAllowThai();")
    End Sub
    'Private Sub LoadRequestType()
    '    chkType.DataSource = ctlR.RequestType_Get
    '    chkType.DataTextField = "Name"
    '    chkType.DataValueField = "UID"
    '    chkType.DataBind()
    'End Sub
    Private Sub LoadRequestTypeList(ReqUID As Integer)
        Dim dtC As New DataTable
        dtC = ctlR.RequestTypeList_GetByRequestUID(ReqUID)
        If dtC.Rows.Count > 0 Then
            For i = 0 To dtC.Rows.Count - 1
                Select Case dtC.Rows(i)("RequestTypeUID")
                    Case 1
                        chkType1.Checked = True
                        pnPolicy.Visible = True
                        pnChange.Visible = False
                    Case 2
                        chkType2.Checked = True
                        pnPolicy.Visible = True
                        pnChange.Visible = False
                    Case 3
                        chkType3.Checked = True
                    Case 4
                        chkType4.Checked = True
                    Case 5
                        chkType5.Checked = True
                        pnChange.Visible = True
                    Case 6
                        chkType6.Checked = True
                    Case 7
                        chkType7.Checked = True
                        pnPolicy.Visible = True
                        pnChange.Visible = False
                    Case 8
                        chkType8.Checked = True
                    Case 9
                        chkType9.Checked = True
                End Select

            Next

        End If
    End Sub

    Private Sub LoadRequestData()
        dt = ctlR.Request_GetByUID(Request("rid"))
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
                'ddlType.SelectedValue = String.Concat(.Item("RequestType"))
                txtRequesterOther.Text = String.Concat(.Item("RequesterRemark"))
                'chkType.Enabled = False
                optChange.Enabled = False

                LoadRequestTypeList(StrNull2Zero(.Item("UID")))
                optChange.SelectedValue = String.Concat(.Item("RequestSubType"))

                'If DBNull2Zero(.Item("RequestType")) = 5 Then
                '    pnPolicy.Visible = False
                '    pnChange.Visible = True
                '    optChange.SelectedValue = String.Concat(.Item("RequestSubType"))
                'ElseIf DBNull2Zero(.Item("RequestType")) >= 1 And DBNull2Zero(.Item("RequestType")) <= 2 Then
                '    pnPolicy.Visible = True
                '    pnChange.Visible = False
                'Else
                '    pnPolicy.Visible = False
                '    pnChange.Visible = False
                'End If

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

        If chkType1.Checked Or chkType2.Checked Or chkType7.Checked Then
            If chkAllow.Checked = False Then
                ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','ท่านยังไม่ได้เลือกยอมรับทราบและให้คำรับรอง');", True)
                Exit Sub
            End If
        End If


        'If StrNull2Zero(ddlType.SelectedValue) <= 2 Then
        '    If chkAllow.Checked = False Then
        '        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','ท่านยังไม่ได้เลือกยอมรับทราบและให้คำรับรอง');", True)
        '        Exit Sub
        '    End If
        'Else
        '    If StrNull2Zero(ddlType.SelectedValue) = 7 Then
        '        If chkAllow.Checked = False Then
        '            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','ท่านยังไม่ได้เลือกยอมรับทราบและให้คำรับรอง');", True)
        '            Exit Sub
        '        End If
        '    End If
        'End If

        If StrNull2Zero(hdRequestUID.Value) = 0 Then
            txtCode.Text = ctlM.RunningNumber_New(CODE_REQ)
        End If

        ctlR.Request_Save(StrNull2Zero(hdRequestUID.Value), txtCode.Text, StrNull2Zero(hdLocationUID.Value), 0, StrNull2Zero(optChange.SelectedValue), txtFname.Text, txtLname.Text, txtEmail.Text, txtLineID.Text, txtTel.Text, StrNull2Zero(ddlRequesterType.SelectedValue), txtRequesterOther.Text, Request.Cookies("UserID").Value)

        If StrNull2Zero(hdRequestUID.Value) = 0 Then
            ctlM.RunningNumber_Update(CODE_REQ)
            hdRequestUID.Value = ctlR.Request_GetUID(txtCode.Text)
        End If

        ctlR.RequestTypeList_Delete(StrNull2Zero(hdRequestUID.Value))

        If chkType1.Checked Then
            ctlR.RequestTypeList_Add(StrNull2Zero(hdRequestUID.Value), 1, Request.Cookies("userid").Value)
        End If
        If chkType2.Checked Then
            ctlR.RequestTypeList_Add(StrNull2Zero(hdRequestUID.Value), 2, Request.Cookies("userid").Value)
        End If
        If chkType3.Checked Then
            ctlR.RequestTypeList_Add(StrNull2Zero(hdRequestUID.Value), 3, Request.Cookies("userid").Value)
        End If
        If chkType4.Checked Then
            ctlR.RequestTypeList_Add(StrNull2Zero(hdRequestUID.Value), 4, Request.Cookies("userid").Value)
        End If
        If chkType5.Checked Then
            ctlR.RequestTypeList_Add(StrNull2Zero(hdRequestUID.Value), 5, Request.Cookies("userid").Value)
        End If
        If chkType6.Checked Then
            ctlR.RequestTypeList_Add(StrNull2Zero(hdRequestUID.Value), 6, Request.Cookies("userid").Value)
        End If
        If chkType7.Checked Then
            ctlR.RequestTypeList_Add(StrNull2Zero(hdRequestUID.Value), 7, Request.Cookies("userid").Value)
        End If
        If chkType8.Checked Then
            ctlR.RequestTypeList_Add(StrNull2Zero(hdRequestUID.Value), 8, Request.Cookies("userid").Value)
        End If
        If chkType9.Checked Then
            ctlR.RequestTypeList_Add(StrNull2Zero(hdRequestUID.Value), 9, Request.Cookies("userid").Value)
        End If

        ctlL.Location_UpdateLitigation(StrNull2Zero(hdLocationUID.Value), txtLitigation.Text)

        ctlU.User_GenLogfile(Request.Cookies("UserID").Value, ACTTYPE_UPD, "Request", "บันทึก/แก้ไข Request :{RequestUID=" & hdRequestUID.Value & "}{RequestCode=" & txtCode.Text & "}", "", Environment.MachineName, GetIPAddress())

        If StrNull2Zero(hdRequestUID.Value) = 0 Then
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalSuccess(this,'Success','บันทึกข้อมูลเรียบร้อย');", True)
        Else
            Response.Redirect("RequestDetail.aspx?m=req&id=" & hdRequestUID.Value)
        End If

    End Sub
    Private Sub chkType1_CheckedChanged(sender As Object, e As EventArgs) Handles chkType1.CheckedChanged
        If chkType1.Checked = True Then
            chkType2.Checked = False
            chkType7.Checked = False
            pnPolicy.Visible = True
        End If
        If chkType1.Checked = False And chkType2.Checked = False And chkType7.Checked = False Then
            pnPolicy.Visible = False
        End If
    End Sub

    Private Sub chkType2_CheckedChanged(sender As Object, e As EventArgs) Handles chkType2.CheckedChanged
        If chkType2.Checked = True Then
            chkType1.Checked = False
            chkType7.Checked = False
            pnPolicy.Visible = True
        End If
        If chkType1.Checked = False And chkType2.Checked = False And chkType7.Checked = False Then
            pnPolicy.Visible = False
        End If
    End Sub

    Private Sub chkType5_CheckedChanged(sender As Object, e As EventArgs) Handles chkType5.CheckedChanged
        If chkType5.Checked = True Then
            pnChange.Visible = True
        Else
            pnChange.Visible = False
        End If
    End Sub

    Private Sub chkType7_CheckedChanged(sender As Object, e As EventArgs) Handles chkType7.CheckedChanged
        If chkType1.Checked = True Or chkType7.Checked = True Then
            chkType2.Checked = False
            chkType1.Checked = False
            pnPolicy.Visible = True
        End If
        If chkType1.Checked = False And chkType2.Checked = False And chkType7.Checked = False Then
            pnPolicy.Visible = False
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