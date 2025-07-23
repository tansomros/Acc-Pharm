Imports Microsoft.ApplicationBlocks.Data

Public Class MediaController
    Inherits BaseClass
    Dim ds As New DataSet
#Region "QA"

    Public Function Media_Get(RequestUID As Integer, LocationUID As Integer, ImageGroup As String, REFUID As Long) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Media_Get"), RequestUID, LocationUID, ImageGroup, REFUID)
        Return ds.Tables(0)
    End Function
    Public Function Media_GetByYear(RequestUID As Integer, AsmYear As Integer, LocationUID As Integer, ImageGroup As String, REFUID As Long) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Media_GetByYear"), RequestUID, AsmYear, LocationUID, ImageGroup, REFUID)
        Return ds.Tables(0)
    End Function
    Public Function Media_GetByLocation(LocationUID As Integer, ImageGroup As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Media_GetByLocation"), LocationUID, ImageGroup)
        Return ds.Tables(0)
    End Function
    Public Function Media_GetStatus(RequestUID As Integer, LocationUID As Integer, ImageGroup As String, REFUID As Long) As String
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Media_GetStatus"), RequestUID, LocationUID, ImageGroup, REFUID)
        Return String.Concat(ds.Tables(0).Rows(0)(0))
    End Function

    Public Function Media_GetByID(id As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Media_GetByID"), id)
        Return ds.Tables(0)
    End Function

    Public Function Media_GetPharmacistImage(LocationUID As Integer, REFUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Media_GetPharmacistImage"), LocationUID, REFUID)
        Return ds.Tables(0)
    End Function

    Public Function Media_GetProfileImage(LocationUID As Integer) As String
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Media_GetProfileImage"), LocationUID)
        If ds.Tables(0).Rows.Count > 0 Then
            Return String.Concat(ds.Tables(0).Rows(0)(0))
        Else
            Return ""
        End If
    End Function
    Public Function Media_GetCount(RequestUID As Integer, AsmYear As Integer, LocationUID As Integer, ImageGroup As String, REFUID As Long) As Integer
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Media_GetCount"), RequestUID, AsmYear, LocationUID, ImageGroup, REFUID)
        Return DBNull2Zero(ds.Tables(0).Rows(0)(0))
    End Function
    Public Function Media_GetLastSEQ(RequestUID As Integer, AsmYear As Integer, LocationUID As Integer, ImageGroup As String, REFUID As Long) As Integer
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Media_GetLastSEQ"), RequestUID, AsmYear, LocationUID, ImageGroup, REFUID)
        Return DBNull2Zero(ds.Tables(0).Rows(0)(0))
    End Function

    Public Function Media_GetImagePath(RequestUID As Integer, LocationUID As Integer, ImageGroup As String, REFUID As Long) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Media_GetImagePath"), RequestUID, LocationUID, ImageGroup, REFUID)
        Return ds.Tables(0)
    End Function
    Public Function Media_Save(RequestUID As Integer, AsmYear As Integer, LocationUID As Integer, ImageGroup As String, REFUID As Long, ByVal SEQNO As Integer, ByVal LinkPath As String, ByVal MUser As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("Media_Save"), RequestUID, AsmYear, LocationUID, ImageGroup, REFUID, SEQNO, LinkPath, MUser)
    End Function
    Public Function Media_Save2(RequestUID As Integer, AsmYear As Integer, LocationUID As Integer, ImageGroup As String, REFUID As Long, ByVal SEQNO As Integer, ByVal LinkPath As String, ByVal MUser As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("Media_Save2"), RequestUID, AsmYear, LocationUID, ImageGroup, REFUID, SEQNO, LinkPath, MUser)
    End Function


    'Public Function Media_SaveGPP(RequestUID As Integer, AsmYear As Integer, LocationUID As Integer, ImageGroup As String, REFUID As Long, ByVal SEQNO As Integer, ByVal LinkPath As String, ByVal MUser As Integer) As Integer
    '    Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("Media_SaveGPP"), RequestUID, AsmYear, LocationUID, ImageGroup, REFUID, SEQNO, LinkPath, MUser)
    'End Function

    Public Function Media_Delete(ByVal pID As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, "Media_Delete", pID)
    End Function

#End Region

#Region "Complain"

    Public Function ComplainFile_Get(RequestUID As Integer, LocationUID As Integer, ImageGroup As String, REFUID As Long) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("ComplainFile_Get"), RequestUID, LocationUID, ImageGroup, REFUID)
        Return ds.Tables(0)
    End Function
    Public Function ComplainFile_GetNull(UserID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("ComplainFile_GetNull"), UserID)
        Return ds.Tables(0)
    End Function
    Public Function ComplainFile_GetByRefCode(RefCode As String, GroupCode As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("ComplainFile_GetByRefCode"), RefCode, GroupCode)
        Return ds.Tables(0)
    End Function
    Public Function ComplainFile_GetByComplainUID(cmpUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("ComplainFile_GetByComplainUID"), cmpUID)
        Return ds.Tables(0)
    End Function

    Public Function ComplainFile_GetStatus(RequestUID As Integer, LocationUID As Integer, ImageGroup As String, REFUID As Long) As String
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("ComplainFile_GetStatus"), RequestUID, LocationUID, ImageGroup, REFUID)
        Return String.Concat(ds.Tables(0).Rows(0)(0))
    End Function

    Public Function ComplainFile_GetByID(id As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("ComplainFile_GetByID"), id)
        Return ds.Tables(0)
    End Function

    Public Function ComplainFile_GetPharmacistImage(LocationUID As Integer, REFUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("ComplainFile_GetPharmacistImage"), LocationUID, REFUID)
        Return ds.Tables(0)
    End Function

    Public Function ComplainFile_GetProfileImage(LocationUID As Integer) As String
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("ComplainFile_GetProfileImage"), LocationUID)
        If ds.Tables(0).Rows.Count > 0 Then
            Return String.Concat(ds.Tables(0).Rows(0)(0))
        Else
            Return ""
        End If
    End Function
    Public Function ComplainFile_GetCount(RequestUID As Integer, AsmYear As Integer, LocationUID As Integer, ImageGroup As String, REFUID As Long) As Integer
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("ComplainFile_GetCount"), RequestUID, AsmYear, LocationUID, ImageGroup, REFUID)
        Return DBNull2Zero(ds.Tables(0).Rows(0)(0))
    End Function
    Public Function ComplainFile_GetLastSEQ(RefCode As String, GroupCode As String) As Integer
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("ComplainFile_GetLastSEQ"), RefCode, GroupCode)
        Return DBNull2Zero(ds.Tables(0).Rows(0)(0))
    End Function

    Public Function ComplainFile_GetImagePath(RequestUID As Integer, LocationUID As Integer, ImageGroup As String, REFUID As Long) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("ComplainFile_GetImagePath"), RequestUID, LocationUID, ImageGroup, REFUID)
        Return ds.Tables(0)
    End Function
    Public Function ComplainFile_Save(RefCode As String, ComplainUID As Integer, GroupCode As String, ByVal SEQNO As Integer, ByVal FilePath As String, ByVal FileType As String, ByVal MUser As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("ComplainFile_Save"), RefCode, ComplainUID, GroupCode, SEQNO, FilePath, FileType, MUser)
    End Function

    'Public Function ComplainFile_SaveGPP(RequestUID As Integer, AsmYear As Integer, LocationUID As Integer, ImageGroup As String, REFUID As Long, ByVal SEQNO As Integer, ByVal LinkPath As String, ByVal MUser As Integer) As Integer
    '    Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("ComplainFile_SaveGPP"), RequestUID, AsmYear, LocationUID, ImageGroup, REFUID, SEQNO, LinkPath, MUser)
    'End Function

    Public Function ComplainFile_Delete(ByVal pID As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, "ComplainFile_Delete", pID)
    End Function
    Public Function ComplainFile_DeleteByFileName(ByVal pFilename As String) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, "ComplainFile_DeleteByFileName", pFilename)
    End Function

    Public Function ComplainFile_DeleteByComplainUID(ByVal cmpUID As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, "ComplainFile_DeleteByComplainUID", cmpUID)
    End Function

#End Region
#Region "Post"

    Public Function PostAuditFile_GetNull(UserID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("PostAuditFile_GetNull"), UserID)
        Return ds.Tables(0)
    End Function
    Public Function PostAuditFile_Get(PostUID As Integer, GroupCode As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("PostAuditFile_Get"), PostUID, GroupCode)
        Return ds.Tables(0)
    End Function
    Public Function PostAuditFile_GetLastSEQ(RefCode As String, GroupCode As String) As Integer
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("PostAuditFile_GetLastSEQ"), RefCode, GroupCode)
        Return DBNull2Zero(ds.Tables(0).Rows(0)(0))
    End Function
    Public Function PostAuditFile_GetStatus(RequestUID As Integer, LocationUID As Integer, ImageGroup As String, REFUID As Long) As String
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("PostAuditFile_GetStatus"), RequestUID, LocationUID, ImageGroup, REFUID)
        Return String.Concat(ds.Tables(0).Rows(0)(0))
    End Function

    Public Function PostAuditFile_GetByID(id As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("PostAuditFile_GetByID"), id)
        Return ds.Tables(0)
    End Function
    Public Function PostAuditFile_Save(RefCode As String, PostUID As Integer, LocationUID As Integer, GroupCode As String, ByVal SEQNO As Integer, ByVal FilePath As String, ByVal FileType As String, ByVal MUser As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("PostAuditFile_Save"), RefCode, PostUID, LocationUID, GroupCode, SEQNO, FilePath, FileType, MUser)
    End Function

    'Public Function PostAuditFile_SaveGPP(RequestUID As Integer, AsmYear As Integer, LocationUID As Integer, ImageGroup As String, REFUID As Long, ByVal SEQNO As Integer, ByVal LinkPath As String, ByVal MUser As Integer) As Integer
    '    Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("PostAuditFile_SaveGPP"), RequestUID, AsmYear, LocationUID, ImageGroup, REFUID, SEQNO, LinkPath, MUser)
    'End Function

    Public Function PostAuditFile_Delete(ByVal pID As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, "PostAuditFile_Delete", pID)
    End Function
#End Region
End Class
