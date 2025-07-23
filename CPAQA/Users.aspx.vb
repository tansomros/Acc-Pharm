Imports BigLion
Public Class Users
    Inherits System.Web.UI.Page

    Dim dt As New DataTable
    Dim objUser As New UserController
    Public dtUser As New DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
          If IsNothing(Request.Cookies("CPAQA")) Then
            Response.Redirect("Default.aspx")
        End If

        If Not IsPostBack Then
            'grdData.PageIndex = 0
            BindUserGroup()
            ddlGroupFind.SelectedValue = "2"
            LoadUserAccountToGrid()
            If Request.Cookies("ROLE_ID").Value = 9 Then
                cmdExport.Visible = True
            Else
                cmdExport.Visible = False
            End If
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
                .Items.Add("ผู้ประเมิน GPP")
                .Items(4).Value = "4"
                .Items.Add("Admin สสจ.")
                .Items(5).Value = "5"
                .Items.Add("FDA Admin (อย.)")
                .Items(6).Value = "7"
                .Items.Add("Super Admin")
                .Items(7).Value = "9"
            End If
        End With
    End Sub

    Private Sub LoadUserAccountToGrid()
        dtUser = objUser.User_GetBySearch(ddlGroupFind.SelectedValue, txtSearch.Text, Request.Cookies("userid").Value)
    End Sub

    Protected Sub cmdFind_Click(sender As Object, e As EventArgs) Handles cmdFind.Click
        LoadUserAccountToGrid()
    End Sub

    Protected Sub ddlGroupFind_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlGroupFind.SelectedIndexChanged
        LoadUserAccountToGrid()
    End Sub

    Private Sub cmdExport_Click(sender As Object, e As EventArgs) Handles cmdExport.Click
        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "Report", "window.open('Reports/rptUser.aspx?grp=" & ddlGroupFind.SelectedValue & "&key=" & txtSearch.Text & "','_blank');", True)
    End Sub
End Class

