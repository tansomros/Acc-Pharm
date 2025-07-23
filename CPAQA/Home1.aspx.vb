Imports System.Net.Mail

Public Class Home1
    Inherits System.Web.UI.Page
    'Dim ctlR As New LawController
    Dim ctlR As New ReportController
    Dim dt As New DataTable

    Public Shared catebar1 As String
    Public Shared catebar2 As String
    Public Shared databar1 As String
    Public Shared databar2 As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsNothing(Request.Cookies("CPAQA")) Then
            Response.Redirect("Default")
        End If

        If Not IsPostBack Then
            If Not IsNothing(Request.Cookies("CPAQA")) Then
                If Request.Cookies("PACKAGENO") = 1 Then
                    dt = ctlR.RPT_Legal_ByType_ForChart(StrNull2Zero(Request.Cookies("LoginLocationID").value))
                Else
                    dt = ctlR.RPT_Legal_ByType_ForChart(StrNull2Zero(Request.Cookies("LoginLocationID").value), StrNull2Zero(Request.Cookies("PeriodID").value))
                End If


                catebar1 = ""
                catebar2 = ""
                databar1 = ""
                databar2 = ""

                For i = 0 To dt.Rows.Count - 1
                    catebar1 = catebar1 + "'" + dt.Rows(i)("LawTypeName") + "'"
                    databar1 = databar1 + dt.Rows(i)("LCount").ToString()

                    If i < dt.Rows.Count - 1 Then
                        catebar1 = catebar1 + ","
                        databar1 = databar1 + ","
                    End If
                Next


                For i = 0 To dt.Rows.Count - 1
                    catebar2 = catebar2 + "'" + dt.Rows(i)("LawTypeName") + "'"
                    databar2 = databar2 + dt.Rows(i)("LCount").ToString()

                    If i < dt.Rows.Count - 1 Then
                        catebar2 = catebar2 + ","
                        databar2 = databar2 + ","
                    End If
                Next


            End If
        End If
    End Sub

    'Private Sub SendAlertOwner()
    '    Dim dt As New DataTable

    '    dt = ctlT.TaskOwner_GetEmailAlert(StrNull2Zero(Request.Cookies("LoginLocationID").value))
    '    If dt.Rows.Count > 0 Then
    '        For i = 0 To dt.Rows.Count - 1
    '            If String.Concat(dt.Rows(i)("Email")) <> "" Then
    '                SendMailAlert(dt.Rows(i)("CompanyUID"), dt.Rows(i)("TaskUID"), dt.Rows(i)("PersonUID"), dt.Rows(i)("PersonName"), dt.Rows(i)("DueDate"), dt.Rows(i)("Email"))
    '                ctlT.SendAlert_Save(dt.Rows(i)("CompanyUID"), dt.Rows(i)("TaskUID"), dt.Rows(i)("PersonUID"), dt.Rows(i)("Email"), "N")
    '            End If
    '        Next
    '    End If

    'End Sub
    'Private Sub SendMailAlert(CompanyUID As Integer, TaskUID As Integer, PersonUID As Integer, PersonName As String, StartDate As String, ByVal sTo As String)
    '    Try

    '        Dim MySubject As String = "แจ้งเตือน Task ใกล้ถึง Duedate"
    '        Dim MyMessageBody As String = ""

    '        MyMessageBody = "<p>เรียน คุณ" & PersonName & "<br />  นี่คืออีเมล์แจ้งเตือนอัตโนมัติจากระบบ Easy Ergonomic Scanner  ท่านมี Task Action ที่ใกล้ถึงวันกำหนด ในวันที่ " & StartDate & " <br />"

    '        MyMessageBody &= "  รายละเอียดเพิ่มเติมสามารถดูได้ที่เว็บไซต์ www.easyergoscanner.com <br/> "

    '        Dim RecipientEmail As String = sTo
    '        Dim SenderEmail As String = "npcsafetyservice@gmail.com"
    '        Dim SenderDisplayName As String = "Easy Ergonomic Scanner"
    '        Dim SenderEmailPassword As String = "Qazxsw21"

    '        Dim HOST = "smtp.gmail.com"
    '        Dim PORT = "587" 'TLS Port

    '        Dim mail As New MailMessage
    '        mail.Subject = MySubject
    '        mail.Body = MyMessageBody

    '        mail.IsBodyHtml = True
    '        mail.To.Add(RecipientEmail)
    '        mail.From = New MailAddress(SenderEmail, SenderDisplayName)

    '        Dim SMTP As New SmtpClient(HOST)
    '        SMTP.EnableSsl = True
    '        SMTP.Credentials = New System.Net.NetworkCredential(SenderEmail.Trim(), SenderEmailPassword.Trim())
    '        SMTP.DeliveryMethod = SmtpDeliveryMethod.Network
    '        SMTP.Port = PORT
    '        SMTP.Send(mail)
    '        'MsgBox("Sent Message To : " & RecipientEmail, MsgBoxStyle.Information, "Sent!")


    '        ctlT.SendAlert_UpdateStatus(CompanyUID, TaskUID, PersonUID, "Y")
    '    Catch ex As Exception
    '        'DisplayMessage(Me.Page, ex.Message)

    '    End Try
    '    '(4) Send the MailMessage (will use the Web.config settings)



    'End Sub


End Class