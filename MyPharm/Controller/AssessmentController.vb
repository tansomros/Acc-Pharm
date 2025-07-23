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

    Public Function GPP_Assessment_GetUID(RequestUID As Integer) As Long
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("GPP_Assessment_GetUID"), RequestUID)
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

    Public Function Assessment_UpdateResult(ByVal UID As Integer, ByVal Comment1 As String, ByVal Comment2 As String, ByVal Comment3 As String, ByVal Comment4 As String, ByVal Comment5 As String, ByVal S As String, ByVal W As String, ByVal O As String, ByVal T As String, ByVal Status As String, ByVal AppointmentDate As String, ByVal PassDate As String, ByVal DocumentNo As String, ByVal AccLicense As String, ByVal StartDate As String, ByVal ExpireDate As String, ByVal AccRemark As String, ByVal CUser As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("Assessment_UpdateResult"), UID, Comment1, Comment2, Comment3, Comment4, Comment5, S, W, O, T, Status, AppointmentDate, PassDate, DocumentNo, AccLicense, StartDate, ExpireDate, AccRemark, CUser)
    End Function

#Region "GPP"

    Public Function GPP_Assessment_GetByRequestUID(RequestUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("GPP_Assessment_GetByRequestUID"), RequestUID)
        Return ds.Tables(0)
    End Function

    Public Function GPP_Assessment_Save(ByVal UID As Integer, ByVal RequestUID As Integer, ByVal LocationUID As Integer, ByVal TotalScore As Double, ByVal FinalScore As Double, ByVal PercentScore As Double, ByVal FinalResult As String, ByVal Remark As String, MUser As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("GPP_Assessment_Save"), UID, RequestUID, LocationUID, TotalScore, FinalScore, PercentScore, FinalResult, Remark, MUser)
    End Function
    Public Function GPP_AssessmentScore_Save(ByVal GPP_Assessment_UID As Integer, ByVal ItemUID As Integer, ByVal Score As Double, ByVal WeightScore As Double, ByVal NetScore As Double, ByVal Muser As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("GPP_AssessmentScore_Save"), GPP_Assessment_UID, ItemUID, Score, WeightScore, NetScore, Muser)
    End Function

    Public Function GPP_AssessmentScore_Get(GPPUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("GPP_AssessmentScore_Get"), GPPUID)
        Return ds.Tables(0)
    End Function

#End Region
#Region "QA"

    Public Function QA_Assessment_GetByRequestUID(RequestUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("QA_Assessment_GetByRequestUID"), RequestUID)
        Return ds.Tables(0)
    End Function

    Public Function QA_Assessment_Save(ByVal UID As Integer, ByVal RequestUID As Integer, ByVal LocationUID As Integer, ByVal Risk1 As String, ByVal Risk2 As String, ByVal Risk3 As String, ByVal Risk4 As String, ByVal Risk5 As String, ByVal Risk6 As String, ByVal Risk7 As String, ByVal Risk8 As String, ByVal Risk9 As String, ByVal Risk10 As String, ByVal Telepharmacy As String, ByVal TeleTools As String, ByVal ToolsOther As String, ByVal Q2 As String, ByVal Q3 As String, ByVal Q4 As String, ByVal Q5 As String, ByVal MUser As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("QA_Assessment_Save"), UID, RequestUID, LocationUID, Risk1, Risk2, Risk3, Risk4, Risk5, Risk6, Risk7, Risk8, Risk9, Risk10, Telepharmacy, TeleTools, ToolsOther, Q2, Q3, Q4, Q5, MUser)
    End Function
    Public Function QA_AssessmentScore_Save(ByVal QA_Assessment_UID As Long, ByVal RequestUID As Long, ByVal Score1 As Double, ByVal AuditorComment1 As String, ByVal Score2 As Double, ByVal AuditorComment2 As String, ByVal Score3 As Double, ByVal AuditorComment3 As String, ByVal AsmStatus As String, ByVal Muser As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("QA_AssessmentScore_Save"), QA_Assessment_UID, RequestUID, Score1, AuditorComment1, Score2, AuditorComment2, Score3, AuditorComment3, AsmStatus, Muser)
    End Function

    Public Function QA_AssessmentScore_Get(QAUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("QA_AssessmentScore_Get"), QAUID)
        Return ds.Tables(0)
    End Function


#End Region
End Class
