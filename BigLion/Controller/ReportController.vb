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

    Public Function RPT_Location_ByType8_ForChart() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("RPT_Location_ByType8_ForChart"))
        Return ds.Tables(0)
    End Function
    Public Function RPT_Location_ByType9_ForChart() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("RPT_Location_ByType9_ForChart"))
        Return ds.Tables(0)
    End Function
    Public Function RPT_Location_ByType10_ForChart() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("RPT_Location_ByType10_ForChart"))
        Return ds.Tables(0)
    End Function
    Public Function RPT_Location_ByType11_ForChart() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("RPT_Location_ByType11_ForChart"))
        Return ds.Tables(0)
    End Function

    Public Function RPT_Location_GetBySearch(LGroup As String, LChain As String, LType As String, NHSO As String, PGroup As String, ProvinceID As String, isAccPharm As String, AccStatus As String, Search As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Location_GetBySearch"), LGroup, LChain, LType, NHSO, PGroup, ProvinceID, isAccPharm, AccStatus, Search)
        Return ds.Tables(0)
    End Function
    Public Function GEN_LocationReportBySearch(LGroup As String, LChain As String, LType As String, NHSO As String, PGroup As String, ProvinceID As String, isAccPharm As String, AccStatus As String, Search As String, UserID As String) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("GEN_Location_GetBySearch"), LGroup, LChain, LType, NHSO, PGroup, ProvinceID, isAccPharm, AccStatus, Search, UserID)
    End Function
    Public Function GEN_ComplainReport(StartDate As String, EndDate As String, ProjectUID As String, ProblemUID As String, CloseStatus As String, IsAccPharm As String, ProvinceID As String, LocationUID As String, Search As String, UserID As String) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("GEN_ComplainReport"), StartDate, EndDate, ProjectUID, ProblemUID, CloseStatus, IsAccPharm, ProvinceID, LocationUID, Search, UserID)
    End Function
    Public Function RPT_Request_GetByStatus(StartDate As String, EndDate As String, AsmStatus As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("RPT_Request_GetByStatus"), StartDate, EndDate, AsmStatus)
        Return ds.Tables(0)
    End Function
    Public Function RPT_Request_GetByType(StartDate As String, EndDate As String, AsmType As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("RPT_Request_GetByType"), StartDate, EndDate, AsmType)
        Return ds.Tables(0)
    End Function
    Public Function RPT_Request_GetByStatus(StartDate As String, EndDate As String, AsmStatus As String, SupervisorUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("RPT_Request_GetByStatusForSupervisor"), StartDate, EndDate, AsmStatus, SupervisorUID)
        Return ds.Tables(0)
    End Function
    Public Function RPT_Request_GetByType(StartDate As String, EndDate As String, AsmType As String, SupervisorUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("RPT_Request_GetByTypeForSupervisor"), StartDate, EndDate, AsmType, SupervisorUID)
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
    Public Function RPT_Assessment_GetScore(StartDate As String, EndDate As String, AsmType As String, AsmStatus As String, LocationUID As String, SupervisorUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("RPT_Assessment_GetScoreForSupervisor"), StartDate, EndDate, AsmType, AsmStatus, LocationUID, SupervisorUID)
        Return ds.Tables(0)
    End Function
    Public Function LocationWarning_GetSearch(StartDate As String, EndDate As String, SeqNo As String, sType As String, ProvinceID As String, IsAccPharm As String, LocationUID As String, Keyword As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("LocationWarning_GetSearch"), StartDate, EndDate, SeqNo, sType, ProvinceID, IsAccPharm, LocationUID, Keyword)
        Return ds.Tables(0)
    End Function
    Public Function RPT_LocationWarning_Get(StartDate As String, EndDate As String, SeqNo As String, sType As String, ProvinceID As String, IsAccPharm As String, LocationUID As String, Keyword As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("RPT_LocationWarning_Get"), StartDate, EndDate, SeqNo, sType, ProvinceID, IsAccPharm, LocationUID, Keyword)
        Return ds.Tables(0)
    End Function
    Public Function RPT_Assessment_GetSWOT(StartDate As String, EndDate As String, AsmType As String, AsmStatus As String, LocationUID As String, SupervisorUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("RPT_Assessment_GetSWOTForSupervisor"), StartDate, EndDate, AsmType, AsmStatus, LocationUID, SupervisorUID)
        Return ds.Tables(0)
    End Function

    Public Function RPT_Location_GetQACountAll() As Integer
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("RPT_Location_GetQACountAll"))
        Return DBNull2Zero(ds.Tables(0).Rows(0)(0))
    End Function
    Public Function RPT_Location_GetQACountTypeNull() As Integer
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("RPT_Location_GetQACountTypeNull"))
        Return DBNull2Zero(ds.Tables(0).Rows(0)(0))
    End Function

    Public Function RPT_Assessment_Performance(StartDate As String, EndDate As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("RPT_Assessment_Performance"), StartDate, EndDate)
        Return ds.Tables(0)
    End Function
    Public Function RPT_Assessment_Performance_ForChart(StartDate As String, EndDate As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("RPT_Assessment_Performance_ForChart"), StartDate, EndDate)
        Return ds.Tables(0)
    End Function

    Public Function RPT_Complain_Performance(StartDate As String, EndDate As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("RPT_Complain_Performance"), StartDate, EndDate)
        Return ds.Tables(0)
    End Function
    Public Function RPT_Complain_Performance_ForChart(StartDate As String, EndDate As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("RPT_Complain_Performance_ForChart"), StartDate, EndDate)
        Return ds.Tables(0)
    End Function

    Public Function RPT_User_Process(StartDate As String, EndDate As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("RPT_User_Process"), StartDate, EndDate)
        Return ds.Tables(0)
    End Function
    Public Function RPT_User_Process_ForChart(StartDate As String, EndDate As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("RPT_User_Process_ForChart"), StartDate, EndDate)
        Return ds.Tables(0)
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
    'Public Function GEN_TmpReports_Location_BySearch(ByVal pCode As String, StartDate As String, EndDate As String, ProvincID As String, AccStatus As String, Search As String, UserID As String) As Integer
    '    Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("GEN_TmpReports_Location_BySearch"), pCode, StartDate, EndDate, ProvincID, AccStatus, Search, UserID)
    'End Function
    Public Function GEN_TmpReports_Location_BySearch(ByVal pCode As String, StartDate As String, EndDate As String, AYear As String, StartNo As String, EndNo As String, ProvincID As String, AccStatus As String, Search As String, UserID As String) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("GEN_TmpReports_Location_BySearch"), pCode, StartDate, EndDate, AYear, StartNo, EndNo, ProvincID, AccStatus, Search, UserID)
    End Function
    Public Function GEN_TmpReports_Pharmacist_BySearch(ByVal pCode As String, CertType As String, ProvincID As String, Search As String, UserID As String) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("GEN_TmpReports_Pharmacist_BySearch"), pCode, CertType, ProvincID, Search, UserID)
    End Function

    Public Function TMP_Report_SET2CERT(ByVal sCode As String, sFormula As String, sUserID As String) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("TMP_Report_SET2CERT"), sCode, sFormula, sUserID)
    End Function
    Public Function TMP_Report_Pharmacist_SET2CERT(ByVal sCode As String, CertType As String, sFormula As String, sUserID As String) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("TMP_Report_Pharmacist_SET2CERT"), sCode, CertType, sFormula, sUserID)
    End Function


    Public Function GEN_LocationReportForPPH(LGroup As String, LChain As String, LType As String, NHSO As String, PGroup As String, ProvinceID As String, isAccPharm As String, AccStatus As String, Search As String, UserID As String) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("GEN_LocationReportForPPH"), LGroup, LChain, LType, NHSO, PGroup, ProvinceID, isAccPharm, AccStatus, Search, UserID)

    End Function
    Public Function GEN_GPPReportForPPH(AsmYear As String, PGroup As String, ProvinceID As String, AssessorID As String, Search As String, UserID As String) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("GEN_GPPReportForPPH"), AsmYear, PGroup, ProvinceID, AssessorID, Search, UserID)
    End Function

    Public Function GEN_LocationWarning_Report(StartDate As String, EndDate As String, SeqNo As String, sType As String, ProvinceID As String, IsAccPharm As String, LocationUID As String, Keyword As String, UserID As String) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("GEN_LocationWarning_Report"), StartDate, EndDate, SeqNo, sType, ProvinceID, IsAccPharm, LocationUID, Keyword, UserID)
    End Function

    Public Function GEN_PostReport(AsmYear As String, pType As String, PGroup As String, ProvinceID As String, AssessorID As String, Search As String, UserID As String) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("GEN_PostReport"), AsmYear, pType, PGroup, ProvinceID, AssessorID, Search, UserID)
    End Function

    Public Function GEN_GPPReportForAdminPPH(AsmYear As String, PGroup As String, ProvinceID As String, Search As String, UserID As String) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("GEN_GPPReportForAdminPPH"), AsmYear, PGroup, ProvinceID, Search, UserID)
    End Function

    Public Function RPT_Location_GetByAdminPPHSearch(LGroup As String, LChain As String, LType As String, NHSO As String, PGroup As String, ProvinceID As String, isAccPharm As String, AccStatus As String, Search As String, UserID As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Location_GetByAdminPPHSearch"), LGroup, LChain, LType, NHSO, PGroup, ProvinceID, isAccPharm, AccStatus, Search, UserID)
        Return ds.Tables(0)
    End Function

    Public Function RPT_Location_GetByPPHSearch(LGroup As String, LChain As String, LType As String, NHSO As String, PGroup As String, ProvinceID As String, isAccPharm As String, AccStatus As String, Search As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Location_GetByPPHSearch"), LGroup, LChain, LType, NHSO, PGroup, ProvinceID, isAccPharm, AccStatus, Search)
        Return ds.Tables(0)
    End Function
    Public Function RPT_GPP_GetByPPHSearch(AsmYear As String, PGroup As String, ProvinceID As String, UserID As String, Search As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("GPP_GetByPPHSearch"), AsmYear, PGroup, ProvinceID, UserID, Search)
        Return ds.Tables(0)
    End Function

    Public Function RPT_LocationRisk_Get(RiskYear As Integer, RiskLevel As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("RPT_LocationRisk_Get"), RiskYear, RiskLevel)
        Return ds.Tables(0)
    End Function


    Public Function RPT_PostAudit_GetBySearch(AsmYear As String, pType As String, PGroup As String, ProvinceID As String, UserID As String, Search As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("RPT_PostAudit_GetBySearch"), AsmYear, pType, PGroup, ProvinceID, UserID, Search)
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
