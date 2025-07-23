Imports System
Imports BigLion
Public Class DrugStore
    Inherits System.Web.UI.Page
    Dim ctlL As New LocationController
    Public dtLoc As New DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            dtLoc = ctlL.Location_Get
        End If
    End Sub
End Class