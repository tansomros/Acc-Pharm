Imports Microsoft.ApplicationBlocks.Data

Public Class NewsController
    Inherits BaseClass
    Dim ds As New DataSet

    Public Function News_Get() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, "News_Get")
        Return ds.Tables(0)
    End Function
    Public Function News_GetActive() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, "News_GetActive")
        Return ds.Tables(0)
    End Function
    Public Function News_GetPageCountBySearch(Category As String, Search As String) As Integer
        ds = SqlHelper.ExecuteDataset(ConnectionString, "News_GetPageCountBySearch", Category, Search)
        If ds.Tables(0).Rows.Count > 0 Then
            If DBNull2Zero(ds.Tables(0).Rows(0)(0)) > 0 Then
                Return ds.Tables(0).Rows(0)(0)
            Else
                Return 1
            End If
        Else
            Return 1
        End If

    End Function

    Public Function News_GetSearch(Category As String, Search As String, CurrentPage As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, "News_GetSearch", Category, Search, CurrentPage)
        Return ds.Tables(0)
    End Function


    Public Function News_GetByID(NewsID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, "News_GetByID", NewsID)
        Return ds.Tables(0)
    End Function
    Public Function News_GetNextNewsID() As Integer
        ds = SqlHelper.ExecuteDataset(ConnectionString, "News_GetNextNewsID")
        Return DBNull2Zero(ds.Tables(0).Rows(0)(0))
    End Function
    Public Function News_UpdateReadCount(NewsID As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, "News_UpdateReadCount", NewsID)
    End Function

    'Public Function News_Save(ByVal NewsID As Integer, NewsCate As String, ByVal NewsHead As String, ByVal ContentNews As String, ByVal ImagePath As String, FileAttachName As String, isMember As String, StatusFlag As String) As Integer
    '    Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("News_Save"), NewsID, NewsCate, NewsHead, ContentNews, ImagePath, FileAttachName, isMember, StatusFlag)
    'End Function
    Public Function News_Save(ByVal NewsID As Integer, NewsCate As String, NewsType As String, ByVal NewsHead As String, ByVal ContentNews As String, ByVal ImagePath As String, FileAttachName As String, FilePath As String, LinkURL As String, isMember As String, StatusFlag As String, SiteFlag As String) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("News_Save"), NewsID, NewsCate, NewsType, NewsHead, ContentNews, ImagePath, FileAttachName, FilePath, LinkURL, isMember, StatusFlag, SiteFlag)
    End Function

    Public Function News_UpdateFileAttachName(ByVal NewsID As Integer, ByVal FilePath As String) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("News_UpdateFileAttachName"), NewsID, FilePath)
    End Function

    Public Function News_Delete(ByVal pID As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, "News_Delete", pID)
    End Function

    Public Function News_GetFirstPage(SiteFlag As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, "News_GetFirstPage", SiteFlag)
        Return ds.Tables(0)
    End Function
    Public Function News_GetList(Cate As String, Search As String, NewsFlag As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, "News_GetList", Cate, Search, NewsFlag)
        Return ds.Tables(0)
    End Function

    Public Function PrivateNews_Save(ByVal NewsID As Integer, NewsCate As String, isTH As String, isEN As String, ByVal NewsHead As String, ByVal ContentNews As String, ByVal IsActive As Integer, ByVal FilePath As String) As Integer

        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("PrivateNews_Add"), NewsID, NewsCate, isTH, isEN, NewsHead, ContentNews, IsActive, FilePath)
    End Function

End Class
