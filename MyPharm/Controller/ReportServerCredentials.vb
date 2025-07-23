Imports Microsoft.Reporting.WebForms
Imports System.Security.Principal
Imports System.Net

Partial Public Class ReportServerCredentials
    Implements IReportServerCredentials

    Private _userName As String
    Private _password As String
    Private _domain As String

    Public Sub New()
        _userName = ConfigurationManager.AppSettings("ReportServerUser")
        _password = ConfigurationManager.AppSettings("ReportServerPassword")
        _domain = ConfigurationManager.AppSettings("ReportServerLocation")
    End Sub

    Public Function ReportServerUrl() As Uri
        Return New Uri(ConfigurationManager.AppSettings("ReportServerURL"))
    End Function

    Public Function ReportPath(ByVal path As String) As String
        Return ConfigurationManager.AppSettings("ReportServerPath") & "/" + path
    End Function

    Public ReadOnly Property ImpersonationUser() As WindowsIdentity Implements IReportServerCredentials.ImpersonationUser
        Get
            Return Nothing
        End Get
    End Property

    Public ReadOnly Property NetworkCredentials() As ICredentials Implements IReportServerCredentials.NetworkCredentials
        Get
            Return New NetworkCredential(_userName, _password, _domain)
        End Get
    End Property

    Public Function GetFormsCredentials(ByRef authCookie As Cookie, ByRef userName As String, ByRef password As String, ByRef authority As String) As Boolean Implements IReportServerCredentials.GetFormsCredentials
        userName = _userName
        password = _password
        authority = _domain
        Return Nothing
    End Function

End Class
