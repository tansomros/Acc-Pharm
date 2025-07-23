Imports System.IO
Imports System.Drawing
'Imports Newtonsoft.Json
Imports BigLion
Imports DevExpress.XtraRichEdit.Import.OpenXml
Public Class Pharmacist
    Inherits System.Web.UI.Page
    Dim dt As New DataTable
    Dim ctlM As New MasterController
    Dim ctlL As New LocationController
    Private UploadDirectory As String

    Dim ctlPs As New PharmacistController
    Dim ctlMd As New MediaController
    Dim ctlU As New UserController
    Dim ctlD As New DocumentController

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If IsNothing(Request.Cookies("CPAQA")) Then
        '    Response.Redirect("Default.aspx")
        'End If
        Response.Cache.SetExpires(DateTime.Now.AddSeconds(60))
        Response.Cache.SetCacheability(HttpCacheability.Public)
        Response.Cache.SetValidUntilExpires(True)

        If Not IsPostBack Then
            txtPLicense.Text = ""
            If Not Request("lid") = Nothing Then
                LoadLocationData(Request("lid"))
                LoadPharmacist()
                LoadImgPharmacist()
            End If

            If Request.Cookies("ROLE_ID").Value = "1" Then
                ddlPType.SelectedIndex = 1
                ddlPType.Enabled = False
            End If

        End If

        txtPLicense.Attributes.Add("OnKeyPress", "return AllowOnlyIntegers();")
    End Sub
    Private Sub LoadLocationData(ByVal pID As String)
        Dim dtL As New DataTable

        dtL = ctlL.Location_GetByUID(pID)
        If dtL.Rows.Count > 0 Then
            With dtL.Rows(0)
                hdLocationUID.Value = .Item("UID")

                UploadDirectory = Server.MapPath("~/imageUploads/" + String.Concat(.Item("UID")) + "/Locations/")
                If Not Directory.Exists(UploadDirectory) Then
                    Directory.CreateDirectory(UploadDirectory)
                End If

                lblLocationName.Text = String.Concat(.Item("LocationName"))
                lblAddress.Text = String.Concat(.Item("LocationAddress"))
            End With
        End If
        dtL = Nothing
    End Sub

    Private Sub PreviewPicture(Fname As String, Desc As String, filePath As String)
        'Dim fPath As String = "imageUploads/Locations/" & hdLocationUID.Value & "/"
        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWindow(this,'" + Fname + "','" + Desc + "','" + filePath + "');", True)
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
        grdTime.Visible = False
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
                        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalSuccess(this,'Success','ลบข้อมูลเรียบร้อย');", True)
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
        '    dt = ctlPs.PharmacistTime_Get(StrNull2Zero(hdPharmacistUID.Value))
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
End Class