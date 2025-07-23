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
    Public Function Request_Save(ByVal UID As Long, ByVal Code As String, ByVal LocationUID As Integer, ByVal RequestType As Integer, ByVal Fname As String, ByVal Lname As String, ByVal Email As String, ByVal LineId As String, ByVal Tel As String, ByVal RequesterType As Integer, ByVal RequesterRemark As String, ByVal CUser As Integer) As Integer

        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("Request_Save"), UID, Code, LocationUID, RequestType, Fname, Lname, Email, LineId, Tel, RequesterType, RequesterRemark, CUser)
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

    Public Function Request_UpdateStatus(ByVal UID As Integer, RequestStatus As String, ByVal UpdBy As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("Request_UpdateStatus"), UID, RequestStatus, UpdBy)
    End Function

    Public Function RequestTransaction_Add(ByVal RequestUID As Integer, LocationUID As Integer, AsmStatus As String, Remark As String, ByVal UpdBy As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("RequestTransaction_Add"), RequestUID, LocationUID, AsmStatus, Remark, UpdBy)
    End Function

    Public Function Practice_Get(RequestUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Practice_Get"), RequestUID)
        Return ds.Tables(0)
    End Function
    Public Function Practice_GetForAssessment(RequestUID As Integer, UserID As Integer, PeriodID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Practice_GetForAssessment"), RequestUID, UserID, PeriodID)
        Return ds.Tables(0)
    End Function

    Public Function Practice_GetAssessmentResult(PeriodID As Integer, RequestUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Practice_GetAssessmentResult"), PeriodID, RequestUID)
        Return ds.Tables(0)
    End Function

    Public Function RequestAction_GetProgression(PeriodID As Integer, RequestUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("RequestAction_GetProgression"), PeriodID, RequestUID)
        Return ds.Tables(0)
    End Function

    Public Function Practice_GetByUID(UID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Practice_GetByUID"), UID)
        Return ds.Tables(0)
    End Function


    Public Function Practice_Delete(ByVal UID As Integer, RequestUID As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("Practice_Delete"), UID, RequestUID)
    End Function
    Public Function Practice_Save(ByVal UID As Integer, RequestUID As Integer, Code As String, Description As String, Recurrence As String) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("Practice_Save"), UID, RequestUID, Code, Description, Recurrence)
    End Function

    Public Function Practice_SaveByImport(RequestCode As String, PracticeCode As String, Description As String, Recurrence As String, CUser As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("Practice_SaveByImport"), RequestCode, PracticeCode, Description, Recurrence, CUser)
    End Function
    Public Function Practice_CheckDuplicate(RequestCode As String, Code As String) As Boolean
        ds = SqlHelper.ExecuteDataset(ConnectionString, "Practice_CheckDuplicate", RequestCode, Code)
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
    Public Function RequestType_Delete(ByVal RequestUID As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("RequestType_Delete"), RequestUID)
    End Function

    Public Function RequestType_Save(ByVal RequestUID As Integer, ByVal TypeUID As Integer, ByVal UpdBy As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("RequestType_Save"), RequestUID, TypeUID, UpdBy)
    End Function
    Public Function RequestType_GetByRequestUID(RequestUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("RequestType_GetByRequestUID"), RequestUID)
        Return ds.Tables(0)
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


#Region "Request Area"
    Public Function RequestArea_Delete(ByVal RequestUID As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("RequestArea_Delete"), RequestUID)
    End Function

    Public Function RequestArea_Save(ByVal RequestUID As Integer, ByVal AreaUID As Integer, ByVal UpdBy As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("RequestArea_Save"), RequestUID, AreaUID, UpdBy)
    End Function
    Public Function RequestArea_GetByRequestUID(RequestUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("RequestArea_GetByRequestUID"), RequestUID)
        Return ds.Tables(0)
    End Function

#End Region

#Region "Request FactoryType"
    Public Function RequestFactoryType_Delete(ByVal RequestUID As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("RequestFactoryType_Delete"), RequestUID)
    End Function

    Public Function RequestFactoryType_Save(ByVal RequestUID As Integer, ByVal FactoryTypeUID As Integer, ByVal UpdBy As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("RequestFactoryType_Save"), RequestUID, FactoryTypeUID, UpdBy)
    End Function
    Public Function RequestFactoryType_GetByRequestUID(RequestUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("RequestFactoryType_GetByRequestUID"), RequestUID)
        Return ds.Tables(0)
    End Function

#End Region

#Region "Request Keyword"
    Public Function RequestKeyword_Delete(ByVal RequestUID As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("RequestKeyword_Delete"), RequestUID)
    End Function

    Public Function RequestKeyword_Save(ByVal RequestUID As Integer, ByVal KeywordUID As Integer, ByVal UpdBy As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("RequestKeyword_Save"), RequestUID, KeywordUID, UpdBy)
    End Function
    Public Function RequestKeyword_GetByRequestUID(RequestUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("RequestKeyword_GetByRequestUID"), RequestUID)
        Return ds.Tables(0)
    End Function

#End Region

    Public Function Request_UpdateActivityQA(ByVal UID As Integer, ActivityQA As String) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("Request_UpdateActivityQA"), UID, ActivityQA)
    End Function

    Public Function Request_UpdateLicensee(ByVal RequestUID As Integer, ByVal Licensee_Old As String, ByVal Licensee_New As String, ByVal LicenseeType_Old As String, ByVal LicenseeType_New As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("Request_UpdateLicensee"), RequestUID, Licensee_Old, Licensee_New, LicenseeType_Old, LicenseeType_New)
    End Function

    Public Function Request_UpdateLocationName(ByVal RequestUID As Integer, ByVal LocationName_Old As String, ByVal LocationName_New As String) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("Request_UpdateLocationName"), RequestUID, LocationName_Old, LocationName_New)
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


#Region "Law Master"
    Public Function LawMaster_GetActive() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("LawMaster_GetActive"))
        Return ds.Tables(0)
    End Function
    Public Function LawMaster_GetBySearch(KeySearch As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("LawMaster_GetBySearch"), KeySearch)
        Return ds.Tables(0)
    End Function

    Public Function LawMaster_GetByUID(UID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("LawMaster_GetByUID"), UID)
        Return ds.Tables(0)
    End Function
    Public Function LawMaster_Delete(pID As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, "LawMaster_Delete", pID)
    End Function

    Public Function LawMaster_Save(UID As Integer, Name As String, Sort As Integer, StatusFlag As String) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, "LawMaster_Save", UID, Name, Sort, StatusFlag)
    End Function

#End Region

#Region "Law Type"

    Public Function LawType_Get() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("LawType_Get"))
        Return ds.Tables(0)
    End Function
    Public Function LawType_GetBySearch(KeySearch As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("LawType_GetBySearch"), KeySearch)
        Return ds.Tables(0)
    End Function

    Public Function LawType_Get4Select() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("LawType_Get4Select"))
        Return ds.Tables(0)
    End Function
    Public Function LawType_GetByRequestID(UID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("LawType_GetByRequestID"), UID)
        Return ds.Tables(0)
    End Function

    Public Function LawType_GetByUID(UID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("LawType_GetByUID"), UID)
        Return ds.Tables(0)
    End Function
    Public Function LawType_Delete(pID As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, "LawType_Delete", pID)
    End Function
    Public Function LawType_Save(UID As Integer, Name As String, Sort As Integer, StatusFlag As String) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, "LawType_Save", UID, Name, Sort, StatusFlag)
    End Function
#End Region

#Region "Law Category"
    Public Function LawCategory_GetByRequestID(UID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("LawCategory_GetByRequestID"), UID)
        Return ds.Tables(0)
    End Function
    Public Function LawCategory_GetBySearch(KeySearch As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("LawCategory_GetBySearch"), KeySearch)
        Return ds.Tables(0)
    End Function

    Public Function LawCategory_GetByUID(UID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("LawCategory_GetByUID"), UID)
        Return ds.Tables(0)
    End Function
    Public Function LawCategory_Delete(pID As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, "LawCategory_Delete", pID)
    End Function
    Public Function LawCategory_Save(UID As Integer, Name As String, Sort As Integer, StatusFlag As String) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, "LawCategory_Save", UID, Name, Sort, StatusFlag)
    End Function
#End Region

#Region "Law Release"
    Public Function LawRelease_Save(ByVal RequestUID As Integer, ByVal PracticeUID As Integer, CompanyUID As Integer, ByVal UserID As Integer, PeriodID As Integer, StatusFlag As String, ByVal UpdBy As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("LawRelease_Save"), RequestUID, PracticeUID, UserID, PeriodID, StatusFlag, UpdBy)
    End Function
    Public Function LawRelease_Delete(pID As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, "LawRelease_Delete", pID)
    End Function

#End Region

#Region "Law Action"
    Public Function RequestAction_GetByUID(pUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("RequestAction_GetByUID"), pUID)
        Return ds.Tables(0)
    End Function
    Public Function RequestAction_Save(ByVal UID As Integer, ByVal RequestUID As Integer, ByVal PracticeUID As Integer, CompanyUID As Integer, ByVal UserID As Integer, PeriodID As Integer, Descriptions As String, ByVal AsmResult As String, FilePath As String, MUser As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("RequestAction_Save"), UID _
           , RequestUID _
           , PracticeUID _
           , CompanyUID _
           , UserID _
           , PeriodID _
           , Descriptions _
           , AsmResult _
           , FilePath _
           , MUser)
    End Function

    Public Function RequestAction_UpdateActionStatus(ByVal UID As Integer, ApproveStatus As String, ActionStatus As String, Comment As String, ByVal UpdBy As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("RequestAction_UpdateActionStatus"), UID, ApproveStatus, ActionStatus, Comment, UpdBy)
    End Function
    Public Function RequestAction_UpdateApproveStatus(ByVal UID As Integer, ApproveStatus As String, ActionStatus As String, Comment As String, ByVal UpdBy As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("RequestAction_UpdateApproveStatus"), UID, ApproveStatus, ActionStatus, Comment, UpdBy)
    End Function

    Public Function RequestAction_GetForApproval(RequestUID As Integer, PeriodID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("RequestAction_GetForApproval"), RequestUID, PeriodID)
        Return ds.Tables(0)
    End Function
    Public Function RequestAction_GetByAsmStatus(CompanyUID As Integer, PeriodID As Integer, AsmStatus As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("RequestAction_GetByAsmStatus"), PeriodID, AsmStatus)
        Return ds.Tables(0)
    End Function

#End Region


#Region "Request Phase"
    Public Function RequestPhase_Delete(ByVal RequestUID As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("RequestPhase_Delete"), RequestUID)
    End Function

    Public Function RequestPhase_Save(ByVal RequestUID As Integer, ByVal PhaseUID As Integer, ByVal UpdBy As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("RequestPhase_Save"), RequestUID, PhaseUID, UpdBy)
    End Function
    Public Function RequestPhase_GetByRequestUID(RequestUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("RequestPhase_GetByRequestUID"), RequestUID)
        Return ds.Tables(0)
    End Function

#End Region


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
