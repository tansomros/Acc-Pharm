Imports System
Imports System.IO
Imports System.Web.UI
Imports BigLion
Public Class PostAudit
    Inherits System.Web.UI.Page
    Dim ctlU As New UserController
    Dim ctlL As New LocationController
    Dim dt As New DataTable
    'Dim ds As New DataSet
    'Dim objEn As New CryptographyEngine
    Dim ctlPs As New PharmacistController
    Dim ctlM As New MediaController
    Private UploadDirectory As String
    Dim ctlR As New RequestController
    Dim ctlA As New AssessmentController

    Dim dtSp As New DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsNothing(Request.Cookies("CPAQA")) Then
            Response.Redirect("Default.aspx")
        End If

        If Not IsPostBack Then
            hdLocationUID.Value = 0
            If Not Request("lid") = Nothing Then
                hdLocationUID.Value = Request("lid")
                LoadLocationDetail(hdLocationUID.Value)
                dtSp = ctlA.RPT_AssessorByLocation(Request("lid"))
                grdSurveyor.DataSource = dtSp
                grdSurveyor.DataBind()
                'CheckStatusAssessment()
            End If

            UploadDirectory = Server.MapPath("~/imageUploads/POST/" & hdLocationUID.Value)

            If Not Directory.Exists(UploadDirectory) Then
                Directory.CreateDirectory(UploadDirectory)
            End If

            If Request("id") = Nothing Or Request("id") = "0" Then
                cmdCreate.Visible = True
                cmdSave.Visible = False
                cmdDelete.Visible = False
                pnQA.Visible = False
                pnCI.Visible = False
                dt = ctlA.Assessment_GetByLocation(hdLocationUID.Value)
                If dt.Rows.Count > 0 Then
                    hdAssessmentUID.Value = dt.Rows(0)("AssessmentUID")
                    txtAsmDate.Text = ConvertStrDate2ShortTH(String.Concat(dt.Rows(0)("AsmDate")))
                End If
            Else
                cmdCreate.Visible = False
                cmdSave.Visible = True
                cmdDelete.Visible = True

                EditPostData(Request("id"))

                If chkAccPharm.Checked = True Then
                    pnQA.Visible = True
                End If
                If chkCI.Checked = True Then
                    pnCI.Visible = True
                End If

                LoadImgQAInform()
                LoadImgQAResponse()
                LoadImgCIInform()
                LoadImgCIResponse()
                LoadImgQAResult()
                LoadImgCIResult()
            End If


            If Request("t") = "del" Then
                ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalSuccess(this,'Success','ลบข้อมูลเรียบร้อย');", True)
            End If

            'If Convert.ToInt32(Request.Cookies("ROLE_ID").Value) >= 2 Then
            '    cmdSave.Visible = True
            '    grdSoftware.Columns(4).Visible = False
            'End If
        End If


        cmdDelete.Attributes.Add("onClick", "javascript:return confirm(""ต้องการลบใช่หรือไม่?"");")

        'txtStartYear.Attributes.Add("OnKeyPress", "return AllowOnlyIntegers();")
        'txtZipCode.Attributes.Add("OnKeyPress", "return AllowOnlyIntegers();")
        'txtArea1.Attributes.Add("OnKeyPress", "return AllowOnlyIntegers();")
        'txtArea2.Attributes.Add("OnKeyPress", "return AllowOnlyDouble();")

        'txtEmail.Attributes.Add("OnKeyPress", "return NotAllowThai();")
    End Sub

    Private Sub LoadLocationDetail(LID As Integer)
        Dim dtL As New DataTable
        dtL = ctlL.Location_GetByUID(LID)

        If dtL.Rows.Count > 0 Then
            With dtL.Rows(0)
                Try
                    lblLicenseNo.Text = String.Concat(.Item("LicenseNo1"))
                    lblLocationName.Text = String.Concat(.Item("LocationName"))
                    lblAddress.Text = String.Concat(.Item("LocationAddress"))
                    lblTel.Text = String.Concat(.Item("tel"))
                    lblAddress.Text = String.Concat(.Item("LocationAddress"))
                    lblProvince.Text = String.Concat(.Item("ProvinceName"))
                    lblAccLicenseNo.Text = String.Concat(.Item("AccLicenseNo"))

                    lblLicenseStatus.Text = DisplayLicenseStatus(String.Concat(.Item("LicenseStatus")))
                    lblStartDate.Text = String.Concat(.Item("LicenseStartDate"))
                    lblExpireDate.Text = String.Concat(.Item("LicenseExpireDate"))
                    lblLicensee.Text = String.Concat(.Item("Licensee"))
                Catch ex As Exception

                End Try
            End With
        End If
    End Sub

    Private Sub EditPostData(ByVal pID As Integer)
        Dim dtL As New DataTable

        dtL = ctlA.PostAudit_GetByUID(pID)
        If dtL.Rows.Count > 0 Then
            With dtL.Rows(0)
                hdPostUID.Value = .Item("UID")
                hdLocationUID.Value = .Item("LocationUID")
                lblCode.Text = String.Concat(.Item("Code"))
                txtAssessee.Text = String.Concat(.Item("Pharmacist"))
                txtPosition.Text = String.Concat(.Item("PositionName"))
                txtAsmDate.Text = ConvertStrDate2ShortTH(String.Concat(.Item("AsmDate")))
                optAudit.SelectedValue = String.Concat(.Item("AsmMethod"))

                If String.Concat(.Item("IsQA")) = "Y" Then
                    chkAccPharm.Checked = True
                End If
                If String.Concat(.Item("IsCI")) = "Y" Then
                    chkCI.Checked = True
                End If


                optQA1.SelectedValue = String.Concat(.Item("QA1"))
                optQA2.SelectedValue = String.Concat(.Item("QA2"))
                optQA3.SelectedValue = String.Concat(.Item("QA3"))
                optQA4.SelectedValue = String.Concat(.Item("QA4"))
                optQA5.SelectedValue = String.Concat(.Item("QA5"))
                'txtQA1.Text = String.Concat(.Item("QA1Remark"))
                'txtQA2.Text = String.Concat(.Item("QA2Remark"))
                'txtQA3.Text = String.Concat(.Item("QA3Remark"))
                'txtQA4.Text = String.Concat(.Item("QA4Remark"))
                'txtQA5.Text = String.Concat(.Item("QA5Remark"))

                optQAResult.SelectedValue = String.Concat(.Item("QAResult"))
                txtQARemark.Text = String.Concat(.Item("QARemark"))

                If String.Concat(.Item("QAInformDate")) <> "" Then
                    txtQAInformDate.Text = ConvertStrDate2ShortTH(String.Concat(.Item("QAInformDate")))
                End If
                If String.Concat(.Item("QAResponseDate")) <> "" Then
                    txtQAresponseDate.Text = ConvertStrDate2ShortTH(String.Concat(.Item("QAResponseDate")))
                End If

                optQAComplete.SelectedValue = String.Concat(.Item("QAComplete"))
                chkQAClose.Checked = ConvertYN2Boolean(String.Concat(.Item("QAClose")))
                If String.Concat(.Item("QACloseDate")) <> "" Then
                    txtQACloseDate.Text = ConvertStrDate2ShortTH(String.Concat(.Item("QACloseDate")))
                End If

                txtQACloseRemark.Text = String.Concat(.Item("QACloseRemark"))

                chkC1.Checked = ConvertYN2Boolean(String.Concat(.Item("CI1")))
                chkC2.Checked = ConvertYN2Boolean(String.Concat(.Item("CI2")))
                chkC3.Checked = ConvertYN2Boolean(String.Concat(.Item("CI3")))
                chkC4.Checked = ConvertYN2Boolean(String.Concat(.Item("CI4")))
                chkC5.Checked = ConvertYN2Boolean(String.Concat(.Item("CI5")))
                chkC6.Checked = ConvertYN2Boolean(String.Concat(.Item("CI6")))
                chkC7.Checked = ConvertYN2Boolean(String.Concat(.Item("CI7")))
                chkC8.Checked = ConvertYN2Boolean(String.Concat(.Item("CI8")))
                chkC9.Checked = ConvertYN2Boolean(String.Concat(.Item("CI9")))
                chkC10.Checked = ConvertYN2Boolean(String.Concat(.Item("CI10")))
                chkC11.Checked = ConvertYN2Boolean(String.Concat(.Item("CI11")))
                chkC12.Checked = ConvertYN2Boolean(String.Concat(.Item("CI12")))

                txtCI1.Text = String.Concat(.Item("CI1Remark"))
                txtCI2.Text = String.Concat(.Item("CI2Remark"))
                txtCI3.Text = String.Concat(.Item("CI3Remark"))
                txtCI4.Text = String.Concat(.Item("CI4Remark"))
                txtCI5.Text = String.Concat(.Item("CI5Remark"))
                txtCI6.Text = String.Concat(.Item("CI6Remark"))
                txtCI7.Text = String.Concat(.Item("CI7Remark"))
                txtCI8.Text = String.Concat(.Item("CI8Remark"))
                txtCI9.Text = String.Concat(.Item("CI9Remark"))
                txtCI10.Text = String.Concat(.Item("CI10Remark"))
                txtCI11.Text = String.Concat(.Item("CI11Remark"))
                txtCI12.Text = String.Concat(.Item("CI12Remark"))
                txtCI13.Text = String.Concat(.Item("CIOther"))

                txtSatisfaction.Text = String.Concat(.Item("CISatisfaction"))

                optCIResult.SelectedValue = String.Concat(.Item("CIResult"))
                txtCIRemark.Text = String.Concat(.Item("CIRemark"))
                If String.Concat(.Item("CIInformDate")) <> "" Then
                    txtCIInformDate.Text = ConvertStrDate2ShortTH(String.Concat(.Item("CIInformDate")))
                End If

                If String.Concat(.Item("CIResponseDate")) <> "" Then
                    txtCIResponseDate.Text = ConvertStrDate2ShortTH(String.Concat(.Item("CIResponseDate")))
                End If


                optCIComplete.SelectedValue = String.Concat(.Item("CIComplete"))
                chkCIClose.Checked = ConvertYN2Boolean(String.Concat(.Item("CIClose")))
                If String.Concat(.Item("CICloseDate")) <> "" Then
                    txtCICloseDate.Text = ConvertStrDate2ShortTH(String.Concat(.Item("CICloseDate")))
                End If

                txtCICloseRemark.Text = String.Concat(.Item("CICloseRemark"))

                LoadQA1()
                LoadQA2()
                LoadQA3()
                LoadQA4()
                LoadQA5()


                '        'If String.Concat(.Item("LocationAsmStatus")) = "Y" Then
                '        '    chkStatus.Checked = True
                '        'Else
                '        '    chkStatus.Checked = False
                '        'End If

            End With

        End If
        dtL = Nothing
    End Sub

    Protected Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click

        'If chkIsSoftware.Checked = True Then
        '    isSoftware = "Y"
        'Else
        '    isSoftware = "N"
        'End If
        'สร้าง id การตรวจ
        If txtAssessee.Text = "" Or txtPosition.Text = "" Then
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','กรุณาระบุชื่อ/ตำแหน่ง ของผู้รับการตรวจ');", True)
            Exit Sub
        End If
        If txtAsmDate.Text = "" Then
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','กรุณาระบุวันที่ดำเนินการตรวจ');", True)
            Exit Sub
        End If
        If optAudit.SelectedValue = Nothing Then
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','กรุณาระบุวิธีตรวจ');", True)
            Exit Sub
        End If

        If optQA1.SelectedValue = Nothing Then
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','กรุณาระบุมาตรฐานหมวด 1.หมวดสถานที่');", True)
            Exit Sub
        End If
        If optQA2.SelectedValue = Nothing Then
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','กรุณาระบุมาตรฐานหมวด 2.หมวดอุปกรณ์');", True)
            Exit Sub
        End If
        If optQA3.SelectedValue = Nothing Then
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','กรุณาระบุมาตรฐานหมวด 3.หมวดบุคลากร');", True)
            Exit Sub
        End If
        If optQA4.SelectedValue = Nothing Then
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','กรุณาระบุมาตรฐานหมวด 4.หมวดการควบคุมคุณภาพยา');", True)
            Exit Sub
        End If
        If optQA5.SelectedValue = Nothing Then
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','กรุณาระบุมาตรฐานหมวด 5.การปฏิบัติตามวิธีปฏิบัติทางเภสัชกรรมชุมชน');", True)
            Exit Sub
        End If

        If optQAResult.SelectedValue = Nothing Then
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','กรุณาระบุผลการตรวจระบบร้านยาคุณภาพ');", True)
            Exit Sub
        End If

        If optQAComplete.SelectedValue = Nothing Then
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','กรุณาระบุผลพิจารณาการแก้ไข ระบบร้านยาคุณภาพ');", True)
            Exit Sub
        End If

        If chkQAClose.Checked And txtQACloseDate.Text = "" Then
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','กรุณาระบุวันที่ปิดการตรวจมาตรฐาน ระบบร้านยาคุณภาพ');", True)
            Exit Sub
        End If

        If optCIResult.SelectedValue = Nothing Then
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','กรุณาระบุผลการตรวจ มาตรฐานบริการ Common illness');", True)
            Exit Sub
        End If

        If optCIComplete.SelectedValue = Nothing Then
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','กรุณาระบุผลพิจารณาการแก้ไข  มาตรฐานบริการ Common illness');", True)
            Exit Sub
        End If

        If chkCIClose.Checked And txtCICloseDate.Text = "" Then
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','กรุณาระบุวันที่ปิดการตรวจมาตรฐาน  มาตรฐานบริการ Common illness');", True)
            Exit Sub
        End If

        Dim AsmDate As String = ConvertStrDate2DBDate(txtAsmDate.Text)

        Dim QAInformDate As String = ConvertStrDate2DBDate(txtQAInformDate.Text)
        Dim QAResponseDate As String = ConvertStrDate2DBDate(txtQAresponseDate.Text)
        Dim QACloseDate As String = ConvertStrDate2DBDate(txtQACloseDate.Text)

        Dim CIInformDate As String = ConvertStrDate2DBDate(txtCIInformDate.Text)
        Dim CIResponseDate As String = ConvertStrDate2DBDate(txtCIResponseDate.Text)
        Dim CICloseDate As String = ConvertStrDate2DBDate(txtCICloseDate.Text)

        Dim IsQA, IsCI As String
        If chkAccPharm.Checked = True Then
            IsQA = "Y"
        Else
            IsQA = "N"
        End If
        If chkCI.Checked = True Then
            IsCI = "Y"
        Else
            IsCI = "N"
        End If

        ctlA.PostAudit_Update(StrNull2Zero(hdPostUID.Value), StrNull2Zero(hdLocationUID.Value), txtAssessee.Text, txtPosition.Text, StrNull2Zero(hdAssessmentUID.Value), AsmDate, optAudit.SelectedValue, optQA1.SelectedValue, optQA2.SelectedValue, optQA3.SelectedValue, optQA4.SelectedValue, optQA5.SelectedValue, optQAResult.SelectedValue, txtQARemark.Text, QAInformDate, QAResponseDate, optQAComplete.SelectedValue, ConvertBoolean2YN(chkQAClose.Checked), QACloseDate, txtQACloseRemark.Text, ConvertBoolean2YN(chkC1.Checked), ConvertBoolean2YN(chkC2.Checked), ConvertBoolean2YN(chkC3.Checked), ConvertBoolean2YN(chkC4.Checked), ConvertBoolean2YN(chkC5.Checked), ConvertBoolean2YN(chkC6.Checked), ConvertBoolean2YN(chkC7.Checked), ConvertBoolean2YN(chkC8.Checked), ConvertBoolean2YN(chkC9.Checked), ConvertBoolean2YN(chkC10.Checked), ConvertBoolean2YN(chkC11.Checked), ConvertBoolean2YN(chkC12.Checked), txtCI13.Text, txtCI1.Text, txtCI2.Text, txtCI3.Text, txtCI4.Text, txtCI5.Text, txtCI6.Text, txtCI7.Text, txtCI8.Text, txtCI9.Text, txtCI10.Text, txtCI11.Text, txtCI12.Text, txtSatisfaction.Text, optCIResult.SelectedValue, txtCIRemark.Text, CIInformDate, CIResponseDate, optCIComplete.SelectedValue, ConvertBoolean2YN(chkCIClose.Checked), CICloseDate, txtCICloseRemark.Text, Request.Cookies("userid").Value, IsQA, IsCI)

        ctlU.User_GenLogfile(Request.Cookies("UserID").Value, ACTTYPE_UPD, "PostAudit", "บันทึกข้อมูล Post Audit", "[LocationUID=" & hdLocationUID.Value & "][AsmUID=" & hdAssessmentUID.Value & "][UID=" & hdPostUID.Value & "]", Environment.MachineName, GetIPAddress())

        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalSuccess(this,'Success','บันทึกข้อมูลเรียบร้อย');", True)

    End Sub

    Private Sub UploadFiles(ByVal Fileupload As Object, REFUID As Integer, sCode As String)
        Dim SEQNO As String
        Dim sfileName As String = ""

        UploadDirectory = Server.MapPath("imageUploads/POST/" & hdLocationUID.Value & "/")

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

                SEQNO = ctlM.Media_GetLastSEQ(StrNull2Zero(hdPostUID.Value), 0, StrNull2Zero(hdLocationUID.Value), sCode, REFUID)
                sfileName = sCode & "_" & REFUID & "_" & SEQNO.ToString() & fileExtname

                Dim objfile As FileInfo = New FileInfo("imageUploads/POST/" & hdLocationUID.Value & "/" & sfileName)
                If objfile.Exists Then
                    objfile.Delete()
                End If
                uploadedFile.SaveAs(System.IO.Path.Combine(UploadDirectory, sfileName))
                ctlM.Media_Save2(StrNull2Zero(hdPostUID.Value), 0, StrNull2Zero(hdLocationUID.Value), sCode, REFUID, SEQNO, sfileName, Request.Cookies("UserID").Value)
            Next
        End If
    End Sub


    Protected Sub cmdSaveQA1_Click(sender As Object, e As EventArgs) Handles cmdSaveQA1.Click
        If optQA1.SelectedValue = Nothing Then
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','ต้องเลือกพบสิ่งที่ไม่เป็นไปตามมาตรฐาน เท่านั้นถึงจะป้อนข้อมูลได้');", True)
            Exit Sub
        End If
        If txtQA1.Text = "" Then
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','กรุณป้อนข้อมูลให้ครบถ้วนก่อน');", True)
            Exit Sub
        End If

        Dim SEQNO, QAUID As String
        Dim sfileName As String = ""
        UploadDirectory = Server.MapPath("~/imageUploads/POST/" & hdLocationUID.Value)
        If Not Directory.Exists(UploadDirectory) Then
            Directory.CreateDirectory(UploadDirectory)
        End If

        ctlA.QAStandard_Save(StrNull2Zero(hdQA1UID.Value), StrNull2Zero(hdPostUID.Value), 1, txtQA1.Text)

        If StrNull2Long(hdQA1UID.Value) = 0 Then
            QAUID = ctlA.QAStandard_GetLastUID(StrNull2Zero(hdPostUID.Value), 1)
        Else
            QAUID = hdQA1UID.Value
        End If

        If FileUploadQA1.HasFiles Then
            For Each uploadedFile As HttpPostedFile In FileUploadQA1.PostedFiles
                Dim fileExtname As String = Path.GetExtension(uploadedFile.FileName).ToLower()

                'If ctlM.Media_GetCount(StrNull2Zero(Request("id")), 0, StrNull2Zero(hdLocationUID.Value), "QA1", StrNull2Long(QAUID)) >= 4 Then
                '    Exit Sub
                'End If

                If fileExtname <> ".jpg" And fileExtname <> ".jpeg" And fileExtname <> ".png" Then
                    ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','ไฟล์รูปภาพต้องมีนามสกุล .jpg, .jpeg, .png เท่านั้น');", True)
                    Exit Sub
                End If
                If (FileUploadQA1.PostedFile.ContentLength / 1024) > 1024 Then
                    ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','ไฟล์มีขนาดใหญ่เกิน 1024 Kb. ไม่สามารถอัพโหลดได้');", True)
                    Exit Sub
                End If

                SEQNO = ctlM.Media_GetLastSEQ(StrNull2Zero(hdPostUID.Value), 0, StrNull2Zero(hdLocationUID.Value), "QA1", QAUID)

                sfileName = "QA1_" & QAUID & "_" & SEQNO.ToString() & fileExtname

                Dim objfile As FileInfo = New FileInfo(UploadDirectory & sfileName)
                If objfile.Exists Then
                    objfile.Delete()
                End If
                uploadedFile.SaveAs(System.IO.Path.Combine(UploadDirectory, sfileName))
                ctlM.Media_Save2(StrNull2Zero(hdPostUID.Value), 0, hdLocationUID.Value, "QA1", QAUID, SEQNO, sfileName, Request.Cookies("UserID").Value)
            Next
        End If
        hdQA1UID.Value = ""
        txtQA1.Text = ""
        LoadQA1()
    End Sub
    Private Sub LoadQA1()
        Dim dtS As New DataTable
        dtS = ctlA.QAStandard_Get(StrNull2Zero(hdPostUID.Value), 1)
        If dtS.Rows.Count > 0 Then
            With grdQA1
                .Visible = True
                .DataSource = dtS
                .DataBind()
            End With
        Else
            grdQA1.Visible = False
        End If
        dtS = Nothing
    End Sub
    Private Sub EditQA1Data(ByVal pID As String)
        txtQA1.Text = ""
        dt = ctlA.QAStandard_GetByUID(pID)
        If dt.Rows.Count > 0 Then
            With dt.Rows(0)
                hdQA1UID.Value = .Item("UID")
                txtQA1.Text = String.Concat(.Item("Descriptions"))
                cmdSaveQA1.Text = "บันทึก"
            End With
        End If

        dt = Nothing
    End Sub

    Private Sub grdQA1_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grdQA1.RowCommand
        If TypeOf e.CommandSource Is WebControls.LinkButton Then
            Dim ButtonPressed As WebControls.LinkButton = e.CommandSource
            Select Case ButtonPressed.ID
                Case "imgEdit"
                    EditQA1Data(e.CommandArgument())
                Case "imgFileQA1"
                    Dim fPath As String = "imageUploads/POST/" & hdLocationUID.Value
                    hdQAUID.Value = e.CommandArgument()
                    hdImgCode.Value = "QA1"
                    LoadQAImg()
                    ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalUploadQA(this,'" + e.CommandArgument() + "');", True)

                Case "imgDel"
                    If ctlA.QAStandard_Delete(e.CommandArgument) Then
                        DeleteImageByGroup("QA1", e.CommandArgument)
                        LoadQA1()

                        'ctlU.User_GenLogfile(Request.Cookies("UserID").Value, "DEL", "Pharmacists", "ลบเภสัชกรประจำร้านยา :" & e.CommandArgument, "")
                        'ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalSuccess(this,'Success','ลบข้อมูลเรียบร้อย');", True)
                    Else
                        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningAlert(this,'ผลการตรวจสอบ','ไม่สามารถลบข้อมูลได้ กรุณาตรวจสอบและลองใหม่อีกครั้ง');", True)
                    End If

            End Select
        End If
    End Sub
    Private Sub grdQA1_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles grdQA1.RowDataBound
        If e.Row.RowType = ListItemType.AlternatingItem Or e.Row.RowType = ListItemType.Item Then
            Dim scriptString As String = "javascript:return confirm(""ต้องการลบ ข้อมูลนี้ ?"");"
            Dim imgD As LinkButton = e.Row.Cells(3).FindControl("imgDel")
            imgD.Attributes.Add("onClick", scriptString)
        End If

        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#d0e8ff';")
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;")

        End If
    End Sub


    Protected Sub cmdSaveQA2_Click(sender As Object, e As EventArgs) Handles cmdSaveQA2.Click
        If optQA2.SelectedValue = Nothing Then
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','ต้องเลือกพบสิ่งที่ไม่เป็นไปตามมาตรฐาน เท่านั้นถึงจะป้อนข้อมูลได้');", True)
            Exit Sub
        End If
        If txtQA2.Text = "" Then
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','กรุณป้อนข้อมูลให้ครบถ้วนก่อน');", True)
            Exit Sub
        End If

        Dim SEQNO, QAUID As String
        Dim sfileName As String = ""
        UploadDirectory = Server.MapPath("~/imageUploads/POST/" & hdLocationUID.Value)
        If Not Directory.Exists(UploadDirectory) Then
            Directory.CreateDirectory(UploadDirectory)
        End If

        ctlA.QAStandard_Save(StrNull2Zero(hdQA2UID.Value), StrNull2Zero(hdPostUID.Value), 2, txtQA2.Text)

        If StrNull2Long(hdQA2UID.Value) = 0 Then
            QAUID = ctlA.QAStandard_GetLastUID(StrNull2Zero(hdPostUID.Value), 2)
        Else
            QAUID = hdQA2UID.Value
        End If

        If FileUploadQA2.HasFiles Then
            For Each uploadedFile As HttpPostedFile In FileUploadQA2.PostedFiles
                Dim fileExtname As String = Path.GetExtension(uploadedFile.FileName).ToLower()

                'If ctlM.Media_GetCount(StrNull2Zero(Request("id")), 0, StrNull2Zero(hdLocationUID.Value), "QA2", StrNull2Long(QAUID)) >= 4 Then
                '    Exit Sub
                'End If

                If fileExtname <> ".jpg" And fileExtname <> ".jpeg" And fileExtname <> ".png" Then
                    ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','ไฟล์รูปภาพต้องมีนามสกุล .jpg, .jpeg, .png เท่านั้น');", True)
                    Exit Sub
                End If
                If (FileUploadQA2.PostedFile.ContentLength / 1024) > 1024 Then
                    ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','ไฟล์มีขนาดใหญ่เกิน 1024 Kb. ไม่สามารถอัพโหลดได้');", True)
                    Exit Sub
                End If

                SEQNO = ctlM.Media_GetLastSEQ(StrNull2Zero(hdPostUID.Value), 0, StrNull2Zero(hdLocationUID.Value), "QA2", QAUID)

                sfileName = "QA2_" & QAUID & "_" & SEQNO.ToString() & fileExtname

                Dim objfile As FileInfo = New FileInfo(UploadDirectory & sfileName)
                If objfile.Exists Then
                    objfile.Delete()
                End If
                uploadedFile.SaveAs(System.IO.Path.Combine(UploadDirectory, sfileName))
                ctlM.Media_Save2(StrNull2Zero(hdPostUID.Value), 0, hdLocationUID.Value, "QA2", QAUID, SEQNO, sfileName, Request.Cookies("UserID").Value)
            Next
        End If
        hdQA2UID.Value = ""
        txtQA2.Text = ""
        LoadQA2()
    End Sub
    Private Sub LoadQA2()
        Dim dtS As New DataTable
        dtS = ctlA.QAStandard_Get(StrNull2Zero(hdPostUID.Value), 2)
        If dtS.Rows.Count > 0 Then
            With grdQA2
                .Visible = True
                .DataSource = dtS
                .DataBind()
            End With
        Else
            grdQA2.Visible = False
        End If
        dtS = Nothing
    End Sub
    Private Sub EditQA2Data(ByVal pID As String)
        txtQA2.Text = ""
        dt = ctlA.QAStandard_GetByUID(pID)
        If dt.Rows.Count > 0 Then
            With dt.Rows(0)
                hdQA2UID.Value = .Item("UID")
                txtQA2.Text = String.Concat(.Item("Descriptions"))
                cmdSaveQA2.Text = "บันทึก"
            End With
        End If

        dt = Nothing
    End Sub

    Private Sub grdQA2_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grdQA2.RowCommand
        If TypeOf e.CommandSource Is WebControls.LinkButton Then
            Dim ButtonPressed As WebControls.LinkButton = e.CommandSource
            Select Case ButtonPressed.ID
                Case "imgEdit"
                    EditQA2Data(e.CommandArgument())
                Case "imgFileQA2"
                    Dim fPath As String = "imageUploads/POST/" & hdLocationUID.Value
                    hdQAUID.Value = e.CommandArgument()
                    hdImgCode.Value = "QA2"
                    LoadQAImg()
                    ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalUploadQA(this,'" + e.CommandArgument() + "');", True)

                Case "imgDel"
                    If ctlA.QAStandard_Delete(e.CommandArgument) Then
                        DeleteImageByGroup("QA2", e.CommandArgument)
                        LoadQA2()

                        'ctlU.User_GenLogfile(Request.Cookies("UserID").Value, "DEL", "Pharmacists", "ลบเภสัชกรประจำร้านยา :" & e.CommandArgument, "")
                        'ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalSuccess(this,'Success','ลบข้อมูลเรียบร้อย');", True)
                    Else
                        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningAlert(this,'ผลการตรวจสอบ','ไม่สามารถลบข้อมูลได้ กรุณาตรวจสอบและลองใหม่อีกครั้ง');", True)
                    End If

            End Select
        End If
    End Sub
    Private Sub grdQA2_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles grdQA2.RowDataBound
        If e.Row.RowType = ListItemType.AlternatingItem Or e.Row.RowType = ListItemType.Item Then
            Dim scriptString As String = "javascript:return confirm(""ต้องการลบ ข้อมูลนี้ ?"");"
            Dim imgD As LinkButton = e.Row.Cells(3).FindControl("imgDel")
            imgD.Attributes.Add("onClick", scriptString)
        End If

        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#d0e8ff';")
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;")

        End If
    End Sub




    Protected Sub cmdSaveQA3_Click(sender As Object, e As EventArgs) Handles cmdSaveQA3.Click
        If optQA3.SelectedValue = Nothing Then
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','ต้องเลือกพบสิ่งที่ไม่เป็นไปตามมาตรฐาน เท่านั้นถึงจะป้อนข้อมูลได้');", True)
            Exit Sub
        End If
        If txtQA3.Text = "" Then
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','กรุณป้อนข้อมูลให้ครบถ้วนก่อน');", True)
            Exit Sub
        End If

        Dim SEQNO, QAUID As String
        Dim sfileName As String = ""
        UploadDirectory = Server.MapPath("~/imageUploads/POST/" & hdLocationUID.Value)
        If Not Directory.Exists(UploadDirectory) Then
            Directory.CreateDirectory(UploadDirectory)
        End If

        ctlA.QAStandard_Save(StrNull2Zero(hdQA3UID.Value), StrNull2Zero(hdPostUID.Value), 3, txtQA3.Text)

        If StrNull2Long(hdQA3UID.Value) = 0 Then
            QAUID = ctlA.QAStandard_GetLastUID(StrNull2Zero(hdPostUID.Value), 3)
        Else
            QAUID = hdQA3UID.Value
        End If

        If FileUploadQA3.HasFiles Then
            For Each uploadedFile As HttpPostedFile In FileUploadQA3.PostedFiles
                Dim fileExtname As String = Path.GetExtension(uploadedFile.FileName).ToLower()

                'If ctlM.Media_GetCount(StrNull2Zero(Request("id")), 0, StrNull2Zero(hdLocationUID.Value), "QA3", StrNull2Long(QAUID)) >= 4 Then
                '    Exit Sub
                'End If

                If fileExtname <> ".jpg" And fileExtname <> ".jpeg" And fileExtname <> ".png" Then
                    ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','ไฟล์รูปภาพต้องมีนามสกุล .jpg, .jpeg, .png เท่านั้น');", True)
                    Exit Sub
                End If
                If (FileUploadQA3.PostedFile.ContentLength / 1024) > 1024 Then
                    ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','ไฟล์มีขนาดใหญ่เกิน 1024 Kb. ไม่สามารถอัพโหลดได้');", True)
                    Exit Sub
                End If

                SEQNO = ctlM.Media_GetLastSEQ(StrNull2Zero(hdPostUID.Value), 0, StrNull2Zero(hdLocationUID.Value), "QA3", QAUID)

                sfileName = "QA3_" & QAUID & "_" & SEQNO.ToString() & fileExtname

                Dim objfile As FileInfo = New FileInfo(UploadDirectory & sfileName)
                If objfile.Exists Then
                    objfile.Delete()
                End If
                uploadedFile.SaveAs(System.IO.Path.Combine(UploadDirectory, sfileName))
                ctlM.Media_Save2(StrNull2Zero(hdPostUID.Value), 0, hdLocationUID.Value, "QA3", QAUID, SEQNO, sfileName, Request.Cookies("UserID").Value)
            Next
        End If
        hdQA3UID.Value = ""
        txtQA3.Text = ""
        LoadQA3()
    End Sub
    Private Sub LoadQA3()
        Dim dtS As New DataTable
        dtS = ctlA.QAStandard_Get(StrNull2Zero(hdPostUID.Value), 3)
        If dtS.Rows.Count > 0 Then
            With grdQA3
                .Visible = True
                .DataSource = dtS
                .DataBind()
            End With
        Else
            grdQA3.Visible = False
        End If
        dtS = Nothing
    End Sub
    Private Sub EditQA3Data(ByVal pID As String)
        txtQA3.Text = ""
        dt = ctlA.QAStandard_GetByUID(pID)
        If dt.Rows.Count > 0 Then
            With dt.Rows(0)
                hdQA3UID.Value = .Item("UID")
                txtQA3.Text = String.Concat(.Item("Descriptions"))
                cmdSaveQA3.Text = "บันทึก"
            End With
        End If

        dt = Nothing
    End Sub

    Private Sub grdQA3_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grdQA3.RowCommand
        If TypeOf e.CommandSource Is WebControls.LinkButton Then
            Dim ButtonPressed As WebControls.LinkButton = e.CommandSource
            Select Case ButtonPressed.ID
                Case "imgEdit"
                    EditQA3Data(e.CommandArgument())
                Case "imgFileQA3"
                    Dim fPath As String = "imageUploads/POST/" & hdLocationUID.Value
                    hdQAUID.Value = e.CommandArgument()
                    hdImgCode.Value = "QA3"
                    LoadQAImg()
                    ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalUploadQA(this,'" + e.CommandArgument() + "');", True)

                Case "imgDel"
                    If ctlA.QAStandard_Delete(e.CommandArgument) Then
                        DeleteImageByGroup("QA3", e.CommandArgument)
                        LoadQA3()

                        'ctlU.User_GenLogfile(Request.Cookies("UserID").Value, "DEL", "Pharmacists", "ลบเภสัชกรประจำร้านยา :" & e.CommandArgument, "")
                        'ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalSuccess(this,'Success','ลบข้อมูลเรียบร้อย');", True)
                    Else
                        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningAlert(this,'ผลการตรวจสอบ','ไม่สามารถลบข้อมูลได้ กรุณาตรวจสอบและลองใหม่อีกครั้ง');", True)
                    End If

            End Select
        End If
    End Sub
    Private Sub grdQA3_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles grdQA3.RowDataBound
        If e.Row.RowType = ListItemType.AlternatingItem Or e.Row.RowType = ListItemType.Item Then
            Dim scriptString As String = "javascript:return confirm(""ต้องการลบ ข้อมูลนี้ ?"");"
            Dim imgD As LinkButton = e.Row.Cells(3).FindControl("imgDel")
            imgD.Attributes.Add("onClick", scriptString)
        End If

        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#d0e8ff';")
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;")

        End If
    End Sub




    Protected Sub cmdSaveQA4_Click(sender As Object, e As EventArgs) Handles cmdSaveQA4.Click
        If optQA4.SelectedValue = Nothing Then
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','ต้องเลือกพบสิ่งที่ไม่เป็นไปตามมาตรฐาน เท่านั้นถึงจะป้อนข้อมูลได้');", True)
            Exit Sub
        End If
        If txtQA4.Text = "" Then
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','กรุณป้อนข้อมูลให้ครบถ้วนก่อน');", True)
            Exit Sub
        End If

        Dim SEQNO, QAUID As String
        Dim sfileName As String = ""
        UploadDirectory = Server.MapPath("~/imageUploads/POST/" & hdLocationUID.Value)
        If Not Directory.Exists(UploadDirectory) Then
            Directory.CreateDirectory(UploadDirectory)
        End If

        ctlA.QAStandard_Save(StrNull2Zero(hdQA4UID.Value), StrNull2Zero(hdPostUID.Value), 4, txtQA4.Text)

        If StrNull2Long(hdQA4UID.Value) = 0 Then
            QAUID = ctlA.QAStandard_GetLastUID(StrNull2Zero(hdPostUID.Value), 4)
        Else
            QAUID = hdQA4UID.Value
        End If

        If FileUploadQA4.HasFiles Then
            For Each uploadedFile As HttpPostedFile In FileUploadQA4.PostedFiles
                Dim fileExtname As String = Path.GetExtension(uploadedFile.FileName).ToLower()

                'If ctlM.Media_GetCount(StrNull2Zero(Request("id")), 0, StrNull2Zero(hdLocationUID.Value), "QA4", StrNull2Long(QAUID)) >= 4 Then
                '    Exit Sub
                'End If

                If fileExtname <> ".jpg" And fileExtname <> ".jpeg" And fileExtname <> ".png" Then
                    ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','ไฟล์รูปภาพต้องมีนามสกุล .jpg, .jpeg, .png เท่านั้น');", True)
                    Exit Sub
                End If
                If (FileUploadQA4.PostedFile.ContentLength / 1024) > 1024 Then
                    ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','ไฟล์มีขนาดใหญ่เกิน 1024 Kb. ไม่สามารถอัพโหลดได้');", True)
                    Exit Sub
                End If

                SEQNO = ctlM.Media_GetLastSEQ(StrNull2Zero(hdPostUID.Value), 0, StrNull2Zero(hdLocationUID.Value), "QA4", QAUID)

                sfileName = "QA4_" & QAUID & "_" & SEQNO.ToString() & fileExtname

                Dim objfile As FileInfo = New FileInfo(UploadDirectory & sfileName)
                If objfile.Exists Then
                    objfile.Delete()
                End If
                uploadedFile.SaveAs(System.IO.Path.Combine(UploadDirectory, sfileName))
                ctlM.Media_Save2(StrNull2Zero(hdPostUID.Value), 0, hdLocationUID.Value, "QA4", QAUID, SEQNO, sfileName, Request.Cookies("UserID").Value)
            Next
        End If
        hdQA4UID.Value = ""
        txtQA4.Text = ""
        LoadQA4()
    End Sub
    Private Sub LoadQA4()
        Dim dtS As New DataTable
        dtS = ctlA.QAStandard_Get(StrNull2Zero(hdPostUID.Value), 4)
        If dtS.Rows.Count > 0 Then
            With grdQA4
                .Visible = True
                .DataSource = dtS
                .DataBind()
            End With
        Else
            grdQA4.Visible = False
        End If
        dtS = Nothing
    End Sub
    Private Sub EditQA4Data(ByVal pID As String)
        txtQA4.Text = ""
        dt = ctlA.QAStandard_GetByUID(pID)
        If dt.Rows.Count > 0 Then
            With dt.Rows(0)
                hdQA4UID.Value = .Item("UID")
                txtQA4.Text = String.Concat(.Item("Descriptions"))
                cmdSaveQA4.Text = "บันทึก"
            End With
        End If

        dt = Nothing
    End Sub

    Private Sub grdQA4_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grdQA4.RowCommand
        If TypeOf e.CommandSource Is WebControls.LinkButton Then
            Dim ButtonPressed As WebControls.LinkButton = e.CommandSource
            Select Case ButtonPressed.ID
                Case "imgEdit"
                    EditQA4Data(e.CommandArgument())
                Case "imgFileQA4"
                    Dim fPath As String = "imageUploads/POST/" & hdLocationUID.Value
                    hdQAUID.Value = e.CommandArgument()
                    hdImgCode.Value = "QA4"
                    LoadQAImg()
                    ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalUploadQA(this,'" + e.CommandArgument() + "');", True)

                Case "imgDel"
                    If ctlA.QAStandard_Delete(e.CommandArgument) Then
                        DeleteImageByGroup("QA4", e.CommandArgument)
                        LoadQA4()

                        'ctlU.User_GenLogfile(Request.Cookies("UserID").Value, "DEL", "Pharmacists", "ลบเภสัชกรประจำร้านยา :" & e.CommandArgument, "")
                        'ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalSuccess(this,'Success','ลบข้อมูลเรียบร้อย');", True)
                    Else
                        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningAlert(this,'ผลการตรวจสอบ','ไม่สามารถลบข้อมูลได้ กรุณาตรวจสอบและลองใหม่อีกครั้ง');", True)
                    End If

            End Select
        End If
    End Sub
    Private Sub grdQA4_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles grdQA4.RowDataBound
        If e.Row.RowType = ListItemType.AlternatingItem Or e.Row.RowType = ListItemType.Item Then
            Dim scriptString As String = "javascript:return confirm(""ต้องการลบ ข้อมูลนี้ ?"");"
            Dim imgD As LinkButton = e.Row.Cells(3).FindControl("imgDel")
            imgD.Attributes.Add("onClick", scriptString)
        End If

        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#d0e8ff';")
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;")

        End If
    End Sub




    Protected Sub cmdSaveQA5_Click(sender As Object, e As EventArgs) Handles cmdSaveQA5.Click
        If optQA5.SelectedValue = Nothing Then
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','ต้องเลือกพบสิ่งที่ไม่เป็นไปตามมาตรฐาน เท่านั้นถึงจะป้อนข้อมูลได้');", True)
            Exit Sub
        End If
        If txtQA5.Text = "" Then
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','กรุณป้อนข้อมูลให้ครบถ้วนก่อน');", True)
            Exit Sub
        End If

        Dim SEQNO, QAUID As String
        Dim sfileName As String = ""
        UploadDirectory = Server.MapPath("~/imageUploads/POST/" & hdLocationUID.Value)
        If Not Directory.Exists(UploadDirectory) Then
            Directory.CreateDirectory(UploadDirectory)
        End If

        ctlA.QAStandard_Save(StrNull2Zero(hdQA5UID.Value), StrNull2Zero(hdPostUID.Value), 5, txtQA5.Text)

        If StrNull2Long(hdQA5UID.Value) = 0 Then
            QAUID = ctlA.QAStandard_GetLastUID(StrNull2Zero(hdPostUID.Value), 5)
        Else
            QAUID = hdQA5UID.Value
        End If

        If FileUploadQA5.HasFiles Then
            For Each uploadedFile As HttpPostedFile In FileUploadQA5.PostedFiles
                Dim fileExtname As String = Path.GetExtension(uploadedFile.FileName).ToLower()

                'If ctlM.Media_GetCount(StrNull2Zero(Request("id")), 0, StrNull2Zero(hdLocationUID.Value), "QA5", StrNull2Long(QAUID)) >= 4 Then
                '    Exit Sub
                'End If

                If fileExtname <> ".jpg" And fileExtname <> ".jpeg" And fileExtname <> ".png" Then
                    ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','ไฟล์รูปภาพต้องมีนามสกุล .jpg, .jpeg, .png เท่านั้น');", True)
                    Exit Sub
                End If
                If (FileUploadQA5.PostedFile.ContentLength / 1024) > 1024 Then
                    ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','ไฟล์มีขนาดใหญ่เกิน 1024 Kb. ไม่สามารถอัพโหลดได้');", True)
                    Exit Sub
                End If

                SEQNO = ctlM.Media_GetLastSEQ(StrNull2Zero(hdPostUID.Value), 0, StrNull2Zero(hdLocationUID.Value), "QA5", QAUID)

                sfileName = "QA5_" & QAUID & "_" & SEQNO.ToString() & fileExtname

                Dim objfile As FileInfo = New FileInfo(UploadDirectory & sfileName)
                If objfile.Exists Then
                    objfile.Delete()
                End If
                uploadedFile.SaveAs(System.IO.Path.Combine(UploadDirectory, sfileName))
                ctlM.Media_Save2(StrNull2Zero(hdPostUID.Value), 0, hdLocationUID.Value, "QA5", QAUID, SEQNO, sfileName, Request.Cookies("UserID").Value)
            Next
        End If
        hdQA5UID.Value = ""
        txtQA5.Text = ""
        LoadQA5()
    End Sub
    Private Sub LoadQA5()
        Dim dtS As New DataTable
        dtS = ctlA.QAStandard_Get(StrNull2Zero(hdPostUID.Value), 5)
        If dtS.Rows.Count > 0 Then
            With grdQA5
                .Visible = True
                .DataSource = dtS
                .DataBind()
            End With
        Else
            grdQA5.Visible = False
        End If
        dtS = Nothing
    End Sub
    Private Sub EditQA5Data(ByVal pID As String)
        txtQA5.Text = ""
        dt = ctlA.QAStandard_GetByUID(pID)
        If dt.Rows.Count > 0 Then
            With dt.Rows(0)
                hdQA5UID.Value = .Item("UID")
                txtQA5.Text = String.Concat(.Item("Descriptions"))
                cmdSaveQA5.Text = "บันทึก"
            End With
        End If

        dt = Nothing
    End Sub

    Private Sub grdQA5_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grdQA5.RowCommand
        If TypeOf e.CommandSource Is WebControls.LinkButton Then
            Dim ButtonPressed As WebControls.LinkButton = e.CommandSource
            Select Case ButtonPressed.ID
                Case "imgEdit"
                    EditQA5Data(e.CommandArgument())
                Case "imgFileQA5"
                    Dim fPath As String = "imageUploads/POST/" & hdLocationUID.Value
                    hdQAUID.Value = e.CommandArgument()
                    hdImgCode.Value = "QA5"
                    LoadQAImg()
                    ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalUploadQA(this,'" + e.CommandArgument() + "');", True)

                Case "imgDel"
                    If ctlA.QAStandard_Delete(e.CommandArgument) Then
                        DeleteImageByGroup("QA5", e.CommandArgument)
                        LoadQA5()

                        'ctlU.User_GenLogfile(Request.Cookies("UserID").Value, "DEL", "Pharmacists", "ลบเภสัชกรประจำร้านยา :" & e.CommandArgument, "")
                        'ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalSuccess(this,'Success','ลบข้อมูลเรียบร้อย');", True)
                    Else
                        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningAlert(this,'ผลการตรวจสอบ','ไม่สามารถลบข้อมูลได้ กรุณาตรวจสอบและลองใหม่อีกครั้ง');", True)
                    End If

            End Select
        End If
    End Sub
    Private Sub grdQA5_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles grdQA5.RowDataBound
        If e.Row.RowType = ListItemType.AlternatingItem Or e.Row.RowType = ListItemType.Item Then
            Dim scriptString As String = "javascript:return confirm(""ต้องการลบ ข้อมูลนี้ ?"");"
            Dim imgD As LinkButton = e.Row.Cells(3).FindControl("imgDel")
            imgD.Attributes.Add("onClick", scriptString)
        End If

        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#d0e8ff';")
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;")

        End If
    End Sub


    Private Sub DeleteImageByGroup(ImgGroup As String, RefUID As String)
        dt = ctlM.Media_GetImagePath(0, hdLocationUID.Value, ImgGroup, RefUID)
        If dt.Rows.Count > 0 Then
            Dim sPath As String = ""
            Select Case ImgGroup
                Case "QA1", "QA2", "QA3", "QA4", "QA5"
                    sPath = "/POST/"
            End Select

            For i = 0 To dt.Rows.Count - 1
                sPath = ""
                Dim objfile As FileInfo = New FileInfo(Server.MapPath("~/imageUploads" & sPath & hdLocationUID.Value & "/" & dt.Rows(i)("FilePath")))
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
            'Select Case dt.Rows(0)("ImageGroup")
            '    Case "QA1", "QA2", "QA3", "QA4", "QA5"
            sPath = "/POST/"
            'End Select

            Dim objfile As FileInfo = New FileInfo(Server.MapPath("~/imageUploads" & sPath & hdLocationUID.Value & "/" & dt.Rows(0)("FilePath")))
            If objfile.Exists Then
                objfile.Delete()
            End If
        End If
    End Sub
    Private Sub PreviewPicture(Fname As String, Desc As String, filePath As String)
        Dim fPath As String = "imageUploads/POST/" & hdLocationUID.Value & "/"
        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWindow(this,'" + Fname + "','" + Desc + "','" + fPath + filePath + "?v=" & ConvertDate2DBString(Now.Date) & ConvertTimeToString(Now()) & "');", True)
    End Sub
    Private Sub PreviewPostPicture(Fname As String, Desc As String, filePath As String)
        'Dim fPath As String = "imageUploads/POST/" & hdLocationUID.Value & "/"
        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWindow(this,'" + Fname + "','" + Desc + "','" + filePath + "?v=" & ConvertDate2DBString(Now.Date) & ConvertTimeToString(Now()) & "');", True)
    End Sub
    Private Sub LoadQAImg()
        dt = ctlM.Media_Get(StrNull2Zero(hdPostUID.Value), StrNull2Zero(hdLocationUID.Value), hdImgCode.Value, StrNull2Zero(hdQAUID.Value))
        grdImgQA.DataSource = dt
        grdImgQA.DataBind()

        If dt.Rows.Count >= 4 Then
            lblImgQA.Text = "ท่านได้อัพโหลดไฟล์ครบ 4 ไฟล์แล้ว ไม่สามารถอัพโหลดเพิ่มได้อีก"
            cmdUpImgQA.Enabled = False
            lblImgQA.Visible = True
        Else
            lblImgQA.Visible = False
            cmdUpImgQA.Enabled = True
        End If

    End Sub

    Private Sub grdImgQA_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grdImgQA.RowCommand
        If TypeOf e.CommandSource Is WebControls.ImageButton Then
            Dim ButtonPressed As WebControls.ImageButton = e.CommandSource
            Select Case ButtonPressed.ID
                Case "imgView"
                    PreviewPicture("", "", e.CommandArgument())
                Case "imgDelFile"
                    DeleteImage(e.CommandArgument)
                    ctlM.Media_Delete(e.CommandArgument)
                    LoadQAImg()
            End Select
        End If
    End Sub

    Private Sub grdImgQA_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles grdImgQA.RowDataBound
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


    'Private Sub LoadImg()
    '    dt = ctlM.Media_Get(StrNull2Zero(Request("id")), StrNull2Zero(hdLocationUID.Value), "A", StrNull2Long(hdAccID.Value))
    '    grdImg.DataSource = dt
    '    grdImg.DataBind()

    '    If dt.Rows.Count >= 4 Then
    '        lblImg.Text = "ท่านได้อัพโหลดไฟล์ครบ 4 ไฟล์แล้ว ไม่สามารถอัพโหลดเพิ่มได้อีก"
    '        cmdUpImg.Enabled = False
    '        lblImg.Visible = True
    '    Else
    '        lblImg.Visible = False
    '        cmdUpImg.Enabled = True
    '    End If

    'End Sub

    'Private Sub grdImg_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grdImg.RowCommand
    '    If TypeOf e.CommandSource Is WebControls.ImageButton Then
    '        Dim ButtonPressed As WebControls.ImageButton = e.CommandSource
    '        Select Case ButtonPressed.ID
    '            Case "imgView"
    '                PreviewPicture("", "", e.CommandArgument())
    '            Case "imgDelFile"
    '                DeleteImage(e.CommandArgument)
    '                ctlM.Media_Delete(e.CommandArgument)
    '                LoadImg()
    '        End Select
    '    End If
    'End Sub

    'Private Sub grdImg_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles grdImg.RowDataBound
    '    If e.Row.RowType = ListItemType.AlternatingItem Or e.Row.RowType = ListItemType.Item Then

    '        Dim scriptString As String = "javascript:return confirm(""ต้องการลบ ข้อมูลนี้ ?"");"
    '        Dim imgD As ImageButton = e.Row.Cells(3).FindControl("imgDelFile")
    '        imgD.Attributes.Add("onClick", scriptString)

    '    End If
    '    If e.Row.RowType = DataControlRowType.DataRow Then
    '        e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#d0e8ff';")
    '        e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;")
    '    End If
    'End Sub

    'Protected Sub cmdUpImg_Click(sender As Object, e As EventArgs) Handles cmdUpImg.Click
    '    UploadFiles(FileUpload1, StrNull2Zero(hdAccID.Value), "A")
    '    LoadImg()
    'End Sub


    Protected Sub cmdClearQA1_Click(sender As Object, e As EventArgs) Handles cmdClearQA1.Click
        txtQA1.Text = ""
        hdQA1UID.Value = "0"
    End Sub

    Private Sub cmdBack_Click(sender As Object, e As EventArgs) Handles cmdBack.Click
        Response.Redirect("PostList?m=po&s=list")
    End Sub

    Private Sub cmdUpImgQA_Click(sender As Object, e As EventArgs) Handles cmdUpImgQA.Click
        UploadFiles(FileUploadQA, StrNull2Zero(hdQAUID.Value), hdImgCode.Value)
        LoadQAImg()
    End Sub

    Private Sub cmdCreate_Click(sender As Object, e As EventArgs) Handles cmdCreate.Click
        'สร้าง id การตรวจ
        If txtAssessee.Text = "" Or txtPosition.Text = "" Then
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','กรุณาระบุชื่อ/ตำแหน่ง ของผู้รับการตรวจ');", True)
            Exit Sub
        End If
        If txtAsmDate.Text = "" Then
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','กรุณาระบุวันที่ดำเนินการตรวจ');", True)
            Exit Sub
        End If
        If optAudit.SelectedValue = Nothing Then
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','กรุณาระบุวิธีตรวจ');", True)
            Exit Sub
        End If
        Dim AsmDate As String = ConvertStrDate2DBDate(txtAsmDate.Text)
        Dim Code As String = ctlM.RunningNumber_New(CODE_POST)

        Dim IsQA, IsCI As String
        If chkAccPharm.Checked = True Then
            IsQA = "Y"
        Else
            IsQA = "N"
        End If
        If chkCI.Checked = True Then
            IsCI = "Y"
        Else
            IsCI = "N"
        End If

        ctlA.PostAudit_Save(StrNull2Zero(hdPostUID.Value), Code, StrNull2Zero(hdLocationUID.Value), txtAssessee.Text, txtPosition.Text, StrNull2Zero(hdAssessmentUID.Value), AsmDate, optAudit.SelectedValue, Request.Cookies("UserID").Value, IsQA, IsCI)

        hdPostUID.Value = ctlA.PostAudit_GetUID(StrNull2Zero(hdLocationUID.Value), StrNull2Zero(hdAssessmentUID.Value), AsmDate)

        Response.Redirect("PostAudit.aspx?m=po&s=list&id=" & hdPostUID.Value)
    End Sub
    Private Sub LoadImgQAInform()
        dt = ctlM.PostAuditFile_Get(hdPostUID.Value, "Q1")
        dtlImgQAInform.DataSource = dt
        dtlImgQAInform.DataBind()
    End Sub
    Private Sub LoadImgQAResponse()
        dt = ctlM.PostAuditFile_Get(hdPostUID.Value, "Q2")
        dtlImgQAResponse.DataSource = dt
        dtlImgQAResponse.DataBind()
    End Sub
    Private Sub LoadImgCIInform()
        dt = ctlM.PostAuditFile_Get(hdPostUID.Value, "C1")
        dtlImgCIInform.DataSource = dt
        dtlImgCIInform.DataBind()
    End Sub
    Private Sub LoadImgCIResponse()
        dt = ctlM.PostAuditFile_Get(hdPostUID.Value, "C2")
        dtlImgCIResponse.DataSource = dt
        dtlImgCIResponse.DataBind()
    End Sub
    Private Sub cmdUploadQAInform_Click(sender As Object, e As EventArgs) Handles cmdUploadQAInform.Click
        Dim SEQNO, Ftype, sCode, RefCode As String
        Dim sfileName As String = ""

        RefCode = "Q" & ConvertDate2DBString(Now.Date) & ConvertTimeToString(Now())
        sCode = "Q1"
        UploadDirectory = Server.MapPath("~/imageUploads/POST/" & hdLocationUID.Value)

        If Not Directory.Exists(UploadDirectory) Then
            Directory.CreateDirectory(UploadDirectory)
        End If

        If FileUploadQAInform.HasFiles Then
            For Each uploadedFile As HttpPostedFile In FileUploadQAInform.PostedFiles
                Dim fileExtname As String = Path.GetExtension(uploadedFile.FileName).ToLower()
                If fileExtname <> ".jpg" And fileExtname <> ".jpeg" And fileExtname <> ".png" And fileExtname <> ".pdf" And fileExtname <> ".doc" And fileExtname <> ".docx" Then
                    ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','ไฟล์รูปภาพต้องมีนามสกุล .jpg, .jpeg, .png,.doc,.docx,.pdf เท่านั้น');", True)
                    Exit Sub
                End If
                If (uploadedFile.ContentLength / 1024) > 2048 Then
                    ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','ไฟล์มีขนาดใหญ่เกิน 2048 Kb. ไม่สามารถอัพโหลดได้');", True)
                    Exit Sub
                End If
                Select Case fileExtname
                    Case ".jpg", ".jpeg", ".png"
                        Ftype = "img"
                    Case Else
                        Ftype = "file"
                End Select

                SEQNO = ctlM.PostAuditFile_GetLastSEQ(RefCode, sCode)
                sfileName = RefCode & sCode & "_" & SEQNO.ToString() & fileExtname

                Dim objfile As FileInfo = New FileInfo(UploadDirectory & sfileName)
                If objfile.Exists Then
                    objfile.Delete()
                End If
                uploadedFile.SaveAs(System.IO.Path.Combine(UploadDirectory, sfileName))
                ctlM.PostAuditFile_Save(RefCode, StrNull2Zero(hdPostUID.Value), StrNull2Zero(hdLocationUID.Value), sCode, SEQNO, sfileName, Ftype, Request.Cookies("UserID").Value)
            Next
        End If
        LoadImgQAInform()
    End Sub

    Private Sub dtlImgQAInform_ItemCommand(source As Object, e As DataListCommandEventArgs) Handles dtlImgQAInform.ItemCommand
        If TypeOf e.CommandSource Is WebControls.ImageButton Then
            Dim ButtonPressed As WebControls.ImageButton = e.CommandSource
            Select Case ButtonPressed.ID
                Case "imgView"
                    Dim str() As String
                    str = Split(e.CommandArgument(), ".")
                    Select Case Left(str(1), 3)
                        Case "jpg", "jpe", "png"
                            PreviewPostPicture("", "", e.CommandArgument())
                        Case Else
                            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "Modal", "window.open('" & e.CommandArgument() & "','_blank');", True)
                    End Select
                Case "imgDel"
                    DeleteImage(e.CommandArgument)
                    ctlM.PostAuditFile_Delete(e.CommandArgument)
                    LoadImgQAInform()
            End Select
        End If
    End Sub

    Private Sub dtlImgQAInform_ItemDataBound(sender As Object, e As DataListItemEventArgs) Handles dtlImgQAInform.ItemDataBound
        If e.Item.ItemType = ListItemType.AlternatingItem Or e.Item.ItemType = ListItemType.Item Then
            Dim scriptString As String = "javascript:return confirm(""ต้องการลบ ข้อมูลนี้ ?"");"
            Dim imgD As ImageButton = e.Item.FindControl("imgDel")
            imgD.Attributes.Add("onClick", scriptString)

        End If
        If e.Item.ItemType = DataControlRowType.DataRow Then
            e.Item.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#d0e8ff';")
            e.Item.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;")

        End If
    End Sub

    Private Sub cmdUploadQAResponse_Click(sender As Object, e As EventArgs) Handles cmdUploadQAResponse.Click
        Dim SEQNO, Ftype, sCode, RefCode As String
        Dim sfileName As String = ""

        RefCode = "Q" & ConvertDate2DBString(Now.Date) & ConvertTimeToString(Now())
        sCode = "Q2"
        UploadDirectory = Server.MapPath("~/imageUploads/POST/" & hdLocationUID.Value)

        If Not Directory.Exists(UploadDirectory) Then
            Directory.CreateDirectory(UploadDirectory)
        End If

        If FileUploadQAResponse.HasFiles Then
            For Each uploadedFile As HttpPostedFile In FileUploadQAResponse.PostedFiles
                Dim fileExtname As String = Path.GetExtension(uploadedFile.FileName).ToLower()
                If fileExtname <> ".jpg" And fileExtname <> ".jpeg" And fileExtname <> ".png" And fileExtname <> ".pdf" And fileExtname <> ".doc" And fileExtname <> ".docx" Then
                    ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','ไฟล์รูปภาพต้องมีนามสกุล .jpg, .jpeg, .png,.doc,.docx,.pdf เท่านั้น');", True)
                    Exit Sub
                End If
                If (uploadedFile.ContentLength / 1024) > 2048 Then
                    ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','ไฟล์มีขนาดใหญ่เกิน 2048 Kb. ไม่สามารถอัพโหลดได้');", True)
                    Exit Sub
                End If
                Select Case fileExtname
                    Case ".jpg", ".jpeg", ".png"
                        Ftype = "img"
                    Case Else
                        Ftype = "file"
                End Select

                SEQNO = ctlM.PostAuditFile_GetLastSEQ(RefCode, sCode)
                sfileName = RefCode & sCode & "_" & SEQNO.ToString() & fileExtname

                Dim objfile As FileInfo = New FileInfo(UploadDirectory & sfileName)
                If objfile.Exists Then
                    objfile.Delete()
                End If
                uploadedFile.SaveAs(System.IO.Path.Combine(UploadDirectory, sfileName))
                ctlM.PostAuditFile_Save(RefCode, StrNull2Zero(hdPostUID.Value), StrNull2Zero(hdLocationUID.Value), sCode, SEQNO, sfileName, Ftype, Request.Cookies("UserID").Value)
            Next
        End If
        LoadImgQAResponse()
    End Sub

    Private Sub dtlImgQAResponse_ItemCommand(source As Object, e As DataListCommandEventArgs) Handles dtlImgQAResponse.ItemCommand
        If TypeOf e.CommandSource Is WebControls.ImageButton Then
            Dim ButtonPressed As WebControls.ImageButton = e.CommandSource
            Select Case ButtonPressed.ID
                Case "imgView"
                    Dim str() As String
                    str = Split(e.CommandArgument(), ".")
                    Select Case Left(str(1), 3)
                        Case "jpg", "jpe", "png"
                            PreviewPostPicture("", "", e.CommandArgument())
                        Case Else
                            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "Modal", "window.open('" & e.CommandArgument() & "','_blank');", True)
                    End Select
                Case "imgDel"
                    DeleteImage(e.CommandArgument)
                    ctlM.PostAuditFile_Delete(e.CommandArgument)
                    LoadImgQAResponse()
            End Select
        End If
    End Sub

    Private Sub dtlImgQAResponse_ItemDataBound(sender As Object, e As DataListItemEventArgs) Handles dtlImgQAResponse.ItemDataBound
        If e.Item.ItemType = ListItemType.AlternatingItem Or e.Item.ItemType = ListItemType.Item Then
            Dim scriptString As String = "javascript:return confirm(""ต้องการลบ ข้อมูลนี้ ?"");"
            Dim imgD As ImageButton = e.Item.FindControl("imgDel")
            imgD.Attributes.Add("onClick", scriptString)

        End If
        If e.Item.ItemType = DataControlRowType.DataRow Then
            e.Item.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#d0e8ff';")
            e.Item.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;")

        End If
    End Sub

    Private Sub cmdUploadCIInform_Click(sender As Object, e As EventArgs) Handles cmdUploadCIInform.Click
        Dim SEQNO, Ftype, sCode, RefCode As String
        Dim sfileName As String = ""

        RefCode = "C" & ConvertDate2DBString(Now.Date) & ConvertTimeToString(Now())
        sCode = "C1"
        UploadDirectory = Server.MapPath("~/imageUploads/POST/" & hdLocationUID.Value)

        If Not Directory.Exists(UploadDirectory) Then
            Directory.CreateDirectory(UploadDirectory)
        End If

        If FileUploadCIInform.HasFiles Then
            For Each uploadedFile As HttpPostedFile In FileUploadCIInform.PostedFiles
                Dim fileExtname As String = Path.GetExtension(uploadedFile.FileName).ToLower()
                If fileExtname <> ".jpg" And fileExtname <> ".jpeg" And fileExtname <> ".png" And fileExtname <> ".pdf" And fileExtname <> ".doc" And fileExtname <> ".docx" Then
                    ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','ไฟล์รูปภาพต้องมีนามสกุล .jpg, .jpeg, .png,.doc,.docx,.pdf เท่านั้น');", True)
                    Exit Sub
                End If
                If (uploadedFile.ContentLength / 1024) > 2048 Then
                    ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','ไฟล์มีขนาดใหญ่เกิน 2048 Kb. ไม่สามารถอัพโหลดได้');", True)
                    Exit Sub
                End If
                Select Case fileExtname
                    Case ".jpg", ".jpeg", ".png"
                        Ftype = "img"
                    Case Else
                        Ftype = "file"
                End Select

                SEQNO = ctlM.PostAuditFile_GetLastSEQ(RefCode, sCode)
                sfileName = RefCode & sCode & "_" & SEQNO.ToString() & fileExtname

                Dim objfile As FileInfo = New FileInfo(UploadDirectory & sfileName)
                If objfile.Exists Then
                    objfile.Delete()
                End If
                uploadedFile.SaveAs(System.IO.Path.Combine(UploadDirectory, sfileName))
                ctlM.PostAuditFile_Save(RefCode, StrNull2Zero(hdPostUID.Value), StrNull2Zero(hdLocationUID.Value), sCode, SEQNO, sfileName, Ftype, Request.Cookies("UserID").Value)
            Next
        End If
        LoadImgCIInform()
    End Sub

    Private Sub dtlImgCIInform_ItemCommand(source As Object, e As DataListCommandEventArgs) Handles dtlImgCIInform.ItemCommand
        If TypeOf e.CommandSource Is WebControls.ImageButton Then
            Dim ButtonPressed As WebControls.ImageButton = e.CommandSource
            Select Case ButtonPressed.ID
                Case "imgView"
                    Dim str() As String
                    str = Split(e.CommandArgument(), ".")
                    Select Case Left(str(1), 3)
                        Case "jpg", "jpe", "png"
                            PreviewPostPicture("", "", e.CommandArgument())
                        Case Else
                            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "Modal", "window.open('" & e.CommandArgument() & "','_blank');", True)
                    End Select
                Case "imgDel"
                    DeleteImage(e.CommandArgument)
                    ctlM.PostAuditFile_Delete(e.CommandArgument)
                    LoadImgCIInform()
            End Select
        End If
    End Sub

    Private Sub dtlImgCIInform_ItemDataBound(sender As Object, e As DataListItemEventArgs) Handles dtlImgCIInform.ItemDataBound
        If e.Item.ItemType = ListItemType.AlternatingItem Or e.Item.ItemType = ListItemType.Item Then
            Dim scriptString As String = "javascript:return confirm(""ต้องการลบ ข้อมูลนี้ ?"");"
            Dim imgD As ImageButton = e.Item.FindControl("imgDel")
            imgD.Attributes.Add("onClick", scriptString)

        End If
        If e.Item.ItemType = DataControlRowType.DataRow Then
            e.Item.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#d0e8ff';")
            e.Item.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;")

        End If
    End Sub

    Private Sub cmdUploadCIResponse_Click(sender As Object, e As EventArgs) Handles cmdUploadCIResponse.Click
        Dim SEQNO, Ftype, sCode, RefCode As String
        Dim sfileName As String = ""

        RefCode = "C" & ConvertDate2DBString(Now.Date) & ConvertTimeToString(Now())
        sCode = "C2"
        UploadDirectory = Server.MapPath("~/imageUploads/POST/" & hdLocationUID.Value)

        If Not Directory.Exists(UploadDirectory) Then
            Directory.CreateDirectory(UploadDirectory)
        End If

        If FileUploadCIResponse.HasFiles Then
            For Each uploadedFile As HttpPostedFile In FileUploadCIResponse.PostedFiles
                Dim fileExtname As String = Path.GetExtension(uploadedFile.FileName).ToLower()
                If fileExtname <> ".jpg" And fileExtname <> ".jpeg" And fileExtname <> ".png" And fileExtname <> ".pdf" And fileExtname <> ".doc" And fileExtname <> ".docx" Then
                    ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','ไฟล์รูปภาพต้องมีนามสกุล .jpg, .jpeg, .png,.doc,.docx,.pdf เท่านั้น');", True)
                    Exit Sub
                End If
                If (uploadedFile.ContentLength / 1024) > 2048 Then
                    ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','ไฟล์มีขนาดใหญ่เกิน 2048 Kb. ไม่สามารถอัพโหลดได้');", True)
                    Exit Sub
                End If
                Select Case fileExtname
                    Case ".jpg", ".jpeg", ".png"
                        Ftype = "img"
                    Case Else
                        Ftype = "file"
                End Select

                SEQNO = ctlM.PostAuditFile_GetLastSEQ(RefCode, sCode)
                sfileName = RefCode & sCode & "_" & SEQNO.ToString() & fileExtname

                Dim objfile As FileInfo = New FileInfo(UploadDirectory & sfileName)
                If objfile.Exists Then
                    objfile.Delete()
                End If
                uploadedFile.SaveAs(System.IO.Path.Combine(UploadDirectory, sfileName))
                ctlM.PostAuditFile_Save(RefCode, StrNull2Zero(hdPostUID.Value), StrNull2Zero(hdLocationUID.Value), sCode, SEQNO, sfileName, Ftype, Request.Cookies("UserID").Value)
            Next
        End If
        LoadImgCIResponse()
    End Sub

    Private Sub dtlImgCIResponse_ItemCommand(source As Object, e As DataListCommandEventArgs) Handles dtlImgCIResponse.ItemCommand
        If TypeOf e.CommandSource Is WebControls.ImageButton Then
            Dim ButtonPressed As WebControls.ImageButton = e.CommandSource
            Select Case ButtonPressed.ID
                Case "imgView"
                    Dim str() As String
                    str = Split(e.CommandArgument(), ".")
                    Select Case Left(str(1), 3)
                        Case "jpg", "jpe", "png"
                            PreviewPostPicture("", "", e.CommandArgument())
                        Case Else
                            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "Modal", "window.open('" & e.CommandArgument() & "','_blank');", True)
                    End Select
                Case "imgDel"
                    DeleteImage(e.CommandArgument)
                    ctlM.PostAuditFile_Delete(e.CommandArgument)
                    LoadImgCIResponse()
            End Select
        End If
    End Sub

    Private Sub dtlImgCIResponse_ItemDataBound(sender As Object, e As DataListItemEventArgs) Handles dtlImgCIResponse.ItemDataBound
        If e.Item.ItemType = ListItemType.AlternatingItem Or e.Item.ItemType = ListItemType.Item Then
            Dim scriptString As String = "javascript:return confirm(""ต้องการลบ ข้อมูลนี้ ?"");"
            Dim imgD As ImageButton = e.Item.FindControl("imgDel")
            imgD.Attributes.Add("onClick", scriptString)

        End If
        If e.Item.ItemType = DataControlRowType.DataRow Then
            e.Item.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#d0e8ff';")
            e.Item.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;")

        End If
    End Sub

    Private Sub cmdDelete_Click(sender As Object, e As EventArgs) Handles cmdDelete.Click
        ctlA.PostAudit_Delete(StrNull2Zero(hdPostUID.Value))

        hdPostUID.Value = ""
        Response.Redirect("PostAudit.aspx?m=po&s=list&t=del&lid=" & hdLocationUID.Value)
    End Sub

    Private Sub cmdUploadQAResult_Click(sender As Object, e As EventArgs) Handles cmdUploadQAResult.Click
        Dim SEQNO, Ftype, sCode, RefCode As String
        Dim sfileName As String = ""

        RefCode = "Q" & ConvertDate2DBString(Now.Date) & ConvertTimeToString(Now())
        sCode = "Q3"
        UploadDirectory = Server.MapPath("~/imageUploads/POST/" & hdLocationUID.Value)

        If Not Directory.Exists(UploadDirectory) Then
            Directory.CreateDirectory(UploadDirectory)
        End If

        If FileUploadQAResult.HasFiles Then
            For Each uploadedFile As HttpPostedFile In FileUploadQAResult.PostedFiles
                Dim fileExtname As String = Path.GetExtension(uploadedFile.FileName).ToLower()
                If fileExtname <> ".jpg" And fileExtname <> ".jpeg" And fileExtname <> ".png" And fileExtname <> ".pdf" And fileExtname <> ".doc" And fileExtname <> ".docx" Then
                    ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','ไฟล์รูปภาพต้องมีนามสกุล .jpg, .jpeg, .png,.doc,.docx,.pdf เท่านั้น');", True)
                    Exit Sub
                End If
                If (uploadedFile.ContentLength / 1024) > 2048 Then
                    ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','ไฟล์มีขนาดใหญ่เกิน 2048 Kb. ไม่สามารถอัพโหลดได้');", True)
                    Exit Sub
                End If
                Select Case fileExtname
                    Case ".jpg", ".jpeg", ".png"
                        Ftype = "img"
                    Case Else
                        Ftype = "file"
                End Select

                SEQNO = ctlM.PostAuditFile_GetLastSEQ(RefCode, sCode)
                sfileName = RefCode & sCode & "_" & SEQNO.ToString() & fileExtname

                Dim objfile As FileInfo = New FileInfo(UploadDirectory & sfileName)
                If objfile.Exists Then
                    objfile.Delete()
                End If
                uploadedFile.SaveAs(System.IO.Path.Combine(UploadDirectory, sfileName))
                ctlM.PostAuditFile_Save(RefCode, StrNull2Zero(hdPostUID.Value), StrNull2Zero(hdLocationUID.Value), sCode, SEQNO, sfileName, Ftype, Request.Cookies("UserID").Value)
            Next
        End If
        LoadImgQAResult()
    End Sub
    Private Sub LoadImgQAResult()
        dt = ctlM.PostAuditFile_Get(hdPostUID.Value, "Q3")
        dtlImgQAResult.DataSource = dt
        dtlImgQAResult.DataBind()
    End Sub
    Private Sub dtlImgQAResult_ItemCommand(source As Object, e As DataListCommandEventArgs) Handles dtlImgQAResult.ItemCommand
        If TypeOf e.CommandSource Is WebControls.ImageButton Then
            Dim ButtonPressed As WebControls.ImageButton = e.CommandSource
            Select Case ButtonPressed.ID
                Case "imgView"
                    Dim str() As String
                    str = Split(e.CommandArgument(), ".")
                    Select Case Left(str(1), 3)
                        Case "jpg", "jpe", "png"
                            PreviewPostPicture("", "", e.CommandArgument())
                        Case Else
                            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "Modal", "window.open('" & e.CommandArgument() & "','_blank');", True)
                    End Select
                Case "imgDel"
                    DeleteImage(e.CommandArgument)
                    ctlM.PostAuditFile_Delete(e.CommandArgument)
                    LoadImgQAResult()
            End Select
        End If
    End Sub

    Private Sub dtlImgQAResult_ItemDataBound(sender As Object, e As DataListItemEventArgs) Handles dtlImgQAResult.ItemDataBound
        If e.Item.ItemType = ListItemType.AlternatingItem Or e.Item.ItemType = ListItemType.Item Then
            Dim scriptString As String = "javascript:return confirm(""ต้องการลบ ข้อมูลนี้ ?"");"
            Dim imgD As ImageButton = e.Item.FindControl("imgDel")
            imgD.Attributes.Add("onClick", scriptString)

        End If
        If e.Item.ItemType = DataControlRowType.DataRow Then
            e.Item.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#d0e8ff';")
            e.Item.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;")

        End If
    End Sub


    Private Sub cmdUploadCIResult_Click(sender As Object, e As EventArgs) Handles cmdUploadCIResult.Click
        Dim SEQNO, Ftype, sCode, RefCode As String
        Dim sfileName As String = ""

        RefCode = "C" & ConvertDate2DBString(Now.Date) & ConvertTimeToString(Now())
        sCode = "C3"
        UploadDirectory = Server.MapPath("~/imageUploads/POST/" & hdLocationUID.Value)

        If Not Directory.Exists(UploadDirectory) Then
            Directory.CreateDirectory(UploadDirectory)
        End If

        If FileUploadCIResult.HasFiles Then
            For Each uploadedFile As HttpPostedFile In FileUploadCIResult.PostedFiles
                Dim fileExtname As String = Path.GetExtension(uploadedFile.FileName).ToLower()
                If fileExtname <> ".jpg" And fileExtname <> ".jpeg" And fileExtname <> ".png" And fileExtname <> ".pdf" And fileExtname <> ".doc" And fileExtname <> ".docx" Then
                    ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','ไฟล์รูปภาพต้องมีนามสกุล .jpg, .jpeg, .png,.doc,.docx,.pdf เท่านั้น');", True)
                    Exit Sub
                End If
                If (uploadedFile.ContentLength / 1024) > 2048 Then
                    ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','ไฟล์มีขนาดใหญ่เกิน 2048 Kb. ไม่สามารถอัพโหลดได้');", True)
                    Exit Sub
                End If
                Select Case fileExtname
                    Case ".jpg", ".jpeg", ".png"
                        Ftype = "img"
                    Case Else
                        Ftype = "file"
                End Select

                SEQNO = ctlM.PostAuditFile_GetLastSEQ(RefCode, sCode)
                sfileName = RefCode & sCode & "_" & SEQNO.ToString() & fileExtname

                Dim objfile As FileInfo = New FileInfo(UploadDirectory & sfileName)
                If objfile.Exists Then
                    objfile.Delete()
                End If
                uploadedFile.SaveAs(System.IO.Path.Combine(UploadDirectory, sfileName))
                ctlM.PostAuditFile_Save(RefCode, StrNull2Zero(hdPostUID.Value), StrNull2Zero(hdLocationUID.Value), sCode, SEQNO, sfileName, Ftype, Request.Cookies("UserID").Value)
            Next
        End If
        LoadImgCIResult()
    End Sub
    Private Sub LoadImgCIResult()
        dt = ctlM.PostAuditFile_Get(hdPostUID.Value, "C3")
        dtlImgCIResult.DataSource = dt
        dtlImgCIResult.DataBind()
    End Sub
    Private Sub dtlImgCIResult_ItemCommand(source As Object, e As DataListCommandEventArgs) Handles dtlImgCIResult.ItemCommand
        If TypeOf e.CommandSource Is WebControls.ImageButton Then
            Dim ButtonPressed As WebControls.ImageButton = e.CommandSource
            Select Case ButtonPressed.ID
                Case "imgView"
                    Dim str() As String
                    str = Split(e.CommandArgument(), ".")
                    Select Case Left(str(1), 3)
                        Case "jpg", "jpe", "png"
                            PreviewPostPicture("", "", e.CommandArgument())
                        Case Else
                            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "Modal", "window.open('" & e.CommandArgument() & "','_blank');", True)
                    End Select
                Case "imgDel"
                    DeleteImage(e.CommandArgument)
                    ctlM.PostAuditFile_Delete(e.CommandArgument)
                    LoadImgCIResult()
            End Select
        End If
    End Sub

    Private Sub dtlImgCIResult_ItemDataBound(sender As Object, e As DataListItemEventArgs) Handles dtlImgCIResult.ItemDataBound
        If e.Item.ItemType = ListItemType.AlternatingItem Or e.Item.ItemType = ListItemType.Item Then
            Dim scriptString As String = "javascript:return confirm(""ต้องการลบ ข้อมูลนี้ ?"");"
            Dim imgD As ImageButton = e.Item.FindControl("imgDel")
            imgD.Attributes.Add("onClick", scriptString)

        End If
        If e.Item.ItemType = DataControlRowType.DataRow Then
            e.Item.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#d0e8ff';")
            e.Item.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;")

        End If
    End Sub

    Private Sub chkAccPharm_CheckedChanged(sender As Object, e As EventArgs) Handles chkAccPharm.CheckedChanged
        If cmdCreate.Visible = False Then
            If chkAccPharm.Checked = True Then
                pnQA.Visible = True
            Else
                pnQA.Visible = False
            End If
        End If
    End Sub

    Private Sub chkCI_CheckedChanged(sender As Object, e As EventArgs) Handles chkCI.CheckedChanged
        If cmdCreate.Visible = False Then
            If chkCI.Checked = True Then
                pnCI.Visible = True
            Else
                pnCI.Visible = False
            End If
        End If
    End Sub
End Class

