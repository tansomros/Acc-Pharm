Imports Microsoft.ApplicationBlocks.Data

Public Class DocumentController
    Inherits BaseClass
    Dim ds As New DataSet
    Public Function Document_GetYear() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, "Document_GetYear")
        Return ds.Tables(0)
    End Function

    Public Function LocationDocument_GetCategory() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("LocationDocument_GetCategory"))
        Return ds.Tables(0)
    End Function
    Public Function Document_GetCategory() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Document_GetCategory"))
        Return ds.Tables(0)
    End Function

    Public Function Document_GetDocumentID(TermNo As Integer, EduYear As Integer, StudentID As Integer, RegDate As String, TopicUID As Integer) As Integer
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Document_GetDocumentID"), TermNo, EduYear, StudentID, RegDate, TopicUID)
        If ds.Tables(0).Rows.Count > 0 Then
            Return DBNull2Zero(ds.Tables(0).Rows(0)(0))
        Else
            Return 0
        End If

    End Function
    Public Function LocationDocument_Get(LocationUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("LocationDocument_Get"), LocationUID)
        Return ds.Tables(0)
    End Function
    Public Function GPPDocument_Get(GPPUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("GPPDocument_Get"), GPPUID)
        Return ds.Tables(0)
    End Function
    Public Function Document_Get(ReqUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Document_Get"), ReqUID)
        Return ds.Tables(0)
    End Function

    Public Function Document_GetPayslip(ReqUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Document_GetPayslip"), ReqUID)
        Return ds.Tables(0)
    End Function


    Public Function GetDocument_BySearch(pYear As Integer, SubjectCode As String, pkey As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, "Document_GetBySearch", pYear, SubjectCode, pkey)
        Return ds.Tables(0)
    End Function

    Public Function Document_GetByID(DocID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, "Document_GetByUID", DocID)
        Return ds.Tables(0)
    End Function
    Public Function Document_GetByStudent(EduYear As Integer, StudentID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, "Document_GetByStudent", EduYear, StudentID)
        Return ds.Tables(0)
    End Function
    Public Function Document_GetByYear(EduYear As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, "Document_GetByYear", EduYear)
        Return ds.Tables(0)
    End Function
    Public Function Document_GetBySearch(EduYear As Integer, TopicUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, "Document_GetBySearch", EduYear, TopicUID)
        Return ds.Tables(0)
    End Function
    Public Function Document_Delete(DocID As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, "Document_Delete", DocID)
    End Function
    Public Function LocationDocument_Delete(DocID As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, "LocationDocument_Delete", DocID)
    End Function

    Public Function Document_GetStudentBySex(RegYear As String, LocationID As Integer, Phase As Integer, DegreeNo As Integer, sSex As String, SubjectCode As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Document_GetStudentBySex"), RegYear, LocationID, Phase, DegreeNo, sSex, SubjectCode)

        Return ds.Tables(0)

    End Function
    Public Function Document_GetFolderName(UID As Integer) As String
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Document_GetFolderName"), UID)
        If ds.Tables(0).Rows.Count > 0 Then
            Return String.Concat(ds.Tables(0).Rows(0)(0))
        Else
            Return ""
        End If

    End Function
    Public Function Document_CheckDup(RegYear As String, stdCode As String, Phase As Integer) As Integer
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Document_CheckDup"), RegYear, stdCode, Phase)
        If ds.Tables(0).Rows.Count > 0 Then
            Return DBNull2Zero(ds.Tables(0).Rows(0)(0))
        Else
            Return 0
        End If

    End Function
    Public Function Document_CheckAssessment(RID As Integer) As Integer
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Document_CheckAssessment"), RID)
        If ds.Tables(0).Rows.Count > 0 Then
            Return DBNull2Zero(ds.Tables(0).Rows(0)(0))
        Else
            Return 0
        End If

    End Function

    Public Function Document_GetStudentNoAssessment(RegYear As Integer, SubjCode As String, Optional sKey As String = "") As DataTable

        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Document_NotAssessment"), RegYear, SubjCode, sKey)
        Return ds.Tables(0)

    End Function
    Public Function Document_GetStudentNoDocument(RegYear As Integer, SubjCode As String, CID As Integer, Optional sKey As String = "") As DataTable

        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Document_NotDocument"), RegYear, SubjCode, CID, sKey)
        Return ds.Tables(0)

    End Function
    Public Function LocationDocument_Save(DocumentUID As Integer, LocationUID As Integer, FilePath As String, UpdBy As String) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("LocationDocument_Save"), DocumentUID, LocationUID, FilePath, UpdBy)
    End Function
    Public Function GPPDocument_Save(GUID As Integer, DocumentName As String, LocationUID As Integer, FilePath As String, UpdBy As String) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("GPPDocument_Save"), GUID, DocumentName, LocationUID, FilePath, UpdBy)
    End Function
    Public Function GPPDocument_UpdateGPPUID(GUID As Integer, LocationUID As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("GPPDocument_UpdateGPPUID"), GUID, LocationUID)
    End Function
    Public Function Document_Save(DocumentUID As Integer, RequestUID As Integer, LocationUID As Integer, FilePath As String, UpdBy As String) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("Document_Add"), DocumentUID, RequestUID, LocationUID, FilePath, UpdBy)
    End Function
    Public Function PaymentSlip_Add(DocumentUID As Integer, RequestUID As Integer, LocationUID As Integer, FilePath As String, Amount As Double, UpdBy As String) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("PaymentSlip_Add"), DocumentUID, RequestUID, LocationUID, FilePath, Amount, UpdBy)
    End Function


    Public Function Document_Update(ByVal pID_old As Integer, ByVal pID_new As Integer, ByVal pName As String, desc As String, ByVal pStatus As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, "Document_Update", pID_old, pID_new, pName, desc, pStatus)
    End Function

    Public Function Document_UpdatePriority(ByVal ItemID As Integer, ByVal flage As String, updBy As String) As Integer

        Return SqlHelper.ExecuteNonQuery(ConnectionString, "Document_UpdatePriority", ItemID, flage, updBy)
    End Function

    Public Function Document_UpdatePriorityItem(ByVal pID As Integer, ByVal pDegree As Integer, updBy As String) As Integer

        Return SqlHelper.ExecuteNonQuery(ConnectionString, "Document_UpdatePriorityItem", pID, pDegree, updBy)

    End Function


    Public Function DocumentTopic_Get() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, "DocumentTopic_Get")
        Return ds.Tables(0)
    End Function

End Class
