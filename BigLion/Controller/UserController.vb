﻿Imports Microsoft.ApplicationBlocks.Data

#Region "User"
Public Class UserController
    Inherits BaseClass
    Public ds As New DataSet
    Public Function User_Get() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("User_Get"))
        Return ds.Tables(0)
    End Function
    Public Function User_GetActive() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("User_GetActive"))
        Return ds.Tables(0)
    End Function
    Public Function Analyst_GetActive(CompanyUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Analyst_GetActive"), CompanyUID)
        Return ds.Tables(0)
    End Function
    Public Function Supervisor_Get() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Supervisor_Get"))
        Return ds.Tables(0)
    End Function
    Public Function Supervisor_GetActive() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Supervisor_GetActive"))
        Return ds.Tables(0)
    End Function
    Public Function User_GetComplainAdmin() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("User_GetComplainAdmin"))
        Return ds.Tables(0)
    End Function

    Public Function AssessmentStatus_Get() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("AssessmentStatus_Get"))
        Return ds.Tables(0)
    End Function
    Public Function User_GetPPH(ByVal UserID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("User_GetPPH"), UserID)
        Return ds.Tables(0)
    End Function

    Public Function User_CheckLogin(ByVal pUsername As String, ByVal pPassword As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("User_Login"), pUsername, pPassword)
        Return ds.Tables(0)
    End Function
    Public Function User_AcceptPolicy(ByVal UserID As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("User_AcceptPolicy"), UserID)
    End Function
    Public Function User_CheckPolicyAccept(ByVal UserID As Integer) As String
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("User_CheckPolicyAccept"), UserID)
        Return String.Concat(ds.Tables(0).Rows(0)(0))
    End Function

    Public Function User_AcceptPolicy1(ByVal UserID As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("User_AcceptPolicy1"), UserID)
    End Function
    Public Function User_CheckPolicyAccept1(ByVal UserID As Integer) As String
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("User_CheckPolicyAccept1"), UserID)
        Return String.Concat(ds.Tables(0).Rows(0)(0))
    End Function

    Public Function User_AcceptPolicy2(ByVal UserID As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("User_AcceptPolicy2"), UserID)
    End Function
    Public Function User_CheckPolicyAccept2(ByVal UserID As Integer) As String
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("User_CheckPolicyAccept2"), UserID)
        Return String.Concat(ds.Tables(0).Rows(0)(0))
    End Function

    Public Function User_GetNoAllocate(AsmYear As Integer, ProvID As String, LocationUID As Integer, Cond As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("User_GetNoAllocate"), AsmYear, ProvID, LocationUID, Cond)
        Return ds.Tables(0)
    End Function
    Public Function User_GetNoAllocateSearch(AsmYear As Integer, ProvID As String, LocationUID As Integer, Cond As String, Search As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("User_GetNoAllocateSearch"), AsmYear, ProvID, LocationUID, Cond, Search)
        Return ds.Tables(0)
    End Function


    Public Function User_SaveByUser(UserID As Integer, ByVal DisplayName As String, ByVal Tel As String, ByVal Email As String, MUser As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("User_SaveByUser"), UserID, DisplayName, Tel, Email, MUser)
    End Function

    Public Function User_UpdateFileName(ByVal UserID As Integer, fname As String) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, "User_UpdateFileName", UserID, fname)
    End Function

    Public Function User_IsApprover(ByVal pUserID As Integer) As Boolean
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("User_IsApprover"), pUserID)
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

    Public Function User_GetByUserID(ByVal UserID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("User_GetByUserID"), UserID)
        Return ds.Tables(0)
    End Function
    Public Function User_GetByUsername(ByVal Username As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("User_GetByUsername"), Username)
        Return ds.Tables(0)
    End Function
    Public Function User_GetEmailByUsername(ByVal Username As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("User_GetEmailByUsername"), Username)
        Return ds.Tables(0)
    End Function

    Public Function User_GetMainUserAdmin(ByVal CompanyUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("User_GetMainUserAdmin"), CompanyUID)
        Return ds.Tables(0)
    End Function

    Public Function User_GetUID(ByVal Username As String) As Integer
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("User_GetUID"), Username)
        If ds.Tables(0).Rows.Count > 0 Then
            Return DBNull2Zero(ds.Tables(0).Rows(0)(0))
        Else
            Return 0
        End If
    End Function
    Public Function Users_Online() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Users_Online"))
        Return ds.Tables(0)
    End Function
    Public Function User_GetUserRole(ByVal UserID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("User_GetUserRole"), UserID)
        Return ds.Tables(0)
    End Function
    Public Function User_GetForExport(Grp As Integer, id As String, UserID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, "User_GetForExport", Grp, id, UserID)
        Return ds.Tables(0)
    End Function
    Public Function User_GetBySearch(Grp As Integer, id As String, UserID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, "User_GetSearch", Grp, id, UserID)
        Return ds.Tables(0)
    End Function
    Public Function User_GetNameByUserID(ByVal userid As Integer) As String
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("User_GetNameByUserID"), userid)
        Return String.Concat(ds.Tables(0).Rows(0)(0))
    End Function

    Public Function User_GetNameByUsername(ByVal username As String) As String
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("User_GetNameByUsername"), username)
        Return String.Concat(ds.Tables(0).Rows(0)(0))
    End Function
    Public Function User_LastLog_Update(ByVal pUsername As String) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("User_LastLog_Update"), pUsername)
    End Function
    Public Function User_LastLog1_Update(ByVal pUsername As String) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("User_LastLog1_Update"), pUsername)
    End Function
    Public Function User_LastLog2_Update(ByVal pUsername As String) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("User_LastLog2_Update"), pUsername)
    End Function
    Public Function User_Delete(ByVal pID As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("User_Delete"), pID)
    End Function

    Public Function User_Save_Pharm(
           ByVal UserID As Integer,
           ByVal Username As String,
           ByVal Passwords As String,
           ByVal DisplayName As String,
           ByVal Email As String,
           ByVal Telephone As String,
           ByVal RoleID As Integer,
           ByVal LocationUID As Integer,
           ByVal StatusFlag As String,
           ByVal CUser As Integer, AdminAcc As String, AdminPharm As String, Reporter As String) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("User_Save_Pharm"), UserID, Username, Passwords, DisplayName, Email, Telephone, RoleID, LocationUID, StatusFlag, CUser, AdminAcc, AdminPharm, Reporter)

    End Function

    Public Function User_Save(
           ByVal UserID As Integer,
           ByVal Username As String,
           ByVal Passwords As String,
           ByVal DisplayName As String,
           ByVal Email As String,
           ByVal Telephone As String,
           ByVal RoleID As Integer,
           ByVal LocationUID As Integer,
           ByVal ProvinceID As String,
           ByVal StatusFlag As String,
           ByVal CUser As Integer, AdminAcc As String, AdminPharm As String, IsReporter As String, AdminComp As String) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("User_Save"), UserID, Username, Passwords, DisplayName, Email, Telephone, RoleID, LocationUID, ProvinceID, StatusFlag, CUser, AdminAcc, AdminPharm, IsReporter, AdminComp)
        ' สำหรับ สรร. สำหรับ add สสจ. ได้
    End Function

    Public Function UserMainAdmin_Add(
           ByVal Username As String,
           ByVal Password As String,
           ByVal FName As String,
           ByVal LName As String,
           ByVal Tel As String,
           ByVal Email As String,
           ByVal StatusFlag As String,
           ByVal CUser As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("UserMainAdmin_Add"), Username _
           , Password _
           , FName _
           , LName _
           , Tel _
           , Email _
           , StatusFlag _
           , CUser)

    End Function

    Public Function User_Update(ByVal Username As String, ByVal Password As String, ByVal FName As String, ByVal LName As String, ByVal Email As String, ByVal IsSuperUser As Integer, ByVal Status As Integer, ByVal UserProfileID As Integer, ByVal ProfileID As String) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("User_Update"), Username, Password, FName, LName, Email, IsSuperUser, Status, UserProfileID, ProfileID)
    End Function

    Public Function User_UpdateDatail(ByVal Username As String, ByVal Password As String, ByVal FName As String, ByVal LName As String, ByVal Email As String, ByVal IsSuperUser As Integer, ByVal Status As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("User_UpdateDatail"), Username, Password, FName, LName, Email, IsSuperUser, Status)
    End Function
    Public Function User_CheckDuplicate(ByVal pUser As String) As Boolean
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("User_GetByUsername"), pUser)
        If ds.Tables(0).Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Function User_CheckDuplicateCustomerAdmin(ByVal pUser As String) As Boolean
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("User_CheckDuplicateCustomerAdmin"), pUser)
        If ds.Tables(0).Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function


    Public Function UserCompany_GetByUserID(UserID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, "UserCompany_GetByUserID", UserID)
        Return ds.Tables(0)
    End Function
    Public Function UserCompany_GetByUsername(Username As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, "UserCompany_GetByUsername", Username)
        Return ds.Tables(0)
    End Function
    Public Function User_ChangeUsername(ByVal Username As String, ByVal Username2 As String) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("User_ChangeUsername"), Username, Username2)
    End Function

    Public Function Approver_Add(ByVal Username As String, ByVal RoleID As Integer, ByVal UpdBy As String) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("Approver_Add"), Username, RoleID, UpdBy)
    End Function
    Public Function Approver_Save(ByVal UserID As String, ByVal GroupUID As Integer, StatusFlag As String, ByVal UpdBy As String) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("UserAccessGroup_Save"), UserID, GroupUID, StatusFlag, UpdBy)
    End Function

    Public Function User_UpdateProfileID(ByVal Username As String, sProfileID As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("User_UpdateProfileID"), Username, sProfileID)
    End Function

    Public Function Approver_UpdateStatus(Username As String, RoleID As Integer, bActive As Integer, UpdBy As String) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("UserRole_UpdateStatus"), Username, RoleID, bActive, UpdBy)
    End Function

    Public Function User_ChangePassword(ByVal UserID As Integer, ByVal Password As String) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("User_ChangePassword"), UserID, Password)
    End Function

    Public Function User_GenLogfile(ByVal UserID As Integer, ByVal Act_Type As String, DB_Effective As String, Descrp As String, Remark As String, CompName As String, IPname As String) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("User_genLogfile"), UserID, Act_Type, DB_Effective, Descrp, Remark, CompName, IPname)
    End Function
    Public Function UserLogfile_UpdateByLicenseNo(ByVal LicenseNo As String) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("UserLogfile_UpdateByLicenseNo"), LicenseNo)
    End Function

    Public Function User_UpdateMail(ByVal Username As String, email As String) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("User_UpdateEmail"), Username, email)
    End Function
    Public Function UserCompany_Delete(ByVal UID As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("UserCompany_Delete"), UID)
    End Function
    Public Function UserCompany_Save(ByVal UserID As Integer, Username As String, CompanyUID As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("UserCompany_Save"), UserID, Username, CompanyUID)
    End Function


    Public Function SendAlert_Get() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("SendAlert_Get"))
        Return ds.Tables(0)
    End Function
    Public Function SendAlert_GetMail() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("SendAlert_GetMail"))
        Return ds.Tables(0)
    End Function

    Public Function SendAlert_Save(ByVal LocationID As Integer, TimePhaseID As Integer, email As String, Status As String) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("SendAlert_Save"), LocationID, TimePhaseID, email, Status)
    End Function
    Public Function SendAlert_UpdateStatus(ByVal LocationID As Integer, TimePhaseID As Integer, Status As String) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("SendAlert_UpdateStatus"), LocationID, TimePhaseID, Status)
    End Function
    Public Function AssessorTime_Get(ByVal UserID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("AssessorTime_Get"), UserID)
        Return ds.Tables(0)
    End Function
    Public Function AssessorTime_Add(ByVal UserID As Integer, ByVal StartDate As String, EndDate As String, PeriodTime As String, ByVal Remark As String) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("AssessorTime_Add"), UserID, StartDate, EndDate, PeriodTime, Remark)
    End Function
    Public Function AssessorTime_Delete(ByVal UID As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("AssessorTime_Delete"), UID)
    End Function
    Public Function AssessorTime_GetByDateAM(ByVal ActiveDate As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("AssessorTime_GetByDateAM"), ActiveDate)
        Return ds.Tables(0)
    End Function
    Public Function AssessorTime_GetByDatePM(ByVal ActiveDate As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("AssessorTime_GetByDatePM"), ActiveDate)
        Return ds.Tables(0)
    End Function
    Public Function AssessorTime_GetSchedule() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("AssessorTime_GetSchedule"))
        Return ds.Tables(0)
    End Function
    Public Function Supervisor_GetByProvince(ProvinceID As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Supervisor_GetByProvince"), ProvinceID)
        Return ds.Tables(0)
    End Function


    Public Function AssessorTravel_Get(ByVal UserID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("AssessorTravel_Get"), UserID)
        Return ds.Tables(0)
    End Function
    Public Function AssessorTravel_Add(ByVal UserID As Integer, ByVal StartDate As String, EndDate As String, PeriodTime As String, ByVal Remark As String) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("AssessorTravel_Add"), UserID, StartDate, EndDate, PeriodTime, Remark)
    End Function
    Public Function AssessorTravel_Delete(ByVal UID As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("AssessorTravel_Delete"), UID)
    End Function
    Public Function AssessorTravel_GetByDate(ByVal ActiveDate As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("AssessorTravel_GetByDate"), ActiveDate)
        Return ds.Tables(0)
    End Function

    Public Function AssessorTravel_GetSchedule() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("AssessorTravel_GetSchedule"))
        Return ds.Tables(0)
    End Function




    Public Function User_Get4AllocateProvince() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("User_Get4AllocateProvince"))
        Return ds.Tables(0)
    End Function
    Public Function Province_GetNoAllocate(UserID As String, Cond As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Province_GetNoAllocate"), UserID, Cond)
        Return ds.Tables(0)
    End Function
    Public Function Province_GetNoAllocateSearch(UserID As String, Cond As String, Search As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Province_GetNoAllocateSearch"), UserID, Cond, Search)
        Return ds.Tables(0)
    End Function
    Public Function ProvinceAllocate_GetByUser(UserID As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("ProvinceAllocate_GetByUser"), UserID)
        Return ds.Tables(0)
    End Function

    Public Function ProvinceAllocate_Get4ReportByUser(UserID As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("ProvinceAllocate_Get4ReportByUser"), UserID)
        Return ds.Tables(0)
    End Function
    Public Function ProvinceAllocate_GetByUserSearch(UserID As String, Search As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("ProvinceAllocate_GetByUserSearch"), UserID, Search)
        Return ds.Tables(0)
    End Function

    Public Function ProvinceAllocate_Add(ByVal UserID As Integer, ByVal ProvinceUID As Integer, ByVal MUser As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("ProvinceAllocate_Add"), UserID, ProvinceUID, MUser)
    End Function

    Public Function ProvinceAllocate_DeleteAll(ByVal UserID As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, "ProvinceAllocate_DeleteAll", UserID)
    End Function

    Public Function ProvinceAllocate_Delete(ByVal pID As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, "ProvinceAllocate_Delete", pID)
    End Function

End Class
Public Class UserRoleController
    Inherits BaseClass
    Public ds As New DataSet

    Public Function UserGroup_Get() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("UserGroup_Get"))
        Return ds.Tables(0)
    End Function


    Public Function UserAccessGroup_Get(ByVal pUserID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("UserAccessGroup_Get"), pUserID)
        Return ds.Tables(0)
    End Function

    Public Function UserRole_GetByUserID(ByVal pUserID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("UserRole_GetByUserID"), pUserID)
        Return ds.Tables(0)
    End Function

    Public Function UserRole_GetActiveRoleByUID(ByVal pUserID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("UserRole_GetActiveRoleByUID"), pUserID)
        Return ds.Tables(0)
    End Function

    Public Function UserAccessGroup_Save(ByVal UserID As String, ByVal GroupUID As Integer, StatusFlag As String, ByVal UpdBy As String) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("UserAccessGroup_Save"), UserID, GroupUID, StatusFlag, UpdBy)
    End Function

    Public Function UserAccessGroup_GetByUID(ByVal pUserID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("UserAccessGroup_GetByUID"), pUserID)
        Return ds.Tables(0)
    End Function

    Public Function UserAction_CheckByUser(ByVal pUser As String, ByVal pLocation As Integer) As Boolean
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("UserAction_CheckByUser"), pUser, pLocation)

        If ds.Tables(0).Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function UserAction_Checked(ByVal pUser As String, ByVal pLocation As Integer) As Boolean
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("UserAction_Checked"), pUser, pLocation)

        If ds.Tables(0).Rows.Count > 0 Then
            If ds.Tables(0).Rows(0)(0) = 1 Then
                Return True
            Else
                Return False
            End If
        Else
            Return False
        End If
    End Function

    Public Function UserAction_Add(ByVal Username As String, ByVal LocationID As Integer, ByVal RoleAction As Integer, ByVal UpdBy As String) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("UserAction_Add"), Username, LocationID, RoleAction, UpdBy)
    End Function



End Class

#End Region
#Region "Approver"
Public Class ApproverController
    Inherits BaseClass
    Public ds As New DataSet
    Public Function Approver_GetAll() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Approver_GetAll"))
        Return ds.Tables(0)
    End Function
    Public Function Approver_GetActive() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Approver_GetActive"))
        Return ds.Tables(0)
    End Function
    Public Function Approver_GetByUserID(ByVal pUserID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Approver_GetByUserID"), pUserID)
        Return ds.Tables(0)
    End Function

    Public Function Approver_GetByApproverUID(ByVal CustomerUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Approver_GetByApproverID"), CustomerUID)
        Return ds.Tables(0)
    End Function

    Public Function Approver_GetByCustomerUID(ByVal CustomerUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Approver_GetByCustomerUID"), CustomerUID)
        Return ds.Tables(0)
    End Function

    Public Function Approver_GetActiveRoleByUID(ByVal pUserID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Approver_GetActiveRoleByUID"), pUserID)
        Return ds.Tables(0)
    End Function

    Public Function UserAccessGroup_GetByUID(ByVal pUserID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("UserAccessGroup_GetByUID"), pUserID)
        Return ds.Tables(0)
    End Function

    Public Function UserAction_CheckByUser(ByVal pUser As String, ByVal pLocation As Integer) As Boolean
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("UserAction_CheckByUser"), pUser, pLocation)

        If ds.Tables(0).Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function Approver_Save(
           ByVal ApproverUID As Integer,
           ByVal Username As String,
           ByVal Password As String,
           ByVal FName As String,
           ByVal LName As String,
           ByVal Tel As String,
           ByVal Email As String,
           ByVal StatusFlag As String,
           ByVal CUser As Integer) As Integer

        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("Approver_Save"),
             ApproverUID _
           , Username _
           , Password _
           , FName _
           , LName _
           , Tel _
           , Email _
           , StatusFlag _
           , CUser)

    End Function
    Public Function Approver_GetApproverUID(ByVal Username As String, name As String) As String
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Approver_GetApproverUID"), Username, name)
        Return String.Concat(ds.Tables(0).Rows(0)(0))
    End Function


    Public Function ApproverCustomer_Save(ByVal ApproverUID As Integer, ByVal CustomerUID As Integer, ByVal Username As String, ByVal CUser As String) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("ApproverCustomer_Save"), ApproverUID, CustomerUID, Username, CUser)
    End Function
    Public Function ApproverCustomer_UpdateCustomerUID(ByVal Username As String, ByVal CustomerUID As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("ApproverCustomer_UpdateCustomerUID"), Username, CustomerUID)
    End Function
    Public Function ApproverCustomer_UpdateApproverUID(ByVal Username As String, ByVal ApproverUID As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("ApproverCustomer_UpdateApproverUID"), Username, ApproverUID)
    End Function

    Public Function ApproverCustomer_Delete(ByVal AUID As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("ApproverCustomer_Delete"), AUID)
    End Function




End Class
#End Region