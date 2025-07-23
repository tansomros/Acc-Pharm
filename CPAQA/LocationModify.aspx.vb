Imports System.Net.Mail
Imports System.Web
Imports System.IO
Imports Microsoft.Reporting.WebForms
Imports System.Net
Imports System.Drawing
Imports DevExpress.Web
Imports DevExpress.Web.Internal
Imports Newtonsoft.Json
Imports BigLion
Public Class LocationModify
    Inherits System.Web.UI.Page
    Dim dt As New DataTable
    Dim ctlM As New MasterController
    Dim ctlL As New LocationController
    Private UploadDirectory As String

    Dim ctlPs As New PharmacistController
    Dim ctlMd As New MediaController
    Dim ctlU As New UserController
    Dim ctlD As New DocumentController

    Public Shared json As String
    Public Shared lat As Double
    Public Shared lng As Double

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsNothing(Request.Cookies("CPAQA")) Then
            Response.Redirect("Default.aspx")
        End If
        Response.Cache.SetExpires(DateTime.Now.AddSeconds(60))
        Response.Cache.SetCacheability(HttpCacheability.Public)
        Response.Cache.SetValidUntilExpires(True)
        If Not IsPostBack Then
            chkStatus.Checked = True
            pnCCR.Visible = False
            pnWarning.Visible = False
            pnRisk.Visible = False
            pnMember.Visible = False
            pnPharmacist.Visible = False
            'UploadDirectory = Server.MapPath("~/imageUploads/" + +"/")
            ddlAccStatus.SelectedValue = "N"
            LoadProvinceToDDL()
            LoadLocationGroupToDDL()
            LoadLocationChainToDDL()
            LoadLocationTypeToCheckList()
            LoadDocumentCategory()
            LoadWarningSubjectToDDL()

            If Request("s") = "reg2" Then
                chkPPH.Checked = True
            End If

            ddlChain.Enabled = False
            If Not Request("lid") = Nothing Then
                '    If (Not Request("t") = Nothing) And (Request("t") <> "new") Then
                '        EditLocationData(Request.Cookies("LoginLocationUID").Value)
                '    End If
                'Else
                lblDistrict.Visible = False
                ddlDistrict.Visible = True

                EditLocationData(Request("lid"))

                If StrNull2Zero(hdLocationUID.Value) <> 0 Then
                    pnMember.Visible = True
                    pnPharmacist.Visible = True
                End If
                LoadImg()
                LoadImgPharmacist()
                LoadDocument()
            Else 'Add New
                If Request("p") = "reg" Then
                    LoadLocationDataFromFDA()
                End If
            End If

            If Request.Cookies("ROLE_ID").Value = "1" Then
                txtLocationName.Enabled = False
                txtAddressNo.Enabled = False
                txtMoo.Enabled = False
                txtRoad.Enabled = False
                txtSubDistrict.Enabled = False
                ddlDistrict.Enabled = False
                ddlProvince.Enabled = False
                txtZipCode.Enabled = False
                txtAuthName.Enabled = False
                txtLicensee.Enabled = False
                txtPharmacist.Enabled = False
                txtPharmacistLicenseNo.Enabled = False
                optLicenseeType.Enabled = False

                ddlPType.SelectedIndex = 1
                ddlPType.Enabled = False
            Else
                pnCCR.Visible = True
                pnWarning.Visible = True
                pnRisk.Visible = True
                LoadCCR()
                LoadRisk()
                LoadWarning()
            End If
            If Request.Cookies("ROLE_ID").Value <> "3" And Request.Cookies("ROLE_ID").Value <> "9" Then
                pnCCRInput.Visible = False
                grdCCR.Columns(4).Visible = False
                pnWarningInput.Visible = False
                grdWarning.Columns(4).Visible = False
            End If

        End If
        txtStartYear.Attributes.Add("OnKeyPress", "return AllowOnlyIntegers();")
        txtArea1.Attributes.Add("OnKeyPress", "return AllowOnlyDouble();")
        txtArea2.Attributes.Add("OnKeyPress", "return AllowOnlyDouble();")
        txtZipCode.Attributes.Add("OnKeyPress", "return AllowOnlyIntegers();")
        txtEmail.Attributes.Add("OnKeyPress", "return NotAllowThai();")

        txtPLicense.Attributes.Add("OnKeyPress", "return AllowOnlyIntegers();")
        txtPharmacistLicenseNo.Attributes.Add("OnKeyPress", "return AllowOnlyIntegers();")

        'txtLat.Attributes.Add("OnKeyPress", "return AllowOnlyDouble();")
        'txtLng.Attributes.Add("OnKeyPress", "return AllowOnlyDouble();")
    End Sub
    Function checkField(tD As DataTable, ColumnName As String) As String
        If tD.Columns(ColumnName) IsNot Nothing Then
            Return String.Concat(tD.Rows(0)(ColumnName))
        Else
            Return ""
        End If
    End Function
    Private Sub LoadLocationDataFromFDA()
        Dim ctlFDA As New FDAServiceController
        Dim NewCode As String
        NewCode = ctlFDA.ConvertLicenseToNewCode(Session("LicenseRegister"))
        hdNewCode.Value = NewCode
        lnkFDA.NavigateUrl = "https://pertento.fda.moph.go.th/FDA_SEARCH_DRUG/SEARCH_DRUG/pop-up_drug_location_operator.aspx?Newcode_not=" & hdNewCode.Value

        dt = ctlFDA.GET_DRUG_PHARMACY(NewCode)
        If dt Is Nothing Then
            txtLicenseNo1.Text = Session("LicenseRegister")
            'lblthanm.Text = "ไม่พบเลข ขย.นี้ในฐานข้อมูล อย. กรุณาตรวจสอบ"
            Exit Sub
        End If
        If dt.Rows.Count > 0 Then
            dt.DefaultView.Sort = "appdate desc,lcnno desc"
            Dim dtResult As DataTable = dt.DefaultView.ToTable()
            With dt.Rows(0)
                Try
                    txtLocationName.Text = checkField(dtResult, "thanm")
                    txtAddressNo.Text = checkField(dtResult, "thaaddr") '& " " & checkField(dtResult, "tharoad")
                    txtSubDistrict.Text = checkField(dtResult, "thathmblnm")
                    lblDistrict.Text = checkField(dtResult, "thaamphrnm")
                    ddlDistrict.Visible = False
                    lblDistrict.Visible = True
                    ddlProvince.SelectedValue = checkField(dtResult, "pvncd")
                    txtZipCode.Text = checkField(dtResult, "zipcode")
                    txtTel.Text = checkField(dtResult, "tel")
                    'txtLicensee.Text = checkField(dtResult, "grannm_lo")
                    'txtWorkTime.Text = checkField(dtResult, "licen_time")
                    txtLicenseNo1.Text = Session("LicenseRegister") ' Replace(String.Concat(.Item("lcnno_noo")), " ", ".")

                    txtLicensee.Text = checkField(dtResult, "licen")
                    txtWorkTime.Text = checkField(dtResult, "licen_time")

                    txtAuthName.Text = checkField(dtResult, "grannm_lo")
                    txtPharmacist.Text = checkField(dtResult, "phrnm")
                    txtPharmacistLicenseNo.Text = checkField(dtResult, "phrno")
                    txtPharmacistLicenseNo.Text = Replace(txtPharmacistLicenseNo.Text, "ภ.", "")

                    'txtLicenseNo1.Text = String.Concat(Session("LicenseRegister"))
                    'txtLastUpdate.Text = "Last update :" & String.Concat(.Item("lmdfdate"))
                    'hdNewCode.Value = checkField(dtResult, "Newcode_not")

                Catch ex As Exception

                End Try
            End With
        End If
    End Sub

    Private Sub LoadMaps(LID As Integer)
        Dim dtMap As New DataTable
        dtMap = ctlL.Location_GetMapsByLocation(LID)
        If dtMap.Rows.Count > 0 Then
            lat = DBNull2Dbl(dtMap.Rows(0)("lat"))
            lng = DBNull2Dbl(dtMap.Rows(0)("lng"))
        End If
        json = JsonConvert.SerializeObject(dtMap, Formatting.Indented)
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

    Private Sub LoadDistrictToDDL()
        dt = ctlM.District_GetForReport(ddlProvince.SelectedValue)
        If dt.Rows.Count > 0 Then
            With ddlDistrict
                .Enabled = True
                .DataSource = dt
                .DataTextField = "DistrictName"
                .DataValueField = "DistrictID"
                .DataBind()
                '.SelectedIndex = 0
            End With
        End If
        dt = Nothing
    End Sub
    Private Sub LoadWarningSubjectToDDL()
        dt = ctlM.ReferenceValue_GetByDomainCode("WARN")
        If dt.Rows.Count > 0 Then
            With ddlWarningType
                .Enabled = True
                .DataSource = dt
                .DataTextField = "Descriptions"
                .DataValueField = "ValueCode"
                .DataBind()
            End With
        End If
        dt = Nothing
    End Sub

    'Private Sub LoadAccStatusToDDL()
    '    dt = ctlM.AccStatus_Get
    '    If dt.Rows.Count > 0 Then
    '        With ddlCurrentStatus
    '            .Enabled = True
    '            .DataSource = dt
    '            .DataTextField = "Name"
    '            .DataValueField = "UID"
    '            .DataBind()
    '        End With
    '    End If
    '    dt = Nothing
    'End Sub

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
        dt = ctlL.LocationType_GetActive
        If dt.Rows.Count > 0 Then
            chkLocationType.DataSource = dt
            chkLocationType.DataTextField = "Name"
            chkLocationType.DataValueField = "UID"
            chkLocationType.DataBind()
        End If
        dt = Nothing
    End Sub


    Private Sub EditLocationData(ByVal pID As String)
        Dim dtL As New DataTable

        dtL = ctlL.Location_GetByUID(pID)
        If dtL.Rows.Count > 0 Then
            With dtL.Rows(0)
                hdLocationUID.Value = .Item("UID")
                hdNewCode.Value = String.Concat(.Item("NewCode"))
                lnkFDA.NavigateUrl = "https://pertento.fda.moph.go.th/FDA_SEARCH_DRUG/SEARCH_DRUG/pop-up_drug_location_operator.aspx?Newcode_not=" & String.Concat(.Item("NewCode"))

                LoadMaps(DBNull2Zero(.Item("UID")))

                UploadDirectory = Server.MapPath("~/imageUploads/" + String.Concat(.Item("UID")) + "/Locations/")
                If Not Directory.Exists(UploadDirectory) Then
                    Directory.CreateDirectory(UploadDirectory)
                End If

                txtNHSOCode.Text = String.Concat(.Item("NHSOCode"))

                txtLocationName.Text = String.Concat(.Item("LocationName"))
                txtAddressNo.Text = String.Concat(.Item("AddressNo"))
                txtMoo.Text = String.Concat(.Item("Moo"))
                txtRoad.Text = String.Concat(.Item("Road"))
                txtSubDistrict.Text = String.Concat(.Item("Subdistrict"))

                ddlProvince.SelectedValue = String.Concat(.Item("ProvinceID"))
                LoadDistrictToDDL()

                lblDistrict.Text = String.Concat(.Item("District"))
                If DBNull2Zero(.Item("DistrictID")) <> 0 Then
                    ddlDistrict.SelectedValue = String.Concat(.Item("DistrictID"))
                    lblDistrict.Visible = False
                Else
                    lblDistrict.Visible = True
                End If

                txtZipCode.Text = String.Concat(.Item("ZipCode"))

                txtTel.Text = String.Concat(.Item("Tel"))
                txtEmail.Text = String.Concat(.Item("EMail"))
                txtLineID.Text = String.Concat(.Item("LineID"))
                txtFacebook.Text = String.Concat(.Item("Facebook"))

                If String.Concat(.Item("Lng")) <> "" Then
                    txtLat.Text = String.Concat(.Item("Lat")) & "," & String.Concat(.Item("Lng"))
                Else
                    txtLat.Text = String.Concat(.Item("Lat"))
                End If

                'txtLng.Text = String.Concat(.Item("Lng"))
                txtWorkTime.Text = String.Concat(.Item("WorkTime"))
                txtStartYear.Text = String.Concat(.Item("StartYear"))

                txtLicenseNo1.Text = String.Concat(.Item("LicenseNo1"))
                txtLicenseNo2.Text = String.Concat(.Item("LicenseNo2"))
                txtLicenseNo3.Text = String.Concat(.Item("LicenseNo3"))
                txtLicensee.Text = String.Concat(.Item("Licensee"))
                optLicenseeType.SelectedValue = String.Concat(.Item("LicenseeType"))

                txtAuthName.Text = String.Concat(.Item("AuthPerson"))
                txtPharmacist.Text = String.Concat(.Item("Pharmacist"))
                txtPharmacistLicenseNo.Text = String.Concat(.Item("PharmacistLicenseNo"))

                ddlGroup.SelectedValue = String.Concat(.Item("LocationGroupUID"))
                'ddlType.SelectedValue = String.Concat(.Item("LocationTypeUID"))
                ddlChain.SelectedValue = String.Concat(.Item("LocationChainUID"))
                If ddlGroup.SelectedValue = 2 Then
                    ddlChain.Enabled = True
                Else
                    ddlChain.Enabled = False
                End If

                LoadLocationType(.Item("UID"))
                txtArea1.Text = String.Concat(.Item("Area1"))
                txtArea2.Text = String.Concat(.Item("Area2"))

                ddlAccStatus.SelectedValue = String.Concat(.Item("AccStatus"))
                txtAccLicense.Text = String.Concat(.Item("AccLicense"))
                txtStartDate.Text = ConvertStrDate2ShortTH(String.Concat(.Item("StartDate")))
                txtExpireDate.Text = ConvertStrDate2ShortTH(String.Concat(.Item("ExpireDate")))
                txtBeginDate.Text = ConvertStrDate2ShortTH(String.Concat(.Item("BeginDate")))
                txtCertName1.Text = String.Concat(.Item("CertName1"))
                txtCertName2.Text = String.Concat(.Item("CertName2"))
                txtCertAddress.Text = String.Concat(.Item("CertAddress"))
                txtAccRemark.Text = String.Concat(.Item("AccRemark"))
                If Request.Cookies("ROLE_ID").Value > 1 Then
                    chkStatus.Visible = True
                    chkAccPharm.Visible = True
                    ddlAccStatus.Enabled = True
                Else
                    chkAccPharm.Visible = False
                    chkStatus.Visible = False
                    chkPPH.Visible = False
                    ddlAccStatus.Enabled = False
                    txtAccLicense.ReadOnly = True
                    txtStartDate.Enabled = False
                    txtExpireDate.Enabled = False
                    txtBeginDate.Enabled = False
                    txtAccRemark.ReadOnly = True

                End If
                If Request.Cookies("ROLE_ID").Value >= 4 And Request.Cookies("ROLE_ID").Value <= 5 Then
                    chkAccPharm.Visible = False
                    chkStatus.Visible = False
                    chkPPH.Visible = False
                    ddlAccStatus.Enabled = False
                    txtAccLicense.ReadOnly = True
                    txtStartDate.Enabled = False
                    txtExpireDate.Enabled = False
                    txtBeginDate.Enabled = False
                    txtAccRemark.ReadOnly = True
                    txtStartYear.Enabled = False
                    txtCertName1.Enabled = False
                    txtCertName2.Enabled = False
                    txtCertAddress.Enabled = False

                End If

                If String.Concat(.Item("isAccPharm")) = "Y" Then
                    chkAccPharm.Checked = True
                Else
                    chkAccPharm.Checked = False
                End If

                If String.Concat(.Item("StatusFlag")) = "A" Then
                    chkStatus.Checked = True
                Else
                    chkStatus.Checked = False
                End If
                If String.Concat(.Item("IsPPHealth")) = "Y" Then
                    chkPPH.Checked = True
                Else
                    chkPPH.Checked = False
                End If

                'ddlRiskLevel.SelectedValue = String.Concat(.Item("RiskLevel"))
                'txtRiskDate.Text = ConvertStrDate2ShortTH(String.Concat(.Item("RiskDate")))
                'txtRiskDesc.Text = String.Concat(.Item("RiskDescription"))

                LoadPharmacist()

            End With
        End If
        dtL = Nothing
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

        If txtLicenseNo1.Text.Trim() = "" Then
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','กรุณาตรวจสอบเลขที่ ขย.5');", True)
            Exit Sub
        End If

        If StrNull2Zero(hdLocationUID.Value) = 0 Then
            If ctlL.Location_SearchByLicense(txtLicenseNo1.Text) > 0 Then
                ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','เลขที่ใบอนุญาตนี้มี User ในระบบแล้ว ไม่สามารถเพิ่มซ้ำได้');", True)
                Exit Sub
            End If
        End If
        If Request.Cookies("ROLE_ID").Value = 1 Then
            If IsNumeric(Left(txtLicenseNo1.Text, 1)) Or IsNumeric(Mid(txtLicenseNo1.Text, 2, 1)) Then
                ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','กรุณาระบุเลขที่ใบอนุญาตขายยา (ขย.5) 2 ตัวแรกด้วยรหัสจังหวัด');", True)
                Exit Sub
            End If
            If Len(Trim(txtLicenseNo1.Text)) < 8 Or Len(Trim(txtLicenseNo1.Text)) > 12 Then
                ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','กรุณาระบุเลขที่ใบอนุญาตขายยา (ขย.5) ให้ถูกต้อง');", True)
                Exit Sub
            End If

            If txtLocationName.Text = "" Then
                ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','กรุณาระบุชื่อร้านยา');", True)
                Exit Sub
            End If
            If txtAddressNo.Text = "" Then
                ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','กรุณาระบุบ้านเลขที่/เลขที่ตั้ง');", True)
                Exit Sub
            End If
            If txtSubDistrict.Text = "" Then
                ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','กรุณาระบุแขวง/ตำบล');", True)
                Exit Sub
            End If
            If ddlDistrict.SelectedValue = "0" Then
                ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','กรุณาระบุเขต/อำเภอ');", True)
                Exit Sub
            End If
            If txtZipCode.Text = "" Then
                ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','กรุณาระบุรหัสไปรษณีย์');", True)
                Exit Sub
            End If
            If txtTel.Text = "" Then
                ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','กรุณาระบุเบอร์โทร');", True)
                Exit Sub
            End If
            If txtEmail.Text = "" Then
                ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','กรุณาระบุอีเมล');", True)
                Exit Sub
            End If
            If Check_Email(txtEmail.Text) = False Then
                ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningAlert(this,'ผลการตรวจสอบ','รูปแบบ E-mail ไม่ถูกต้อง กรุณาตรวจสอบ');", True)
                Exit Sub
            End If

            If txtLicenseNo1.Text = "" Then
                ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','กรุณาระบุเลขที่ใบอนุญาต ขย.5');", True)
                Exit Sub
            End If
            If txtLicensee.Text = "" Then
                ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','กรุณาระบุชื่อผู้ได้รับอนุญาต');", True)
                Exit Sub
            End If
            If txtAuthName.Text = "" Then
                ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','กรุณาระบุชื่อผู้ดำเนินกิจการ');", True)
                Exit Sub
            End If
            If txtPharmacist.Text = "" Then
                ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','กรุณาระบุชื่อผู้มีหน้าที่ปฏิบัติการ);", True)
                Exit Sub
            End If
            If txtPharmacistLicenseNo.Text = "" Then
                ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','กรุณาระบุเลขใบประกอบวิชาชีพฯ');", True)
                Exit Sub
            End If

            'If txtArea1.Text = "" Or txtArea2.Text = "" Then
            '    ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','กรุณาระบุจำนวนคูหา หรือ พื้นที่ร้าน');", True)
            '    Exit Sub
            'End If
            'If ddlRiskLevel.SelectedValue > 0 Then
            '    If txtRiskDate.Text = "" Or txtRiskDesc.Text = "" Then
            '        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','กรุณาระบุวันที่และรายละเอียดความเสี่ยง');", True)
            '        Exit Sub
            '    End If
            'End If
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
        Dim IsAccPharm As String = ""
        If chkAccPharm.Checked Then
            IsAccPharm = "Y"
        Else
            IsAccPharm = "N"
        End If

        Dim StatusFlag As String = "A"
        If chkStatus.Checked Then
            StatusFlag = "A"
        Else
            StatusFlag = "D"
        End If

        Dim IsPPHealth As String = "Y"
        If chkPPH.Checked Then
            IsPPHealth = "Y"
        Else
            IsPPHealth = "N"
        End If

        Dim enc As New CryptographyEngine

        If StrNull2Zero(hdLocationUID.Value) = 0 Then
            ctlL.Location_Register(hdNewCode.Value, txtLicenseNo1.Text, txtLicenseNo1.Text, enc.EncryptString("1234", True), txtLocationName.Text, txtAddressNo.Text, txtMoo.Text, txtRoad.Text, txtSubDistrict.Text, ddlDistrict.SelectedItem.Text, ddlProvince.SelectedValue, txtZipCode.Text, txtTel.Text, txtEmail.Text, txtLineID.Text, txtWorkTime.Text, sLat, sLng, txtFacebook.Text, StrNull2Zero(txtStartYear.Text), txtLicenseNo1.Text, txtLicenseNo2.Text, txtLicenseNo3.Text, txtLicensee.Text, StrNull2Zero(optLicenseeType.SelectedValue), StrNull2Zero(txtArea1.Text), StrNull2Double(txtArea2.Text), StrNull2Zero(ddlGroup.SelectedValue), StrNull2Zero(ddlChain.SelectedValue), Request.Cookies("userid").Value, IsAccPharm, txtNHSOCode.Text, IsPPHealth, txtAuthName.Text, txtPharmacist.Text, txtPharmacistLicenseNo.Text)

            hdLocationUID.Value = ctlL.Location_GetUID(txtLicenseNo1.Text).ToString()
            pnMember.Visible = True
            pnPharmacist.Visible = True

            ctlU.User_GenLogfile(Request.Cookies("UserID").Value, ACTTYPE_ADD, "Locations", "เพิ่มร้านยาใหม่", "[LocationUID=" & hdLocationUID.Value & "]", Environment.MachineName, GetIPAddress())
        Else
            If hdNewCode.Value = "" Then
                Dim ctlFDA As New FDAServiceController
                hdNewCode.Value = ctlFDA.ConvertLicenseToNewCode(txtLicenseNo1.Text)
            End If

            ctlL.Location_Update(StrNull2Zero(hdLocationUID.Value), hdNewCode.Value, txtLicenseNo1.Text, txtLicenseNo1.Text, txtLocationName.Text, txtAddressNo.Text, txtMoo.Text, txtRoad.Text, txtSubDistrict.Text, ddlDistrict.SelectedValue, ddlProvince.SelectedValue, txtZipCode.Text, txtTel.Text, txtEmail.Text, txtLineID.Text, txtWorkTime.Text, sLat, sLng, txtFacebook.Text, StrNull2Zero(txtStartYear.Text), txtLicenseNo1.Text, txtLicenseNo2.Text, txtLicenseNo3.Text, txtLicensee.Text, StrNull2Zero(optLicenseeType.SelectedValue), StrNull2Double(txtArea1.Text), StrNull2Double(txtArea2.Text), StrNull2Zero(ddlGroup.SelectedValue), StrNull2Zero(ddlChain.SelectedValue), StatusFlag, Request.Cookies("userid").Value, IsAccPharm, txtNHSOCode.Text, txtCertName1.Text, txtCertName2.Text, txtCertAddress.Text, IsPPHealth, txtAuthName.Text, txtPharmacist.Text, txtPharmacistLicenseNo.Text)

            ctlU.User_GenLogfile(Request.Cookies("UserID").Value, ACTTYPE_UPD, "Locations", "แก้ไขข้อมูลร้านยา", "[LocationUID=" & hdLocationUID.Value & "]", Environment.MachineName, GetIPAddress())
        End If

        ctlL.LocationTypeDetail_Delete(StrNull2Zero(hdLocationUID.Value))
        For i = 0 To chkLocationType.Items.Count - 1
            If chkLocationType.Items(i).Selected Then
                ctlL.LocationTypeDetail_Save(StrNull2Zero(hdLocationUID.Value), chkLocationType.Items(i).Value)
            Else

            End If
        Next

        If Convert.ToInt32(Request.Cookies("ROLE_ID").Value) >= 3 Then
            Dim AccStatus As String = "N"
            If IsAccPharm = "N" Then
                AccStatus = "N"
            Else
                AccStatus = ddlAccStatus.SelectedValue
            End If

            ctlL.Location_UpdateAccStatus(StrNull2Zero(hdLocationUID.Value), AccStatus, txtAccLicense.Text, ConvertStrDate2DBDate(txtStartDate.Text), ConvertStrDate2DBDate(txtExpireDate.Text), ConvertStrDate2DBDate(txtBeginDate.Text), txtAccRemark.Text)
            ctlU.User_GenLogfile(Request.Cookies("UserID").Value, ACTTYPE_UPD, "Locations", "Update เลขที่ใบรับรอง", "[LocationUID=" & hdLocationUID.Value & "][AccLicense=" & txtAccLicense.Text & "]", Environment.MachineName, GetIPAddress())
        End If

        'If Convert.ToInt32(Request.Cookies("ROLE_ID").Value) >= 2 Then
        '    ctlL.Location_UpdateRisk(StrNull2Zero(hdLocationUID.Value), ddlRiskLevel.SelectedValue, ConvertStrDate2DBDate(txtRiskDate.Text), txtRiskDesc.Text)
        '    ctlU.User_GenLogfile(Request.Cookies("UserID").Value, ACTTYPE_UPD, "Locations", "Update การเฝ้าระวัง/ความเสี่ยง", "[LocationUID=" & hdLocationUID.Value & "][Level=" & ddlRiskLevel.SelectedValue & "][Date=" & txtRiskDate.Text & "][Desc=" & txtRiskDesc.Text & "]", Environment.MachineName, GetIPAddress())
        'End If

        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalSuccess(this,'Success','บันทึกข้อมูลเรียบร้อย');", True)

    End Sub

    Protected Sub ddlGroup_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlGroup.SelectedIndexChanged
        If ddlGroup.SelectedValue = 2 Then
            ddlChain.Enabled = True
        Else
            ddlChain.Enabled = False
        End If
    End Sub

    Protected Sub cmdUpload_Click(sender As Object, e As EventArgs) Handles cmdUpload.Click
        Dim SEQNO As String
        Dim sfileName As String = ""

        UploadDirectory = Server.MapPath("imageUploads/" & hdLocationUID.Value & "/Locations/")

        If Not Directory.Exists(UploadDirectory) Then
            Directory.CreateDirectory(UploadDirectory)
        End If

        If FileUploadA.HasFiles Then
            For Each uploadedFile As HttpPostedFile In FileUploadA.PostedFiles
                Dim fileExtname As String = Path.GetExtension(uploadedFile.FileName).ToLower()
                If fileExtname <> ".jpg" And fileExtname <> ".jpeg" And fileExtname <> ".png" Then
                    ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','ไฟล์รูปภาพต้องมีนามสกุล .jpg, .jpeg, .png เท่านั้น');", True)
                    Exit Sub
                End If
                If (uploadedFile.ContentLength / 1024) > 1024 Then
                    ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','ไฟล์มีขนาดใหญ่เกิน 1024 Kb. ไม่สามารถอัพโหลดได้');", True)
                    Exit Sub
                End If

                SEQNO = ctlMd.Media_GetLastSEQ(0, 0, StrNull2Zero(hdLocationUID.Value), "L", 0)
                sfileName = "L" & hdLocationUID.Value & "_" & SEQNO.ToString() & fileExtname

                Dim objfile As FileInfo = New FileInfo(UploadDirectory & sfileName)
                If objfile.Exists Then
                    objfile.Delete()
                End If
                uploadedFile.SaveAs(System.IO.Path.Combine(UploadDirectory, sfileName))
                ctlMd.Media_Save(0, 0, hdLocationUID.Value, "L", 0, SEQNO, sfileName, Request.Cookies("UserID").Value)
            Next
        End If
        LoadImg()
    End Sub

    Private Sub LoadImg()
        dt = ctlMd.Media_GetByLocation(StrNull2Zero(hdLocationUID.Value), "L")
        grdImg.DataSource = dt
        grdImg.DataBind()

        If dt.Rows.Count >= 4 Then
            Label2.Text = "ท่านได้อัพโหลดไฟล์ครบ 4 ไฟล์แล้ว ไม่สามารถอัพโหลดเพิ่มได้อีก"
            cmdUpload.Enabled = False
            Label2.Visible = True
        Else
            Label2.Visible = False
            cmdUpload.Enabled = True
        End If

    End Sub

    Private Sub grdImg_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grdImg.RowCommand
        If TypeOf e.CommandSource Is WebControls.ImageButton Then
            Dim ButtonPressed As WebControls.ImageButton = e.CommandSource
            Select Case ButtonPressed.ID
                Case "imgView"
                    PreviewPicture("", "", e.CommandArgument())
                Case "imgDelFile"
                    DeleteImage(e.CommandArgument)
                    ctlMd.Media_Delete(e.CommandArgument)
                    LoadImg()
            End Select
        End If
    End Sub

    Private Sub grdImg_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles grdImg.RowDataBound
        If e.Row.RowType = ListItemType.AlternatingItem Or e.Row.RowType = ListItemType.Item Then

            Dim scriptString As String = "javascript:return confirm(""ต้องการลบ ข้อมูลนี้ ?"");"
            Dim imgD As ImageButton = e.Row.Cells(0).FindControl("imgDelFile")
            imgD.Attributes.Add("onClick", scriptString)

        End If
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#d0e8ff';")
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;")

        End If
    End Sub
    Private Sub DeleteImage(MediaUID As Integer)
        Dim ctlM As New MediaController
        dt = ctlM.Media_GetByID(MediaUID)
        If dt.Rows.Count > 0 Then
            Dim sPath As String = ""
            Select Case dt.Rows(0)("ImageGroup")
                Case "S", "L", "A", "M"
                    sPath = hdLocationUID.Value & "/Locations/"
                Case "G"
                    sPath = hdLocationUID.Value & "/GPP/"
                Case "P", "R", "Q"
                    sPath = hdLocationUID.Value & "/QA/"
                Case "CCR"
                    sPath = "CCR/"
                Case "WAR"
                    sPath = "Warning/"
            End Select

            Dim objfile As FileInfo = New FileInfo(Server.MapPath("~/imageUploads/" & sPath & dt.Rows(0)("FilePath")))
            If objfile.Exists Then
                objfile.Delete()
            End If

        End If
    End Sub

    Private Sub DeletePharmacistImage(LocationUID As Integer, MediaUID As Integer)
        Dim ctlM As New MediaController
        dt = ctlM.Media_GetPharmacistImage(LocationUID, MediaUID)
        If dt.Rows.Count > 0 Then
            Dim sPath As String = ""
            sPath = "/Locations/"

            Dim objfile As FileInfo = New FileInfo(Server.MapPath("~/imageUploads/" & hdLocationUID.Value & sPath & dt.Rows(0)("FilePath")))
            If objfile.Exists Then
                objfile.Delete()
            End If

        End If
    End Sub


    Private Sub PreviewPicture(Fname As String, Desc As String, filePath As String)
        'Dim fPath As String = "imageUploads/Locations/" & hdLocationUID.Value & "/"
        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWindow(this,'" + Fname + "','" + Desc + "','" + filePath + "');", True)
    End Sub
    'Protected Sub UploadControl_FileUploadComplete(ByVal sender As Object, ByVal e As FileUploadCompleteEventArgs)

    '    If chkFileExist(Server.MapPath(UploadDirectory + Session("picname"))) Then
    '        File.Delete(Server.MapPath(UploadDirectory + Session("picname")))
    '    End If

    '    e.CallbackData = SavePostedFile(e.UploadedFile, UploadDirectory, Path.GetRandomFileName())
    '    Session("picname") = e.CallbackData
    'End Sub
    'Protected Function SavePostedFile(ByVal uploadedFile As UploadedFile, ByVal UploadPath As String, ByVal UploadFileName As String) As String
    '    If (Not uploadedFile.IsValid) Then
    '        Return String.Empty
    '    End If

    '    Dim fileName As String = Path.ChangeExtension(UploadFileName, ".jpg")

    '    Dim fullFileName As String = CombinePath(UploadPath, fileName)
    '    Using original As Image = Image.FromStream(uploadedFile.FileContent)
    '        Using thumbnail As Image = New ImageThumbnailCreator(original).CreateImageThumbnail(New Size(350, 350))
    '            ImageUtils.SaveToJpeg(CType(thumbnail, Bitmap), fullFileName)
    '        End Using
    '    End Using
    '    UploadingUtils.RemoveFileWithDelay(fileName, fullFileName, 5)
    '    Return fileName
    'End Function
    'Protected Function CombinePath(ByVal UploadPath As String, ByVal fileName As String) As String
    '    Return Path.Combine(Server.MapPath(UploadPath), fileName)
    'End Function


    Private Sub LoadPharmacist()
        Dim dtP As New DataTable
        dtP = ctlPs.Pharmacist_Get(hdLocationUID.Value)
        If dtP.Rows.Count > 0 Then
            With grdPharmacist
                .Visible = True
                .DataSource = dtP
                .DataBind()
            End With

            Dim btEdit As LinkButton
            Dim btDel As LinkButton

            For i = 0 To grdPharmacist.Rows.Count - 1
                With grdPharmacist
                    btEdit = .Rows(i).Cells(5).FindControl("imgEdit")
                    btDel = .Rows(i).Cells(5).FindControl("imgDel")

                    If .Rows(i).Cells(3).Text = "Full time" And Convert.ToInt32(Request.Cookies("ROLE_ID").Value) = 1 Then
                        btEdit.Visible = False
                        btDel.Visible = False
                    End If

                End With
            Next

        Else
            grdPharmacist.Visible = False
        End If
        dtP = Nothing
    End Sub

    Protected Sub cmdAddPharmacist_Click(sender As Object, e As EventArgs) Handles cmdAddPharmacist.Click
        If txtPName.Text = "" Or txtPLicense.Text = "" Then
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','กรุณป้อนข้อมูลให้ครบถ้วน');", True)
            Exit Sub
        End If
        Dim PLicense As String
        PLicense = txtPLicense.Text
        PLicense = Replace(txtPLicense.Text, "ภ", "")
        PLicense = Replace(PLicense, ".", "")
        PLicense = Replace(PLicense, " ", "")

        Dim REFUID As String

        If StrNull2Zero(hdPharmacistUID.Value) = 0 Then
            ctlPs.Pharmacist_Add(txtPName.Text, PLicense, ddlPType.SelectedValue, "", StrNull2Zero(hdLocationUID.Value), Request.Cookies("UserID").Value)
            ctlU.User_GenLogfile(Request.Cookies("UserID").Value, ACTTYPE_ADD, "Pharmacists", "เพิ่มรายชื่อเภสัชกรประจำร้านยา :" & txtPName.Text, "เพิ่มแบบทีละคน", Environment.MachineName, GetIPAddress())
            REFUID = ctlPs.Pharmacist_GetUID(StrNull2Zero(hdLocationUID.Value), txtPName.Text, PLicense).ToString
        Else
            ctlPs.Pharmacist_Update(StrNull2Zero(hdPharmacistUID.Value), txtPName.Text, PLicense, ddlPType.SelectedValue, "", StrNull2Zero(hdLocationUID.Value), Request.Cookies("UserID").Value)
            ctlU.User_GenLogfile(Request.Cookies("UserID").Value, ACTTYPE_UPD, "Pharmacists", "แก้ไขชื่อเภสัชกรประจำร้านยา :" & txtPName.Text, "เพิ่มแบบทีละคน", Environment.MachineName, GetIPAddress())
            REFUID = hdPharmacistUID.Value
        End If

        Dim sfileName As String = ""
        UploadDirectory = Server.MapPath("~/imageUploads/" & hdLocationUID.Value & "/Locations/")

        If Not Directory.Exists(UploadDirectory) Then
            Directory.CreateDirectory(UploadDirectory)
        End If

        If FileUploadP.HasFiles Then
            For Each uploadedFile As HttpPostedFile In FileUploadP.PostedFiles
                Dim fileExtname As String = Path.GetExtension(uploadedFile.FileName).ToLower()
                If fileExtname <> ".jpg" And fileExtname <> ".jpeg" And fileExtname <> ".png" Then
                    ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','ไฟล์รูปภาพต้องมีนามสกุล .jpg, .jpeg, .png เท่านั้น');", True)
                    Exit Sub
                End If
                If (FileUploadP.PostedFile.ContentLength / 1024) > 1024 Then
                    ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','ไฟล์มีขนาดใหญ่เกิน 1024 Kb. ไม่สามารถอัพโหลดได้');", True)
                    Exit Sub
                End If

                sfileName = "M" & REFUID & fileExtname

                Dim objfile As FileInfo = New FileInfo(UploadDirectory & sfileName)
                If objfile.Exists Then
                    objfile.Delete()
                End If
                uploadedFile.SaveAs(System.IO.Path.Combine(UploadDirectory, sfileName))
                ctlMd.Media_Save(0, 0, hdLocationUID.Value, "M", REFUID, 1, sfileName, Request.Cookies("UserID").Value)
                ctlPs.Pharmacist_UpdateImgName(REFUID, sfileName)
            Next
        End If

        LoadPharmacist()
        LoadImgPharmacist()
        ClearPharmacistData()
    End Sub
    Private Sub ClearPharmacistData()
        hdPharmacistUID.Value = "0"
        txtPName.Text = ""
        txtPLicense.Text = ""
        ddlPType.SelectedIndex = 1
        grdTime.DataSource = Nothing
        grdTime.Visible = True
        chkDay.ClearSelection()
        chkAll.Checked = False
        chkNon.Checked = False
        chkAll.Enabled = True
        chkNon.Enabled = True
    End Sub
    Private Sub grdPharmacist_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdPharmacist.RowCommand
        If TypeOf e.CommandSource Is WebControls.LinkButton Then
            Dim ButtonPressed As WebControls.LinkButton = e.CommandSource
            Select Case ButtonPressed.ID
                'Case "imgTime"
                '    hdPTimeUID.Value = e.CommandArgument()
                '    lblPharmacistName.Text = ctlPs.Pharmacist_GetName(e.CommandArgument)
                '    LoadTime()
                '    ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalTime(this,'" + e.CommandArgument() + "');", True)
                Case "imgEdit"
                    EditPharmacistData(e.CommandArgument())
                Case "imgDel"
                    DeletePharmacistImage(hdLocationUID.Value, e.CommandArgument)
                    If ctlPs.Pharmacist_Delete(e.CommandArgument) Then
                        ctlU.User_GenLogfile(Request.Cookies("UserID").Value, "DEL", "Pharmacists", "ลบเภสัชกรประจำร้านยา :" & e.CommandArgument, "", Environment.MachineName, GetIPAddress())
                        'ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalSuccess(this,'Success','ลบข้อมูลเรียบร้อย');", True)
                    Else
                        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','ไม่สามารถลบข้อมูลได้ กรุณาตรวจสอบและลองใหม่อีกครั้ง');", True)
                    End If
                    LoadPharmacist()
            End Select
        End If
    End Sub

    Private Sub grdPharmacist_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdPharmacist.RowDataBound
        If e.Row.RowType = ListItemType.AlternatingItem Or e.Row.RowType = ListItemType.Item Then

            'e.Row.Cells(0).Text = e.Row.RowIndex + 1
            Dim scriptString As String = "javascript:return confirm(""ต้องการลบ ข้อมูลนี้ ?"");"
            Dim imgD As LinkButton = e.Row.Cells(5).FindControl("imgDel")
            imgD.Attributes.Add("onClick", scriptString)

        End If
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#d0e8ff';")
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;")

        End If

    End Sub

    Private Sub EditPharmacistData(ByVal pID As String)
        ClearPharmacistData()
        dt = ctlPs.GetPharmacist_ByID(pID)
        If dt.Rows.Count > 0 Then
            With dt.Rows(0)
                hdPharmacistUID.Value = .Item("UID")
                txtPName.Text = String.Concat(.Item("PharmacistName"))
                txtPLicense.Text = String.Concat(.Item("License"))
                'txtPTime.Text = String.Concat(.Item("WorkTime"))
                ddlPType.SelectedValue = String.Concat(.Item("WorkType"))

                LoadTime()
            End With

        End If
        'chkNon.Enabled = True
        'chkDay.Enabled = True

        dt = Nothing
    End Sub
    Private Sub LoadImgPharmacist()
        dt = ctlPs.PharmacistImage_Get(StrNull2Zero(hdLocationUID.Value))
        grdImgPharmacist.DataSource = dt
        grdImgPharmacist.DataBind()

        Dim btDel As ImageButton

        For i = 0 To grdImgPharmacist.Rows.Count - 1
            With grdImgPharmacist
                btDel = .Rows(i).Cells(0).FindControl("imgDelFile")

                If Convert.ToInt32(Request.Cookies("ROLE_ID").Value) = 1 Then
                    btDel.Visible = False
                End If

            End With
        Next

    End Sub
    Private Sub grdImgPharmacist_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grdImgPharmacist.RowCommand
        If TypeOf e.CommandSource Is WebControls.ImageButton Then
            Dim ButtonPressed As WebControls.ImageButton = e.CommandSource
            Select Case ButtonPressed.ID
                Case "imgView"
                    PreviewPicture("", "", e.CommandArgument())
                Case "imgDelFile"
                    DeletePharmacistImage(hdLocationUID.Value, e.CommandArgument)
                    ctlPs.Pharmacist_Delete(e.CommandArgument)
                    LoadImgPharmacist()
                    LoadPharmacist()
            End Select
        End If
    End Sub

    Private Sub grdImgPharmacist_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles grdImgPharmacist.RowDataBound
        If e.Row.RowType = ListItemType.AlternatingItem Or e.Row.RowType = ListItemType.Item Then

            Dim scriptString As String = "javascript:return confirm(""ต้องการลบ ข้อมูลนี้ ?"");"
            Dim imgD As ImageButton = e.Row.Cells(0).FindControl("imgDelFile")
            imgD.Attributes.Add("onClick", scriptString)

        End If
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#d0e8ff';")
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;")

        End If
    End Sub

    Private Sub LoadDocumentCategory()
        ddlDocument.DataSource = ctlD.LocationDocument_GetCategory
        ddlDocument.DataTextField = "Descriptions"
        ddlDocument.DataValueField = "ValueCode"
        ddlDocument.DataBind()
    End Sub

    Private Sub LoadDocument()
        dt = ctlD.LocationDocument_Get(hdLocationUID.Value)
        grdDocument.DataSource = dt
        grdDocument.DataBind()
    End Sub
    Private Sub LoadCCR()
        dt = ctlL.LocationCCR_Get(StrNull2Zero(hdLocationUID.Value))
        grdCCR.DataSource = dt
        grdCCR.DataBind()
    End Sub
    Private Sub LoadRisk()
        dt = ctlL.LocationRisk_Get(StrNull2Zero(hdLocationUID.Value))
        grdRisk.DataSource = dt
        grdRisk.DataBind()
    End Sub
    Private Sub LoadWarning()
        dt = ctlL.LocationWarning_Get(StrNull2Zero(hdLocationUID.Value))
        grdWarning.DataSource = dt
        grdWarning.DataBind()

        If dt.Rows.Count > 0 Then
            txtWarnSeqNo.Text = StrNull2Zero(dt.Rows.Count) + 1
        Else
            txtWarnSeqNo.Text = "1"
        End If
    End Sub
    Protected Sub cmdAddFile_Click(sender As Object, e As EventArgs) Handles cmdAddFile.Click
        Dim sfileName As String = ""
        UploadDirectory = Server.MapPath(DocumentLocation & "/" & hdLocationUID.Value)
        If Not Directory.Exists(UploadDirectory) Then
            Directory.CreateDirectory(UploadDirectory)
        End If

        If FileUpload1.HasFiles Then
            Dim fileExtname As String = Path.GetExtension(FileUpload1.FileName).ToLower()
            If fileExtname <> ".jpg" And fileExtname <> ".jpeg" And fileExtname <> ".png" And fileExtname <> ".pdf" And fileExtname <> ".docx" Then
                ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','ไฟล์รูปภาพต้องมีนามสกุล .jpg, .jpeg,.png,ไฟล์เอกสาร เท่านั้น');", True)
                Exit Sub
            End If

            If (FileUpload1.PostedFile.ContentLength / 1024) > 5120 Then
                ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','ไฟล์มีขนาดใหญ่เกิน 5,120 Kb. ไม่สามารถอัพโหลดได้');", True)
                Exit Sub
            End If

            sfileName = "LDocument_" & ddlDocument.SelectedValue & fileExtname
            Dim objfile As FileInfo = New FileInfo(UploadDirectory & sfileName)
            If objfile.Exists Then
                objfile.Delete()
            End If
            FileUpload1.SaveAs(System.IO.Path.Combine(UploadDirectory, sfileName))
            ctlD.LocationDocument_Save(StrNull2Long(ddlDocument.SelectedValue), StrNull2Zero(hdLocationUID.Value), sfileName, StrNull2Zero(Request.Cookies("UserID").Value))
        End If
        LoadDocument()
    End Sub
    Private Sub grdDocument_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grdDocument.RowCommand
        If TypeOf e.CommandSource Is WebControls.ImageButton Then
            Dim ButtonPressed As WebControls.ImageButton = e.CommandSource
            Select Case ButtonPressed.ID
                Case "imgDel"
                    DeleteDocumentFile(e.CommandArgument)
                    ctlD.Document_Delete(e.CommandArgument)
                    LoadDocument()
            End Select
        End If
    End Sub


    Private Sub grdDocument_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles grdDocument.RowDataBound
        If e.Row.RowType = ListItemType.AlternatingItem Or e.Row.RowType = ListItemType.Item Then
            Dim scriptString As String = "javascript:return confirm(""ต้องการลบ ข้อมูลนี้ ?"");"
            Dim imgD As ImageButton = e.Row.Cells(2).FindControl("imgDel")
            imgD.Attributes.Add("onClick", scriptString)

        End If
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#d0e8ff';")
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;")
        End If
    End Sub

    Private Sub cmdClearPharmacist_Click(sender As Object, e As EventArgs) Handles cmdClearPharmacist.Click
        hdPharmacistUID.Value = "0"
        txtPLicense.Text = ""
        txtPName.Text = ""
        grdTime.DataSource = Nothing
        grdTime.Visible = False
    End Sub

    Private Sub grdTime_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grdTime.RowCommand
        If TypeOf e.CommandSource Is WebControls.ImageButton Then
            Dim ButtonPressed As WebControls.ImageButton = e.CommandSource
            Select Case ButtonPressed.ID
                Case "imgDelT"
                    ctlPs.PharmacistTime_Delete(e.CommandArgument)
                    LoadTime()
            End Select
        End If
    End Sub

    Private Sub grdTime_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles grdTime.RowDataBound
        If e.Row.RowType = ListItemType.AlternatingItem Or e.Row.RowType = ListItemType.Item Then
            Dim scriptString As String = "javascript:return confirm(""ต้องการลบ ข้อมูลนี้ ?"");"
            Dim imgD As ImageButton = e.Row.Cells(0).FindControl("imgDelT")
            imgD.Attributes.Add("onClick", scriptString)
        End If
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#d0e8ff';")
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;")

        End If
    End Sub

    Private Sub LoadTime()
        'If StrNull2Zero(hdPharmacistUID.Value) = 0 Then
        dt = ctlPs.PharmacistTime_GetByCode(StrNull2Zero(hdLocationUID.Value), txtPLicense.Text)
        'Else
        'dt = ctlPs.PharmacistTime_Get(StrNull2Zero(hdPharmacistUID.Value))
        'End If

        grdTime.DataSource = dt
        grdTime.DataBind()
        grdTime.Visible = True
    End Sub

    Private Sub cmdSaveTime_Click(sender As Object, e As EventArgs) Handles cmdSaveTime.Click
        If txtPName.Text = "" Or txtPLicense.Text = "" Then
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','กรุณป้อนข้อมูลชื่อ-นามสกุล และ เลขใบประกอบโรคศิลปะ ให้ครบถ้วนก่อน');", True)
            Exit Sub
        End If

        Dim StartTime, EndTime As String
        StartTime = ddlStartHH.SelectedValue & ":" & ddlStartMM.SelectedValue
        EndTime = ddlEndHH.SelectedValue & ":" & ddlEndMM.SelectedValue

        If chkAll.Checked Then
            ctlPs.PharmacistTime_Add(StrNull2Zero(hdLocationUID.Value), StrNull2Zero(hdPharmacistUID.Value), txtPLicense.Text, "ALL", StartTime, EndTime, StrNull2Zero(Request.Cookies("UserID").Value))
        Else

            If chkNon.Checked Then
                ctlPs.PharmacistTime_Add(StrNull2Zero(hdLocationUID.Value), StrNull2Zero(hdPharmacistUID.Value), txtPLicense.Text, "TBD", StartTime, EndTime, StrNull2Zero(Request.Cookies("UserID").Value))
            End If

            For i = 0 To chkDay.Items.Count - 1
                If chkDay.Items(i).Selected Then
                    ctlPs.PharmacistTime_Add(StrNull2Zero(hdLocationUID.Value), StrNull2Zero(hdPharmacistUID.Value), txtPLicense.Text, chkDay.Items(i).Value, StartTime, EndTime, StrNull2Zero(Request.Cookies("UserID").Value))
                End If
            Next
        End If
        LoadTime()
    End Sub
    Protected Sub chkAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkAll.CheckedChanged
        If chkAll.Checked Then
            chkDay.ClearSelection()
            chkDay.Enabled = False
            chkNon.Enabled = False
        Else
            chkDay.Enabled = True
            chkNon.Enabled = True
        End If
    End Sub
    Private Sub DeleteDocumentFile(DocUID As Integer)
        Dim ctlM As New DocumentController
        dt = ctlM.Document_GetByID(DocUID)
        If dt.Rows.Count > 0 Then
            Dim objfile As FileInfo = New FileInfo(Server.MapPath("~/Documents/Locations/" & hdLocationUID.Value & "/" & dt.Rows(0)("FilePath")))
            If objfile.Exists Then
                objfile.Delete()
            End If
        End If
    End Sub

    Private Sub cmdAdd3Year_Click(sender As Object, e As EventArgs) Handles cmdAdd3Year.Click
        If txtStartDate.Text <> "" Then
            txtExpireDate.Text = DisplayShortDateTH(DateAdd(DateInterval.Year, 3, ConvertStringDateToDate(txtStartDate.Text)))
        Else
            txtExpireDate.Text = DisplayShortDateTH(DateAdd(DateInterval.Year, 3, Now.Date()))
        End If
    End Sub

    Protected Sub cmdAddCCR_Click(sender As Object, e As EventArgs) Handles cmdAddCCR.Click
        If txtCCRDate.Text = "" Or txtCCRDetail.Text = "" Then
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','กรุณป้อนวันที่ และ รายละเอียดปัญหา/คำร้องเรียน ให้ครบถ้วนก่อน');", True)
            Exit Sub
        End If

        hdCCRUID.Value = 0

        ctlL.LocationCCR_Save(StrNull2Zero(hdLocationUID.Value), ConvertStrDate2DBDate(txtCCRDate.Text), txtCCRDetail.Text, StrNull2Zero(Request.Cookies("UserID").Value))

        UploadDirectory = Server.MapPath("~/imageUploads/CCR/")

        Dim SEQNO, CCRUID As String
        Dim sfileName As String = ""

        CCRUID = ctlL.LocationCCR_GetUID(hdLocationUID.Value)

        If FileUploadCCR.HasFiles Then
            For Each uploadedFile As HttpPostedFile In FileUploadCCR.PostedFiles
                Dim fileExtname As String = Path.GetExtension(uploadedFile.FileName).ToLower()

                'If ctlM.Media_GetCount(0), 0, StrNull2Zero(hdLocationUID.Value), "CCR", StrNull2Long(SoftID)) >= 4 Then
                '    Exit Sub
                'End If
                If fileExtname <> ".jpg" And fileExtname <> ".jpeg" And fileExtname <> ".png" And fileExtname <> ".pdf" Then
                    ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','ไฟล์รูปภาพต้องมีนามสกุล .jpg, .jpeg, .png ,.pdf เท่านั้น');", True)
                    Exit Sub
                End If
                If (FileUploadCCR.PostedFile.ContentLength / 1024) > 1024 Then
                    ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','ไฟล์มีขนาดใหญ่เกิน 1024 Kb. ไม่สามารถอัพโหลดได้');", True)
                    Exit Sub
                End If


                SEQNO = ctlMd.Media_GetLastSEQ(0, 0, StrNull2Zero(hdLocationUID.Value), "CCR", CCRUID)
                sfileName = Replace(Replace(txtLicenseNo1.Text, ".", ""), "/", "") & "_" & CCRUID & "_" & SEQNO.ToString() & fileExtname

                Dim objfile As FileInfo = New FileInfo(UploadDirectory & sfileName)
                If objfile.Exists Then
                    objfile.Delete()
                End If
                uploadedFile.SaveAs(System.IO.Path.Combine(UploadDirectory, sfileName))
                ctlMd.Media_Save(0, 0, hdLocationUID.Value, "CCR", CCRUID, SEQNO, sfileName, Request.Cookies("UserID").Value)
            Next
        End If


        LoadCCR()
        txtCCRDetail.Text = ""
    End Sub
    Private Sub grdCCR_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grdCCR.RowCommand
        If TypeOf e.CommandSource Is WebControls.ImageButton Then
            Dim ButtonPressed As WebControls.ImageButton = e.CommandSource
            Select Case ButtonPressed.ID
                Case "imgCCR"
                    Dim fPath As String = "imageUploads/CCR/"
                    hdCCRUID.Value = e.CommandArgument()
                    LoadCCRImg()
                    ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalUploadCCR(this,'" + e.CommandArgument() + "');", True)
                Case "imgDel"
                    ctlL.CCR_Delete(e.CommandArgument)
                    LoadCCR()
            End Select
        End If
    End Sub
    Private Sub LoadCCRImg()
        dt = ctlMd.Media_Get(0, StrNull2Zero(hdLocationUID.Value), "CCR", StrNull2Zero(hdCCRUID.Value))
        grdImgCCR.DataSource = dt
        grdImgCCR.DataBind()

        'For i = 0 To dt.Rows.Count - 1

        'Next

        lblImgCCR.Visible = False
        cmdUpImgCCR.Enabled = True

    End Sub

    Private Sub grdImgCCR_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grdImgCCR.RowCommand
        If TypeOf e.CommandSource Is WebControls.ImageButton Then
            Dim ButtonPressed As WebControls.ImageButton = e.CommandSource
            Select Case ButtonPressed.ID
                Case "imgView"
                    PreviewPicture("", "", e.CommandArgument())
                Case "imgDelFile"
                    DeleteImage(e.CommandArgument)
                    ctlMd.Media_Delete(e.CommandArgument)
                    LoadCCRImg()
            End Select
        End If
    End Sub

    Private Sub grdImgCCR_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles grdImgCCR.RowDataBound
        If e.Row.RowType = ListItemType.AlternatingItem Or e.Row.RowType = ListItemType.Item Then

            Dim scriptString As String = "javascript:return confirm(""ต้องการลบ ข้อมูลนี้ ?"");"
            Dim imgD As ImageButton = e.Row.Cells(2).FindControl("imgDelFile")
            imgD.Attributes.Add("onClick", scriptString)

        End If
        'If e.Row.RowType = DataControlRowType.DataRow Then
        '    Dim btnExport As Button = TryCast(e.Row.FindControl("imgDelFile"), Button)

        '    If btnExport IsNot Nothing Then
        '        CType(Me.Page.Master.FindControl("imgDelFile"), ScriptManager).RegisterPostBackControl(btnExport)
        '    End If
        'End If

        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#d0e8ff';")
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;")

        End If
    End Sub



    Private Sub grdCCR_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles grdCCR.RowDataBound
        If e.Row.RowType = ListItemType.AlternatingItem Or e.Row.RowType = ListItemType.Item Then
            Dim scriptString As String = "javascript:return confirm(""ต้องการลบ ข้อมูลนี้ ?"");"
            Dim imgD As ImageButton = e.Row.Cells(4).FindControl("imgDel")
            imgD.Attributes.Add("onClick", scriptString)

        End If
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#d0e8ff';")
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;")
        End If
    End Sub
    Private Sub cmdUpImgCCR_Click(sender As Object, e As EventArgs) Handles cmdUpImgCCR.Click
        UploadFiles(FileUploadCCR2, StrNull2Zero(hdCCRUID.Value), "CCR")
        LoadCCRImg()
    End Sub

    Private Sub UploadFiles(ByVal Fileupload As Object, REFUID As Integer, sCode As String)
        Dim SEQNO, CCRUID As String
        Dim sfileName As String = ""
        Dim sFolder As String = ""
        Select Case sCode
            Case "CCR"
                sFolder = "CCR/"
            Case "WAR"
                sFolder = "Warning/"
        End Select
        UploadDirectory = Server.MapPath("imageUploads/" & sFolder)

        If Fileupload.HasFiles Then
            For Each uploadedFile As HttpPostedFile In Fileupload.PostedFiles
                Dim fileExtname As String = Path.GetExtension(uploadedFile.FileName).ToLower()

                'If ctlMd.Media_GetCount(0), 0, StrNull2Zero(hdLocationUID.Value), sCode, REFUID) >= 4 Then
                '    Exit Sub
                'End If

                If fileExtname <> ".jpg" And fileExtname <> ".jpeg" And fileExtname <> ".png" And fileExtname <> ".pdf" Then
                    ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','ไฟล์รูปภาพต้องมีนามสกุล .jpg, .jpeg, .png,.pdf เท่านั้น');", True)
                    Exit Sub
                End If
                If (Fileupload.PostedFile.ContentLength / 1024) > 1024 Then
                    ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','ไฟล์มีขนาดใหญ่เกิน 1024 Kb. ไม่สามารถอัพโหลดได้');", True)
                    Exit Sub
                End If
                CCRUID = REFUID
                SEQNO = ctlMd.Media_GetLastSEQ(0, 0, StrNull2Zero(hdLocationUID.Value), sCode, CCRUID)
                sfileName = Replace(Replace(txtLicenseNo1.Text, ".", ""), "/", "") & "_" & REFUID & "_" & SEQNO.ToString() & fileExtname

                Dim objfile As FileInfo = New FileInfo("imageUploads/" & sFolder & sfileName)
                If objfile.Exists Then
                    objfile.Delete()
                End If
                uploadedFile.SaveAs(System.IO.Path.Combine(UploadDirectory, sfileName))
                ctlMd.Media_Save(0, 0, StrNull2Zero(hdLocationUID.Value), sCode, REFUID, SEQNO, sfileName, Request.Cookies("UserID").Value)
            Next
        End If
    End Sub

    Private Sub ddlProvince_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlProvince.SelectedIndexChanged
        LoadDistrictToDDL()
    End Sub

    Protected Sub cmdAddRisk_Click(sender As Object, e As EventArgs) Handles cmdAddRisk.Click
        If ddlRiskLevel.SelectedValue > 0 Then
            If txtRiskDate.Text = "" Or txtRiskDetail.Text = "" Then
                ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','กรุณาระบุวันที่และรายละเอียดความเสี่ยง');", True)
                Exit Sub
            End If
        End If

        ctlL.LocationRisk_Save(StrNull2Zero(hdLocationUID.Value), ddlRiskLevel.SelectedValue, ConvertStrDate2DBDate(txtRiskDate.Text), txtRiskDetail.Text, StrNull2Zero(Request.Cookies("UserID").Value))

        ctlU.User_GenLogfile(Request.Cookies("UserID").Value, ACTTYPE_UPD, "Locations", "Update การเฝ้าระวัง/ความเสี่ยง", "[LocationUID=" & hdLocationUID.Value & "][Level=" & ddlRiskLevel.SelectedValue & "][Date=" & txtRiskDate.Text & "][Desc=" & txtRiskDetail.Text & "]", Environment.MachineName, GetIPAddress())

        LoadRisk()
        txtRiskDetail.Text = ""
    End Sub
    Private Sub grdRisk_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grdRisk.RowCommand
        If TypeOf e.CommandSource Is WebControls.ImageButton Then
            Dim ButtonPressed As WebControls.ImageButton = e.CommandSource
            Select Case ButtonPressed.ID
                Case "imgDel"
                    ctlL.Risk_Delete(e.CommandArgument)
                    LoadRisk()
            End Select
        End If
    End Sub

    Private Sub grdRisk_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles grdRisk.RowDataBound
        If e.Row.RowType = ListItemType.AlternatingItem Or e.Row.RowType = ListItemType.Item Then
            Dim scriptString As String = "javascript:return confirm(""ต้องการลบ ข้อมูลนี้ ?"");"
            Dim imgD As ImageButton = e.Row.Cells(3).FindControl("imgDel")
            imgD.Attributes.Add("onClick", scriptString)

        End If
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#d0e8ff';")
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;")
        End If
    End Sub


    Protected Sub cmdAddWarning_Click(sender As Object, e As EventArgs) Handles cmdAddWarning.Click
        If txtWarnSeqNo.Text = "" Or txtWarningDate.Text = "" Then
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','กรุณป้อน ครั้งที่ วันที่ และ รายละเอียดประเด็น ให้ครบถ้วนก่อน');", True)
            Exit Sub
        End If

        hdWarningUID.Value = 0

        ctlL.LocationWarning_Save(StrNull2Zero(hdLocationUID.Value), StrNull2Zero(txtWarnSeqNo.Text), ConvertStrDate2DBDate(txtWarningDate.Text), ddlWarningType.SelectedValue, txtWarningNo.Text, txtWarningDesc.Text, txtWarnRemark.Text, StrNull2Zero(Request.Cookies("UserID").Value))

        UploadDirectory = Server.MapPath("~/imageUploads/Warning/")

        Dim SEQNO, WarningUID As String
        Dim sfileName As String = ""

        WarningUID = ctlL.LocationWarning_GetUID(hdLocationUID.Value)

        If FileUploadWarning.HasFiles Then
            For Each uploadedFile As HttpPostedFile In FileUploadWarning.PostedFiles
                Dim fileExtname As String = Path.GetExtension(uploadedFile.FileName).ToLower()

                'If ctlM.Media_GetCount(0), 0, StrNull2Zero(hdLocationUID.Value), "WAR", StrNull2Long(SoftID)) >= 4 Then
                '    Exit Sub
                'End If
                If fileExtname <> ".jpg" And fileExtname <> ".jpeg" And fileExtname <> ".png" And fileExtname <> ".pdf" Then
                    ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','ไฟล์รูปภาพต้องมีนามสกุล .jpg, .jpeg, .png ,.pdf เท่านั้น');", True)
                    Exit Sub
                End If
                If (FileUploadWarning.PostedFile.ContentLength / 1024) > 1024 Then
                    ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','ไฟล์มีขนาดใหญ่เกิน 1024 Kb. ไม่สามารถอัพโหลดได้');", True)
                    Exit Sub
                End If


                SEQNO = ctlMd.Media_GetLastSEQ(0, 0, StrNull2Zero(hdLocationUID.Value), "WAR", WarningUID)
                sfileName = Replace(Replace(txtLicenseNo1.Text, ".", ""), "/", "") & "_" & WarningUID & "_" & SEQNO.ToString() & fileExtname

                Dim objfile As FileInfo = New FileInfo(UploadDirectory & sfileName)
                If objfile.Exists Then
                    objfile.Delete()
                End If
                uploadedFile.SaveAs(System.IO.Path.Combine(UploadDirectory, sfileName))
                ctlMd.Media_Save(0, 0, hdLocationUID.Value, "WAR", WarningUID, SEQNO, sfileName, Request.Cookies("UserID").Value)
            Next
        End If

        LoadWarning()

        txtWarnSeqNo.Text = StrNull2Zero(txtWarnSeqNo.Text) + 1
        txtWarningDate.Text = ""
        txtWarningDesc.Text = ""
        txtWarnRemark.Text = ""
    End Sub
    Private Sub grdWarning_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grdWarning.RowCommand
        If TypeOf e.CommandSource Is WebControls.ImageButton Then
            Dim ButtonPressed As WebControls.ImageButton = e.CommandSource
            Select Case ButtonPressed.ID
                Case "imgWarning"
                    Dim fPath As String = "imageUploads/Warning/"
                    hdWarningUID.Value = e.CommandArgument()
                    LoadWarningImg()
                    ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalUploadWarning(this,'" + e.CommandArgument() + "');", True)
                Case "imgDel"
                    ctlL.Warning_Delete(e.CommandArgument)
                    LoadWarning()
            End Select
        End If
    End Sub
    Private Sub LoadWarningImg()
        dt = ctlMd.Media_Get(0, StrNull2Zero(hdLocationUID.Value), "WAR", StrNull2Zero(hdWarningUID.Value))
        grdImgWarning.DataSource = dt
        grdImgWarning.DataBind()

        'For i = 0 To dt.Rows.Count - 1

        'Next

        lblImgWarning.Visible = False
        cmdUpImgWarning.Enabled = True

    End Sub

    Private Sub grdImgWarning_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grdImgWarning.RowCommand
        If TypeOf e.CommandSource Is WebControls.ImageButton Then
            Dim ButtonPressed As WebControls.ImageButton = e.CommandSource
            Select Case ButtonPressed.ID
                Case "imgView"
                    PreviewPicture("", "", e.CommandArgument())
                Case "imgDelFile"
                    DeleteImage(e.CommandArgument)
                    ctlMd.Media_Delete(e.CommandArgument)
                    LoadWarningImg()
            End Select
        End If
    End Sub

    Private Sub grdImgWarning_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles grdImgWarning.RowDataBound
        If e.Row.RowType = ListItemType.AlternatingItem Or e.Row.RowType = ListItemType.Item Then

            Dim scriptString As String = "javascript:return confirm(""ต้องการลบ ข้อมูลนี้ ?"");"
            Dim imgD As ImageButton = e.Row.Cells(2).FindControl("imgDelFile")
            imgD.Attributes.Add("onClick", scriptString)

        End If
        'If e.Row.RowType = DataControlRowType.DataRow Then
        '    Dim btnExport As Button = TryCast(e.Row.FindControl("imgDelFile"), Button)

        '    If btnExport IsNot Nothing Then
        '        CType(Me.Page.Master.FindControl("imgDelFile"), ScriptManager).RegisterPostBackControl(btnExport)
        '    End If
        'End If

        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#d0e8ff';")
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;")

        End If
    End Sub

    Private Sub grdWarning_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles grdWarning.RowDataBound
        If e.Row.RowType = ListItemType.AlternatingItem Or e.Row.RowType = ListItemType.Item Then
            Dim scriptString As String = "javascript:return confirm(""ต้องการลบ ข้อมูลนี้ ?"");"
            Dim imgD As ImageButton = e.Row.Cells(6).FindControl("imgDel")
            imgD.Attributes.Add("onClick", scriptString)

        End If
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#d0e8ff';")
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;")
        End If
    End Sub
    Private Sub cmdUpImgWarning_Click(sender As Object, e As EventArgs) Handles cmdUpImgWarning.Click
        UploadFiles(FileUploadWarning2, StrNull2Zero(hdWarningUID.Value), "WAR")
        LoadWarningImg()
    End Sub
End Class