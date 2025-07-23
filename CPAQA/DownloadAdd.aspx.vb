Imports System.IO
Imports BigLion
Public Class DownloadAdd
    Inherits System.Web.UI.Page

    Dim dt As New DataTable
    Dim ctlD As New DownloadController

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If IsNothing(Request.Cookies("UserLogin").Value) Then
        '    Response.Redirect("Login.aspx")
        'End If

        If Not IsPostBack Then
            ClearData()
            'LoadGroup()
            LoadCategory()
            'LoadType()
            'ddlGroup.SelectedIndex = 0

            'If ddlGroup.SelectedValue = "2" Then
            '    lblTypeUID.Visible = True
            '    ddlType.Visible = True
            'Else
            '    lblTypeUID.Visible = False
            '    ddlType.Visible = False
            'End If


            If Not Request("id") = Nothing Then
                LoadDataEdit(Request("id"))
            End If

        End If
    End Sub

    Private Sub LoadDataEdit(ByVal tid As Integer)
        dt = ctlD.Download_GetByUID(tid)
        If dt.Rows.Count > 0 Then
            With dt.Rows(0)
                isAdd = False
                Me.lblUID.Text = DBNull2Str(dt.Rows(0)("UID"))
                txtDescriptions.Text = DBNull2Str(dt.Rows(0)("Descriptions"))

                'ddlGroup.SelectedValue = DBNull2Str(dt.Rows(0)("GroupUID"))
                'LoadCategory()
                ddlCategory.SelectedValue = DBNull2Str(dt.Rows(0)("CategoryUID"))

                'If DBNull2Str(dt.Rows(0)("GroupUID")) = "2" Then
                '    lblTypeUID.Visible = True
                '    ddlType.Visible = True
                '    ddlType.SelectedValue = DBNull2Str(dt.Rows(0)("TypeUID"))
                'Else
                '    lblTypeUID.Visible = False
                '    ddlType.Visible = False

                'End If

                hlnkDoc.Text = DBNull2Str(dt.Rows(0)("filePath"))
                hlnkDoc.NavigateUrl = "../" & DownloadPath & "/" & DBNull2Str(dt.Rows(0)("filePath"))
                hlnkDoc.Visible = True

                If String.Concat(.Item("isMember")) = "Y" Then
                    chkIsMember.Checked = True
                Else
                    chkIsMember.Checked = False
                End If
                If String.Concat(.Item("StatusFlag")) = "A" Then
                    chkStatus.Checked = True
                Else
                    chkStatus.Checked = False
                End If


                If String.Concat(.Item("SiteFlag")) <> "" Then
                    Dim siteF() As String
                    siteF = Split(String.Concat(.Item("SiteFlag")), "|")
                    For i = 0 To siteF.Length - 1
                        Select Case siteF(i)
                            Case "1"
                                chkNews1.Checked = True
                            Case "2"
                                chkNews2.Checked = True
                        End Select
                    Next
                Else
                    chkNews1.Checked = True
                    chkNews2.Checked = True
                End If

            End With
        End If
        dt = Nothing
    End Sub


    Protected Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click

        If txtDescriptions.Text.Trim = "" Then
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','ท่านยังไม่ได้ระบุรายละเอียด');", True)
            Exit Sub
        End If

        Dim f_Icon, f_Extension, f_Path, cate As String
        f_Icon = ""
        f_Extension = ""
        f_Path = ""
        cate = ""
        Dim DownloadID, TypeUID As Integer
        TypeUID = 0
        Select Case ddlCategory.SelectedValue
            Case "1"
                cate = "Document_"
            Case "2"
                cate = "Manual_"
            Case "3"
                cate = "Regulation_"
            Case else
                cate = "Form_"
        End Select

        If hlnkDoc.Text = "" Then
            If FileUpload1.PostedFile.FileName = "" Then
                ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','ท่านยังไม่ได้เลือกไฟล์สำหรับอัพโหลด');", True)
                Exit Sub
            End If
        End If

        Dim siteF As String = ""
        If chkNews1.Checked = True Then
            siteF = "1"
        End If
        If chkNews2.Checked = True Then
            If siteF <> "" Then
                siteF = siteF + "|2"
            Else
                siteF = "2"
            End If
        End If


        If lblUID.Text = "" Then
            ctlD.Download_Add(ddlCategory.SelectedValue, TypeUID, txtDescriptions.Text, f_Icon, f_Extension, f_Path, 0, ConvertBoolean2YN(chkIsMember.Checked), ConvertBoolean2StatusFlag(chkStatus.Checked), Request.Cookies("UserID").Value, siteF)
            DownloadID = ctlD.Download_GetLastUID(ddlCategory.SelectedValue, 0, txtDescriptions.Text, Request.Cookies("UserID").Value)
        Else
            DownloadID = StrNull2Zero(lblUID.Text)
            ctlD.Download_Update(DownloadID, ddlCategory.SelectedValue, TypeUID, txtDescriptions.Text, 0, ConvertBoolean2YN(chkIsMember.Checked), ConvertBoolean2StatusFlag(chkStatus.Checked), Request.Cookies("UserID").Value, siteF)
        End If

        If FileUpload1.HasFile Then
            f_Path = cate & DownloadID.ToString() & Path.GetExtension(FileUpload1.PostedFile.FileName)
            f_Extension = Path.GetExtension(FileUpload1.PostedFile.FileName)
            Select Case f_Extension.ToLower()
                Case ".pdf"
                    f_Icon = "pdf.png"
                Case ".doc", ".docx"
                    f_Icon = "word.png"
                Case ".jpg", ".jpeg", ".png"
                    f_Icon = "photo.png"
                Case ".ppt", ".pptx"
                    f_Icon = "ppt.png"
                Case ".xls", ".xlsx"
                    f_Icon = "excel.png"
                Case Else
                    f_Icon = ""
            End Select

            ctlD.Download_UpdateFile(DownloadID, f_Icon, f_Extension, f_Path, Request.Cookies("UserID").Value)
            UploadFile(FileUpload1, f_Path)


        End If

        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalSuccess(this,'Success','บันทึกข้อมูลเรียบร้อย');", True)
        ClearData()
        'Response.Redirect("DownloadList.aspx")
    End Sub
    Sub UploadFile(ByVal Fileupload As Object, sName As String)
        Dim FileFullName As String = Fileupload.PostedFile.FileName
        Dim FileNameInfo As String = Path.GetFileName(FileFullName)
        Dim filename As String = Path.GetFileName(Fileupload.PostedFile.FileName)
        Dim objfile As FileInfo = New FileInfo(Server.MapPath(DownloadPath))
        If FileNameInfo <> "" Then
            Fileupload.PostedFile.SaveAs(objfile.DirectoryName & "\" & sName)
        End If
        objfile = Nothing
    End Sub


    Protected Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click

        Response.Redirect("DocumentList.aspx?m=d")
    End Sub
    Private Sub ClearData()
        lblUID.Text = ""
        txtDescriptions.Text = ""
        hlnkDoc.Text = ""
        chkStatus.Checked = True
    End Sub

    'Protected Sub ddlGroup_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlGroup.SelectedIndexChanged
    '    LoadCategory()
    '    'If ddlGroup.SelectedValue = "2" Then
    '    '    lblTypeUID.Visible = True
    '    '    ddlType.Visible = True
    '    'Else
    '    '    lblTypeUID.Visible = False
    '    '    ddlType.Visible = False
    '    'End If
    'End Sub
    Private Sub LoadCategory()
        Dim dtCate As New DataTable
        dtCate = ctlD.Download_Category_Get()
        ddlCategory.DataSource = dtCate
        ddlCategory.DataTextField = "Name"
        ddlCategory.DataValueField = "UID"
        ddlCategory.DataBind()

        dtCate = Nothing
    End Sub
    'Private Sub LoadGroup()
    '    Dim dtG As New DataTable
    '    dtG = ctlD.Download_Group_Get()
    '    ddlGroup.DataSource = dtG
    '    ddlGroup.DataTextField = "Name"
    '    ddlGroup.DataValueField = "UID"
    '    ddlGroup.DataBind()
    '    ddlGroup.SelectedIndex = 0
    '    dtG = Nothing
    'End Sub

    Protected Sub ddlCategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlCategory.SelectedIndexChanged
        'If ddlGroup.SelectedValue = "2" Then
        '    lblTypeUID.Visible = True
        '    ddlType.Visible = True
        'Else
        '    lblTypeUID.Visible = False
        '    ddlType.Visible = False
        'End If
    End Sub
    'Private Sub LoadType()
    '    Dim dtG As New DataTable
    '    dtG = ctlD.Download_Type_Get(ddlCategory.SelectedValue)
    '    ddlType.DataSource = dtG
    '    ddlType.DataTextField = "Name"
    '    ddlType.DataValueField = "UID"
    '    ddlType.DataBind()
    '    ddlType.SelectedIndex = 0
    '    dtG = Nothing
    'End Sub

End Class