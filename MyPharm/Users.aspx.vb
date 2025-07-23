Imports BigLion
Public Class Users
    Inherits System.Web.UI.Page

    Dim dt As New DataTable
    Dim objUser As New UserController
    Public dtUser As New DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsNothing(Request.Cookies("CPA")) Then
            Response.Redirect("Default.aspx")
        End If
        'If Session("userid") Is Nothing Then
        '    Response.Redirect("Default.aspx")
        'End If

        If Not IsPostBack Then
            'grdData.PageIndex = 0
            BindUserGroup()
            LoadUserAccountToGrid()
        End If
    End Sub

    Private Sub BindUserGroup()
        With ddlGroupFind
            .Items.Clear()
            .Items.Add("All")
            .Items(0).Value = "0"
            .Items.Add("ร้านขายยา")
            .Items(1).Value = "1"
            .Items.Add("ผู้ตรวจประเมิน")
            .Items(2).Value = "2"
            .Items.Add("Admin")
            .Items(3).Value = "3"
            If Request.Cookies("ROLE_ID").Value = 9 Then
                .Items.Add("Super Admin")
                .Items(4).Value = "9"
            End If
        End With
    End Sub

    Private Sub LoadUserAccountToGrid()
        dtUser = objUser.User_GetBySearch(ddlGroupFind.SelectedValue, txtSearch.Text, Request.Cookies("UserID").Value)
        'If dtUser.Rows.Count > 0 Then
        '    With grdData
        '        .Visible = True
        '        .DataSource = dtUser
        '        .DataBind()
        '    End With
        'Else
        '    grdData.DataSource = Nothing
        '    grdData.Visible = False
        'End If
    End Sub

    'Private Sub grdData_PageIndexChanging(sender As Object, e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdData.PageIndexChanging
    '    grdData.PageIndex = e.NewPageIndex
    '    LoadUserAccountToGrid()
    'End Sub
    'Private Sub grdData_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdData.RowCommand

    '    If TypeOf e.CommandSource Is WebControls.ImageButton Then
    '        Dim ButtonPressed As WebControls.ImageButton = e.CommandSource
    '        Select Case ButtonPressed.ID
    '            Case "imgEdit"
    '                Response.Redirect("UserModify?m=u&s=u&uid=" & e.CommandArgument())
    '            Case "imgDel"
    '                If objUser.User_Delete(e.CommandArgument) Then

    '                    objUser.User_GenLogfile(Request.Cookies("UserID").value, "DEL", "User", "ลบ user :" & e.CommandArgument, "")

    '                    ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalSuccess(this,'ผลการทำงาน','ลบข้อมูลเรียบร้อย');", True)

    '                    'DisplayMessage(Me, "ลบข้อมูลเรียบร้อย")
    '                Else
    '                    ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','ไม่สามารถลบข้อมูลได้ กรุณาตรวจสอบและลองใหม่อีกครั้ง');", True)

    '                    'DisplayMessage(Me, "ไม่สามารถลบข้อมูลได้ กรุณาตรวจสอบและลองใหม่อีกครั้ง")
    '                End If

    '                LoadUserAccountToGrid()

    '        End Select

    '    End If

    'End Sub
    'Private Sub grdData_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdData.RowDataBound
    '    If e.Row.RowType = ListItemType.AlternatingItem Or e.Row.RowType = ListItemType.Item Then

    '        'e.Row.Cells(0).Text = e.Row.RowIndex + 1
    '        Dim scriptString As String = "javascript:return confirm(""ต้องการลบ ข้อมูลนี้ ?"");"
    '        Dim imgD As Image = e.Row.Cells(1).FindControl("imgDel")
    '        imgD.Attributes.Add("onClick", scriptString)

    '    End If
    '    'If e.Row.RowType = DataControlRowType.DataRow Then
    '    '    e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#d9edf7';")
    '    '    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;")

    '    'End If

    'End Sub

    Protected Sub cmdFind_Click(sender As Object, e As EventArgs) Handles cmdFind.Click
        'grdData.PageIndex = 0
        LoadUserAccountToGrid()
    End Sub

    Protected Sub ddlGroupFind_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlGroupFind.SelectedIndexChanged
        'grdData.PageIndex = 0
        LoadUserAccountToGrid()
    End Sub

End Class

