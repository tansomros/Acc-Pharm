Imports System.Data
Imports BigLion
Public Class PharmacyGPP
    Inherits System.Web.UI.Page
    Dim ctlL As New LocationController
    Public dtGPP As New DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsNothing(Request.Cookies("CPAQA")) Then
            Response.Redirect("Default.aspx")
        End If
        If Not IsPostBack Then
            LoadLocationDetail()
            Dim ctlA As New AssessmentController
            dtGPP = ctlA.GPP_GetByLocationDC(StrNull2Zero(Request("lid")), StrNull2Zero(Request.Cookies("userid").Value))

            If Request("close") = "y" Then
                ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalSuccess(this,'Success','บันทึกปิดการประเมินเรียบร้อย');", True)
            End If
            If Request("done") = "y" Then
                ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalSuccess(this,'Success','บันทึกการประเมินเรียบร้อย');", True)
            End If
            If Request("del") = "y" Then
                ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalSuccess(this,'Success','ลบรายการเรียบร้อย');", True)
            End If
            Dim dtN As New DataTable
            dtN = ctlA.GPP_GetByYearPPH(Request("lid"))
            If dtN.Rows.Count > 0 Then
                lnkAddNew.Visible = False
            Else
                lnkAddNew.Visible = True
            End If
        End If
    End Sub
    Private Sub LoadLocationDetail()
        Dim dtResult As DataTable
        dtResult = ctlL.Location_GetByUID(Request("lid"))
        If dtResult.Rows.Count > 0 Then
            With dtResult.Rows(0)
                Try
                    lblLicenseNo.Text = String.Concat(.Item("LicenseNo1"))
                    lblLicenseNo.Text = String.Concat(.Item("LicenseNo1"))
                    lblLocationName.Text = String.Concat(.Item("LocationName"))
                    lblAddress.Text = String.Concat(.Item("LocationAddress"))
                    lblTel.Text = String.Concat(.Item("tel"))
                    lblAddress.Text = String.Concat(.Item("LocationAddress"))
                    lnkFDA.NavigateUrl = "https://pertento.fda.moph.go.th/FDA_SEARCH_DRUG/SEARCH_DRUG/pop-up_drug_location_operator.aspx?Newcode_not=" & String.Concat(.Item("NewCode"))
                    lblLicenseStatus.Text = DisplayLicenseStatus(String.Concat(.Item("LicenseStatus")))
                    lblStartDate.Text = String.Concat(.Item("LicenseStartDate"))
                    lblExpireDate.Text = String.Concat(.Item("LicenseExpireDate"))
                    lblLicensee.Text = String.Concat(.Item("Licensee"))
                Catch ex As Exception

                End Try
            End With
        End If
    End Sub

    Private Sub lnkAddNew_Click(sender As Object, e As EventArgs) Handles lnkAddNew.Click
        Response.Redirect("AsmGPP?m=g&s=new&lid=" & Request("lid"))
    End Sub
End Class