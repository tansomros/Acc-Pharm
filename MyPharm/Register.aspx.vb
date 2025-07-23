
Imports BigLion
Public Class Register
    Inherits Page
    Dim dt As New DataTable
    Dim ctlL As New LocationController
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        'If Request("logout") = "y" Then
        '    Session.Contents.RemoveAll()
        '    Session.Abandon()
        '    Session.RemoveAll()
        '    Response.Cookies.Clear()

        '    Dim delCookie1 As HttpCookie
        '    delCookie1 = New HttpCookie("CPA")
        '    delCookie1.Expires = DateTime.Now.AddDays(-1D)
        '    Response.Cookies.Add(delCookie1)
        'Else
        '    'RenewSessionFromCookie()
        'End If

        'If Not IsPostBack Then
        '    If Request("logout") = "y" Then
        '        Session.Abandon()
        '        Request.Cookies("userid") = Nothing
        '    End If
        '    txtUsername.Focus()
        'End If

        'Session.Timeout = 360
        ''Response.Redirect("Home")

    End Sub

    Protected Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        If Trim(txtLicenseNo.Text) = "" Then
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','กรุณาระบุเลขที่ใบอนุญาตขายยา (ขย.5) ก่อน');", True)
            Exit Sub
        End If

        If Len(Trim(txtLicenseNo.Text)) < 8 Or Len(Trim(txtLicenseNo.Text)) > 12 Then
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','กรุณาระบุเลขที่ใบอนุญาตขายยา (ขย.5) ให้ถูกต้อง');", True)
            Exit Sub
        End If

        Dim sL() As String
        sL = Split(txtLicenseNo.Text, "/")
        If sL.Length > 1 Then
            If sL(1).Length <> 4 Then
                ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','กรุณาระบุเลขที่ใบอนุญาตขายยา (ขย.5) ให้ถูกต้อง');", True)
                Exit Sub
            End If
        Else
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','กรุณาระบุเลขที่ใบอนุญาตขายยา (ขย.5) ให้ถูกต้อง');", True)
            Exit Sub
        End If

        If ctlL.Location_SearchByLicense(txtLicenseNo.Text) > 0 Then
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','เลขที่ใบอนุญาตนี้มี User ในระบบแล้ว กรุณา Login ด้วยรหัสผู้ใช้งานของท่าน');", True)
        Else
            Dim ctlFDA As New FDAServiceController
            Dim NewCode As String
            NewCode = ctlFDA.ConvertLicenseToNewCode(txtLicenseNo.Text)
            Try
                dt = ctlFDA.GET_DRUG_LCN_INFORMATION(NewCode)
            Catch ex As Exception
                ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningAlert(this,'ผลการตรวจสอบ','ไม่สามารถเชื่อมต่อระบบร้านยา สำนักงานคณะกรรมการอาหารและยา(อย.)ได้ในขณะนี้ กรุณาลองใหม่ภายหลัง หรือ ติดต่อผู้ดูแลระบบ');", True)
                Exit Sub
            End Try

            If Not dt Is Nothing Then
                If dt.Rows.Count > 0 Then 'มีใน อย.
                    Session("LicenseRegister") = txtLicenseNo.Text
                    Response.Redirect("PrivacyPolicy.aspx?p=reg")

                Else
                    ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningAlert(this,'ผลการตรวจสอบ','ไม่พบเลขที่ใบอนุญาตนี้ในฐานข้อมูลของ อย. กรุณาตรวจสอบและลองใหม่อีกครั้ง');", True)
                End If
            Else
                ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningAlert(this,'ผลการตรวจสอบ','ไม่พบเลขที่ใบอนุญาตนี้ในฐานข้อมูลของ อย. กรุณาตรวจสอบและลองใหม่อีกครั้ง');", True)
            End If

        End If
    End Sub


End Class