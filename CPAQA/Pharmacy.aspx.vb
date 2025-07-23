Imports System
Imports BigLion
Public Class Pharmacy
    Inherits System.Web.UI.Page
    Dim ctlL As New LocationController
    Dim ctlM As New MasterController
    Public dtLoc As New DataTable
    Dim dt As New DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            LoadProvinceToDDL()
            'LoadNHSOToDDL()
            LoadProvinceGroupToDDL()
            LoadData()
        End If
    End Sub
    Private Sub LoadProvinceToDDL()
        If ddlProvinceGroup.SelectedValue = "0" Then
            dt = ctlM.Province_GetForReport()
        Else
            dt = ctlM.Province_GetForReportByGroup(ddlProvinceGroup.SelectedValue)
        End If

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
    'Private Sub LoadNHSOToDDL()
    '    dt = ctlM.NHSO_GetForReport
    '    If dt.Rows.Count > 0 Then
    '        With ddlNHSO
    '            .Enabled = True
    '            .DataSource = dt
    '            .DataTextField = "NHSOName"
    '            .DataValueField = "NHSOID"
    '            .DataBind()
    '            '.SelectedIndex = 0
    '        End With
    '    End If
    '    dt = Nothing
    'End Sub
    Private Sub LoadProvinceGroupToDDL()
        dt = ctlM.ProvinceGroup_GetForReport
        If dt.Rows.Count > 0 Then
            With ddlProvinceGroup
                .Enabled = True
                .DataSource = dt
                .DataTextField = "ProvinceGroupName"
                .DataValueField = "ProvinceGroupUID"
                .DataBind()
                '.SelectedIndex = 0
            End With
        End If
        dt = Nothing
    End Sub

    Private Sub LoadData()
        dtLoc = ctlL.Location_GetForWeb(ddlProvinceGroup.SelectedValue, ddlProvince.SelectedValue, txtSearch.Text)
    End Sub
    Private Sub cmdView_Click(sender As Object, e As EventArgs) Handles cmdView.Click
        LoadData()
    End Sub
    Protected Sub ddlProvinceGroup_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlProvinceGroup.SelectedIndexChanged
        LoadProvinceToDDL()
        LoadData()
    End Sub


    Private Sub ddlProvince_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlProvince.SelectedIndexChanged
        LoadData()
    End Sub
End Class