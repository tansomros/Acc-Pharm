Imports BigLion
Public Class ReportRisk
    Inherits System.Web.UI.Page
    Dim ctlM As New MasterController
    Dim dt As New DataTable
    Dim acc As New UserController
    Public dtR As New DataTable
    Dim ctlR As New RequestController
    Dim ctlRpt As New ReportController

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsNothing(Request.Cookies("CPAQA")) Then
            Response.Redirect("Default.aspx")
        End If
        If Not IsPostBack Then
            pnData.Visible = False
            LoadYearToDDL()
            'LoadRequestType()
            'LoadStatus()
            'LoadLocation()
            'txtStartDate.Text = Today.Date.ToString("dd/MM/yyyy")
            'txtEndDate.Text = Today.Date.ToString("dd/MM/yyyy")
            lblReportTitle.Text = "รายงานการเฝ้าระวัง/ความเสี่ยง"
            'If Request("s") = "A1" Then
            'Else
            '    lblReportTitle.Text = "รายงานคำขอรับรองฯ"
            'End If
        End If

    End Sub
    Private Sub LoadYearToDDL()
        dt = ctlM.GetRiskYear()
        If dt.Rows.Count > 0 Then
            With ddlYear
                .Enabled = True
                .DataSource = dt
                .DataTextField = "YearName"
                .DataValueField = "RiskYear"
                .DataBind()
                '.SelectedIndex = 0
            End With
        End If
        dt = Nothing
    End Sub

    'Private Sub LoadRequestType()
    '    ddlType.DataSource = ctlR.RequestType_GetForReport
    '    ddlType.DataTextField = "Name"
    '    ddlType.DataValueField = "UID"
    '    ddlType.DataBind()
    'End Sub
    'Private Sub LoadStatus()
    '    dt = ctlM.AssessmentStatus_GetForReport()
    '    If dt.Rows.Count > 0 Then
    '        With ddlStatus
    '            .DataSource = dt
    '            .DataTextField = "Descriptions"
    '            .DataValueField = "Code"
    '            .DataBind()
    '        End With
    '    End If
    'End Sub

    'Private Sub LoadLocation()
    '    Dim ctlL As New LocationController
    '    ddlLocation.DataSource = ctlL.Location_GetForReport
    '    ddlLocation.DataTextField = "LocationName"
    '    ddlLocation.DataValueField = "LocationUID"
    '    ddlLocation.DataBind()
    'End Sub 

    Protected Sub cmdView_Click(sender As Object, e As EventArgs) Handles cmdView.Click
        'If txtStartDate.Text = "" Or txtEndDate.Text = "" Then
        '    ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModals(this,'ผลการตรวจสอบ','กรุณาระบุช่วงวันที่ก่อน');", True)
        '    Exit Sub
        'End If

        'Dim Bdate, Edate As String
        'Bdate = ConvertStrDate2DBDate(txtStartDate.Text)
        'Edate = ConvertStrDate2DBDate(txtEndDate.Text)
        dtR = ctlRpt.RPT_LocationRisk_Get(ddlYear.SelectedValue, ddlStatus.SelectedValue)
        pnData.Visible = True
    End Sub

    Protected Sub cmdExport_Click(sender As Object, e As EventArgs) Handles cmdExport.Click
        'If txtStartDate.Text = "" Or txtEndDate.Text = "" Then
        '    ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModals(this,'ผลการตรวจสอบ','กรุณาระบุช่วงวันที่ก่อน');", True)
        '    Exit Sub
        'End If
        'Dim Bdate, Edate As String
        'Bdate = ConvertStrDate2DBDate(txtStartDate.Text)
        'Edate = ConvertStrDate2DBDate(txtEndDate.Text)
        pnData.Visible = False

        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "Report", "window.open('ReportViewer?R=" & Request("s") & "&y=" & ddlYear.SelectedValue & "&level=" & ddlStatus.SelectedValue & "&RPTTYPE=EXCEL','_blank');", True)


    End Sub
End Class

