Imports System.IO
Imports System.Data.OleDb
Imports System.Data
Imports BigLion

Public Class PrintCert2
    Inherits System.Web.UI.Page

    Dim dt As New DataTable
    Dim ctlP As New PharmacistController
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
            LoadTypeToDDL()
            LoadProvinceToDDL()
        End If
    End Sub
    Private Sub LoadTypeToDDL()
        dt = ctlM.ReferenceValue_GetByDomainCode("CERTTYP")
        If dt.Rows.Count > 0 Then
            With ddlType
                .Enabled = True
                .DataSource = dt
                .DataTextField = "Descriptions"
                .DataValueField = "Valuecode"
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
        LoadData()
    End Sub
    Private Sub LoadData()

        dt = ctlP.Pharmacist_GetBySearch4Print(ddlProvince.SelectedValue, txtSearch.Text)

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
        LoadData()
    End Sub
    Private Sub grdData_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdData.RowDataBound
        If e.Row.RowType = ListItemType.AlternatingItem Or e.Row.RowType = ListItemType.Item Then
            e.Row.Cells(5).Text = "<a target='_blank' href='ReportViewer.aspx?m=c&R=" & Request("R") & "1&RPTTYPE=PDF&t=" & ddlType.SelectedValue & "&pid=" & grdData.DataKeys(e.Row.RowIndex).Value & "'><img src='images/printer.png'></a>"
        End If
    End Sub

    Private Sub lnkPrintAll_Click(sender As Object, e As EventArgs) Handles lnkPrintAll.Click
        ctlR.GEN_TmpReports_Pharmacist_BySearch(Left(Request("R"), 2), ddlType.SelectedValue, ddlProvince.SelectedValue, txtSearch.Text, Request.Cookies("userid").Value)
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
            Case "C3P"
                'พิมพ์ใบเกียรติบัตร
                If strQ <> "" Then
                    ctlR.TMP_Report_Pharmacist_SET2CERT("C3", ddlType.SelectedValue, strQ, Request.Cookies("UserID").Value)
                End If

        End Select
    End Sub

End Class