Imports System.Net
Imports System.Net.Mail
Imports BigLion
Public Class ForgotPassword
    Inherits Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        If Not IsPostBack Then
            lblResult.Visible = False
            lblAlert.Visible = False
        End If


    End Sub

    Private Sub SendEmail(PersonName As String, Username As String, Password As String, sTo As String)
        Dim SenderDisplayName As String = "สำนักงานรับรองร้านยาคุณภาพ สภาเภสัชกรรม"
        Dim MySubject As String = "แจ้ง Username & Password เข้าใช้งานระบบประเมินร้านยาคุณภาพ :" & PersonName
        Dim MyMessageBody As String = ""

        MyMessageBody = " <font size='4'>
    
  <p> เรียน " & PersonName & "</p>
  <p> เรื่อง แจ้ง Username & Password เข้าใช้งานระบบประเมินร้านยาคุณภาพ</p>
    <p>ท่านสามารถเข้าใช้งานระบบประเมินร้านยาคุณภาพได้ที่ <a href='https://www.acc-pharm.com'>https://www.acc-pharm.com</p> 
  <p>ข้อมูลผู้ใช้งานของท่าน</p>
        ชื่อผู้ใช้ (Username) : " & Username & " <br />
        รหัสผ่าน (Password) : " & Password & "  <br /> <br />
      <font color='#ff0000'> 
**อีเมล์นี้เป็นระบบอัตโนมัติ ห้ามตอบกลับใดๆทั้งสิ้น** </font><br />
        หากท่านต้องการติดต่อสอบถามข้อมูลเพิ่มเติมสามารถติดต่อได้ตามช่องทางต่อไปนี้ <br />
       
        โทร. 0 2591 9992-5 กด 6 <br />
        อีเมลล์ <a href='mailto:papc@pharmacycouncil.org'>papc@pharmacycouncil.org</a> <br />
        Line id : <a href='https://line.me/ti/g/B8JVsnP_QI'>line.me/ti/g/B8JVsnP_QI</a> หรือ แสกน QR Code นี้ <br /><br />
         <img src='https://www.acc-pharm.com/images/lineid.jpg?v=01' height='250' />


        <br /><br />

        ขอแสดงความนับถือ <br />       
สำนักงานรับรองร้านยาคุณภาพ สภาเภสัชกรรม<br />
อาคารมหิตลาธิเบศร ชั้น 8 กระทรวงสาธารณสุข	<br />
 	เลขที่ 88/19 หมู่ 4 ถนนติวานนท์ ตำบลตลาดขวัญ	 <br />
 	อำเภอเมือง จังหวัดนนทบุรี 11000
    </font>"
        Dim mailMessage As System.Net.Mail.MailMessage = New System.Net.Mail.MailMessage()
        mailMessage.From = New MailAddress("papcinfo@gmail.com", SenderDisplayName)
        mailMessage.Subject = MySubject
        mailMessage.Body = MyMessageBody
        mailMessage.IsBodyHtml = True
        mailMessage.[To].Add(New MailAddress(sTo))

        Dim smtp As SmtpClient = New SmtpClient()
        smtp.Host = "smtp.gmail.com"
        smtp.EnableSsl = True

        Dim NetworkCred As NetworkCredential = New NetworkCredential()
        NetworkCred.UserName = mailMessage.From.Address
        NetworkCred.Password = "qktzlmsamzknnizq"
        smtp.UseDefaultCredentials = True
        smtp.Credentials = NetworkCred
        smtp.Port = 587
        smtp.Send(mailMessage)
    End Sub

    Protected Sub cmdSubmit_Click(sender As Object, e As EventArgs) Handles cmdSubmit.Click
        Dim ctlU As New UserController
        Dim dtU As New DataTable
        Dim enc As New CryptographyEngine
        Dim noM As Boolean = False
        If txtUsername.Text = "" Then
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningAlert(this,'Warning!!','Please input your username.');", True)
            Exit Sub
        End If

        dtU = ctlU.User_GetEmailByUsername(txtUsername.Text)
        If dtU.Rows.Count > 0 Then
            Try
                If String.Concat(dtU.Rows(0)("Email")) <> "" Then
                    SendEmail(dtU.Rows(0)("DisplayName"), dtU.Rows(0)("Username"), enc.DecryptString(dtU.Rows(0)("Passwords"), True), dtU.Rows(0)("Email"))
                    lblResult.Text = "ระบบดำเนินการส่งรหัสผ่านให้ท่านแล้ว กรุณาตรวจสอบอีเมลที่ท่านได้ลงทะเบียนไว้กับเรา"
                    noM = True
                End If
                If String.Concat(dtU.Rows(0)("Email")) <> String.Concat(dtU.Rows(0)("Email2")) Then
                    If String.Concat(dtU.Rows(0)("Email2")) <> "" Then
                        SendEmail(dtU.Rows(0)("DisplayName"), dtU.Rows(0)("Username"), enc.DecryptString(dtU.Rows(0)("Passwords"), True), dtU.Rows(0)("Email2"))
                        lblResult.Text = "ระบบดำเนินการส่งรหัสผ่านให้ท่านแล้ว กรุณาตรวจสอบอีเมลที่ท่านได้ลงทะเบียนไว้กับเรา"
                        noM = True
                    End If
                End If
                If noM = True Then
                    lblResult.Text = "ระบบดำเนินการส่งรหัสผ่านให้ท่านแล้ว กรุณาตรวจสอบอีเมลที่ท่านได้ลงทะเบียนไว้กับเรา"
                Else
                    lblResult.Text = "ไม่พบอีเมล์ท่านในระบบ กรุณาติดต่อผู้ดูแลระบบ"
                End If
                lblResult.Visible = True
            Catch ex As Exception
                'DisplayMessage(Me.Page, ex.Message)
                lblAlert.Text = "เกิดข้อผิดพลาดบางอย่าง ระบบไม่สามารถส่งอีเมล์ให้ท่านได้ กรุณาติดต่อผู้ดูแลระบบ"
                lblAlert.Visible = True
            End Try
        Else
            lblAlert.Text = "ตรวจสอบไม่พบ Username นี้ในระบบ กรุณาตรวจสอบและทำการ request ใหม่อีกครั้ง หรือ ติดต่อผู้ดูแลระบบ"
            lblAlert.Visible = True
        End If

    End Sub

End Class