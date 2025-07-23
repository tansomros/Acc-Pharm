Imports Microsoft.ApplicationBlocks.Data

Public Class ElearningController

    Inherits BaseClass
    Public ds As New DataSet
    Public Function Course_Get() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Course_Get"))
        Return ds.Tables(0)
    End Function
    Public Function Course_GetActive() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Course_GetActive"))
        Return ds.Tables(0)
    End Function

    Public Function Course_GetByUID(pUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Course_GetByUID"), pUID)
        Return ds.Tables(0)
    End Function

    Public Function Course_GetForClassroom(PID As Integer, CID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Course_GetForClassroom"), PID, CID)
        Return ds.Tables(0)
    End Function


    Public Function Course_GetBySearch(pKey As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Course_GetBySearch"), pKey)
        Return ds.Tables(0)
    End Function

    Public Function Course_Save(ByVal CourseID As String, ByVal Name As String, ByVal MediaType As String, ByVal MediaCount As String, DisplayOrder As Integer, MediaLink As String, PicturePath As String, StatusFlag As String) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("Course_Save"), CourseID, Name, DisplayOrder, StatusFlag, MediaType, MediaCount, MediaLink, PicturePath)
    End Function

    Public Function Course_UpdateFilename(ByVal CourseID As String, ByVal FileName As String) As Integer

        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("Course_UpdateFilename"), CourseID, FileName)

    End Function



    Public Function Course_Delete(ByVal CourseUID As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("Course_Delete"), CourseUID)
    End Function

    Public Function CourseAssign_GetByPersonUID(pUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("CourseAssignment_GetByPersonUID"), pUID)
        Return ds.Tables(0)
    End Function 
    Public Function CourseAssign_GetByUID(pUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("CourseAssignment_GetByUID"), pUID)
        Return ds.Tables(0)
    End Function
    Public Function CourseAssign_DeleteByPerson(PersonUID As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, "CourseAssignment_DeleteByPerson", PersonUID)
    End Function

    Public Function CourseAssign_Save(PersonUID As Integer, CourseUID As Integer, Duedate As String, Recure As String) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, "CourseAssignment_Save", PersonUID, CourseUID, Duedate, Recure)
    End Function

    Public Function CourseAssign_Delete(ByVal UID As Long) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("CourseAssign_Delete"), UID)
    End Function

    Public Function PersonLearning_Save(ByVal CourseUID As Integer, ByVal PersonUID As Integer, ByVal LearnStatus As String) As Integer
        ', ByVal Duedate As String, ByVal LearnStatus As String, ByVal SEQNO As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("PersonLearning_Save"), CourseUID, PersonUID, LearnStatus)
    End Function

    Public Function PersonLearning_Get(pUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("PersonLearning_Get"), pUID)
        Return ds.Tables(0)
    End Function


#Region "Evaluation" 'ข้อสอบ
    Public Function EvaluationTopic_Get() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("EvaluationTopic_Get"))
        Return ds.Tables(0)
    End Function
    Public Function EvaluationTopic_Get(ByVal pSearch As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("EvaluationTopic_GetSearch"), pSearch)
        Return ds.Tables(0)
    End Function

    Public Function EvaluationTopicNotSetForm_Get(ByVal EvaGroup As Integer, ByVal pSearch As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("EvaluationTopicNotSetForm_Get"), EvaGroup, pSearch)
        Return ds.Tables(0)
    End Function

    Public Function EvaluationTopic_GetByGroup(ByVal GroupUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("EvaluationTopic_GetByGroup"), GroupUID)
        Return ds.Tables(0)
    End Function

    Public Function EvaluationTopic_GetByUID(ByVal PUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("EvaluationTopic_GetByUID"), PUID)
        Return ds.Tables(0)
    End Function
    Public Function EvaluationTopic_GetUID(ByVal CourseUID As Integer, Descriptions As String) As Integer
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("EvaluationTopic_GetUID"), CourseUID, Descriptions)
        If ds.Tables(0).Rows.Count > 0 Then
            Return DBNull2Zero(ds.Tables(0).Rows(0)(0))
        Else
            Return 0
        End If
    End Function


    Public Function EvaluationTopic_Delete(ByVal pID As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, "EvaluationTopic_Delete", pID)
    End Function
    Public Function EvaluationTopic_Save(ByVal pID As Integer, CourseUID As Integer, Descriptions As String, Sort As String, Statusflag As String) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, "EvaluationTopic_Save", pID, CourseUID, Descriptions, Sort, Statusflag)
    End Function

    Public Function EvaluationAnswer_Get(ByVal QuestionUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("EvaluationAnswer_Get"), QuestionUID)
        Return ds.Tables(0)
    End Function

    Public Function EvaluationAnswer_Save(ByVal AnswerID As Integer, CourseUID As Integer, QuestionID As Integer, Descriptions As String, AnswerCode As String, isAnswer As String) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, "EvaluationAnswer_Save", AnswerID, CourseUID, QuestionID, Descriptions, AnswerCode, isAnswer)
    End Function
#End Region


#Region "Test"
    Public Function Question_Get(CourseUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Question_Get"), CourseUID)
        Return ds.Tables(0)
    End Function

    Public Function Answer_Get(CourseUID As Integer, QuestionUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Answer_Get"), CourseUID, QuestionUID)
        Return ds.Tables(0)
    End Function
    Public Function Question_GetCorrectAnswer(CourseUID As Integer, QuestionUID As Integer) As Integer
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Question_GetCorrectAnswer"), CourseUID, QuestionUID)

        If ds.Tables(0).Rows.Count > 0 Then
            Return DBNull2Zero(ds.Tables(0).Rows(0)(0))
        Else
            Return 0
        End If
    End Function


    Public Function PersonTest_Get(PersonUID As Integer, CourseUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("PersonTest_Get"), PersonUID, CourseUID)
        Return ds.Tables(0)
    End Function

    Public Function PersonTest_Save(PersonUID As Integer, CourseUID As Integer, TotalScore As Integer, ResultStatus As String) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("PersonTest_Save"), PersonUID, CourseUID, TotalScore, ResultStatus)
    End Function

    Public Function PersonTest_GetUID(PersonUID As Integer, CourseUID As Integer) As Integer
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("PersonTest_GetUID"), PersonUID, CourseUID)
        If ds.Tables(0).Rows.Count > 0 Then
            Return DBNull2Zero(ds.Tables(0).Rows(0)(0))
        Else
            Return 0
        End If
    End Function



    Public Function PersonTestScore_Save(PersonTestUID As Integer, QuestionUID As Integer, AnswerID As Integer, IsCorrect As String, Score As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("PersonTestScore_Save"), PersonTestUID, QuestionUID, AnswerID, IsCorrect, Score)
    End Function
#End Region
End Class

