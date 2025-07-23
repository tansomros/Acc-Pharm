Imports System
Imports System.IO
Imports System.Web.UI
Imports BigLion
'Imports DevExpress.Web
Public Class Location
    Inherits System.Web.UI.Page
    Dim ctlU As New UserController
    Dim ctlL As New LocationController
    Dim dt As New DataTable
    'Dim ds As New DataSet
    'Dim objEn As New CryptographyEngine
    Dim ctlPs As New PharmacistController
    Dim ctlM As New MediaController
    Private UploadDirectory As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsNothing(Request.Cookies("CPA")) Then
            Response.Redirect("Default.aspx")
        End If
        If Not IsPostBack Then
            cmdApprove.Visible = False
            cmdDelete.Visible = False

            pnPharmacist.Visible = False


            hdLocationUID.Value = Request.Cookies("LoginLocationUID").Value

            LoadProvinceToDDL()
            'LoadBankToDDL()
            LoadLocationGroupToDDL()
            LoadLocationChainToDDL()
            LoadLocationTypeToCheckList()

            'GenLocationNumber()

            If Not Request("lid") = Nothing Then
                EditLocationData(Request("lid"), Request("id"))
                'UploadDirectory = Server.MapPath("~/imageUploads/" & hdLocationUID.Value & "/Locations/")
                UploadDirectory = DirectoryPath & "imageUploads\" & hdLocationUID.Value & "\Locations\"

                If Not Directory.Exists(UploadDirectory) Then
                    Directory.CreateDirectory(UploadDirectory)
                End If
                StatusUpload()

                CheckStatusAssessment()

            End If


            If Convert.ToInt32(Request.Cookies("ROLE_ID").Value) >= 2 Then
                cmdApprove.Visible = True
                cmdSave.Visible = False
                grdPharmacist.Columns(5).Visible = False
                grdSoftware.Columns(4).Visible = False
            End If
        End If

        txtStartYear.Attributes.Add("OnKeyPress", "return AllowOnlyIntegers();")
        txtZipCode.Attributes.Add("OnKeyPress", "return AllowOnlyIntegers();")
        txtArea1.Attributes.Add("OnKeyPress", "return AllowOnlyIntegers();")
        txtArea2.Attributes.Add("OnKeyPress", "return AllowOnlyDouble();")
        txtPLicense.Attributes.Add("OnKeyPress", "return AllowOnlyIntegers();")
        txtEmail.Attributes.Add("OnKeyPress", "return NotAllowThai();")
    End Sub

    Private Sub CheckStatusAssessment()
        Dim iStatus As Integer = 0
        Dim ctlA As New AssessmentController
        dt = ctlA.Assessment_GetStatus(StrNull2Long(Request("id")))
        If dt.Rows.Count > 0 Then
            iStatus = DBNull2Zero(dt.Rows(0)("StatusID"))

            If iStatus >= 1 And iStatus <= 4 Then ' Processing
                'If Convert.ToInt32(Request.Cookies("ROLE_ID").Value) = 1 Then
                '    btnAsmLocation.Visible = True
                '    btnAsmGPP.Visible = True
                '    btnAsmQA.Visible = True
                '    cmdAddFile.Enabled = True
                '    cmdAddSlip.Enabled = True
                '    FileUpload1.Enabled = True
                '    FileUploadA.Enabled = True
                'End If
            ElseIf iStatus >= 5 And iStatus <= 7 Then 'Passed
                If Convert.ToInt32(Request.Cookies("ROLE_ID").Value) = 1 Then
                    cmdSave.Visible = False
                    cmdApprove.Visible = False
                    cmdDelete.Visible = False

                    FileUploadSW.Enabled = False
                    cmdSaveSoftware.Enabled = False
                    cmdClearSoftware.Enabled = False
                    grdSoftware.Columns(4).Visible = False

                    FileUpload1.Enabled = False
                    FileUploadA.Enabled = False

                    cmdUpImg.Visible = False
                    cmdUpImgSW.Visible = False

                    grdImg.Columns(3).Visible = False
                    grdImgSW.Columns(3).Visible = False
                    lblImgSW.Visible = True
                    lblImg.Visible = True
                    lblImgSW.Text = "สถานะปัจจุบันไม่สามารถออัพโหลดหรือแก้ไขรูปภาพได้อีก"
                    lblImg.Text = "สถานะปัจจุบันไม่สามารถออัพโหลดหรือแก้ไขรูปภาพได้อีก"
                End If
            ElseIf iStatus = 8 Then 'ยกเลิก

            End If
        End If

    End Sub


    'Protected Sub UploadControl_FileUploadComplete(ByVal sender As Object, ByVal e As FileUploadCompleteEventArgs)
    '    Dim resultExtension As String = Path.GetExtension(e.UploadedFile.FileName)
    '    Dim resultFileName As String = Path.ChangeExtension(Path.GetRandomFileName(), resultExtension)
    '    Dim resultFileUrl As String = UploadDirectory & sender.id.ToString() & resultFileName
    '    Dim  resultFilePath As String = MapPath(resultFileUrl)
    '    e.UploadedFile.SaveAs(resultFilePath)

    '    UploadingUtils.RemoveFileWithDelay(resultFileName, resultFilePath, 5)

    '    Dim name As String = e.UploadedFile.FileName
    '    Dim url As String = ResolveClientUrl(resultFileUrl)
    '    Dim sizeInKilobytes As Long = e.UploadedFile.ContentLength / 1024
    '    Dim sizeText As String = sizeInKilobytes.ToString() & " KB"
    '    e.CallbackData = name & "|" & url & "|" & sizeText
    'End Sub

    Private Sub LoadActivityQA()
        Dim ctlR As New RequestController
        dt = ctlR.Request_GetActivityQA(Request("id"))
        txtQ10.Text = String.Concat(dt.Rows(0)("ActivityQA"))
    End Sub
    Private Sub LoadPharmacist()
        Dim dtP As New DataTable
        dtP = ctlPs.Pharmacist_Get(hdLocationUID.Value)
        If dtP.Rows.Count > 0 Then
            With grdPharmacist
                .Visible = True
                .DataSource = dtP
                .DataBind()
            End With
        Else
            grdPharmacist.Visible = False
        End If
        dtP = Nothing
    End Sub
    Private Sub LoadProvinceToDDL()
        Dim ctlbase As New MasterController
        dt = ctlbase.Province_Get
        If dt.Rows.Count > 0 Then
            With ddlProvince
                .Enabled = True
                .DataSource = dt
                .DataTextField = "ProvinceName"
                .DataValueField = "ProvinceID"
                .DataBind()
                .SelectedIndex = 0
            End With
        End If
        dt = Nothing
    End Sub

    'Private Sub LoadBankToDDL()
    '    Dim ctlbase As New MasterController
    '    dt = ctlbase.LoadBank
    '    If dt.Rows.Count > 0 Then
    '        With ddlBank
    '            .Enabled = True
    '            .DataSource = dt
    '            .DataTextField = "BankName"
    '            .DataValueField = "BankID"
    '            .DataBind()
    '            .SelectedIndex = 0
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

    Private Sub EditLocationData(ByVal pID As Integer, ByVal requid As Long)
        Dim dtL As New DataTable

        dtL = ctlL.Location_GetByRequestUID(pID, requid)
        If dtL.Rows.Count > 0 Then
            With dtL.Rows(0)
                hdLocationUID.Value = .Item("UID")

                txtLocationName.Text = String.Concat(.Item("LocationName"))
                txtAddressNo.Text = String.Concat(.Item("AddressNo"))
                txtSubdistrict.Text = String.Concat(.Item("Subdistrict"))
                txtDistrict.Text = String.Concat(.Item("District"))
                ddlProvince.SelectedValue = String.Concat(.Item("ProvinceID"))
                txtZipCode.Text = String.Concat(.Item("ZipCode"))

                txtTel.Text = String.Concat(.Item("Tel"))
                txtEmail.Text = String.Concat(.Item("EMail"))
                txtLineID.Text = String.Concat(.Item("LineID"))
                txtFacebook.Text = String.Concat(.Item("Facebook"))

                'txtLat.Text = String.Concat(.Item("Lat"))
                'txtLng.Text = String.Concat(.Item("Lng"))
                If String.Concat(.Item("Lng")) <> "" Then
                    txtLat.Text = String.Concat(.Item("Lat")) & "," & String.Concat(.Item("Lng"))
                Else
                    txtLat.Text = String.Concat(.Item("Lat"))
                End If

                txtWorkTime.Text = String.Concat(.Item("WorkTime"))
                txtStartYear.Text = String.Concat(.Item("StartYear"))

                txtLicenseNo1.Text = String.Concat(.Item("LicenseNo1"))
                txtLicenseNo2.Text = String.Concat(.Item("LicenseNo2"))
                txtLicenseNo3.Text = String.Concat(.Item("LicenseNo3"))
                txtLicensee.Text = String.Concat(.Item("Licensee"))
                optLicenseeType.SelectedValue = String.Concat(.Item("LicenseeType"))

                If String.Concat(.Item("LocationAsmStatus")) = "Y" Then
                    chkStatus.Checked = True
                Else
                    chkStatus.Checked = False
                End If


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

                If String.Concat(.Item("isSoftware")) = "Y" Then
                    chkIsSoftware.Checked = True
                Else
                    chkIsSoftware.Checked = False
                End If

                LoadActivityQA()

                'txtAccNo.Text = String.Concat(.Item("AccNo"))
                'txtAccName.Text = String.Concat(.Item("AccName"))
                'ddlBank.SelectedValue = String.Concat(.Item("BankID"))
                'txtBrunch.Text = String.Concat(.Item("BankBrunch"))
                'optBankType.SelectedValue = String.Concat(.Item("BankType"))
                'txtCardID.Text = String.Concat(dtE.Rows(0)("CardID"))

                'chkStatus.Checked = CBool(.Item("isPublic"))

                LoadPharmacist()
                LoadSoftware()
            End With

            'chkProject.ClearSelection()
            'Dim dtLP As New DataTable
            'dtLP = ctlUser.LocationProject_GetByLocationID(lblID.Text)

            'If dtLP.Rows.Count > 0 Then
            '    For i = 0 To dtLP.Rows.Count - 1
            '        Select Case dtLP.Rows(i)("ProjectID")
            '            Case "1"
            '                chkProject.Items(0).Selected = True
            '            Case "2"
            '                chkProject.Items(1).Selected = True
            '            Case "3"
            '                chkProject.Items(2).Selected = True
            '        End Select
            '    Next
            'End If
            'dtLP = Nothing

        End If
        dtL = Nothing
    End Sub


    Private Sub ClearData()
        txtLocationName.Text = ""
        txtAddressNo.Text = ""
        ddlProvince.SelectedIndex = 1
        Me.txtZipCode.Text = ""

        txtTel.Text = ""
        txtLineID.Text = ""
        'GenLocationNumber()
    End Sub
    Function Check_Email(str As String) As Boolean
        Return Regex.IsMatch(str, "\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*")
    End Function

    Protected Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click

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
        If txtSubdistrict.Text = "" Then
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','กรุณาระบุแขวง/ตำบล');", True)
            Exit Sub
        End If
        If txtDistrict.Text = "" Then
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
        If txtLat.Text = "" Then
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','กรุณาระบุละติจูด-ลองจิจูด');", True)
            Exit Sub
        End If
        'If txtArea1.Text = "" Or txtArea2.Text = "" Then
        '    ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','กรุณาระบุจำนวนคูหา หรือ พื้นที่ร้าน');", True)
        '    Exit Sub
        'End If

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
                ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','กรุณาระบุละติจูด/ลองจิจูด เป็นรูปแบบองศาทศนิยมเท่านั้น ');", True)
                Exit Sub
            End If
        End If


        Dim isSoftware As String
        If chkIsSoftware.Checked = True Then
            isSoftware = "Y"
        Else
            isSoftware = "N"
        End If

        ctlL.Location_UpdateByLocation(hdLocationUID.Value, txtLicenseNo1.Text, txtLicenseNo1.Text, txtLocationName.Text, txtAddressNo.Text, txtMoo.Text, txtRoad.Text, txtSubdistrict.Text, txtDistrict.Text, ddlProvince.SelectedValue, txtZipCode.Text, txtTel.Text, txtEmail.Text, txtLineID.Text, txtWorkTime.Text, sLat, sLng, txtFacebook.Text, StrNull2Zero(txtStartYear.Text), txtLicenseNo1.Text, txtLicenseNo2.Text, txtLicenseNo3.Text, txtLicensee.Text, StrNull2Zero(optLicenseeType.SelectedValue), StrNull2Zero(txtArea1.Text), StrNull2Double(txtArea2.Text), StrNull2Zero(ddlGroup.SelectedValue), StrNull2Zero(ddlChain.SelectedValue), "A", Request.Cookies("UserID").Value)

        ctlU.User_GenLogfile(Request.Cookies("UserID").Value, ACTTYPE_UPD, "Locations", "แก้ไขข้อมูลร้านยา:Service", "[LocationUID=" & hdLocationUID.Value & "]", Environment.MachineName, GetIPAddress())

        ctlL.LocationTypeDetail_Delete(StrNull2Zero(hdLocationUID.Value))
        For i = 0 To chkLocationType.Items.Count - 1
            If chkLocationType.Items(i).Selected Then
                ctlL.LocationTypeDetail_Save(StrNull2Zero(hdLocationUID.Value), chkLocationType.Items(i).Value)
            End If
        Next

        Dim ctlR As New RequestController
        ctlR.Request_UpdateActivityQA(Request("id"), txtQ10.Text)

        ctlL.Location_UpdateIsSoftware(hdLocationUID.Value, isSoftware)

        'ctlR.Request_UpdateLocationAsmStatus(Request("id"))

        Assessment_Save(StrNull2Long(Request("id")))

        'ClearData()
        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalSuccess(this,'Success','บันทึกข้อมูลเรียบร้อย');", True)

    End Sub
    Private Sub Assessment_Save(RequestUID As Long)
        Dim ctlA As New AssessmentController
        ctlA.Assessment_Save(RequestUID, StrNull2Zero(hdLocationUID.Value), Request.Cookies("UserID").Value)
    End Sub

    Private Sub UploadFiles(ByVal Fileupload As Object, REFUID As Integer, sCode As String)
        Dim SEQNO As String
        Dim sfileName As String = ""
        'UploadDirectory = Server.MapPath("imageUploads/" & hdLocationUID.Value & "/Locations/")
        UploadDirectory = DirectoryPath & "imageUploads\" & hdLocationUID.Value & "\Locations\"

        If Fileupload.HasFiles Then
            For Each uploadedFile As HttpPostedFile In Fileupload.PostedFiles
                Dim fileExtname As String = Path.GetExtension(uploadedFile.FileName).ToLower()

                If ctlM.Media_GetCount(StrNull2Zero(Request("id")), 0, StrNull2Zero(hdLocationUID.Value), sCode, REFUID) >= 4 Then
                    Exit Sub
                End If

                If fileExtname <> ".jpg" And fileExtname <> ".jpeg" And fileExtname <> ".png" Then
                    ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','ไฟล์รูปภาพต้องมีนามสกุล .jpg, .jpeg, .png เท่านั้น');", True)
                    Exit Sub
                End If
                If (Fileupload.PostedFile.ContentLength / 1024) > 1024 Then
                    ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','ไฟล์มีขนาดใหญ่เกิน 1024 Kb. ไม่สามารถอัพโหลดได้');", True)
                    Exit Sub
                End If

                SEQNO = ctlM.Media_GetLastSEQ(StrNull2Zero(Request("id")), 0, StrNull2Zero(hdLocationUID.Value), sCode, REFUID)
                sfileName = sCode & "_" & REFUID & "_" & SEQNO.ToString() & fileExtname

                Dim objfile As FileInfo = New FileInfo("imageUploads/" & hdLocationUID.Value & "/Locations/" & sfileName)
                If objfile.Exists Then
                    objfile.Delete()
                End If
                uploadedFile.SaveAs(System.IO.Path.Combine(UploadDirectory, sfileName))
                ctlM.Media_Save(StrNull2Zero(Request("id")), 0, StrNull2Zero(hdLocationUID.Value), sCode, REFUID, SEQNO, sfileName, Request.Cookies("UserID").Value)
            Next
        End If
    End Sub
    Private Sub ddlGroup_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlGroup.SelectedIndexChanged
        If ddlGroup.SelectedValue = 2 Then
            ddlChain.Enabled = True
        Else
            ddlChain.Enabled = False
        End If
    End Sub

    Protected Sub cmdAddPharmacist_Click(sender As Object, e As EventArgs) Handles cmdAddPharmacist.Click
        If txtPName.Text = "" Or txtPLicense.Text = "" Or txtPTime.Text = "" Then
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','กรุณป้อนข้อมูลให้ครบถ้วน');", True)
            Exit Sub
        End If

        If StrNull2Zero(hdPharmacistUID.Value) = 0 Then
            ctlPs.Pharmacist_Add(txtPName.Text, txtPLicense.Text, ddlPType.SelectedValue, txtPTime.Text, StrNull2Zero(hdLocationUID.Value), Request.Cookies("UserID").Value)
            ctlU.User_GenLogfile(Request.Cookies("UserID").Value, ACTTYPE_ADD, "Pharmacists", "เพิ่มรายชื่อเภสัชกรประจำร้านยา :" & txtPName.Text, "เพิ่มแบบทีละคน:service", Environment.MachineName, GetIPAddress())
        Else
            ctlPs.Pharmacist_Update(StrNull2Zero(hdPharmacistUID.Value), txtPName.Text, txtPLicense.Text, ddlPType.SelectedValue, txtPTime.Text, StrNull2Zero(hdLocationUID.Value), Request.Cookies("UserID").Value)
            ctlU.User_GenLogfile(Request.Cookies("UserID").Value, ACTTYPE_UPD, "Pharmacists", "แก้ไขชื่อเภสัชกรประจำร้านยา :" & txtPName.Text, "เพิ่มแบบทีละคน:service", Environment.MachineName, GetIPAddress())

        End If

        LoadPharmacist()
        ClearPharmacistData()
    End Sub
    Private Sub ClearPharmacistData()
        hdPharmacistUID.Value = "0"
        txtPName.Text = ""
        txtPLicense.Text = ""
        txtPTime.Text = ""
        ddlPType.SelectedIndex = 0
        cmdAddPharmacist.Text = "เพิ่ม"
    End Sub
    Private Sub grdPharmacist_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdPharmacist.RowCommand
        If TypeOf e.CommandSource Is WebControls.LinkButton Then
            Dim ButtonPressed As WebControls.LinkButton = e.CommandSource
            Select Case ButtonPressed.ID
                Case "imgEdit"
                    EditPharmacistData(e.CommandArgument())
                Case "imgDel"
                    If ctlPs.Pharmacist_Delete(e.CommandArgument) Then
                        ctlU.User_GenLogfile(Request.Cookies("UserID").Value, "DEL", "Pharmacists", "ลบเภสัชกรประจำร้านยา :" & e.CommandArgument, "service", Environment.MachineName, GetIPAddress())
                        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalSuccess(this,'Success','ลบข้อมูลเรียบร้อย');", True)
                    Else
                        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningAlert(this,'ผลการตรวจสอบ','ไม่สามารถลบข้อมูลได้ กรุณาตรวจสอบและลองใหม่อีกครั้ง');", True)
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
                txtPTime.Text = String.Concat(.Item("WorkTime"))
                ddlPType.SelectedValue = String.Concat(.Item("WorkType"))
                cmdAddPharmacist.Text = "บันทึก"
            End With

        End If

        dt = Nothing
    End Sub

    Protected Sub cmdSaveSoftware_Click(sender As Object, e As EventArgs) Handles cmdSaveSoftware.Click
        If txtSname.Text = "" Or txtSdesc.Text = "" Then
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','กรุณป้อนข้อมูลให้ครบถ้วนก่อน');", True)
            Exit Sub
        End If

        Dim SEQNO, SoftID As String
        Dim sfileName As String = ""
        'UploadDirectory = Server.MapPath("~/imageUploads/" & hdLocationUID.Value & "/Locations/")
        UploadDirectory = DirectoryPath & "imageUploads\" & hdLocationUID.Value & "\Locations\"
        If Not Directory.Exists(UploadDirectory) Then
            Directory.CreateDirectory(UploadDirectory)
        End If
        ctlL.LocationSoftware_Save(StrNull2Long(hdSoftwareUID.Value), hdLocationUID.Value, txtSname.Text, txtSdesc.Text, Request.Cookies("UserID").Value)
        If StrNull2Long(hdSoftwareUID.Value) = 0 Then
            SoftID = ctlL.LocationSoftware_GetLastUID(hdLocationUID.Value).ToString
        Else
            SoftID = hdSoftwareUID.Value
        End If

        If FileUploadA.HasFiles Then
            For Each uploadedFile As HttpPostedFile In FileUploadA.PostedFiles
                Dim fileExtname As String = Path.GetExtension(uploadedFile.FileName).ToLower()

                If ctlM.Media_GetCount(StrNull2Zero(Request("id")), 0, StrNull2Zero(hdLocationUID.Value), "S", StrNull2Long(SoftID)) >= 4 Then
                    Exit Sub
                End If
                If fileExtname <> ".jpg" And fileExtname <> ".jpeg" And fileExtname <> ".png" Then
                    ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','ไฟล์รูปภาพต้องมีนามสกุล .jpg, .jpeg, .png เท่านั้น');", True)
                    Exit Sub
                End If
                If (FileUploadA.PostedFile.ContentLength / 1024) > 1024 Then
                    ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','ไฟล์มีขนาดใหญ่เกิน 1024 Kb. ไม่สามารถอัพโหลดได้');", True)
                    Exit Sub
                End If


                SEQNO = ctlM.Media_GetLastSEQ(StrNull2Zero(Request("id")), 0, StrNull2Zero(hdLocationUID.Value), "S", SoftID)
                sfileName = "S_" & SoftID & "_" & SEQNO.ToString() & fileExtname

                Dim objfile As FileInfo = New FileInfo(UploadDirectory & sfileName)
                If objfile.Exists Then
                    objfile.Delete()
                End If
                uploadedFile.SaveAs(System.IO.Path.Combine(UploadDirectory, sfileName))
                ctlM.Media_Save(StrNull2Zero(Request("id")), 0, hdLocationUID.Value, "S", SoftID, SEQNO, sfileName, Request.Cookies("UserID").Value)
            Next
        End If
        hdSoftwareUID.Value = ""
        txtSname.Text = ""
        txtSdesc.Text = ""
        LoadSoftware()
    End Sub
    Private Sub LoadSoftware()
        Dim dtS As New DataTable
        dtS = ctlL.LocationSoftware_Get(hdLocationUID.Value)
        If dtS.Rows.Count > 0 Then
            With grdSoftware
                .Visible = True
                .DataSource = dtS
                .DataBind()
            End With
        Else
            grdSoftware.Visible = False
        End If
        dtS = Nothing
    End Sub
    Private Sub EditSoftwareData(ByVal pID As String)
        txtSname.Text = ""
        txtSdesc.Text = ""

        dt = ctlL.LocationSoftware_GetByUID(pID)
        If dt.Rows.Count > 0 Then
            With dt.Rows(0)
                hdSoftwareUID.Value = .Item("UID")
                txtSname.Text = String.Concat(.Item("SoftwareName"))
                txtSdesc.Text = String.Concat(.Item("Descriptions"))
                cmdSaveSoftware.Text = "บันทึก"
            End With
        End If

        dt = Nothing
    End Sub

    Private Sub grdSoftware_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grdSoftware.RowCommand
        If TypeOf e.CommandSource Is WebControls.LinkButton Then
            Dim ButtonPressed As WebControls.LinkButton = e.CommandSource
            Select Case ButtonPressed.ID
                Case "imgEdit_SW"
                    EditSoftwareData(e.CommandArgument())
                Case "imgFileSW"
                    Dim fPath As String = "imageUploads/" & hdLocationUID.Value & "/Locations/"
                    hdSWUID.Value = e.CommandArgument()
                    LoadSoftwareImg()
                    ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalUploadSW(this,'" + e.CommandArgument() + "');", True)

                Case "imgDel_SW"
                    If ctlL.LocationSoftware_Delete(e.CommandArgument) Then
                        DeleteImageByGroup("S", e.CommandArgument)
                        'ctlU.User_GenLogfile(Request.Cookies("UserID").value, "DEL", "Pharmacists", "ลบเภสัชกรประจำร้านยา :" & e.CommandArgument, "")
                        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalSuccess(this,'Success','ลบข้อมูลเรียบร้อย');", True)
                    Else
                        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningAlert(this,'ผลการตรวจสอบ','ไม่สามารถลบข้อมูลได้ กรุณาตรวจสอบและลองใหม่อีกครั้ง');", True)
                    End If
                    LoadSoftware()
            End Select
        End If
    End Sub

    Private Sub DeleteImageByGroup(ImgGroup As String, RefUID As String)
        dt = ctlM.Media_GetImagePath(Request("id"), hdLocationUID.Value, ImgGroup, RefUID)
        If dt.Rows.Count > 0 Then
            Dim sPath As String = ""
            Select Case ImgGroup
                Case "S", "L", "A", "M"
                    sPath = "\Locations\"
                Case "G"
                    sPath = "\GPP\"
                Case "P", "R", "Q"
                    sPath = "\QA\"
            End Select

            For i = 0 To dt.Rows.Count - 1
                sPath = ""
                Dim objfile As FileInfo = New FileInfo(DirectoryPath & "imageUploads\" & hdLocationUID.Value & "\Locations\" & sPath & dt.Rows(0)("FilePath"))

                If objfile.Exists Then
                    objfile.Delete()
                End If
            Next
        End If
    End Sub
    Private Sub DeleteImage(MediaUID As Integer)
        dt = ctlM.Media_GetByID(MediaUID)
        If dt.Rows.Count > 0 Then
            Dim sPath As String = ""
            Select Case dt.Rows(0)("ImageGroup")
                Case "S", "L", "A", "M"
                    sPath = "\Locations\"
                Case "G"
                    sPath = "\GPP\"
                Case "P", "R", "Q"
                    sPath = "\QA\"
            End Select

            Dim objfile As FileInfo = New FileInfo(DirectoryPath & "imageUploads\" & hdLocationUID.Value & "\Locations\" & sPath & dt.Rows(0)("FilePath"))
            If objfile.Exists Then
                    objfile.Delete()
                End If

        End If
    End Sub

    Private Sub grdSoftware_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles grdSoftware.RowDataBound
        If e.Row.RowType = ListItemType.AlternatingItem Or e.Row.RowType = ListItemType.Item Then

            Dim scriptString As String = "javascript: Return confirm(""ต้องการลบ ข้อมูลนี้ ?"");"
            Dim imgD As LinkButton = e.Row.Cells(4).FindControl("imgDel_SW")
            imgD.Attributes.Add("onClick", scriptString)

        End If

        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#d0e8ff';")
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;")

        End If
    End Sub

    Private Sub PreviewPicture(Fname As String, Desc As String, filePath As String)
        Dim fPath As String = "imageUploads/" & hdLocationUID.Value & "/Locations/"
        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWindow(this,'" + Fname + "','" + Desc + "','" + fPath + filePath + "');", True)
    End Sub
    Private Sub LoadSoftwareImg()
        dt = ctlM.Media_Get(StrNull2Zero(Request("id")), StrNull2Zero(hdLocationUID.Value), "S", StrNull2Zero(hdSWUID.Value))
        grdImgSW.DataSource = dt
        grdImgSW.DataBind()

        If dt.Rows.Count >= 4 Then
            lblImgSW.Text = "ท่านได้อัพโหลดไฟล์ครบ 4 ไฟล์แล้ว ไม่สามารถอัพโหลดเพิ่มได้อีก"
            cmdUpImgSW.Enabled = False
            lblImgSW.Visible = True
        Else
            lblImgSW.Visible = False
            cmdUpImgSW.Enabled = True
        End If

    End Sub

    Private Sub grdImgSW_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grdImgSW.RowCommand
        If TypeOf e.CommandSource Is WebControls.ImageButton Then
            Dim ButtonPressed As WebControls.ImageButton = e.CommandSource
            Select Case ButtonPressed.ID
                Case "imgView"
                    PreviewPicture("", "", e.CommandArgument())
                Case "imgDelFile"
                    DeleteImage(e.CommandArgument)
                    ctlM.Media_Delete(e.CommandArgument)
                    LoadSoftwareImg()
            End Select
        End If
    End Sub

    Private Sub grdImgSW_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles grdImgSW.RowDataBound
        If e.Row.RowType = ListItemType.AlternatingItem Or e.Row.RowType = ListItemType.Item Then

            Dim scriptString As String = "javascript:return confirm(""ต้องการลบ ข้อมูลนี้ ?"");"
            Dim imgD As ImageButton = e.Row.Cells(3).FindControl("imgDelFile")
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

    'Protected Sub cmdUpd1_Click(sender As Object, e As EventArgs) Handles cmdUpd1.Click
    '    UploadFiles(FileUpload1, 1, "")
    'End Sub
    'Protected Sub cmdUpd2_Click(sender As Object, e As EventArgs) Handles cmdUpd2.Click
    '    UploadFiles(FileUpload2, 2, "")
    'End Sub
    'Protected Sub cmdUpd3_Click(sender As Object, e As EventArgs) Handles cmdUpd3.Click
    '    UploadFiles(FileUpload3, 3, "")
    'End Sub
    'Protected Sub cmdUpd4_Click(sender As Object, e As EventArgs) Handles cmdUpd4.Click
    '    UploadFiles(FileUpload4, 4, "")
    'End Sub
    'Protected Sub cmdUpd5_Click(sender As Object, e As EventArgs) Handles cmdUpd5.Click
    '    UploadFiles(FileUpload5, 5, "")
    'End Sub
    'Protected Sub cmdUpd6_Click(sender As Object, e As EventArgs) Handles cmdUpd6.Click
    '    UploadFiles(FileUpload6, 6, "")
    'End Sub
    'Protected Sub cmdUpd7_Click(sender As Object, e As EventArgs) Handles cmdUpd7.Click
    '    UploadFiles(FileUpload7, 7, "")
    'End Sub
    'Protected Sub cmdUpd8_Click(sender As Object, e As EventArgs) Handles cmdUpd8.Click
    '    UploadFiles(FileUpload8, 8, "")
    'End Sub
    'Protected Sub cmdUpd9_Click(sender As Object, e As EventArgs) Handles cmdUpd9.Click
    '    UploadFiles(FileUpload9, 9, "")
    'End Sub
    'Protected Sub cmdUpd10_Click(sender As Object, e As EventArgs) Handles cmdUpd10.Click
    '    UploadFiles(FileUpload10, 10, "")
    'End Sub

    Protected Sub imgQ1_Click(sender As Object, e As EventArgs) Handles imgQ1.Click
        Dim fPath As String = "imageUploads/" & hdLocationUID.Value & "/Locations/"
        hdAccID.Value = "1"
        lblTopic.Text = "การคัดกรองความเสี่ยง เบาหวาน ความดัน"
        LoadImg()
        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalUpload(this,'1');", True)
    End Sub
    Protected Sub imgQ2_Click(sender As Object, e As EventArgs) Handles imgQ2.Click
        Dim fPath As String = "imageUploads/" & hdLocationUID.Value & "/Locations/"
        hdAccID.Value = "2"
        lblTopic.Text = "บริการเลิกสูบบุหรี่"
        LoadImg()
        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalUpload(this,'2');", True)
    End Sub
    Protected Sub imgQ3_Click(sender As Object, e As EventArgs) Handles imgQ3.Click
        Dim fPath As String = "imageUploads/" & hdLocationUID.Value & "/Locations/"
        hdAccID.Value = "3"
        lblTopic.Text = "บริการติดตามการใช้ยาในโรคเรื้อรัง"
        LoadImg()
        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalUpload(this,'3');", True)
    End Sub
    Protected Sub imgQ4_Click(sender As Object, e As EventArgs) Handles imgQ4.Click
        Dim fPath As String = "imageUploads/" & hdLocationUID.Value & "/Locations/"
        hdAccID.Value = "4"
        lblTopic.Text = "บริการเภสัชกรรมทางTelepharmacy"
        LoadImg()
        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalUpload(this,'4');", True)
    End Sub
    Protected Sub imgQ5_Click(sender As Object, e As EventArgs) Handles imgQ5.Click
        Dim fPath As String = "imageUploads/" & hdLocationUID.Value & "/Locations/"
        hdAccID.Value = "5"
        lblTopic.Text = "บริการปรึกษาปัญหาสุขภาพ การใช้ยา"
        LoadImg()
        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalUpload(this,'5');", True)
    End Sub
    Protected Sub imgQ6_Click(sender As Object, e As EventArgs) Handles imgQ6.Click
        Dim fPath As String = "imageUploads/" & hdLocationUID.Value & "/Locations/"
        hdAccID.Value = "6"
        lblTopic.Text = "มี Page ให้ความรู้"
        LoadImg()
        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalUpload(this,'6');", True)
    End Sub
    Protected Sub imgQ7_Click(sender As Object, e As EventArgs) Handles imgQ7.Click
        Dim fPath As String = "imageUploads/" & hdLocationUID.Value & "/Locations/"
        hdAccID.Value = "7"
        lblTopic.Text = "มี Facebook ให้ความรู้"
        LoadImg()
        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalUpload(this,'7');", True)
    End Sub
    Protected Sub imgQ8_Click(sender As Object, e As EventArgs) Handles imgQ8.Click
        Dim fPath As String = "imageUploads/" & hdLocationUID.Value & "/Locations/"
        hdAccID.Value = "8"
        lblTopic.Text = "มี Line OA ของร้าน"
        LoadImg()
        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalUpload(this,'8');", True)
    End Sub
    Protected Sub imgQ9_Click(sender As Object, e As EventArgs) Handles imgQ9.Click
        Dim fPath As String = "imageUploads/" & hdLocationUID.Value & "/Locations/"
        hdAccID.Value = "9"
        lblTopic.Text = "มี Real Time Application"
        LoadImg()
        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalUpload(this,'9');", True)
    End Sub
    Protected Sub imgQ10_Click(sender As Object, e As EventArgs) Handles imgQ10.Click
        Dim fPath As String = "imageUploads/" & hdLocationUID.Value & "/Locations/"
        hdAccID.Value = "10"
        lblTopic.Text = "กิจกรรมอื่นๆ " & txtQ10.Text
        LoadImg()
        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalUpload(this,'10');", True)
    End Sub

    Private Sub LoadImg()
        dt = ctlM.Media_Get(StrNull2Zero(Request("id")), StrNull2Zero(hdLocationUID.Value), "A", StrNull2Long(hdAccID.Value))
        grdImg.DataSource = dt
        grdImg.DataBind()

        If dt.Rows.Count >= 4 Then
            lblImg.Text = "ท่านได้อัพโหลดไฟล์ครบ 4 ไฟล์แล้ว ไม่สามารถอัพโหลดเพิ่มได้อีก"
            cmdUpImg.Enabled = False
            lblImg.Visible = True
        Else
            lblImg.Visible = False
            cmdUpImg.Enabled = True
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
                    ctlM.Media_Delete(e.CommandArgument)
                    LoadImg()
            End Select
        End If
    End Sub

    Private Sub grdImg_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles grdImg.RowDataBound
        If e.Row.RowType = ListItemType.AlternatingItem Or e.Row.RowType = ListItemType.Item Then

            Dim scriptString As String = "javascript:return confirm(""ต้องการลบ ข้อมูลนี้ ?"");"
            Dim imgD As ImageButton = e.Row.Cells(3).FindControl("imgDelFile")
            imgD.Attributes.Add("onClick", scriptString)

        End If
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#d0e8ff';")
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;")
        End If
    End Sub

    Protected Sub cmdUpImg_Click(sender As Object, e As EventArgs) Handles cmdUpImg.Click
        UploadFiles(FileUpload1, StrNull2Zero(hdAccID.Value), "A")
        LoadImg()
        StatusUpload()
    End Sub
    Private Sub StatusUpload()
        lblQ1.Text = ctlM.Media_GetStatus(StrNull2Zero(Request("id")), hdLocationUID.Value, "A", 1)
        lblQ2.Text = ctlM.Media_GetStatus(StrNull2Zero(Request("id")), hdLocationUID.Value, "A", 2)
        lblQ3.Text = ctlM.Media_GetStatus(StrNull2Zero(Request("id")), hdLocationUID.Value, "A", 3)
        lblQ4.Text = ctlM.Media_GetStatus(StrNull2Zero(Request("id")), hdLocationUID.Value, "A", 4)
        lblQ5.Text = ctlM.Media_GetStatus(StrNull2Zero(Request("id")), hdLocationUID.Value, "A", 5)
        lblQ6.Text = ctlM.Media_GetStatus(StrNull2Zero(Request("id")), hdLocationUID.Value, "A", 6)
        lblQ7.Text = ctlM.Media_GetStatus(StrNull2Zero(Request("id")), hdLocationUID.Value, "A", 7)
        lblQ8.Text = ctlM.Media_GetStatus(StrNull2Zero(Request("id")), hdLocationUID.Value, "A", 8)
        lblQ9.Text = ctlM.Media_GetStatus(StrNull2Zero(Request("id")), hdLocationUID.Value, "A", 9)
        lblQ10.Text = ctlM.Media_GetStatus(StrNull2Zero(Request("id")), hdLocationUID.Value, "A", 10)

    End Sub

    Protected Sub cmdClearPharmacist_Click(sender As Object, e As EventArgs) Handles cmdClearPharmacist.Click
        txtPName.Text = ""
        txtPLicense.Text = ""
        txtPTime.Text = ""
        hdPharmacistUID.Value = "0"
    End Sub

    Protected Sub cmdClearSoftware_Click(sender As Object, e As EventArgs) Handles cmdClearSoftware.Click
        txtSname.Text = ""
        txtSdesc.Text = ""
        hdSoftwareUID.Value = "0"
    End Sub

    Private Sub cmdBack_Click(sender As Object, e As EventArgs) Handles cmdBack.Click
        Response.Redirect("RequestDetail?id=" & Request("id"))
    End Sub

    Private Sub cmdUpImgSW_Click(sender As Object, e As EventArgs) Handles cmdUpImgSW.Click
        UploadFiles(FileUploadSW, StrNull2Zero(hdSWUID.Value), "S")
        LoadSoftwareImg()
    End Sub

    Private Sub cmdApprove_Click(sender As Object, e As EventArgs) Handles cmdApprove.Click
        Dim ctlR As New RequestController
        Dim AsmStatus As String = "N"
        If chkStatus.Checked Then
            AsmStatus = "Y"
        Else
            AsmStatus = "N"
        End If
        ctlR.Request_UpdateLocationAsmStatus(StrNull2Zero(hdLocationUID.Value), StrNull2Long(Request("id")), AsmStatus)
        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalSuccess(this,'Success','บันทึกเรียบร้อย');", True)

    End Sub
End Class

