Imports BigLion

Public Class Home
    Inherits System.Web.UI.Page
    'Dim ctlR As New LocationController
    Dim ctlR As New ReportController
    Dim dt As New DataTable
    Public Shared hDatachart1 As String
    Public Shared hCatebar As String
    Public Shared hDatabar1 As String

    Dim dtType As New DataTable 'ประเภทร้านยา
    Dim dtNHSO As New DataTable 'สปสช
    Public dtProv As New DataTable 'จังหวัด
    Dim dtGroup As New DataTable 'ภาค
    Dim dtChain As New DataTable 'chain
    Public Shared catebarType As String
    Public Shared catebarNHSO As String
    Public Shared catebarGroup As String
    Public Shared catebarChain As String

    Public Shared databarType As String
    Public Shared databarNHSO As String
    Public Shared databarGroup As String
    Public Shared databarChain As String
    Dim ctlN As New NewsController
    Public dtNew As New DataTable

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsNothing(Request.Cookies("CPAQA")) Then
            Response.Redirect("Default")
        End If

        If Not IsPostBack Then
            grdEvent.PageIndex = 0
            LoadEventList()
            If Convert.ToInt32(Request.Cookies("ROLE_ID").Value) = 1 Then
                LoadLocationData()
            End If
            dtNew = ctlN.News_GetFirstPage("2")
        End If
        '    If Not IsNothing(Request.Cookies("CPAQA")) Then
        'SendAlertOwner()
        dtProv = ctlR.RPT_Location_GetCountByProvince

        dt = ctlR.RPT_Location_ByAccStatus_ForChart()

        hDatachart1 = dt.Rows(0)(0).ToString()   'JsonConvert.SerializeObject(dt, Formatting.None)


        dtType = ctlR.RPT_Location_GetCountByType

        catebarType = ""
        catebarNHSO = ""
        catebarGroup = ""
        catebarChain = ""

        databarType = ""
        databarNHSO = ""
        databarGroup = ""
        databarChain = ""

        For i = 0 To dtType.Rows.Count - 1
            catebarType = catebarType + "'" + dtType.Rows(i)("TypeName") + "'"
            databarType = databarType + dtType.Rows(i)("LCount").ToString()

                    If i < dtType.Rows.Count - 1 Then
                        catebarType = catebarType + ","
                        databarType = databarType + ","
                    End If
                Next


        dtNHSO = ctlR.RPT_Location_GetCountByNHSOGroup

                For i = 0 To dtNHSO.Rows.Count - 1
                    catebarNHSO = catebarNHSO + "'" + dtNHSO.Rows(i)("GroupName") + "'"
                    databarNHSO = databarNHSO + dtNHSO.Rows(i)("LCount").ToString()

                    If i < dtNHSO.Rows.Count - 1 Then
                        catebarNHSO = catebarNHSO + ","
                        databarNHSO = databarNHSO + ","
                    End If
                Next

        dtGroup = ctlR.RPT_Location_GetCountByProvinceGroup

        For i = 0 To dtGroup.Rows.Count - 1
            catebarGroup = catebarGroup + "'" + dtGroup.Rows(i)("ProvinceGroupName") + "'"
            databarGroup = databarGroup + dtGroup.Rows(i)("LCount").ToString()

            If i < dtGroup.Rows.Count - 1 Then
                catebarGroup = catebarGroup + ","
                databarGroup = databarGroup + ","
            End If
        Next

        dtChain = ctlR.RPT_Location_GetCountByChainGroup

        For i = 0 To dtChain.Rows.Count - 1
            catebarChain = catebarChain + "'" + dtChain.Rows(i)("ChainName") + "'"
            databarChain = databarChain + dtChain.Rows(i)("LCount").ToString()

            If i < dtChain.Rows.Count - 1 Then
                catebarChain = catebarChain + ","
                databarChain = databarChain + ","
            End If
        Next

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

    Private Sub LoadLocationData()
        Dim ctlL As New LocationController
        Dim ctlMd As New MediaController
        dt = ctlL.Location_GetByUID(StrNull2Int(Request.Cookies("LoginLocationUID").Value))
        If dt.Rows.Count > 0 Then
            lblLocationName.Text = dt.Rows(0)("LocationName")
            'hdLocationUID.Value = dt.Rows(0)("UID")
            'lblProvinceName.Text = "จังหวัด " & dt.Rows(0)("ProvinceName")
            lblAddress.Text = String.Concat(dt.Rows(0)("AddressNO")) & " " & String.Concat(dt.Rows(0)("Subdistrict")) & " " & String.Concat(dt.Rows(0)("District")) & " " & String.Concat(dt.Rows(0)("ProvinceName"))
            lblAccLicense.Text = String.Concat(dt.Rows(0)("AccLicense"))
            lblStartDate.Text = Left(String.Concat(dt.Rows(0)("StartDate")), 10)
            lblEndDate.Text = Left(String.Concat(dt.Rows(0)("ExpireDate")), 10)
            lblStartYear.Text = String.Concat(dt.Rows(0)("StartYear"))

            Dim ImgL As String = ctlMd.Media_GetProfileImage(dt.Rows(0)("UID"))

            If ImgL = "" Then
                imgLocation.ImageUrl = "images/logo.jpg"
            Else
                imgLocation.ImageUrl = "imageUploads/" & Request.Cookies("LoginLocationUID").Value & "/Locations/" & ImgL
            End If

            'If String.Concat(dt.Rows(0)("isAccPharm")) = "Y" Then
            pnCert.Visible = False
            'Else
            '    pnCert.Visible = False
            'End If
        End If

    End Sub

    Private Sub LoadEventList()
        Dim ctlE As New RequestController
        If StrNull2Zero(Request.Cookies("ROLE_ID").Value) = 1 Then
            dt = ctlE.Event_GetListByUser(StrNull2Zero(Request.Cookies("LoginLocationUID").Value))
        ElseIf StrNull2Zero(Request.Cookies("ROLE_ID").Value) = 2 Then
            dt = ctlE.Event_GetListBySupervisor(StrNull2Zero(Request.Cookies("UserID").Value))
        Else
            dt = ctlE.Event_GetListByAdmin()
        End If
        With grdEvent
            .Visible = True
            .DataSource = dt
            .DataBind()

            'For i = 0 To .Rows.Count - 1
            '    Dim hlnkD As HyperLink = .Rows(i).Cells(0).FindControl("hlnkEdate")
            '    Dim hlnkN As HyperLink = .Rows(i).Cells(0).FindControl("hlnkEname")
            '    hlnkN.Text = dt.Rows(i)("Title")
            '    hlnkD.Text = dt.Rows(i)("EventDate")

            '    If dt.Rows(i)("Details") <> "" Then
            '        hlnkD.NavigateUrl = "EventDetail?eid=" & dt.Rows(i)("UID")
            '        hlnkN.NavigateUrl = "EventDetail?eid=" & dt.Rows(i)("UID")
            '    End If
            'Next

        End With

    End Sub

    Protected Sub grdEvent_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grdEvent.PageIndexChanging
        grdEvent.PageIndex = e.NewPageIndex
        LoadEventList()
    End Sub

    Private Sub imgCert1_Click(sender As Object, e As ImageClickEventArgs) Handles imgCert1.Click
        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "Report", "window.open('ReportViewer?m=rpt&R=C1&RPTTYPE=PDF&lid=" & Request.Cookies("LoginLocationUID").Value & "&RPTTYPE=PDF','_blank');", True)
    End Sub

    Private Sub imgCert2_Click(sender As Object, e As ImageClickEventArgs) Handles imgCert2.Click
        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "Report", "window.open('ReportViewer?m=rpt&R=C2&RPTTYPE=PDF&lid=" & Request.Cookies("LoginLocationUID").Value & "&RPTTYPE=PDF','_blank');", True)
    End Sub
End Class