Imports System
Imports System.IO
Imports System.Web.UI
Imports DevExpress.Web
Imports BigLion
Public Class Self
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

                LoadSelf_Assessment(Request("id"))
                LoadLocationDetail(hdLocationUID.Value)

                UploadDirectory = Server.MapPath("~/imageUploads/" & hdLocationUID.Value & "/Self/")

                If Not Directory.Exists(UploadDirectory) Then
                    Directory.CreateDirectory(UploadDirectory)
                End If
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
    Private Sub LoadSelf_Assessment(RequestUID As Integer)
        dt = ctlA.QA_Assessment_GetByRequestUID(RequestUID)
        If dt.Rows.Count > 0 Then
            hdSelfUID.Value = String.Concat(dt.Rows(0)("UID"))
            hdLocationUID.Value = String.Concat(dt.Rows(0)("LocationUID"))
            hdRequestUID.Value = String.Concat(dt.Rows(0)("RequestUID"))
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
                    FileUpload1.Enabled = False
                    cmdUpImg.Visible = False
                    grdImg.Columns(3).Visible = False
                    Label2.Visible = True
                    Label2.Text = "สถานะปัจจุบันไม่สามารถออัพโหลดหรือแก้ไขรูปภาพได้อีก"
                End If
            ElseIf iStatus = 0 Then 'ยกเลิก

            End If
        End If

    End Sub

    Private Sub Assessment_Save(RequestUID As Long)
        Dim ctlA As New AssessmentController
        ctlA.Assessment_Save(RequestUID, StrNull2Zero(hdLocationUID.Value), Request.Cookies("UserID").Value)
    End Sub

    Private Sub PreviewPicture(Fname As String, Desc As String, filePath As String)
        Dim fPath As String = "imageUploads/" & hdLocationUID.Value & "/Self/"
        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWindow(this,'" + Fname + "','" + Desc + "','" + fPath + filePath + "?v=" & ConvertDate2DBString(Now.Date) & ConvertTimeToString(Now()) & "');", True)
    End Sub

    Private Sub LoadImg()
        dt = ctlM.Media_Get(StrNull2Zero(Request("id")), StrNull2Zero(hdLocationUID.Value), "QS", StrNull2Long(hdAccID.Value))
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
        UploadFiles(FileUpload1, hdAccID.Value, "QS")
        LoadImg()
    End Sub

    Private Sub cmdBack_Click(sender As Object, e As EventArgs) Handles cmdBack.Click
        Response.Redirect("RequestDetail?id=" & Request("id"))
    End Sub
    Private Sub UploadFiles(ByVal Fileupload As Object, REFUID As Integer, sCode As String)
        Dim SEQNO As String
        Dim sfileName As String = ""
        UploadDirectory = Server.MapPath("imageUploads/" & hdLocationUID.Value & "/Self/")

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

                Dim objfile As FileInfo = New FileInfo("imageUploads/" & hdLocationUID.Value & "/Self/" & sfileName)
                If objfile.Exists Then
                    objfile.Delete()
                End If
                uploadedFile.SaveAs(System.IO.Path.Combine(UploadDirectory, sfileName))
                ctlM.Media_Save(StrNull2Zero(hdRequestUID.Value), StrNull2Zero(lblYear.Text), hdLocationUID.Value, sCode, REFUID, SEQNO, sfileName, Request.Cookies("UserID").Value)
            Next
        End If
    End Sub

    Protected Sub imgRisk1_Click(sender As Object, e As EventArgs) Handles imgRisk1.Click
        Dim fPath As String = "imageUploads/" & hdLocationUID.Value & "/Self/"
        hdAccID.Value = "1"
        'lblTCode.Text = "QS"
        lblTopic.Text = "1. สมุนไพร"
        LoadImg()
        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalUpload(this,'1');", True)
    End Sub
    Protected Sub imgRisk2_Click(sender As Object, e As EventArgs) Handles imgRisk2.Click
        Dim fPath As String = "imageUploads/" & hdLocationUID.Value & "/Self/"
        hdAccID.Value = "2"
        'lblTCode.Text = "QS"
        lblTopic.Text = "2. ยาสามัญประจำบ้าน"
        LoadImg()
        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalUpload(this,'2');", True)
    End Sub
    Protected Sub imgRisk3_Click(sender As Object, e As EventArgs) Handles imgRisk3.Click
        Dim fPath As String = "imageUploads/" & hdLocationUID.Value & "/Self/"
        hdAccID.Value = "3"
        'lblTCode.Text = "QS"
        lblTopic.Text = "3. ยาบรรจุเสร็จ (บางรายการ)"
        LoadImg()
        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalUpload(this,'3');", True)
    End Sub
    Protected Sub imgRisk4_Click(sender As Object, e As EventArgs) Handles imgRisk4.Click
        Dim fPath As String = "imageUploads/" & hdLocationUID.Value & "/Self/"
        hdAccID.Value = "4"
        'lblTCode.Text = "QS"
        lblTopic.Text = "4. ผลิตภัณฑ์ที่มิใช่ยา อุปกรณ์ วัสดุการแพทย์"
        LoadImg()
        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalUpload(this,'4');", True)
    End Sub
    Protected Sub imgRisk5_Click(sender As Object, e As EventArgs) Handles imgRisk5.Click
        Dim fPath As String = "imageUploads/" & hdLocationUID.Value & "/Self/"
        hdAccID.Value = "5"
        'lblTCode.Text = "QS"
        lblTopic.Text = "5. ยาแผนโบราณ"
        LoadImg()
        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalUpload(this,'5');", True)
    End Sub
    Protected Sub imgRisk6_Click(sender As Object, e As EventArgs) Handles imgRisk6.Click
        Dim fPath As String = "imageUploads/" & hdLocationUID.Value & "/Self/"
        hdAccID.Value = "6"
        'lblTCode.Text = "QS"
        lblTopic.Text = "6. อาหารเสริม"
        LoadImg()
        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalUpload(this,'6');", True)
    End Sub
    Protected Sub imgRisk7_Click(sender As Object, e As EventArgs) Handles imgRisk7.Click
        Dim fPath As String = "imageUploads/" & hdLocationUID.Value & "/Self/"
        hdAccID.Value = "7"
        'lblTCode.Text = "QS"
        lblTopic.Text = "7. อื่นๆ"
        LoadImg()
        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalUpload(this,'7');", True)
    End Sub

    Private Sub DeleteImageByGroup(ImgGroup As String, RefUID As String)
        dt = ctlM.Media_GetImagePath(Request("id"), hdLocationUID.Value, ImgGroup, RefUID)
        If dt.Rows.Count > 0 Then
            Dim sPath As String = "Self"
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
            Dim sPath As String = "Self"
            Dim objfile As FileInfo = New FileInfo(Server.MapPath("~/imageUploads/" & hdLocationUID.Value & sPath & dt.Rows(0)("FilePath")))
            If objfile.Exists Then
                objfile.Delete()
            End If

        End If
    End Sub

End Class

