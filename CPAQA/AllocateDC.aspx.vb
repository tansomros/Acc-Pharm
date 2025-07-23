
Imports BigLion

Public Class AllocateDC
    Inherits System.Web.UI.Page
    Dim dt As New DataTable
    Dim ctlL As New LocationController
    Dim ctlU As New UserController
    Dim ctlM As New MasterController

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsNothing(Request.Cookies("UserID").Value) Then
            Response.Redirect("Default.aspx")
        End If
        If Not IsPostBack Then
            lblNotic.Visible = False
            LoadYearToDDL()
            ddlYear.SelectedValue = Now.Date.Year + 543

            LoadProvinceToDDL()
            If Convert.ToInt32(Request.Cookies("ROLE_ID").Value) < 9 Then
                Dim dtP As New DataTable
                Dim ctlU As New UserController
                dtP = ctlU.User_GetPPH(Request.Cookies("UserID").Value)
                If dtP.Rows.Count > 0 Then
                    ddlProvince.SelectedValue = dtP.Rows(0)("ProvinceID")
                End If
                ddlProvince.Enabled = False
            End If
            LoadLocationToDDL()
            LoadDatacollectorAllocateToGrid()
            LoadDatacollectorNoAllocateToGrid()
        End If

        lnkSubmitDel.Attributes.Add("onClick", "javascript:return confirm(""ต้องการลบทุกรายการใช่หรือไม่?"");")
    End Sub
    Private Sub LoadYearToDDL()
        dt = ctlM.GetAsmYear()
        If dt.Rows.Count > 0 Then
            With ddlYear
                .Enabled = True
                .DataSource = dt
                .DataTextField = "YearName"
                .DataValueField = "AsmYear"
                .DataBind()
                '.SelectedIndex = 0
            End With
        End If
        dt = Nothing
    End Sub
    Private Sub LoadProvinceToDDL()
        dt = ctlM.Province_Get()

        If dt.Rows.Count > 0 Then
            With ddlProvince
                .Enabled = True
                .DataSource = dt
                .DataTextField = "ProvinceName"
                .DataValueField = "ProvinceID"
                .DataBind()
                '.SelectedIndex = 0
            End With
        End If
        dt = Nothing
    End Sub
    Private Sub LoadDatacollectorNoAllocateToGrid()
        If StrNull2Zero(ddlLocation.SelectedValue) <> 0 Then
            If txtSearchLocation.Text <> "" Then
                dt = ctlU.User_GetNoAllocateSearch(ddlYear.SelectedValue, ddlProvince.SelectedValue, StrNull2Zero(ddlLocation.SelectedValue), optCond.SelectedValue, txtSearchLocation.Text)
            Else
                dt = ctlU.User_GetNoAllocate(ddlYear.SelectedValue, ddlProvince.SelectedValue, StrNull2Zero(ddlLocation.SelectedValue), optCond.SelectedValue)
            End If
            If dt.Rows.Count > 0 Then
                With grdData
                    .Visible = True
                    .DataSource = dt
                    .DataBind()
                End With
                lblNotic.Visible = False
                'cmdSave.Enabled = True
                cmdClear.Enabled = True
            Else
                grdData.Visible = False
                lblNotic.Text = "ไม่พบร้านยาที่ท่านค้นหา"
                lblNotic.Visible = True
                'cmdSave.Enabled = False
                cmdClear.Enabled = False
            End If
        Else
            grdData.Visible = False
        End If
    End Sub
    Private Sub LoadLocationToDDL()
        dt = ctlL.Location_PPH_GetByProvince(ddlProvince.SelectedValue)
        'If dt.Rows.Count > 0 Then
        With ddlLocation
            .DataSource = dt
            .DataTextField = "LocationName"
            .DataValueField = "UID"
            .DataBind()
        End With
        'End If
    End Sub
    Private Sub LoadDatacollectorAllocateToGrid()
        If StrNull2Zero(ddlLocation.SelectedValue) <> 0 Then
            If txtSearchAllocate.Text <> "" Then
                dt = ctlL.DatacollectorAllocate_GetByLocationSearch(StrNull2Zero(ddlYear.SelectedValue), StrNull2Zero(ddlLocation.SelectedValue), txtSearchAllocate.Text)
            Else
                dt = ctlL.DatacollectorAllocate_GetByLocation(StrNull2Zero(ddlYear.SelectedValue), StrNull2Zero(ddlLocation.SelectedValue))
            End If

            If dt.Rows.Count > 0 Then
                lblCount.Text = dt.Rows.Count
                lblNo.Visible = False
                With grdDC
                    .Visible = True
                    .DataSource = dt
                    .DataBind()
                End With
            Else
                lblCount.Text = 0
                lblNo.Visible = True
                grdDC.Visible = False
            End If
        Else
            lblCount.Text = 0
            lblNo.Visible = True
            grdDC.Visible = False
        End If
    End Sub

    Private Sub grdData_PageIndexChanging(sender As Object, e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdData.PageIndexChanging
        grdData.PageIndex = e.NewPageIndex
        LoadDatacollectorNoAllocateToGrid()
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
                    item = ctlL.LocationAllocate_Add(StrNull2Zero(ddlYear.SelectedValue) - 543, .DataKeys(i).Value, ddlLocation.SelectedValue, Request.Cookies("UserID").Value)

                    ctlU.User_GenLogfile(Request.Cookies("UserID").Value, ACTTYPE_ADD, "LocationAllocate", "เพิ่ม ผู้ตรวจประเมิน:UserID=" & ddlLocation.SelectedValue & ">>LID=" & .DataKeys(i).Value & ">>" & .Rows(i).Cells(1).Text, "", Environment.MachineName, GetIPAddress())
                End If
            End With
        Next
        LoadDatacollectorAllocateToGrid()
        LoadDatacollectorNoAllocateToGrid()
        'ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalSuccess(this,'Success','บันทึกข้อมูลเรียบร้อย');", True)
    End Sub

    Private Sub grdLocation_PageIndexChanging(sender As Object, e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdDC.PageIndexChanging
        grdDC.PageIndex = e.NewPageIndex
        LoadDatacollectorAllocateToGrid()
    End Sub

    Private Sub grdLocation_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdDC.RowCommand
        If TypeOf e.CommandSource Is WebControls.ImageButton Then
            Dim ButtonPressed As WebControls.ImageButton = e.CommandSource
            Select Case ButtonPressed.ID
                Case "imgDel"
                    If ctlL.LocationAllocate_Delete(e.CommandArgument) Then
                        ctlU.User_GenLogfile(Request.Cookies("UserID").Value, ACTTYPE_DEL, "LocationAllocate", "ลบ ผู้ตรวจประเมินที่จัดสรรให้ร้านยา:" & ddlLocation.SelectedValue & ">>" & e.CommandArgument, "", Environment.MachineName, GetIPAddress())

                        'ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','ลบข้อมูลเรียบร้อย');", True)
                        LoadDatacollectorAllocateToGrid()
                        LoadDatacollectorNoAllocateToGrid()
                    Else
                        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','ไม่สามารถลบข้อมูลได้ กรุณาตรวจสอบและลองใหม่อีกครั้ง');", True)
                    End If


            End Select


        End If
    End Sub

    Private Sub grdLocation_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdDC.RowDataBound
        If e.Row.RowType = ListItemType.AlternatingItem Or e.Row.RowType = ListItemType.Item Then

            Dim scriptString As String = "javascript:return confirm(""ต้องการลบ ข้อมูลนี้ ?"");"
            Dim imgD As Image = e.Row.Cells(2).FindControl("imgDel")
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


    Protected Sub ddlUser_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlLocation.SelectedIndexChanged
        grdDC.PageIndex = 0
        grdData.PageIndex = 0
        LoadDatacollectorAllocateToGrid()
        LoadDatacollectorNoAllocateToGrid()
    End Sub

    Protected Sub cmdFindAlocate_Click(sender As Object, e As EventArgs) Handles cmdFindAlocate.Click
        grdDC.PageIndex = 0
        LoadDatacollectorAllocateToGrid()
    End Sub

    Protected Sub cmdFindLocation_Click(sender As Object, e As EventArgs) Handles cmdFindLocation.Click
        grdData.PageIndex = 0
        LoadDatacollectorNoAllocateToGrid()
    End Sub

    Protected Sub lnkSubmitDel_Click(sender As Object, e As EventArgs) Handles lnkSubmitDel.Click

        ctlL.LocationAllocate_DeleteByLocation(ddlLocation.SelectedValue)

        grdDC.PageIndex = 0
        grdData.PageIndex = 0
        LoadDatacollectorAllocateToGrid()
        LoadDatacollectorNoAllocateToGrid()
        'ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalSuccess(this,'Success','ลบข้อมูลเรียบร้อย');", True)

    End Sub

    Private Sub ddlProvince_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlProvince.SelectedIndexChanged
        LoadLocationToDDL()
        grdDC.PageIndex = 0
        grdData.PageIndex = 0

        LoadDatacollectorAllocateToGrid()
        LoadDatacollectorNoAllocateToGrid()
    End Sub

    Private Sub ddlYear_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlYear.SelectedIndexChanged
        grdDC.PageIndex = 0
        grdData.PageIndex = 0

        LoadDatacollectorAllocateToGrid()
        LoadDatacollectorNoAllocateToGrid()
    End Sub
End Class

