Imports BigLion
Imports Newtonsoft.Json.Linq

Public Class UserModify
    Inherits System.Web.UI.Page
    Dim ctlU As New UserController
    Dim ctlR As New UserRoleController
    Dim enc As New CryptographyEngine

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsNothing(Request.Cookies("CPAQA")) Then
            Response.Redirect("Default.aspx")
        End If

        If Not IsPostBack Then
            pnAdmin.Visible = False
            chkStatus.Checked = True
            lblUserID.Text = ""
            cmdDelete.Enabled = False
            pnLocation.Visible = False
            pnPPH.Visible = False
            BindUserGroup()
            LoadLocation()
            LoadProvinceToDDL()

            If Not Request("uid") = Nothing Then
                EditUser()
            End If
        End If

        Dim scriptString As String = "javascript:return confirm(""ต้องการลบ ข้อมูลนี้ ?"");"
        cmdDelete.Attributes.Add("onClick", scriptString)
        txtEmail.Attributes.Add("OnKeyPress", "return NotAllowThai();")
        txtUsername.Attributes.Add("OnKeyPress", "return AllowOnlyEnglishAndInteger();")

    End Sub
    Private Sub BindUserGroup()
        chkGroup.Items.Clear()

        chkGroup.Items.Add("ร้านยา")
        chkGroup.Items(0).Value = 1
        chkGroup.Items.Add("ผู้ตรวจประเมิน")
        chkGroup.Items(1).Value = 2
        chkGroup.Items.Add("Admin")
        chkGroup.Items(2).Value = 3
        If Convert.ToInt32(Request.Cookies("ROLE_ID").Value) = 9 Then
            chkGroup.Items.Add("Super Admin")
            chkGroup.Items(3).Value = 9
            chkGroup.Items.Add("ผู้ประเมิน GPP")
            chkGroup.Items(4).Value = 4
            chkGroup.Items.Add("Admin สสจ.")
            chkGroup.Items(5).Value = 5
            'chkGroup.Items.Add("อาจารย์ประจำกลุ่ม (สสจ.)")
            'chkGroup.Items(6).Value = 6
            chkGroup.Items.Add("FDA Admin (อย.)")
            chkGroup.Items(6).Value = 7
            pnAdmin.Visible = True
        End If
    End Sub
    Private Sub LoadProvinceToDDL()
        Dim ctlM As New MasterController
        With ddlProvince
            .Enabled = True
            .DataSource = ctlM.Province_Get
            .DataTextField = "ProvinceName"
            .DataValueField = "ProvinceID"
            .DataBind()
            '.SelectedIndex = 0
        End With
    End Sub
    Private Sub LoadLocation()
        Dim ctlM As New LocationController
        ddlLocation.DataSource = ctlM.Location_GetForUser
        ddlLocation.DataTextField = "LocationName"
        ddlLocation.DataValueField = "UID"
        ddlLocation.DataBind()
    End Sub
    Private Sub EditUser()
        Dim dt As New DataTable
        dt = ctlU.User_GetByUserID(Request("uid"))

        If dt.Rows.Count > 0 Then
            With dt.Rows(0)
                lblUserID.Text = String.Concat(.Item("UserID"))
                txtDisplayname.Text = String.Concat(.Item("DisplayName"))
                txtTel.Text = String.Concat(.Item("Telephone"))
                txtEmail.Text = String.Concat(.Item("Email"))

                If DBNull2Zero(.Item("RoleID")) = 1 Then
                    ddlType.SelectedIndex = 0
                    pnLocation.Visible = True
                    pnPPH.Visible = False
                    LoadLocation()
                    ddlLocation.SelectedValue = String.Concat(.Item("LocationUID"))
                ElseIf DBNull2Zero(.Item("RoleID")) >= 4 And DBNull2Zero(.Item("RoleID")) <= 6 Then
                    ddlType.SelectedValue = "4"
                    pnPPH.Visible = True
                    pnLocation.Visible = False
                    ddlProvince.SelectedValue = String.Concat(.Item("ProvinceID"))
                Else
                    ddlType.SelectedIndex = 1
                    pnLocation.Visible = False
                    pnPPH.Visible = False
                End If

                txtUsername.Text = String.Concat(.Item("Username"))
                txtPassword.Text = enc.DecryptString(String.Concat(dt.Rows(0)("Passwords")), True)
                chkStatus.Checked = ConvertStatusFlag2CHK(String.Concat(.Item("StatusFlag")))

                chkGroup.SelectedValue = String.Concat(dt.Rows(0)("RoleID"))

                'If String.Concat(dt.Rows(0)("RoleID")) = 3 Or String.Concat(dt.Rows(0)("RoleID")) = 9 Then
                chkAdminAcc.Checked = ConvertYN2Boolean(String.Concat(.Item("AdminAcc")))
                    chkAdminPharm.Checked = ConvertYN2Boolean(String.Concat(.Item("AdminPharm")))
                    chkAdminComp.Checked = ConvertYN2Boolean(String.Concat(.Item("AdminComp")))
                'End If
                If String.Concat(dt.Rows(0)("RoleID")) = 5 Then
                    chkReporter.Checked = ConvertYN2Boolean(String.Concat(.Item("IsReporter")))
                End If

                cmdDelete.Enabled = True
            End With

        End If
    End Sub

    Function Check_Email(str As String) As Boolean
        Return Regex.IsMatch(str, "\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*")
    End Function
    Protected Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        If ddlLocation.SelectedIndex = -1 Or ddlLocation.SelectedValue = Nothing Then
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','กรุณาเลือกหน่วยงานก่อน');", True)
            Exit Sub
        End If

        If txtDisplayname.Text = "" Then
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','กรุณากรอก Display Name');", True)
            Exit Sub
        End If
        'If txtLastName.Text = "" Then
        '    ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','กรุณากรอกนามสกุล');", True)
        '    Exit Sub
        'End If
        'If txtEmail.Text = "" Then
        '    ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','กรุณากรอก E-mail');", True)
        '    Exit Sub
        'End If
        If txtEmail.Text <> "" Then
            If Check_Email(txtEmail.Text) = False Then
                ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningAlert(this,'ผลการตรวจสอบ','รูปแบบ E-mail ไม่ถูกต้อง กรุณาตรวจสอบ');", True)
                Exit Sub
            End If
        End If


        If txtUsername.Text = "" Then
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','กรุณากรอก Username');", True)
            Exit Sub
        End If
        If txtPassword.Text = "" Then
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','กรุณาระบุ Password');", True)
            Exit Sub
        End If

        If chkGroup.SelectedValue = "" Then
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','กรุณาระบุสิทธิ์ผู้ใช้งานก่อน');", True)
            Exit Sub
        End If

        If lblUserID.Text = "" Then
            If ctlU.User_CheckDuplicate(txtUsername.Text) Then
                ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','Username นี้มีในระบบแล้ว');", True)
                Exit Sub
            End If
        End If
        Dim Password As String = enc.EncryptString(txtPassword.Text, True)
        Dim LocationUID As Integer
        Dim ProvinceID As String = ""
        If ddlType.SelectedValue = "1" Then
            LocationUID = StrNull2Zero(ddlLocation.SelectedValue)
        ElseIf ddlType.SelectedValue = "4" Then
            ProvinceID = ddlProvince.SelectedValue
            LocationUID = 0
        Else
            LocationUID = 0
        End If

        ctlU.User_Save(StrNull2Zero(lblUserID.Text), txtUsername.Text, Password, txtDisplayname.Text, txtEmail.Text, txtTel.Text, StrNull2Zero(chkGroup.SelectedValue), LocationUID, ProvinceID, ConvertBoolean2StatusFlag(chkStatus.Checked), Request.Cookies("userid").Value, ConvertBoolean2YN(chkAdminAcc.Checked), ConvertBoolean2YN(chkAdminPharm.Checked), ConvertBoolean2YN(chkReporter.Checked), ConvertBoolean2YN(chkAdminComp.Checked))

        If lblUserID.Text = "" Then
            lblUserID.Text = ctlU.User_GetUID(txtUsername.Text)
        End If

        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalSuccess(this,'Success','บันทึกข้อมูลเรียบร้อย');", True)

    End Sub
    Private Sub ClearData()
        lblUserID.Text = ""
        txtDisplayname.Text = ""
        txtUsername.Text = ""
        txtPassword.Text = ""
        txtTel.Text = ""
        txtEmail.Text = ""
        ddlType.SelectedIndex = 1
        pnLocation.Visible = False
        pnPPH.Visible = False
        cmdDelete.Enabled = False
    End Sub
    Protected Sub cmdDelete_Click(sender As Object, e As EventArgs) Handles cmdDelete.Click
        ctlU.User_Delete(lblUserID.Text)
        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalSuccess(this,'ผลการทำงาน','ลบข้อมูลเรียบร้อย');", True)

        Response.Redirect("Users?m=u&s=u")
    End Sub

    Protected Sub cmdClear_Click(sender As Object, e As EventArgs) Handles cmdClear.Click
        ClearData()
    End Sub

    Protected Sub ddlType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlType.SelectedIndexChanged
        If ddlType.SelectedValue = "1" Then
            pnLocation.Visible = True
            pnPPH.Visible = False
        ElseIf ddlType.SelectedValue = "4" Then
            pnPPH.Visible = True
            pnLocation.Visible = False
        Else
            pnLocation.Visible = False
            pnPPH.Visible = False
        End If
    End Sub

    'Protected Sub grdLocation_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grdLocation.RowCommand
    '    If TypeOf e.CommandSource Is WebControls.ImageButton Then
    '        Dim ButtonPressed As WebControls.ImageButton = e.CommandSource
    '        Select Case ButtonPressed.ID
    '            Case "imgDel"
    '                If ctlU.UserLocation_Delete(e.CommandArgument) Then
    '                    ctlU.User_GenLogfile(Request.Cookies("UserID").Value, "DEL", "UserLocation", "ลบ UserLocation :" & e.CommandArgument, "")
    '                    EditUserLocationToGrid()
    '                Else
    '                    ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalSuccess(this,'ผลการตรวจสอบ','ไม่สามารถลบข้อมูลได้ กรุณาตรวจสอบและลองใหม่อีกครั้ง');", True)
    '                End If
    '        End Select
    '    End If
    'End Sub

    'Protected Sub cmdAddLocation_Click(sender As Object, e As EventArgs) Handles cmdAddLocation.Click
    '    If ddlLocation.SelectedValue = "0" Then
    '        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','กรุณาเลือกบริษัทที่ให้สิทธิก่อน');", True)
    '        Exit Sub
    '    End If

    '    ctlU.UserLocation_Save(StrNull2Zero(lblUserID.Text), txtUsername.Text, ddlLocation.SelectedValue)
    '    ddlLocation.SelectedIndex =0
    '    EditUserLocationToGrid()
    'End Sub
End Class