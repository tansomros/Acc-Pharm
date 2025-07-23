Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.Configuration
Imports System.IO
Imports BigLion
Public Class NewsAdd
    Inherits System.Web.UI.Page

    'Dim _from As String = ""

    Dim dtNews As New DataTable
    Dim ctlN As New NewsController

    Dim sContent, sFile As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If IsNothing(Request.Cookies("UserLogin").Value) Then
        '    Response.Redirect("Login.aspx")
        'End If

        If Not Page.IsPostBack Then
            cmdDelFile.Visible = False

            If Not Request("cate") Is Nothing Then
                ddlCategory.SelectedValue = Request("cate").ToUpper()
            End If

            If Not Request("NewsID") Is Nothing Then
                EditNews(Request("NewsID"))
            Else
                lblNewsID.Text = ctlN.News_GetNextNewsID().ToString()
            End If

            Dim folder As String = Server.MapPath("~/" + ImageNews + lblNewsID.Text)
            If Not Directory.Exists(folder) Then
                Directory.CreateDirectory(folder)
            End If
            'ASPxFileManager1.Settings.RootFolder = folder
            ShowNewsType()
        End If
    End Sub
    Private Sub ShowNewsType()
        pnURL.Visible = False
        pnFile.Visible = False
        pnContent.Visible = False
        'pnFileManager.Visible = False
        pnContentFile.Visible = False
        Select Case optType.SelectedValue
            Case "URL"
                pnURL.Visible = True
            Case "UPL"
                pnFile.Visible = True
            Case "CON"
                pnContent.Visible = True
                pnContentFile.Visible = True
                'pnFileManager.Visible = True
        End Select
    End Sub
    Private Sub EditNews(NewsID As Integer)
        dtNews = ctlN.News_GetByID(NewsID)
        If dtNews.Rows.Count > 0 Then
            lblNewsID.Text = NewsID.ToString()
            txtHead.Text = String.Concat(dtNews.Rows(0).Item("NewsHead"))
            txtDetail.Html = String.Concat(dtNews.Rows(0).Item("NewsDetail"))
            ddlCategory.SelectedValue = String.Concat(dtNews.Rows(0).Item("NewsCate"))
            optType.SelectedValue = String.Concat(dtNews.Rows(0).Item("NewsType"))

            If String.Concat(dtNews.Rows(0).Item("SiteFlag")) <> "" Then
                Dim siteF() As String
                siteF = Split(String.Concat(dtNews.Rows(0).Item("SiteFlag")), "|")
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

            Select Case optType.SelectedValue
                Case "URL"
                    txtURL.Text = String.Concat(dtNews.Rows(0).Item("LinkPath"))
                Case "UPL"
                    hlnkNews.Text = String.Concat(dtNews.Rows(0).Item("FilePath"))
                    hlnkNews.NavigateUrl = ImageNews + lblNewsID.Text + "/" + String.Concat(dtNews.Rows(0).Item("FilePath"))
                Case "CON"
                    'ASPxFileManager1.Settings.RootFolder = "~/Images/News//" + NewsID.ToString() + "/"
                    If String.Concat(dtNews.Rows(0).Item("AttachFileName")) <> "" And String.Concat(dtNews.Rows(0).Item("AttachFileName")) <> "ไม่มีเอกสารแนบ" Then
                        hlnkAttachs.Text = dtNews.Rows(0).Item("AttachFileName").ToString()
                        hlnkAttachs.NavigateUrl = ImageNews + lblNewsID.Text + "/" + dtNews.Rows(0).Item("AttachFileName").ToString()
                        cmdDelFile.Visible = True
                    Else
                        hlnkAttachs.Text = ""
                        cmdDelFile.Visible = False
                    End If
            End Select

            If Convert.ToString(dtNews.Rows(0).Item("CoverImagePath")) <> "" Then
                imgCover.ImageUrl = ImageCoverNews + dtNews.Rows(0).Item("CoverImagePath").ToString()
            Else
                imgCover.ImageUrl = ""
            End If

            If String.Concat(dtNews.Rows(0).Item("isMember")) = "Y" Then
                chkIsMember.Checked = True
            Else
                chkIsMember.Checked = False
            End If
            If String.Concat(dtNews.Rows(0).Item("StatusFlag")) = "A" Then
                chkStatus.Checked = True
            Else
                chkStatus.Checked = False
            End If

            ShowNewsType()
        End If
    End Sub
    Protected Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        Response.Redirect("NewsList.aspx?m=n")
    End Sub

    Protected Sub bttSave_Click(sender As Object, e As System.EventArgs) Handles bttSave.Click

        Dim folder As String = Server.MapPath("~/" + ImageNews + lblNewsID.Text)
        If Not Directory.Exists(folder) Then
            Directory.CreateDirectory(folder)
        End If

        Dim CoverImageFileName, AttachFileName As String
        Dim UlFileName As String = ""
        CoverImageFileName = ""
        AttachFileName = ""

        If FileUploadImage.HasFile Then
            UlFileName = FileUploadImage.FileName
            CoverImageFileName = Path.GetFileName(UlFileName)
            FileUploadImage.SaveAs(Server.MapPath("~/" + ImageCoverNews + UlFileName))
        Else
            CoverImageFileName = Path.GetFileName(imgCover.ImageUrl)
        End If

        If FileUploadFile.HasFile Then
            UlFileName = FileUploadFile.FileName
            AttachFileName = Path.GetFileName(UlFileName)
            FileUploadFile.SaveAs(Server.MapPath("~/" + ImageNews + lblNewsID.Text + "/" + UlFileName))
        Else
            AttachFileName = hlnkAttachs.Text
        End If


        sContent = ""
        If optType.SelectedValue = "UPL" Then
            folder = Server.MapPath("~/" + ImageNews + lblNewsID.Text)
            If Not Directory.Exists(folder) Then
                Directory.CreateDirectory(folder)
            End If
            sFile = ""
            If FileUpload.HasFile Then
                sFile = Path.GetFileName(FileUpload.PostedFile.FileName)
            End If
            txtDetail.Html = ""
        ElseIf optType.SelectedValue = "URL" Then
            sFile = ""
            txtDetail.Html = ""
        Else
            sContent = txtDetail.Html
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

        ctlN.News_Save(StrNull2Zero(lblNewsID.Text), ddlCategory.SelectedValue, optType.SelectedValue, txtHead.Text, sContent, CoverImageFileName, AttachFileName, sFile, txtURL.Text, ConvertBoolean2YN(chkIsMember.Checked), ConvertBoolean2StatusFlag(chkStatus.Checked), siteF)

        If FileUploadFile.HasFile Then
            ctlN.News_UpdateFileAttachName(StrNull2Zero(lblNewsID.Text), UlFileName)
        End If

        If optType.SelectedValue = "UPL" Then
            If FileUpload.HasFiles Then
                UploadFile(FileUpload)
            End If
        End If

        'EditNews(lblNewsID.Text)

        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalSuccess(this,'Success','บันทึกข้อมูลเรียบร้อย');", True)

    End Sub
    Sub UploadFile(ByVal Fileupload As Object)
        'Dim FileFullName As String = Fileupload.PostedFile.FileName

        Dim filesPath As String() = System.IO.Directory.GetFiles(Server.MapPath("~/" + ImageNews + lblNewsID.Text))
        For Each filePath As String In filesPath
            Dim fName As String = Path.GetFileName(filePath).ToLower()
            If fName.StartsWith("news_" + lblNewsID.Text + "_") Then
                File.Delete(filePath)
            End If
        Next

        Dim fileExtname As String = Path.GetExtension(Fileupload.FileName).ToLower()
        Dim FileName As String = "news_" + lblNewsID.Text + "_" + ConvertDate2DBString(Now.Date) + ConvertTimeToString(Now()) + fileExtname

        If FileName <> "" Then
            Fileupload.SaveAs(Server.MapPath("~/" + ImageNews + lblNewsID.Text + "/" + FileName))
            ctlN.News_UpdateFileName(StrNull2Zero(lblNewsID.Text), FileName)
        End If
    End Sub

    Protected Sub optType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles optType.SelectedIndexChanged
        ShowNewsType()
    End Sub

    Protected Sub cmdDelFile_Click(sender As Object, e As EventArgs) Handles cmdDelFile.Click
        ctlN.News_UpdateFileAttachName(StrNull2Zero(lblNewsID.Text), "")

        If chkFileExist(Server.MapPath("/" + ImageNews + lblNewsID.Text + "/" + hlnkAttachs.Text)) Then
            File.Delete(Server.MapPath("/" + ImageNews + lblNewsID.Text + "/" + hlnkAttachs.Text))
        End If

        hlnkAttachs.Text = ""
        cmdDelFile.Visible = False
    End Sub
End Class