Imports BigLion
Public Class ReportRequest
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
            'pnData.Visible = False
            LoadRequestType()
            LoadStatus()
            txtStartDate.Text = Today.Date.ToString("dd/MM/yyyy")
            txtEndDate.Text = Today.Date.ToString("dd/MM/yyyy")
            If Request("s") = "R1" Then
                lblReportTitle.Text = "รายงานคำขอรับรองฯ แยกตามสถานะการประเมิน"
            ElseIf Request("s") = "R2" Then
                lblReportTitle.Text = "รายงานคำขอรับรองฯ แยกตามประเภท"
            Else
                lblReportTitle.Text = "รายงานคำขอรับรองฯ"
            End If
        End If

    End Sub
    Private Sub LoadRequestType()
        ddlType.DataSource = ctlR.RequestType_GetForReport
        ddlType.DataTextField = "Name"
        ddlType.DataValueField = "UID"
        ddlType.DataBind()
    End Sub
    Private Sub LoadStatus()
        dt = ctlM.AssessmentStatus_GetForReport()
        If dt.Rows.Count > 0 Then
            With ddlStatus
                .DataSource = dt
                .DataTextField = "Descriptions"
                .DataValueField = "Code"
                .DataBind()
            End With
        End If
    End Sub

    Protected Sub cmdView_Click(sender As Object, e As EventArgs) Handles cmdView.Click
        If txtStartDate.Text = "" Or txtEndDate.Text = "" Then
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModals(this,'ผลการตรวจสอบ','กรุณาระบุช่วงวันที่ก่อน');", True)
            Exit Sub
        End If

        Dim Bdate, Edate As String
        Bdate = ConvertStrDate2DBDate(txtStartDate.Text)
        Edate = ConvertStrDate2DBDate(txtEndDate.Text)
        If Convert.ToInt32(Request.Cookies("ROLE_ID").Value) = 2 Then
            If Request("s") = "R1" Then
                dtR = ctlRpt.RPT_Request_GetByStatus(Bdate, Edate, ddlStatus.SelectedValue, StrNull2Zero(Request.Cookies("UserID").Value))
            ElseIf Request("s") = "R2" Then
                dtR = ctlRpt.RPT_Request_GetByType(Bdate, Edate, ddlType.SelectedValue, StrNull2Zero(Request.Cookies("UserID").Value))
            End If
        Else
            If Request("s") = "R1" Then
                dtR = ctlRpt.RPT_Request_GetByStatus(Bdate, Edate, ddlStatus.SelectedValue)
            ElseIf Request("s") = "R2" Then
                dtR = ctlRpt.RPT_Request_GetByType(Bdate, Edate, ddlType.SelectedValue)
            End If
        End If
        'pnData.Visible = True
    End Sub

    Protected Sub cmdExport_Click(sender As Object, e As EventArgs) Handles cmdExport.Click
        If txtStartDate.Text = "" Or txtEndDate.Text = "" Then
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModals(this,'ผลการตรวจสอบ','กรุณาระบุช่วงวันที่ก่อน');", True)
            Exit Sub
        End If

        Dim Bdate, Edate As String
        Bdate = ConvertStrDate2DBDate(txtStartDate.Text)
        Edate = ConvertStrDate2DBDate(txtEndDate.Text)

        'Bdate = Right(txtStartDate.Text, 4) + "-" + Mid(txtStartDate.Text, 4, 2) + "-" + Left(txtStartDate.Text, 2)
        'Edate = Right(txtEndDate.Text, 4) + "-" + Mid(txtEndDate.Text, 4, 2) + "-" + Left(txtEndDate.Text, 2)

        'If Request("s") = "R1" Then
        '    'ctlR.GEN_LocationReportBySearch(ddlGroup.SelectedValue, ddlChain.SelectedValue, ddlType.SelectedValue, ddlNHSO.SelectedValue, ddlProvinceGroup.SelectedValue, ddlProvince.SelectedValue, ddlAccStatus.SelectedValue, txtSearch.Text, Request.Cookies("UserID").Value)
        '    'dtR = ctlRpt.RPT_Request_GetByStatus(txtStartDate.Text, txtEndDate.Text, ddlStatus.SelectedValue)
        'ElseIf Request("s") = "R2" Then
        '    'dtR = ctlRpt.RPT_Request_GetByType(txtStartDate.Text, txtEndDate.Text, ddlType.SelectedValue)
        'End If
        'pnData.Visible = False
        If Convert.ToInt32(Request.Cookies("ROLE_ID").Value) = 2 Then
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "Report", "window.open('ReportViewer?R=" & Request("s") & "S&ST=" & ddlStatus.SelectedValue & "&TYPE=" & ddlType.SelectedValue & "&BDT=" & Bdate & "&EDT=" & Edate & "&RPTTYPE=EXCEL','_blank');", True)
        Else
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "Report", "window.open('ReportViewer?R=" & Request("s") & "&ST=" & ddlStatus.SelectedValue & "&TYPE=" & ddlType.SelectedValue & "&BDT=" & Bdate & "&EDT=" & Edate & "&RPTTYPE=EXCEL','_blank');", True)
        End If

    End Sub
End Class

