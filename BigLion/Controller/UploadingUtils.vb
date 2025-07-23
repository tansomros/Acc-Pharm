Imports Microsoft.VisualBasic
Imports System
Imports System.IO
Imports System.Web
Imports System.Web.Caching
Imports System.Web.Configuration
Imports DevExpress.Web

Public NotInheritable Class UploadingUtils
    Private Const DropboxAccessTokenValueSettingName As String = "UploadDropboxAccessTokenValue"
    Private Const AzureAccessKeySettingName As String = "UploadAzureAccessKey"
    Private Const AmazonAccessKeyIDSettingName As String = "UploadAmazonAccessKeyID"
    Private Const AmazonSecretAccessKeySettingName As String = "UploadAmazonSecretAccessKey"

    Private Const RemoveTaskKeyPrefix As String = "DXRemoveTask_"

    Private Sub New()
    End Sub
    Public Shared Function GetAmazonAccessKeyID() As String
        Return WebConfigurationManager.AppSettings(AmazonAccessKeyIDSettingName)
    End Function
    Public Shared Function GetAmazonSecretAccessKey() As String
        Return WebConfigurationManager.AppSettings(AmazonSecretAccessKeySettingName)
    End Function
    Public Shared Function GetAzureStorageAccountName() As String
        Return "aspxdemos"
    End Function
    Public Shared Function GetAzureAccessKey() As String
        Return WebConfigurationManager.AppSettings(AzureAccessKeySettingName)
    End Function
    Public Shared Function GetDropboxAccessTokenValue() As String
        Return WebConfigurationManager.AppSettings(DropboxAccessTokenValueSettingName)
    End Function

    Public Shared Sub RemoveFileWithDelay(ByVal key As String, ByVal fullPath As String, ByVal delay As Integer)
        RemoveFileWithDelayInternal(key, fullPath, delay, AddressOf FileSystemRemoveAction)
    End Sub
    Public Shared Sub RemoveFileFromAzureWithDelay(ByVal fileKeyName As String, ByVal accountName As String, ByVal containerName As String, ByVal delay As Integer)
        Dim azureFile As New AzureFileInfo(fileKeyName, accountName, containerName)
        RemoveFileWithDelayInternal(fileKeyName, azureFile, delay, AddressOf AzureStorageRemoveAction)
    End Sub
    Public Shared Sub RemoveFileFromAmazonWithDelay(ByVal fileKeyName As String, ByVal accountName As String, ByVal bucketName As String, ByVal region As String, ByVal delay As Integer)
        Dim amazonFile As New AmazonFileInfo(fileKeyName, accountName, bucketName, region)
        RemoveFileWithDelayInternal(fileKeyName, amazonFile, delay, AddressOf AmazonStorageRemoveAction)
    End Sub
    Public Shared Sub RemoveFileFromDropboxWithDelay(ByVal fileKeyName As String, ByVal accountName As String, ByVal delay As Integer)
        Dim dropboxFile As New DropboxFileInfo(fileKeyName, accountName)
        RemoveFileWithDelayInternal(fileKeyName, dropboxFile, delay, AddressOf DropboxStorageRemoveAction)
    End Sub
    Private Shared Sub FileSystemRemoveAction(ByVal key As String, ByVal value As Object, ByVal reason As CacheItemRemovedReason)
        Dim fileFullPath As String = value.ToString()
        If File.Exists(fileFullPath) Then
            File.Delete(fileFullPath)
        End If
    End Sub
    Private Shared Sub AzureStorageRemoveAction(ByVal key As String, ByVal value As Object, ByVal reason As CacheItemRemovedReason)
        Dim azureFile As AzureFileInfo = TryCast(value, AzureFileInfo)
        If azureFile IsNot Nothing Then
            Dim provider As New AzureFileSystemProvider("")
            provider.AccountName = azureFile.AccountName
            provider.ContainerName = azureFile.ContainerName
            Dim file As New FileManagerFile(provider, azureFile.FileKeyName)
            provider.DeleteFile(file)
        End If
    End Sub
    Private Shared Sub AmazonStorageRemoveAction(ByVal key As String, ByVal value As Object, ByVal reason As CacheItemRemovedReason)
        Dim amazonFile As AmazonFileInfo = TryCast(value, AmazonFileInfo)
        If amazonFile IsNot Nothing Then
            Dim provider As New AmazonFileSystemProvider("")
            provider.AccountName = amazonFile.AccountName
            provider.BucketName = amazonFile.BucketName
            provider.Region = amazonFile.Region
            Dim file As New FileManagerFile(provider, amazonFile.FileKeyName)
            provider.DeleteFile(file)
        End If
    End Sub
    Private Shared Sub DropboxStorageRemoveAction(ByVal key As String, ByVal value As Object, ByVal reason As CacheItemRemovedReason)
        Dim dropboxFile As DropboxFileInfo = TryCast(value, DropboxFileInfo)
        If dropboxFile IsNot Nothing Then
            Dim provider As New DropboxFileSystemProvider("")
            provider.AccountName = dropboxFile.AccountName
            Dim file As New FileManagerFile(provider, dropboxFile.FileKeyName)
            provider.DeleteFile(file)
        End If
    End Sub
    Private Shared Sub RemoveFileWithDelayInternal(ByVal fileKey As String, ByVal fileData As Object, ByVal delay As Integer, ByVal removeAction As CacheItemRemovedCallback)
        Dim key As String = RemoveTaskKeyPrefix & fileKey
        If HttpRuntime.Cache(key) Is Nothing Then
            Dim absoluteExpiration As DateTime = DateTime.UtcNow.Add(New TimeSpan(0, delay, 0))
            HttpRuntime.Cache.Insert(key, fileData, Nothing, absoluteExpiration, Cache.NoSlidingExpiration, CacheItemPriority.NotRemovable, removeAction)
        End If
    End Sub

    Private Class AzureFileInfo
        Public Property FileKeyName() As String
        Public Property AccountName() As String
        Public Property ContainerName() As String

        Public Sub New(ByVal fileKeyName As String, ByVal accountName As String, ByVal containerName As String)
            fileKeyName = fileKeyName
            accountName = accountName
            containerName = containerName
        End Sub
    End Class

    Private Class AmazonFileInfo
        Public Property FileKeyName() As String
        Public Property AccountName() As String
        Public Property BucketName() As String
        Public Property Region() As String

        Public Sub New(ByVal fileKeyName As String, ByVal accountName As String, ByVal bucketName As String, ByVal region As String)
            fileKeyName = fileKeyName
            accountName = accountName
            bucketName = bucketName
            region = region
        End Sub
    End Class
    Private Class DropboxFileInfo
        Public Property FileKeyName() As String
        Public Property AccountName() As String

        Public Sub New(ByVal fileKeyName As String, ByVal accountName As String)
            fileKeyName = fileKeyName
            accountName = accountName
        End Sub
    End Class
End Class

