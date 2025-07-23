Imports Microsoft.ApplicationBlocks.Data
Public Class LocationController
    Inherits BaseClass
    Dim ds As New DataSet

#Region "Locations"
    Public Function Location_GetMapsByLocation(LocationUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, "Location_GetMapsByLocation", LocationUID)
        Return ds.Tables(0)
    End Function

    Public Function Location_GetAll() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, ("Location_GetAll"))
        Return ds.Tables(0)
    End Function
    Public Function Location_GetForReport() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, ("Location_GetForReport"))
        Return ds.Tables(0)
    End Function
    Public Function Location_Get() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, ("Location_Get"))
        Return ds.Tables(0)
    End Function
    Public Function Location_GetBySupervisor(UserID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, "Location_GetBySupervisor", UserID)
        Return ds.Tables(0)
    End Function

    Public Function Location_SearchByLicense(LicenseNo As String) As Integer
        ds = SqlHelper.ExecuteDataset(ConnectionString, "Location_SearchByLicense", LicenseNo)
        If ds.Tables(0).Rows.Count > 0 Then
            Return DBNull2Zero(ds.Tables(0).Rows(0)(0))
        Else
            Return 0
        End If
    End Function

    Public Function Location_GetUID(LicenseNo As String) As Integer
        ds = SqlHelper.ExecuteDataset(ConnectionString, "Location_GetUID", LicenseNo)
        If ds.Tables(0).Rows.Count > 0 Then
            Return DBNull2Zero(ds.Tables(0).Rows(0)(0))
        Else
            Return 0
        End If
    End Function
    Public Function Location_GetByUID(uid As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, ("Location_GetByUID"), uid)
        Return ds.Tables(0)
    End Function
    Public Function Location_GetByRequestUID(LocationUid As String, RequestUID As Long) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, ("Location_GetByRequestUID"), LocationUid, RequestUID)
        Return ds.Tables(0)
    End Function
    Public Function Location_GetBySearchAll(provid As String, id As String) As DataTable

        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Location_GetByProvinceIDAll"), provid, id)
        Return ds.Tables(0)
    End Function


    Public Function Location_GetNameByID(id As String) As String
        SQL = "select LocationName  from Locations  where Locationid='" & id & "'"
        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.Text, SQL)
        If ds.Tables(0).Rows.Count > 0 Then
            Return ds.Tables(0).Rows(0)("LocationName")
        Else
            Return ""
        End If

    End Function

    Public Function Location_Register(ByVal NewCode As String, ByVal LocationID As String, ByVal Code As String, ByVal Password As String, ByVal LocationName As String, ByVal AddressNo As String, ByVal Subdistrict As String, ByVal District As String, ByVal ProvinceID As String, ByVal ZipCode As String, ByVal Tel As String, ByVal Email As String, ByVal LineID As String, ByVal WorkTime As String, ByVal Lat As String, ByVal Lng As String, ByVal Facebook As String, ByVal StartYear As Integer, ByVal LicenseNo1 As String, ByVal LicenseNo2 As String, ByVal LicenseNo3 As String, ByVal Licensee As String, ByVal LicenseeType As Integer, ByVal Area1 As Integer, ByVal Area2 As Double, ByVal LocationGroupUID As Integer, ByVal LocationChainUID As Integer, ByVal Cuser As String) As Integer

        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("Location_Add"), NewCode, LocationID, Code, Password, LocationName, AddressNo, Subdistrict, District, ProvinceID, ZipCode, Tel, Email, LineID, WorkTime, Lat, Lng, Facebook, StartYear, LicenseNo1, LicenseNo2, LicenseNo3, Licensee, LicenseeType, Area1, Area2, LocationGroupUID, LocationChainUID, Cuser)
    End Function

    Public Function Location_Update(ByVal UID As Integer, ByVal NewCode As String, ByVal LocationID As String, ByVal Code As String, ByVal LocationName As String, ByVal AddressNo As String, ByVal Subdistrict As String, ByVal District As String, ByVal ProvinceID As String, ByVal ZipCode As String, ByVal Tel As String, ByVal Email As String, ByVal LineID As String, ByVal WorkTime As String, ByVal Lat As String, ByVal Lng As String, ByVal Facebook As String, ByVal StartYear As Integer, ByVal LicenseNo1 As String, ByVal LicenseNo2 As String, ByVal LicenseNo3 As String, ByVal Licensee As String, ByVal LicenseeType As Integer, ByVal Area1 As Integer, ByVal Area2 As Double, ByVal LocationGroupUID As Integer, ByVal LocationChainUID As Integer, ByVal StatusFlag As String, ByVal Muser As String) As Integer

        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("Location_Update"), UID, NewCode, LocationID, Code, LocationName, AddressNo, Subdistrict, District, ProvinceID, ZipCode, Tel, Email, LineID, WorkTime, Lat, Lng, Facebook, StartYear, LicenseNo1, LicenseNo2, LicenseNo3, Licensee, LicenseeType, Area1, Area2, LocationGroupUID, LocationChainUID, StatusFlag, Muser)
    End Function

    Public Function Location_UpdateByLocation(ByVal UID As Integer, ByVal LocationID As String, ByVal Code As String, ByVal LocationName As String, ByVal AddressNo As String, ByVal Subdistrict As String, ByVal District As String, ByVal ProvinceID As String, ByVal ZipCode As String, ByVal Tel As String, ByVal Email As String, ByVal LineID As String, ByVal WorkTime As String, ByVal Lat As String, ByVal Lng As String, ByVal Facebook As String, ByVal StartYear As Integer, ByVal LicenseNo1 As String, ByVal LicenseNo2 As String, ByVal LicenseNo3 As String, ByVal Licensee As String, ByVal LicenseeType As Integer, ByVal Area1 As Integer, ByVal Area2 As Double, ByVal LocationGroupUID As Integer, ByVal LocationChainUID As Integer, ByVal StatusFlag As String, ByVal Muser As String) As Integer

        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("Location_UpdateByLocation"), UID, LocationID, Code, LocationName, AddressNo, Subdistrict, District, ProvinceID, ZipCode, Tel, Email, LineID, WorkTime, Lat, Lng, Facebook, StartYear, LicenseNo1, LicenseNo2, LicenseNo3, Licensee, LicenseeType, Area1, Area2, LocationGroupUID, LocationChainUID, StatusFlag, Muser)
    End Function

    Public Function Location_UpdateIsSoftware(ByVal LocationUID As Integer, ByVal IsSoftware As String) As Integer

        Return SqlHelper.ExecuteNonQuery(ConnectionString, "Location_UpdateIsSoftware", LocationUID, IsSoftware)

    End Function

    Public Function Location_UpdateAccStatus(ByVal LocationUID As Integer, ByVal AccStatus As String, ByVal AccLicense As String, ByVal StartDate As String, ByVal EndDate As String) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, "Location_UpdateAccStatus", LocationUID, AccStatus, AccLicense, StartDate, EndDate)
    End Function



    Public Function Location_UpdateByUser(ByVal LocationID As String, ByVal LocationName As String, TypeShop As String, TypeName As String, ByVal Address As String, ByVal ZipCode As String, ByVal Office_Tel As String, ByVal Office_Fax As String, ByVal Co_Name As String, ByVal Co_Mail As String, ByVal Co_Tel As String, ByVal AccNo As String, ByVal AccName As String, ByVal BankID As String, ByVal BankBrunch As String, ByVal BankType As String, ByVal UpdBy As String, ByVal Office_Mail As String, CardID As String, RYear As String) As Integer

        Return SqlHelper.ExecuteNonQuery(ConnectionString, "Location_UpdateByUser", LocationID, LocationName, TypeShop, TypeName, Address, ZipCode, Office_Tel, Office_Fax, Co_Name, Co_Mail, Co_Tel, AccNo, AccName, BankID, BankBrunch, BankType, UpdBy, Office_Mail, CardID, RYear)

    End Function


    Public Function Location_Delete(ByVal pID As String) As Integer
        SQL = "delete from Locations where Locationid ='" & pID & "'"
        Return SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, SQL)
    End Function

#End Region
#Region "Group"

    Public Function LocationGroup_Get() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("LocationGroup_Get"))
        Return ds.Tables(0)
    End Function
    Public Function LocationGroup_GetForReport() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("LocationGroup_GetForReport"))
        Return ds.Tables(0)
    End Function

    Public Function LocationGroup_GetBySearch(search As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("LocationGroup_GetBySearch"), search)
        Return ds.Tables(0)
    End Function
    Public Function LocationGroup_GetByUID(id As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("LocationGroup_GetByUID"), id)
        Return ds.Tables(0)
    End Function
    Public Function LocationGroup_CheckDuplicate(Name As String) As Boolean
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("LocationGroup_CheckDuplicate"), Name)
        If ds.Tables(0).Rows.Count > 0 Then
            If DBNull2Zero(ds.Tables(0).Rows(0)(0)) > 0 Then
                Return True
            Else
                Return False
            End If
        Else
            Return False
        End If
    End Function
    Public Function LocationGroup_Save(ByVal pUID As String, ByVal pCode As String, ByVal pName As String, pDesc As String, ByVal pStatus As String) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, "LocationGroup_Save", pUID, pCode, pName, pDesc, pStatus)
    End Function
    Public Function LocationGroup_Delete(ByVal pID As String) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, "LocationGroup_Delete", pID)
    End Function

#End Region

#Region "Chain"
    Public Function LocationChain_Get() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("LocationChain_Get"))
        Return ds.Tables(0)
    End Function
    Public Function LocationChain_GetForReport() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("LocationChain_GetForReport"))
        Return ds.Tables(0)
    End Function
    Public Function LocationChain_GetBySearch(search As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("LocationChain_GetBySearch"), search)
        Return ds.Tables(0)
    End Function
    Public Function LocationChain_GetByUID(id As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("LocationChain_GetByUID"), id)
        Return ds.Tables(0)
    End Function
    Public Function LocationChain_CheckDuplicate(Name As String) As Boolean
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("LocationChain_CheckDuplicate"), Name)
        If ds.Tables(0).Rows.Count > 0 Then
            If DBNull2Zero(ds.Tables(0).Rows(0)(0)) > 0 Then
                Return True
            Else
                Return False
            End If
        Else
            Return False
        End If
    End Function
    Public Function LocationChain_Save(ByVal pUID As String, ByVal pCode As String, ByVal pName As String, pDesc As String, ByVal pStatus As String) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, "LocationChain_Save", pUID, pCode, pName, pDesc, pStatus)
    End Function
    Public Function LocationChain_Delete(ByVal pID As String) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, "LocationChain_Delete", pID)
    End Function

#End Region

#Region "Type"

    Public Function LocationType_Get() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("LocationType_Get"))
        Return ds.Tables(0)
    End Function
    Public Function LocationType_GetForReport() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("LocationType_GetForReport"))
        Return ds.Tables(0)
    End Function

    Public Function LocationType_GetBySearch(search As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("LocationType_GetBySearch"), search)
        Return ds.Tables(0)
    End Function
    Public Function LocationType_GetByUID(id As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("LocationType_GetByUID"), id)
        Return ds.Tables(0)
    End Function
    Public Function LocationType_CheckDuplicate(Name As String) As Boolean
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("LocationType_CheckDuplicate"), Name)
        If ds.Tables(0).Rows.Count > 0 Then
            If DBNull2Zero(ds.Tables(0).Rows(0)(0)) > 0 Then
                Return True
            Else
                Return False
            End If
        Else
            Return False
        End If
    End Function
    Public Function LocationType_Save(ByVal pUID As String, ByVal pCode As String, ByVal pName As String, pDesc As String, ByVal pStatus As String) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, "LocationType_Save", pUID, pCode, pName, pDesc, pStatus)
    End Function
    Public Function LocationType_Delete(ByVal pID As String) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, "LocationType_Delete", pID)
    End Function

#End Region

#Region "LocationType Detail"
    Public Function LocationTypeDetail_Delete(ByVal LocationUID As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("LocationTypeDetail_Delete"), LocationUID)
    End Function
    Public Function LocationTypeDetail_Save(ByVal LocationUID As Integer, ByVal TypeUID As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("LocationTypeDetail_Save"), LocationUID, TypeUID)
    End Function
    Public Function LocationTypeDetail_SaveByLicense(ByVal License As String, ByVal TypeUID As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("LocationTypeDetail_SaveByLicense"), License, TypeUID)
    End Function
    Public Function LocationTypeDetail_GetByLocationUID(LocationUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("LocationTypeDetail_GetByLocationUID"), LocationUID)
        Return ds.Tables(0)
    End Function

#End Region
#Region "Location Software"

    Public Function LocationSoftware_Get(LocationUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("LocationSoftware_Get"), LocationUID)
        Return ds.Tables(0)
    End Function

    Public Function LocationSoftware_GetMaxUID() As Long
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("LocationSoftware_GetMaxUID"))
        Return DBNull2Lng(ds.Tables(0).Rows(0)(0))
    End Function
    Public Function LocationSoftware_GetLastUID(LocationUID As Integer) As Long
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("LocationSoftware_GetLastUID"), LocationUID)
        Return DBNull2Lng(ds.Tables(0).Rows(0)(0))
    End Function
    Public Function LocationSoftware_GetByUID(id As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("LocationSoftware_GetByUID"), id)
        Return ds.Tables(0)
    End Function

    Public Function LocationSoftware_Save(ByVal UID As Long, ByVal LocationUID As Integer, Name As String, Desc As String, ByVal MUser As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("LocationSoftware_Save"), UID, LocationUID, Name, Desc, MUser)
    End Function

    Public Function LocationSoftware_Update(ByVal pID_old As String, ByVal pID_new As String, ByVal pName As String, desc As String, ByVal pStatus As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, "LocationSoftware_Update", pID_old, pID_new, pName, desc, pStatus)
    End Function

    Public Function LocationSoftware_Delete(ByVal pID As String) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, "LocationSoftware_Delete", pID)
    End Function

#End Region

#Region "Location Project"

    Public Function LocationProject_Get(LocationUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("LocationProject_Get"), LocationUID)
        Return ds.Tables(0)
    End Function

    Public Function LocationProject_GetMaxUID() As Long
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("LocationProject_GetMaxUID"))
        Return DBNull2Lng(ds.Tables(0).Rows(0)(0))
    End Function
    Public Function LocationProject_GetLastUID(LocationUID As Integer) As Long
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("LocationProject_GetLastUID"), LocationUID)
        Return DBNull2Lng(ds.Tables(0).Rows(0)(0))
    End Function
    Public Function LocationProject_GetByUID(id As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("LocationProject_GetByUID"), id)
        Return ds.Tables(0)
    End Function

    Public Function LocationProject_Save(ByVal UID As Long, ByVal LocationUID As Integer, Name As String, Desc As String, Acction As String, ByVal MUser As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("LocationProject_Save"), UID, LocationUID, Name, Desc, Acction, MUser)
    End Function

    Public Function LocationProject_Update(ByVal pID_old As String, ByVal pID_new As String, ByVal pName As String, desc As String, Acction As String, ByVal pStatus As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, "LocationProject_Update", pID_old, pID_new, pName, desc, Acction, pStatus)
    End Function

    Public Function LocationProject_Delete(ByVal pID As String) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, "LocationProject_Delete", pID)
    End Function

#End Region

#Region "Location Allocate"

    Public Function LocationAllocate_GetByUser(UserID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("LocationAllocate_GetByUser"), UserID)
        Return ds.Tables(0)
    End Function
    Public Function LocationAllocate_GetByUserSearch(UserID As Integer, Search As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("LocationAllocate_GetByUserSearch"), UserID, Search)
        Return ds.Tables(0)
    End Function
    Public Function LocationAllocate_GetByLocation(LocationUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("LocationAllocate_GetByLocation"), LocationUID)
        Return ds.Tables(0)
    End Function

    Public Function Location_GetNoAllocate(UserID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Location_GetNoAllocate"), UserID)
        Return ds.Tables(0)
    End Function
    Public Function Location_GetNoAllocateSearch(UserID As Integer, Search As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Location_GetNoAllocateSearch"), UserID, Search)
        Return ds.Tables(0)
    End Function

    Public Function LocationAllocate_Add(ByVal UserID As Integer, ByVal LocationUID As Integer, ByVal MUser As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("LocationAllocate_Add"), UserID, LocationUID, MUser)
    End Function

    Public Function LocationAllocate_DeleteAll(ByVal UserID As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, "LocationAllocate_DeleteAll", UserID)
    End Function

    Public Function LocationAllocate_Delete(ByVal pID As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, "LocationAllocate_Delete", pID)
    End Function

#End Region

End Class