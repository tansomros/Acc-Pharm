
Imports BigLion
Public Class LocationGroup
    Inherits System.Web.UI.Page

    Dim ctlL As New LocationController
    Dim dt As New DataTable
    Dim acc As New UserController
    Public dtG As New DataTable

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsNothing(Request.Cookies("CPA")) Then
            Response.Redirect("Default.aspx")
        End If
        If Not IsPostBack Then
            ClearData()
            LoadLocationGroupToGrid()
        End If

        cmdDelete.Attributes.Add("onClick", "javascript:return confirm(""ต้องการลบรายการนี้ใช่หรือไม่?"");")
    End Sub
    Private Sub LoadLocationGroupToGrid()
        If Trim(txtSearch.Text) <> "" Then
            dt = ctlL.LocationGroup_GetBySearch(txtSearch.Text)
        Else
            dt = ctlL.LocationGroup_Get()
        End If
        With grdData
            .Visible = True
            .DataSource = dt
            .DataBind()
        End With
    End Sub

    Private Sub grdData_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdData.RowCommand
        If TypeOf e.CommandSource Is WebControls.LinkButton Then
            Dim ButtonPressed As WebControls.LinkButton = e.CommandSource
            Select Case ButtonPressed.ID
                Case "imgEdit"
                    EditData(e.CommandArgument())
                    ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalMasterData(this,'" + e.CommandArgument() + "');", True)
                Case "imgDel"
                    If ctlL.LocationGroup_Delete(e.CommandArgument) Then
                        acc.User_GenLogfile(Request.Cookies("UserID").Value, ACTTYPE_DEL, "LocationGroup", "ลบชื่อกลุ่มร้านยา :" & txtName.Text, "service", Environment.MachineName, GetIPAddress())

                        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalSuccess(this,'Success','ลบข้อมูลเรียบร้อย');", True)
                        LoadLocationGroupToGrid()
                    Else
                        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'Success','ไม่สามารถลบข้อมูลได้ กรุณาตรวจสอบและลองใหม่อีกครั้ง');", True)

                    End If
            End Select
        End If
    End Sub

    Private Sub grdData_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdData.RowDataBound
        If e.Row.RowType = ListItemType.AlternatingItem Or e.Row.RowType = ListItemType.Item Then
            Dim scriptString As String = "javascript:return confirm(""ต้องการลบรายการนี้ ?"");"
            Dim imgD As LinkButton = e.Row.Cells(5).FindControl("imgDel")
            imgD.Attributes.Add("onClick", scriptString)

        End If
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#d9edf7';")
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;")
        End If
    End Sub
    Private Sub EditData(ByVal pID As String)
        dt = ctlL.LocationGroup_GetByUID(pID)
        If dt.Rows.Count > 0 Then
            With dt.Rows(0)
                isAdd = False
                Me.txtUID.Text = String.Concat(dt.Rows(0)("UID"))
                txtCode.Text = String.Concat(dt.Rows(0)("Code"))
                txtName.Text = String.Concat(dt.Rows(0)("Name"))
                txtDescriptions.Text = String.Concat(dt.Rows(0)("Descriptions"))
                chkStatus.Checked = ConvertStatusFlag2CHK(String.Concat(dt.Rows(0)("StatusFlag")))
            End With
        End If
        dt = Nothing
    End Sub

    Private Sub ClearData()
        Me.txtUID.Text = ""
        txtUID.Text = ""
        txtCode.Text = ""
        txtName.Text = ""
        txtDescriptions.Text = "0"
        chkStatus.Checked = True

    End Sub


    Protected Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        If txtName.Text = "" Then
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','กรุณากรอกข้อมูลให้ครบถ้วน');", True)
            Exit Sub
        End If
        If StrNull2Zero(txtUID.Text) = 0 Then
            If ctlL.LocationGroup_CheckDuplicate(txtName.Text) Then
                ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','ชื่อกลุ่มร้านยานี้มีอยู่่ในระบบแล้ว');", True)
                Exit Sub
            End If
            acc.User_GenLogfile(Request.Cookies("UserID").Value, ACTTYPE_ADD, "LocationGroup", "เพิ่มชื่อกลุ่มร้านยา :" & txtName.Text, "service", Environment.MachineName, GetIPAddress())
        Else
            acc.User_GenLogfile(Request.Cookies("UserID").Value, ACTTYPE_UPD, "LocationGroup", "แก้ไขชื่อกลุ่มร้านยา :" & txtName.Text, "service", Environment.MachineName, GetIPAddress())
        End If

        ctlL.LocationGroup_Save(StrNull2Zero(txtUID.Text), txtCode.Text, txtName.Text, txtDescriptions.Text, ConvertBoolean2StatusFlag(chkStatus.Checked))

        LoadLocationGroupToGrid()
        ClearData()
        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalSuccess(this,'Success','บันทึกข้อมูลเรียบร้อย');", True)
    End Sub

    Protected Sub cmdClear_Click(sender As Object, e As EventArgs) Handles cmdClear.Click
        ClearData()
    End Sub

    Protected Sub cmdFind_Click(sender As Object, e As EventArgs) Handles cmdFind.Click
        LoadLocationGroupToGrid()
    End Sub

    'Protected Sub grdData_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grdData.PageIndexChanging
    '    grdData.PageIndex = e.NewPageIndex
    '    'LoadLocationGroupToGrid()
    'End Sub

    Protected Sub cmdNew_Click(sender As Object, e As EventArgs) Handles cmdNew.Click
        ClearData()
        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalMasterData(this,'');", True)
    End Sub

    Private Sub cmdDelete_Click(sender As Object, e As EventArgs) Handles cmdDelete.Click
        ctlL.LocationGroup_Delete(StrNull2Zero(txtUID.Text))
        LoadLocationGroupToGrid()
    End Sub
End Class

