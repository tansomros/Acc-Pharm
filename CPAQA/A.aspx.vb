Imports BigLion
Imports Newtonsoft.Json

Public Class A
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Private Sub cmdApprove_Click(sender As Object, e As EventArgs) Handles cmdApprove.Click

        Dim ctlFDA As New FDAServiceController
        Dim NewCode As String
        Dim ctlL As New LocationController
        Dim dt As New DataTable

        dt = ctlL.Location_GetNoNewCode()

        For i = 0 To dt.Rows.Count - 1
            With dt.Rows(i)
                If String.Concat(.Item("NewCode")) = "" Then
                    NewCode = ""
                    Try
                        NewCode = ctlFDA.ConvertLicenseToNewCode(String.Concat(.Item("LicenseNo1")))
                        ctlL.Location_UpdateNewCode(.Item("UID"), NewCode, NewCode)
                    Catch ex As Exception

                    End Try
                End If
            End With
        Next

        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalSuccess(this,'Success','บันทึกเรียบร้อย');", True)

    End Sub
End Class