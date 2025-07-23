Imports Microsoft.ApplicationBlocks.Data

Public Class MediaController
    Inherits BaseClass
    Dim ds As New DataSet

    Public Function Media_Get(RequestUID As Integer, LocationUID As Integer, ImageGroup As String, REFUID As Long) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Media_Get"), RequestUID, LocationUID, ImageGroup, REFUID)
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
    Public Function Media_GetCount(RequestUID As Integer, LocationUID As Integer, ImageGroup As String, REFUID As Long) As Integer
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Media_GetCount"), RequestUID, LocationUID, ImageGroup, REFUID)
        Return DBNull2Zero(ds.Tables(0).Rows(0)(0))
    End Function
    Public Function Media_GetLastSEQ(RequestUID As Integer, LocationUID As Integer, ImageGroup As String, REFUID As Long) As Integer
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Media_GetLastSEQ"), RequestUID, LocationUID, ImageGroup, REFUID)
        Return DBNull2Zero(ds.Tables(0).Rows(0)(0))
    End Function

    Public Function Media_GetImagePath(RequestUID As Integer, LocationUID As Integer, ImageGroup As String, REFUID As Long) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Media_GetImagePath"), RequestUID, LocationUID, ImageGroup, REFUID)
        Return ds.Tables(0)
    End Function


    Public Function Media_Save(RequestUID As Integer, LocationUID As Integer, ImageGroup As String, REFUID As Long, ByVal SEQNO As Integer, ByVal LinkPath As String, ByVal MUser As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("Media_Save"), RequestUID, LocationUID, ImageGroup, REFUID, SEQNO, LinkPath, MUser)
    End Function

    Public Function Media_Delete(ByVal pID As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, "Media_Delete", pID)
    End Function

End Class
