Imports BigLion
Public Class RegisterList
    Inherits System.Web.UI.Page
    Dim ctlP As New RegisterController
    Dim dt As New DataTable

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsNothing(Request.Cookies("CPAQA")) Then
            Response.Redirect("Default.aspx")
        End If

        If Not IsPostBack Then
            grdData.PageIndex = 0
            'LoadMajor()
            If Not Request("id") = Nothing Then
                ddlPersonType.SelectedValue = Request("id")
            End If
            LoadData()
        End If
    End Sub

    ''Private Sub LoadMajor()
    ''    Dim ctlM As New MasterController
    ''    Dim dtM As New DataTable
    ''    If ddlPersonType.SelectedValue = 1 Then
    ''        dtM = ctlM.Major_Get
    ''    Else
    ''        dtM = ctlM.Department_Get
    ''    End If
    ''    ddlMajor.Items.Clear()
    ''    ddlMajor.DataSource = dtM
    ''    ddlMajor.DataValueField = "UID"
    ''    ddlMajor.DataTextField = "NameTH"
    ''    ddlMajor.DataBind()
    ''    dtM = Nothing
    ''End Sub

    Private Sub LoadData()
        dt = ctlP.Register_GetBySearch(ddlPersonType.SelectedValue, txtSearch.Text)
        grdData.DataSource = dt
        grdData.DataBind()


    End Sub

    Private Sub grdData_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grdData.RowCommand
        If TypeOf e.CommandSource Is WebControls.ImageButton Then
            Dim ButtonPressed As WebControls.ImageButton = e.CommandSource
            Select Case ButtonPressed.ID
                Case "imgStatus"
                    ctlP.Register_UpdateActiveStatus(e.CommandArgument())
                    LoadData()
                Case "imgEdit"
                    Response.Redirect("RegisterModify.aspx?pid=" & e.CommandArgument())
                Case "imgDel"
                    ctlP.Register_Delete(e.CommandArgument())
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


        End If

        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#c1ffc2';")
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;")

        End If
    End Sub

    Protected Sub cmdSearch_Click(sender As Object, e As EventArgs) Handles cmdSearch.Click
        grdData.PageIndex = 0
        LoadData()
    End Sub


    Protected Sub ddlPersonType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlPersonType.SelectedIndexChanged
        grdData.PageIndex = 0
        LoadData()
    End Sub

    Protected Sub grdData_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grdData.PageIndexChanging
        grdData.PageIndex = e.NewPageIndex
        LoadData()
    End Sub

End Class