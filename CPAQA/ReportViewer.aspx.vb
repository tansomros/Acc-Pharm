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
    Dim ctlR As New ReportController
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

        Select Case Request("R").ToUpper()
            Case "L1"
                ReportFileName = "DrugStore" & ConvertDate2DBString(Now.Date)
                ReportViewer1.ServerReport.ReportPath = credential.ReportPath("Locations")
                xParam.Add(New ReportParameter("UserID", Request.Cookies("userid").Value))
                xParam.Add(New ReportParameter("Code", "L1"))
            Case "L2"
                ReportFileName = "DrugStoreType" & ConvertDate2DBString(Now.Date)
                ReportViewer1.ServerReport.ReportPath = credential.ReportPath("LocationByLocationType")
            Case "L3"
                ReportFileName = "DrugStoreType" & ConvertDate2DBString(Now.Date)
                ReportViewer1.ServerReport.ReportPath = credential.ReportPath("LocationByLocationType2")
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
                '-------------------Supervisor-----------------------------------------
            Case "R1S"
                ReportFileName = "RequestByStatus" & ConvertDate2DBString(Now.Date)
                ReportViewer1.ServerReport.ReportPath = credential.ReportPath("RequestByStatusForSupervisor")
                xParam.Add(New ReportParameter("StartDate", Request("BDT").ToString()))
                xParam.Add(New ReportParameter("EndDate", Request("EDT").ToString()))
                xParam.Add(New ReportParameter("AsmStatus", Request("ST").ToString()))
                xParam.Add(New ReportParameter("SupervisorUID", String.Concat(Request.Cookies("userid").Value)))
            Case "R2S"
                ReportFileName = "RequestByType" & ConvertDate2DBString(Now.Date)
                ReportViewer1.ServerReport.ReportPath = credential.ReportPath("RequestByTypeForSupervisor")
                xParam.Add(New ReportParameter("StartDate", Request("BDT").ToString()))
                xParam.Add(New ReportParameter("EndDate", Request("EDT").ToString()))
                xParam.Add(New ReportParameter("AsmType", Request("TYPE").ToString()))
                xParam.Add(New ReportParameter("SupervisorUID", String.Concat(Request.Cookies("userid").Value)))
            Case "A1S"
                ReportFileName = "AssessmentScore" & ConvertDate2DBString(Now.Date)
                ReportViewer1.ServerReport.ReportPath = credential.ReportPath("AssessmentScoreForSupervisor")
                xParam.Add(New ReportParameter("StartDate", Request("BDT").ToString()))
                xParam.Add(New ReportParameter("EndDate", Request("EDT").ToString()))
                xParam.Add(New ReportParameter("AsmType", Request("TYPE").ToString()))
                xParam.Add(New ReportParameter("AsmStatus", Request("ST").ToString()))
                xParam.Add(New ReportParameter("LocationUID", Request("LID").ToString()))
                xParam.Add(New ReportParameter("SupervisorUID", String.Concat(Request.Cookies("userid").Value)))
            Case "A2S"
                ReportFileName = "AssessmentSWOT" & ConvertDate2DBString(Now.Date)
                ReportViewer1.ServerReport.ReportPath = credential.ReportPath("AssessmentSWOTForSupervisor")
                xParam.Add(New ReportParameter("StartDate", Request("BDT").ToString()))
                xParam.Add(New ReportParameter("EndDate", Request("EDT").ToString()))
                xParam.Add(New ReportParameter("AsmType", Request("TYPE").ToString()))
                xParam.Add(New ReportParameter("AsmStatus", Request("ST").ToString()))
                xParam.Add(New ReportParameter("LocationUID", Request("LID").ToString()))
                xParam.Add(New ReportParameter("SupervisorUID", String.Concat(Request.Cookies("userid").Value)))
            Case "P1"
                ReportFileName = "ProcessPerformance" & ConvertDate2DBString(Now.Date)
                ReportViewer1.ServerReport.ReportPath = credential.ReportPath("AssessmentPerformance")
                xParam.Add(New ReportParameter("StartDate", Request("BDT").ToString()))
                xParam.Add(New ReportParameter("EndDate", Request("EDT").ToString()))
            Case "C1"
                ReportFileName = "Certificate1" & ConvertDate2DBString(Now.Date)
                ReportViewer1.ServerReport.ReportPath = credential.ReportPath("Certificate1")
                xParam.Add(New ReportParameter("LocationUID", Request("lid").ToString()))
            Case "C2"
                ReportFileName = "Certificate2" & ConvertDate2DBString(Now.Date)
                ReportViewer1.ServerReport.ReportPath = credential.ReportPath("Certificate2")
                xParam.Add(New ReportParameter("LocationUID", Request("lid").ToString()))
            Case "C1P"
                ReportFileName = "Certificate1Print" & ConvertDate2DBString(Now.Date)
                ReportViewer1.ServerReport.ReportPath = credential.ReportPath("Certificate1Print")
                xParam.Add(New ReportParameter("UserID", String.Concat(Request.Cookies("userid").Value)))
            Case "C2P"
                ReportFileName = "Certificate2Print" & ConvertDate2DBString(Now.Date)
                ReportViewer1.ServerReport.ReportPath = credential.ReportPath("Certificate2Print")
                xParam.Add(New ReportParameter("UserID", String.Concat(Request.Cookies("userid").Value)))
            Case "C3P"
                ReportFileName = "Certificate3Print" & ConvertDate2DBString(Now.Date)
                ReportViewer1.ServerReport.ReportPath = credential.ReportPath("Certificate3Print")
                xParam.Add(New ReportParameter("UserID", String.Concat(Request.Cookies("userid").Value)))
            Case "C1P1"
                ctlR.TMP_Report_SET2CERT("C1", "(" & Request("lid").ToString() & ")", Request.Cookies("UserID").Value)
                ReportFileName = "Certificate1Print" & ConvertDate2DBString(Now.Date)
                ReportViewer1.ServerReport.ReportPath = credential.ReportPath("Certificate1Print")
                xParam.Add(New ReportParameter("UserID", String.Concat(Request.Cookies("userid").Value)))
            Case "C2P1"
                ctlR.TMP_Report_SET2CERT("C2", "(" & Request("lid").ToString() & ")", Request.Cookies("UserID").Value)
                ReportFileName = "Certificate2Print" & ConvertDate2DBString(Now.Date)
                ReportViewer1.ServerReport.ReportPath = credential.ReportPath("Certificate2Print")
                xParam.Add(New ReportParameter("UserID", String.Concat(Request.Cookies("userid").Value)))
            Case "C3P1"
                ctlR.TMP_Report_Pharmacist_SET2CERT("C3", Request("t"), "(" & Request("pid").ToString() & ")", Request.Cookies("UserID").Value)
                ReportFileName = "Certificate3Print" & ConvertDate2DBString(Now.Date)
                ReportViewer1.ServerReport.ReportPath = credential.ReportPath("Certificate3Print")
                xParam.Add(New ReportParameter("UserID", String.Concat(Request.Cookies("userid").Value)))
            Case "PH1"
                ReportFileName = "DrugStore" & ConvertDate2DBString(Now.Date)
                ReportViewer1.ServerReport.ReportPath = credential.ReportPath("LocationsPPH")
                xParam.Add(New ReportParameter("UserID", Request.Cookies("userid").Value))
                xParam.Add(New ReportParameter("Code", "PH1"))
            Case "GPP"
                ReportFileName = "GPPASM" & ConvertDate2DBString(Now.Date)
                ReportViewer1.ServerReport.ReportPath = credential.ReportPath("AssessmentScorePPH")
                xParam.Add(New ReportParameter("UserID", Request.Cookies("userid").Value))
                xParam.Add(New ReportParameter("Code", "GPP"))
            Case "GSC"
                ReportFileName = "GPPASM" & ConvertDate2DBString(Now.Date)
                ReportViewer1.ServerReport.ReportPath = credential.ReportPath("AssessmentScoreItemPPH")
                xParam.Add(New ReportParameter("UserID", Request.Cookies("userid").Value))
                xParam.Add(New ReportParameter("Code", "GPP"))
            Case "FDA"
                ReportFileName = "GPP" & ConvertDate2DBString(Now.Date)
                ReportViewer1.ServerReport.ReportPath = credential.ReportPath("GPPSummary")
                xParam.Add(New ReportParameter("UserID", Request.Cookies("userid").Value))
                xParam.Add(New ReportParameter("Code", "GPP"))

            Case "GPNT"
                ReportFileName = ""
                ReportViewer1.ServerReport.ReportPath = credential.ReportPath("GPPPrint")
                xParam.Add(New ReportParameter("UID", Request("id")))
                xParam.Add(New ReportParameter("LocationUID", Request("lid")))

            Case "CMP1"
                ReportFileName = "CMP" & ConvertDate2DBString(Now.Date)
                ReportViewer1.ServerReport.ReportPath = credential.ReportPath("ComplainList")
                xParam.Add(New ReportParameter("UserID", Request.Cookies("userid").Value))
                xParam.Add(New ReportParameter("Code", "CMP1"))
            Case "CMP2"
                ReportFileName = "ComplainPerformance" & ConvertDate2DBString(Now.Date)
                ReportViewer1.ServerReport.ReportPath = credential.ReportPath("ComplainPerformance")
                xParam.Add(New ReportParameter("StartDate", Request("BDT").ToString()))
                xParam.Add(New ReportParameter("EndDate", Request("EDT").ToString()))
            Case "RK1"
                ReportFileName = "Risk" & ConvertDate2DBString(Now.Date)
                ReportViewer1.ServerReport.ReportPath = credential.ReportPath("LocationRisk")
                xParam.Add(New ReportParameter("RiskYear", Request("y").ToString()))
                xParam.Add(New ReportParameter("LevelNo", Request("level").ToString()))
            Case "RPA"
                ReportFileName = "POST" & ConvertDate2DBString(Now.Date)
                ReportViewer1.ServerReport.ReportPath = credential.ReportPath("PostAudit")
                xParam.Add(New ReportParameter("UserID", Request.Cookies("userid").Value))
                xParam.Add(New ReportParameter("Code", "POST"))
            Case "WAR"
                ReportFileName = "WarningReport" & ConvertDate2DBString(Now.Date)
                ReportViewer1.ServerReport.ReportPath = credential.ReportPath("WarningReport")
                xParam.Add(New ReportParameter("UserID", Request.Cookies("userid").Value))
                'xParam.Add(New ReportParameter("StartDate", Request("BDT").ToString()))
                'xParam.Add(New ReportParameter("EndDate", Request("EDT").ToString()))
                'xParam.Add(New ReportParameter("SeqNo", Request("seqno").ToString()))
                'xParam.Add(New ReportParameter("WarningType", Request("s").ToString()))
                'xParam.Add(New ReportParameter("ProvinceID", Request("pv").ToString()))
                'xParam.Add(New ReportParameter("IsAccPharm", Request("t").ToString()))
                'xParam.Add(New ReportParameter("LocationID", Request("lid").ToString()))
                'xParam.Add(New ReportParameter("Search", Request("find").ToString()))
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