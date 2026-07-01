Imports System.Data
Imports BigLion
Public Class LocationList
    Inherits System.Web.UI.Page
    Dim ctlL As New LocationController
    Dim ctlM As New MasterController
    Public dtLoc As New DataTable
    Dim dt As New DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsNothing(Request.Cookies("CPAQA")) Then
            Response.Redirect("Default.aspx")
        End If
        If Not IsPostBack Then
            If Request.Cookies("ROLE_ID").Value >= 3 Then
                pnSearch.Visible = True
            Else
                pnSearch.Visible = False
            End If

            LoadProvinceToDDL()
            LoadData()
        End If

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
                .SelectedValue = 10
            End With
        End If
        dt = Nothing
    End Sub
    Private Sub LoadData()
        If ddlProvince.SelectedIndex = 0 And ddlAccPharm.SelectedIndex = 0 And ddlAccStatus.SelectedIndex = 0 And Len(txtSearch.Text.Trim()) < 2 Then
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','กรุณาระบุเงื่อนไข/คำค้นหาก่อน');", True)
            Exit Sub
        End If

        If Request.Cookies("ROLE_ID").Value = 2 Then
            dtLoc = ctlL.Location_GetBySupervisor(StrNull2Zero(Request.Cookies("UserID").Value))
        ElseIf Request.Cookies("ROLE_ID").Value >= 3 Then
            dtLoc = ctlL.Location_GetList(ddlProvince.SelectedValue, ddlAccPharm.SelectedValue, ddlAccStatus.Text, txtSearch.Text)
        End If
    End Sub
    Private Sub cmdView_Click(sender As Object, e As EventArgs) Handles cmdView.Click
        LoadData()
    End Sub
End Class