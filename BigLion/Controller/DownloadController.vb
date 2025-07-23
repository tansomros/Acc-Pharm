Imports Microsoft.ApplicationBlocks.Data
Public Class DownloadController
    Inherits BaseClass
    Dim ds As New DataSet

    Public Function Document_GetSearch(SiteFlag As String, pSearch As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, ("Document_GetSearch"), SiteFlag, pSearch)
        Return ds.Tables(0)
    End Function


    Public Function Download_GetByStatus(Status As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, ("Download_GetByStatus"), Status)
        Return ds.Tables(0)
    End Function

    Public Function Download_GetByCategory(TypeID As Integer, SiteFlag As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, ("Download_GetByCategory"), TypeID, SiteFlag)
        Return ds.Tables(0)
    End Function

    Public Function Download_GetByUID(UID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, ("Download_GetByUID"), UID)
        Return ds.Tables(0)
    End Function
    Public Function Download_GetSearch(SiteFlag As String, pSearch As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, ("Download_GetSearch"), SiteFlag, pSearch)
        Return ds.Tables(0)
    End Function
    Public Function Download_Delete(PUID As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, ("Download_Delete"), PUID)
    End Function
    Public Function Download_GetLastUID(ByVal CategoryUID As Integer, ByVal TypeUID As Integer, ByVal Descriptions As String, ByVal CUser As Integer) As Integer
        ds = SqlHelper.ExecuteDataset(ConnectionString, ("Download_GetLastUID"), CategoryUID, TypeUID, CUser)
        Return DBNull2Zero(ds.Tables(0).Rows(0)(0))
    End Function
    Public Function Download_Add(ByVal CategoryUID As Integer, ByVal TypeUID As Integer, ByVal Descriptions As String, ByVal FileIcon As String, ByVal FileExtension As String, ByVal FilePath As String, ByVal Sort As Integer, ByVal isTH As String, ByVal isEN As String, ByVal CUser As Integer, SiteFlag As String) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, ("Download_Add"), CategoryUID _
           , TypeUID _
           , Descriptions _
           , FileIcon _
           , FileExtension _
           , FilePath _
           , Sort _
           , isTH _
           , isEN _
           , CUser, SiteFlag)
    End Function
    Public Function Download_Update(ByVal UID As Integer, ByVal CategoryUID As Integer, ByVal TypeUID As Integer, ByVal Descriptions As String, ByVal Sort As Integer, ByVal isTH As String, ByVal isEN As String, ByVal MUser As Integer, SiteFlag As String) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, ("Download_Update"), UID, CategoryUID _
           , TypeUID _
           , Descriptions _
           , Sort _
           , isTH _
           , isEN _
           , MUser, SiteFlag)
    End Function

    Public Function Download_UpdateFile(ByVal UID As Integer, ByVal FileIcon As String, ByVal FileExtension As String, ByVal FilePath As String, ByVal CUser As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, ("Download_UpdateFile"), UID, FileIcon _
           , FileExtension _
           , FilePath _
           , CUser)
    End Function

#Region "Media"

    Public Function Media_Get(GroupID As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, ("Media_Get"), GroupID)
        Return ds.Tables(0)
    End Function

    Public Function Media_GetSearch(pSearch As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, ("Media_GetSearch"), pSearch)
        Return ds.Tables(0)
    End Function

    Public Function Media_Delete(PUID As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, ("Media_Delete"), PUID)
    End Function
    Public Function Media_GetByUID(UID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, ("Media_GetByUID"), UID)
        Return ds.Tables(0)
    End Function
    Public Function Media_Add(ByVal MajorUID As Integer, ByVal SubjectCode As String, ByVal SubjectName As String, ByVal Descriptions As String, ByVal Instructor As String, ByVal FilePath As String, ByVal CUser As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, ("Media_Add"), MajorUID, SubjectCode, SubjectName, Descriptions, Instructor, FilePath, CUser)
    End Function
    Public Function Media_Update(ByVal UID As Integer, ByVal MajorUID As Integer, ByVal SubjectCode As String, ByVal SubjectName As String, ByVal Descriptions As String, ByVal Instructor As String, ByVal FilePath As String, ByVal CUser As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, ("Media_Update"), UID, MajorUID, SubjectCode, SubjectName, Descriptions, Instructor, FilePath, CUser)
    End Function

    Public Function Media_UpdateFile(ByVal UID As Integer, ByVal FileIcon As String, ByVal FileExtension As String, ByVal FilePath As String, ByVal CUser As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, ("Media_UpdateFile"), UID, FileIcon _
           , FileExtension _
           , FilePath _
           , CUser)
    End Function
#End Region

#Region "Group"
    Public Function Download_Group_Get() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, ("Download_Group_Get"))
        Return ds.Tables(0)
    End Function
#End Region


#Region "Category"
    Public Function Download_Category_Get() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, ("Download_Category_Get"))
        Return ds.Tables(0)
    End Function
#End Region

#Region "Type"
    Public Function Download_Type_Get(CateUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, ("Download_Type_Get"), CateUID)
        Return ds.Tables(0)
    End Function
#End Region

End Class
