Imports System.Web.Configuration
Imports BigLion
Imports Microsoft.ApplicationBlocks.Data

Public Class A
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Private Sub cmdApprove_Click(sender As Object, e As EventArgs) Handles cmdApprove.Click

        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalSuccess(this,'Success','บันทึกเรียบร้อย');", True)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim dtL As New DataTable
        Dim ctlL As New LocationController

        dtL = ctlL.Location_GetNoHour
        If dtL.Rows.Count > 0 Then
            For i = 0 To dtL.Rows.Count - 1
                With dtL.Rows(i)
                    ctlL.LocationHour_Save(.Item("LocationUID"), 1, "SUN", "Y", "08:00", "20:00", 1)
                    ctlL.LocationHour_Save(.Item("LocationUID"), 2, "MON", "Y", "08:00", "20:00", 1)
                    ctlL.LocationHour_Save(.Item("LocationUID"), 3, "TUE", "Y", "08:00", "20:00", 1)
                    ctlL.LocationHour_Save(.Item("LocationUID"), 4, "WED", "Y", "08:00", "20:00", 1)
                    ctlL.LocationHour_Save(.Item("LocationUID"), 5, "THU", "Y", "08:00", "20:00", 1)
                    ctlL.LocationHour_Save(.Item("LocationUID"), 6, "FRI", "Y", "08:00", "20:00", 1)
                    ctlL.LocationHour_Save(.Item("LocationUID"), 7, "SAT", "Y", "08:00", "20:00", 1)
                End With
            Next
        End If
        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalSuccess(this,'Success','บันทึกเรียบร้อย');", True)
    End Sub
End Class