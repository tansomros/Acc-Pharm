Imports BigLion
Public Class DownloadList
    Inherits System.Web.UI.Page
    Dim ctlD As New DownloadController
    Dim dt As New DataTable
    Dim acc As New UserController
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If IsNothing(Request.Cookies("UserLogin").Value) Then
        '    Response.Redirect("Login.aspx")
        'End If

        If Not IsPostBack Then
            grdData.PageIndex = 0
            LoadData()
            If Request.Cookies("ROLE_ID").Value = 1 Then
                cmdAdd.Visible = False
                'grdData.Columns(2).Visible = False
                grdData.Columns(3).Visible = False
                grdData.Columns(4).Visible = False
                grdData.Columns(5).Visible = False
                grdData.Columns(6).Visible = False
            End If
        End If
    End Sub

    Private Sub LoadData()
        dt = ctlD.Download_GetSearch("1", txtSearch.Text)
        If dt.Rows.Count > 0 Then
            grdData.DataSource = dt
            grdData.DataBind()
        End If

    End Sub



    Private Sub grdData_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grdData.RowCommand
        If TypeOf e.CommandSource Is WebControls.ImageButton Then
            Dim ButtonPressed As WebControls.ImageButton = e.CommandSource
            Select Case ButtonPressed.ID
                Case "imgEdit"
                    Response.Redirect("DownloadAdd.aspx?id=" & e.CommandArgument())
                Case "imgDel"
                    ctlD.Download_Delete(e.CommandArgument())
                    grdData.PageIndex = 0
                    LoadData()
            End Select


        End If
    End Sub

    Private Sub grdData_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles grdData.RowDataBound
        If e.Row.RowType = ListItemType.AlternatingItem Or e.Row.RowType = ListItemType.Item Then

            Dim scriptString As String = "javascript:return confirm(""ต้องการลบ ข้อมูลนี้ ?"");"
            Dim imgD As Image = e.Row.Cells(6).FindControl("imgDel")
            imgD.Attributes.Add("onClick", scriptString)

            'e.Row.Cells(0).Text = e.Row.RowIndex + 1

            'Select Case e.Row.Cells(4).Text
            '    Case "1"
            '        e.Row.Cells(4).Text = " <span class='label label-warning'>รอดำเนินการ</span>"
            '    Case "2"
            '        e.Row.Cells(4).Text = " <span class='label label-info'>กำลังดำเนินการ</span>"
            '    Case "3"
            '        e.Row.Cells(4).Text = " <span class='label label-danger'>ข้อมูลไม่เพียงพอ</span>"
            '    Case "4"
            '        e.Row.Cells(4).Text = " <span class='label label-success'>ดำเนินการเรียบร้อย</span>"
            'End Select


        End If

        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#e0f3ff';")
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;")

        End If
    End Sub

    Protected Sub cmdSearch_Click(sender As Object, e As EventArgs) Handles cmdSearch.Click
        grdData.PageIndex = 0
        LoadData()
    End Sub

    Protected Sub cmdAdd_Click(sender As Object, e As EventArgs) Handles cmdAdd.Click
        Response.Redirect("DownloadAdd.aspx")
    End Sub

    Protected Sub grdData_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grdData.PageIndexChanging
        grdData.PageIndex = e.NewPageIndex
        LoadData()
    End Sub
End Class