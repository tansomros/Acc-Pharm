Imports System.Drawing
Imports System.IO
'Imports DevExpress.Web
'Imports DevExpress.Web.Internal
Imports System.Net
Imports System.Net.Http
Imports System.Net.Mail
Imports System.Security
Imports System.Threading.Tasks
Imports BigLion
Public Class RequestDetail
    Inherits System.Web.UI.Page
    Dim dt As New DataTable
    Dim ctlR As New RequestController
    Dim ctlA As New AssessmentController
    Dim ctlU As New UserController

    Private UploadDirectory As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsNothing(Request.Cookies("CPAQA")) Then
            Response.Redirect("Default.aspx")
        End If

        If Not IsPostBack Then
            cmdApprove.Visible = False
            cmdDelete.Visible = False
            cmdCancel.Visible = False
            cmdChangeType.Visible = False
            cmdWorkFlow.Visible = False

            pnDocument.Visible = False
            'pnPayment.Visible = False
            pnAudit.Visible = False
            pnAssignment.Visible = False
            pnCommentBack.Visible = False
            pnFinal.Visible = False
            hdLocationUID.Value = Request.Cookies("LoginLocationUID").Value

            txtAccLicense.Enabled = False
            'Request.Cookies("Requestimg")="blankimage.png"
            'Request.Cookies("Requestimg1") = ""
            'Request.Cookies("picname1") = ""
            'Request.Cookies("Requestimg2") = ""
            'Request.Cookies("picname2") = ""
            'Request.Cookies("Requestimg3") = ""
            'Request.Cookies("picname3") = ""
            'LoadRequestType()
            LoadTemplateTextToGrid()
            LoadStatusToDDL()

            If Request("id") Is Nothing Then
                Response.Redirect("Home")
            Else
                LoadRequestData()
                LoadAssessmentData()
                LoadDocumentCategory()
                LoadDocument()
                LoadSlip()
            End If

            If Convert.ToInt32(Request.Cookies("ROLE_ID").Value) = 1 Then
                cmdCancel.Visible = True
                'pnFinal.Visible = False
                pnLitigation.Visible = False
                ddlStatus.Enabled = False
                txtAppointmentDate.Enabled = False
                txtPassDate.Enabled = False
                txtSupervisorDate.Enabled = False
                txtAccLicense.Enabled = False
                txtStartDate.Enabled = False
                txtExpireDate.Enabled = False

                txtAppointmentDate.BackColor = Color.White
                txtPassDate.BackColor = Color.White
                txtSupervisorDate.BackColor = Color.White
                txtAccLicense.BackColor = Color.White
                txtStartDate.BackColor = Color.White
                txtExpireDate.BackColor = Color.White
                cmdAdd3Year.Enabled = False

            ElseIf Convert.ToInt32(Request.Cookies("ROLE_ID").Value) >= 2 Then
                pnLitigation.Visible = True
                pnDocument.Visible = True
                pnPayment.Visible = True
                pnAudit.Visible = True
                pnFinal.Visible = True
                cmdApprove.Visible = True
                pnCommentBack.Visible = True
                Dim ctlL As New LocationController
                lblLitigation.Text = ctlL.Location_GetLitigation(StrNull2Zero(hdLocationUID.Value))
                If Trim(lblLitigation.Text) = "" Or Trim(lblLitigation.Text) = "-" Then
                    pnLitigation.Visible = False
                End If
                LoadDocumentCategory()
            Else
                txtAuditorComment1.ReadOnly = True
                txtAuditorComment2.ReadOnly = True
                txtAuditorComment3.ReadOnly = True
                txtAuditorComment4.ReadOnly = True
                txtAuditorComment5.ReadOnly = True
                txtS.ReadOnly = True
                txtW.ReadOnly = True
                txtO.ReadOnly = True
                txtT.ReadOnly = True
                txtPassDate.Enabled = False
                txtAccLicense.ReadOnly = True
                txtSupervisorDate.ReadOnly = True
                txtStartDate.Enabled = False
                txtExpireDate.Enabled = False

                ddlStatus.Enabled = False
                cmdApprove.Visible = False
            End If
            If Convert.ToInt32(Request.Cookies("ROLE_ID").Value) >= 3 Then
                cmdCancel.Visible = True
                cmdDelete.Visible = True
                LoadSupervisorToDDL()
                pnAssignment.Visible = True
                LoadAssignSupervisorToGrid()

                cmdChangeType.Visible = True
                cmdWorkFlow.Visible = True
                LoadRequestTypeList(StrNull2Long(hdRequestUID.Value))
            End If
            'If Request.Cookies("ROLE_ADM") = False And Request.Cookies("ROLE_SPA") = False Then
            '    ddlOrganize.Enabled = False
            'Else
            '    ddlOrganize.Enabled = True
            'End If


            CheckStatusAssessment(StrNull2Long(hdRequestUID.Value))

        End If

        'cmdCancel.Attributes.Add("onClick", "javascript:return confirm(""คุณต้องการยกเลิกคำขอนี้ใช่หรือไม่?"");")
        cmdDelete.Attributes.Add("onClick", "javascript:return confirm(""ต้องการลบข้อมูลนี้ใช่หรือไม่?"");")

    End Sub
    Private Sub LoadRequestTypeList(ReqUID As Integer)
        Dim dtC As New DataTable
        dtC = ctlR.RequestTypeList_GetByRequestUID(ReqUID)
        If dtC.Rows.Count > 0 Then
            For i = 0 To dtC.Rows.Count - 1
                Select Case dtC.Rows(i)("RequestTypeUID")
                    Case 1
                        chkType1.Checked = True

                    Case 2
                        chkType2.Checked = True

                    Case 3
                        chkType3.Checked = True
                    Case 4
                        chkType4.Checked = True
                    Case 5
                        chkType5.Checked = True

                    Case 6
                        chkType6.Checked = True
                    Case 7
                        chkType7.Checked = True
                    Case 8
                        chkType8.Checked = True
                    Case 9
                        chkType9.Checked = True
                End Select

            Next

        End If
    End Sub
    Private Sub CheckStatusAssessment(RequestUID As Long)
        Dim iStatus As Integer = 0
        dt = ctlA.Assessment_GetStatus(RequestUID)
        If dt.Rows.Count > 0 Then
            iStatus = DBNull2Zero(dt.Rows(0)("StatusID"))
            lblAssessmentStatus.Text = String.Concat(dt.Rows(0)("AssessmentStatusName"))
            lblStatusRemark.Text = String.Concat(dt.Rows(0)("AssessmentRemark"))
            pnCancel.Visible = False

            If iStatus >= 10 And iStatus <= 55 Then ' Processing
                If Convert.ToInt32(Request.Cookies("ROLE_ID").Value) = 1 Then
                    btnAsmLocation.Visible = True
                    btnAsmGPP.Visible = True
                    btnAsmQA.Visible = True
                    btnAsmSelf.Visible = True
                    cmdAddFile.Enabled = True
                    cmdAddSlip.Enabled = True
                    FileUpload1.Enabled = True
                    FileUploadA.Enabled = True
                    If iStatus >= 30 Then
                        cmdCancel.Visible = False
                        cmdDelete.Visible = False
                    End If
                End If
            ElseIf iStatus >= 60 And iStatus <= 80 Then 'Passed
                If Convert.ToInt32(Request.Cookies("ROLE_ID").Value) = 1 Then
                    lblStatusRemark.Text = ""
                    btnAsmLocation.Text = "รายละเอียด"
                    btnAsmGPP.Text = "รายละเอียด"
                    btnAsmQA.Text = "รายละเอียด"
                    btnAsmSelf.Text = "รายละเอียด"
                    cmdAddFile.Enabled = False
                    cmdAddSlip.Enabled = False
                    FileUpload1.Enabled = False
                    FileUploadA.Enabled = False
                    grdDocument.Enabled = False
                    grdSlip.Enabled = False
                    cmdCancel.Visible = False
                    cmdSaveUpdate.Visible = False
                End If
            ElseIf iStatus = 0 Then 'ยกเลิก
                If Convert.ToInt32(Request.Cookies("ROLE_ID").Value) >= 3 Then
                    lblStatusRemark.Text = ""
                    btnAsmLocation.Text = "รายละเอียด"
                    btnAsmGPP.Text = "รายละเอียด"
                    btnAsmQA.Text = "รายละเอียด"
                    btnAsmSelf.Text = "รายละเอียด"
                    cmdAddFile.Enabled = True
                    cmdAddSlip.Enabled = True
                    FileUpload1.Enabled = True
                    FileUploadA.Enabled = True
                    cmdAssign.Enabled = True
                    cmdConfirmAssign.Visible = True
                    cmdConfirm.Visible = True
                    cmdSend.Visible = True
                    cmdSend.Text = "ส่งเรื่องพิจารณาอีกครั้ง"
                    cmdApprove.Visible = True
                    cmdApprove.Text = "บันทึก"
                    cmdCancel.Visible = True
                    cmdDelete.Visible = True
                    cmdSendBack.Visible = True
                    pnCancel.Visible = False
                    cmdSaveUpdate.Visible = True
                    txtAsmRemark.ReadOnly = False
                    txtAccRemark.ReadOnly = False
                Else
                    lblStatusRemark.Text = ""
                    btnAsmLocation.Text = "รายละเอียด"
                    btnAsmGPP.Text = "รายละเอียด"
                    btnAsmQA.Text = "รายละเอียด"
                    btnAsmSelf.Text = "รายละเอียด"
                    cmdAddFile.Enabled = False
                    cmdAddSlip.Enabled = False
                    FileUpload1.Enabled = False
                    FileUploadA.Enabled = False
                    cmdAssign.Enabled = False
                    cmdConfirmAssign.Visible = False
                    cmdConfirm.Visible = False
                    cmdSend.Visible = False
                    cmdApprove.Visible = False
                    cmdCancel.Visible = False
                    cmdDelete.Visible = False
                    cmdSendBack.Visible = False
                    pnCancel.Visible = True
                    cmdSaveUpdate.Visible = False
                    txtAsmRemark.ReadOnly = True
                    txtAccRemark.ReadOnly = True
                End If
            End If
        End If
    End Sub

    Private Sub LoadSupervisorToDDL()
        dt = ctlU.Supervisor_Get()
        If dt.Rows.Count > 0 Then
            With ddlSupervisor
                .DataSource = dt
                .DataTextField = "DisplayName"
                .DataValueField = "UserID"
                .DataBind()
            End With
        End If
    End Sub
    Private Sub LoadStatusToDDL()
        dt = ctlU.AssessmentStatus_Get()
        If dt.Rows.Count > 0 Then
            With ddlStatus
                .DataSource = dt
                .DataTextField = "Descriptions"
                .DataValueField = "ValueCode"
                .DataBind()
            End With

            With ddlStatusBack
                .DataSource = dt
                .DataTextField = "Descriptions"
                .DataValueField = "ValueCode"
                .DataBind()
            End With

        End If
    End Sub
    Private Sub LoadTemplateTextToGrid()
        Dim ctlM As New MasterController
        dt = ctlM.TemplateText_Get()
        If dt.Rows.Count > 0 Then
            With grdTemplate
                .Visible = True
                .DataSource = dt
                .DataBind()
            End With
        Else
            grdTemplate.Visible = False
        End If
    End Sub

    'Private Sub LoadRequestTypeList(ReqUID As Integer)
    '    Dim dtC As New DataTable
    '    Dim AmountFee As Double = 0
    '    dtC = ctlR.RequestTypeList_GetByRequestUID(ReqUID)
    '    If dtC.Rows.Count > 0 Then
    '        For i = 0 To dtC.Rows.Count - 1
    '            AmountFee = AmountFee + StrNull2Double(dtC.Rows(i)("Fee"))
    '        Next
    '        txtAmount.Text = AmountFee.ToString("#,###.##")
    '    End If
    'End Sub


    Private Sub LoadRequestData()
        dt = ctlR.Request_GetByUID(Request("id"))
        If dt.Rows.Count > 0 Then
            With dt.Rows(0)
                hdRequestUID.Value = String.Concat(.Item("UID"))
                hdLocationUID.Value = String.Concat(.Item("LocationUID"))
                lblCode.Text = String.Concat(.Item("Code"))
                lblRequesterName.Text = String.Concat(.Item("RequesterName"))
                lblRequesterMail.Text = String.Concat(.Item("EMail"))
                lblRequesterType.Text = String.Concat(.Item("RequesterTypeName"))
                lblRequestType.Text = String.Concat(.Item("RequestTypeName"))
                'ddlType.SelectedValue = String.Concat(.Item("RequestType"))

                txtAmount.Text = StrNull2Double(.Item("AmountFee")).ToString("#,###.##")


                lblLocationName.Text = String.Concat(.Item("LocationName"))
                lblAddress.Text = String.Concat(.Item("LocationAddress"))

                btnAsmLocation.NavigateUrl = "~/Location.aspx?lid=" & String.Concat(.Item("LocationUID")) & "&id=" & String.Concat(.Item("UID"))
                btnAsmGPP.NavigateUrl = "~/GPP.aspx?lid=" & String.Concat(.Item("LocationUID")) & "&id=" & String.Concat(.Item("UID"))

                If DBNull2Zero(.Item("REQDTT")) >= 20240201 Then
                    btnAsmQA.NavigateUrl = "~/QA2.aspx?lid=" & String.Concat(.Item("LocationUID")) & "&id=" & String.Concat(.Item("UID"))
                Else
                    btnAsmQA.NavigateUrl = "~/QA.aspx?lid=" & String.Concat(.Item("LocationUID")) & "&id=" & String.Concat(.Item("UID"))
                End If

                btnAsmSelf.NavigateUrl = "~/Self.aspx?lid=" & String.Concat(.Item("LocationUID")) & "&id=" & String.Concat(.Item("UID"))

                lblLocStatus.Text = String.Concat(.Item("AsmLocationStatus"))
                lblGPPStatus.Text = String.Concat(.Item("AsmGPPStatus"))
                lblQAStatus.Text = String.Concat(.Item("AsmQAStatus"))

                If String.Concat(.Item("LocationStatus")) = "Y" Then
                    lblLocStatus.ForeColor = Color.Green
                End If
                If String.Concat(.Item("GPPStatus")) = "Y" Then
                    lblGPPStatus.ForeColor = Color.Green
                End If
                If String.Concat(.Item("QAStatus")) = "Y" Then
                    lblQAStatus.ForeColor = Color.Green
                End If

                ddlStatus.SelectedValue = String.Concat(.Item("RequestStatus"))
                ddlStatusBack.SelectedValue = String.Concat(.Item("RequestStatus"))

                If DBNull2Zero(.Item("RequestStatus")) >= 20 Then
                    cmdSend.Visible = False
                    pnPayment.Visible = True
                    pnDocument.Visible = True
                End If

                Dim sType() As String

                sType = Split(String.Concat(.Item("RequestTypeUID")), ",")

                pnAsmAll.Visible = False
                pnAsmChange.Visible = False

                pnAsmChange4N.Visible = False
                pnAsmChange4O.Visible = False
                pnAsmChange5N.Visible = False
                pnAsmChange5O.Visible = False
                pnAsmChangeNameN.Visible = False
                pnAsmChangeNameO.Visible = False
                pnAsmChange9.Visible = False

                For n = 0 To sType.Length - 1
                    Select Case DBNull2Zero(sType(n))
                        Case 1, 2, 3, 7
                            pnAsmAll.Visible = True
                        Case 4
                            pnAsmAll.Visible = True
                            pnAsmChange.Visible = True
                            pnAsmChange4N.Visible = True
                            pnAsmChange4O.Visible = True
                            lblPharmacistOld.Text = String.Concat(.Item("Pharmacist_Old"))
                            txtPharmacistNew.Text = String.Concat(.Item("Pharmacist_New"))
                            lblPharmacistLicenseOld.Text = String.Concat(.Item("PharmacistLicenseNo_Old"))
                            txtPharmacistLicenseNew.Text = String.Concat(.Item("PharmacistLicenseNo_New"))
                        Case 5
                            pnAsmChange.Visible = True
                            pnAsmChange5N.Visible = True
                            pnAsmChange5O.Visible = True
                            pnAsmChangeNameN.Visible = False
                            pnAsmChangeNameO.Visible = False

                            lblLicenseeOld.Text = String.Concat(.Item("Licensee_Old"))
                            lblLicenseeTypeOld.Text = String.Concat(.Item("LicenseeType_Old"))

                            txtLicensee.Text = String.Concat(.Item("Licensee_New"))
                            If String.Concat(.Item("LicenseeType_New")) <> "" Then
                                optLicenseeType.SelectedValue = String.Concat(.Item("LicenseeType_New"))
                            Else
                                optLicenseeType.SelectedValue = String.Concat(.Item("RequestSubType"))
                            End If
                        Case = 6
                            pnAsmChange.Visible = True
                            pnAsmChange5N.Visible = False
                            pnAsmChange5O.Visible = False
                            pnAsmChangeNameN.Visible = True
                            pnAsmChangeNameO.Visible = True

                            lblLocationNameOld.Text = String.Concat(.Item("LocationName_Old"))
                            txtLocationName.Text = String.Concat(.Item("LocationName_New"))
                        Case 9
                            lblNew.Text = "ขอเพิ่มใหม่"
                            lblOld.Visible = False
                            pnAsmAll.Visible = True
                            pnAsmChange.Visible = True
                            pnAsmChange9.Visible = True
                            'lblPharmacistOld.Text = String.Concat(.Item("Pharmacist_Old"))
                            txtPharmacistNewAdd.Text = String.Concat(.Item("Pharmacist_New"))
                            'lblPharmacistLicenseOld.Text = String.Concat(.Item("PharmacistLicenseNo_Old"))
                            txtPharmacistLicenseNewAdd.Text = String.Concat(.Item("PharmacistLicenseNo_New"))
                            txtPharmacistTimeNew.Text = String.Concat(.Item("PharmacistTime_New"))
                    End Select
                Next

            End With

            LoadRequestTransaction()
        Else
        End If
    End Sub

    Private Sub LoadAssessmentData()
        dt = ctlA.Assessment_GetByRequestUID(Request("id"))
        If dt.Rows.Count > 0 Then
            With dt.Rows(0)
                hdAssessmentUID.Value = String.Concat(.Item("UID"))
                lblAssessmentStatus.Text = String.Concat(.Item("AssessmentStatusName"))
                lblStatusRemark.Text = String.Concat(.Item("AssessmentRemark"))

                txtAuditorComment1.Text = String.Concat(.Item("AuditorComment1"))
                txtAuditorComment2.Text = String.Concat(.Item("AuditorComment2"))
                txtAuditorComment3.Text = String.Concat(.Item("AuditorComment3"))
                txtAuditorComment4.Text = String.Concat(.Item("AuditorComment4"))
                txtAuditorComment5.Text = String.Concat(.Item("AuditorComment5"))
                txtS.Text = String.Concat(.Item("S"))
                txtW.Text = String.Concat(.Item("W"))
                txtO.Text = String.Concat(.Item("O"))
                txtT.Text = String.Concat(.Item("T"))

                ddlStatus.SelectedValue = String.Concat(.Item("AssessmentStatus"))
                ddlStatusBack.SelectedValue = String.Concat(.Item("AssessmentStatus"))

                txtAccLicense.Text = String.Concat(.Item("AccLicense"))
                txtAppointmentDate.Text = ConvertStrDate2ShortTH(String.Concat(.Item("AppointmentDate")))
                txtSupervisorDate.Text = ConvertStrDate2ShortTH(String.Concat(.Item("SupervisorDate")))
                txtPassDate.Text = ConvertStrDate2ShortTH(String.Concat(.Item("PassDate")))
                txtStartDate.Text = ConvertStrDate2ShortTH(String.Concat(.Item("StartDate")))
                txtExpireDate.Text = ConvertStrDate2ShortTH(String.Concat(.Item("EndDate")))

                If Convert.ToInt32(Request.Cookies("ROLE_ID").Value) > 1 Then
                    txtAsmRemark.Text = String.Concat(.Item("Remark"))
                End If

                If String.Concat(.Item("AuditType")) <> "" Then
                    optAudit.SelectedValue = String.Concat(.Item("AuditType"))
                End If

                txtAccRemark.Text = String.Concat(.Item("LocationAccRemark"))

                'lblLocScore.Text = ""
                lblGPPScore.Text = String.Concat(.Item("GPP_Percentage")) & " %" ' String.Concat(.Item("GPP_Score")) 

                lblQAScore1.Text = String.Concat(.Item("QA_Score1"))
                lblQAScore2.Text = String.Concat(.Item("QA_Score2"))
                lblQAScore3.Text = String.Concat(.Item("QA_Score3"))
                lblQAScore.Text = String.Concat(.Item("QA_Percentage")) & " %"  ' String.Concat(.Item("QA_Score"))

                lblTotalAsmScore.Text = (StrNull2Double(lblLocScore.Text) + StrNull2Double(String.Concat(.Item("GPP_Score"))) + StrNull2Double(lblQAScore.Text)).ToString()

                'If lblLocStatus.Text = "ผ่าน" Then
                '    lblLocStatus.ForeColor = Color.Green
                'End If
                'If DBNull2Dbl(.Item("GPP_Percentage")) > 70 Then
                '    lblGPPStatus.Text = "ผ่าน"
                '    lblGPPStatus.ForeColor = Color.Green
                'End If
                'If DBNull2Dbl(.Item("QA_Percentage")) > 70 Then
                '    lblQAStatus.Text = "ผ่าน"
                '    lblQAStatus.ForeColor = Color.Green
                'End If
                If DBNull2Zero(.Item("AssessmentStatus")) = 50 Then 'ยังไม่ผ่าน/รอแก้ไข
                    If Convert.ToInt32(Request.Cookies("ROLE_ID").Value) = 1 Then
                        cmdSend.Visible = True
                        cmdSend.Text = "ส่งเรื่องพิจารณาอีกครั้ง"
                        cmdCancel.Visible = False
                    End If
                ElseIf DBNull2Zero(.Item("AssessmentStatus")) >= 60 Then
                    pnAudit.Visible = True
                    pnFinal.Visible = True

                    If Convert.ToInt32(Request.Cookies("ROLE_ID").Value) = 1 Then
                        cmdCancel.Visible = False
                    End If
                End If
            End With
        Else
        End If
    End Sub

    Protected Sub cmdSend_Click(sender As Object, e As EventArgs) Handles cmdSend.Click
        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalSend(this,'ยืนยันการส่งเรื่องพิจารณา','คุณต้องการส่งเรื่องเพื่อพิจารณา ใช่หรือไม่?');", True)
        'ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalSuccess(this,'Success','บันทึกข้อมูลเรียบร้อย');", True)
    End Sub

    Async Function TelegramNotify(ByVal chatId As String, ByVal message As String) As Task

        Dim botToken As String = "8169505062:AAF6oy_hUmGdILb6XN829KCl0OUX1ce4tEk"
        ' URL ของ Telegram API
        Dim url As String = $"https://api.telegram.org/bot{botToken}/sendMessage?chat_id={chatId}&text={Uri.EscapeDataString(message)}"
        Try
            Using client As New HttpClient()
                ' ส่ง HTTP GET Request ไปยัง Telegram API
                Dim response As HttpResponseMessage = Await client.GetAsync(url)

                If response.IsSuccessStatusCode Then
                    Console.WriteLine("Message sent successfully!")
                Else
                    Console.WriteLine("Failed to send message!")
                End If
            End Using
        Catch ex As Exception
            Console.Write(ex.Message)
        End Try
    End Function

    Public Sub lineNotify(ByVal msg As String)

        ServicePointManager.Expect100Continue = True
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12


        Dim token As String = "NkKRAmJdgdnNCMG3WZV2ADLBDylR0dMq9fZUeQovMCI"
        'Dim msg As String = "ทดสอบจ้าาา...."

        Try
            Dim request = CType(WebRequest.Create("https://notify-api.line.me/api/notify"), HttpWebRequest)
            Dim postData = String.Format("message={0}", msg)
            Dim data = Encoding.UTF8.GetBytes(postData)
            request.Method = "POST"
            request.ContentType = "application/x-www-form-urlencoded"
            request.ContentLength = data.Length
            request.Headers.Add("Authorization", "Bearer " & token)

            Using stream = request.GetRequestStream()
                stream.Write(data, 0, data.Length)
            End Using

            Dim response = CType(request.GetResponse(), HttpWebResponse)
            Dim responseString = New StreamReader(response.GetResponseStream()).ReadToEnd()
        Catch ex As Exception
            Console.Write(ex.ToString())
        End Try
    End Sub

    'Sub UploadFile(ByVal Fileupload As Object, sName As String)
    '    'Dim FileFullName As String = Fileupload.PostedFile.FileName
    '    'Dim FileNameInfo As String = Path.GetFileName(FileFullName)
    '    Dim filename As String = Path.GetFileName(Fileupload.PostedFile.FileName)
    '    Dim objfile As FileInfo = New FileInfo(Server.MapPath(DocumentRequest & "/" & sName))
    '    If objfile.Exists Then
    '        objfile.Delete()
    '    End If


    '    'If FileNameInfo <> "" Then
    '    Fileupload.PostedFile.SaveAs(Server.MapPath(DocumentRequest & "/" & sName))
    '    'End If
    '    'objfile = Nothing
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

    Protected Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalCancel(this,'ยกเลิกคำขอ','คุณต้องการยกเลิกคำขอใช่หรือไม่?');", True)

        'ctlR.Request_Cancel(StrNull2Zero(hdRequestUID.Value))
        'Response.Redirect("ResultPage.aspx?p=request&t=cancel")
    End Sub
    Protected Sub cmdDelete_Click(sender As Object, e As EventArgs) Handles cmdDelete.Click
        ctlR.Request_Delete(StrNull2Zero(hdRequestUID.Value))
        Response.Redirect("ResultPage.aspx?p=request&t=del")
        'ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalSuccess(this,'Success','ลบ Request เรียบร้อย');", True)
    End Sub

    Protected Sub cmdConfirm_Click(sender As Object, e As EventArgs) Handles cmdConfirm.Click
        Dim ctlA As New AssessmentController

        If cmdSend.Text = "ส่งเรื่องพิจารณาอีกครั้ง" Then
            ctlA.Assessment_SendApprove2(hdRequestUID.Value, hdLocationUID.Value, Request.Cookies("UserID").Value)
        Else
            ctlA.Assessment_SendApprove(hdRequestUID.Value, hdLocationUID.Value, Request.Cookies("UserID").Value)
        End If

        LoadRequestData()
        LoadAssessmentData()
        'CheckStatusAssessment(StrNull2Long(hdRequestUID.Value))
        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalSuccess(this,'Success','ส่งเรื่องพิจารณาเรียบร้อย');", True)
    End Sub

    Private Sub cmdApprove_Click(sender As Object, e As EventArgs) Handles cmdApprove.Click
        Dim AppointmentDate, SupervisorDate, PassDate, StartDate, ExpireDate As String
        AppointmentDate = ConvertStrDate2DBDate(txtAppointmentDate.Text)
        SupervisorDate = ConvertStrDate2DBDate(txtSupervisorDate.Text)
        PassDate = ConvertStrDate2DBDate(txtPassDate.Text)
        StartDate = ConvertStrDate2DBDate(txtStartDate.Text)
        ExpireDate = ConvertStrDate2DBDate(txtExpireDate.Text)

        If optAudit.SelectedValue = Nothing Then
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','โปรดระบุวิธีการตรวจก่อน');", True)
            Exit Sub
        End If

        ctlA.Assessment_UpdateResult(StrNull2Int(hdAssessmentUID.Value), txtAuditorComment1.Text, txtAuditorComment2.Text, txtAuditorComment3.Text, txtAuditorComment4.Text, txtAuditorComment5.Text, txtS.Text, txtW.Text, txtO.Text, txtT.Text, ddlStatus.SelectedValue, AppointmentDate, SupervisorDate, PassDate, StartDate, ExpireDate, txtAsmRemark.Text, txtAccRemark.Text, Request.Cookies("UserID").Value)

        'If StrNull2Zero(ddlStatus.SelectedValue) >= 6 And StrNull2Zero(ddlStatus.SelectedValue) <= 7 Then 'ถ้าผ่านการรับรองแล้ว 
        '    If Left(lblCode.Text, 3) <> "CHK" Then
        '        Dim ctlL As New LocationController
        '        ctlL.Location_UpdateAccStatus(StrNull2Zero(hdLocationUID.Value), "A", txtAccLicense.Text, ConvertStrDate2DBDate(txtStartDate.Text), ConvertStrDate2DBDate(txtExpireDate.Text), "", txtAccRemark.Text)
        '    End If
        'End If

        ctlR.Request_UpdateStatus(hdRequestUID.Value, ddlStatus.SelectedValue, optAudit.SelectedValue, Request.Cookies("UserID").Value)
        ctlR.RequestTransaction_Add(hdRequestUID.Value, hdLocationUID.Value, ddlStatus.SelectedValue, "บันทึกผลการตรวจประเมิน", Request.Cookies("UserID").Value)

        'LoadRequestData()
        'LoadAssessmentData()
        CheckStatusAssessment(StrNull2Long(hdRequestUID.Value))
        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalSuccess(this,'Success','บันทึกการตรวจประเมินเรียบร้อย');", True)
    End Sub

    Protected Sub cmdAssign_Click(sender As Object, e As EventArgs) Handles cmdAssign.Click
        If ddlSupervisor.SelectedValue = "" Then
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','กรุณาเลือกผู้ตรวจประเมินก่อน');", True)
            Exit Sub
        End If

        ctlR.Request_AddSupervisor(StrNull2Zero(hdRequestUID.Value), StrNull2Zero(ddlSupervisor.SelectedValue), StrNull2Zero(Request.Cookies("UserID").Value))
        LoadAssignSupervisorToGrid()
    End Sub
    Private Sub LoadAssignSupervisorToGrid()
        dt = ctlR.RequestAssignment_get(StrNull2Zero(hdRequestUID.Value))
        If dt.Rows.Count > 0 Then
            With grdSupervisor
                .Visible = True
                .DataSource = dt
                .DataBind()
            End With
        Else
            grdSupervisor.Visible = False
        End If
    End Sub

    Protected Sub cmdConfirmAssign_Click(sender As Object, e As EventArgs) Handles cmdConfirmAssign.Click
        Dim dtB As New DataTable
        Dim msgBody As String = ""
        Dim mailMsg As String = ""
        Dim sChatID As String = ""
        dtB = ctlR.RequestAssignment_get(StrNull2Zero(hdRequestUID.Value))
        If dtB.Rows.Count > 0 Then
            msgBody = "คำขอเลขที่ " & lblCode.Text & " " & lblRequestType.Text & " จาก " & lblLocationName.Text & " Assign ให้ " & vbCrLf
            For i = 0 To dtB.Rows.Count - 1
                msgBody = msgBody & i + 1 & ". " & String.Concat(dtB.Rows(i)("SupervisorName")) & vbCrLf
                sChatID = "-4662575113" 'String.Concat(dtB.Rows(i)("ChatID"))
                mailMsg = " <font size='4'>
    
  <p> เรียน " & String.Concat(dtB.Rows(i)("SupervisorName")) & "</p>
  <p> เรื่อง แจ้ง Assign งานการตรวจประเมินร้านยาคุณภาพ</p> 

  <p>ท่านมีงานที่ต้องดำเนินการตรวจประเมินงานรับรองร้านยาคุณภาพ ในระบบ Acc-Pharm </p>
        รหัสคำขอ : " & lblCode.Text & " <br />
        ร้านยา : " & lblLocationName.Text & "  <br /> <br />
<font color='#ff0000'>
**อีเมล์นี้เป็นระบบอัตโนมัติ ห้ามตอบกลับใดๆทั้งสิ้น** </font> <br />
       
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

                If String.Concat(dtB.Rows(i)("Email")) <> "" Then
                    SendEmail(String.Concat(dtB.Rows(i)("SupervisorName")), "แจ้ง Assign งานการตรวจประเมินร้านยาคุณภาพ", mailMsg, String.Concat(dtB.Rows(i)("Email")), "")
                End If
            Next
        End If

        'If sChatID <> "" Then
        '    Dim t As Task = TelegramNotify(sChatID, msgBody)
        'End If

        'lineNotify(msgBody)

        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalSuccess(this,'ผลการตรวจสอบ','ส่งแจ้งผู้ตรวจประเมินเรียบร้อย');", True)
    End Sub

    Dim ctlD As New DocumentController
    Private Sub LoadDocumentCategory()
        ddlDocument.DataSource = ctlD.Document_GetCategory
        ddlDocument.DataTextField = "Descriptions"
        ddlDocument.DataValueField = "ValueCode"
        ddlDocument.DataBind()
    End Sub

    Private Sub LoadDocument()
        dt = ctlD.Document_Get(Request("id"))
        grdDocument.DataSource = dt
        grdDocument.DataBind()
    End Sub

    Private Sub LoadRequestTransaction()
        dt = ctlR.RequestTransaction_Get(StrNull2Zero(hdRequestUID.Value))
        grdOverview.DataSource = dt
        grdOverview.DataBind()
    End Sub

    Protected Sub cmdAddFile_Click(sender As Object, e As EventArgs) Handles cmdAddFile.Click
        Dim sfileName As String = ""
        UploadDirectory = Server.MapPath(DocumentLocation & "/" & hdLocationUID.Value)
        If Not Directory.Exists(UploadDirectory) Then
            Directory.CreateDirectory(UploadDirectory)
        End If

        If FileUploadA.HasFiles Then
            Dim fileExtname As String = Path.GetExtension(FileUploadA.FileName).ToLower()

            sfileName = "Docs_" & hdRequestUID.Value & "_" & ConvertDate2DBString(Now.Date) & ConvertTimeToString(Now()) & "_" & ddlDocument.SelectedValue & fileExtname

            If fileExtname <> ".jpg" And fileExtname <> ".jpeg" And fileExtname <> ".png" And fileExtname <> ".pdf" Then
                ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','ไฟล์รูปภาพต้องมีนามสกุล .jpg, .jpeg,.png,.pdf เท่านั้น');", True)
                Exit Sub
            End If
            If (FileUploadA.PostedFile.ContentLength / 1024) > 2048 Then
                ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','ไฟล์มีขนาดใหญ่เกิน 2048 Kb. ไม่สามารถอัพโหลดได้');", True)
                Exit Sub
            End If

            Dim objfile As FileInfo = New FileInfo(UploadDirectory & sfileName)
            If objfile.Exists Then
                objfile.Delete()
            End If
            FileUploadA.SaveAs(System.IO.Path.Combine(UploadDirectory, sfileName))
            ctlD.Document_Save(StrNull2Long(ddlDocument.SelectedValue), StrNull2Zero(hdRequestUID.Value), StrNull2Zero(hdLocationUID.Value), sfileName, StrNull2Zero(Request.Cookies("UserID").Value))
        End If
        LoadDocument()
    End Sub
    Private Sub LoadSlip()
        dt = ctlD.Document_GetPayslip(Request("id"))
        grdSlip.DataSource = dt
        grdSlip.DataBind()
    End Sub
    Protected Sub cmdAddSlip_Click(sender As Object, e As EventArgs) Handles cmdAddSlip.Click
        Dim sfileName As String = ""
        UploadDirectory = Server.MapPath(DocumentLocation & "/" & hdLocationUID.Value)
        If Not Directory.Exists(UploadDirectory) Then
            Directory.CreateDirectory(UploadDirectory)
        End If

        If FileUpload1.HasFiles Then
            Dim fileExtname As String = Path.GetExtension(FileUpload1.FileName).ToLower()
            If fileExtname <> ".jpg" And fileExtname <> ".jpeg" And fileExtname <> ".png" Then
                ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','ไฟล์รูปภาพต้องมีนามสกุล .jpg, .jpeg, .png เท่านั้น');", True)
                Exit Sub
            End If

            If (FileUpload1.PostedFile.ContentLength / 1024) > 1024 Then
                ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','ไฟล์มีขนาดใหญ่เกิน 1024 Kb. ไม่สามารถอัพโหลดได้');", True)
                Exit Sub
            End If

            sfileName = "PaySlip_" & hdRequestUID.Value & "_" & ConvertDate2DBString(Now.Date) & ConvertTimeToString(Now()) & fileExtname
            Dim objfile As FileInfo = New FileInfo(UploadDirectory & sfileName)
            If objfile.Exists Then
                objfile.Delete()
            End If
            FileUpload1.SaveAs(System.IO.Path.Combine(UploadDirectory, sfileName))
            ctlD.PaymentSlip_Add(StrNull2Long(ddlDocument.SelectedValue), StrNull2Zero(hdRequestUID.Value), StrNull2Zero(hdLocationUID.Value), sfileName, StrNull2Double(txtAmount.Text), StrNull2Zero(Request.Cookies("UserID").Value))
        End If
        LoadSlip()
    End Sub

    Protected Sub cmdSendBack_Click(sender As Object, e As EventArgs) Handles cmdSendBack.Click
        If txtComment.Text = "" Then
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','ท่านยังไม่ได้ระบุข้อความ');", True)
            Exit Sub
        End If

        ctlA.Assessment_UpdateRemark(hdRequestUID.Value, hdLocationUID.Value, ddlStatusBack.SelectedValue, txtComment.Text, StrNull2Zero(Request.Cookies("UserID").Value))

        ctlR.RequestTransaction_Add(hdRequestUID.Value, hdLocationUID.Value, ddlStatus.SelectedValue, "ส่งข้อความตอบกลับร้านยา", Request.Cookies("UserID").Value)

        Dim mCC As String = ""
        dt = ctlR.RequestAssignment_get(StrNull2Zero(hdRequestUID.Value))
        If dt.Rows.Count > 0 Then
            For i = 0 To dt.Rows.Count - 1
                mCC = mCC & String.Concat(dt.Rows(i)("Email")) & ","
            Next
        End If

        If mCC <> "" Then
            mCC = Left(mCC, Len(mCC) - 1)
        End If


        Dim MyMessageBody As String = " <font size='4'>
    
  <p> เรียน " & lblRequesterName.Text & "</p>
  <p> เรื่อง แจ้งผลการยื่นคำขอตรวจประเมินร้านยาคุณภาพ : " & lblLocationName.Text & "</p> 
     <p>ท่านสามารถเข้าใช้งานระบบประเมินร้านยาคุณภาพได้ที่ <a href='https://www.acc-pharm.com'>https://www.acc-pharm.com</p> 
  <p>" + txtComment.Text + " </p>  <br /> <br />
     <font color='#ff0000'>  **อีเมล์นี้เป็นระบบอัตโนมัติ ห้ามตอบกลับใดๆทั้งสิ้น** </font><br />
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



        SendEmail(lblLocationName.Text, "แจ้งผลการตรจประเมินร้านยาคุณภาพ", MyMessageBody, lblRequesterMail.Text, mCC)

        CheckStatusAssessment(StrNull2Long(hdRequestUID.Value))

        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalSuccess(this,'Success','บันทึกข้อมูลเรียบร้อย');", True)

    End Sub

    Private Sub SendEmail(PersonName As String, subject As String, Msg As String, sTo As String, sCC As String)
        Dim SenderDisplayName As String = "สำนักงานรับรองร้านยาคุณภาพ สภาเภสัชกรรม"
        Dim MySubject As String = subject & " : " & PersonName
        Dim MyMessageBody As String = Msg

        Dim mailMessage As System.Net.Mail.MailMessage = New System.Net.Mail.MailMessage()
        mailMessage.From = New MailAddress("papcinfo@gmail.com", SenderDisplayName)
        mailMessage.Subject = MySubject
        mailMessage.Body = MyMessageBody
        mailMessage.IsBodyHtml = True
        mailMessage.[To].Add(New MailAddress(sTo))
        If sCC <> "" Then
            Dim emails() As String
            emails = sCC.Split(",")
            For i = 0 To emails.Length - 1
                If emails(i) <> "" Then
                    mailMessage.CC.Add(New MailAddress(emails(i)))
                End If
            Next
        End If

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

    Private Sub grdSlip_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grdSlip.RowCommand
        If TypeOf e.CommandSource Is WebControls.ImageButton Then
            Dim ButtonPressed As WebControls.ImageButton = e.CommandSource
            Select Case ButtonPressed.ID
                Case "imgDel"
                    DeleteDocumentFile(e.CommandArgument)
                    ctlD.Document_Delete(e.CommandArgument)
                    LoadSlip()
            End Select
        End If
    End Sub


    Private Sub grdSlip_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles grdSlip.RowDataBound
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

    Private Sub grdTemplate_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grdTemplate.RowCommand
        If TypeOf e.CommandSource Is WebControls.ImageButton Then
            Dim ButtonPressed As WebControls.ImageButton = e.CommandSource
            Select Case ButtonPressed.ID
                Case "imgSelect"
                    txtComment.Text = txtComment.Text & e.CommandArgument() & vbCrLf
            End Select
        End If
    End Sub

    Protected Sub cmdAdd3Year_Click(sender As Object, e As EventArgs) Handles cmdAdd3Year.Click
        If txtStartDate.Text <> "" Then
            txtExpireDate.Text = DisplayShortDateTH(DateAdd(DateInterval.Year, 3, ConvertStringDateToDate(txtStartDate.Text)))
        Else
            txtExpireDate.Text = DisplayShortDateTH(DateAdd(DateInterval.Year, 3, Now.Date()))
        End If
    End Sub

    Private Sub grdSupervisor_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grdSupervisor.RowCommand
        If TypeOf e.CommandSource Is WebControls.ImageButton Then
            Dim ButtonPressed As WebControls.ImageButton = e.CommandSource
            Select Case ButtonPressed.ID
                Case "imgDel"
                    ctlR.RequestAssignment_Delete(e.CommandArgument)
                    LoadAssignSupervisorToGrid()
            End Select
        End If
    End Sub

    Protected Sub cmdSaveUpdate_Click(sender As Object, e As EventArgs) Handles cmdSaveUpdate.Click
        If pnAsmChangeNameN.Visible Then
            If txtLocationName.Text = "" Then
                ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','กรุณาระบุชื่อร้านยาใหม่ที่ต้องการเปลี่ยน');", True)
                Exit Sub
            End If
            ctlR.Request_UpdateLocationName(hdRequestUID.Value, lblLocationNameOld.Text, txtLocationName.Text)
        End If

        If pnAsmChange4N.Visible Then
            If txtPharmacistNew.Text = "" Or txtPharmacistLicenseNew.Text = "" Then
                ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','กรุณาระบุข้อมูลที่ต้องการเปลี่ยนให้ครบถ้วน');", True)
                Exit Sub
            End If
            ctlR.Request_UpdatePharmacistLicense(hdRequestUID.Value, lblPharmacistOld.Text, txtPharmacistNew.Text, lblPharmacistLicenseOld.Text, txtPharmacistLicenseNew.Text)
        End If

        If pnAsmChange9.Visible Then
            If txtPharmacistNewAdd.Text = "" Or txtPharmacistLicenseNewAdd.Text = "" Or txtPharmacistTimeNew.Text = "" Then
                ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','กรุณาระบุข้อมูลที่ต้องการให้ครบถ้วน');", True)
                Exit Sub
            End If
            ctlR.Request_UpdatePharmacistNew(hdRequestUID.Value, txtPharmacistNewAdd.Text, txtPharmacistLicenseNewAdd.Text, txtPharmacistTimeNew.Text)
        End If

        If pnAsmChange5N.Visible Then
            If txtLicensee.Text = "" Or optLicenseeType.SelectedValue = Nothing Then
                ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','กรุณาระบุข้อมูลที่ต้องการเปลี่ยนให้ครบถ้วน');", True)
                Exit Sub
            End If
            ctlR.Request_UpdateLicensee(hdRequestUID.Value, lblLicenseeOld.Text, txtLicensee.Text, lblLicenseeTypeOld.Text, optLicenseeType.SelectedValue)
        End If

        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalSuccess(this,'Success','บันทึกข้อมูลเรียบร้อย');", True)

    End Sub

    Private Sub cmdConfirmCancel_Click(sender As Object, e As EventArgs) Handles cmdConfirmCancel.Click
        'If txtCancelRemark.Text = "" Or Len(txtCancelRemark.Text) < 5 Then
        '    ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalAlert(this,'ผลการตรวจสอบ','กรุณาระบุเหตุผลในการยกเลิกมากกว่า 5 ตัวอักษร');", True)
        '    Exit Sub
        'End If
        ctlR.Request_Cancel(StrNull2Zero(hdRequestUID.Value), txtCancelRemark.Text)
        ctlR.RequestTransaction_Add(StrNull2Zero(hdRequestUID.Value), StrNull2Zero(hdLocationUID.Value), 0, "ยกเลิกคำขอ : " & txtCancelRemark.Text, Request.Cookies("UserID").Value)

        Response.Redirect("ResultPage.aspx?p=request&t=cancel")
    End Sub

    Private Sub cmdSaveChangeType_Click(sender As Object, e As EventArgs) Handles cmdSaveChangeType.Click
        'If ddlType.SelectedValue = "" Then
        '    ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','ท่านยังไม่ได้ระบุข้อความ');", True)
        '    Exit Sub
        'End If

        'ctlR.Request_ChangeType(StrNull2Zero(hdRequestUID.Value), StrNull2Zero(ddlType.SelectedValue))

        ctlR.RequestTypeList_Delete(StrNull2Zero(hdRequestUID.Value))

        If chkType1.Checked Then
            ctlR.RequestTypeList_Add(StrNull2Zero(hdRequestUID.Value), 1, Request.Cookies("userid").Value)
        End If
        If chkType2.Checked Then
            ctlR.RequestTypeList_Add(StrNull2Zero(hdRequestUID.Value), 2, Request.Cookies("userid").Value)
        End If
        If chkType3.Checked Then
            ctlR.RequestTypeList_Add(StrNull2Zero(hdRequestUID.Value), 3, Request.Cookies("userid").Value)
        End If
        If chkType4.Checked Then
            ctlR.RequestTypeList_Add(StrNull2Zero(hdRequestUID.Value), 4, Request.Cookies("userid").Value)
        End If
        If chkType5.Checked Then
            ctlR.RequestTypeList_Add(StrNull2Zero(hdRequestUID.Value), 5, Request.Cookies("userid").Value)
        End If
        If chkType6.Checked Then
            ctlR.RequestTypeList_Add(StrNull2Zero(hdRequestUID.Value), 6, Request.Cookies("userid").Value)
        End If
        If chkType7.Checked Then
            ctlR.RequestTypeList_Add(StrNull2Zero(hdRequestUID.Value), 7, Request.Cookies("userid").Value)
        End If
        If chkType8.Checked Then
            ctlR.RequestTypeList_Add(StrNull2Zero(hdRequestUID.Value), 8, Request.Cookies("userid").Value)
        End If
        If chkType9.Checked Then
            ctlR.RequestTypeList_Add(StrNull2Zero(hdRequestUID.Value), 9, Request.Cookies("userid").Value)
        End If

        ctlR.RequestTransaction_Add(hdRequestUID.Value, hdLocationUID.Value, ddlStatus.SelectedValue, "เปลี่ยนประเภทคำขอ", Request.Cookies("UserID").Value)
        LoadRequestData()
        CheckStatusAssessment(StrNull2Long(hdRequestUID.Value))

        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalSuccess(this,'Success','บันทึกข้อมูลเรียบร้อย');", True)
    End Sub

    Private Sub cmdChangeType_Click(sender As Object, e As EventArgs) Handles cmdChangeType.Click
        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalChangeType(this,'เปลี่ยนประเภทคำขอ','ระบุประเภทคำขอใหม่');", True)
    End Sub

    Protected Sub cmdWorkFlow_Click(sender As Object, e As EventArgs) Handles cmdWorkFlow.Click
        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalOverview(this,'Work Flow Overview','Transaction');", True)
    End Sub

    Protected Sub cmdEdit_Click(sender As Object, e As EventArgs) Handles cmdEdit.Click
        Response.Redirect("Request.aspx?m=req&rid=" & hdRequestUID.Value)
    End Sub
End Class