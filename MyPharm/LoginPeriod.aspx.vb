
Public Class LoginPeriod
    Inherits Page
    Dim dt As New DataTable
    Dim ctlM As New MasterController
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If IsNothing(Request.Cookies("CPAQA")) Then
            Response.Redirect("Default.aspx")
        End If

        If Not IsPostBack Then
            If Request("logout") = "y" Then
                Response.Redirect("Default.asxp?logout=y")
            End If
            Dim ctlC As New CompanyController
            If ctlC.Company_GetPackage(StrNull2Zero(Request.Cookies("LoginLocationUID").value)) = 1 Then
                Dim iCPACookie2 As HttpCookie = New HttpCookie("CPAQA")
                iCPACookie2("PeriodID") = "0"
                iCPACookie2("PeriodName") = ""
                Response.Cookies.Add(iCPACookie2)
                Response.Redirect("Home1")
            Else
                LoadPeriodTime()
                ddlPeriod.Focus()
            End If
        End If
    End Sub

    Private Sub LoadPeriodTime()
        If IsNothing(Request.Cookies("CPAQA")) Then
            Exit Sub
        End If

        dt = ctlM.PeriodTime_GetActive(StrNull2Zero(Request.Cookies("LoginLocationUID").value))

        If dt.Rows.Count > 0 Then
            ddlPeriod.DataSource = dt
            ddlPeriod.DataTextField = "PeriodName"
            ddlPeriod.DataValueField = "PeriodID"
            ddlPeriod.DataBind()
        Else
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModals(this,'ผลการตรวจสอบ','หน่วยงานนี้ยังไม่มี Period Time กรุณาติดต่อ NCP admin');", True)
            Exit Sub
        End If

    End Sub

    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click

        If ddlPeriod.SelectedValue = "" Then
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModals(this,'Warning!','กรุณาเลือก Period ก่อน');", True)
            Exit Sub
        End If

        Dim iCPACookie2 As HttpCookie = New HttpCookie("CPAQA")
        iCPACookie2("PeriodID") = ddlPeriod.SelectedValue
        iCPACookie2("PeriodName") = ddlPeriod.SelectedItem.Text
        'Request.Cookies("PeriodID") = ddlPeriod.SelectedValue
        'Request.Cookies("PeriodName") = ddlPeriod.SelectedItem.Text
        Response.Cookies.Add(iCPACookie2)
        Response.Redirect("Home")
    End Sub
End Class