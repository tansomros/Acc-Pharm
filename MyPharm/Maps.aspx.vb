Imports System.Security.Cryptography
Imports BigLion

Public Class Maps
    Inherits System.Web.UI.Page
    Public dtMap As New DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ctlL As New LocationController
        dtMap = ctlL.Location_GetMapsAll()
    End Sub
End Class