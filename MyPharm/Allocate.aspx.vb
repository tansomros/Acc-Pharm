
Public Class Allocate
    Inherits System.Web.UI.Page
    Dim dt As New DataTable
    Dim ctlL As New LocationController
    Dim ctlU As New UserController

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsNothing(Request.Cookies("UserID").Value) Then
            Response.Redirect("Default.aspx")
        End If
        If Not IsPostBack Then
            lblNotic.Visible = False
            LoadUserToDDL()
            LoadLocationAllocateToGrid()
            LoadLocationNoAllocateToGrid()
        End If

        lnkSubmitDel.Attributes.Add("onClick", "javascript:return confirm(""ต้องการลบทุกรายการใช่หรือไม่?"");")
    End Sub
    Private Sub LoadLocationNoAllocateToGrid()
        If StrNull2Zero(ddlUser.SelectedValue) <> 0 Then
            If txtSearchLocation.Text <> "" Then
                dt = ctlL.Location_GetNoAllocateSearch(StrNull2Zero(ddlUser.SelectedValue), txtSearchLocation.Text)
            Else
                dt = ctlL.Location_GetNoAllocate(StrNull2Zero(ddlUser.SelectedValue))
            End If
            If dt.Rows.Count > 0 Then
                With grdData
                    .Visible = True
                    .DataSource = dt
                    .DataBind()
                End With
                lblNotic.Visible = False
                cmdSave.Enabled = True
                cmdClear.Enabled = True
            Else
                grdData.Visible = False
                lblNotic.Text = "ไม่พบร้านยาที่ท่านค้นหา"
                lblNotic.Visible = True
                cmdSave.Enabled = False
                cmdClear.Enabled = False
            End If
        Else
            grdData.Visible = False
        End If
    End Sub
    Private Sub LoadUserToDDL()
        dt = ctlU.Supervisor_Get()
        If dt.Rows.Count > 0 Then
            With ddlUser
                .DataSource = dt
                .DataTextField = "DisplayName"
                .DataValueField = "UserID"
                .DataBind()
            End With
        End If
    End Sub
    Private Sub LoadLocationAllocateToGrid()
        If StrNull2Zero(ddlUser.SelectedValue) <> 0 Then
            If txtSearchAllocate.Text <> "" Then
                dt = ctlL.LocationAllocate_GetByUserSearch(StrNull2Zero(ddlUser.SelectedValue), txtSearchAllocate.Text)
            Else
                dt = ctlL.LocationAllocate_GetByUser(StrNull2Zero(ddlUser.SelectedValue))
            End If

            If dt.Rows.Count > 0 Then
                lblCount.Text = dt.Rows.Count
                lblNo.Visible = False
                With grdLocation
                    .Visible = True
                    .DataSource = dt
                    .DataBind()
                End With
            Else
                lblCount.Text = 0
                lblNo.Visible = True
                grdLocation.Visible = False
            End If
        Else
            lblCount.Text = 0
            lblNo.Visible = True
            grdLocation.Visible = False
        End If
    End Sub

    Private Sub grdData_PageIndexChanging(sender As Object, e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdData.PageIndexChanging
        grdData.PageIndex = e.NewPageIndex
        LoadLocationNoAllocateToGrid()
    End Sub
    Private Sub grdData_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdData.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#ffdfef';")
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;")
        End If
    End Sub
    Private Sub AddLocationToUser()
        Dim item As Integer
        For i = 0 To grdData.Rows.Count - 1
            With grdData
                Dim chkS As CheckBox = .Rows(i).Cells(0).FindControl("chkSelect")
                If chkS.Checked Then
                    item = ctlL.LocationAllocate_Add(ddlUser.SelectedValue, .Rows(i).Cells(1).Text, Request.Cookies("UserID").Value)

                    ctlU.User_GenLogfile(Request.Cookies("UserID").Value, ACTTYPE_ADD, "LocationAllocate", "เพิ่ม ร้านยาให้ผู้ตรวจประเมิน:UserID=" & ddlUser.SelectedValue & ">>LID=" & .Rows(i).Cells(1).Text, "")
                End If
            End With
        Next
        LoadLocationAllocateToGrid()
        LoadLocationNoAllocateToGrid()
        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalSuccess(this,'Success','บันทึกข้อมูลเรียบร้อย');", True)
    End Sub

    Private Sub grdLocation_PageIndexChanging(sender As Object, e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdLocation.PageIndexChanging
        grdLocation.PageIndex = e.NewPageIndex
        LoadLocationAllocateToGrid()
    End Sub

    Private Sub grdLocation_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdLocation.RowCommand
        If TypeOf e.CommandSource Is WebControls.ImageButton Then
            Dim ButtonPressed As WebControls.ImageButton = e.CommandSource
            Select Case ButtonPressed.ID
                Case "imgDel"
                    If ctlL.LocationAllocate_Delete(e.CommandArgument) Then
                        ctlU.User_GenLogfile(Request.Cookies("UserID").Value, ACTTYPE_DEL, "LocationAllocate_DeleteByUID", "ลบ ร้านยาที่จัดสรรให้ผู้ตรวจประเมิน:" & ddlUser.SelectedValue & ">>" & e.CommandArgument, "")

                        'ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','ลบข้อมูลเรียบร้อย');", True)
                        LoadLocationAllocateToGrid()
                        LoadLocationNoAllocateToGrid()
                    Else
                        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','ไม่สามารถลบข้อมูลได้ กรุณาตรวจสอบและลองใหม่อีกครั้ง');", True)
                    End If


            End Select


        End If
    End Sub

    Private Sub grdLocation_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdLocation.RowDataBound
        If e.Row.RowType = ListItemType.AlternatingItem Or e.Row.RowType = ListItemType.Item Then

            Dim scriptString As String = "javascript:return confirm(""ต้องการลบ ข้อมูลนี้ ?"");"
            Dim imgD As Image = e.Row.Cells(3).FindControl("imgDel")
            imgD.Attributes.Add("onClick", scriptString)

        End If

        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#ffdfef';")
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;")

        End If

    End Sub

    Protected Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        'If StrNull2Zero(ddlDegree.SelectedValue) = 0 Then
        '    ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','กรุณาเลือกลำดับที่ก่อน');", True)
        '    Exit Sub
        'End If

        AddLocationToUser()
    End Sub

    Protected Sub cmdClear_Click(sender As Object, e As EventArgs) Handles cmdClear.Click
        For i = 0 To grdData.Rows.Count - 1
            With grdData
                Dim chkS As CheckBox = .Rows(i).Cells(0).FindControl("chkSelect")
                chkS.Checked = False
            End With
        Next
    End Sub


    Protected Sub ddlUser_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlUser.SelectedIndexChanged
        grdLocation.PageIndex = 0
        grdData.PageIndex = 0
        LoadLocationAllocateToGrid()
        LoadLocationNoAllocateToGrid()
    End Sub

    Protected Sub cmdFindAlocate_Click(sender As Object, e As EventArgs) Handles cmdFindAlocate.Click
        grdLocation.PageIndex = 0
        LoadLocationAllocateToGrid()
    End Sub

    Protected Sub cmdFindLocation_Click(sender As Object, e As EventArgs) Handles cmdFindLocation.Click
        grdData.PageIndex = 0
        LoadLocationNoAllocateToGrid()
    End Sub

    Protected Sub lnkSubmitDel_Click(sender As Object, e As EventArgs) Handles lnkSubmitDel.Click

        ctlL.LocationAllocate_DeleteAll(ddlUser.SelectedValue)

        grdLocation.PageIndex = 0
        grdData.PageIndex = 0
        LoadLocationAllocateToGrid()
        LoadLocationNoAllocateToGrid()
        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalSuccess(this,'Success','ลบข้อมูลเรียบร้อย');", True)

    End Sub

    Protected Sub lnkSubmitAdd_Click(sender As Object, e As EventArgs) Handles lnkSubmitAdd.Click
        Dim ctlCs As New UserController
        dt = ctlL.Location_GetNoAllocate(ddlUser.SelectedValue)
        If dt.Rows.Count > 0 Then
            For i = 0 To dt.Rows.Count - 1
                ctlL.LocationAllocate_Add(StrNull2Zero(ddlUser.SelectedValue), dt.Rows(i)("LocationUID"), Request.Cookies("UserID").Value)
            Next
        End If

        ctlU.User_GenLogfile(Request.Cookies("UserID").Value, ACTTYPE_ADD, "LocationAllocate", "เพิ่ม ร้านยาให้ผู้ตรวจประเมิน แบบทั้งหมด:UserID=" & ddlUser.SelectedItem.Text, "")

        grdLocation.PageIndex = 0
        grdData.PageIndex = 0
        LoadLocationAllocateToGrid()
        LoadLocationNoAllocateToGrid()
        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalSuccess(this,'Success','บันทึกข้อมูลเรียบร้อย');", True)
    End Sub


End Class

