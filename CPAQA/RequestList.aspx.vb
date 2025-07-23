Imports System.Data
Imports BigLion
Public Class RequestList
    Inherits System.Web.UI.Page
    Dim ctlR As New RequestController
    Public dtREQ As New DataTable
    Dim ctlM As New MasterController
    Dim dt As New DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsNothing(Request.Cookies("CPAQA")) Then
            Response.Redirect("Default.aspx")
        End If
        If Not IsPostBack Then
            lblTitle.Text = "รายการคำขอ"
            'txtStartDate.Text = DateAdd(DateInterval.Year, -1, Today.Date).ToString("dd/MM/yyyy")
            txtStartDate.Text = "01/01/" & Today.Year + 542
            txtEndDate.Text = Today.Date.ToString("dd/MM/yyyy")

            LoadRequestType()
            LoadStatus()
            LoadRequestList()

            'Select Case Request("s")
            '    Case "asm"


            'Case "apv"
            '    lblTitle.Text = ""
            '    If Request.Cookies("ROLE_ID").Value = 2 Then
            '        dtREQ = ctlL.Request_GetForApproval(Request.Cookies("LoginLocationUID").Value, Request.Cookies("UserID").Value, Request.Cookies("PeriodID").Value)
            '    End If
            '    Case Else
            '        Response.Redirect("Home.aspx")
            'End Select

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
    Private Sub LoadRequestList()
        If txtStartDate.Text = "" Then
            txtStartDate.Text = DateAdd(DateInterval.Year, -1, Today.Date).ToString("dd/MM/yyyy")
        End If
        If txtEndDate.Text = "" Then
            txtEndDate.Text = Today.Date.ToString("dd/MM/yyyy")
        End If

        Dim Bdate, Edate As String
        Bdate = ConvertStrDate2DBDate(txtStartDate.Text)
        Edate = ConvertStrDate2DBDate(txtEndDate.Text)

        If Request.Cookies("ROLE_ID").Value = 1 Then
            dtREQ = ctlR.Request_GetByLocation(Request.Cookies("LoginLocationUID").Value, Bdate, Edate, ddlType.SelectedValue, ddlStatus.SelectedValue)
        ElseIf Request.Cookies("ROLE_ID").Value = 2 Then
            dtREQ = ctlR.Request_GetBySupervisor(StrNull2Zero(Request.Cookies("UserID").Value), Bdate, Edate, ddlType.SelectedValue, ddlStatus.SelectedValue)
        ElseIf Request.Cookies("ROLE_ID").Value = 3 Then
            dtREQ = ctlR.Request_GetByAdmin(Bdate, Edate, ddlType.SelectedValue, ddlStatus.SelectedValue)
        Else
            dtREQ = ctlR.Request_GetBySuperAdmin(Bdate, Edate, ddlType.SelectedValue, ddlStatus.SelectedValue)
        End If
    End Sub


    Protected Sub cmdView_Click(sender As Object, e As EventArgs) Handles cmdView.Click
        LoadRequestList()
    End Sub

    Protected Sub ddlType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlType.SelectedIndexChanged
        LoadRequestList()
    End Sub

    Protected Sub ddlStatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlStatus.SelectedIndexChanged
        LoadRequestList()
    End Sub
End Class