Imports BigLion
Public Class LocationNew
    Inherits System.Web.UI.Page
    Dim dt As New DataTable
    Dim ctlL As New LocationController
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsNothing(Request.Cookies("CPAQA")) Then
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

        If ctlL.Location_SearchByLicense(txtLicenseNo.Text) > 0 Then
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','เลขที่ใบอนุญาตนี้มี User ในระบบแล้ว');", True)
        Else
            Dim ctlFDA As New FDAServiceController
            Dim NewCode As String
            NewCode = ctlFDA.ConvertLicenseToNewCode(txtLicenseNo.Text)
            Try
                dt = ctlFDA.GET_DRUG_LCN_INFORMATION(NewCode)
            Catch ex As Exception
                ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningAlert(this,'ผลการตรวจสอบ','ไม่สามารถเชื่อมต่อระบบร้านยา สำนักงานคณะกรรมการอาหารและยา (อย.) ได้ในขณะนี้ กรุณาลองใหม่ภายหลัง หรือ ติดต่อผู้ดูแลระบบ');", True)
                'Exit Sub
            End Try

            If Not dt Is Nothing Then
                If dt.Rows.Count > 0 Then 'มีใน อย.
                    pnDetail.Visible = True
                    LoadLocationDataFromFDA()
                    pnReg.Visible = False
                Else
                    pnDetail.Visible = True
                    pnReg.Visible = False
                    lblLcnno.Text = txtLicenseNo.Text
                    ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningAlert(this,'ผลการตรวจสอบ','ไม่พบเลขที่ใบอนุญาตนี้ในฐานข้อมูลของ อย. กรุณาตรวจสอบและลองใหม่อีกครั้ง');", True)
                End If
            Else
                pnDetail.Visible = True
                pnReg.Visible = False
                lblLcnno.Text = txtLicenseNo.Text
                ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningAlert(this,'ผลการตรวจสอบ','ไม่พบเลขที่ใบอนุญาตนี้ในฐานข้อมูลของ อย. กรุณาตรวจสอบและลองใหม่อีกครั้ง');", True)
            End If

        End If
    End Sub
    Function checkField(tD As DataTable, ColumnName As String) As String
        If tD.Columns(ColumnName) IsNot Nothing Then
            Return String.Concat(tD.Rows(0)(ColumnName))
        Else
            Return ""
        End If
    End Function
    Private Sub LoadLocationDataFromFDA()
        Dim ctlFDA As New FDAServiceController
        Dim NewCode As String
        NewCode = ctlFDA.ConvertLicenseToNewCode(txtLicenseNo.Text)
        dt = ctlFDA.GET_DRUG_LCN_INFORMATION(NewCode)
        If dt Is Nothing Then
            lblthanm.Text = "ไม่พบเลข ขย.นี้ในฐานข้อมูล อย. กรุณาตรวจสอบ"
            Exit Sub
        End If
        If dt.Rows.Count > 0 Then
            dt.DefaultView.Sort = "appdate desc,lcnno desc"
            Dim dtResult As DataTable = dt.DefaultView.ToTable()

            With dtResult.Rows(0)
                Try
                    lblNewCode.Text = checkField(dtResult, "Newcode_not")
                    lblLcnno.Text = Replace(Replace(checkField(dtResult, "lcnno_no"), "ขย1 ", ""), " ", ".")
                    lblLcnsid.Text = checkField(dtResult, "lcnsid")
                    lblthanm.Text = checkField(dtResult, "thanm")
                    lblAddress.Text = checkField(dtResult, "thanm_address")
                    lblTel.Text = checkField(dtResult, "tel")
                    lblLicenTime.Text = checkField(dtResult, "licen_time")

                    lblLicenStatus.Text = checkField(dtResult, "cncnm")
                    lblAppdate.Text = checkField(dtResult, "appdate")
                    lblExpyear.Text = checkField(dtResult, "expyear")
                    lblGrannm.Text = checkField(dtResult, "grannm_lo")
                    'txtLicenseNo.Text = Replace(String.Concat(.Item("lcnno_noo")), " ", ".")
                    lblLastUpdate.Text = "Last update :" & checkField(dtResult, "lmdfdate")
                Catch ex As Exception

                End Try
            End With
        End If
    End Sub

    Private Sub cmdConfirm_Click(sender As Object, e As EventArgs) Handles cmdConfirm.Click
        Session("LicenseRegister") = lblLcnno.Text
        Response.Redirect("LocationModify.aspx?m=l&p=reg&s=" & Request("s"))
    End Sub
End Class