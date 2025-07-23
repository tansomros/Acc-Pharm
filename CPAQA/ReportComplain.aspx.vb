Imports System.Data
Imports BigLion
Public Class ReportComplain
    Inherits System.Web.UI.Page
    Dim ctlR As New ReportController
    Dim ctlM As New MasterController
    Dim ctlL As New LocationController
    Dim dt As New DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsNothing(Request.Cookies("CPAQA")) Then
            Response.Redirect("Default.aspx")
        End If
        If Not IsPostBack Then
            lblTitle.Text = "รายงานข้อร้องเรียน"
            'txtStartDate.Text = DateAdd(DateInterval.Year, -1, Today.Date).ToString("dd/MM/yyyy")
            txtStartDate.Text = "01/01/" & Today.Year + 542
            txtEndDate.Text = Today.Date.ToString("dd/MM/yyyy")
            LoadProblemToDDL()
            LoadLocationProject()
            LoadProvinceToDDL()
            LoadLocation()
        End If
    End Sub
    Private Sub LoadProblemToDDL()
        Dim ctlC As New ComplainController
        dt = ctlC.ComplainProblem_GetForReport()
        If dt.Rows.Count > 0 Then
            With ddlProblem
                .Enabled = True
                .DataSource = dt
                .DataTextField = "Descriptions"
                .DataValueField = "UID"
                .DataBind()
            End With
        End If
        dt = Nothing
    End Sub
    Private Sub LoadLocationProject()
        Dim ctlC As New ComplainController
        dt = ctlc.ComplainProject_GetForReport
        If dt.Rows.Count > 0 Then
            With ddlProject
                .Enabled = True
                .DataSource = dt
                .DataTextField = "Descriptions"
                .DataValueField = "UID"
                .DataBind()
            End With
        End If
        dt = Nothing
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
    Private Sub LoadLocation()
        ddlLocation.DataSource = ctlL.LocationComplain_GetForReport(ddlProvince.SelectedValue)
        ddlLocation.DataTextField = "LocationName"
        ddlLocation.DataValueField = "LocationUID"
        ddlLocation.DataBind()
    End Sub
    Private Sub cmdExport_Click(sender As Object, e As EventArgs) Handles cmdExport.Click
        'If txtStartDate.Text = "" Then
        '    txtStartDate.Text = DateAdd(DateInterval.Year, -1, Today.Date).ToString("dd/MM/yyyy")
        'End If
        'If txtEndDate.Text = "" Then
        '    txtEndDate.Text = Today.Date.ToString("dd/MM/yyyy")
        'End If

        Dim Bdate, Edate As String
        Bdate = ConvertStrDate2DBDate(txtStartDate.Text)
        Edate = ConvertStrDate2DBDate(txtEndDate.Text)

        ctlR.GEN_ComplainReport(Bdate, Edate, ddlProject.SelectedValue, ddlProblem.SelectedValue, ddlStatus.SelectedValue, ddlEvidence.SelectedValue, ddlProvince.SelectedValue, ddlLocation.SelectedValue, txtSearch.Text, Request.Cookies("UserID").Value)

        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "Report", "window.open('ReportViewer?R=" & Request("s") & "&RPTTYPE=EXCEL','_blank');", True)
    End Sub

    Private Sub ddlProvince_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlProvince.SelectedIndexChanged
        LoadLocation()
    End Sub
End Class