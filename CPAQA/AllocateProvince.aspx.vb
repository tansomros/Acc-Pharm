
Imports BigLion

Public Class AllocateProvince
    Inherits System.Web.UI.Page
    Dim dt As New DataTable
    Dim ctlU As New UserController
    Dim ctlM As New MasterController

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsNothing(Request.Cookies("UserID").Value) Then
            Response.Redirect("Default.aspx")
        End If
        If Not IsPostBack Then
            lblNotic.Visible = False
            If Convert.ToInt32(Request.Cookies("ROLE_ID").Value) < 9 Then
                Dim dtP As New DataTable
                Dim ctlU As New UserController
                dtP = ctlU.User_GetPPH(Request.Cookies("UserID").Value)
            End If
            LoadSupervisorToDDL()
            LoadProvinceAllocateToGrid()
            LoadProvinceNoAllocateToGrid()
        End If

        lnkSubmitDel.Attributes.Add("onClick", "javascript:return confirm(""ต้องการลบทุกรายการใช่หรือไม่?"");")
    End Sub
    Private Sub LoadProvinceNoAllocateToGrid()
        If StrNull2Zero(ddlUser.SelectedValue) <> 0 Then
            If txtSearchProvince.Text <> "" Then
                dt = ctlU.Province_GetNoAllocateSearch(StrNull2Zero(ddlUser.SelectedValue), optCond.SelectedValue, txtSearchProvince.Text)
            Else
                dt = ctlU.Province_GetNoAllocate(StrNull2Zero(ddlUser.SelectedValue), optCond.SelectedValue)
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
                lblNotic.Text = "ไม่พบจังหวัดที่ท่านค้นหา"
                lblNotic.Visible = True
                cmdSave.Enabled = False
                cmdClear.Enabled = False
            End If
        Else
            grdData.Visible = False
        End If
    End Sub
    Private Sub LoadSupervisorToDDL()
        dt = ctlU.User_Get4AllocateProvince()
        'If dt.Rows.Count > 0 Then
        With ddlUser
            .DataSource = dt
            .DataTextField = "DisplayName"
            .DataValueField = "UserID"
            .DataBind()
        End With
        'End If
    End Sub
    Private Sub LoadProvinceAllocateToGrid()
        If StrNull2Zero(ddlUser.SelectedValue) <> 0 Then
            If txtSearchAllocate.Text <> "" Then
                dt = ctlU.ProvinceAllocate_GetByUserSearch(StrNull2Zero(ddlUser.SelectedValue), txtSearchAllocate.Text)
            Else
                dt = ctlU.ProvinceAllocate_GetByUser(StrNull2Zero(ddlUser.SelectedValue))
            End If

            If dt.Rows.Count > 0 Then
                lblCount.Text = dt.Rows.Count
                lblNo.Visible = False
                With grdProvince
                    .Visible = True
                    .DataSource = dt
                    .DataBind()
                End With
            Else
                lblCount.Text = 0
                lblNo.Visible = True
                grdProvince.Visible = False
            End If
        Else
            lblCount.Text = 0
            lblNo.Visible = True
            grdProvince.Visible = False
        End If
    End Sub

    Private Sub grdData_PageIndexChanging(sender As Object, e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdData.PageIndexChanging
        grdData.PageIndex = e.NewPageIndex
        LoadProvinceNoAllocateToGrid()
    End Sub
    Private Sub grdData_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdData.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#ffdfef';")
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;")
        End If
    End Sub
    Private Sub AddProvinceToUser()
        Dim item As Integer
        For i = 0 To grdData.Rows.Count - 1
            With grdData
                Dim chkS As CheckBox = .Rows(i).Cells(0).FindControl("chkSelect")
                If chkS.Checked Then
                    item = ctlU.ProvinceAllocate_Add(ddlUser.SelectedValue, .Rows(i).Cells(1).Text, Request.Cookies("UserID").Value)

                    ctlU.User_GenLogfile(Request.Cookies("UserID").Value, ACTTYPE_ADD, "ProvinceAllocate", "เพิ่ม จังหวัดให้ผู้ตรวจประเมิน:UserID=" & ddlUser.SelectedValue & ">>LID=" & .Rows(i).Cells(1).Text, "", Environment.MachineName, GetIPAddress())
                End If
            End With
        Next
        LoadProvinceAllocateToGrid()
        LoadProvinceNoAllocateToGrid()
        'ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalSuccess(this,'Success','บันทึกข้อมูลเรียบร้อย');", True)
    End Sub

    Private Sub grdProvince_PageIndexChanging(sender As Object, e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdProvince.PageIndexChanging
        grdProvince.PageIndex = e.NewPageIndex
        LoadProvinceAllocateToGrid()
    End Sub

    Private Sub grdProvince_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdProvince.RowCommand
        If TypeOf e.CommandSource Is WebControls.ImageButton Then
            Dim ButtonPressed As WebControls.ImageButton = e.CommandSource
            Select Case ButtonPressed.ID
                Case "imgDel"
                    If ctlU.ProvinceAllocate_Delete(e.CommandArgument) Then
                        ctlU.User_GenLogfile(Request.Cookies("UserID").Value, ACTTYPE_DEL, "ProvinceAllocate_DeleteByUID", "ลบ จังหวัดที่จัดสรรให้ผู้ตรวจประเมิน:" & ddlUser.SelectedValue & ">>" & e.CommandArgument, "", Environment.MachineName, GetIPAddress())

                        'ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','ลบข้อมูลเรียบร้อย');", True)
                        LoadProvinceAllocateToGrid()
                        LoadProvinceNoAllocateToGrid()
                    Else
                        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','ไม่สามารถลบข้อมูลได้ กรุณาตรวจสอบและลองใหม่อีกครั้ง');", True)
                    End If


            End Select


        End If
    End Sub

    Private Sub grdProvince_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdProvince.RowDataBound
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

        AddProvinceToUser()
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
        grdProvince.PageIndex = 0
        grdData.PageIndex = 0
        LoadProvinceAllocateToGrid()
        LoadProvinceNoAllocateToGrid()
    End Sub

    Protected Sub cmdFindAlocate_Click(sender As Object, e As EventArgs) Handles cmdFindAlocate.Click
        grdProvince.PageIndex = 0
        LoadProvinceAllocateToGrid()
    End Sub

    Protected Sub cmdFindProvince_Click(sender As Object, e As EventArgs) Handles cmdFindProvince.Click
        grdData.PageIndex = 0
        LoadProvinceNoAllocateToGrid()
    End Sub

    Protected Sub lnkSubmitDel_Click(sender As Object, e As EventArgs) Handles lnkSubmitDel.Click

        ctlU.ProvinceAllocate_DeleteAll(ddlUser.SelectedValue)

        grdProvince.PageIndex = 0
        grdData.PageIndex = 0
        LoadProvinceAllocateToGrid()
        LoadProvinceNoAllocateToGrid()
        'ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalSuccess(this,'Success','ลบข้อมูลเรียบร้อย');", True)

    End Sub

    Protected Sub lnkSubmitAdd_Click(sender As Object, e As EventArgs) Handles lnkSubmitAdd.Click
        Dim ctlCs As New UserController
        dt = ctlU.Province_GetNoAllocate(ddlUser.SelectedValue, optCond.SelectedValue)
        If dt.Rows.Count > 0 Then
            For i = 0 To dt.Rows.Count - 1
                ctlU.ProvinceAllocate_Add(StrNull2Zero(ddlUser.SelectedValue), dt.Rows(i)("ProvinceUID"), Request.Cookies("UserID").Value)
            Next
        End If

        ctlU.User_GenLogfile(Request.Cookies("UserID").Value, ACTTYPE_ADD, "ProvinceAllocate", "เพิ่ม จังหวัดให้ผู้ตรวจประเมิน แบบทั้งหมด:UserID=" & ddlUser.SelectedItem.Text, "", Environment.MachineName, GetIPAddress())

        grdProvince.PageIndex = 0
        grdData.PageIndex = 0
        LoadProvinceAllocateToGrid()
        LoadProvinceNoAllocateToGrid()
        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalSuccess(this,'Success','บันทึกข้อมูลเรียบร้อย');", True)
    End Sub
End Class

