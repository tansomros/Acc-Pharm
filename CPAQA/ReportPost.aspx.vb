Imports BigLion
Public Class ReportPost
    Inherits System.Web.UI.Page

    Dim ctlM As New MasterController
    Dim dt As New DataTable
    Public dtGPP As New DataTable
    Dim ctlL As New LocationController
    Dim ctlR As New ReportController

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If IsNothing(Request.Cookies("CPAQA")) Then
        '    Response.Redirect("Default.aspx")
        'End If
        If Not IsPostBack Then
            LoadYearToDDL()
            LoadProvinceToDDL()
            LoadProvinceGroupToDDL()

            If Request("s") = "rpa" Then
                pnView.Visible = True
                lblReportTitle.Text = "รายงานการตรวจรักษาคุณภาพ"
            Else
                pnView.Visible = False
                cmdView.Visible = False
                lblReportTitle.Text = "รายงานการตรวจรักษาคุณภาพ"
            End If

            If Convert.ToInt32(Request.Cookies("ROLE_ID").Value) < 9 Then
                Dim dtP As New DataTable
                Dim ctlU As New UserController
                dtP = ctlU.User_GetPPH(Request.Cookies("UserID").Value)
                If dtP.Rows.Count > 0 Then
                    With dtP.Rows(0)
                        ddlProvinceGroup.SelectedValue = .Item("ProvinceGroupID")
                        LoadProvinceToDDL()
                        ddlProvince.SelectedValue = .Item("ProvinceID")
                    End With
                    'ddlProvinceGroup.Enabled = False
                    'ddlProvince.Enabled = False
                End If
            End If
        End If
    End Sub
    Private Sub LoadYearToDDL()
        dt = ctlM.GetGPPYear()
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
        If Convert.ToInt32(Request.Cookies("ROLE_ID").Value) >= 4 And Convert.ToInt32(Request.Cookies("ROLE_ID").Value) <= 5 Then
            dtGPP = ctlR.RPT_PostAudit_GetBySearch(ddlYear.SelectedValue, ddlType.SelectedValue, ddlProvinceGroup.SelectedValue, ddlProvince.SelectedValue, Request.Cookies("UserID").Value, txtSearch.Text)
            'ElseIf Convert.ToInt32(Request.Cookies("ROLE_ID").Value) = 5 Then
            '    dtGPP = ctlR.RPT_GPP_GetByAdminPPHSearch(ddlYear.SelectedValue, ddlProvinceGroup.SelectedValue, ddlProvince.SelectedValue, Request.Cookies("UserID").Value, txtSearch.Text)
        Else
            dtGPP = ctlR.RPT_PostAudit_GetBySearch(ddlYear.SelectedValue, ddlType.SelectedValue, ddlProvinceGroup.SelectedValue, ddlProvince.SelectedValue, "0", txtSearch.Text)
        End If
    End Sub
    Protected Sub cmdView_Click(sender As Object, e As EventArgs) Handles cmdView.Click
        LoadData()
    End Sub

    Private Sub cmdExport_Click(sender As Object, e As EventArgs) Handles cmdExport.Click
        'ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'Under Construction','อยู่ระหว่างการพัฒนา ขออภัยในความไม่สะดวก');", True)
        Select Case Convert.ToInt32(Request.Cookies("ROLE_ID").Value)
            Case 9
                ctlR.GEN_PostReport(ddlYear.SelectedValue, ddlType.SelectedValue, ddlProvinceGroup.SelectedValue, ddlProvince.SelectedValue, "0", txtSearch.Text, Request.Cookies("UserID").Value)
            Case Else
                ctlR.GEN_PostReport(ddlYear.SelectedValue, ddlType.SelectedValue, ddlProvinceGroup.SelectedValue, ddlProvince.SelectedValue, Request.Cookies("UserID").Value, txtSearch.Text, Request.Cookies("UserID").Value)
        End Select
        LoadData()
        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "Report", "window.open('ReportViewer?R=" & Request("s").ToUpper() & "&RPTTYPE=EXCEL','_blank');", True)
    End Sub
    Protected Sub ddlProvinceGroup_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlProvinceGroup.SelectedIndexChanged
        LoadProvinceToDDL()
    End Sub
End Class

