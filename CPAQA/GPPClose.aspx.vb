Imports BigLion
Public Class GPPClose
    Inherits System.Web.UI.Page

    Dim ctlM As New MasterController
    Dim dt As New DataTable
    Public dtGPP As New DataTable
    Dim ctlL As New LocationController
    Dim ctlA As New AssessmentController

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If IsNothing(Request.Cookies("CPAQA")) Then
        '    Response.Redirect("Default.aspx")
        'End If
        If Not IsPostBack Then
            LoadYearToDDL()
            LoadProvinceToDDL()
            LoadProvinceGroupToDDL()

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
                    ddlProvinceGroup.Enabled = False
                    ddlProvince.Enabled = False
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
        dtGPP = ctlA.GPP_GetForClose(ddlYear.SelectedValue, ddlProvinceGroup.SelectedValue, ddlProvince.SelectedValue, txtSearch.Text)
    End Sub
    Protected Sub cmdView_Click(sender As Object, e As EventArgs) Handles cmdView.Click
        LoadData()
    End Sub

    Private Sub cmdExport_Click(sender As Object, e As EventArgs) Handles cmdExport.Click
        ctlA.GPP_CloseBySearch(ddlYear.SelectedValue, ddlProvinceGroup.SelectedValue, ddlProvince.SelectedValue, txtSearch.Text, Request.Cookies("UserID").Value)
        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalSuccess(this,'Success','บันทึกปิดการประเมินตามเงื่อนไขเรียบร้อย');", True)
    End Sub
    Protected Sub ddlProvinceGroup_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlProvinceGroup.SelectedIndexChanged
        LoadProvinceToDDL()
    End Sub
End Class

