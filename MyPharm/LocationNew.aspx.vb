
Imports BigLion
Public Class LocationNew
    Inherits System.Web.UI.Page
    Dim dt As New DataTable
    Dim ctlL As New LocationController
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsNothing(Request.Cookies("CPA")) Then
            Response.Redirect("Default.aspx")
        End If
        If Not IsPostBack Then
            pnDetail.Visible = False
        End If
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
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','เลขที่ใบอนุญาตนี้มี User ในระบบแล้ว');", True)
        Else
            Dim ctlFDA As New FDAServiceController
            Dim NewCode As String
            NewCode = ctlFDA.ConvertLicenseToNewCode(txtLicenseNo.Text)
            Try
                dt = ctlFDA.GET_DRUG_LCN_INFORMATION(NewCode)
            Catch ex As Exception

            End Try

            If Not dt Is Nothing Then
                If dt.Rows.Count > 0 Then 'มีใน อย.
                    pnDetail.Visible = True
                    LoadLocationDataFromFDA()
                    pnReg.Visible = False
                Else
                    ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningAlert(this,'ผลการตรวจสอบ','ไม่พบเลขที่ใบอนุญาตนี้ในฐานข้อมูลของ อย. กรุณาตรวจสอบและลองใหม่อีกครั้ง');", True)
                End If
            Else
                ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningAlert(this,'ผลการตรวจสอบ','ไม่พบเลขที่ใบอนุญาตนี้ในฐานข้อมูลของ อย. กรุณาตรวจสอบและลองใหม่อีกครั้ง');", True)
            End If

        End If
    End Sub
    Private Sub LoadLocationDataFromFDA()
        Dim ctlFDA As New FDAServiceController
        Dim NewCode As String
        NewCode = ctlFDA.ConvertLicenseToNewCode(txtLicenseNo.Text)
        Try
            dt = ctlFDA.GET_DRUG_LCN_INFORMATION(NewCode)
        Catch ex As Exception

        End Try

        If dt Is Nothing Then
            lblthanm.Text = "ไม่พบเลข ขย.นี้ในฐานข้อมูล อย. กรุณาตรวจสอบ"
            Exit Sub
        End If
        If dt.Rows.Count > 0 Then
            dt.DefaultView.Sort = "appdate desc,lcnno desc"
            Dim dtResult As DataTable = dt.DefaultView.ToTable()

            With dtResult.Rows(0)
                Try
                    lblNewCode.Text = String.Concat(.Item("Newcode_not"))
                    lblLcnno.Text = String.Concat(.Item("lcnno_no"))
                    lblLcnsid.Text = String.Concat(.Item("lcnsid"))
                    lblthanm.Text = String.Concat(.Item("thanm"))
                    lblAddress.Text = String.Concat(.Item("thanm_address"))
                    lblTel.Text = String.Concat(.Item("tel"))
                    lblLicenTime.Text = String.Concat(.Item("licen_time"))

                    lblLicenStatus.Text = String.Concat(.Item("cncnm"))
                    lblAppdate.Text = String.Concat(.Item("appdate"))
                    lblExpyear.Text = String.Concat(.Item("expyear"))
                    lblGrannm.Text = String.Concat(.Item("grannm_lo"))

                    txtLicenseNo.Text = Replace(String.Concat(.Item("lcnno_noo")), " ", ".")

                    lblLastUpdate.Text = "Last update :" & String.Concat(.Item("lmdfdate"))
                Catch ex As Exception

                End Try
            End With
        End If
    End Sub

    Private Sub cmdConfirm_Click(sender As Object, e As EventArgs) Handles cmdConfirm.Click
        Session("LicenseRegister") = txtLicenseNo.Text
        Response.Redirect("LocationModify.aspx?m=l&p=reg")
    End Sub
End Class