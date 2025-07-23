Imports Microsoft.ApplicationBlocks.Data
Public Class RequestController
    Inherits BaseClass
    Public ds As New DataSet

#Region "Request"
    Public Function Request_Get() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Request_Get"))
        Return ds.Tables(0)
    End Function
    Public Function Request_GetByAdmin(StartDate As String, EndDate As String, ReqType As String, ReqStatus As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Request_GetByAdmin"), StartDate, EndDate, ReqType, ReqStatus)
        Return ds.Tables(0)
    End Function
    Public Function Request_GetBySuperAdmin(StartDate As String, EndDate As String, ReqType As String, ReqStatus As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Request_GetBySuperAdmin"), StartDate, EndDate, ReqType, ReqStatus)
        Return ds.Tables(0)
    End Function

    Public Function Request_GetByLocation(LocationUID As Integer, StartDate As String, EndDate As String, ReqType As String, ReqStatus As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Request_GetByLocation"), LocationUID, StartDate, EndDate, ReqType, ReqStatus)
        Return ds.Tables(0)
    End Function
    Public Function Request_GetBySupervisor(SupervisorUID As Integer, StartDate As String, EndDate As String, ReqType As String, ReqStatus As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Request_GetBySupervisor"), SupervisorUID, StartDate, EndDate, ReqType, ReqStatus)
        Return ds.Tables(0)
    End Function
    Public Function Request_GetActivityQA(RequestUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Request_GetActivityQA"), RequestUID)
        Return ds.Tables(0)
    End Function
    Public Function Request_GetLast() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Request_GetLast"))
        Return ds.Tables(0)
    End Function
    Public Function Request_GetStatusAlive(LocationUID As Integer) As Boolean
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Request_GetStatusAlive"), LocationUID)
        If ds.Tables(0).Rows.Count > 0 Then
            If ds.Tables(0).Rows(0)(0) > 0 Then
                Return True
            Else
                Return False
            End If
        Else
            Return False
        End If
    End Function

    Public Function Request_GetType(RequestUID As Integer) As Integer
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Request_GetType"), RequestUID)
        If ds.Tables(0).Rows.Count > 0 Then
            Return DBNull2Zero(ds.Tables(0).Rows(0)(0))
        Else
            Return 0
        End If
    End Function
    Public Function Request_GetByLawType(PhaseUID As String, TypeUID As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Request_GetByLawType"), PhaseUID, TypeUID)
        Return ds.Tables(0)
    End Function
    Public Function Request_GetByLawMaster(PhaseUID As String, MasterUID As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Request_GetByLawMaster"), PhaseUID, MasterUID)
        Return ds.Tables(0)
    End Function

    Public Function Request_GetByStatus(Status As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Request_GetByStatus"), Status)
        Return ds.Tables(0)
    End Function
    Public Function Request_GetByCompany(CompanyUID As Integer, PeriodID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Request_GetByCompany"), PeriodID)
        Return ds.Tables(0)
    End Function

    Public Function Request_GetForAssessment(CompanyUID As Integer, UserID As Integer, PeriodID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Request_GetForAssessment"), UserID, PeriodID)
        Return ds.Tables(0)
    End Function
    Public Function Request_GetForApproval(CompanyUID As Integer, UserID As Integer, PeriodID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Request_GetForApproval"), UserID, PeriodID)
        Return ds.Tables(0)
    End Function
    Public Function Request_GetByPhaseUID(PhaseUID As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Request_GetByPhaseUID"), PhaseUID)
        Return ds.Tables(0)
    End Function
    Public Function Request_GetByMinistryUID(PhaseUID As String, MinistryUID As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Request_GetByMinistryUID"), PhaseUID, MinistryUID)
        Return ds.Tables(0)
    End Function
    Public Function Request_GetByYear(PhaseUID As String, RequestYear As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Request_GetByYear"), PhaseUID, RequestYear)
        Return ds.Tables(0)
    End Function
    Public Function Request_GetByBusinessTypeUID(PhaseUID As String, BusinessTypeUID As String, FactoryTypeUID As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Request_GetByBusinessTypeUID"), PhaseUID, BusinessTypeUID, FactoryTypeUID)
        Return ds.Tables(0)
    End Function
    Public Function Request_GetByKeyword(PhaseUID As String, sKeyword As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Request_GetByKeyword"), PhaseUID, sKeyword)
        Return ds.Tables(0)
    End Function

    Public Function Request_GetByCompany(CompanyUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Request_GetByCompany"), CompanyUID)
        Return ds.Tables(0)
    End Function
    Public Function Request_GetByUser(UserID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Request_GetByUser"), UserID)
        Return ds.Tables(0)
    End Function
    Public Function Request_GetActive(CompanyUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Request_GetActive"), CompanyUID)
        Return ds.Tables(0)
    End Function

    Public Function RequestYear_Get() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("RequestYear_Get"))
        Return ds.Tables(0)
    End Function
    Public Function RequestYear_Get4Select() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("RequestYear_Get4Select"))
        Return ds.Tables(0)
    End Function
    Public Function Request_CheckDuplicate(Code As String) As Boolean
        ds = SqlHelper.ExecuteDataset(ConnectionString, "Request_CheckDuplicate", Code)
        If ds.Tables(0).Rows.Count > 0 Then
            If String.Concat(ds.Tables(0).Rows(0)(0)) <> "0" Then
                Return True
            Else
                Return False
            End If
        Else
            Return False
        End If
    End Function

    Public Function Request_GetByUID(pUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Request_GetByUID"), pUID)
        Return ds.Tables(0)
    End Function
    Public Function Request_GetDetail(pUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Request_GetDetail"), pUID)
        Return ds.Tables(0)
    End Function
    Public Function Request_Save(ByVal UID As Long, ByVal Code As String, ByVal LocationUID As Integer, ByVal RequestType As Integer, RequestSubType As Integer, ByVal Fname As String, ByVal Lname As String, ByVal Email As String, ByVal LineId As String, ByVal Tel As String, ByVal RequesterType As Integer, ByVal RequesterRemark As String, ByVal CUser As Integer) As Integer

        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("Request_Save"), UID, Code, LocationUID, RequestType, RequestSubType, Fname, Lname, Email, LineId, Tel, RequesterType, RequesterRemark, CUser)
    End Function
    Public Function RequestAssignment_get(ByVal RequestUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("RequestAssignment_Get"), RequestUID)
        Return ds.Tables(0)
    End Function
    Public Function Request_AddSupervisor(ByVal RequestUID As Integer, ByVal UserID As Integer, ByVal UpdBy As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("Request_AddSupervisor"), RequestUID, UserID, UpdBy)
    End Function

    Public Function RequestAssignment_Delete(ByVal UID As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("RequestAssignment_Delete"), UID)
    End Function

    Public Function Request_UpdateStatus(ByVal UID As Integer, RequestStatus As String, ByVal AuditType As String, ByVal UpdBy As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("Request_UpdateStatus"), UID, RequestStatus, AuditType, UpdBy)
    End Function

    Public Function RequestTransaction_Get(RequestUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("RequestTransaction_Get"), RequestUID)
        Return ds.Tables(0)
    End Function

    Public Function RequestTransaction_Add(ByVal RequestUID As Integer, LocationUID As Integer, AsmStatus As String, Remark As String, ByVal UpdBy As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("RequestTransaction_Add"), RequestUID, LocationUID, AsmStatus, Remark, UpdBy)
    End Function

    Public Function Request_GetUID(pCode As String) As Integer
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Request_GetUID"), pCode)
        If ds.Tables(0).Rows.Count > 0 Then
            Return DBNull2Zero(ds.Tables(0).Rows(0)(0))
        Else
            Return 0
        End If
    End Function
    Public Function Request_UpdateFile(ByVal UID As Integer, ByVal FilePath As String, ByVal CUser As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, ("Request_UpdateFile"), UID, FilePath, CUser)
    End Function
    Public Function Request_UpdateLocationAsmStatus(ByVal LocationUID As Integer, RequestUID As Long, AsmStatus As String) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, "Request_UpdateLocationAsmStatus", LocationUID, RequestUID, AsmStatus)
    End Function

    Public Function Request_UpdateGPPAsmStatus(ByVal LocationUID As Integer, RequestUID As Long, Score As Double, TotalScore As Double, Percentage As Double, AsmStatus As String, Comment As String, MUser As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, "Request_UpdateGPPAsmStatus", LocationUID, RequestUID, Score, TotalScore, Percentage, AsmStatus, Comment, MUser)
    End Function

#End Region

#Region "Request  Type"
    Public Function RequestType_Get() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("RequestType_Get"))
        Return ds.Tables(0)
    End Function
    Public Function RequestType_GetForReport() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("RequestType_GetForReport"))
        Return ds.Tables(0)
    End Function

    Public Function RequestTypeList_Add(ByVal RequestUID As Integer, ByVal TypeUID As Integer, ByVal UpdBy As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("RequestTypeList_Add"), RequestUID, TypeUID, UpdBy)
    End Function
    Public Function RequestTypeList_GetByRequestUID(RequestUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("RequestTypeList_GetByRequestUID"), RequestUID)
        Return ds.Tables(0)
    End Function

    Public Function RequestTypeList_Delete(ByVal RequestUID As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("RequestTypeList_Delete"), RequestUID)
    End Function


#End Region
#Region "Request Category Detail"
    Public Function RequestCategoryDetail_Delete(ByVal RequestUID As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("RequestCategoryDetail_Delete"), RequestUID)
    End Function

    Public Function RequestCategoryDetail_Save(ByVal RequestUID As Integer, ByVal CateUID As Integer, ByVal UpdBy As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("RequestCategoryDetail_Save"), RequestUID, CateUID, UpdBy)
    End Function
    Public Function RequestCategoryDetail_GetByRequestUID(RequestUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("RequestCategoryDetail_GetByRequestUID"), RequestUID)
        Return ds.Tables(0)
    End Function

#End Region


    Public Function Request_UpdateActivityQA(ByVal UID As Integer, ActivityQA As String) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("Request_UpdateActivityQA"), UID, ActivityQA)
    End Function
    Public Function Request_UpdatePharmacistLicense(ByVal RequestUID As Integer, ByVal Pharmacist_Old As String, ByVal Pharmacist_New As String, ByVal LicenseNO_Old As String, ByVal LicenseNo_New As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("Request_UpdatePharmacistLicense"), RequestUID, Pharmacist_Old, Pharmacist_New, LicenseNO_Old, LicenseNo_New)
    End Function
    Public Function Request_UpdatePharmacistNew(ByVal RequestUID As Integer, ByVal Pharmacist_New As String, ByVal LicenseNo_New As Integer, ByVal PharmacistTime_New As String) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("Request_UpdatePharmacistNew"), RequestUID, Pharmacist_New, LicenseNo_New, PharmacistTime_New)
    End Function
    Public Function Request_UpdateLicensee(ByVal RequestUID As Integer, ByVal Licensee_Old As String, ByVal Licensee_New As String, ByVal LicenseeType_Old As String, ByVal LicenseeType_New As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("Request_UpdateLicensee"), RequestUID, Licensee_Old, Licensee_New, LicenseeType_Old, LicenseeType_New)
    End Function
    Public Function Request_UpdateLocationName(ByVal RequestUID As Integer, ByVal LocationName_Old As String, ByVal LocationName_New As String) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("Request_UpdateLocationName"), RequestUID, LocationName_Old, LocationName_New)
    End Function
    Public Function Request_ChangeType(ByVal RequestUID As Integer, ByVal TypeID As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("Request_ChangeType"), RequestUID, TypeID)
    End Function

    Public Function Request_Cancel(ByVal UID As Integer, Remark As String) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("Request_Cancel"), UID, Remark)
    End Function
    Public Function Request_Delete(ByVal UID As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("Request_Delete"), UID)
    End Function

    Public Function Request_UpdateFileName(ByVal UID As Integer, ByVal LawNo As String, ByVal Name As String) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("Request_UpdateFileName"), UID, LawNo, Name)
    End Function

    Public Function RequestImage_Get(LawUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("RequestImage_Get"), LawUID)
        Return ds.Tables(0)
    End Function

    Public Function RequestImage_Delete(ByVal UID As Integer, ByVal LawNo As String, ByVal Name As String) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("RequestImage_Delete"), UID, LawNo, Name)
    End Function
    'Public Function Request_UpdateFileName(ByVal UID As Integer, ByVal LawNo As String, ByVal Name As String) As Integer
    '    Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("Request_UpdateFileName"), UID, LawNo, Name)
    'End Function


    Public Function RequestRelease_GetByRequest(CompanyUID As Integer, LawUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("RequestRelease_GetByRequest"), LawUID)
        Return ds.Tables(0)
    End Function

    Public Function RequestRelease_GetByUID(UID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("RequestRelease_GetByUID"), UID)
        Return ds.Tables(0)
    End Function

    Public Function RequestRelease_Save(ByVal UID As Integer, ByVal LawUID As Integer, ByVal PersonUID As Integer, CompanyUID As Integer, LevelID As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("RequestRelease_Save"), UID, LawUID, PersonUID, LevelID)
    End Function

    Public Function RequestRelease_Delete(ByVal UID As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("RequestRelease_Delete"), UID)
    End Function

    Public Function Request_Problem_Get(CompanyUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Request_Problem_Get"), CompanyUID)
        Return ds.Tables(0)
    End Function

    Public Function LawAction_Get(CompanyUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("LawAction_Get"), CompanyUID)
        Return ds.Tables(0)
    End Function

    Public Function LawOwner_GetEmailAlert(CompanyUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("LawOwner_GetEmailAlert"), CompanyUID)
        Return ds.Tables(0)
    End Function

    Public Function SendAlert_Save(LawUID As Integer, PersonUID As Integer, email As String, Status As String) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("SendAlert_Save"), LawUID, PersonUID, email, Status)
    End Function
    Public Function SendAlert_UpdateStatus(LawUID As Integer, PersonUID As Integer, Status As String) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("SendAlert_UpdateStatus"), LawUID, PersonUID, Status)
    End Function

    Public Function Request_Reject(PeriodID As Integer, ByVal RequestUID As Integer, ByVal Reason As String, ByVal CUser As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("Request_Reject"), PeriodID, RequestUID, Reason, CUser)
    End Function

    Public Function LawAction_GetByLawUID(pUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("LawAction_GetByLawUID"), pUID)
        Return ds.Tables(0)
    End Function

    Public Function LawAction_Save(ByVal UID As Integer, ByVal LawUID As Integer, ByVal ActionUID As String, ByVal OwnerUID As String, ByVal Duedate As String, ActionStatus As String, Comment As String) As Integer

        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("LawAction_Save"), UID, LawUID, ActionUID, OwnerUID, Duedate, ActionStatus, Comment)
    End Function

    Public Function Event_GetListByAdmin() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Event_GetListByAdmin"))
        Return ds.Tables(0)
    End Function
    Public Function Event_GetListByUser(ByVal LocationUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Event_GetListByUser"), LocationUID)
        Return ds.Tables(0)
    End Function
    Public Function Event_GetListBySupervisor(ByVal UserID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Event_GetListBySupervisor"), UserID)
        Return ds.Tables(0)
    End Function


    Public Function Event_GetByAdmin(ByVal UserID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Event_GetByAdmin"), UserID)
        Return ds.Tables(0)
    End Function
    Public Function Event_GetByUser(ByVal LocationUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Event_GetByUser"), LocationUID)
        Return ds.Tables(0)
    End Function
    Public Function Event_GetBySupervisor(ByVal UserID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Event_GetBySupervisor"), UserID)
        Return ds.Tables(0)
    End Function

    Public Function RPT_Request_Assessment(Bdate As Integer, Edate As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("RPT_Request_Assessment"), Bdate, Edate)
        Return ds.Tables(0)
    End Function


#Region "Request สภาเภสัชกรรม"
    Public Function PC_Request_Get() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("PC_Request_Get"))
        Return ds.Tables(0)
    End Function
    Public Function PC_Request_GetByAdmin(StartDate As String, EndDate As String, ReqType As String, ReqStatus As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("PC_Request_GetByAdmin"), StartDate, EndDate, ReqType, ReqStatus)
        Return ds.Tables(0)
    End Function
    Public Function PC_Request_GetBySuperAdmin(StartDate As String, EndDate As String, ReqType As String, ReqStatus As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("PC_Request_GetBySuperAdmin"), StartDate, EndDate, ReqType, ReqStatus)
        Return ds.Tables(0)
    End Function

    Public Function PC_Request_GetByLocation(LocationUID As Integer, StartDate As String, EndDate As String, ReqType As String, ReqStatus As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("PC_Request_GetByLocation"), LocationUID, StartDate, EndDate, ReqType, ReqStatus)
        Return ds.Tables(0)
    End Function
    Public Function PC_Request_GetBySupervisor(SupervisorUID As Integer, StartDate As String, EndDate As String, ReqType As String, ReqStatus As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("PC_Request_GetBySupervisor"), SupervisorUID, StartDate, EndDate, ReqType, ReqStatus)
        Return ds.Tables(0)
    End Function
    Public Function PC_Request_GetActivityQA(RequestUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("PC_Request_GetActivityQA"), RequestUID)
        Return ds.Tables(0)
    End Function
    Public Function PC_Request_GetLast() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("PC_Request_GetLast"))
        Return ds.Tables(0)
    End Function

    Public Function PC_Request_GetStatusAlive(LocationUID As Integer) As Boolean
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("PC_Request_GetStatusAlive"), LocationUID)
        If ds.Tables(0).Rows.Count > 0 Then
            If ds.Tables(0).Rows(0)(0) > 0 Then
                Return True
            Else
                Return False
            End If
        Else
            Return False
        End If
    End Function

    Public Function PC_Request_GetByLawType(PhaseUID As String, TypeUID As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("PC_Request_GetByLawType"), PhaseUID, TypeUID)
        Return ds.Tables(0)
    End Function
    Public Function PC_Request_GetByLawMaster(PhaseUID As String, MasterUID As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("PC_Request_GetByLawMaster"), PhaseUID, MasterUID)
        Return ds.Tables(0)
    End Function

    Public Function PC_Request_GetByStatus(Status As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("PC_Request_GetByStatus"), Status)
        Return ds.Tables(0)
    End Function
    Public Function PC_Request_GetByCompany(CompanyUID As Integer, PeriodID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("PC_Request_GetByCompany"), PeriodID)
        Return ds.Tables(0)
    End Function

    Public Function PC_Request_GetForAssessment(CompanyUID As Integer, UserID As Integer, PeriodID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("PC_Request_GetForAssessment"), UserID, PeriodID)
        Return ds.Tables(0)
    End Function
    Public Function PC_Request_GetForApproval(CompanyUID As Integer, UserID As Integer, PeriodID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("PC_Request_GetForApproval"), UserID, PeriodID)
        Return ds.Tables(0)
    End Function
    Public Function PC_Request_GetByPhaseUID(PhaseUID As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("PC_Request_GetByPhaseUID"), PhaseUID)
        Return ds.Tables(0)
    End Function
    Public Function PC_Request_GetByMinistryUID(PhaseUID As String, MinistryUID As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("PC_Request_GetByMinistryUID"), PhaseUID, MinistryUID)
        Return ds.Tables(0)
    End Function
    Public Function PC_Request_GetByYear(PhaseUID As String, RequestYear As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("PC_Request_GetByYear"), PhaseUID, RequestYear)
        Return ds.Tables(0)
    End Function
    Public Function PC_Request_GetByBusinessTypeUID(PhaseUID As String, BusinessTypeUID As String, FactoryTypeUID As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("PC_Request_GetByBusinessTypeUID"), PhaseUID, BusinessTypeUID, FactoryTypeUID)
        Return ds.Tables(0)
    End Function
    Public Function PC_Request_GetByKeyword(PhaseUID As String, sKeyword As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("PC_Request_GetByKeyword"), PhaseUID, sKeyword)
        Return ds.Tables(0)
    End Function

    Public Function PC_Request_GetByCompany(CompanyUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("PC_Request_GetByCompany"), CompanyUID)
        Return ds.Tables(0)
    End Function
    Public Function PC_Request_GetByUser(UserID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("PC_Request_GetByUser"), UserID)
        Return ds.Tables(0)
    End Function
    Public Function PC_Request_GetActive(CompanyUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("PC_Request_GetActive"), CompanyUID)
        Return ds.Tables(0)
    End Function

    Public Function PC_RequestYear_Get() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("PC_RequestYear_Get"))
        Return ds.Tables(0)
    End Function
    Public Function PC_RequestYear_Get4Select() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("PC_RequestYear_Get4Select"))
        Return ds.Tables(0)
    End Function
    Public Function PC_Request_CheckDuplicate(Code As String) As Boolean
        ds = SqlHelper.ExecuteDataset(ConnectionString, "PC_Request_CheckDuplicate", Code)
        If ds.Tables(0).Rows.Count > 0 Then
            If String.Concat(ds.Tables(0).Rows(0)(0)) <> "0" Then
                Return True
            Else
                Return False
            End If
        Else
            Return False
        End If
    End Function

    Public Function PC_Request_GetByUID(pUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("PC_Request_GetByUID"), pUID)
        Return ds.Tables(0)
    End Function
    Public Function PC_Request_GetDetail(pUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("PC_Request_GetDetail"), pUID)
        Return ds.Tables(0)
    End Function
    Public Function PC_Request_Save(ByVal UID As Long, ByVal Code As String, ByVal LocationUID As Integer, ByVal RequestType As Integer, ByVal Fname As String, ByVal Lname As String, ByVal Email As String, ByVal LineId As String, ByVal Tel As String, ByVal RequesterType As Integer, ByVal RequesterRemark As String, ByVal CUser As Integer) As Integer

        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("PC_Request_Save"), UID, Code, LocationUID, RequestType, Fname, Lname, Email, LineId, Tel, RequesterType, RequesterRemark, CUser)
    End Function

    Public Function PC_Request_UpdateStatus(ByVal UID As Integer, RequestStatus As String, ByVal UpdBy As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("PC_Request_UpdateStatus"), UID, RequestStatus, UpdBy)
    End Function

    Public Function PC_Request_GetUID(pCode As String) As Integer
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("PC_Request_GetUID"), pCode)
        If ds.Tables(0).Rows.Count > 0 Then
            Return DBNull2Zero(ds.Tables(0).Rows(0)(0))
        Else
            Return 0
        End If
    End Function
    Public Function PC_Request_UpdateFile(ByVal UID As Integer, ByVal FilePath As String, ByVal CUser As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, ("PC_Request_UpdateFile"), UID, FilePath, CUser)
    End Function
    Public Function PC_Request_UpdateLocationAsmStatus(ByVal LocationUID As Integer, RequestUID As Long, AsmStatus As String) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, "PC_Request_UpdateLocationAsmStatus", LocationUID, RequestUID, AsmStatus)
    End Function

    Public Function PC_Request_UpdateGPPAsmStatus(ByVal LocationUID As Integer, RequestUID As Long, Score As Double, TotalScore As Double, Percentage As Double, AsmStatus As String, Comment As String, MUser As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, "PC_Request_UpdateGPPAsmStatus", LocationUID, RequestUID, Score, TotalScore, Percentage, AsmStatus, Comment, MUser)
    End Function

#End Region

End Class
