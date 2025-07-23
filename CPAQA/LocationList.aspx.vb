Imports System.Data
Imports BigLion
Public Class LocationList
    Inherits System.Web.UI.Page
    Dim ctlL As New LocationController
    Public dtLoc As New DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsNothing(Request.Cookies("CPAQA")) Then
            Response.Redirect("Default.aspx")
        End If
        If Not IsPostBack Then
            If Request.Cookies("ROLE_ID").Value = 2 Then
                dtLoc = ctlL.Location_GetBySupervisor(StrNull2Zero(Request.Cookies("UserID").Value))
            ElseIf Request.Cookies("ROLE_ID").Value >= 3 Then
                dtLoc = ctlL.Location_Get
            End If
        End If
    End Sub
End Class