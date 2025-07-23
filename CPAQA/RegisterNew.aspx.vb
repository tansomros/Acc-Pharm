Imports System.Net.Mail
Imports System.Web
Imports System.IO
Imports Microsoft.Reporting.WebForms
Imports System.Net
Imports DevExpress.XtraPrinting.Export.Pdf
Imports BigLion
Public Class RegisterNew
    Inherits System.Web.UI.Page
    Dim dt As New DataTable
    Dim ctlM As New MasterController
    Dim ctlL As New LocationController

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If IsNothing(Request.Cookies("CPAQA")) Then
        '    Response.Redirect("Default.aspx")
        'End If
        If Not IsPostBack Then
            LoadProvinceToDDL()
            LoadLocationGroupToDDL()
            LoadLocationChainToDDL()
            LoadLocationTypeToCheckList()

            lblLicenseNo1.Text = Session("LicenseRegister")
            LoadLocationDataFromFDA()

            ddlChain.Enabled = False
            If Not Request("pid") = Nothing Then
                'LoadRegisterData()
            End If
        End If
        txtQAYear.Attributes.Add("OnKeyPress", "return AllowOnlyIntegers();")
        txtArea1.Attributes.Add("OnKeyPress", "return AllowOnlyDouble();")
        txtArea2.Attributes.Add("OnKeyPress", "return AllowOnlyDouble();")
        txtEmail.Attributes.Add("OnKeyPress", "return NotAllowThai();")
    End Sub
    Function checkField(tD As DataTable, ColumnName As String) As String
        If tD.Columns(ColumnName) IsNot Nothing Then
            Return String.Concat(tD.Rows(0)(ColumnName))
        Else
            Return ""
        End If
    End Function

    Private Sub LoadLocationDataFromFDA()
        Dim dtResult1 As New DataTable
        Dim dtResult2 As New DataTable

        Dim ctlFDA As New FDAServiceController
        Dim NewCode As String
        NewCode = ctlFDA.ConvertLicenseToNewCode(Session("LicenseRegister"))
        lblNewCode.Text = NewCode
        Try
            dt = ctlFDA.GET_DRUG_LCN_INFORMATION(NewCode)
            If dt.Rows.Count > 0 Then
                dt.DefaultView.Sort = "appdate desc,lcnno desc"
                dtResult1 = dt.DefaultView.ToTable()
            End If
            dt = ctlFDA.GET_DRUG_PHARMACY(NewCode)
            If dt.Rows.Count > 0 Then
                dt.DefaultView.Sort = "appdate desc,lcnno desc"
                dtResult2 = dt.DefaultView.ToTable()
            End If

            If dtResult1.Rows.Count > 0 Then

                'txtLocationName.Text = String.Concat(.Item("thanm"))
                'txtAddressNo.Text = String.Concat(.Item("thaaddr"))  '& " " & .Item("tharoad"))
                'txtSubDistict.Text = String.Concat(.Item("thathmblnm"))
                'txtDistrict.Text = String.Concat(.Item("thaamphrnm"))
                'ddlProvince.SelectedValue = String.Concat(.Item("pvncd"))
                'txtZipCode.Text = String.Concat(.Item("zipcode"))
                'txtTel.Text = String.Concat(.Item("tel"))
                'txtLicensee.Text = String.Concat(.Item("grannm_lo"))
                'txtWorkTime.Text = String.Concat(.Item("licen_time"))
                lblLicenseNo1.Text = Replace(Replace(String.Concat(dtResult1.Rows(0)("lcnno_no")), "ขย1 ", ""), " ", ".")
                lblLocationName.Text = checkField(dtResult1, "thanm")
                lblAddressNo.Text = checkField(dtResult1, "thaaddr")
                lblMoo.Text = checkField(dtResult1, "thamu")
                lblRoad.Text = checkField(dtResult1, "tharoad") & " " & IIf(checkField(dtResult1, "thasoi") <> "", " ซอย " & checkField(dtResult1, "thasoi"), "")
                lblSubDistict.Text = checkField(dtResult1, "thathmblnm")
                lblDistrict.Text = checkField(dtResult1, "thaamphrnm")
                ddlProvince.SelectedValue = checkField(dtResult1, "pvncd")
                lblProvince.Text = ddlProvince.SelectedItem.Text
                lblZipCode.Text = checkField(dtResult1, "zipcode")
                txtTel.Text = checkField(dtResult1, "tel")
                lblLicensee.Text = checkField(dtResult1, "grannm_lo")
                txtWorkTime.Text = checkField(dtResult1, "licen_time")

                lblAuthName.Text = checkField(dtResult2, "grannm_lo")
                lblLicensee.Text = checkField(dtResult2, "licen")
                lblPharmacistLicenseNo.Text = checkField(dtResult2, "phrno")
                lblPharmacist.Text = checkField(dtResult2, "phrnm")
                lblPharmacistLicenseNo.Text = Replace(lblPharmacistLicenseNo.Text, "ภ.", "")

                'lcnno                   รหัสผู้ประกอบการ
                'thanm                   ชื่อสถานที่(ร้าน)
                'pvncd                   รหัสจังหวัด
                'lcntpcd                 ประเภทใบอนุญาตสถานที่ด้าน ยา
                'lcnsid                  รหัสผู้ประกอบการ
                'GROUPNAME               ประเภทสถานที่
                'lcnno_no                เลขใบอนุญาตสถานที่ด้านยา
                'lcnno_noo               เลขใบอนุญาตสถานที่ด้านยา
                'lcnno_not_pvnabbr       เลขใบอนุญาตสถานที่ด้านยา 
                'typee                   ประเภทใบอนุญาตสถานที่ด้าน ยา
                'licen                   ชื่อผู้รับอนุญาต
                'licen_addr              -
                'licen_address           -
                'licen_time              เวลาทำการของร้าน
                'grannm_lo               ชื่อผู้ดำเนินกิจการ
                'grannm_addr              -
                'grannm_address           -
                'thaaddr                 ที่อยู่สถานที่ 
                'tharoom                 ห้อง
                'thafloor                ชั้น
                'thabuilding             อาคาร
                'thasoi                  ซอย
                'tharoad                 ถนน
                'thamu                   หมู่
                'thathmblnm              ตำบล
                'zipcode                 รหัสไปรษณีย์
                'tel                     เบอร์โทรศัพท์
                'fax                     เบอร์โทรสาร
                'thanm_addr              ที่อยู่สถานที่ แบบเต็ม
                'thanm_address           ที่อยู่สถานที่ แบบเต็ม
                'thaamphrnm              อำเภอ
                'thachngwtnm             จังหวัด
                'cncnm                   สถานะใบอนุญาต
                'appdate                 วันที่อนุญาต
                'expyear                 ปีที่หมดอายุ
                'lmdfdate                Last update
                'grouptype               กลุ่มใบอนุญาต
                'Newcode_not             รหัส Newcode

            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub LoadProvinceToDDL()
        dt = ctlM.Province_Get
        If dt.Rows.Count > 0 Then
            With ddlProvince
                .Enabled = True
                .DataSource = dt
                .DataTextField = "ProvinceName"
                .DataValueField = "ProvinceID"
                .DataBind()
                '.SelectedIndex = 0
            End With
        End If
        dt = Nothing
    End Sub
    Private Sub LoadLocationGroupToDDL()
        dt = ctlL.LocationGroup_Get
        If dt.Rows.Count > 0 Then
            With ddlGroup
                .Enabled = True
                .DataSource = dt
                .DataTextField = "Name"
                .DataValueField = "UID"
                .DataBind()
            End With
        End If
        dt = Nothing
    End Sub

    Private Sub LoadLocationChainToDDL()
        dt = ctlL.LocationChain_Get
        If dt.Rows.Count > 0 Then
            With ddlChain
                .Enabled = True
                .DataSource = dt
                .DataTextField = "Name"
                .DataValueField = "UID"
                .DataBind()
            End With
        End If
        dt = Nothing
    End Sub
    Private Sub LoadLocationTypeToCheckList()
        dt = ctlL.LocationType_Get
        If dt.Rows.Count > 0 Then
            chkLocationType.DataSource = dt
            chkLocationType.DataTextField = "Name"
            chkLocationType.DataValueField = "UID"
            chkLocationType.DataBind()
        End If
        dt = Nothing
    End Sub
    Private Sub LoadLocationType(LUID As Integer)
        Dim dtC As New DataTable
        dtC = ctlL.LocationTypeDetail_GetByLocationUID(LUID)
        If dtC.Rows.Count > 0 Then
            chkLocationType.ClearSelection()
            For i = 0 To chkLocationType.Items.Count - 1
                For n = 0 To dtC.Rows.Count - 1
                    If chkLocationType.Items(i).Value = dtC.Rows(n)("LocationTypeUID") Then
                        chkLocationType.Items(i).Selected = True
                    End If
                Next
            Next
        End If
    End Sub
    Function Check_Email(str As String) As Boolean
        Return Regex.IsMatch(str, "\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*")
    End Function
    Protected Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click

        If ctlL.Location_SearchByLicense(lblLicenseNo1.Text) > 0 Then
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningAlert(this,'ผลการตรวจสอบ','เลขที่ใบอนุญาตนี้มี User ในระบบแล้ว กรุณา Login ด้วยรหัสผู้ใช้งานของท่าน');", True)
            Exit Sub
        End If

        If IsNumeric(Left(lblLicenseNo1.Text, 1)) Or IsNumeric(Mid(lblLicenseNo1.Text, 2, 1)) Then
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningAlert(this,'ผลการตรวจสอบ','กรุณาระบุเลขที่ใบอนุญาตขายยา (ขย.5) 2 ตัวแรกด้วยรหัสจังหวัด');", True)
            Exit Sub
        End If

        If Len(Trim(lblLicenseNo1.Text)) < 8 Or Len(Trim(lblLicenseNo1.Text)) > 12 Then
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningAlert(this,'ผลการตรวจสอบ','กรุณาระบุเลขที่ใบอนุญาตขายยา (ขย.5) ให้ถูกต้อง');", True)
            Exit Sub
        End If

        'If txtLocationName.Text = "" Then
        '    ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningAlert(this,'ผลการตรวจสอบ','กรุณาระบุชื่อร้านยา');", True)
        '    Exit Sub
        'End If
        'If txtAddressNo.Text = "" Then
        '    ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningAlert(this,'ผลการตรวจสอบ','กรุณาระบุบ้านเลขที่/เลขที่ตั้ง');", True)
        '    Exit Sub
        'End If
        'If txtSubDistict.Text = "" Then
        '    ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningAlert(this,'ผลการตรวจสอบ','กรุณาระบุแขวง/ตำบล');", True)
        '    Exit Sub
        'End If
        'If txtDistrict.Text = "" Then
        '    ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningAlert(this,'ผลการตรวจสอบ','กรุณาระบุเขต/อำเภอ');", True)
        '    Exit Sub
        'End If
        'If txtZipCode.Text = "" Then
        '    ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningAlert(this,'ผลการตรวจสอบ','กรุณาระบุรหัสไปรษณีย์');", True)
        '    Exit Sub
        'End If
        If txtTel.Text = "" Then
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningAlert(this,'ผลการตรวจสอบ','กรุณาระบุเบอร์โทร');", True)
            Exit Sub
        End If
        If txtEmail.Text = "" Then
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningAlert(this,'ผลการตรวจสอบ','กรุณาระบุอีเมล');", True)
            Exit Sub
        End If
        If Check_Email(txtEmail.Text) = False Then
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningAlert(this,'ผลการตรวจสอบ','รูปแบบอีเมลไม่ถูกต้อง กรุณาตรวจสอบ');", True)
            Exit Sub
        End If
        If lblLicenseNo1.Text = "" Then
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningAlert(this,'ผลการตรวจสอบ','กรุณาระบุเลขที่ใบอนุญาต ขย.5');", True)
            Exit Sub
        End If
        'If txtLicensee.Text = "" Then
        '    ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningAlert(this,'ผลการตรวจสอบ','กรุณาระบุชื่อผู้ได้รับอนุญาต');", True)
        '    Exit Sub
        'End If
        'If txtAuthName.Text = "" Then
        '    ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','กรุณาระบุชื่อผู้ดำเนินกิจการ');", True)
        '    Exit Sub
        'End If
        'If txtPharmacist.Text = "" Then
        '    ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','กรุณาระบุชื่อผู้มีหน้าที่ปฏิบัติการ);", True)
        '    Exit Sub
        'End If
        'If txtPharmacistLicenseNo.Text = "" Then
        '    ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','กรุณาระบุเลขใบประกอบวิชาชีพฯ');", True)
        '    Exit Sub
        'End If
        If txtArea1.Text = "" Or txtArea2.Text = "" Then
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningAlert(this,'ผลการตรวจสอบ','กรุณาระบุจำนวนคูหา หรือ พื้นที่ร้าน');", True)
            Exit Sub
        End If

        Dim sLat, sLng, sL() As String
        sLat = ""
        sLng = ""
        If txtLat.Text <> "" Then
            sL = Split(Replace(txtLat.Text, " ", ""), ",")
            sLat = sL(0)
            If sL.Length > 1 Then
                sLng = sL(1)
            End If

            If IsNumeric(sLat) = False Or IsNumeric(sLng) = False Then
                ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','กรุณาระบุละติจูด/ลองติจูด เป็นรูปแบบองศาทศนิยมเท่านั้น ');", True)
                Exit Sub
            End If
        End If

        Dim Generator As System.Random = New System.Random()
        Dim sPassword As String = Generator.Next(1000, 9999).ToString()
        Dim enc As New CryptographyEngine


        ctlL.Location_Register(lblNewCode.Text, lblLicenseNo1.Text, lblLicenseNo1.Text, enc.EncryptString(sPassword, True), lblLocationName.Text, lblAddressNo.Text, lblMoo.Text, lblRoad.Text, lblSubDistict.Text, lblDistrict.Text, ddlProvince.SelectedValue, lblZipCode.Text, txtTel.Text, txtEmail.Text, txtLineID.Text, txtWorkTime.Text, sLat, sLng, txtFacebook.Text, StrNull2Zero(txtQAYear.Text), lblLicenseNo1.Text, txtLicenseNo2.Text, txtLicenseNo3.Text, lblLicensee.Text, StrNull2Zero(optLicenseeType.SelectedValue), StrNull2Zero(txtArea1.Text), StrNull2Double(txtArea2.Text), StrNull2Zero(ddlGroup.SelectedValue), StrNull2Zero(ddlChain.SelectedValue), 1, "N", "", "N", lblAuthName.Text, lblPharmacist.Text, lblPharmacistLicenseNo.Text)

        Dim ctlU As New UserController
        ctlU.User_GenLogfile(0, ACTTYPE_ADD, "Locations", "ลงทะเบียนร้านยาใหม่", "[LicenseNo1=" & lblLicenseNo1.Text & "]", Environment.MachineName, GetIPAddress())

        ctlU.UserLogfile_UpdateByLicenseNo(lblLicenseNo1.Text)


        For i = 0 To chkLocationType.Items.Count - 1
            If chkLocationType.Items(i).Selected Then
                ctlL.LocationTypeDetail_SaveByLicense(lblLicenseNo1.Text, chkLocationType.Items(i).Value)
            End If
        Next
        Try
            SendEmail(lblLicensee.Text, lblLicenseNo1.Text, sPassword, txtEmail.Text)
        Catch ex As Exception

        End Try

        Response.Redirect("RegisterComplete.aspx?u=" & lblLicenseNo1.Text & "&p=" & sPassword)

        'ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalSuccess(this,'ผลการตรวจสอบ','สร้าง Customer Company เรียบร้อย');", True)

    End Sub

    Protected Sub ddlGroup_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlGroup.SelectedIndexChanged
        If ddlGroup.SelectedValue = 2 Then
            ddlChain.Enabled = True
        Else
            ddlChain.Enabled = False
        End If
    End Sub
    Private Sub SendEmail(PersonName As String, Username As String, Password As String, sTo As String)
        Dim SenderDisplayName As String = "สำนักงานรับรองร้านยาคุณภาพ สภาเภสัชกรรม"
        Dim MySubject As String = "ยืนยันการลงทะเบียนเข้าใช้งานระบบประเมินร้านยาคุณภาพ :" & lblLocationName.Text
        Dim MyMessageBody As String = ""

        MyMessageBody = " <font size='4'>
    
  <p> เรียน คุณ " & PersonName & "</p>
  <p> เรื่อง ยืนยันการลงทะเบียนเข้าใช้งานระบบประเมินร้านยาคุณภาพ</p> 
     <p>ท่านสามารถเข้าใช้งานระบบประเมินร้านยาคุณภาพได้ที่ <a href='https://www.acc-pharm.com'>https://www.acc-pharm.com</p> 
  <p>ข้อมูลผู้ใช้งานของท่าน</p>
        ชื่อผู้ใช้ (Username) : " & Username & " <br />
        รหัสผ่าน (Password) : " & Password & "  <br /> <br />

   <font color='#ff0000'>    **อีเมล์นี้เป็นระบบอัตโนมัติ ห้ามตอบกลับใดๆทั้งสิ้น** </font><br />
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

End Class