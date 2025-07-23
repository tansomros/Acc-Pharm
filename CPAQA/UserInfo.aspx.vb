Imports System.Drawing
Imports System.IO
Imports DevExpress.Web
Imports DevExpress.Web.Internal
Imports BigLion
Public Class UserInfo
    Inherits System.Web.UI.Page
    Dim ctlU As New UserController
    Dim ctlM As New MasterController
    Dim dt As New DataTable
    Dim sAlert As String
    Dim isValid As Boolean
    Private Const UploadDirectory As String = "~/images/users/"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If IsNothing(Request.Cookies("UserLogin").Value) Then
        '    Response.Redirect("Login.aspx")
        'End If

        If Not IsPostBack Then
            pnAlert.Visible = False
            pnSuccess.Visible = False
            lblUserID.Text = ""
            If Not Request("uid") Is Nothing Then
                If Request("uid") = "" Then
                    EditData(Request.Cookies("UserLoginID").Value)
                Else
                    EditData(Request("pid"))
                End If
            Else
                EditData(Request.Cookies("UserID").Value)
            End If
        End If

        txtMail.Attributes.Add("OnKeyPress", "return NotAllowThai();")
    End Sub
    Private Sub EditData(ByVal UserID As Integer)
        Dim dtU As New DataTable
        dtU = ctlU.User_GetByUserID(UserID)
        If dtU.Rows.Count > 0 Then
            With dtU.Rows(0)
                isAdd = False
                Me.lblUserID.Text = DBNull2Str(dtU.Rows(0)("UserID"))
                lblUsername.Text = DBNull2Str(dtU.Rows(0)("Username"))
                txtFnameTH.Text = DBNull2Str(dtU.Rows(0)("DisplayName"))
                txtTel.Text = DBNull2Str(dtU.Rows(0)("Telephone"))
                txtMail.Text = DBNull2Str(dtU.Rows(0)("Email"))
                Session("userimg") = dtU.Rows(0).Item("ImagePath")

                'If DBNull2Str(dtU.Rows(0).Item("ImagePath")) <> "" Then
                '    Dim objfile As FileInfo = New FileInfo(Server.MapPath("~/" & userpic & "/" & dtU.Rows(0).Item("ImagePath")))
                'End If
            End With
        End If
        dt = Nothing
    End Sub
    Protected Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click

        If ValidateData() = False Then
            pnAlert.Visible = True
            lblAlert.Text = sAlert
            Exit Sub
        Else
            pnAlert.Visible = False
        End If

        ctlU.User_SaveByUser(StrNull2Zero(lblUserID.Text), txtFnameTH.Text, txtTel.Text, txtMail.Text, Request.Cookies("UserID").Value)


        If Not Session("picname") Is Nothing Then
            ctlU.User_UpdateFileName(StrNull2Zero(lblUserID.Text), lblUserID.Text & Path.GetExtension(Session("picname")))

            'UploadFile(FileUpload1, lblUserID.Text & Path.GetExtension(FileUpload1.PostedFile.FileName))

            RenamePictureName()
        End If
        pnSuccess.Visible = True
        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalSuccess(this,'Success','บันทึกข้อมูลเรียบร้อย');", True)
        'Response.Redirect("UserInfo.aspx?uid=" & lblUserID.Text)

    End Sub
    Private Sub RenamePictureName()
        Dim Path As String = Server.MapPath(UploadDirectory)
        Dim Fromfile As String = Path + Session("picname")
        Dim Tofile As String = Path + lblUserID.Text + ".jpg"

        Dim objfile As FileInfo = New FileInfo(Server.MapPath("~/" & PictureUser & "/" & lblUserID.Text + ".jpg"))

        If objfile.Exists Then
            objfile.Delete()
        End If

        File.Move(Fromfile, Tofile)

    End Sub
    Sub UploadFile(ByVal Fileupload As Object, sName As String)
        Dim FileFullName As String = Fileupload.PostedFile.FileName
        Dim FileNameInfo As String = Path.GetFileName(FileFullName)
        Dim filename As String = Path.GetFileName(Fileupload.PostedFile.FileName)
        Dim objfile As FileInfo = New FileInfo(Server.MapPath("../" & PictureUser & "/"))
        If FileNameInfo <> "" Then
            'Fileupload.PostedFile.SaveAs(objfile.DirectoryName & "\" & filename)
            Fileupload.PostedFile.SaveAs(objfile.DirectoryName & "\" & sName)
        End If
        objfile = Nothing
    End Sub
    Function Check_Email(str As String) As Boolean
        Return Regex.IsMatch(str, "\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*")
    End Function
    Function ValidateData() As Boolean
        sAlert = "กรุณาตรวจสอบ <br />"
        isValid = True

        If txtMail.Text = "" Then
            sAlert &= "- กรุณากรอก E-mail <br/>"
            isValid = False
        End If

        If Check_Email(txtMail.Text) = False Then
            sAlert &= "- รูปแบบ E-mail ไม่ถูกต้อง กรุณาตรวจสอบ<br/>"
            isValid = False
        End If

        'If txtStartDate.Text = "" Then
        '    sAlert &= "- ระบุวันที่ให้ครบถ้วน <br/>"
        '    isValid = False
        'End If

        'If Not CheckDateValid(txtStartDate.Text) Then
        '    sAlert &= "- ตรวจสอบวันที่ให้ถูกต้อง <br/>"
        '    isValid = False
        'End If


        'If txtPresentType.Text = "" Then
        '    sAlert &= "- ประเภทผลงาน <br/>"
        '    isValid = False
        'End If


        If txtFnameTH.Text.Trim = "" Then
            sAlert &= "- ชื่อ <br/>"
            isValid = False

        End If
        Return isValid

    End Function

    'Protected Sub cmdSavePicture_Click(sender As Object, e As EventArgs) Handles cmdSavePicture.Click
    '    If FileUpload1.HasFile Then
    '        ctlU.User_UpdateFileName(StrNull2Zero(lblUserID.Text), lblUserID.Text & Path.GetExtension(FileUpload1.PostedFile.FileName))
    '        UploadFile(FileUpload1, lblUserID.Text & Path.GetExtension(FileUpload1.PostedFile.FileName))
    '    End If

    '    Dim objfile As FileInfo = New FileInfo(Server.MapPath("~/" & UserPic & "/" & lblUserID.Text & ".jpg"))

    '    If objfile.Exists Then
    '        imgPerson.ImageUrl = "~/" & userpic & "/" & lblPersonID.Text & ".jpg"
    '        lblNoSuccess.Visible = False
    '    Else
    '        'imgPerson.ImageUrl = "~/" & userpic & "/nopic.jpg"
    '        lblNoSuccess.Visible = True
    '    End If
    '    imgPerson.ImageUrl = "~/images/users/" + Session("picname")

    'End Sub

    Protected Sub UploadControl_FileUploadComplete(ByVal sender As Object, ByVal e As FileUploadCompleteEventArgs)

        If chkFileExist(Server.MapPath(UploadDirectory + Session("picname"))) Then
            File.Delete(Server.MapPath(UploadDirectory + Session("picname")))
        End If

        e.CallbackData = SavePostedFile(e.UploadedFile, UploadDirectory, Path.GetRandomFileName())
        Session("picname") = e.CallbackData
    End Sub
    Protected Function SavePostedFile(ByVal uploadedFile As UploadedFile, ByVal UploadPath As String, ByVal UploadFileName As String) As String
        If (Not uploadedFile.IsValid) Then
            Return String.Empty
        End If

        Dim fileName As String = Path.ChangeExtension(UploadFileName, ".jpg")

        Dim fullFileName As String = CombinePath(UploadPath, fileName)
        Using original As Image = Image.FromStream(uploadedFile.FileContent)
            Using thumbnail As Image = New ImageThumbnailCreator(original).CreateImageThumbnail(New Size(350, 350))
                ImageUtils.SaveToJpeg(CType(thumbnail, Bitmap), fullFileName)
            End Using
        End Using
        UploadingUtils.RemoveFileWithDelay(fileName, fullFileName, 5)
        Return fileName
    End Function
    Protected Function CombinePath(ByVal UploadPath As String, ByVal fileName As String) As String
        Return Path.Combine(Server.MapPath(UploadPath), fileName)
    End Function
End Class