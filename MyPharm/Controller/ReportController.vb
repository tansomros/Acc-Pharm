Imports Microsoft.ApplicationBlocks.Data

Public Class ReportController
    Inherits BaseClass
    Dim ds As New DataSet
#Region "Location"


    Public Function RPT_Location_ByAccStatus_ForChart() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("RPT_Location_ByAccStatus_ForChart"))
        Return ds.Tables(0)
    End Function

    Public Function RPT_Location_ByType1_ForChart() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("RPT_Location_ByType1_ForChart"))
        Return ds.Tables(0)
    End Function
    Public Function RPT_Location_ByType2_ForChart() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("RPT_Location_ByType2_ForChart"))
        Return ds.Tables(0)
    End Function
    Public Function RPT_Location_ByType3_ForChart() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("RPT_Location_ByType3_ForChart"))
        Return ds.Tables(0)
    End Function
    Public Function RPT_Location_ByType4_ForChart() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("RPT_Location_ByType4_ForChart"))
        Return ds.Tables(0)
    End Function
    Public Function RPT_Location_ByType5_ForChart() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("RPT_Location_ByType5_ForChart"))
        Return ds.Tables(0)
    End Function
    Public Function RPT_Location_ByType6_ForChart() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("RPT_Location_ByType6_ForChart"))
        Return ds.Tables(0)
    End Function
    Public Function RPT_Location_ByType7_ForChart() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("RPT_Location_ByType7_ForChart"))
        Return ds.Tables(0)
    End Function

    Public Function RPT_Location_GetBySearch(LGroup As String, LChain As String, LType As String, NHSO As String, PGroup As String, ProvinceID As String, AccStatus As String, Search As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Location_GetBySearch"), LGroup, LChain, LType, NHSO, PGroup, ProvinceID, AccStatus, Search)
        Return ds.Tables(0)
    End Function
    Public Function GEN_LocationReportBySearch(LGroup As String, LChain As String, LType As String, NHSO As String, PGroup As String, ProvinceID As String, AccStatus As String, Search As String, UserID As String) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("GEN_Location_GetBySearch"), LGroup, LChain, LType, NHSO, PGroup, ProvinceID, AccStatus, Search, UserID)

    End Function

    Public Function RPT_Request_GetByStatus(StartDate As String, EndDate As String, AsmStatus As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("RPT_Request_GetByStatus"), StartDate, EndDate, AsmStatus)
        Return ds.Tables(0)
    End Function
    Public Function RPT_Request_GetByType(StartDate As String, EndDate As String, AsmType As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("RPT_Request_GetByType"), StartDate, EndDate, AsmType)
        Return ds.Tables(0)
    End Function
    Public Function RPT_Assessment_GetScore(StartDate As String, EndDate As String, AsmType As String, AsmStatus As String, LocationUID As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("RPT_Assessment_GetScore"), StartDate, EndDate, AsmType, AsmStatus, LocationUID)
        Return ds.Tables(0)
    End Function
    Public Function RPT_Assessment_GetSWOT(StartDate As String, EndDate As String, AsmType As String, AsmStatus As String, LocationUID As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("RPT_Assessment_GetSWOT"), StartDate, EndDate, AsmType, AsmStatus, LocationUID)
        Return ds.Tables(0)
    End Function

    Public Function RPT_Location_GetQACountAll() As Integer
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("RPT_Location_GetQACountAll"))
        Return DBNull2Zero(ds.Tables(0).Rows(0)(0))
    End Function

    Public Function RPT_Location_GetCountByType() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("RPT_Location_GetCountByType"))
        Return ds.Tables(0)
    End Function
    Public Function RPT_Location_GetCountByProvinceGroup() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("RPT_Location_GetCountByProvinceGroup"))
        Return ds.Tables(0)
    End Function
    Public Function RPT_Location_GetCountByChainGroup() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("RPT_Location_GetCountByChainGroup"))
        Return ds.Tables(0)
    End Function

    Public Function RPT_Location_GetCountByNHSOGroup() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("RPT_Location_GetCountByNHSOGroup"))
        Return ds.Tables(0)
    End Function

    Public Function RPT_Location_GetCountByProvince() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("RPT_Location_GetCountByProvince"))
        Return ds.Tables(0)
    End Function

#End Region

#Region "ร้านยาสภาเภสัชกรรม"
    Public Function RPT_Pharmacy_ByAccStatus_ForChart() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("RPT_Pharmacy_ByAccStatus_ForChart"))
        Return ds.Tables(0)
    End Function
    Public Function RPT_Pharmacy_ByType1_ForChart() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("RPT_Pharmacy_ByType1_ForChart"))
        Return ds.Tables(0)
    End Function
    Public Function RPT_Pharmacy_ByType2_ForChart() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("RPT_Pharmacy_ByType2_ForChart"))
        Return ds.Tables(0)
    End Function
    Public Function RPT_Pharmacy_ByType3_ForChart() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("RPT_Pharmacy_ByType3_ForChart"))
        Return ds.Tables(0)
    End Function
    Public Function RPT_Pharmacy_ByType4_ForChart() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("RPT_Pharmacy_ByType4_ForChart"))
        Return ds.Tables(0)
    End Function
    Public Function RPT_Pharmacy_ByType5_ForChart() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("RPT_Pharmacy_ByType5_ForChart"))
        Return ds.Tables(0)
    End Function
    Public Function RPT_Pharmacy_ByType6_ForChart() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("RPT_Pharmacy_ByType6_ForChart"))
        Return ds.Tables(0)
    End Function
    Public Function RPT_Pharmacy_ByType7_ForChart() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("RPT_Pharmacy_ByType7_ForChart"))
        Return ds.Tables(0)
    End Function

    Public Function RPT_Pharmacy_GetBySearch(LGroup As String, LChain As String, LType As String, NHSO As String, PGroup As String, ProvinceID As String, AccStatus As String, Search As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Pharmacy_GetBySearch"), LGroup, LChain, LType, NHSO, PGroup, ProvinceID, AccStatus, Search)
        Return ds.Tables(0)
    End Function

    'Public Function RPT_Request_GetByStatus(StartDate As String, EndDate As String, AsmStatus As String) As DataTable
    '    ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("RPT_Request_GetByStatus"), StartDate, EndDate, AsmStatus)
    '    Return ds.Tables(0)
    'End Function
    'Public Function RPT_Request_GetByType(StartDate As String, EndDate As String, AsmType As String) As DataTable
    '    ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("RPT_Request_GetByType"), StartDate, EndDate, AsmType)
    '    Return ds.Tables(0)
    'End Function
    Public Function RPT_Pharmacy_GetCountAll() As Integer
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("RPT_Pharmacy_GetCountAll"))
        Return DBNull2Zero(ds.Tables(0).Rows(0)(0))
    End Function

    Public Function RPT_Pharmacy_GetCountByType() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("RPT_Pharmacy_GetCountByType"))
        Return ds.Tables(0)
    End Function
    Public Function RPT_Pharmacy_GetCountByProvinceGroup() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("RPT_Pharmacy_GetCountByProvinceGroup"))
        Return ds.Tables(0)
    End Function
    Public Function RPT_Pharmacy_GetCountByChainGroup() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("RPT_Pharmacy_GetCountByChainGroup"))
        Return ds.Tables(0)
    End Function

    Public Function RPT_Pharmacy_GetCountByNHSOGroup() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("RPT_Pharmacy_GetCountByNHSOGroup"))
        Return ds.Tables(0)
    End Function

    Public Function RPT_Pharmacy_GetCountByProvince() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("RPT_Pharmacy_GetCountByProvince"))
        Return ds.Tables(0)
    End Function

#End Region

End Class
