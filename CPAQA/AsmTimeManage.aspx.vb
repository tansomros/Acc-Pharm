Imports System.IO
Imports System.Data.OleDb
Imports System.Data
Imports BigLion

Public Class AsmTimeManage
    Inherits System.Web.UI.Page
    Dim dt As New DataTable
    Dim ctlU As New UserController
    Dim ctlR As New ReportController

    Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If IsNothing(Request.Cookies("CPAQA")) Then
            Response.Redirect("Default.aspx")
        End If

        If Not IsPostBack Then
            grdData.PageIndex = 0
            LoadData()

            txtStartDate.Text = Today.Date.ToString("dd/MM/yyyy")
            txtEndDate.Text = Today.Date.ToString("dd/MM/yyyy")
        End If

    End Sub

    Private Sub LoadData()

        dt = ctlU.AssessorTime_Get(Request.Cookies("UserID").Value)

        If dt.Rows.Count > 0 Then
            With grdData
                .Visible = True
                .DataSource = dt
                .DataBind()
            End With
        Else
            grdData.Visible = False
        End If


    End Sub
    Private Sub grdData_PageIndexChanging(sender As Object, e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdData.PageIndexChanging
        grdData.PageIndex = e.NewPageIndex
        LoadData()
    End Sub
    Private Sub grdData_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdData.RowDataBound
        If e.Row.RowType = ListItemType.AlternatingItem Or e.Row.RowType = ListItemType.Item Then
            Dim scriptString As String = "javascript:return confirm(""ต้องการลบรายการนี้ ?"");"
            Dim imgD As LinkButton = e.Row.Cells(5).FindControl("imgDel")
            imgD.Attributes.Add("onClick", scriptString)

        End If

        'If e.Row.RowType = ListItemType.AlternatingItem Or e.Row.RowType = ListItemType.Item Then
        '    e.Row.Cells(5).Text = "<a target='_blank' href='ReportViewer.aspx?m=c&R=" & Request("R") & "1&RPTTYPE=PDF&lid=" & grdData.DataKeys(e.Row.RowIndex).Value & "'><img src='images/printer.png'></a>"
        'End If

    End Sub
    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        Dim Bdate, Edate As String
        Dim iD As Integer
        iD = DateDiff(DateInterval.Day, ConvertStringDateToDate(txtStartDate.Text), ConvertStringDateToDate(txtEndDate.Text)) + 1

        For i = 0 To iD - 1
            Bdate = ConvertStrDate2DBDate(DateAdd(DateInterval.Day, i, ConvertStringDateToDate(txtStartDate.Text)))
            Edate = Bdate
            ctlU.AssessorTime_Add(Request.Cookies("UserID").Value, Bdate, Edate, ddlTime.SelectedValue, txtRemark.Text)
        Next
        grdData.PageIndex = 0
        LoadData()
    End Sub

    Private Sub grdData_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grdData.RowCommand
        If TypeOf e.CommandSource Is WebControls.LinkButton Then
            Dim ButtonPressed As WebControls.LinkButton = e.CommandSource
            Select Case ButtonPressed.ID
                Case "imgDel"
                    If ctlU.AssessorTime_Delete(e.CommandArgument) Then
                        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalSuccess(this,'Success','ลบข้อมูลเรียบร้อย');", True)
                        LoadData()
                    Else
                        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'Success','ไม่สามารถลบข้อมูลได้ กรุณาตรวจสอบและลองใหม่อีกครั้ง');", True)

                    End If
            End Select
        End If
    End Sub
    'Private Sub lnkPrintAll_Click(sender As Object, e As EventArgs) Handles lnkPrintAll.Click
    '    Dim Bdate, Edate As String
    '    Bdate = ConvertStrDate2DBDate(txtStartDate.Text)
    '    Edate = ConvertStrDate2DBDate(txtEndDate.Text)

    '    ctlR.GEN_TmpReports_Location_BySearch(Left(Request("R"), 2), Bdate, Edate, ddlProvince.SelectedValue, ddlAccStatus.SelectedValue, txtSearch.Text, Request.Cookies("userid").Value)
    '    ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "Report", "window.open('ReportViewer?R=" & Request("R") & "&RPTTYPE=PDF','_blank');", True)

    'End Sub

    'Private Sub lnkPrintSelect_Click(sender As Object, e As EventArgs) Handles lnkPrintSelect.Click
    '    Dim str As String = ""
    '    Dim n As Integer = 0

    '    For i = 0 To grdData.Rows.Count - 1
    '        With grdData
    '            Dim chkS As CheckBox = .Rows(i).Cells(0).FindControl("chkSelect")
    '            If chkS.Checked Then
    '                n = n + 1
    '                str = str & .DataKeys(i).Value & ","
    '            End If
    '        End With
    '    Next
    '    str = str & "0"
    '    str = "(" & str & ")"
    '    If n <> 0 Then
    '        GenData(str)
    '        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "Report", "window.open('ReportViewer?R=" & Request("R") & "&RPTTYPE=PDF','_blank');", True)
    '    Else
    '        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','ท่านยังไม่ได้เลือกร้านยา');", True)
    '    End If

    'End Sub


End Class