Imports Microsoft.Reporting.WebForms
Public Class ReportStudentBioView
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadReport()
    End Sub
    Private Sub LoadReport()
        Dim credential As New ReportServerCredentials
        ReportViewer1.Reset()
        ReportViewer1.ServerReport.ReportServerCredentials = credential
        ReportViewer1.ServerReport.ReportServerUrl = credential.ReportServerUrl
        ReportViewer1.ShowPrintButton = True

        Dim xParam As New List(Of ReportParameter)

        Select Case Session("m")
            Case "cert"
                ReportViewer1.ServerReport.ReportPath = credential.ReportPath("StudentCertificate")
                xParam.Add(New ReportParameter("EduYear", Session("rptyear").ToString()))
                xParam.Add(New ReportParameter("Username", Session("Username").ToString()))
            Case "certregis"
                ReportViewer1.ServerReport.ReportPath = credential.ReportPath("StudentCertificateForRegister")
                xParam.Add(New ReportParameter("Username", Session("Username").ToString()))
            Case Else
                ReportViewer1.ServerReport.ReportPath = credential.ReportPath("StudentBio")
                xParam.Add(New ReportParameter("Username", Session("Username").ToString()))
        End Select

        'ReportViewer1.ServerReport.ReportPath = credential.ReportPath("StudentBio")
        'xParam.Add(New ReportParameter("Username", Session("Username").ToString()))
        ReportViewer1.ServerReport.SetParameters(xParam)

        Select Case FagRPT
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
                Response.AddHeader("content-disposition", Convert.ToString("attachment; filename=" & ReportName & "_" & ConvertStrDate2DBString(Request("b")) & "_" & ConvertStrDate2DBString(Request("e")) & "." & extension))
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