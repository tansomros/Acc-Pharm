Imports System.Net.Mail

Public Class Home2
    Inherits System.Web.UI.Page
    Dim ctlT As New LawController
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
          If IsNothing(Request.Cookies("iLaw")) Then
            Response.Redirect("Default")
        End If

        If Not IsPostBack Then
            'SendAlertOwner()
        End If
    End Sub

    'Private Sub SendAlertOwner()
    '    Dim dt As New DataTable

    '    dt = ctlT.TaskOwner_GetEmailAlert(Request.Cookies("iLaw")("LoginCompanyUID"))
    '    If dt.Rows.Count > 0 Then
    '        For i = 0 To dt.Rows.Count - 1
    '            If String.Concat(dt.Rows(i)("Email")) <> "" Then
    '                SendMailAlert(dt.Rows(i)("CompanyUID"), dt.Rows(i)("TaskUID"), dt.Rows(i)("PersonUID"), dt.Rows(i)("PersonName"), dt.Rows(i)("DueDate"), dt.Rows(i)("Email"))
    '                ctlT.SendAlert_Save(dt.Rows(i)("CompanyUID"), dt.Rows(i)("TaskUID"), dt.Rows(i)("PersonUID"), dt.Rows(i)("Email"), "N")
    '            End If
    '        Next
    '    End If

    'End Sub
    Private Sub SendMailAlert(CompanyUID As Integer, TaskUID As Integer, PersonUID As Integer, PersonName As String, StartDate As String, ByVal sTo As String)
        Try

            Dim MySubject As String = "แจ้งเตือน Task ใกล้ถึง Duedate"
            Dim MyMessageBody As String = ""

            MyMessageBody = "<p>เรียน คุณ" & PersonName & "<br />  นี่คืออีเมล์แจ้งเตือนอัตโนมัติจากระบบ Ergonomic Plus  ท่านมี Task Action ที่ใกล้ถึงวันกำหนด ในวันที่ " & StartDate & " <br />"

            MyMessageBody &= "  รายละเอียดเพิ่มเติมสามารถดูได้ที่เว็บไซต์ www.thaiergoplus.com <br/> "
            'MyMessageBody &= "  หากมีปัญหาการใช้งานหรือข้อสงสัยใดๆ ติดต่อแจ้งเรื่องได้ที่ xxxxxxx หรือ xxxxxxx </p> <br />"
            'MyMessageBody &= "<p> หน่วยฝึกปฏิบัติงานวิชาชีพ  <br />คณะเภสัชศาสตร์ จุฬาลงกรณ์มหาวิทยาลัย  <br />254 ถนนพญาไท เขตปทุมวัน กรุงเทพมหานคร 10330  <br />โทร 02-218-8450-1 โทรสาร 02-218-8450</p>"

            Dim RecipientEmail As String = sTo
            Dim SenderEmail As String = "thaiergonomic@gmail.com"
            Dim SenderDisplayName As String = "Thai Ergonomic Plus"
            Dim SenderEmailPassword As String = "Qazxsw21"

            Dim HOST = "smtp.gmail.com"
            Dim PORT = "587" 'TLS Port

            Dim mail As New MailMessage
            mail.Subject = MySubject
            mail.Body = MyMessageBody

            mail.IsBodyHtml = True
            mail.To.Add(RecipientEmail)
            mail.From = New MailAddress(SenderEmail, SenderDisplayName)

            Dim SMTP As New SmtpClient(HOST)
            SMTP.EnableSsl = True
            SMTP.Credentials = New System.Net.NetworkCredential(SenderEmail.Trim(), SenderEmailPassword.Trim())
            SMTP.DeliveryMethod = SmtpDeliveryMethod.Network
            SMTP.Port = PORT
            SMTP.Send(mail)
            'MsgBox("Sent Message To : " & RecipientEmail, MsgBoxStyle.Information, "Sent!")


            ctlT.SendAlert_UpdateStatus(CompanyUID, TaskUID, PersonUID, "Y")
        Catch ex As Exception
            'DisplayMessage(Me.Page, ex.Message)

        End Try
        '(4) Send the MailMessage (will use the Web.config settings)



    End Sub


End Class