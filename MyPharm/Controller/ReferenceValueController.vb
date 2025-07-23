Imports Microsoft.ApplicationBlocks.Data

Public Class ReferenceValueController
        Inherits BaseClass
    'Public dt As DataTable = New DataTable
    Public ds As DataSet = New DataSet
    Public Function ReferenceValue_GetByDomainCode(pCode As String) As DataTable
            ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("ReferenceValue_GetByDomainCode"), pCode)
            Return ds.Tables(0)
        End Function
        Public Function ReferenceValue_GetListByDomainCode(pCode As String) As DataTable
            ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("ReferenceValue_GetListByDomainCode"), pCode)
            Return ds.Tables(0)
        End Function
        Public Function CheckUpReason_Get() As DataTable
            ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("CheckUpReason_Get"))
            Return ds.Tables(0)
        End Function
        Public Function ReturnWorkReason_Get() As DataTable
            ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("ReturnWorkReason_Get"))
            Return ds.Tables(0)
        End Function
        Public Function ReturnWorkResult_Get() As DataTable
            ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("ReturnWorkResult_Get"))
            Return ds.Tables(0)
        End Function
        Public Function Diagnosis_Get() As DataTable
            ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Diagnosis_Get"))
            Return ds.Tables(0)
        End Function

        Public Function CheckUpProgram_GetGroup() As DataTable
            ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("CheckUpProgram_GetGroup"))
            Return ds.Tables(0)
        End Function

        Public Function CheckUpProgram_GetAgePeriod() As DataTable
            ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("CheckUpProgram_GetAgePeriod"))
            Return ds.Tables(0)
        End Function
#Region "Referece Value"
        Public Function ReferenceValue_GetByDomainCode(ByVal DomainCode As String, Optional Blank As String = "") As DataTable
            If Blank = "Y" Then
                ds = SqlHelper.ExecuteDataset(ConnectionString, "ReferenceValue_GetByDomainCodeAndBlank", DomainCode)
            Else
                ds = SqlHelper.ExecuteDataset(ConnectionString, "ReferenceValue_GetByDomainCode", DomainCode)
            End If
            Return ds.Tables(0)
        End Function

        Public Function ReferenceDomain_GetByCode(ByVal Code As String) As DataTable
            ds = SqlHelper.ExecuteDataset(ConnectionString, "ReferenceDomain_GetByCode", Code)
            Return ds.Tables(0)
        End Function
        Public Function ReferenceDomain_ChkDup(ByVal Code As String) As Boolean
        ds = SqlHelper.ExecuteDataset(ConnectionString, "ReferenceDomain_GetByCode", Code)
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


        Public Function ReferenceDomain_GetSearch(ByVal Search As String) As DataTable
            ds = SqlHelper.ExecuteDataset(ConnectionString, "ReferenceDomain_GetSearch", Search)
            Return ds.Tables(0)
        End Function
        Public Function ReferenceDomain_Add(Code As String, Desc As String, isSortByDesc As String, StatusFlag As String) As Integer
            Return SqlHelper.ExecuteNonQuery(ConnectionString, "ReferenceDomain_Add", Code, Desc, isSortByDesc, StatusFlag)
        End Function
        Public Function ReferenceDomain_Update(UID As Integer, Code As String, Desc As String, isSortByDesc As String, StatusFlag As String) As Integer
            Return SqlHelper.ExecuteNonQuery(ConnectionString, "ReferenceDomain_Update", UID, Code, Desc, isSortByDesc, StatusFlag)
        End Function

        Public Function ReferenceDomain_Delete(UID As Integer) As Integer
            Return SqlHelper.ExecuteNonQuery(ConnectionString, "ReferenceDomain_Delete", UID)
        End Function

        Public Function ReferenceValue_GetByCode(ByVal Code As String) As DataTable
            ds = SqlHelper.ExecuteDataset(ConnectionString, "ReferenceValue_GetByCode", Code)
            Return ds.Tables(0)
        End Function
        Public Function ReferenceValue_GetByCode(Domain As String, ByVal Code As String) As DataTable
            ds = SqlHelper.ExecuteDataset(ConnectionString, "ReferenceValue_GetByCode", Domain, Code)
            Return ds.Tables(0)
        End Function

        Public Function ReferenceValue_ChkDup(Domain As String, ByVal Code As String) As Boolean
            ds = SqlHelper.ExecuteDataset(ConnectionString, "ReferenceValue_GetByCode", Domain, Code)
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
        Public Function ReferenceValue_Get() As DataTable
            ds = SqlHelper.ExecuteDataset(ConnectionString, "ReferenceValue_Get")
            Return ds.Tables(0)
        End Function

        Public Function ReferenceValue_GetSearch(DomainCode As String, ByVal Search As String) As DataTable
            ds = SqlHelper.ExecuteDataset(ConnectionString, "ReferenceValue_GetSearch", DomainCode, Search)
            Return ds.Tables(0)
        End Function
        Public Function ReferenceValue_GetByUID(ByVal UID As Integer) As DataTable
            ds = SqlHelper.ExecuteDataset(ConnectionString, "ReferenceValue_GetByUID", UID)
            Return ds.Tables(0)
        End Function

        Public Function ReferenceValue_Add(DomainUID As Integer, DomainCode As String, Code As String, Desc As String, DisplayOrder As Integer, StatusFlag As String, CUser As Integer) As Integer
            Return SqlHelper.ExecuteNonQuery(ConnectionString, "ReferenceValue_Add", DomainUID, DomainCode, Code, Desc, DisplayOrder, StatusFlag, CUser)
        End Function
        Public Function ReferenceValue_Update(UID As Integer, DomainUID As Integer, DomainCode As String, Code As String, Desc As String, DisplayOrder As Integer, StatusFlag As String, CUser As Integer) As Integer
            Return SqlHelper.ExecuteNonQuery(ConnectionString, "ReferenceValue_Update", UID, DomainUID, DomainCode, Code, Desc, DisplayOrder, StatusFlag, CUser)
        End Function

        Public Function ReferenceValue_Delete(UID As Integer) As Integer
            Return SqlHelper.ExecuteNonQuery(ConnectionString, "ReferenceValue_Delete", UID)
        End Function


        Public Function WorkType_Add(UID As Integer, Name As String, CUser As Integer) As Integer
            Return SqlHelper.ExecuteNonQuery(ConnectionString, "WorkType_Save", UID, Name, CUser)
        End Function
        Public Function WorkType_Delete(UID As Integer) As Integer
            Return SqlHelper.ExecuteNonQuery(ConnectionString, "WorkType_Delete", UID)
        End Function

#End Region




    End Class
