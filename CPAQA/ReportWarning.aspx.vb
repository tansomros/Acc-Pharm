Imports BigLion
Public Class ReportWarning
    Inherits System.Web.UI.Page
    Dim ctlM As New MasterController
    Dim dt As New DataTable
    Dim acc As New UserController
    Public dtR As New DataTable
    Dim ctlR As New ReportController
    Dim ctlL As New LocationController

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsNothing(Request.Cookies("CPAQA")) Then
            Response.Redirect("Default.aspx")
        End If
        If Not IsPostBack Then
            pnData.Visible = False
            LoadSeqNo()
            LoadProvinceToDDL()
            LoadWarningSubjectToDDL()
            LoadLocation()
            txtStartDate.Text = Today.Date.ToString("dd/MM/yyyy")
            txtEndDate.Text = Today.Date.ToString("dd/MM/yyyy")
            lblReportTitle.Text = "รายงานการตักเตือนจาก สรร."

        End If

    End Sub
    Private Sub LoadSeqNo()
        ddlSeq.DataSource = ctlL.LocationWarning_GetSEQ
        ddlSeq.DataTextField = "SeqName"
        ddlSeq.DataValueField = "SeqNo"
        ddlSeq.DataBind()
        ddlSeq.SelectedIndex = 0
    End Sub
    Private Sub LoadProvinceToDDL()
        dt = ctlM.Province_GetForReport()
        If dt.Rows.Count > 0 Then
            With ddlProvince
                .Enabled = True
                .DataSource = dt
                .DataTextField = "ProvinceName"
                .DataValueField = "ProvinceID"
                .DataBind()
                '.SelectedIndex = 0
            End With
        End If
        dt = Nothing
    End Sub
    Private Sub LoadWarningSubjectToDDL()
        dt = ctlM.WarningType_Get4Report()
        If dt.Rows.Count > 0 Then
            With ddlWarningType
                .Enabled = True
                .DataSource = dt
                .DataTextField = "Name"
                .DataValueField = "Code"
                .DataBind()
            End With
        End If
        dt = Nothing
    End Sub
    Private Sub LoadLocation()
        ddlLocation.DataSource = ctlL.LocationWarning_GetByAccForReport(ddlAccPharm.SelectedValue, ddlProvince.SelectedValue)
        ddlLocation.DataTextField = "LocationName"
        ddlLocation.DataValueField = "LocationUID"
        ddlLocation.DataBind()
    End Sub

    Protected Sub cmdView_Click(sender As Object, e As EventArgs) Handles cmdView.Click
        If txtStartDate.Text = "" Or txtEndDate.Text = "" Then
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModals(this,'ผลการตรวจสอบ','กรุณาระบุช่วงวันที่ก่อน');", True)
            Exit Sub
        End If

        Dim Bdate, Edate As String
        Bdate = ConvertStrDate2DBDate(txtStartDate.Text)
        Edate = ConvertStrDate2DBDate(txtEndDate.Text)

        dtR = ctlR.LocationWarning_GetSearch(Bdate, Edate, ddlSeq.SelectedValue, ddlWarningType.SelectedValue, ddlProvince.SelectedValue, ddlAccPharm.SelectedValue, ddlLocation.SelectedValue, txtSearch.Text.Trim())

        pnData.Visible = True
    End Sub

    Protected Sub cmdExport_Click(sender As Object, e As EventArgs) Handles cmdExport.Click
        If txtStartDate.Text = "" Or txtEndDate.Text = "" Then
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModals(this,'ผลการตรวจสอบ','กรุณาระบุช่วงวันที่ก่อน');", True)
            Exit Sub
        End If
        Dim Bdate, Edate As String
        Bdate = ConvertStrDate2DBDate(txtStartDate.Text)
        Edate = ConvertStrDate2DBDate(txtEndDate.Text)
        pnData.Visible = False

        ctlR.GEN_LocationWarning_Report(Bdate, Edate, ddlSeq.SelectedValue, ddlWarningType.SelectedValue, ddlProvince.SelectedValue, ddlAccPharm.SelectedValue, ddlLocation.SelectedValue, txtSearch.Text.Trim(), Request.Cookies("UserID").Value)

        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "Report", "window.open('ReportViewer?R=" & Request("s") & "&RPTTYPE=EXCEL','_blank');", True)

        'ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "Report", "window.open('ReportViewer?R=" & Request("s") & "&t=" & ddlAccPharm.SelectedValue & "&s=" & ddlWarningType.SelectedValue & "&pv=" & ddlProvince.SelectedValue & "&lid=" & ddlLocation.SelectedValue & "&seqno=" & ddlSeq.SelectedValue & "&find=" & txtSearch.Text & "&BDT=" & Bdate & "&EDT=" & Edate & "&RPTTYPE=EXCEL','_blank');", True)
    End Sub

    Private Sub ddlAccPharm_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlAccPharm.SelectedIndexChanged
        LoadLocation()
    End Sub

    Private Sub ddlProvince_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlProvince.SelectedIndexChanged
        LoadLocation()
    End Sub
End Class

