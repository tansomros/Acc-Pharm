Imports System
Imports System.IO
Imports System.Web.UI
Imports DevExpress.Web
Imports BigLion
Public Class QA2
    Inherits System.Web.UI.Page
    Dim ctlL As New LocationController
    Dim dt As New DataTable
    'Dim ds As New DataSet
    'Dim objEn As New CryptographyEngine

    Dim ctlU As New UserController
    Dim ctlPs As New PharmacistController
    Dim ctlM As New MediaController
    Dim ctlA As New AssessmentController

    Private UploadDirectory As String
    'Dim ctlPs As New PersonController
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsNothing(Request.Cookies("CPAQA")) Then
            Response.Redirect("Default.aspx")
        End If

        Response.Cache.SetExpires(DateTime.Now.AddSeconds(60))
        Response.Cache.SetCacheability(HttpCacheability.Public)
        Response.Cache.SetValidUntilExpires(True)

        If Not IsPostBack Then
            'LoadBankToDDL()
            'GenLocationNumber() 

            hdLocationUID.Value = Request.Cookies("LoginLocationUID").Value
            If Not Request("id") = Nothing Then
                hdRequestUID.Value = Request("id")
                LoadRequestDetail(Request("id"))

                lblYear.Text = ctlA.Assessment_GetAsmYearByRequestUID(Request("id"))

                LoadQA_Assessment(Request("id"))
                LoadLocationDetail(hdLocationUID.Value)
                LoadProject()
                UploadDirectory = Server.MapPath("~/imageUploads/" & hdLocationUID.Value & "/QA/")

                If Not Directory.Exists(UploadDirectory) Then
                    Directory.CreateDirectory(UploadDirectory)
                End If
            End If

            If Convert.ToInt32(Request.Cookies("ROLE_ID").Value) >= 2 Then
                grdProject.Columns(5).Visible = False
                cmdSave.Visible = False
                cmdApprove.Visible = True
                chkStatus.Checked = True
            Else
                cmdApprove.Visible = False
                cmdSave.Visible = True
            End If

            CheckStatusAssessment()

        End If

        'txtZipCode.Attributes.Add("OnKeyPress", "return AllowOnlyIntegers();")
    End Sub
    Private Sub LoadRequestDetail(RequestUID As Integer)
        Dim ctlR As New RequestController
        dt = ctlR.Request_GetByUID(RequestUID)
        If dt.Rows.Count > 0 Then
            hdRequestUID.Value = dt.Rows(0)("UID")
            hdLocationUID.Value = dt.Rows(0)("LocationUID")
        End If
        dt = Nothing
    End Sub
    Private Sub LoadLocationDetail(LID As Integer)
        Dim dtL As New DataTable
        dtL = ctlL.Location_GetByUID(LID)

        If dtL.Rows.Count > 0 Then
            With dtL.Rows(0)
                Try
                    lblLicenseNo.Text = String.Concat(.Item("LicenseNo1"))
                    lblLicenseNo.Text = String.Concat(.Item("LicenseNo1"))
                    lblLocationName.Text = String.Concat(.Item("LocationName"))
                    lblAddress.Text = String.Concat(.Item("LocationAddress"))
                    lblTel.Text = String.Concat(.Item("tel"))
                    lblAddress.Text = String.Concat(.Item("LocationAddress"))

                    lblLicenseStatus.Text = DisplayLicenseStatus(String.Concat(.Item("LicenseStatus")))
                    lblStartDate.Text = String.Concat(.Item("LicenseStartDate"))
                    lblExpireDate.Text = String.Concat(.Item("LicenseExpireDate"))
                    lblLicensee.Text = String.Concat(.Item("Licensee"))
                Catch ex As Exception

                End Try
            End With
        End If
    End Sub
    Private Sub LoadQA_Assessment(RequestUID As Integer)
        dt = ctlA.QA_Assessment_GetByRequestUID(RequestUID)
        If dt.Rows.Count > 0 Then
            hdQAUID.Value = String.Concat(dt.Rows(0)("UID"))
            hdLocationUID.Value = String.Concat(dt.Rows(0)("LocationUID"))
            hdRequestUID.Value = String.Concat(dt.Rows(0)("RequestUID"))

            txtProjectScore.Text = String.Concat(dt.Rows(0)("Score1"))
            txtProjectComment.Text = String.Concat(dt.Rows(0)("AuditorComment1"))
            txtRisk1.Text = String.Concat(dt.Rows(0)("Risk1"))
            txtRisk2.Text = String.Concat(dt.Rows(0)("Risk2"))
            txtRisk3.Text = String.Concat(dt.Rows(0)("Risk3"))
            txtRisk4.Text = String.Concat(dt.Rows(0)("Risk4"))
            txtRisk5.Text = String.Concat(dt.Rows(0)("Risk5"))
            txtRisk6.Text = String.Concat(dt.Rows(0)("Risk6"))
            txtRisk7.Text = String.Concat(dt.Rows(0)("Risk7"))
            txtRisk8.Text = String.Concat(dt.Rows(0)("Risk8"))
            txtRisk9.Text = String.Concat(dt.Rows(0)("Risk9"))
            txtRisk10.Text = String.Concat(dt.Rows(0)("Risk10"))
            txtRiskScore.Text = String.Concat(dt.Rows(0)("Score2"))
            txtRiskComment.Text = String.Concat(dt.Rows(0)("AuditorComment2"))
            optTelepharmacy.SelectedValue = String.Concat(dt.Rows(0)("Telepharmacy"))

            'Dim sTele() As String
            'sTele = Split(dt.Rows(0)("TeleTools"), "|")
            'chkTeleTools.ClearSelection()

            'For i = 0 To sTele.Length - 1
            '    For n = 0 To chkTeleTools.Items.Count - 1
            '        If chkTeleTools.Items(n).Value = sTele(i) Then
            '            chkTeleTools.Items(n).Selected = True
            '        End If
            '    Next
            'Next

            txtTeleOther.Text = String.Concat(dt.Rows(0)("ToolsOther"))
            txtQ2.Text = String.Concat(dt.Rows(0)("Q2"))
            txtQ3.Text = String.Concat(dt.Rows(0)("Q3"))
            txtQ4.Text = String.Concat(dt.Rows(0)("Q4"))
            txtQ5.Text = String.Concat(dt.Rows(0)("Q5"))
            txtQ6.Text = String.Concat(dt.Rows(0)("Q6"))
            txtQAScore.Text = String.Concat(dt.Rows(0)("Score3"))
            txtQAComment.Text = String.Concat(dt.Rows(0)("AuditorComment3"))

            If dt.Rows(0)("AsmStatus") = "Y" Then
                chkStatus.Checked = True
            Else
                chkStatus.Checked = False
            End If


        End If
    End Sub
    Private Sub CheckStatusAssessment()
        Dim iStatus As Integer = 0
        Dim ctlA As New AssessmentController
        dt = ctlA.Assessment_GetStatus(StrNull2Long(Request("id")))
        If dt.Rows.Count > 0 Then
            iStatus = DBNull2Zero(dt.Rows(0)("StatusID"))

            If iStatus >= 10 And iStatus <= 50 Then ' Processing

            ElseIf iStatus >= 60 Then 'Passed
                If Convert.ToInt32(Request.Cookies("ROLE_ID").Value) = 1 Then
                    cmdSave.Visible = False
                    cmdApprove.Visible = False
                    grdProject.Columns(5).Visible = False

                    cmdAddProject.Enabled = False
                    cmdClearProject.Enabled = False

                    FileUpload1.Enabled = False
                    FileUploadA.Enabled = False

                    cmdUpImg.Visible = False
                    cmdUpImgPJ.Visible = False

                    grdImg.Columns(3).Visible = False
                    grdImgPJ.Columns(3).Visible = False

                    lblImgPJ.Visible = True
                    Label2.Visible = True
                    lblImgPJ.Text = "สถานะปัจจุบันไม่สามารถออัพโหลดหรือแก้ไขรูปภาพได้อีก"
                    Label2.Text = "สถานะปัจจุบันไม่สามารถออัพโหลดหรือแก้ไขรูปภาพได้อีก"
                End If
            ElseIf iStatus = 0 Then 'ยกเลิก

            End If
        End If

    End Sub


    Protected Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click

        Dim TeleTools As String = ""
        'For i = 0 To chkTeleTools.Items.Count - 1
        '    If chkTeleTools.Items(i).Selected = True Then
        '        TeleTools = TeleTools & chkTeleTools.Items(i).Value & "|"
        '    End If
        'Next
        'If TeleTools <> "" Then
        '    TeleTools = Left(TeleTools, Len(TeleTools) - 1)
        'End If

        Assessment_Save(StrNull2Zero(hdRequestUID.Value))

        ctlA.QA_Assessment_Save2(StrNull2Long(hdQAUID.Value), StrNull2Zero(hdRequestUID.Value), StrNull2Zero(lblYear.Text), StrNull2Zero(hdLocationUID.Value), txtRisk1.Text, txtRisk2.Text, txtRisk3.Text, txtRisk4.Text, txtRisk5.Text, txtRisk6.Text, txtRisk7.Text, txtRisk8.Text, txtRisk9.Text, txtRisk10.Text, optTelepharmacy.SelectedValue, TeleTools, txtTeleOther.Text, txtQ2.Text, txtQ3.Text, txtQ4.Text, txtQ5.Text, txtQ6.Text, Request.Cookies("UserID").Value)

        ctlU.User_GenLogfile(Request.Cookies("UserID").Value, ACTTYPE_ADD, "QA_Assessment", "ประเมินงานคุณภาพ", "[LocationUID=" & hdLocationUID.Value & "][RequestUID=" & hdRequestUID.Value & "]", Environment.MachineName, GetIPAddress())
        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalSuccess(this,'Success','บันทึกข้อมูลเรียบร้อย');", True)
    End Sub
    Private Sub Assessment_Save(RequestUID As Long)
        Dim ctlA As New AssessmentController
        ctlA.Assessment_Save(RequestUID, StrNull2Zero(hdLocationUID.Value), Request.Cookies("UserID").Value)
    End Sub
    Protected Sub cmdAddProject_Click(sender As Object, e As EventArgs) Handles cmdAddProject.Click
        Dim SEQNO, SoftID As String
        Dim sfileName As String = ""
        UploadDirectory = Server.MapPath("~/imageUploads/" & hdLocationUID.Value & "/QA/")

        ctlL.LocationProject_Save(StrNull2Long(hdProjectUID.Value), StrNull2Zero(hdLocationUID.Value), txtProjectName.Text, txtProjectAction.Text, txtProjectNumber.Text, StrNull2Zero(Request.Cookies("UserID").Value))
        SoftID = ctlL.LocationProject_GetLastUID(StrNull2Zero(hdLocationUID.Value)).ToString

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

                If ctlM.Media_GetCount(StrNull2Zero(hdRequestUID.Value), StrNull2Zero(lblYear.Text), StrNull2Zero(hdLocationUID.Value), "P", SoftID) >= 4 Then
                    Exit Sub
                End If

                SEQNO = ctlM.Media_GetLastSEQ(StrNull2Zero(hdRequestUID.Value), StrNull2Zero(lblYear.Text), StrNull2Zero(hdLocationUID.Value), "P", SoftID)
                sfileName = "P_" & StrNull2Zero(lblYear.Text) & "_" & SoftID & "_" & SEQNO.ToString() & fileExtname

                Dim objfile As FileInfo = New FileInfo(UploadDirectory & sfileName)
                If objfile.Exists Then
                    objfile.Delete()
                End If
                uploadedFile.SaveAs(System.IO.Path.Combine(UploadDirectory, sfileName))
                ctlM.Media_Save(StrNull2Zero(hdRequestUID.Value), StrNull2Zero(lblYear.Text), StrNull2Zero(hdLocationUID.Value), "P", SoftID, SEQNO, sfileName, Request.Cookies("UserID").Value)
            Next
        End If
        hdProjectUID.Value = ""
        txtProjectName.Text = ""
        txtProjectAction.Text = ""
        txtProjectNumber.Text = ""

        LoadProject()
    End Sub
    Private Sub LoadProject()
        Dim dtS As New DataTable
        dtS = ctlL.LocationProject_Get(StrNull2Zero(hdLocationUID.Value))
        If dtS.Rows.Count > 0 Then
            With grdProject
                .Visible = True
                .DataSource = dtS
                .DataBind()
            End With
        Else
            grdProject.Visible = False
        End If
        dtS = Nothing
    End Sub
    Private Sub EditProjectData(ByVal pID As String)
        txtProjectName.Text = ""
        txtProjectAction.Text = ""
        txtProjectNumber.Text = ""

        dt = ctlL.LocationProject_GetByUID(pID)
        If dt.Rows.Count > 0 Then
            With dt.Rows(0)
                hdProjectUID.Value = .Item("UID")
                txtProjectName.Text = String.Concat(.Item("ProjectName"))
                txtProjectAction.Text = String.Concat(.Item("Descriptions"))
                txtProjectNumber.Text = String.Concat(.Item("ProjectNumber"))
                cmdAddProject.Text = "บันทึก"
            End With
        End If

        dt = Nothing
    End Sub

    Private Sub grdProject_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grdProject.RowCommand
        If TypeOf e.CommandSource Is WebControls.LinkButton Then
            Dim ButtonPressed As WebControls.LinkButton = e.CommandSource
            Select Case ButtonPressed.ID
                Case "imgEdit_PJ"
                    EditProjectData(e.CommandArgument())
                Case "imgFilePJ"
                    Dim fPath As String = "imageUploads/" & hdLocationUID.Value & "/QA/"
                    hdProjUID.Value = e.CommandArgument()
                    LoadProjectImg()
                    ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalUploadPJ(this,'" + e.CommandArgument() + "');", True)

                Case "imgDel_PJ"
                    If ctlL.LocationProject_Delete(e.CommandArgument) Then
                        DeleteImageByGroup("P", e.CommandArgument)
                        'ctlU.User_GenLogfile(Request.Cookies("UserID").Value, "DEL", "Pharmacists", "ลบเภสัชกรประจำร้านยา :" & e.CommandArgument, "")
                        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalSuccess(this,'Success','ลบข้อมูลเรียบร้อย');", True)
                    Else
                        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningAlert(this,'ผลการตรวจสอบ','ไม่สามารถลบข้อมูลได้ กรุณาตรวจสอบและลองใหม่อีกครั้ง');", True)
                    End If
                    LoadProject()
            End Select
        End If
    End Sub



    Private Sub grdProject_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles grdProject.RowDataBound
        If e.Row.RowType = ListItemType.AlternatingItem Or e.Row.RowType = ListItemType.Item Then

            Dim scriptString As String = "javascript:return confirm(""ต้องการลบ ข้อมูลนี้ ?"");"
            Dim imgD As LinkButton = e.Row.Cells(5).FindControl("imgDel_PJ")
            imgD.Attributes.Add("onClick", scriptString)

        End If
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#d0e8ff';")
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;")

        End If
    End Sub

    Private Sub PreviewPicture(Fname As String, Desc As String, filePath As String)
        Dim fPath As String = "imageUploads/" & hdLocationUID.Value & "/QA/"
        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWindow(this,'" + Fname + "','" + Desc + "','" + fPath + filePath + "?v=" & ConvertDate2DBString(Now.Date) & ConvertTimeToString(Now()) & "');", True)
    End Sub
    Private Sub LoadProjectImg()
        dt = ctlM.Media_Get(StrNull2Zero(hdRequestUID.Value), StrNull2Zero(hdLocationUID.Value), "P", StrNull2Long(hdProjUID.Value))
        grdImgPJ.DataSource = dt
        grdImgPJ.DataBind()

        If dt.Rows.Count >= 4 Then
            lblImgPJ.Text = "ท่านได้อัพโหลดไฟล์ครบ 4 ไฟล์แล้ว ไม่สามารถอัพโหลดเพิ่มได้อีก"
            cmdUpImgPJ.Enabled = False
            lblImgPJ.Visible = True
        Else
            lblImgPJ.Visible = False
            cmdUpImgPJ.Enabled = True
        End If

    End Sub

    Private Sub grdImgPJ_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grdImgPJ.RowCommand
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

    Private Sub grdImgPJ_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles grdImgPJ.RowDataBound
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

    Private Sub LoadImg()
        dt = ctlM.Media_Get(StrNull2Zero(Request("id")), StrNull2Zero(hdLocationUID.Value), lblTCode.Text, StrNull2Long(hdAccID.Value))
        grdImg.DataSource = dt
        grdImg.DataBind()

        If dt.Rows.Count >= 4 Then
            Label2.Text = "ท่านได้อัพโหลดไฟล์ครบ 4 ไฟล์แล้ว ไม่สามารถอัพโหลดเพิ่มได้อีก"
            cmdUpImg.Enabled = False
            Label2.Visible = True
        Else
            Label2.Visible = False
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
        UploadFiles(FileUpload1, hdAccID.Value, lblTCode.Text)
        LoadImg()
    End Sub

    Protected Sub cmdClearProject_Click(sender As Object, e As EventArgs) Handles cmdClearProject.Click
        txtProjectName.Text = ""
        txtProjectAction.Text = ""
        txtProjectNumber.Text = ""
        hdProjectUID.Value = "0"
    End Sub
    Private Sub cmdBack_Click(sender As Object, e As EventArgs) Handles cmdBack.Click
        Response.Redirect("RequestDetail?id=" & Request("id"))
    End Sub
    Private Sub UploadFiles(ByVal Fileupload As Object, REFUID As Integer, sCode As String)
        Dim SEQNO As String
        Dim sfileName As String = ""
        UploadDirectory = Server.MapPath("imageUploads/" & hdLocationUID.Value & "/QA/")

        If Fileupload.HasFiles Then
            For Each uploadedFile As HttpPostedFile In Fileupload.PostedFiles
                Dim fileExtname As String = Path.GetExtension(uploadedFile.FileName).ToLower()
                If fileExtname <> ".jpg" And fileExtname <> ".jpeg" And fileExtname <> ".png" Then
                    ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','ไฟล์รูปภาพต้องมีนามสกุล .jpg, .jpeg, .png เท่านั้น');", True)
                    Exit Sub
                End If
                If (uploadedFile.ContentLength / 1024) > 1024 Then
                    ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','ไฟล์มีขนาดใหญ่เกิน 1024 Kb. ไม่สามารถอัพโหลดได้');", True)
                    Exit Sub
                End If

                If ctlM.Media_GetCount(StrNull2Zero(hdRequestUID.Value), StrNull2Zero(lblYear.Text), StrNull2Zero(hdLocationUID.Value), sCode, REFUID) >= 4 Then
                    Exit Sub
                End If
                SEQNO = ctlM.Media_GetLastSEQ(StrNull2Zero(hdRequestUID.Value), StrNull2Zero(lblYear.Text), StrNull2Zero(hdLocationUID.Value), sCode, REFUID)
                sfileName = sCode & "_" & StrNull2Zero(lblYear.Text) & "_" & REFUID & "_" & SEQNO.ToString() & fileExtname

                Dim objfile As FileInfo = New FileInfo("imageUploads/" & hdLocationUID.Value & "/QA/" & sfileName)
                If objfile.Exists Then
                    objfile.Delete()
                End If
                uploadedFile.SaveAs(System.IO.Path.Combine(UploadDirectory, sfileName))
                ctlM.Media_Save(StrNull2Zero(hdRequestUID.Value), StrNull2Zero(lblYear.Text), hdLocationUID.Value, sCode, REFUID, SEQNO, sfileName, Request.Cookies("UserID").Value)
            Next
        End If
    End Sub

    Protected Sub imgRisk1_Click(sender As Object, e As EventArgs) Handles imgRisk1.Click
        Dim fPath As String = "imageUploads/" & hdLocationUID.Value & "/QA/"
        hdAccID.Value = "1"
        lblTCode.Text = "R"
        lblTopic.Text = "1. ความเสี่ยงในการที่เภสัชกรจะหยิบยาผิดจากปัญหาพ้องรูปพ้องเสียง LASA ( Look Alike Sound Alike ) ระบุแนวทางในการป้องกัน"
        LoadImg()
        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalUpload(this,'1');", True)
    End Sub
    Protected Sub imgRisk2_Click(sender As Object, e As EventArgs) Handles imgRisk2.Click
        Dim fPath As String = "imageUploads/" & hdLocationUID.Value & "/QA/"
        hdAccID.Value = "2"
        lblTCode.Text = "R"
        lblTopic.Text = "2. ความเสี่ยงในการจ่ายยาผิด นอกจากที่เกิดจากปัญหา LASA ระบุแนวทางในการป้องกัน"
        LoadImg()
        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalUpload(this,'2');", True)
    End Sub
    Protected Sub imgRisk3_Click(sender As Object, e As EventArgs) Handles imgRisk3.Click
        Dim fPath As String = "imageUploads/" & hdLocationUID.Value & "/QA/"
        hdAccID.Value = "3"
        lblTCode.Text = "R"
        lblTopic.Text = "3. ความเสี่ยงในการมียาหมดอายุบนชั้นยา ระบุแนวทางในการป้องกัน"
        LoadImg()
        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalUpload(this,'3');", True)
    End Sub
    Protected Sub imgRisk4_Click(sender As Object, e As EventArgs) Handles imgRisk4.Click
        Dim fPath As String = "imageUploads/" & hdLocationUID.Value & "/QA/"
        hdAccID.Value = "4"
        lblTCode.Text = "R"
        lblTopic.Text = "4. ความเสี่ยงในเรื่องอุณหภูมิในร้านที่ไม่เหมาะในการเก็บรักษายา ระบุแนวทางในการป้องกัน"
        LoadImg()
        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalUpload(this,'4');", True)
    End Sub
    Protected Sub imgRisk5_Click(sender As Object, e As EventArgs) Handles imgRisk5.Click
        Dim fPath As String = "imageUploads/" & hdLocationUID.Value & "/QA/"
        hdAccID.Value = "5"
        lblTCode.Text = "R"
        lblTopic.Text = "5. ความเสี่ยงในการป้องกันการแพร่เชื้อ Covid 19 ในร้าน( ระหว่างลูกค้า กับ ลูกค้า , ระหว่าง ลูกค้า กับ เภสัช) ระบุแนวทางในการป้องกัน"
        LoadImg()
        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalUpload(this,'5');", True)
    End Sub
    Protected Sub imgRisk6_Click(sender As Object, e As EventArgs) Handles imgRisk6.Click
        Dim fPath As String = "imageUploads/" & hdLocationUID.Value & "/QA/"
        hdAccID.Value = "6"
        lblTCode.Text = "R"
        lblTopic.Text = "6. ความเสี่ยงในการจ่ายยาที่ลูกค้าเคยแพ้ ระบุแนวทางในการป้องกัน"
        LoadImg()
        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalUpload(this,'6');", True)
    End Sub
    Protected Sub imgRisk7_Click(sender As Object, e As EventArgs) Handles imgRisk7.Click
        Dim fPath As String = "imageUploads/" & hdLocationUID.Value & "/QA/"
        hdAccID.Value = "7"
        lblTCode.Text = "R"
        lblTopic.Text = "7. ความเสี่ยงที่เกิดกับคนไข้ที่มีโรคหรืออาการรุนแรงมาปรึกษาและท่านไม่สามารถให้คำแนะนำในการใช้ยาได้ ท่านมี แนวทางในการดำเนินการอย่างไร"
        LoadImg()
        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalUpload(this,'7');", True)
    End Sub
    Protected Sub imgRisk8_Click(sender As Object, e As EventArgs) Handles imgRisk8.Click
        Dim fPath As String = "imageUploads/" & hdLocationUID.Value & "/QA/"
        hdAccID.Value = "8"
        lblTCode.Text = "R"
        lblTopic.Text = "8. ความเสี่ยงในการจ่ายยาให้ผู้ป่วยแล้วเกิด Drug Interaction ท่านมี แนวทางในการป้องกันอย่างไร"
        LoadImg()
        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalUpload(this,'8');", True)
    End Sub
    Protected Sub imgRisk9_Click(sender As Object, e As EventArgs) Handles imgRisk9.Click
        Dim fPath As String = "imageUploads/" & hdLocationUID.Value & "/QA/"
        hdAccID.Value = "9"
        lblTCode.Text = "R"
        lblTopic.Text = "9. ท่านจะลดความเสี่ยงของที่ผู้ที่มารับบริการในการเกิดปัญหาจากการใช้ยา ท่านมีแนวทางในการป้องกันอย่างไร"
        LoadImg()
        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalUpload(this,'9');", True)
    End Sub
    Protected Sub imgRisk10_Click(sender As Object, e As EventArgs) Handles imgRisk10.Click
        Dim fPath As String = "imageUploads/" & hdLocationUID.Value & "/QA/"
        hdAccID.Value = "10"
        lblTCode.Text = "R"
        lblTopic.Text = "10. ความเสี่ยงในการจัดการขยะที่เป็นยาเสีย ยาหมดอายุ ที่ทำให้เป็นพิษต่อสิ่งแวดล้อม ท่านมีแนวทางจัดการอย่างไร"
        LoadImg()
        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalUpload(this,'10');", True)
    End Sub

    Protected Sub imgQ2_Click(sender As Object, e As EventArgs) Handles imgQ2.Click
        Dim fPath As String = "imageUploads/" & hdLocationUID.Value & "/QA/"
        hdAccID.Value = "2"
        lblTCode.Text = "Q"
        lblTopic.Text = "2.ท่านมีกิจกรรม หรือ ทำอะไรตามมาตรฐาน 5 ( กิจกรรม / บริการสู่ชุมชนภายนอก )"
        LoadImg()
        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalUpload(this,'2');", True)
    End Sub
    Protected Sub imgQ3_Click(sender As Object, e As EventArgs) Handles imgQ3.Click
        Dim fPath As String = "imageUploads/" & hdLocationUID.Value & "/QA/"
        hdAccID.Value = "3"
        lblTCode.Text = "Q"
        lblTopic.Text = "3.ท่านมีระบบการส่งต่อ กรณีที่จำเป็นหรือไม่"
        LoadImg()
        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalUpload(this,'3');", True)
    End Sub
    Protected Sub imgQ4_Click(sender As Object, e As EventArgs) Handles imgQ4.Click
        Dim fPath As String = "imageUploads/" & hdLocationUID.Value & "/QA/"
        hdAccID.Value = "4"
        lblTCode.Text = "Q"
        lblTopic.Text = "5.ท่านมีcase ที่ประทับใจในการเป็น  เภสัชกรชุมชนที่ผ่านมา ( Case Report )"
        LoadImg()
        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalUpload(this,'4');", True)
    End Sub
    Protected Sub imgQ5_Click(sender As Object, e As EventArgs) Handles imgQ5.Click
        Dim fPath As String = "imageUploads/" & hdLocationUID.Value & "/QA/"
        hdAccID.Value = "5"
        lblTCode.Text = "Q"
        lblTopic.Text = "6.กิจกรรมทางวิชาชีพเภสัชกรรมชุมชน เช่น การเป็นพี่เลี้ยงร้านยาคุณภาพ การเป็นอาจารย์แหล่งฝึก หรือได้รับรางวัลทางวิชาชีพ ( ย้อนหลังไม่เกิน 3 ปี )"
        LoadImg()
        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalUpload(this,'5');", True)
    End Sub
    Protected Sub imgQ6_Click(sender As Object, e As EventArgs) Handles imgQ6.Click
        Dim fPath As String = "imageUploads/" & hdLocationUID.Value & "/QA/"
        hdAccID.Value = "6"
        lblTCode.Text = "Q"
        lblTopic.Text = "4.ท่านมีรายงานอาการไม่พึงประสงค์ในการใช้ยา  ย้อนหลัง 2 ปี อย่างไร "
        LoadImg()
        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalUpload(this,'6');", True)
    End Sub
    Private Sub cmdApprove_Click(sender As Object, e As EventArgs) Handles cmdApprove.Click
        Dim Score1, Score2, Score3 As Double
        Dim AsmStatus As String

        If chkStatus.Checked = True Then
            AsmStatus = "Y"
        Else
            AsmStatus = "N"
        End If

        Score1 = StrNull2Double(txtProjectScore.Text)
        Score2 = StrNull2Double(txtRiskScore.Text)
        Score3 = StrNull2Double(txtQAScore.Text)

        ctlA.QA_AssessmentScore_Save(StrNull2Long(hdQAUID.Value), StrNull2Long(hdRequestUID.Value), Score1, txtProjectComment.Text, Score2, txtRiskComment.Text, Score3, txtQAComment.Text, AsmStatus, StrNull2Zero(Request.Cookies("UserID").Value))
        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalSuccess(this,'Success','บันทึกข้อมูลเรียบร้อย');", True)

    End Sub

    Private Sub cmdUpImgPJ_Click(sender As Object, e As EventArgs) Handles cmdUpImgPJ.Click
        UploadFiles(FileUploadProject, StrNull2Zero(hdProjUID.Value), "P")
        LoadProjectImg()
    End Sub

    Private Sub DeleteImageByGroup(ImgGroup As String, RefUID As String)
        dt = ctlM.Media_GetImagePath(Request("id"), hdLocationUID.Value, ImgGroup, RefUID)
        If dt.Rows.Count > 0 Then
            Dim sPath As String = ""
            Select Case ImgGroup
                Case "S", "L", "A", "M"
                    sPath = "/Locations/"
                Case "G"
                    sPath = "/GPP/"
                Case "P", "R", "Q"
                    sPath = "/QA/"
            End Select

            For i = 0 To dt.Rows.Count - 1
                sPath = ""
                Dim objfile As FileInfo = New FileInfo(Server.MapPath("~/imageUploads/" & hdLocationUID.Value & sPath & dt.Rows(i)("FilePath")))
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
                    sPath = "/Locations/"
                Case "G"
                    sPath = "/GPP/"
                Case "P", "R", "Q"
                    sPath = "/QA/"
            End Select

            Dim objfile As FileInfo = New FileInfo(Server.MapPath("~/imageUploads/" & hdLocationUID.Value & sPath & dt.Rows(0)("FilePath")))
            If objfile.Exists Then
                objfile.Delete()
            End If

        End If
    End Sub

End Class

