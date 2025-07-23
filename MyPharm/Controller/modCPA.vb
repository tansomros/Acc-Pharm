Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Globalization
Imports System.Web
Public Module modCPA
#Region "Declaration Parameter"
    Public WebURL As String = ConfigurationSettings.AppSettings("WebURL")
    Public DirectoryPath As String = ConfigurationSettings.AppSettings("DirectoryPath")
    Public DownloadPath As String = ConfigurationSettings.AppSettings("DownloadPath")
    Public ImageNews As String = ConfigurationSettings.AppSettings("ImageNews")
    Public ImageCoverNews As String = ConfigurationSettings.AppSettings("ImageCoverNews")
    Public PictureUser As String = ConfigurationSettings.AppSettings("PictureUser")
    Public DocumentUpload As String = ConfigurationSettings.AppSettings("DocumentUpload")
    Public DocumentLocation As String = ConfigurationSettings.AppSettings("DocumentLocation")

    'Public tmpUpload As String = ConfigurationSettings.AppSettings("tmpUpload")
    'Public ReportPath As String = ConfigurationSettings.AppSettings("ReportPath")

    'Public DocumentRequest As String = ConfigurationSettings.AppSettings("DocumentRequest")

    'Public DocumentAction As String = ConfigurationSettings.AppSettings("DocumentAction")
    'Public PictureRequest As String = ConfigurationSettings.AppSettings("PictureRequest")

#End Region
End Module