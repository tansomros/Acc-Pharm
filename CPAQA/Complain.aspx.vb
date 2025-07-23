Imports System.Data
Imports BigLion
Public Class Complain
    Inherits System.Web.UI.Page
    Dim ctlR As New ComplainController
    Public dtREQ As New DataTable
    Dim ctlM As New MasterController
    Dim dt As New DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsNothing(Request.Cookies("CPAQA")) Then
            Response.Redirect("Default.aspx")
        End If
        If Not IsPostBack Then
            'txtStartDate.Text = DateAdd(DateInterval.Year, -1, Today.Date).ToString("dd/MM/yyyy")
            txtStartDate.Text = "01/01/" & Today.Year + 542
            txtEndDate.Text = Today.Date.ToString("dd/MM/yyyy")

            LoadProblemToDDL()
            LoadComplainList()

            'Select Case Request("s")
            '    Case "asm"


            'Case "apv"
            '    lblTitle.Text = ""
            '    If Request.Cookies("ROLE_ID").Value = 2 Then
            '        dtREQ = ctlL.Complain_GetForApproval(Request.Cookies("LoginLocationUID").Value, Request.Cookies("UserID").Value, Request.Cookies("PeriodID").Value)
            '    End If
            '    Case Else
            '        Response.Redirect("Home.aspx")
            'End Select

        End If
    End Sub
    Private Sub LoadProblemToDDL()
        dt = ctlR.ComplainProblem_GetForReport()
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

    Private Sub LoadComplainList()
        If txtStartDate.Text = "" Then
            txtStartDate.Text = DateAdd(DateInterval.Year, -1, Today.Date).ToString("dd/MM/yyyy")
        End If
        If txtEndDate.Text = "" Then
            txtEndDate.Text = Today.Date.ToString("dd/MM/yyyy")
        End If

        Dim Bdate, Edate As String
        Bdate = ConvertStrDate2DBDate(txtStartDate.Text)
        Edate = ConvertStrDate2DBDate(txtEndDate.Text)

        dtREQ = ctlR.Complain_GetBySearch(Bdate, Edate, ddlProblem.SelectedValue, ddlStatus.SelectedValue, txtSearch.Text)
    End Sub

    Protected Sub cmdView_Click(sender As Object, e As EventArgs) Handles cmdView.Click
        LoadComplainList()
    End Sub

    Protected Sub ddlType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlProblem.SelectedIndexChanged
        LoadComplainList()
    End Sub

    Protected Sub ddlStatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlStatus.SelectedIndexChanged
        LoadComplainList()
    End Sub
End Class