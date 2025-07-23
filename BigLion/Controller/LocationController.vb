Imports System.Configuration
Imports Microsoft.ApplicationBlocks.Data
Public Class LocationController
    Inherits BaseClass
    Dim ds As New DataSet

#Region "Locations"
    Public Function Location_GetMapsAll() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, "Location_GetMapsAll")
        Return ds.Tables(0)
    End Function
    Public Function Location_GetMapsByProvince(ProvinceID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, "Location_GetMapsByProvince", ProvinceID)
        Return ds.Tables(0)
    End Function
    Public Function Location_GetMapsByLocation(LocationUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, "Location_GetMapsByLocation", LocationUID)
        Return ds.Tables(0)
    End Function
    Public Function Location_GetAll() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, ("Location_GetAll"))
        Return ds.Tables(0)
    End Function
    Public Function Location_GetNoNewCode() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, ("Location_GetNoNewCode"))
        Return ds.Tables(0)
    End Function
    Public Function Location_GetForNewFDA() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, ("Location_GetForNewFDA"))
        Return ds.Tables(0)
    End Function
    Public Function PharmacyLicense_GetForUpdateLicen() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, ("PharmacyLicense_GetForUpdateLicen"))
        Return ds.Tables(0)
    End Function
    Public Function Location_GetForUpdateFDA2() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, ("Location_GetForUpdateFDA2"))
        Return ds.Tables(0)
    End Function

    Public Function PharmacyLicense_GetForUpdatePharmacist() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, ("PharmacyLicense_GetForUpdatePharmacist"))
        Return ds.Tables(0)
    End Function

    Public Function Location_GetForReport() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, ("Location_GetForReport"))
        Return ds.Tables(0)
    End Function
    Public Function Location_GetForCCR() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, ("Location_GetForCCR"))
        Return ds.Tables(0)
    End Function
    Public Function Location_Get() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, ("Location_Get"))
        Return ds.Tables(0)
    End Function
    Public Function Location_GetForUser() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, ("Location_GetForUser"))
        Return ds.Tables(0)
    End Function

    Public Function Location_GetBySupervisor(UserID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, "Location_GetBySupervisor", UserID)
        Return ds.Tables(0)
    End Function
    Public Function Location_PPH_GetByProvince(UserID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, "Location_PPH_GetByProvince", UserID)
        Return ds.Tables(0)
    End Function

    Public Function Location_GetByPPHealth(AsmYear As Integer, UserID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, "Location_GetByPPHealth", AsmYear, UserID)
        Return ds.Tables(0)
    End Function
    Public Function Location_GetByPPHealthAdmin(AsmYear As Integer, UserID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, "Location_GetByPPHealthAdmin", AsmYear, UserID)
        Return ds.Tables(0)
    End Function
    Public Function Location_GetForPPHealth(AsmYear As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, "Location_GetForPPHealth", AsmYear)
        Return ds.Tables(0)
    End Function

    Public Function Location_GetForPPHealthByYear(AsmYear As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, "Location_GetForPPHealthByYear", AsmYear)
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
    Public Function Location_CheckDuplicate(LicenseNo As String) As Boolean
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Location_CheckDuplicate"), LicenseNo)
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

    Public Function Location_GetNameByUID(uid As String) As String
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Location_GetNameByUID"), uid)
        If ds.Tables(0).Rows.Count > 0 Then
            Return String.Concat(ds.Tables(0).Rows(0)("LocationName"))
        Else
            Return ""
        End If
    End Function

    Public Function Location_Register(ByVal NewCode As String, ByVal LocationID As String, ByVal Code As String, ByVal Password As String, ByVal LocationName As String, ByVal AddressNo As String, ByVal Moo As String, ByVal Road As String, ByVal Subdistrict As String, ByVal District As String, ByVal ProvinceID As String, ByVal ZipCode As String, ByVal Tel As String, ByVal Email As String, ByVal LineID As String, ByVal WorkTime As String, ByVal Lat As String, ByVal Lng As String, ByVal Facebook As String, ByVal StartYear As Integer, ByVal LicenseNo1 As String, ByVal LicenseNo2 As String, ByVal LicenseNo3 As String, ByVal Licensee As String, ByVal LicenseeType As Integer, ByVal Area1 As Integer, ByVal Area2 As Double, ByVal LocationGroupUID As Integer, ByVal LocationChainUID As Integer, ByVal Cuser As String, IsAccPharm As String, ByVal NHSOCode As String, ByVal IsPPHealth As String, ByVal AuthPerson As String, Pharmacist As String, LicenseNo As String) As Integer

        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("Location_Add"), NewCode, LocationID, Code, Password, LocationName, AddressNo, Moo, Road, Subdistrict, District, ProvinceID, ZipCode, Tel, Email, LineID, WorkTime, Lat, Lng, Facebook, StartYear, LicenseNo1, LicenseNo2, LicenseNo3, Licensee, LicenseeType, Area1, Area2, LocationGroupUID, LocationChainUID, Cuser, IsAccPharm, NHSOCode, IsPPHealth, AuthPerson, Pharmacist, LicenseNo)
    End Function
    Public Function Location_Update(ByVal UID As Integer, ByVal NewCode As String, ByVal LocationID As String, ByVal Code As String, ByVal LocationName As String, ByVal AddressNo As String, ByVal Moo As String, ByVal Road As String, ByVal Subdistrict As String, ByVal District As String, ByVal ProvinceID As String, ByVal ZipCode As String, ByVal Tel As String, ByVal Email As String, ByVal LineID As String, ByVal WorkTime As String, ByVal Lat As String, ByVal Lng As String, ByVal Facebook As String, ByVal StartYear As Integer, ByVal LicenseNo1 As String, ByVal LicenseNo2 As String, ByVal LicenseNo3 As String, ByVal Licensee As String, ByVal LicenseeType As Integer, ByVal Area1 As Integer, ByVal Area2 As Double, ByVal LocationGroupUID As Integer, ByVal LocationChainUID As Integer, ByVal StatusFlag As String, ByVal Muser As String, IsAccPharm As String, ByVal NHSOCode As String, CertName1 As String, CertName2 As String, CertAddress As String, ByVal IsPPHealth As String, ByVal AuthPerson As String, Pharmacist As String, LicenseNo As String) As Integer

        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("Location_Update"), UID, NewCode, LocationID, Code, LocationName, AddressNo, Moo, Road, Subdistrict, District, ProvinceID, ZipCode, Tel, Email, LineID, WorkTime, Lat, Lng, Facebook, StartYear, LicenseNo1, LicenseNo2, LicenseNo3, Licensee, LicenseeType, Area1, Area2, LocationGroupUID, LocationChainUID, StatusFlag, Muser, IsAccPharm, NHSOCode, CertName1, CertName2, CertAddress, IsPPHealth, AuthPerson, Pharmacist, LicenseNo)
    End Function
    Public Function Location_UpdateByLocation(ByVal UID As Integer, ByVal LocationID As String, ByVal Code As String, ByVal LocationName As String, ByVal AddressNo As String, ByVal Moo As String, ByVal Road As String, ByVal Subdistrict As String, ByVal District As String, ByVal ProvinceID As String, ByVal ZipCode As String, ByVal Tel As String, ByVal Email As String, ByVal LineID As String, ByVal WorkTime As String, ByVal Lat As String, ByVal Lng As String, ByVal Facebook As String, ByVal StartYear As Integer, ByVal LicenseNo1 As String, ByVal LicenseNo2 As String, ByVal LicenseNo3 As String, ByVal Licensee As String, ByVal LicenseeType As Integer, ByVal Area1 As Integer, ByVal Area2 As Double, ByVal LocationGroupUID As Integer, ByVal LocationChainUID As Integer, ByVal StatusFlag As String, ByVal Muser As String) As Integer

        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("Location_UpdateByLocation"), UID, LocationID, Code, LocationName, AddressNo, Moo, Road, Subdistrict, District, ProvinceID, ZipCode, Tel, Email, LineID, WorkTime, Lat, Lng, Facebook, StartYear, LicenseNo1, LicenseNo2, LicenseNo3, Licensee, LicenseeType, Area1, Area2, LocationGroupUID, LocationChainUID, StatusFlag, Muser)
    End Function
    Public Function Location_UpdateIsSoftware(ByVal LocationUID As Integer, ByVal IsSoftware As String) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, "Location_UpdateIsSoftware", LocationUID, IsSoftware)
    End Function
    Public Function Location_UpdateNewCode(ByVal LocationUID As Integer, ByVal NewCode As String, Code As String) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, "Location_UpdateNewCode", LocationUID, NewCode, Code)
    End Function

    Public Function Location_UpdateLitigation(ByVal LocationUID As Integer, ByVal Desc As String) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, "Location_UpdateLitigation", LocationUID, Desc)
    End Function
    Public Function Location_GetLitigation(ByVal LocationUID As Integer) As String
        ds = SqlHelper.ExecuteDataset(ConnectionString, "Location_GetLitigation", LocationUID)
        Return String.Concat(ds.Tables(0).Rows(0)(0))
    End Function
    Public Function Location_UpdateAccStatus(ByVal LocationUID As Integer, ByVal AccStatus As String, ByVal AccLicense As String, ByVal StartDate As String, ByVal EndDate As String, BeginDate As String, Remark As String) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, "Location_UpdateAccStatus", LocationUID, AccStatus, AccLicense, StartDate, EndDate, BeginDate, Remark)
    End Function
    Public Function Location_UpdateRisk(ByVal LocationUID As Integer, ByVal Level As Integer, ByVal RiskDate As String, Remark As String) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, "Location_UpdateRisk", LocationUID, Level, RiskDate, Remark)
    End Function


    'Public Function Location_UpdateAccLicense(ByVal LocationUID As Integer, ByVal AccLicense As String) As Integer
    '    Return SqlHelper.ExecuteNonQuery(ConnectionString, "Location_UpdateAccLicense", LocationUID, AccLicense)
    'End Function
    Public Function Location_UpdateByUser(ByVal LocationID As String, ByVal LocationName As String, TypeShop As String, TypeName As String, ByVal Address As String, ByVal ZipCode As String, ByVal Office_Tel As String, ByVal Office_Fax As String, ByVal Co_Name As String, ByVal Co_Mail As String, ByVal Co_Tel As String, ByVal AccNo As String, ByVal AccName As String, ByVal BankID As String, ByVal BankBrunch As String, ByVal BankType As String, ByVal UpdBy As String, ByVal Office_Mail As String, CardID As String, RYear As String) As Integer

        Return SqlHelper.ExecuteNonQuery(ConnectionString, "Location_UpdateByUser", LocationID, LocationName, TypeShop, TypeName, Address, ZipCode, Office_Tel, Office_Fax, Co_Name, Co_Mail, Co_Tel, AccNo, AccName, BankID, BankBrunch, BankType, UpdBy, Office_Mail, CardID, RYear)

    End Function
    Public Function Location_UpdateForPPH(ByVal LicenseNo As String) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("Location_UpdateForPPH"), LicenseNo)
    End Function
    Public Function Location_SaveByImport(ByVal LicenseNo As String, ByVal LocationName As String, ByVal AddressNo As String, ByVal Moo As String, ByVal Road As String, ByVal Subdistrict As String, ByVal District As String, ByVal ProvinceID As String, ByVal ZipCode As String, ByVal Tel As String, ByVal Email As String, ByVal LicenseeType As Integer, ByVal Licensee As String, NHSOCode As String, ByVal CUser As String) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("Location_SaveByImport"), LicenseNo, LocationName, AddressNo, Moo, Road, Subdistrict, District, ProvinceID, ZipCode, Tel, Email, Licensee, LicenseeType, NHSOCode, CUser)
    End Function

    Public Function Pharmacy_Register(ByVal NewCode As String, ByVal LocationID As String, ByVal Code As String, ByVal Password As String, ByVal LocationName As String, ByVal AddressNo As String, ByVal Moo As String, ByVal Road As String, ByVal Subdistrict As String, ByVal District As String, ByVal ProvinceID As String, ByVal ZipCode As String, ByVal Tel As String, ByVal Email As String, ByVal LineID As String, ByVal WorkTime As String, ByVal Lat As String, ByVal Lng As String, ByVal Facebook As String, ByVal LicenseNo1 As String, ByVal LicenseNo2 As String, ByVal LicenseNo3 As String, ByVal Licensee As String, ByVal LicenseeType As Integer, ByVal Area1 As Integer, ByVal Area2 As Double, ByVal LocationGroupUID As Integer, ByVal LocationChainUID As Integer, ByVal Cuser As String, ByVal NHSOCode As String) As Integer

        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("Pharmacy_Add"), NewCode, LocationID, Code, Password, LocationName, AddressNo, Moo, Road, Subdistrict, District, ProvinceID, ZipCode, Tel, Email, LineID, WorkTime, Lat, Lng, Facebook, LicenseNo1, LicenseNo2, LicenseNo3, Licensee, LicenseeType, Area1, Area2, LocationGroupUID, LocationChainUID, Cuser, NHSOCode)
    End Function
    Public Function Pharmacy_Update(ByVal UID As Integer, ByVal NewCode As String, ByVal LocationID As String, ByVal Code As String, ByVal LocationName As String, ByVal AddressNo As String, ByVal Moo As String, ByVal Road As String, ByVal Subdistrict As String, ByVal District As String, ByVal ProvinceID As String, ByVal ZipCode As String, ByVal Tel As String, ByVal Email As String, ByVal LineID As String, ByVal WorkTime As String, ByVal Lat As String, ByVal Lng As String, ByVal Facebook As String, ByVal LicenseNo1 As String, ByVal LicenseNo2 As String, ByVal LicenseNo3 As String, ByVal Licensee As String, ByVal LicenseeType As Integer, ByVal Area1 As Integer, ByVal Area2 As Double, ByVal LocationGroupUID As Integer, ByVal LocationChainUID As Integer, ByVal StatusFlag As String, ByVal Muser As String, ByVal NHSOCode As String) As Integer

        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("Pharmacy_Update"), UID, NewCode, LocationID, Code, LocationName, AddressNo, Moo, Road, Subdistrict, District, ProvinceID, ZipCode, Tel, Email, LineID, WorkTime, Lat, Lng, Facebook, LicenseNo1, LicenseNo2, LicenseNo3, Licensee, LicenseeType, Area1, Area2, LocationGroupUID, LocationChainUID, StatusFlag, Muser, NHSOCode)
    End Function

    Public Function PhamacyLicense_Save(ByVal LocationUID As Integer, ByVal LicenseNo As String, ByVal NewCode As String, ByVal pvncd As String, ByVal lcnno_noo As String, ByVal lcnno_not_pvnabbr As String, ByVal licen As String, ByVal licen_time As String, ByVal grannm_lo As String, ByVal thanm As String, ByVal thaaddr As String, ByVal tharoom As String, ByVal thafloor As String, ByVal thabuilding As String, ByVal thasoi As String, ByVal tharoad As String, ByVal thamu As String, ByVal thathmblnm As String, ByVal zipcode As String, ByVal tel As String, ByVal thanm_address As String, ByVal thaamphrnm As String, ByVal thachngwtnm As String, ByVal ncnm As String, ByVal appdate As String, ByVal expyear As String, ByVal lmdfdate As String, ByVal Newcode_not As String, ByVal LICENSE_NO_SEARCH2 As String) As Integer

        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("PhamacyLicense_Save"), LocationUID, LicenseNo, NewCode, pvncd, lcnno_noo, lcnno_not_pvnabbr, licen, licen_time, grannm_lo, thanm, thaaddr, tharoom, thafloor, thabuilding, thasoi, tharoad, thamu, thathmblnm, zipcode, tel, thanm_address, thaamphrnm, thachngwtnm, ncnm, appdate, expyear, lmdfdate, Newcode_not, LICENSE_NO_SEARCH2)
    End Function
    Public Function PhamacyLicense_Update(ByVal NewCode As String, phrno As String, phrnm As String, pharmacy_name As String) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("PhamacyLicense_Update"), NewCode, phrno, phrnm, pharmacy_name)
    End Function
    Public Function PhamacyLicense_UpdateLicen(ByVal NewCode As String, ByVal licen As String) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("PhamacyLicense_UpdateLicen"), NewCode, licen)
    End Function

    Public Function auto_UpdatePharmacyName_Certificate() As Integer

        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("auto_UpdatePharmacyName_Certificate"))
    End Function
    Public Function Location_GetForWeb(PGroup As String, ProvinceID As String, Search As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Location_GetForWeb"), PGroup, ProvinceID, Search)
        Return ds.Tables(0)
    End Function
    'Public Function Location_GetBySearch4Print(Bdate As String, Edate As String, ProvinceID As String, isAccPharm As String, Search As String) As DataTable
    '    ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Location_GetBySearch4Print"), Bdate, Edate, ProvinceID, isAccPharm, Search)
    '    Return ds.Tables(0)
    'End Function
    Public Function Location_GetBySearch4Print(Bdate As String, Edate As String, AYear As String, StartNo As String, EndNo As String, ProvinceID As String, isAccPharm As String, Search As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Location_GetBySearch4Print"), Bdate, Edate, AYear, StartNo, EndNo, ProvinceID, isAccPharm, Search)
        Return ds.Tables(0)
    End Function



    Public Function Location_GetNotNewCode() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, "Location_GetNotNewCode")
        Return ds.Tables(0)
    End Function

#End Region
#Region "Business Hour"
    Public Function LocationHour_Get(ByVal LocationUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("LocationHour_Get"), LocationUID)
        Return ds.Tables(0)
    End Function
    Public Function LocationHour_GetByDay(iDayNo As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("LocationHour_GetByDay"), iDayNo)
        Return ds.Tables(0)
    End Function
    Public Function LocationHour_Save(ByVal LocationUID As Integer, ByVal DayNo As Integer, DayCode As String, OpenStatus As String, ByVal BeginTime As String, EndTime As String, MUser As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("LocationHour_Save"), LocationUID, DayNo, DayCode, OpenStatus, BeginTime, EndTime, MUser)
    End Function
    Public Function LocationHour_Delete(ByVal pID As String) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, "LocationHour_Delete", pID)
    End Function
    Public Function Location_GetNoHour() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, ("Location_GetNoHour"))
        Return ds.Tables(0)
    End Function

#End Region

#Region "CCR"
    Public Function LocationCCR_Get(LocationUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("LocationCCR_Get"), LocationUID)
        Return ds.Tables(0)
    End Function

    Public Function LocationCCR_GetUID(LocationUID As Integer) As Integer
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("LocationCCR_GetUID"), LocationUID)
        If ds.Tables(0).Rows.Count > 0 Then
            Return DBNull2Zero(ds.Tables(0).Rows(0)(0))
        Else
            Return 0
        End If
    End Function

    Public Function LocationCCR_Save(LocationUID As Integer, CCRDate As String, Desc As String, UpdBy As String) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("LocationCCR_Add"), LocationUID, CCRDate, Desc, UpdBy)
    End Function
    Public Function CCR_Delete(DocID As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, "LocationCCR_Delete", DocID)
    End Function
#End Region

#Region "Risk"
    Public Function LocationRisk_Get(LocationUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("LocationRisk_Get"), LocationUID)
        Return ds.Tables(0)
    End Function
    Public Function LocationRisk_Save(LocationUID As Integer, Level As Integer, RiskDate As String, Desc As String, UpdBy As String) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("LocationRisk_Add"), LocationUID, Level, RiskDate, Desc, UpdBy)
    End Function
    Public Function Risk_Delete(DocID As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, "LocationRisk_Delete", DocID)
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
    Public Function LocationType_GetActive() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("LocationType_GetActive"))
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

    Public Function LocationAllocate_GetByUser(AsmYear As Integer, UserID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("LocationAllocate_GetByUser"), AsmYear, UserID)
        Return ds.Tables(0)
    End Function
    Public Function LocationAllocate_GetByUserSearch(AsmYear As Integer, UserID As Integer, Search As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("LocationAllocate_GetByUserSearch"), AsmYear, UserID, Search)
        Return ds.Tables(0)
    End Function

    Public Function DatacollectorAllocate_GetByLocation(AsmYear As Integer, LocationUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("DatacollectorAllocate_GetByLocation"), AsmYear, LocationUID)
        Return ds.Tables(0)
    End Function
    Public Function DatacollectorAllocate_GetByLocationSearch(AsmYear As Integer, LocationUID As Integer, Search As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("DatacollectorAllocate_GetByLocationSearch"), AsmYear, LocationUID, Search)
        Return ds.Tables(0)
    End Function

    Public Function LocationAllocate_CheckPermission(AsmYear As Integer, UserID As Integer) As Boolean
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("LocationAllocate_CheckPermission"), AsmYear, UserID)
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


    Public Function LocationAllocate_GetByLocation(LocationUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("LocationAllocate_GetByLocation"), LocationUID)
        Return ds.Tables(0)
    End Function
    Public Function Location_GetNoAllocate(AsmYear As Integer, ProvID As String, UserID As Integer, Cond As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Location_GetNoAllocate"), AsmYear, ProvID, UserID, Cond)
        Return ds.Tables(0)
    End Function

    Public Function Location_GetNoAllocateSearch(AsmYear As Integer, ProvID As String, UserID As Integer, Cond As String, Search As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Location_GetNoAllocateSearch"), AsmYear, ProvID, UserID, Cond, Search)
        Return ds.Tables(0)
    End Function


    Public Function LocationAllocate_Add(ByVal AsmYear As Integer, ByVal UserID As Integer, ByVal LocationUID As Integer, ByVal MUser As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("LocationAllocate_Add"), AsmYear, UserID, LocationUID, MUser)
    End Function

    Public Function LocationAllocate_DeleteAll(ByVal UserID As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, "LocationAllocate_DeleteAll", UserID)
    End Function
    Public Function LocationAllocate_DeleteByLocation(ByVal LocationUID As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, "LocationAllocate_DeleteByLocation", LocationUID)
    End Function

    Public Function LocationAllocate_Delete(ByVal pID As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, "LocationAllocate_Delete", pID)
    End Function

#End Region


#Region "Warning"
    Public Function LocationWarning_Get(LocationUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("LocationWarning_Get"), LocationUID)
        Return ds.Tables(0)
    End Function
    Public Function LocationWarning_GetSEQ() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, ("LocationWarning_GetSEQ"))
        Return ds.Tables(0)
    End Function

    Public Function LocationWarning_GetForReport() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, ("LocationWarning_GetForReport"))
        Return ds.Tables(0)
    End Function
    Public Function LocationWarning_GetByAccForReport(IsAccPharm As String, ProvinceID As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, ("LocationWarning_GetByAccForReport"), IsAccPharm, ProvinceID)
        Return ds.Tables(0)
    End Function

    Public Function LocationWarning_GetUID(LocationUID As Integer) As Integer
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("LocationWarning_GetUID"), LocationUID)
        If ds.Tables(0).Rows.Count > 0 Then
            Return DBNull2Zero(ds.Tables(0).Rows(0)(0))
        Else
            Return 0
        End If
    End Function

    Public Function LocationWarning_Save(LocationUID As Integer, SeqNo As Integer, WarningDate As String, Subject As String, DocNo As String, Desc As String, Remark As String, UpdBy As String) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("LocationWarning_Add"), LocationUID, SeqNo, WarningDate, Subject, DocNo, Desc, Remark, UpdBy)
    End Function
    Public Function Warning_Delete(DocID As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, "LocationWarning_Delete", DocID)
    End Function

    Public Function LocationComplain_GetForReport(ProvinceID As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, ("LocationComplain_GetForReport"), ProvinceID)
        Return ds.Tables(0)
    End Function

#End Region


#Region "Post Audit"
    Public Function PostLocation_Get() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, "PostLocation_Get")
        Return ds.Tables(0)
    End Function
    Public Function PostLocation_GetBySupervisor(UserID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, "PostLocation_GetBySupervisor", UserID)
        Return ds.Tables(0)
    End Function



    Public Function LocationPostAllocate_GetByUser(AsmYear As Integer, UserID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("LocationPostAllocate_GetByUser"), AsmYear, UserID)
        Return ds.Tables(0)
    End Function
    Public Function LocationPostAllocate_GetByUserSearch(AsmYear As Integer, UserID As Integer, Search As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("LocationPostAllocate_GetByUserSearch"), AsmYear, UserID, Search)
        Return ds.Tables(0)
    End Function


    Public Function LocationPostAllocate_GetByLocation(LocationUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("LocationPostAllocate_GetByLocation"), LocationUID)
        Return ds.Tables(0)
    End Function

    Public Function Location_GetNoAllocatePost(AsmYear As Integer, ProvID As String, UserID As Integer, Cond As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Location_GetNoAllocatePost"), AsmYear, ProvID, UserID, Cond)
        Return ds.Tables(0)
    End Function

    Public Function Location_GetNoAllocatePostSearch(AsmYear As Integer, ProvID As String, UserID As Integer, Cond As String, Search As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Location_GetNoAllocatePostSearch"), AsmYear, ProvID, UserID, Cond, Search)
        Return ds.Tables(0)
    End Function

    Public Function LocationPostAllocate_Add(ByVal AsmYear As Integer, ByVal UserID As Integer, ByVal LocationUID As Integer, ByVal MUser As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("LocationPostAllocate_Add"), AsmYear, UserID, LocationUID, MUser)
    End Function

    Public Function LocationPostAllocate_DeleteAll(ByVal UserID As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, "LocationPostAllocate_DeleteAll", UserID)
    End Function
    Public Function LocationPostAllocate_DeleteByLocation(ByVal LocationUID As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, "LocationPostAllocate_DeleteByLocation", LocationUID)
    End Function

    Public Function LocationPostAllocate_Delete(ByVal pID As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, "LocationPostAllocate_Delete", pID)
    End Function

#End Region
End Class