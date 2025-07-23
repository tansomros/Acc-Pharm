Imports System.Net
Imports BigLion
Public Class _Default
    Inherits Page
    Dim dt As New DataTable
    Dim acc As New UserController
    Dim enc As New CryptographyEngine
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        'If Request("t") Is Nothing Then
        'Response.Redirect("notice.aspx")
        'End If

        If Request("logout") = "y" Then
            Session.Contents.RemoveAll()
            Session.Abandon()
            Session.RemoveAll()
            Response.Cookies.Clear()

            Dim delCookie1 As HttpCookie
            delCookie1 = New HttpCookie("CPA")
            delCookie1.Expires = DateTime.Now.AddDays(-1D)
            Response.Cookies.Add(delCookie1)
        Else
            'RenewSessionFromCookie()
        End If

        If Not IsPostBack Then
            If Request("logout") = "y" Then
                Session.Abandon()
                Request.Cookies("UserID").Value = Nothing
            End If
            txtUsername.Focus()
        End If

        'Session.Timeout = 36000
        'Response.Redirect("Home")

    End Sub
    Private Sub CheckUser()
        dt = acc.User_CheckLogin(txtUsername.Text, enc.EncryptString(txtPassword.Text, True))

        If dt.Rows.Count > 0 Then

            If dt.Rows(0).Item("StatusFlag") <> "A" Then
                ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningAlert(this,'ผลการตรวจสอบ','ID ของท่านไม่สามารถใช้งานได้ชั่วคราว');", True)
                Exit Sub
            End If

            '--------------------------------------------------------------------------------------------

            Dim ckUserID As New HttpCookie("UserID")
            Dim ckUsername As New HttpCookie("Username")
            Dim ckLoginUser As New HttpCookie("LoginUser")
            Dim ckPassword As New HttpCookie("Password")
            Dim ckLastLogin As New HttpCookie("LastLogin")
            Dim ckNameOfUser As New HttpCookie("NameOfUser")
            'Dim ckPositionName As New HttpCookie("PositionName")
            Dim ckLoginPersonUID As New HttpCookie("LoginPersonUID")
            Dim ckLoginLocationUID As New HttpCookie("LoginLocationUID")
            Dim ckROLE_ID As New HttpCookie("ROLE_ID")
            Dim ckAdminAcc As New HttpCookie("AdminAcc")
            Dim ckAdminPharm As New HttpCookie("AdminPharm")
            'Dim ckPAYEAR As New HttpCookie("PAYEAR")

            Session("userid") = dt.Rows(0).Item("UserID")
            ckUserID.Value = dt.Rows(0).Item("UserID")
            ckUsername.Value = String.Concat(dt.Rows(0).Item("Username")).ToString()
            ckLoginUser.Value = String.Concat(dt.Rows(0).Item("Username")).ToString()
            ckPassword.Value = String.Concat(dt.Rows(0).Item("Passwords")).ToString()
            ckLastLogin.Value = String.Concat(dt.Rows(0).Item("LastLogin")).ToString()
            ckNameOfUser.Value = String.Concat(dt.Rows(0).Item("DisplayName"))
            ckLoginPersonUID.Value = String.Concat(dt.Rows(0)("UserID"))
            ckLoginLocationUID.Value = String.Concat(dt.Rows(0)("LocationUID"))
            ckROLE_ID.Value = DBNull2Zero(dt.Rows(0)("RoleID"))
            ckAdminAcc.Value = String.Concat(dt.Rows(0)("AdminAcc"))
            ckAdminPharm.Value = String.Concat(dt.Rows(0)("AdminPharm"))

            'iCPACookie("userid") = dt.Rows(0).Item("UserID")
            'iCPACookie("username") = String.Concat(dt.Rows(0).Item("Username")).ToString()
            'iCPACookie("Password") = enc.DecryptString(dt.Rows(0).Item("Passwords"), True)
            'iCPACookie("LastLogin") = String.Concat(dt.Rows(0).Item("LastLogin"))
            'iCPACookie("NameOfUser") = String.Concat(dt.Rows(0).Item("DisplayName"))
            'iCPACookie("LoginPersonUID") = dt.Rows(0).Item("UserID")
            'iCPACookie("LoginLocationUID") = dt.Rows(0).Item("LocationUID")
            'iCPACookie("ROLE_ID") = dt.Rows(0).Item("RoleID")
            ''iCPACookie("ROLE_USR") = False
            ''iCPACookie("ROLE_APP") = False
            ''iCPACookie("ROLE_SPA") = False


            Dim iCPACookie As HttpCookie = New HttpCookie("CPA")
            iCPACookie("UserID") = dt.Rows(0).Item("UserID")

            Session.Timeout = 60

            Response.Cookies.Add(ckUserID)
            Response.Cookies.Add(ckUsername)
            Response.Cookies.Add(ckPassword)
            Response.Cookies.Add(ckLoginUser)
            Response.Cookies.Add(ckNameOfUser)
            Response.Cookies.Add(ckLastLogin)
            Response.Cookies.Add(ckLoginPersonUID)
            Response.Cookies.Add(ckLoginLocationUID)
            Response.Cookies.Add(ckROLE_ID)
            Response.Cookies.Add(ckAdminAcc)
            Response.Cookies.Add(ckAdminPharm)

            iCPACookie.Expires = acc.GET_DATE_SERVER().AddMinutes(60)
            Response.Cookies.Add(iCPACookie)


            'If Request.Cookies("UserProfileID") <> 1 Then
            '    Dim ctlC As New CourseController
            '    Request.Cookies("ROLE_ADV") = ctlC.CoursesCoordinator_CheckStatus(Request.Cookies("ProfileID"))
            'End If

            'Dim ctlCfg As New SystemConfigController()
            'Request.Cookies("EDUYEAR") = ctlCfg.SystemConfig_GetByCode(CFG_EDUYEAR)
            'Request.Cookies("ASSMYEAR") = ctlCfg.SystemConfig_GetByCode(CFG_ASSMYEAR)

            'Dns.GetHostEntry(Request.ServerVariables("REMOTE_ADDR")).HostName
            acc.User_GenLogfile(Request.Cookies("UserID").Value, ACTTYPE_LOG, "Login", "UserID=" & Request.Cookies("UserID").Value, "service", Environment.MachineName, GetIPAddress())
            genLastLog()
            'acc.User_GenLogfile(txtUsername.Text, ACTTYPE_LOG, "Users", "", "")

            'Dim rd As New UserRoleController

            'dt = rd.UserAccessGroup_GetByUID(dt.Rows(0).Item("UserID"))
            'If dt.Rows.Count > 0 Then

            '    For i = 0 To dt.Rows.Count - 1
            '        Select Case dt.Rows(i)("UserGroupUID")
            '            Case 1   'Customer Admin
            '                iCPACookie("ROLE_ID").value = 3
            '                Request.Cookies("ROLE_ID").value = 3
            '            Case 2  'Customer User
            '                iCPACookie("ROLE_USR") = True
            '                Request.Cookies("ROLE_USR") = True
            '            Case 3 'Approver
            '                iCPACookie("ROLE_APP") = True
            '                Request.Cookies("ROLE_APP") = True
            '            Case 9  'NPC-SE Administrator
            '                iCPACookie("ROLE_ID").value = 3
            '                Request.Cookies("ROLE_ID").value = 3
            '        End Select
            '    Next
            'End If

            'Select Case Request.Cookies("UserProfileID")
            '    Case 1 'Customer
            '        Response.Redirect("Default.aspx")
            '    Case 2, 3 'Teacher
            '        Response.Redirect("Default.aspx")
            '    Case 4 'Admin
            Response.Redirect("PrivacyPolicy.aspx?p=log")
            'End Select

        Else
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningAlert(this,'ผลการตรวจสอบ','Username  หรือ Password ไม่ถูกต้อง');", True)
            Exit Sub
        End If
    End Sub

    Protected Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        'txtUsername.Value = "admin"
        'txtPassword.Value = "112233"
        'Request.Cookies("userid") = 1
        'Request.Cookies("ROLE_ID").value = 3
        'Response.Redirect("Home")
        If txtUsername.Text = "" Or txtPassword.Text = "" Then
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningAlert(this,'Warning!','กรุณาป้อน Username  หรือ Password ให้ครบถ้วนก่อน');", True)
            txtUsername.Focus()
            Exit Sub
        End If

        Session.Contents.RemoveAll()
        CheckUser()
    End Sub

    Private Sub genLastLog() ' เก็บวันเวลาที่ User เข้าใช้ระบบครั้งล่าสุด
        acc.User_LastLog1_Update(txtUsername.Text)
    End Sub

End Class