Imports BigLion
Imports DevExpress.Web.ASPxHtmlEditor.Internal

Public Class Dashboard3
    Inherits System.Web.UI.Page
    Dim ctlR As New ReportController
    Dim dt As New DataTable
    Public Shared DataValue As String
    Public Shared cateName As String

    Public dtRpt As New DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsNothing(Request.Cookies("CPAQA")) Then
            Response.Redirect("Default")
        End If

        If IsPostBack = False Then
            txtStartDate.Text = DateAdd(DateInterval.Month, -4, Today.Date).ToString("dd/MM/yyyy")
            txtEndDate.Text = Today.Date.ToString("dd/MM/yyyy")

            LoadReport()
        End If

    End Sub

    Private Sub LoadReport()
        If txtStartDate.Text = "" Then
            txtStartDate.Text = DateAdd(DateInterval.Year, -1, Today.Date).ToString("dd/MM/yyyy")
        End If
        If txtEndDate.Text = "" Then
            txtEndDate.Text = Today.Date.ToString("dd/MM/yyyy")
        End If

        Dim Bdate, Edate As String
        Bdate = ConvertStrDate2DBDate(txtStartDate.Text)
        Edate = ConvertStrDate2DBDate(txtEndDate.Text)

        dtRpt = ctlR.RPT_Assessment_Performance(Bdate, Edate)

        dt = ctlR.RPT_Assessment_Performance_ForChart(Bdate, Edate)

        DataValue = ""
        cateName = ""

        Dim sName As String
        Dim sData As String
        sName = ""
        sData = ""
        If dt.Rows.Count > 0 Then

            sName = dt.Rows(0)("Cond").ToString()
            sData = "{" & vbCrLf & "name: '" & sName & "'," & vbCrLf & "data:["

            For i = 0 To dt.Rows.Count - 1
                If sName = String.Concat(dt.Rows(i)("Cond")) Then
                    sData = sData & dt.Rows(i)("iDay").ToString()
                    If String.Concat(dt.Rows(i)("Cond")) = "R2A" Then
                        cateName = cateName + "'" + dt.Rows(i)("RptMonth") + "',"
                    End If
                Else
                    'cateName = cateName + "'" + dt.Rows(i)("RptMonth") + "',"
                    sName = dt.Rows(i)("Cond").ToString()
                    sData = Left(sData, Len(sData) - 1)
                    sData = sData & "]" & vbCrLf & "}," & vbCrLf & "{" & vbCrLf & "name: '" & sName & "'," & vbCrLf & "data:[" & dt.Rows(i)("iDay").ToString()

                End If
                'sData = "{" & vbCrLf & "name: '" & sName & "'," & vbCrLf & "data:["
                'sData = sData + dt.Rows(i)("R2A").ToString() + "," + dt.Rows(i)("A2S").ToString() + "," + dt.Rows(i)("S2P").ToString() + "," + dt.Rows(i)("R2S").ToString() + "," + dt.Rows(i)("R2P").ToString()
                'sData = sData + "]" & vbCrLf & "}" & vbCrLf

                If i < dt.Rows.Count - 1 Then
                    sData = sData & ","
                    'cateName = cateName & ","
                End If
            Next

            DataValue = sData & "]" & vbCrLf & "}"
            cateName = Left(cateName, Len(cateName) - 1)

        End If
        'For i = 0 To dt.Rows.Count - 1
        '    cateName = cateName + "'" + DisplayNumber2Month(dt.Rows(i)("RptMonth")) + "'"
        '    DataValue = DataValue + dt.Rows(i)("R2A").ToString()

        '    'iVal = iVal + DBNull2Zero(dtType.Rows(i)("LCount"))

        '    If i < dt.Rows.Count - 1 Then
        '        cateName = cateName + ","
        '        DataValue = DataValue + ","
        '    End If
        'Next

    End Sub

    Private Sub cmdView_Click(sender As Object, e As EventArgs) Handles cmdView.Click
        LoadReport()
    End Sub

    Private Sub cmdExport_Click(sender As Object, e As EventArgs) Handles cmdExport.Click

        If txtStartDate.Text = "" Or txtEndDate.Text = "" Then
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModals(this,'ผลการตรวจสอบ','กรุณาระบุช่วงวันที่ก่อน');", True)
            Exit Sub
        End If

        Dim Bdate, Edate As String
        Bdate = ConvertStrDate2DBDate(txtStartDate.Text)
        Edate = ConvertStrDate2DBDate(txtEndDate.Text)

        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "Report", "window.open('ReportViewer?R=P1&BDT=" & Bdate & "&EDT=" & Edate & "&RPTTYPE=EXCEL','_blank');", True)

    End Sub
End Class