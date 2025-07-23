Imports System.IO
Imports System.Data.OleDb
Imports System.Data
Imports BigLion

Public Class PrintCert
    Inherits System.Web.UI.Page

    Dim dt As New DataTable
    Dim ctlL As New LocationController
    'Dim ctlU As New UserController
    Dim ctlM As New MasterController
    Dim ctlR As New ReportController

    Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If IsNothing(Request.Cookies("CPAQA")) Then
            Response.Redirect("Default.aspx")
        End If

        If Not IsPostBack Then
            grdData.PageIndex = 0
            lnkPrintAll.Visible = False
            lnkPrintSelect.Visible = False
            'txtStartDate.Text = Today.Date.ToString("dd/MM/yyyy")
            'txtEndDate.Text = Today.Date.ToString("dd/MM/yyyy")
            LoadYearToDDL()
            LoadProvinceToDDL()
        End If
    End Sub
    Private Sub LoadYearToDDL()
        dt = ctlM.GetAccPharmYear()
        If dt.Rows.Count > 0 Then
            With ddlYear
                .Enabled = True
                .DataSource = dt
                .DataTextField = "YearName"
                .DataValueField = "AccYear"
                .DataBind()
                '.SelectedIndex = 0
            End With
        End If
        dt = Nothing
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
                '.SelectedIndex = 0
            End With
        End If
        dt = Nothing
    End Sub
    Protected Sub cmdSearch_Click(sender As Object, e As EventArgs) Handles cmdSearch.Click
        grdData.PageIndex = 0
        LoadLocation()
    End Sub
    Private Sub LoadLocation()
        Dim Bdate, Edate As String
        Bdate = ConvertStrDate2DBDate(txtStartDate.Text)
        Edate = ConvertStrDate2DBDate(txtEndDate.Text)
        dt = ctlL.Location_GetBySearch4Print(Bdate, Edate, ddlYear.SelectedValue, txtStartNo.Text, txtEndNo.Text, ddlProvince.SelectedValue, ddlAccStatus.SelectedValue, txtSearch.Text)

        If dt.Rows.Count > 0 Then
            With grdData
                .Visible = True
                .DataSource = dt
                .DataBind()
            End With

            lnkPrintAll.Visible = True
            lnkPrintSelect.Visible = True
        Else
            grdData.Visible = False
            lnkPrintAll.Visible = False
            lnkPrintSelect.Visible = False
        End If


    End Sub
    Private Sub grdData_PageIndexChanging(sender As Object, e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdData.PageIndexChanging
        grdData.PageIndex = e.NewPageIndex
        LoadLocation()
    End Sub
    Private Sub grdData_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdData.RowDataBound
        If e.Row.RowType = ListItemType.AlternatingItem Or e.Row.RowType = ListItemType.Item Then
            e.Row.Cells(9).Text = "<a target='_blank' href='ReportViewer.aspx?m=c&R=" & Request("R") & "1&RPTTYPE=PDF&lid=" & grdData.DataKeys(e.Row.RowIndex).Value & "'><img src='images/printer.png'></a>"
        End If
    End Sub

    Private Sub lnkPrintAll_Click(sender As Object, e As EventArgs) Handles lnkPrintAll.Click
        Dim Bdate, Edate As String
        Bdate = ConvertStrDate2DBDate(txtStartDate.Text)
        Edate = ConvertStrDate2DBDate(txtEndDate.Text)

        ctlR.GEN_TmpReports_Location_BySearch(Left(Request("R"), 2), Bdate, Edate, ddlYear.SelectedValue, txtStartNo.Text, txtEndNo.Text, ddlProvince.SelectedValue, ddlAccStatus.SelectedValue, txtSearch.Text, Request.Cookies("userid").Value)
        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "Report", "window.open('ReportViewer?R=" & Request("R") & "&RPTTYPE=PDF','_blank');", True)

    End Sub

    Private Sub lnkPrintSelect_Click(sender As Object, e As EventArgs) Handles lnkPrintSelect.Click
        Dim str As String = ""
        Dim n As Integer = 0

        For i = 0 To grdData.Rows.Count - 1
            With grdData
                Dim chkS As CheckBox = .Rows(i).Cells(0).FindControl("chkSelect")
                If chkS.Checked Then
                    n = n + 1
                    str = str & .DataKeys(i).Value & ","
                End If
            End With
        Next
        str = str & "0"
        str = "(" & str & ")"
        If n <> 0 Then
            GenData(str)
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "Report", "window.open('ReportViewer?R=" & Request("R") & "&RPTTYPE=PDF','_blank');", True)
        Else
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','ท่านยังไม่ได้เลือกร้านยา');", True)
        End If

    End Sub
    Private Sub GenData(strQ As String)
        Select Case Request("R")
            Case "C1P"
                'พิมพ์ใบเกียรติบัตร
                If strQ <> "" Then
                    ctlR.TMP_Report_SET2CERT("C1", strQ, Request.Cookies("UserID").Value)
                End If
            Case "C2P"
                'พิมพ์ใบรับรองร้านยาคุณภาพ
                If strQ <> "" Then
                    ctlR.TMP_Report_SET2CERT("C2", strQ, Request.Cookies("UserID").Value)
                End If
        End Select
    End Sub

End Class