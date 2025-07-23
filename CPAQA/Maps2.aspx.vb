Imports BigLion
Public Class Maps2
    Inherits System.Web.UI.Page
    Public dtPv As New DataTable
    Public dtMap As New DataTable
    Dim ctlM As New MasterController
    Dim ctlL As New LocationController
    Dim dt As New DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If IsNothing(Request.Cookies("CPAQA")) Then
        '    Response.Redirect("Default.aspx")
        'End If
        If Not IsPostBack Then
            LoadProvinceToDDL()
            LoadMap()
        End If
    End Sub
    Private Sub LoadProvinceToDDL()
        dt = ctlM.Province_GetForReport()
        If dt.Rows.Count > 0 Then
            With ddlProvince
                .Enabled = True
                .DataSource = dt
                .DataTextField = "ProvinceName"
                .DataValueField = "ProvinceID"
                .DataBind()
            End With
        End If
        dt = Nothing
    End Sub
    Private Sub LoadMap()
        If ddlProvince.SelectedValue = "0" Then
            dtMap = ctlL.Location_GetMapsAll()
            dtPv = ctlM.Province_GetByID("10")
        Else
            dtMap = ctlL.Location_GetMapsByProvince(ddlProvince.SelectedValue)
            dtPv = ctlM.Province_GetByID(ddlProvince.SelectedValue)
        End If
    End Sub

    Private Sub cmdView_Click(sender As Object, e As EventArgs) Handles cmdView.Click
        LoadMap()
        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "location.reload();window.stop();", True)
    End Sub

    Private Sub ddlProvince_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlProvince.SelectedIndexChanged
        LoadMap()
    End Sub
End Class