Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Text
Imports Microsoft.Reporting.WebForms
Imports BigLion
Public Class ReportViewer
    Inherits System.Web.UI.Page

    Dim dt As New DataTable
    Public Shared ReportFormula As String
    Dim ReportFileName As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Request.Browser.Browser = "Firefox" Then
            Panel1.Visible = True
        ElseIf Request.Browser.Browser = "IE" Then
            Panel1.Visible = True
        Else
            Panel1.Visible = False
            LoadReport()
        End If
    End Sub

    Private Sub LoadReport()

        'System.Threading.Thread.Sleep(1000)
        'UpdateProgress1.Visible = True

        Dim credential As New ReportServerCredentials
        ReportViewer1.Reset()
        ReportViewer1.ServerReport.ReportServerCredentials = credential
        ReportViewer1.ServerReport.ReportServerUrl = credential.ReportServerUrl
        ReportViewer1.ShowPrintButton = True

        Dim xParam As New List(Of ReportParameter)

        Select Case Request("R")
            Case "L1"
                ReportFileName = "DrugStore" & ConvertDate2DBString(Now.Date)
                ReportViewer1.ServerReport.ReportPath = credential.ReportPath("Locations")
                xParam.Add(New ReportParameter("UserID", Request.Cookies("UserID").Value))
                xParam.Add(New ReportParameter("Code", "L1"))
            Case "L2"
                ReportFileName = "DrugStoreType" & ConvertDate2DBString(Now.Date)
                ReportViewer1.ServerReport.ReportPath = credential.ReportPath("LocationByLocationType")
            'Case "L3"
            '    ReportFileName = "DrugStoreType" & ConvertDate2DBString(Now.Date)
            '    ReportViewer1.ServerReport.ReportPath = credential.ReportPath("LocationByLocationType2")

            Case "R1"
                ReportFileName = "RequestByStatus" & ConvertDate2DBString(Now.Date)
                ReportViewer1.ServerReport.ReportPath = credential.ReportPath("RequestByStatus")
                xParam.Add(New ReportParameter("StartDate", Request("BDT").ToString()))
                xParam.Add(New ReportParameter("EndDate", Request("EDT").ToString()))
                xParam.Add(New ReportParameter("AsmStatus", Request("ST").ToString()))
            Case "R2"
                ReportFileName = "RequestByType" & ConvertDate2DBString(Now.Date)
                ReportViewer1.ServerReport.ReportPath = credential.ReportPath("RequestByType")
                xParam.Add(New ReportParameter("StartDate", Request("BDT").ToString()))
                xParam.Add(New ReportParameter("EndDate", Request("EDT").ToString()))
                xParam.Add(New ReportParameter("AsmType", Request("TYPE").ToString()))
            Case "A1"
                ReportFileName = "AssessmentScore" & ConvertDate2DBString(Now.Date)
                ReportViewer1.ServerReport.ReportPath = credential.ReportPath("AssessmentScore")
                xParam.Add(New ReportParameter("StartDate", Request("BDT").ToString()))
                xParam.Add(New ReportParameter("EndDate", Request("EDT").ToString()))
                xParam.Add(New ReportParameter("AsmType", Request("TYPE").ToString()))
                xParam.Add(New ReportParameter("AsmStatus", Request("ST").ToString()))
                xParam.Add(New ReportParameter("LocationUID", Request("LID").ToString()))
            Case "A2"
                ReportFileName = "AssessmentSWOT" & ConvertDate2DBString(Now.Date)
                ReportViewer1.ServerReport.ReportPath = credential.ReportPath("AssessmentSWOT")
                xParam.Add(New ReportParameter("StartDate", Request("BDT").ToString()))
                xParam.Add(New ReportParameter("EndDate", Request("EDT").ToString()))
                xParam.Add(New ReportParameter("AsmType", Request("TYPE").ToString()))
                xParam.Add(New ReportParameter("AsmStatus", Request("ST").ToString()))
                xParam.Add(New ReportParameter("LocationUID", Request("LID").ToString()))
                'Case "actdt"
                '    ReportFileName = "ActionByDate" & "_" & Request("BDT")
                '    ReportViewer1.ServerReport.ReportPath = credential.ReportPath("TaskActionByDate")
                '    xParam.Add(New ReportParameter("CompanyUID", Request("COM").ToString()))
                '    xParam.Add(New ReportParameter("Bdate", Request("BDT").ToString()))
                '    xParam.Add(New ReportParameter("Edate", Request("EDT").ToString()))
                '    xParam.Add(New ReportParameter("UserID", Request.Cookies("userid").ToString()))
                'Case Else
                '    ReportViewer1.ServerReport.ReportPath = credential.ReportPath("")
                '    xParam.Add(New ReportParameter("UserID", Request.Cookies("userid").ToString()))
        End Select


        ReportViewer1.ServerReport.SetParameters(xParam)

        Select Case Request("RPTTYPE") ' FagRPT
            Case "EXCEL"
                ' Variables
                Dim warnings As Warning()
                Dim streamIds As String()
                Dim mimeType As String = String.Empty
                Dim encoding As String = String.Empty
                Dim extension As String = String.Empty

                ' Setup the report viewer object and get the array of bytes

                Dim bytes As Byte() = ReportViewer1.ServerReport.Render("EXCEL", Nothing, mimeType, encoding, extension, streamIds, Nothing)

                ' Now that you have all the bytes representing the PDF report, buffer it and send it to the client.
                Response.Buffer = True
                Response.Clear()
                Response.ContentType = mimeType
                Response.AddHeader("content-disposition", Convert.ToString("attachment; filename=" & ReportFileName & "." & extension))
                Response.BinaryWrite(bytes)
                ' create the file
                Response.Flush()

                ' send it to the client to download
            Case Else
                ' Variables

                Dim warnings As Warning()
                Dim streamIds As String()
                Dim mimeType As String = String.Empty
                Dim encoding As String = String.Empty
                Dim extension As String = String.Empty


                ' Setup the report viewer object and get the array of bytes

                Dim bytes As Byte() = ReportViewer1.ServerReport.Render("PDF", Nothing, mimeType, encoding, extension, streamIds, Nothing)

                ' Now that you have all the bytes representing the PDF report, buffer it and send it to the client.
                Response.Buffer = True
                Response.Clear()
                Response.ContentType = mimeType
                'Response.AddHeader("content-disposition", Convert.ToString("attachment; filename=C:\ttt.pdf"))
                Response.BinaryWrite(bytes)
                ' create the file
                'Response.Flush()
                ' send it to the client to download

        End Select
        '
    End Sub
End Class