Imports System.Data
Imports BigLion
Public Class PharmacyGPPListAdmin
    Inherits System.Web.UI.Page

    Public dtGPP As New DataTable
    Dim ctlM As New MasterController
    Dim dt As New DataTable
    Dim ctlR As New ReportController

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsNothing(Request.Cookies("CPAQA")) Then
            Response.Redirect("Default.aspx")
        End If
        If Not IsPostBack Then
            LoadYearToDDL()
            ddlYear.SelectedValue = Now.Date.Year + 543
            LoadProvinceToDDL()
            LoadGPP()
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

    Private Sub LoadProvinceToDDL()
        Dim ctlU As New UserController
        dt = ctlU.ProvinceAllocate_Get4ReportByUser(StrNull2Zero(Request.Cookies("UserID").Value))

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
    Private Sub LoadGPP()
        Dim ctlA As New AssessmentController
        dtGPP = ctlA.GPP_GetByYearProvince(StrNull2Zero(ddlYear.SelectedValue), StrNull2Zero(ddlProvince.SelectedValue), StrNull2Zero(Request.Cookies("UserID").Value))
    End Sub

    Private Sub cmdView_Click(sender As Object, e As EventArgs) Handles cmdView.Click
        LoadGPP()
    End Sub

    Private Sub ddlYear_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlYear.SelectedIndexChanged
        LoadGPP()
    End Sub

    Private Sub ddlProvince_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlProvince.SelectedIndexChanged
        LoadGPP()
    End Sub
End Class