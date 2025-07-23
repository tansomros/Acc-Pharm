
Public Class ReportAction
    Inherits System.Web.UI.Page

    Dim ctlM As New MasterController
    Dim dt As New DataTable
    Dim acc As New UserController


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
          If IsNothing(Request.Cookies("iLaw")) Then
            Response.Redirect("Default.aspx")
        End If
        If Not IsPostBack Then
            LoadCompany()
            LoadTask()

            txtStartDate.Text = Today.Date.ToString("dd/MM/yyyy")
            txtEndDate.Text = Today.Date.ToString("dd/MM/yyyy")
        End If

    End Sub

    Private Sub LoadCompany()
        Dim ctlC As New CompanyController

        If Request.Cookies("iLaw")("ROLE_SPA") = True Or Request.Cookies("iLaw")("ROLE_ADM") = True Then
            dt = ctlC.Company_GetActive()
        Else
            dt = ctlC.Company_GetByUID(Request.Cookies("iLaw")("LoginCompanyUID"))
        End If

        With ddlCompany
            .DataSource = dt
            .DataTextField = "CompanyName"
            .DataValueField = "UID"
            .DataBind()
            .SelectedIndex = 0
        End With

    End Sub

    Private Sub LoadTask()
        Dim ctlT As New LawController
        ddlTask.DataSource = ctlT.Task_GetByCompany(ddlCompany.SelectedValue)
        ddlTask.DataTextField = "TaskName"
        ddlTask.DataValueField = "UID"
        ddlTask.DataBind()
    End Sub


    Protected Sub cmdPrint_Click(sender As Object, e As EventArgs) Handles cmdPrint.Click

        If txtStartDate.Text = "" Or txtEndDate.Text = "" Then
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModals(this,'ผลการตรวจสอบ','กรุณาระบุช่วงวันที่ก่อน');", True)
            Exit Sub
        End If

        Dim Bdate, Edate, Cond As String
        'Bdate = Right(txtStartDate.Text, 4) + Mid(txtStartDate.Text, 4, 2) + Left(txtStartDate.Text, 2)
        'Edate = Right(txtEndDate.Text, 4) + Mid(txtEndDate.Text, 4, 2) + Left(txtEndDate.Text, 2)

        Bdate = Right(txtStartDate.Text, 4) + Mid(txtStartDate.Text, 4, 2) + ConvertYearEN(CInt(Left(txtStartDate.Text, 2)))
        Edate = Right(txtEndDate.Text, 4) + Mid(txtEndDate.Text, 4, 2) + ConvertYearEN(CInt(Left(txtEndDate.Text, 2)))


        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "Report", "window.open('Report/ReportViewer?R=acttask&COM=" & ddlCompany.SelectedValue & "&TASK=" & ddlTask.SelectedValue & "&BDT=" & Bdate & "&EDT=" & Edate & "&RPTTYPE=" & IIf(chkExcel.Checked = True, "EXCEL", "PDF") & "','_blank');", True)

    End Sub

End Class

