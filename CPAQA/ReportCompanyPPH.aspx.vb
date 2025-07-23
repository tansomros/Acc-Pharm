Imports BigLion
Public Class ReportCompanyPPH
    Inherits System.Web.UI.Page

    Dim ctlM As New MasterController
    Dim dt As New DataTable
    Public dtLH As New DataTable
    Dim ctlL As New LocationController
    Dim ctlR As New ReportController

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If IsNothing(Request.Cookies("CPAQA")) Then
        '    Response.Redirect("Default.aspx")
        'End If
        If Not IsPostBack Then
            pnData.Visible = False
            LoadProvinceToDDL()
            LoadLocationGroupToDDL()
            LoadLocationChainToDDL()
            LoadLocationTypeToDDL()
            LoadNHSOToDDL()
            LoadProvinceGroupToDDL()

            If Convert.ToInt32(Request.Cookies("ROLE_ID").Value) >= 4 And Convert.ToInt32(Request.Cookies("ROLE_ID").Value) <= 5 Then
                Dim dtP As New DataTable
                Dim ctlU As New UserController
                dtP = ctlU.User_GetPPH(Request.Cookies("UserID").Value)
                If dtP.Rows.Count > 0 Then
                    With dtP.Rows(0)
                        'ddlNHSO.SelectedValue = .Item("NHSOGroup")
                        ddlProvinceGroup.SelectedValue = .Item("ProvinceGroupID")
                        LoadProvinceToDDL()
                        ddlProvince.SelectedValue = .Item("ProvinceID")
                    End With

                    ddlNHSO.Enabled = False
                    'ddlProvinceGroup.Enabled = False
                    'ddlProvince.Enabled = False
                End If
            End If
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
    Private Sub LoadLocationGroupToDDL()
        dt = ctlL.LocationGroup_GetForReport
        If dt.Rows.Count > 0 Then
            With ddlGroup
                .Enabled = True
                .DataSource = dt
                .DataTextField = "Name"
                .DataValueField = "UID"
                .DataBind()
            End With
        End If
        dt = Nothing
    End Sub
    Private Sub LoadNHSOToDDL()
        dt = ctlM.NHSO_GetForReport
        If dt.Rows.Count > 0 Then
            With ddlNHSO
                .Enabled = True
                .DataSource = dt
                .DataTextField = "NHSOName"
                .DataValueField = "NHSOID"
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

    Private Sub LoadLocationChainToDDL()
        dt = ctlL.LocationChain_GetForReport
        If dt.Rows.Count > 0 Then
            With ddlChain
                .Enabled = True
                .DataSource = dt
                .DataTextField = "Name"
                .DataValueField = "UID"
                .DataBind()
            End With
        End If
        dt = Nothing
    End Sub
    Private Sub LoadLocationTypeToDDL()
        dt = ctlL.LocationType_GetForReport
        If dt.Rows.Count > 0 Then
            With ddlType
                .Enabled = True
                .DataSource = dt
                .DataTextField = "Name"
                .DataValueField = "UID"
                .DataBind()
            End With
        End If
        dt = Nothing
    End Sub
    Private Sub LoadData()
        If Convert.ToInt32(Request.Cookies("ROLE_ID").Value) = 5 Then
            dtLH = ctlR.RPT_Location_GetByAdminPPHSearch(ddlGroup.SelectedValue, ddlChain.SelectedValue, ddlType.SelectedValue, ddlNHSO.SelectedValue, ddlProvinceGroup.SelectedValue, ddlProvince.SelectedValue, ddlAccPharm.SelectedValue, ddlAccStatus.SelectedValue, txtSearch.Text, Request.Cookies("UserID").Value)
        Else
            dtLH = ctlR.RPT_Location_GetByPPHSearch(ddlGroup.SelectedValue, ddlChain.SelectedValue, ddlType.SelectedValue, ddlNHSO.SelectedValue, ddlProvinceGroup.SelectedValue, ddlProvince.SelectedValue, ddlAccPharm.SelectedValue, ddlAccStatus.SelectedValue, txtSearch.Text)
        End If
        pnData.Visible = True
    End Sub
    Protected Sub cmdView_Click(sender As Object, e As EventArgs) Handles cmdView.Click
        LoadData()
        'Dim Bdate, Edate As String
        'Select Case Request("r")
        '    Case "hracomp", "actdt"
        '        If txtStartDate.Text = "" Or txtEndDate.Text = "" Then
        '            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModals(this,'ผลการตรวจสอบ','กรุณาระบุช่วงวันที่ก่อน');", True)
        '            Exit Sub
        '        End If

        '        Bdate = Right(txtStartDate.Text, 4) + Mid(txtStartDate.Text, 4, 2) + Left(txtStartDate.Text, 2)
        '        Edate = Right(txtEndDate.Text, 4) + Mid(txtEndDate.Text, 4, 2) + Left(txtEndDate.Text, 2)

        '    Case "comprog"


        'End Select


        'Select Case Request("r")
        '    Case "hracomp", "actdt"
        '        Bdate = Right(txtStartDate.Text, 4) + Mid(txtStartDate.Text, 4, 2) + ConvertYearEN(CInt(Left(txtStartDate.Text, 2)))
        '        Edate = Right(txtEndDate.Text, 4) + Mid(txtEndDate.Text, 4, 2) + ConvertYearEN(CInt(Left(txtEndDate.Text, 2)))

        '    Case "comprog"


        'End Select

        'ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "Report", "window.open('ReportViewer?R=" & Request("r") & "&COM=" & ddlGroup.SelectedValue & "&BDT=" & Bdate & "&EDT=" & Edate & "&RPTTYPE=" & IIf(chkExcel.Checked = True, "EXCEL", "PDF") & "','_blank');", True)

    End Sub

    Private Sub cmdExport_Click(sender As Object, e As EventArgs) Handles cmdExport.Click
        ctlR.GEN_LocationReportForPPH(ddlGroup.SelectedValue, ddlChain.SelectedValue, ddlType.SelectedValue, ddlNHSO.SelectedValue, ddlProvinceGroup.SelectedValue, ddlProvince.SelectedValue, ddlAccPharm.SelectedValue, ddlAccStatus.SelectedValue, txtSearch.Text, Request.Cookies("UserID").Value)
        pnData.Visible = False
        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "Report", "window.open('ReportViewer?R=PH1" & "&RPTTYPE=EXCEL','_blank');", True)

    End Sub

    Protected Sub ddlGroup_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlGroup.SelectedIndexChanged
        If ddlGroup.SelectedValue = 2 Then
            ddlChain.Enabled = True
        Else
            ddlChain.Enabled = False
        End If
    End Sub

    Protected Sub ddlProvinceGroup_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlProvinceGroup.SelectedIndexChanged
        LoadProvinceToDDL()
    End Sub
End Class

