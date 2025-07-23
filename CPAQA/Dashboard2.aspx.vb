Imports BigLion

Public Class Dashboard2
    Inherits System.Web.UI.Page
    'Dim ctlR As New LocationController
    Dim ctlR As New ReportController
    Dim dt As New DataTable
    Public Shared hDatachart1 As String
    Public Shared hDatachart2 As String
    Public Shared hDatachart3 As String
    Public Shared hDatachart4 As String
    Public Shared hDatachart5 As String
    Public Shared hDatachart6 As String
    Public Shared hDatachart7 As String
    Public Shared hDatachart8 As String
    Public Shared hDatachart9 As String
    Public Shared hDatachart10 As String
    Public Shared hDatachart11 As String
    'Public Shared hCatebar As String
    'Public Shared hDatabar1 As String

    Dim dtType As New DataTable 'ประเภทร้านยา
    'Dim dtNHSO As New DataTable 'สปสช
    'Public dtProv As New DataTable 'จังหวัด
    'Dim dtGroup As New DataTable 'ภาค
    'Dim dtChain As New DataTable 'chain
    Public Shared catebarType2 As String
    'Public Shared catebarNHSO As String
    'Public Shared catebarGroup As String
    'Public Shared catebarChain As String

    Public Shared databarType2 As String
    'Public Shared databarNHSO As String
    'Public Shared databarGroup As String
    'Public Shared databarChain As String

    Public Shared dataLocAll As String


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsNothing(Request.Cookies("CPAQA")) Then
            Response.Redirect("Default")
        End If

        If Not IsPostBack Then
        End If
        '    If Not IsNothing(Request.Cookies("CPAQA")) Then
        'SendAlertOwner()

        dt = ctlR.RPT_Location_ByType1_ForChart()
        hDatachart1 = dt.Rows(0)(0).ToString()

        dt = ctlR.RPT_Location_ByType2_ForChart()
        hDatachart2 = dt.Rows(0)(0).ToString()

        dt = ctlR.RPT_Location_ByType3_ForChart()
        hDatachart3 = dt.Rows(0)(0).ToString()

        dt = ctlR.RPT_Location_ByType4_ForChart()
        hDatachart4 = dt.Rows(0)(0).ToString()

        dt = ctlR.RPT_Location_ByType5_ForChart()
        hDatachart5 = dt.Rows(0)(0).ToString()

        dt = ctlR.RPT_Location_ByType6_ForChart()
        hDatachart6 = dt.Rows(0)(0).ToString()

        dt = ctlR.RPT_Location_ByType7_ForChart()
        hDatachart7 = dt.Rows(0)(0).ToString()

        dt = ctlR.RPT_Location_ByType8_ForChart()
        hDatachart8 = dt.Rows(0)(0).ToString()

        dt = ctlR.RPT_Location_ByType9_ForChart()
        hDatachart9 = dt.Rows(0)(0).ToString()

        dt = ctlR.RPT_Location_ByType10_ForChart()
        hDatachart10 = dt.Rows(0)(0).ToString()

        dt = ctlR.RPT_Location_ByType11_ForChart()
        hDatachart11 = dt.Rows(0)(0).ToString()


        'JsonConvert.SerializeObject(dt, Formatting.None)

        'catebarType = ""
        'catebarNHSO = ""
        'databarType = ""
        'databarNHSO = ""

        'Dim iAll, iVal As Integer
        'iVal = 0
        'iAll = ctlR.RPT_Location_GetQACountAll

        dtType = ctlR.RPT_Location_GetCountByType

        catebarType2 = ""
        databarType2 = ""

        For i = 0 To dtType.Rows.Count - 1
            catebarType2 = catebarType2 + "'" + dtType.Rows(i)("TypeName") + "'"
            databarType2 = databarType2 + dtType.Rows(i)("LCount").ToString()

            'iVal = iVal + DBNull2Zero(dtType.Rows(i)("LCount"))

            If i < dtType.Rows.Count - 1 Then
                catebarType2 = catebarType2 + ","
                databarType2 = databarType2 + ","
            End If
        Next


        'dtNHSO = ctlR.RPT_Location_GetCountByNHSOGroup

        'For i = 0 To dtNHSO.Rows.Count - 1
        '    catebarNHSO = catebarNHSO + "'" + dtNHSO.Rows(i)("GroupName") + "'"
        '    databarNHSO = databarNHSO + dtNHSO.Rows(i)("LCount").ToString()

        '    If i < dtNHSO.Rows.Count - 1 Then
        '        catebarNHSO = catebarNHSO + ","
        '        databarNHSO = databarNHSO + ","
        '    End If
        'Next

        'dtGroup = ctlR.RPT_Location_GetCountByProvinceGroup

        'For i = 0 To dtGroup.Rows.Count - 1
        '    catebarGroup = catebarGroup + "'" + dtGroup.Rows(i)("ProvinceGroupName") + "'"
        '    databarGroup = databarGroup + dtGroup.Rows(i)("LCount").ToString()

        '    If i < dtGroup.Rows.Count - 1 Then
        '        catebarGroup = catebarGroup + ","
        '        databarGroup = databarGroup + ","
        '    End If
        'Next

        'dtChain = ctlR.RPT_Location_GetCountByChainGroup

        'For i = 0 To dtChain.Rows.Count - 1
        '    catebarChain = catebarChain + "'" + dtChain.Rows(i)("ChainName") + "'"
        '    databarChain = databarChain + dtChain.Rows(i)("LCount").ToString()

        '    If i < dtChain.Rows.Count - 1 Then
        '        catebarChain = catebarChain + ","
        '        databarChain = databarChain + ","
        '    End If
        'Next

        '    End If
        'End If
    End Sub

    'Private Sub SendAlertOwner()
    '    Dim dt As New DataTable

    '    dt = ctlT.TaskOwner_GetEmailAlert(StrNull2Zero(Request.Cookies("LoginLocationUID").value))
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

    '        MyMessageBody = "<p>เรียน คุณ" & PersonName & "<br />  นี่คืออีเมลแจ้งเตือนอัตโนมัติจากระบบ Easy Ergonomic Scanner  ท่านมี Task Action ที่ใกล้ถึงวันกำหนด ในวันที่ " & StartDate & " <br />"

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