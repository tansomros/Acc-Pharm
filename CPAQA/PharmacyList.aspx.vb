Imports System.Data
Imports BigLion
Public Class PharmacyList
    Inherits System.Web.UI.Page
    Dim ctlL As New LocationController
    Public dtPPH As New DataTable
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
        dtPPH.Rows.Clear()

        If Convert.ToInt32(Request.Cookies("ROLE_ID").Value) = 4 Then 'ผู้ตรวจประเมินของ สสจ
            dtPPH = ctlL.Location_GetByPPHealth(StrNull2Zero(ddlYear.SelectedValue), StrNull2Zero(Request.Cookies("UserID").Value))
        ElseIf Request.Cookies("ROLE_ID").Value = 5 Then 'admin สสจ
            dtPPH = ctlL.Location_GetByPPHealthAdmin(StrNull2Zero(ddlYear.SelectedValue), StrNull2Zero(Request.Cookies("UserID").Value))
        ElseIf Request.Cookies("ROLE_ID").Value = 9 Then
            dtPPH = ctlL.Location_GetForPPHealth(StrNull2Zero(ddlYear.SelectedValue))
        End If
    End Sub

    Private Sub ddlYear_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlYear.SelectedIndexChanged
        LoadData()
    End Sub
End Class