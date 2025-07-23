Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Globalization
Imports System.Web
Public Module modCPA
#Region "Declaration Parameter"
    'Public PictureUser As String = ConfigurationSettings.AppSettings("PictureUser")
    'Public DownloadPath As String = ConfigurationSettings.AppSettings("DownloadPath")
    'Public tmpUpload As String = ConfigurationSettings.AppSettings("tmpUpload")
    'Public ReportPath As String = ConfigurationSettings.AppSettings("ReportPath")
    'Public DocumentUpload As String = ConfigurationSettings.AppSettings("DocumentUpload")
    'Public DocumentRequest As String = ConfigurationSettings.AppSettings("DocumentRequest")
    'Public DocumentLocation As String = ConfigurationSettings.AppSettings("DocumentLocation")
    'Public DocumentAction As String = ConfigurationSettings.AppSettings("DocumentAction")
    'Public PictureRequest As String = ConfigurationSettings.AppSettings("PictureRequest")
    'Public CourseImage As String = ConfigurationSettings.AppSettings("CourseImage")
    'Public ElearningResource As String = ConfigurationSettings.AppSettings("ElearningResource")
    'Public ImageNews As String = ConfigurationSettings.AppSettings("ImageNews")
    'Public ImageCoverNews As String = ConfigurationSettings.AppSettings("ImageCoverNews")

    'Public ReportPath As String = ConfigurationSettings.AppSettings("ReportPath")
    'Public DocumentRequest As String = ConfigurationSettings.AppSettings("DocumentRequest")
    'Public PictureRequest As String = ConfigurationSettings.AppSettings("PictureRequest")


    Public ProjectLogo As String = "imgLogo"
    Public gPassPhase As String = "CPA@THEDEV"
    Public PictureUser As String = "images/users"
    Public PicturePsn As String = "imgPerson"
    Public tmpUpload As String = "tmpUploads"
    Public DownloadPath As String = "Documents/"
    Public DocumentUpload As String = "Documents"
    Public DocumentLocation As String = "Documents/Locations"
    Public DocumentAction As String = "Documents/Action"
    Public ImageNews As String = "ImageNews/"
    Public ImageCoverNews As String = "ImageNews/cover/"


#End Region
End Module