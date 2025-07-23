Imports BigLion
Public Class ReportCompany2
    Inherits System.Web.UI.Page

    Dim ctlM As New MasterController
    Dim dt As New DataTable
    Public dtL As New DataTable
    Dim ctlL As New LocationController
    Dim ctlR As New ReportController

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If IsNothing(Request.Cookies("CPA")) Then
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
        End If

    End Sub
    Private Sub LoadProvinceToDDL()
        dt = ctlM.Province_GetForReport
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
        dtL = ctlR.RPT_Location_GetBySearch(ddlGroup.SelectedValue, ddlChain.SelectedValue, ddlType.SelectedValue, ddlNHSO.SelectedValue, ddlProvinceGroup.SelectedValue, ddlProvince.SelectedValue, ddlAccPharm.SelectedValue, ddlAccStatus.SelectedValue, txtSearch.Text)
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

        'ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "Report", "window.open('Report/ReportViewer?R=" & Request("r") & "&COM=" & ddlGroup.SelectedValue & "&BDT=" & Bdate & "&EDT=" & Edate & "&RPTTYPE=" & IIf(chkExcel.Checked = True, "EXCEL", "PDF") & "','_blank');", True)

    End Sub

    Private Sub cmdExport_Click(sender As Object, e As EventArgs) Handles cmdExport.Click
        ctlR.GEN_LocationReportBySearch(ddlGroup.SelectedValue, ddlChain.SelectedValue, ddlType.SelectedValue, ddlNHSO.SelectedValue, ddlProvinceGroup.SelectedValue, ddlProvince.SelectedValue, ddlAccPharm.SelectedValue, ddlAccStatus.SelectedValue, txtSearch.Text, Request.Cookies("UserID").Value)
        pnData.Visible = False
        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "Report", "window.open('Report/ReportViewer?R=L1" & "&RPTTYPE=EXCEL','_blank');", True)

    End Sub
End Class

