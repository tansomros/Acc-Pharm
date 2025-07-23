Imports System
Imports System.Data
Imports Microsoft.ApplicationBlocks.Data
Public Class AssessmentController
    Inherits BaseClass
    Public ds As New DataSet

    Public Function Assessment_GetStatus(RequestUID As Long) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Assessment_GetStatus"), RequestUID)
        Return ds.Tables(0)
    End Function

    Public Function Assessment_Save(ByVal RequestUID As Long, ByVal LocationUID As Integer, ByVal MUser As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("Assessment_Save"), RequestUID, LocationUID, MUser)
    End Function

    Public Function Assessment_UpdateGPP(ByVal RequestUID As Long, ByVal LocationUID As Integer, ByVal GPP_Score As Double, ByVal GPP_TotalScore As Double, ByVal GPP_Percentage As Double, ByVal CUser As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("Assessment_UpdateGPP"), RequestUID, LocationUID, GPP_Score, GPP_TotalScore, GPP_Percentage, CUser)
    End Function
    Public Function Assessment_SaveQAScore(ByVal RequestUID As Long, ByVal LocationUID As Integer, ByVal QA_Score As Double, ByVal CUser As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("Assessment_UpdateGPP"), RequestUID, LocationUID, QA_Score, CUser)
    End Function
    Public Function Assessment_SendApprove(ByVal RequestUID As Long, ByVal LocationUID As Integer, ByVal CUser As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("Assessment_SendApprove"), RequestUID, LocationUID, CUser)
    End Function
    Public Function Assessment_SendApprove2(ByVal RequestUID As Long, ByVal LocationUID As Integer, ByVal CUser As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("Assessment_SendApprove2"), RequestUID, LocationUID, CUser)
    End Function
    Public Function GPP_Assessment_GetUID(RequestUID As Integer) As Long
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("GPP_Assessment_GetUID"), RequestUID)
        If ds.Tables(0).Rows.Count > 0 Then
            Return DBNull2Lng(ds.Tables(0).Rows(0)(0))
        Else
            Return 0
        End If
    End Function
    Public Function GPP_Assessment_GetUID(RequestUID As Integer, LocationUID As Integer, AsmYear As Integer) As Long
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("GPP_Assessment_PPH_GetUID"), RequestUID, LocationUID, AsmYear)
        If ds.Tables(0).Rows.Count > 0 Then
            Return DBNull2Lng(ds.Tables(0).Rows(0)(0))
        Else
            Return 0
        End If
    End Function
    Public Function Assessment_UpdateRemark(ByVal RequestUID As Long, ByVal LocationUID As Integer, ByVal AsmStatus As String, ByVal Comment As String, ByVal CUser As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("Assessment_UpdateRemark"), RequestUID, LocationUID, AsmStatus, Comment, CUser)
    End Function
    Public Function Assessment_Get() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Assessment_Get"))
        Return ds.Tables(0)
    End Function

    Public Function Assessment_GetByUID(Code As String, UID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Assessment_GetByUID"), Code, UID)
        Return ds.Tables(0)
    End Function
    Public Function Assessment_GetByRequestUID(ReqUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Assessment_GetByRequestUID"), ReqUID)
        Return ds.Tables(0)
    End Function
    Public Function Assessment_GetAsmYearByRequestUID(RequestUID As Integer) As Integer
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Assessment_GetAsmYearByRequestUID"), RequestUID)
        If ds.Tables(0).Rows.Count > 0 Then
            Return DBNull2Zero(ds.Tables(0).Rows(0)(0))
        Else
            Return 0
        End If
    End Function

    Public Function Assessment_UpdateResult(ByVal UID As Integer, ByVal Comment1 As String, ByVal Comment2 As String, ByVal Comment3 As String, ByVal Comment4 As String, ByVal Comment5 As String, ByVal S As String, ByVal W As String, ByVal O As String, ByVal T As String, ByVal Status As String, ByVal AppointmentDate As String, ByVal PassDate As String, ByVal DocumentNo As String, ByVal StartDate As String, ByVal ExpireDate As String, ByVal AsmRemark As String, ByVal AccRemark As String, ByVal CUser As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("Assessment_UpdateResult"), UID, Comment1, Comment2, Comment3, Comment4, Comment5, S, W, O, T, Status, AppointmentDate, PassDate, DocumentNo, StartDate, ExpireDate, AsmRemark, AccRemark, CUser)
    End Function

    Public Function Assessment_GetByLocation(LocationUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Assessment_GetByLocation"), LocationUID)
        Return ds.Tables(0)
    End Function

#Region "GPP"
    Public Function GPP_Assessment_GetByUID(GPPUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("GPP_Assessment_GetByUID"), GPPUID)
        Return ds.Tables(0)
    End Function
    Public Function GPP_Assessment_GetByLocation(LocationUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("GPP_Assessment_GetByLocation"), LocationUID)
        Return ds.Tables(0)
    End Function
    Public Function GPP_Assessment_GetByRequestUID(RequestUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("GPP_Assessment_GetByRequestUID"), RequestUID)
        Return ds.Tables(0)
    End Function
    Public Function GPP_Assessment_Save(ByVal UID As Integer, ByVal RequestUID As Integer, ByVal AsmYear As Integer, ByVal LocationUID As Integer, ByVal TotalScore As Double, ByVal FinalScore As Double, ByVal PercentScore As Double, ByVal FinalResult As String, ByVal Remark As String, MUser As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("GPP_Assessment_Save"), UID, RequestUID, AsmYear, LocationUID, TotalScore, FinalScore, PercentScore, FinalResult, Remark, MUser)
    End Function
    Public Function GPP_Assessment_Save(ByVal UID As Integer, ByVal RequestUID As Integer, ByVal AsmYear As Integer, ByVal LocationUID As Integer, ByVal TotalScore As Double, ByVal FinalScore As Double, ByVal PercentScore As Double, ByVal FinalResult As String, ByVal Remark1 As String, ByVal Remark2 As String, ByVal Remark3 As String, ByVal Remark4 As String, ByVal Remark5 As String, ByVal Remark As String, MUser As Integer, PercentGroup1 As Double, PercentGroup2 As Double, PercentGroup3 As Double, PercentGroup4 As Double, PercentGroup5 As Double, RiskRemark As String) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("GPP_Assessment_PPH_Save"), UID, RequestUID, AsmYear, LocationUID, TotalScore, FinalScore, PercentScore, FinalResult, Remark1, Remark2, Remark3, Remark4, Remark5, Remark, MUser, PercentGroup1, PercentGroup2, PercentGroup3, PercentGroup4, PercentGroup5, RiskRemark)
    End Function
    Public Function GPP_AssessmentScore_Save(ByVal GPP_Assessment_UID As Integer, ByVal ItemUID As Integer, ByVal Score As Double, ByVal WeightScore As Double, ByVal NetScore As Double, ByVal Muser As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("GPP_AssessmentScore_Save"), GPP_Assessment_UID, ItemUID, Score, WeightScore, NetScore, Muser)
    End Function
    Public Function GPP_AssessmentScore_SavePPH(ByVal GPP_Assessment_UID As Integer, ByVal ItemUID As Integer, ByVal Score As Double, ByVal WeightScore As Double, ByVal NetScore As Double, ByVal Remark As String, ByVal Muser As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("GPP_AssessmentScore_SavePPH"), GPP_Assessment_UID, ItemUID, Score, WeightScore, NetScore, Remark, Muser)
    End Function

    Public Function GPP_AssessmentScore_Get(GPPUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("GPP_AssessmentScore_Get"), GPPUID)
        Return ds.Tables(0)
    End Function

    '------- สสจ ----------------
    Public Function GPP_GetByLocation(LocationUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("GPP_GetByLocation"), LocationUID)
        Return ds.Tables(0)
    End Function
    Public Function GPP_GetByLocationDC(LocationUID As Integer, UserID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("GPP_GetByLocationDC"), LocationUID, UserID)
        Return ds.Tables(0)
    End Function
    Public Function GPP_GetByYearPPH(LocationUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("GPP_GetByYearPPH"), LocationUID)
        Return ds.Tables(0)
    End Function
    Public Function GPP_GetByYearProvince(AsmYear As Integer, ProvinceID As Integer, UserID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("GPP_GetByYearProvince"), AsmYear, ProvinceID, UserID)
        Return ds.Tables(0)
    End Function
    Public Function GPP_Assessment_Close(ByVal UID As Integer, ByVal CUser As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("GPP_Assessment_Close"), UID, CUser)
    End Function
    Public Function GPP_Assessment_Delete(ByVal UID As Integer, ByVal CUser As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("GPP_Assessment_Delete"), UID, CUser)
    End Function
    Public Function GPP_Assessment_Open(ByVal UID As Integer, ByVal CUser As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("GPP_Assessment_Open"), UID, CUser)
    End Function
    Public Function GPP_GetForClose(AsmYear As String, PGroup As String, ProvinceID As String, Search As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("GPP_GetForClose"), AsmYear, PGroup, ProvinceID, Search)
        Return ds.Tables(0)
    End Function
    Public Function GPP_CloseBySearch(AsmYear As String, PGroup As String, ProvinceID As String, Search As String, UserID As String) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("GPP_CloseBySearch"), AsmYear, PGroup, ProvinceID, Search, UserID)
    End Function

    Public Function RPT_GPP_Picture(GPPUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("RPT_GPP_Picture"), GPPUID)
        Return ds.Tables(0)
    End Function
    Public Function RPT_GPP_Critical(GPPUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("RPT_GPP_Critical"), GPPUID)
        Return ds.Tables(0)
    End Function
    Public Function RPT_Assessor(GPPUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("RPT_Assessor"), GPPUID)
        Return ds.Tables(0)
    End Function
    Public Function RPT_AssessorByLocation(LocationUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("RPT_AssessorByLocation"), LocationUID)
        Return ds.Tables(0)
    End Function
    Public Function GPPRisk_Get(GPPUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("GPPRisk_Get"), GPPUID)
        Return ds.Tables(0)
    End Function
    Public Function GPPRisk_Add(GPPUID As Integer, RiskCode As String, UserID As String) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("GPPRisk_Add"), GPPUID, RiskCode, UserID)
    End Function
    Public Function GPPRisk_Delete(GPPUID As Integer, RiskCode As String) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("GPPRisk_Delete"), GPPUID, RiskCode)
    End Function
#End Region
#Region "QA"
    Public Function QA_Assessment_GetByRequestUID(RequestUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("QA_Assessment_GetByRequestUID"), RequestUID)
        Return ds.Tables(0)
    End Function

    Public Function QA_Assessment_Save(ByVal UID As Integer, ByVal RequestUID As Integer, ByVal AsmYear As Integer, ByVal LocationUID As Integer, ByVal Risk1 As String, ByVal Risk2 As String, ByVal Risk3 As String, ByVal Risk4 As String, ByVal Risk5 As String, ByVal Risk6 As String, ByVal Risk7 As String, ByVal Risk8 As String, ByVal Risk9 As String, ByVal Risk10 As String, ByVal Telepharmacy As String, ByVal TeleTools As String, ByVal ToolsOther As String, ByVal Q2 As String, ByVal Q3 As String, ByVal Q4 As String, ByVal Q5 As String, ByVal MUser As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("QA_Assessment_Save"), UID, RequestUID, AsmYear, LocationUID, Risk1, Risk2, Risk3, Risk4, Risk5, Risk6, Risk7, Risk8, Risk9, Risk10, Telepharmacy, TeleTools, ToolsOther, Q2, Q3, Q4, Q5, MUser)
    End Function
    Public Function QA_Assessment_Save2(ByVal UID As Integer, ByVal RequestUID As Integer, ByVal AsmYear As Integer, ByVal LocationUID As Integer, ByVal Risk1 As String, ByVal Risk2 As String, ByVal Risk3 As String, ByVal Risk4 As String, ByVal Risk5 As String, ByVal Risk6 As String, ByVal Risk7 As String, ByVal Risk8 As String, ByVal Risk9 As String, ByVal Risk10 As String, ByVal Telepharmacy As String, ByVal TeleTools As String, ByVal ToolsOther As String, ByVal Q2 As String, ByVal Q3 As String, ByVal Q4 As String, ByVal Q5 As String, ByVal Q6 As String, ByVal MUser As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("QA_Assessment_Save2"), UID, RequestUID, AsmYear, LocationUID, Risk1, Risk2, Risk3, Risk4, Risk5, Risk6, Risk7, Risk8, Risk9, Risk10, Telepharmacy, TeleTools, ToolsOther, Q2, Q3, Q4, Q5, Q6, MUser)
    End Function

    Public Function QA_AssessmentScore_Save(ByVal QA_Assessment_UID As Long, ByVal RequestUID As Long, ByVal Score1 As Double, ByVal AuditorComment1 As String, ByVal Score2 As Double, ByVal AuditorComment2 As String, ByVal Score3 As Double, ByVal AuditorComment3 As String, ByVal AsmStatus As String, ByVal Muser As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("QA_AssessmentScore_Save"), QA_Assessment_UID, RequestUID, Score1, AuditorComment1, Score2, AuditorComment2, Score3, AuditorComment3, AsmStatus, Muser)
    End Function

    Public Function QA_AssessmentScore_Get(QAUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("QA_AssessmentScore_Get"), QAUID)
        Return ds.Tables(0)
    End Function


#End Region


#Region "Self"
    Public Function Self_Assessment_GetByRequestUID(RequestUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Self_Assessment_GetByRequestUID"), RequestUID)
        Return ds.Tables(0)
    End Function

    Public Function Self_Assessment_Save(ByVal UID As Integer, ByVal RequestUID As Integer, ByVal AsmYear As Integer, ByVal LocationUID As Integer, ByVal Risk1 As String, ByVal Risk2 As String, ByVal Risk3 As String, ByVal Risk4 As String, ByVal Risk5 As String, ByVal Risk6 As String, ByVal Risk7 As String, ByVal Risk8 As String, ByVal Risk9 As String, ByVal Risk10 As String, ByVal Telepharmacy As String, ByVal TeleTools As String, ByVal ToolsOther As String, ByVal Q2 As String, ByVal Q3 As String, ByVal Q4 As String, ByVal Q5 As String, ByVal MUser As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("Self_Assessment_Save"), UID, RequestUID, AsmYear, LocationUID, Risk1, Risk2, Risk3, Risk4, Risk5, Risk6, Risk7, Risk8, Risk9, Risk10, Telepharmacy, TeleTools, ToolsOther, Q2, Q3, Q4, Q5, MUser)
    End Function
    Public Function Self_Assessment_Save2(ByVal UID As Integer, ByVal RequestUID As Integer, ByVal AsmYear As Integer, ByVal LocationUID As Integer, ByVal Risk1 As String, ByVal Risk2 As String, ByVal Risk3 As String, ByVal Risk4 As String, ByVal Risk5 As String, ByVal Risk6 As String, ByVal Risk7 As String, ByVal Risk8 As String, ByVal Risk9 As String, ByVal Risk10 As String, ByVal Telepharmacy As String, ByVal TeleTools As String, ByVal ToolsOther As String, ByVal Q2 As String, ByVal Q3 As String, ByVal Q4 As String, ByVal Q5 As String, ByVal Q6 As String, ByVal MUser As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("Self_Assessment_Save2"), UID, RequestUID, AsmYear, LocationUID, Risk1, Risk2, Risk3, Risk4, Risk5, Risk6, Risk7, Risk8, Risk9, Risk10, Telepharmacy, TeleTools, ToolsOther, Q2, Q3, Q4, Q5, Q6, MUser)
    End Function

    Public Function Self_AssessmentScore_Save(ByVal Self_Assessment_UID As Long, ByVal RequestUID As Long, ByVal Score1 As Double, ByVal AuditorComment1 As String, ByVal Score2 As Double, ByVal AuditorComment2 As String, ByVal Score3 As Double, ByVal AuditorComment3 As String, ByVal AsmStatus As String, ByVal Muser As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("Self_AssessmentScore_Save"), Self_Assessment_UID, RequestUID, Score1, AuditorComment1, Score2, AuditorComment2, Score3, AuditorComment3, AsmStatus, Muser)
    End Function

    Public Function Self_AssessmentScore_Get(SelfUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Self_AssessmentScore_Get"), SelfUID)
        Return ds.Tables(0)
    End Function


#End Region


#Region "Post Audit"
    Public Function PostAudit_GetByUID(UID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("PostAudit_GetByUID"), UID)
        Return ds.Tables(0)
    End Function
    Public Function PostAudit_Save(ByVal UID As Integer, ByVal Code As String, ByVal LocationUID As Integer, ByVal Pharmacist As String, ByVal Position As String, ByVal AssessmentUID As Integer, ByVal AsmDate As String, ByVal AsmMethod As String, ByVal CUser As Integer, IsQA As String, IsCI As String) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("PostAudit_Save"), UID, Code, LocationUID, Pharmacist, Position, AssessmentUID, AsmDate, AsmMethod, CUser, IsQA, IsCI)
    End Function
    Public Function PostAudit_Update(ByVal UID As Integer, ByVal LocationUID As Integer, ByVal Pharmacist As String, ByVal Position As String, ByVal AssessmentUID As Integer, ByVal AsmDate As String, ByVal AsmMethod As String, QA1 As String, QA2 As String, QA3 As String, QA4 As String, QA5 As String, QAResult As String, QARemark As String, QAInformDate As String, QAResponseDate As String, QAComplete As String, QAClose As String, QACloseDate As String, QACloseRemark As String, CI1 As String, CI2 As String, CI3 As String, CI4 As String, CI5 As String, CI6 As String, CI7 As String, CI8 As String, CI9 As String, CI10 As String, CI11 As String, CI12 As String, CIOther As String, CI1Remark As String, CI2Remark As String, CI3Remark As String, CI4Remark As String, CI5Remark As String, CI6Remark As String, CI7Remark As String, CI8Remark As String, CI9Remark As String, CI10Remark As String, CI11Remark As String, CI12Remark As String, CISatisfaction As String, CIResult As String, CIRemark As String, CIInformDate As String, CIResponseDate As String, CIComplete As String, CIClose As String, CICloseDate As String, CICloseRemark As String, ByVal CUser As Integer, IsQA As String, IsCI As String) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("PostAudit_Update"), UID, LocationUID, Pharmacist, Position, AssessmentUID, AsmDate, AsmMethod, QA1, QA2, QA3, QA4, QA5, QAResult, QARemark, QAInformDate, QAResponseDate, QAComplete, QAClose, QACloseDate, QACloseRemark, CI1, CI2, CI3, CI4, CI5, CI6, CI7, CI8, CI9, CI10, CI11, CI12, CIOther, CI1Remark, CI2Remark, CI3Remark, CI4Remark, CI5Remark, CI6Remark, CI7Remark, CI8Remark, CI9Remark, CI10Remark, CI11Remark, CI12Remark, CISatisfaction, CIResult, CIRemark, CIInformDate, CIResponseDate, CIComplete, CIClose, CICloseDate, CICloseRemark, CUser, IsQA, IsCI)
    End Function

    Public Function PostAudit_Delete(ByVal UID As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("PostAudit_Delete"), UID)
    End Function

    Public Function PostAudit_GetUID(ByVal LocationUID As Integer, ByVal AssessmentUID As Integer, ByVal AsmDate As String) As Integer
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("PostAudit_GetUID"), LocationUID, AssessmentUID, AsmDate)
        If ds.Tables(0).Rows.Count > 0 Then
            Return DBNull2Zero(ds.Tables(0).Rows(0)(0))
        Else
            Return 0
        End If
    End Function
    Public Function QAStandard_Save(ByVal UID As Integer, ByVal PostAuditUID As Integer, ByVal QANO As Integer, ByVal Descriptions As String) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("QAStandard_Save"), UID, PostAuditUID, QANO, Descriptions)
    End Function


    Public Function QAStandard_GetLastUID(ByVal PostUID As Integer, ByVal QANO As Integer) As Integer
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("QAStandard_GetLastUID"), PostUID, QANO)
        If ds.Tables(0).Rows.Count > 0 Then
            Return DBNull2Zero(ds.Tables(0).Rows(0)(0))
        Else
            Return 0
        End If
    End Function

    Public Function QAStandard_Get(PostUID As Integer, QANO As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("QAStandard_Get"), PostUID, QANO)
        Return ds.Tables(0)
    End Function

    Public Function QAStandard_GetMaxUID() As Long
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("QAStandard_GetMaxUID"))
        Return DBNull2Lng(ds.Tables(0).Rows(0)(0))
    End Function
    Public Function QAStandard_GetLastUID(LocationUID As Integer) As Long
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("QAStandard_GetLastUID"), LocationUID)
        Return DBNull2Lng(ds.Tables(0).Rows(0)(0))
    End Function
    Public Function QAStandard_GetByUID(id As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("QAStandard_GetByUID"), id)
        Return ds.Tables(0)
    End Function

    Public Function QAStandard_Save(ByVal UID As Long, ByVal LocationUID As Integer, Name As String, Desc As String, ByVal MUser As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("QAStandard_Save"), UID, LocationUID, Name, Desc, MUser)
    End Function

    Public Function QAStandard_Update(ByVal pID_old As String, ByVal pID_new As String, ByVal pName As String, desc As String, ByVal pStatus As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, "QAStandard_Update", pID_old, pID_new, pName, desc, pStatus)
    End Function

    Public Function QAStandard_Delete(ByVal pID As String) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, "QAStandard_Delete", pID)
    End Function

    Public Function RPT_PostAudit_GetByUID(PostUID As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("RPT_PostAudit_GetByUID"), PostUID)
        Return ds.Tables(0)
    End Function
    Public Function RPT_PostAudit_QA_Picture(PostUID As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("RPT_PostAudit_QA_Picture"), PostUID)
        Return ds.Tables(0)
    End Function

#End Region
End Class
