Imports System.IO
Imports Newtonsoft.Json
Imports BigLion
Public Class Site
    Inherits System.Web.UI.MasterPage
    Dim dt As New DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If IsNothing(Request.Cookies("CPAQA")) Then
            Response.Redirect("Default.aspx")
        End If

        If Not IsPostBack Then
            LoadUserDetail()
            LoadUserRole()
        End If
        LoadCalendarData()
    End Sub

    Private Sub LoadUserDetail()
        Dim ctlU As New UserController
        dt = ctlU.User_GetByUserID(Request.Cookies("userid").Value)
        If dt.Rows.Count > 0 Then
            lblUserName1.Text = String.Concat(dt.Rows(0)("DisplayName"))
            lblUsername2.Text = String.Concat(dt.Rows(0)("DisplayName"))


            'lblUserDesc.Text = Request.Cookies("PeriodName")
            'lblPeriod.Text = Request.Cookies("PeriodName")
            'lblUserDept.Text = String.Concat(dt.Rows(0)("DepartmentName"))
            If dt.Rows(0)("RoleID") = 1 Then
                lblProfileDesc.Text = ""
                lblLocationName.Text = String.Concat(dt.Rows(0)("LocationName"))
            ElseIf dt.Rows(0)("RoleID") = 4 Then
                lblProfileDesc.Text = "สภาเภสัชกรรม"
                lblLocationName.Text = "สภาเภสัชกรรม"
            Else
                lblProfileDesc.Text = "สำนักรับรองร้านยาคุณภาพ"
                lblLocationName.Text = "สำนักรับรองร้านยาคุณภาพ สภาเภสัชกรรม"
            End If

            If DBNull2Str(dt.Rows(0).Item("ImagePath")) <> "" Then
                Dim objfile As FileInfo = New FileInfo(Server.MapPath("~/" & PictureUser & "/" & dt.Rows(0).Item("ImagePath")))

                If objfile.Exists Then
                    imgUser1.ImageUrl = "~/" & PictureUser & "/" & dt.Rows(0).Item("ImagePath")
                    imgUser2.ImageUrl = "~/" & PictureUser & "/" & dt.Rows(0).Item("ImagePath")
                Else
                    imgUser1.ImageUrl = "~/" & PictureUser & "/user_blank.jpg"
                    imgUser2.ImageUrl = "~/" & PictureUser & "/user_blank.jpg"
                End If

            End If

        End If
        dt = Nothing
    End Sub


    Private Sub LoadUserRole()
        'Dim ctlU As New UserController
        'dt = ctlU.User_GetUserRole(Request.Cookies("userid").value)
        If Request.Cookies("ROLE_ID").Value > 0 Then
            lblUserRole.Text = ""
            'For i = 0 To dt.Rows.Count - 1
            Select Case Request.Cookies("ROLE_ID").Value
                Case "1"
                    lblUserRole.Text = lblUserRole.Text & "<div class='badge badge-primary'>ร้านยา/ผู้ประกอบการ</div>"
                Case "2"
                    lblUserRole.Text = lblUserRole.Text & "<div class='badge badge-info'>ผู้ตรวจประเมิน</div>"
                Case "3"
                    lblUserRole.Text = lblUserRole.Text & "<div class='badge badge-danger'>Administrator</div>"
                Case "4"
                    lblUserRole.Text = lblUserRole.Text & "<div class='badge badge-danger'>Administrator</div>"
                Case "9"
                    lblUserRole.Text = lblUserRole.Text & "<div class='badge badge-success'>Super Admin</div>"
            End Select

            'Next
        End If
        dt = Nothing
    End Sub

    Dim ctlE As New RequestController
    Dim dtCalendar As New DataTable
    Public Shared json As String
    Private Sub LoadCalendarData()
        If StrNull2Zero(Request.Cookies("ROLE_ID").Value) = 1 Then
            dtCalendar = ctlE.Event_GetByUser(StrNull2Zero(Request.Cookies("LoginLocationUID").Value))
        ElseIf StrNull2Zero(Request.Cookies("ROLE_ID").Value) = 2 Then
            dtCalendar = ctlE.Event_GetBySupervisor(StrNull2Zero(Request.Cookies("UserID").Value))
        Else
            dtCalendar = ctlE.Event_GetByAdmin(1)
        End If

        json = JsonConvert.SerializeObject(dtCalendar, Formatting.Indented)
    End Sub
End Class