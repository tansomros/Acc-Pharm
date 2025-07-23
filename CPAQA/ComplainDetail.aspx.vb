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
Imports System.Runtime.InteropServices

Public Class ComplainDetail
    Inherits System.Web.UI.Page
    Dim dt As New DataTable
    Dim ctlC As New ComplainController
    Dim ctlM As New MasterController
    Private UploadDirectory As String
    Dim ctlMd As New MediaController
    Dim ctlU As New UserController
    Dim ctlL As New LocationController

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
            UploadDirectory = Server.MapPath("~/imageUploads/CMP/")
            txtReceiveDate.Text = DisplayShortDateTH(Now.Date())
            pnLoc.Visible = False

            LoadChannelToDDL()
            LoadProvinceToDDL()
            LoadPharmacyToDDL()
            LoadProblemToDDL()
            LoadLocationProject()
            LoadComplainSubject()
            LoadUserAdmin()

            ddlCloseBy.SelectedValue = Request.Cookies("userid").Value

            If Not Request("id") = Nothing Then
                EditComplainData(Request("id"))
                LoadImg1()
                LoadImg2()
                LoadImg3()
                LoadImg4()
            Else 'Add New
                DeleteImageNull()
                hdRefCode.Value = "C" & ConvertDate2DBString(Now.Date) & ConvertTimeToString(Now()) '& Now.Millisecond.ToString("00")
            End If

            If (Not Request("t") = Nothing) And (Request("t") = "del") Then
                ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalSuccess(this,'Success','ลบข้อมูลเรียบร้อย');", True)
            End If

        End If
        txtRound.Attributes.Add("OnKeyPress", "return AllowOnlyIntegers();")
        txtEmail.Attributes.Add("OnKeyPress", "return NotAllowThai();")
        cmdDelete.Attributes.Add("onClick", "javascript:return confirm(""ต้องการลบข้อร้องเรียนนี้ ใช่หรือไม่?"");")
    End Sub
    Private Sub DeleteImageNull()
        dt = ctlMd.ComplainFile_GetNull(StrNull2Zero(Request.Cookies("userid").Value))
        If dt.Rows.Count > 0 Then
            For i = 0 To dt.Rows.Count - 1
                Dim objfile As FileInfo = New FileInfo(Server.MapPath("~/imageUploads/CMP/" & dt.Rows(i)("FilePath")))
                If objfile.Exists Then
                    objfile.Delete()
                End If
                ctlMd.ComplainFile_Delete(dt.Rows(i)("UID"))
            Next
        End If
    End Sub

    Function checkField(tD As DataTable, ColumnName As String) As String
        If tD.Columns(ColumnName) IsNot Nothing Then
            Return String.Concat(tD.Rows(0)(ColumnName))
        Else
            Return ""
        End If
    End Function
    Private Sub LoadChannelToDDL()
        dt = ctlM.ReferenceValue_GetByDomainCode("CMPCHN")
        If dt.Rows.Count > 0 Then
            With ddlChannel
                .Enabled = True
                .DataSource = dt
                .DataTextField = "Descriptions"
                .DataValueField = "ValueCode"
                .DataBind()
                '.SelectedIndex = 0
            End With
        End If
        dt = Nothing
    End Sub
    Private Sub LoadPharmacyToDDL()
        dt = ctlL.Location_GetForCCR
        If dt.Rows.Count > 0 Then
            With ddlPharmacy
                .Enabled = True
                .DataSource = dt
                .DataTextField = "LocationName"
                .DataValueField = "LocationUID"
                .DataBind()
                '.SelectedIndex = 0
            End With
        End If
        dt = Nothing
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
            With ddlProvinceLocation
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
    Private Sub LoadProblemToDDL()
        dt = ctlM.ReferenceValue_GetByDomainCode("CMPPROB")
        If dt.Rows.Count > 0 Then
            With ddlProblem
                .Enabled = True
                .DataSource = dt
                .DataTextField = "Descriptions"
                .DataValueField = "Valuecode"
                .DataBind()
            End With
        End If
        dt = Nothing
    End Sub

    Private Sub LoadLocationProject()
        dt = ctlM.ReferenceValue_GetByDomainCode("CMPPROJ")
        If dt.Rows.Count > 0 Then
            With ddlProject
                .Enabled = True
                .DataSource = dt
                .DataTextField = "Descriptions"
                .DataValueField = "Valuecode"
                .DataBind()
            End With
        End If
        dt = Nothing
    End Sub
    Private Sub LoadComplainSubject()
        dt = ctlM.ReferenceValue_GetByDomainCode("CMPSUBJ")
        If dt.Rows.Count > 0 Then
            With chkComp
                .Enabled = True
                .DataSource = dt
                .DataTextField = "Descriptions"
                .DataValueField = "Valuecode"
                .DataBind()
            End With
        End If
        dt = Nothing
    End Sub
    Private Sub LoadUserAdmin()
        dt = ctlU.User_GetComplainAdmin
        If dt.Rows.Count > 0 Then
            With ddlCloseBy
                .Enabled = True
                .DataSource = dt
                .DataTextField = "DisplayName"
                .DataValueField = "UserID"
                .DataBind()
            End With
        End If
        dt = Nothing
    End Sub
    Private Sub EditComplainData(ByVal pID As String)
        Dim dtL As New DataTable
        dtL = ctlC.Complain_GetByUID(pID)
        If dtL.Rows.Count > 0 Then
            With dtL.Rows(0)
                hdUID.Value = .Item("UID")
                hdRefCode.Value = String.Concat(.Item("Code"))
                lblCMPNO.Text = String.Concat(.Item("CMPNO"))
                UploadDirectory = Server.MapPath("~/imageUploads/CMP/")
                If Not Directory.Exists(UploadDirectory) Then
                    Directory.CreateDirectory(UploadDirectory)
                End If

                ddlChannel.SelectedValue = String.Concat(.Item("CMPCHN"))
                txtInformer.Text = String.Concat(.Item("CompName"))
                txtTel.Text = String.Concat(.Item("CompTel"))
                txtEmail.Text = String.Concat(.Item("CompEmail"))
                txtInformerAddress.Text = String.Concat(.Item("CompCompany"))
                ddlProvince.SelectedValue = String.Concat(.Item("CompProvinceID"))
                ddlPharmacy.SelectedValue = String.Concat(.Item("LocationUID"))

                If String.Concat(.Item("LocationUID")) = "0" Then
                    txtLocationName.Text = String.Concat(.Item("LocationName"))
                    txtLocationAddress.Text = String.Concat(.Item("LocationAddress"))
                    ddlProvinceLocation.SelectedValue = String.Concat(.Item("LocationProvinceID"))
                    pnPharm.Visible = False
                    pnLoc.Visible = True
                Else
                    pnPharm.Visible = True
                    pnLoc.Visible = False
                    lblLicense.Text = String.Concat(.Item("LicenseNo1"))
                    lblAccLicense.Text = String.Concat(.Item("AccLicense"))
                    lblAddress.Text = String.Concat(.Item("LocationAddress2"))
                    lblNHSOCode.Text = String.Concat(.Item("NHSOCode"))

                    txtLocationName.Text = String.Concat(.Item("LocationName2"))
                    txtLocationAddress.Text = String.Concat(.Item("LocationAddress2"))
                    ddlProvinceLocation.SelectedValue = String.Concat(.Item("ProvinceID"))

                End If

                txtReceiver.Text = String.Concat(.Item("ReceiptName"))
                txtReceiverPos.Text = String.Concat(.Item("ReceiptPosition"))
                txtReceiveDate.Text = ConvertStrDate2ShortTH(String.Concat(.Item("ReceiptDate")))

                txtCCRDetail.Text = String.Concat(.Item("ComplaintDetail"))
                optEvidence.SelectedValue = String.Concat(.Item("IsEvidence"))
                ddlProblem.SelectedValue = String.Concat(.Item("CMPPROB"))
                txtProblemOther.Text = String.Concat(.Item("ProblemRemark"))
                optRefer.SelectedValue = String.Concat(.Item("IsSendPharm"))
                txtReferDate.Text = ConvertStrDate2ShortTH(String.Concat(.Item("SendDate")))
                txtReferRemark.Text = String.Concat(.Item("SendRemark"))
                ddlProject.SelectedValue = String.Concat(.Item("CMPPROJ"))
                txtProjectOther.Text = String.Concat(.Item("ProjectOther"))

                txtComplaint.Text = String.Concat(.Item("CompRemark"))
                txtTeamDate.Text = ConvertStrDate2ShortTH(String.Concat(.Item("SendSeekDate")))
                txtTeamRemark.Text = String.Concat(.Item("SeekRemark"))
                txtFindRemark.Text = String.Concat(.Item("SeekDetail"))


                txtResultDate.Text = ConvertStrDate2ShortTH(String.Concat(.Item("SummaryDate")))
                txtSubCommDate.Text = ConvertStrDate2ShortTH(String.Concat(.Item("SubCommitteeDate")))

                optResult.SelectedValue = String.Concat(.Item("SummaryResult"))
                optLevel.SelectedValue = String.Concat(.Item("ImpactLevel"))

                txtRemark.Text = String.Concat(.Item("SummaryRemark"))
                txtCautionBy.Text = String.Concat(.Item("CautionBy"))
                txtNHSORemark.Text = String.Concat(.Item("NHSORemark"))
                txtStopDate.Text = ConvertStrDate2ShortTH(String.Concat(.Item("StopDate")))
                txtRound.Text = String.Concat(.Item("RounNo"))
                txtCommitteeDate.Text = ConvertStrDate2ShortTH(String.Concat(.Item("CommitteeDate")))

                optFinalResult.SelectedValue = String.Concat(.Item("FinalResult"))
                txtFinalRemark.Text = String.Concat(.Item("FinalRemark"))

                txtFinalDate.Text = ConvertStrDate2ShortTH(String.Concat(.Item("FinalDate")))
                txtCloseDate.Text = ConvertStrDate2ShortTH(String.Concat(.Item("CloseDate")))
                ddlCloseBy.SelectedValue = String.Concat(.Item("CloseUser"))

                txtCloseRemark.Text = String.Concat(.Item("CloseRemark"))

                If String.Concat(.Item("CloseStatus")) = "Y" Then
                    chkClose.Checked = True
                Else
                    chkClose.Checked = False
                End If

                LoadComplainProblem(StrNull2Zero(hdUID.Value))
                LoadComplainResult(StrNull2Zero(hdUID.Value))

                LoadImg1()
                LoadImg2()
                LoadImg3()
                LoadImg4()
            End With
        End If
        dtL = Nothing
    End Sub
    Private Sub LoadComplainProblem(CompUID As Integer)
        Dim dtC As New DataTable
        dtC = ctlC.ComplainProblem_Get(CompUID)
        If dtC.Rows.Count > 0 Then
            chkComp.ClearSelection()
            For i = 0 To chkComp.Items.Count - 1
                For n = 0 To dtC.Rows.Count - 1
                    If chkComp.Items(i).Value = dtC.Rows(n)("CMPPROB") Then
                        chkComp.Items(i).Selected = True
                    End If
                Next
            Next
        End If
    End Sub
    Private Sub LoadComplainResult(CompUID As Integer)
        Dim dtC As New DataTable
        dtC = ctlC.ComplainResult_Get(CompUID)
        If dtC.Rows.Count > 0 Then
            chkResult.ClearSelection()
            For i = 0 To chkResult.Items.Count - 1
                For n = 0 To dtC.Rows.Count - 1
                    If chkResult.Items(i).Value = dtC.Rows(n)("ResultUID") Then
                        chkResult.Items(i).Selected = True
                    End If
                Next
            Next
        End If
    End Sub

    Function Check_Email(str As String) As Boolean
        Return Regex.IsMatch(str, "\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*")
    End Function
    Protected Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click

        If txtInformer.Text.Trim() = "" Then
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','กรุณาระบุชื่อผู้ร้องเรียน');", True)
            Exit Sub
        End If
        'If txtTel.Text.Trim() = "" And txtEmail.Text = "" Then
        '    ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','กรุณาระบุเบอร์โทร/E-mail ผู้ร้องเรียน');", True)
        '    Exit Sub
        'End If

        If ddlPharmacy.SelectedIndex = 0 Then
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','กรุณาเลือกชื่อร้านยาที่ถูกร้องเรียน');", True)
            Exit Sub
        End If
        If ddlPharmacy.SelectedIndex = 1 And txtLocationName.Text = "" Then
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','กรุณาระบุชื่อร้าน/คลินิก/อื่นๆที่ถูกร้องเรียน');", True)
            Exit Sub
        End If

        If txtReceiver.Text = "" Then
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','กรุณาระบุชื่อผู้รับคำร้องเรียน');", True)
            Exit Sub
        End If

        If txtReceiveDate.Text = "" Then
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','กรุณาระบุวันที่รับร้องเรียน');", True)
            Exit Sub
        End If

        If txtCCRDetail.Text = "" Then
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','กรุณาระบุประเด็นปัญหา/ข้อร้องเรียน');", True)
            Exit Sub
        End If

        If optEvidence.SelectedValue = "" Then
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','กรุณาระบุหลักฐานการร้องเรียน');", True)
            Exit Sub
        End If

        If optEvidence.SelectedValue <> "X" Then
            If ddlProblem.SelectedValue = "0" And txtProblemOther.Text = "" Then
                ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','กรุณาระบุปัญหาที่ร้องเรียน');", True)
                Exit Sub
            End If

            If optRefer.SelectedValue = "" Then
                ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','กรุณาเลือกการส่งสำนักงานรับรองร้านยาคุณภาพ');", True)
                Exit Sub
            End If

            If optRefer.SelectedValue = "Y" And txtReferDate.Text = "" Then
                ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','กรุณาระบุวันที่ส่ง สรร.');", True)
                Exit Sub
            End If
            If optRefer.SelectedValue = "N" And txtReferRemark.Text = "" Then
                ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','กรุณาระบุเหตุผลที่ไม่ส่ง สรร./ปิดเรื่อง');", True)
                Exit Sub
            End If
        End If
        If ddlProject.SelectedValue = "99" And txtProjectOther.Text = "" Then
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','กรุณาระบุบริการ/โครงการอื่นๆ');", True)
            Exit Sub
        End If

        If txtEmail.Text <> "" Then
            If Check_Email(txtEmail.Text) = False Then
                ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningAlert(this,'ผลการตรวจสอบ','รูปแบบ E-mail ไม่ถูกต้อง กรุณาตรวจสอบ');", True)
                Exit Sub
            End If
        End If

        Dim IsReferPharm, ReferDate, ReferRemark As String
        ReferDate = ""
        ReferRemark = ""
        If optEvidence.SelectedValue = "X" Then
            IsReferPharm = "N"
        Else
            IsReferPharm = optRefer.SelectedValue
            ReferDate = ConvertStrDate2DBDate(txtReferDate.Text)
        End If
        ReferRemark = txtReferRemark.Text

        Dim CloseStatus As String = "N"
        If chkClose.Checked Then
            CloseStatus = "Y"
        Else
            CloseStatus = "N"
        End If

        If StrNull2Zero(hdUID.Value) = 0 Then
            lblCMPNO.Text = ctlM.RunningNumber_New(CODE_CMP)
        End If

        ctlC.Complain_Save(StrNull2Zero(hdUID.Value), lblCMPNO.Text, hdRefCode.Value, ConvertStrDate2DBDate(txtReceiveDate.Text), StrNull2Zero(ddlChannel.SelectedValue), txtInformer.Text, txtTel.Text, txtEmail.Text, txtInformerAddress.Text, StrNull2Zero(ddlProvince.SelectedValue), StrNull2Zero(ddlPharmacy.SelectedValue), txtReceiver.Text, txtReceiverPos.Text, ConvertStrDate2DBDate(txtReceiveDate.Text), txtCCRDetail.Text, optEvidence.SelectedValue, StrNull2Zero(ddlProblem.SelectedValue), txtProblemOther.Text, IsReferPharm, ReferDate, ReferRemark, StrNull2Zero(ddlProject.SelectedValue), txtProjectOther.Text, txtComplaint.Text, ConvertStrDate2DBDate(txtTeamDate.Text), txtTeamRemark.Text, txtFindRemark.Text, ConvertStrDate2DBDate(txtResultDate.Text), ConvertStrDate2DBDate(txtSubCommDate.Text), StrNull2Zero(optResult.SelectedValue), StrNull2Zero(optLevel.SelectedValue), txtRemark.Text, txtCautionBy.Text, txtNHSORemark.Text, ConvertStrDate2DBDate(txtStopDate.Text), StrNull2Zero(txtRound.Text), ConvertStrDate2DBDate(txtCommitteeDate.Text), StrNull2Zero(optFinalResult.SelectedValue), txtFinalRemark.Text, ConvertStrDate2DBDate(txtFinalDate.Text), CloseStatus, ConvertStrDate2DBDate(txtCloseDate.Text), StrNull2Zero(ddlCloseBy.SelectedValue), StrNull2Zero(Request.Cookies("userid").Value), txtLocationName.Text, txtLocationAddress.Text, StrNull2Zero(ddlProvinceLocation.SelectedValue), txtCloseRemark.Text)

        If StrNull2Zero(hdUID.Value) = 0 Then
            ctlM.RunningNumber_Update(CODE_CMP)

            hdUID.Value = ctlC.Complain_GetUID(hdRefCode.Value).ToString()
            ctlU.User_GenLogfile(Request.Cookies("UserID").Value, ACTTYPE_ADD, "Complain", "เพิ่มข้อร้องเรียนใหม่", "[ComplainUID=" & hdUID.Value & "]", Environment.MachineName, GetIPAddress())
        Else
            ctlU.User_GenLogfile(Request.Cookies("UserID").Value, ACTTYPE_UPD, "Complain", "แก้ไขข้อมูลข้อร้องเรียน", "[ComplainUID=" & hdUID.Value & "]", Environment.MachineName, GetIPAddress())
        End If

        'ctlC.ComplainProblem_Delete(StrNull2Zero(hdUID.Value))
        For i = 0 To chkComp.Items.Count - 1
            If chkComp.Items(i).Selected Then
                ctlC.ComplainProblem_Save(StrNull2Zero(hdUID.Value), chkComp.Items(i).Value, Request.Cookies("userid").Value)
            Else
                ctlC.ComplainProblem_Delete(StrNull2Zero(hdUID.Value), chkComp.Items(i).Value)
            End If
        Next

        For i = 0 To chkResult.Items.Count - 1
            If chkResult.Items(i).Selected Then
                ctlC.ComplainResult_Save(StrNull2Zero(hdUID.Value), chkResult.Items(i).Value, Request.Cookies("userid").Value)
            Else
                ctlC.ComplainResult_Delete(StrNull2Zero(hdUID.Value), chkResult.Items(i).Value)
            End If
        Next


        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalSuccess(this,'Success','บันทึกข้อมูลเรียบร้อย');", True)

    End Sub

    Protected Sub cmdUpload1_Click(sender As Object, e As EventArgs) Handles cmdUpload1.Click
        Dim SEQNO, Ftype As String
        Dim sfileName As String = ""

        UploadDirectory = Server.MapPath("imageUploads/CMP/")

        If Not Directory.Exists(UploadDirectory) Then
            Directory.CreateDirectory(UploadDirectory)
        End If

        If FileUpload1.HasFiles Then
            For Each uploadedFile As HttpPostedFile In FileUpload1.PostedFiles
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
                SEQNO = ctlMd.ComplainFile_GetLastSEQ(hdRefCode.Value, "A")
                sfileName = hdRefCode.Value & "A" & "_" & SEQNO.ToString() & fileExtname

                Dim objfile As FileInfo = New FileInfo(UploadDirectory & sfileName)
                If objfile.Exists Then
                    objfile.Delete()
                End If
                uploadedFile.SaveAs(System.IO.Path.Combine(UploadDirectory, sfileName))
                ctlMd.ComplainFile_Save(hdRefCode.Value, StrNull2Zero(hdUID.Value), "A", SEQNO, sfileName, Ftype, Request.Cookies("UserID").Value)
            Next
        End If
        LoadImg1()
    End Sub
    Private Sub LoadImg1()
        dt = ctlMd.ComplainFile_GetByRefCode(hdRefCode.Value, "A")
        dtlImg1.DataSource = dt
        dtlImg1.DataBind()
    End Sub

    Protected Sub cmdUpload2_Click(sender As Object, e As EventArgs) Handles cmdUpload2.Click
        Dim SEQNO, Ftype As String
        Dim sfileName As String = ""

        UploadDirectory = Server.MapPath("imageUploads/CMP/")

        If Not Directory.Exists(UploadDirectory) Then
            Directory.CreateDirectory(UploadDirectory)
        End If

        If FileUpload2.HasFiles Then
            For Each uploadedFile As HttpPostedFile In FileUpload2.PostedFiles
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
                SEQNO = ctlMd.ComplainFile_GetLastSEQ(hdRefCode.Value, "B")
                sfileName = hdRefCode.Value & "B" & "_" & SEQNO.ToString() & fileExtname

                Dim objfile As FileInfo = New FileInfo(UploadDirectory & sfileName)
                If objfile.Exists Then
                    objfile.Delete()
                End If
                uploadedFile.SaveAs(System.IO.Path.Combine(UploadDirectory, sfileName))
                ctlMd.ComplainFile_Save(hdRefCode.Value, StrNull2Zero(hdUID.Value), "B", SEQNO, sfileName, Ftype, Request.Cookies("UserID").Value)
            Next
        End If
        LoadImg2()
    End Sub
    Private Sub LoadImg2()
        dt = ctlMd.ComplainFile_GetByRefCode(hdRefCode.Value, "B")
        dtlImg2.DataSource = dt
        dtlImg2.DataBind()
    End Sub

    Protected Sub cmdUpload3_Click(sender As Object, e As EventArgs) Handles cmdUpload3.Click
        Dim SEQNO, Ftype As String
        Dim sfileName As String = ""

        UploadDirectory = Server.MapPath("imageUploads/CMP/")

        If Not Directory.Exists(UploadDirectory) Then
            Directory.CreateDirectory(UploadDirectory)
        End If

        If FileUpload3.HasFiles Then
            For Each uploadedFile As HttpPostedFile In FileUpload3.PostedFiles
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
                SEQNO = ctlMd.ComplainFile_GetLastSEQ(hdRefCode.Value, "C")
                sfileName = hdRefCode.Value & "C" & "_" & SEQNO.ToString() & fileExtname

                Dim objfile As FileInfo = New FileInfo(UploadDirectory & sfileName)
                If objfile.Exists Then
                    objfile.Delete()
                End If
                uploadedFile.SaveAs(System.IO.Path.Combine(UploadDirectory, sfileName))
                ctlMd.ComplainFile_Save(hdRefCode.Value, StrNull2Zero(hdUID.Value), "C", SEQNO, sfileName, Ftype, Request.Cookies("UserID").Value)
            Next
        End If
        LoadImg3()
    End Sub
    Private Sub LoadImg3()
        dt = ctlMd.ComplainFile_GetByRefCode(hdRefCode.Value, "C")
        dtlImg3.DataSource = dt
        dtlImg3.DataBind()
    End Sub


    Protected Sub cmdUpload4_Click(sender As Object, e As EventArgs) Handles cmdUpload4.Click
        Dim SEQNO, Ftype As String
        Dim sfileName As String = ""

        UploadDirectory = Server.MapPath("imageUploads/CMP/")

        If Not Directory.Exists(UploadDirectory) Then
            Directory.CreateDirectory(UploadDirectory)
        End If

        If FileUpload4.HasFiles Then
            For Each uploadedFile As HttpPostedFile In FileUpload4.PostedFiles
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
                SEQNO = ctlMd.ComplainFile_GetLastSEQ(hdRefCode.Value, "D")
                sfileName = hdRefCode.Value & "D" & "_" & SEQNO.ToString() & fileExtname

                Dim objfile As FileInfo = New FileInfo(UploadDirectory & sfileName)
                If objfile.Exists Then
                    objfile.Delete()
                End If
                uploadedFile.SaveAs(System.IO.Path.Combine(UploadDirectory, sfileName))
                ctlMd.ComplainFile_Save(hdRefCode.Value, StrNull2Zero(hdUID.Value), "D", SEQNO, sfileName, Ftype, Request.Cookies("UserID").Value)
            Next
        End If
        LoadImg4()
    End Sub
    Private Sub LoadImg4()
        dt = ctlMd.ComplainFile_GetByRefCode(hdRefCode.Value, "D")
        dtlImg4.DataSource = dt
        dtlImg4.DataBind()
    End Sub

    Private Sub DeleteImage(MediaUID As String)
        dt = ctlMd.ComplainFile_GetByID(MediaUID)
        If dt.Rows.Count > 0 Then
            Dim objfile As FileInfo = New FileInfo(Server.MapPath("~/imageUploads/CMP/" & dt.Rows(0)("FilePath")))
            If objfile.Exists Then
                objfile.Delete()
            End If
        End If
    End Sub
    Private Sub PreviewPicture(Fname As String, Desc As String, filePath As String)
        'Dim fPath As String = "imageUploads/CMP/Locations/" & hdLocationUID.Value & "/"
        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWindow(this,'" + Fname + "','" + Desc + "','" + filePath + "?v=" + ConvertDate2DBString(Now.Date) + ConvertTimeToString(Now()) + "');", True)
    End Sub

    Private Sub ddlPharmacy_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlPharmacy.SelectedIndexChanged
        Dim dtLoc As New DataTable
        If ddlPharmacy.SelectedIndex = 0 Then
            pnPharm.Visible = True
            pnLoc.Visible = False
            lblLicense.Text = ""
            lblAccLicense.Text = ""
            lblNHSOCode.Text = ""
            lblAddress.Text = ""
            txtLocationName.Text = ""
            txtLocationAddress.Text = ""
            ddlProvinceLocation.SelectedIndex = 0
        ElseIf ddlPharmacy.SelectedIndex = 1 Then
            pnPharm.Visible = False
            pnLoc.Visible = True
            txtLocationName.Text = ""
            txtLocationAddress.Text = ""
            ddlProvinceLocation.SelectedIndex = 0
        Else
            pnPharm.Visible = True
            pnLoc.Visible = False

            dtLoc = ctlL.Location_GetByUID(ddlPharmacy.SelectedValue)
            With dtLoc.Rows(0)
                lblLicense.Text = String.Concat(.Item("LicenseNo1"))
                lblAccLicense.Text = String.Concat(.Item("AccLicense"))
                lblNHSOCode.Text = String.Concat(.Item("NHSOCode"))
                lblAddress.Text = String.Concat(.Item("LocationAddress"))

                txtLocationName.Text = String.Concat(.Item("LocationName"))
                txtLocationAddress.Text = String.Concat(.Item("LocationAddress"))
                ddlProvinceLocation.SelectedValue = String.Concat(.Item("ProvinceID"))

            End With

        End If
        dtLoc = Nothing
    End Sub

    Private Sub dtlImg1_ItemCommand(source As Object, e As DataListCommandEventArgs) Handles dtlImg1.ItemCommand
        If TypeOf e.CommandSource Is WebControls.ImageButton Then
            Dim ButtonPressed As WebControls.ImageButton = e.CommandSource
            Select Case ButtonPressed.ID
                Case "imgView"
                    Dim str() As String
                    str = Split(e.CommandArgument(), ".")
                    Select Case Left(str(1), 3)
                        Case "jpg", "jpe", "png"
                            PreviewPicture("", "", e.CommandArgument())
                        Case Else
                            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "Modal", "window.open('" & e.CommandArgument() & "','_blank');", True)
                    End Select
                Case "imgDel"
                    DeleteImage(e.CommandArgument)
                    ctlMd.ComplainFile_Delete(e.CommandArgument)
                    LoadImg1()
            End Select
        End If
    End Sub

    Private Sub dtlImg1_ItemDataBound(sender As Object, e As DataListItemEventArgs) Handles dtlImg1.ItemDataBound
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

    Private Sub dtlImg2_ItemCommand(source As Object, e As DataListCommandEventArgs) Handles dtlImg2.ItemCommand
        If TypeOf e.CommandSource Is WebControls.ImageButton Then
            Dim ButtonPressed As WebControls.ImageButton = e.CommandSource
            Select Case ButtonPressed.ID
                Case "imgView"
                    Dim str() As String
                    str = Split(e.CommandArgument(), ".")
                    Select Case Left(str(1), 3)
                        Case "jpg", "jpe", "png"
                            PreviewPicture("", "", e.CommandArgument())
                        Case Else
                            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "Modal", "window.open('" & e.CommandArgument() & "','_blank');", True)
                    End Select
                Case "imgDel"
                    DeleteImage(e.CommandArgument)
                    ctlMd.ComplainFile_Delete(e.CommandArgument)
                    LoadImg2()
            End Select
        End If
    End Sub

    Private Sub dtlImg2_ItemDataBound(sender As Object, e As DataListItemEventArgs) Handles dtlImg2.ItemDataBound
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

    Private Sub dtlImg3_ItemCommand(source As Object, e As DataListCommandEventArgs) Handles dtlImg3.ItemCommand
        If TypeOf e.CommandSource Is WebControls.ImageButton Then
            Dim ButtonPressed As WebControls.ImageButton = e.CommandSource
            Select Case ButtonPressed.ID
                Case "imgView"
                    Dim str() As String
                    str = Split(e.CommandArgument(), ".")
                    Select Case Left(str(1), 3)
                        Case "jpg", "jpe", "png"
                            PreviewPicture("", "", e.CommandArgument())
                        Case Else
                            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "Modal", "window.open('" & e.CommandArgument() & "','_blank');", True)
                    End Select
                Case "imgDel"
                    DeleteImage(e.CommandArgument)
                    ctlMd.ComplainFile_Delete(e.CommandArgument)
                    LoadImg3()
            End Select
        End If
    End Sub

    Private Sub dtlImg3_ItemDataBound(sender As Object, e As DataListItemEventArgs) Handles dtlImg3.ItemDataBound
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

    Private Sub dtlImg4_ItemCommand(source As Object, e As DataListCommandEventArgs) Handles dtlImg4.ItemCommand
        If TypeOf e.CommandSource Is WebControls.ImageButton Then
            Dim ButtonPressed As WebControls.ImageButton = e.CommandSource
            Select Case ButtonPressed.ID
                Case "imgView"
                    Dim str() As String
                    str = Split(e.CommandArgument(), ".")
                    Select Case Left(str(1), 3)
                        Case "jpg", "jpe", "png"
                            PreviewPicture("", "", e.CommandArgument())
                        Case Else
                            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "Modal", "window.open('" & e.CommandArgument() & "','_blank');", True)
                    End Select
                Case "imgDel"
                    DeleteImage(e.CommandArgument)
                    ctlMd.ComplainFile_Delete(e.CommandArgument)
                    LoadImg4()
            End Select
        End If
    End Sub

    Private Sub dtlImg4_ItemDataBound(sender As Object, e As DataListItemEventArgs) Handles dtlImg4.ItemDataBound
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
        ctlC.Complain_Delete(hdUID.Value)
        dt = ctlMd.ComplainFile_GetByComplainUID(hdUID.Value)
        If dt.Rows.Count > 0 Then
            For i = 0 To dt.Rows.Count - 1
                Dim objfile As FileInfo = New FileInfo(Server.MapPath("~/imageUploads/CMP/" & dt.Rows(i)("FilePath")))
                If objfile.Exists Then
                    objfile.Delete()
                End If
            Next
        End If

        ctlMd.ComplainFile_DeleteByComplainUID(hdUID.Value)
        Response.Redirect("ComplainDetail.aspx?m=cmp&s=new&t=del")
    End Sub

End Class