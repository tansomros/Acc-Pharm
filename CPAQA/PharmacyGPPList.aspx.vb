Imports System.Data
Imports BigLion
Public Class PharmacyGPPList
    Inherits System.Web.UI.Page
    Dim ctlL As New LocationController
    Public dtGPP As New DataTable

    Dim ctlM As New MasterController
    Dim dt As New DataTable

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsNothing(Request.Cookies("CPAQA")) Then
            Response.Redirect("Default.aspx")
        End If
        If Not IsPostBack Then
            LoadYearToDDL()
            ddlYear.SelectedValue = Now.Date.Year + 543
            LoadData()
        End If
    End Sub

    Private Sub LoadYearToDDL()
        dt = ctlM.GetAsmYear()
        If dt.Rows.Count > 0 Then
            With ddlYear
                .Enabled = True
                .DataSource = dt
                .DataTextField = "YearName"
                .DataValueField = "AsmYear"
                .DataBind()
                '.SelectedIndex = 0
            End With
        End If
        dt = Nothing
    End Sub

    Private Sub LoadData()
        If Convert.ToInt32(Request.Cookies("ROLE_ID").Value) >= 4 And Convert.ToInt32(Request.Cookies("ROLE_ID").Value) <= 5 Then
            dtGPP = ctlL.LocationAllocate_GetByUser(StrNull2Zero(ddlYear.SelectedValue), StrNull2Zero(Request.Cookies("UserID").Value))
        ElseIf Request.Cookies("ROLE_ID").Value = 5 Then
            dtGPP = ctlL.LocationAllocate_GetByUser(StrNull2Zero(ddlYear.SelectedValue), StrNull2Zero(Request.Cookies("UserID").Value))
        ElseIf Request.Cookies("ROLE_ID").Value = 9 Then
            dtGPP = ctlL.Location_GetForPPHealthByYear(StrNull2Zero(ddlYear.SelectedValue))
        End If
    End Sub

    Private Sub ddlYear_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlYear.SelectedIndexChanged
        LoadData()
    End Sub
End Class