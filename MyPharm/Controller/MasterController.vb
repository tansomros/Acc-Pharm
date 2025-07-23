Imports Microsoft.ApplicationBlocks.Data
Public Class MasterController
    Inherits BaseClass
    Dim ds As New DataSet


#Region "Acc / Asm  Status"
    Public Function AccStatus_Get() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, "AccStatus_Get")
        Return ds.Tables(0)
    End Function
    Public Function AssessmentStatus_GetForReport() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, "AssessmentStatus_GetForReport")
        Return ds.Tables(0)
    End Function

#End Region

#Region "Prefix"

    Public Function Prefix_GetAll() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, "Prefix_GetAll")
        Return ds.Tables(0)
    End Function
    Public Function Prefix_GetActive() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, "Prefix_GetActive")
        Return ds.Tables(0)
    End Function

    Public Function Prefix_CheckDuplicate(pName As String) As Boolean
        ds = SqlHelper.ExecuteDataset(ConnectionString, "Prefix_CheckDuplicate", pName)
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
    Public Function Prefix_GetSearch(pSearch As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, "Prefix_GetSearch", pSearch)
        Return ds.Tables(0)
    End Function
    Public Function Prefix_GetByUID(pID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, "Prefix_GetByUID", pID)
        Return ds.Tables(0)
    End Function

    Public Function Prefix_Delete(pID As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, "Prefix_Delete", pID)
    End Function

    Public Function Prefix_Add(Name1 As String, Name2 As String, Name3 As String, StatusFlag As String) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, "Prefix_Add", Name1, Name2, Name3, StatusFlag)
    End Function

    Public Function Prefix_Update(pid As Integer, Name1 As String, Name2 As String, Name3 As String, StatusFlag As String)
        Return SqlHelper.ExecuteNonQuery(ConnectionString, "Prefix_Update", pid, Name1, Name2, Name3, StatusFlag)
    End Function
#End Region
#Region "Category"
    Public Function Category_Get() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, "Category_Get")
        Return ds.Tables(0)
    End Function
    Public Function Category_GetActive() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, "Category_GetActive")
        Return ds.Tables(0)
    End Function

#End Region
#Region "Area"
    Public Function Area_GetAll() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Area_GetAll"))
        Return ds.Tables(0)
    End Function

    Public Function Area_Get() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Area_Get"))
        Return ds.Tables(0)
    End Function

    Public Function Area_GetByUID(ByVal pUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Area_GetByUID"), pUID)
        Return ds.Tables(0)
    End Function

    Public Function Area_GetBySearch(ByVal pKey As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Area_GetBySearch"), pKey)
        Return ds.Tables(0)
    End Function

    Public Function Area_Add(ByVal AreaCode As String, ByVal Name As String, ByVal Sort As Integer, ByVal Status As String) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("Area_Add"), AreaCode, Name, Sort, Status)
    End Function

    Public Function Area_Update(ByVal AreaUID As Integer, ByVal AreaCode As String, ByVal Name As String, ByVal Sort As Integer, ByVal status As String) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("Area_Update"), AreaUID, AreaCode, Name, Sort, status)
    End Function

    Public Function Area_Delete(ByVal AreaUID As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("Area_Delete"), AreaUID)
    End Function
    Public Function Area_Save(UID As Integer, Name As String, Sort As Integer, StatusFlag As String) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, "Area_Save", UID, Name, Sort, StatusFlag)
    End Function
#End Region
#Region "Organize"
    Public Function Organize_GetAll() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, "Organize_GetAll")
        Return ds.Tables(0)
    End Function
    Public Function Organize_GetActive() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, "Organize_GetActive")
        Return ds.Tables(0)
    End Function

    Public Function Organize_CheckDuplicate(pName As String) As Boolean
        ds = SqlHelper.ExecuteDataset(ConnectionString, "Organize_CheckDuplicate", pName)
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
    Public Function Organize_GetSearch(pSearch As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, "Organize_GetSearch", pSearch)
        Return ds.Tables(0)
    End Function
    Public Function Organize_GetByUID(pID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, "Organize_GetByUID", pID)
        Return ds.Tables(0)
    End Function

    Public Function Organize_Delete(pID As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, "Organize_Delete", pID)
    End Function

    Public Function Organize_Save(UID As Integer, Name As String, Sort As Integer, StatusFlag As String) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, "Organize_Save", UID, Name, Sort, StatusFlag)
    End Function
#End Region
#Region "Machine"



    Public Function Machine_GetAll() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, "Machine_GetAll")
        Return ds.Tables(0)
    End Function
    Public Function Machine_GetActive() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, "Machine_GetActive")
        Return ds.Tables(0)
    End Function

    Public Function Machine_CheckDuplicate(pName As String) As Boolean
        ds = SqlHelper.ExecuteDataset(ConnectionString, "Machine_CheckDuplicate", pName)
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
    Public Function Machine_GetSearch(pSearch As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, "Machine_GetSearch", pSearch)
        Return ds.Tables(0)
    End Function
    Public Function Machine_GetByUID(pID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, "Machine_GetByUID", pID)
        Return ds.Tables(0)
    End Function

    Public Function Machine_Delete(pID As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, "Machine_Delete", pID)
    End Function

    Public Function Machine_Add(Name1 As String, Remark As String, StatusFlag As String) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, "Machine_Add", Name1, Remark, StatusFlag)
    End Function

    Public Function Machine_Update(pid As Integer, Name1 As String, Remark As String, StatusFlag As String)
        Return SqlHelper.ExecuteNonQuery(ConnectionString, "Machine_Update", pid, Name1, Remark, StatusFlag)
    End Function
#End Region
#Region "Province"


    'Public Function Province_GetAll() As DataTable
    '        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Province_GetAll"))
    '        Return ds.Tables(0)
    '    End Function

    Public Function Province_Get() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Province_Get"))
        Return ds.Tables(0)
    End Function
    Public Function Province_GetForReport() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Province_GetForReport"))
        Return ds.Tables(0)
    End Function
    Public Function Province_GetForReportByGroup(pvGroup As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Province_GetForReportByGroup"), pvGroup)
        Return ds.Tables(0)
    End Function
    Public Function ProvinceGroup_GetForReport() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("ProvinceGroup_GetForReport"))
        Return ds.Tables(0)
    End Function
    Public Function Province_GetByID(ByVal pKey As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Province_GetByID"), pKey)
        Return ds.Tables(0)
    End Function
    Public Function NHSO_GetForReport() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("NHSO_GetForReport"))
        Return ds.Tables(0)
    End Function
    Public Function Province_GetID(Code As String) As String
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Province_GetID"), Code)
        If ds.Tables(0).Rows.Count > 0 Then
            Return String.Concat(ds.Tables(0).Rows(0)(0))
        Else
            Return "00"
        End If
    End Function

    '    Public Function Province_Add(ByVal ProvinceCode As String, ByVal Name As String, ByVal Sort As Integer, ByVal Status As String) As Integer
    '    Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("Province_Add"), ProvinceCode, Name, Sort, Status)
    'End Function

    '    Public Function Province_Update(ByVal ProvinceUID As Integer, ByVal ProvinceCode As String, ByVal Name As String, ByVal Sort As Integer, ByVal status As String) As Integer
    '    Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("Province_Update"), ProvinceUID, ProvinceCode, Name, Sort, status)
    'End Function

    '    Public Function Province_Delete(ByVal ProvinceUID As Integer) As Integer
    '    Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("Province_Delete"), ProvinceUID)
    'End Function
    'Public Function Province_Save(UID As Integer, Name As String, Sort As Integer, StatusFlag As String) As Integer
    '    Return SqlHelper.ExecuteNonQuery(ConnectionString, "Province_Save", UID, Name, Sort, StatusFlag)
    'End Function
#End Region
#Region "Division"
    Public Function Division_GetAll(ByVal CompanyUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Division_GetAll"), CompanyUID)
        Return ds.Tables(0)
    End Function

    Public Function Division_Get(ByVal CompanyUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Division_Get"), CompanyUID)
        Return ds.Tables(0)
    End Function

    Public Function Division_GetByUID(ByVal pUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Division_GetByUID"), pUID)
        Return ds.Tables(0)
        End Function

    Public Function Division_GetBySearch(ByVal CompanyUID As Integer, ByVal pKey As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Division_GetBySearch"), CompanyUID, pKey)
        Return ds.Tables(0)
    End Function

    Public Function Division_CheckDuplicate(ByVal CompanyUID As Integer, pName As String) As Boolean
        ds = SqlHelper.ExecuteDataset(ConnectionString, "Division_CheckDuplicate", CompanyUID, pName)
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

    Public Function Division_Add(CompanyUID As Integer, ByVal DivisionCode As String, ByVal Name As String, ByVal Sort As Integer, ByVal Status As String) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("Division_Add"), CompanyUID, DivisionCode, Name, Sort, Status)
    End Function

    Public Function Division_Update(ByVal DivisionUID As Integer, CompanyUID As Integer, ByVal DivisionCode As String, ByVal Name As String, ByVal Sort As Integer, ByVal status As String) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("Division_Update"), DivisionUID, CompanyUID, DivisionCode, Name, Sort, status)
    End Function

    Public Function Division_Delete(ByVal CompanyUID As Integer, ByVal DivisionUID As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("Division_Delete"), CompanyUID, DivisionUID)
    End Function

#End Region
#Region "Department"

    Public Function Department_GetAll(ByVal CompanyUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, "Department_GetAll", CompanyUID)
        Return ds.Tables(0)
    End Function
    Public Function Department_GetActive(CompanyUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, "Department_GetActive", CompanyUID)
        Return ds.Tables(0)

    End Function
    Public Function Department_GetSearch(CompanyUID As Integer, pSearch As String) As DataTable

        ds = SqlHelper.ExecuteDataset(ConnectionString, "Department_GetSearch", CompanyUID, pSearch)

        Return ds.Tables(0)


    End Function
    Public Function Department_CheckDuplicate(CompanyUID As Integer, pName As String) As Boolean
        ds = SqlHelper.ExecuteDataset(ConnectionString, "Department_CheckDuplicate", CompanyUID, pName)
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

    Public Function Department_GetByID(pid As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, "Department_GetByID", pid)
        Return ds.Tables(0)
    End Function

    Public Function Department_Add(CompanyUID As Integer, Code As String, Name As String, divisionUID As Integer, sort As Integer, StatusFlag As String)
        Return SqlHelper.ExecuteNonQuery(ConnectionString, "Department_Add", CompanyUID, Code, Name, divisionUID, sort, StatusFlag)
    End Function

    Public Function Department_Update(UID As Integer, CompanyUID As Integer, Code As String, Name As String, divisionUID As Integer, sort As Integer, StatusFlag As String)
        Return SqlHelper.ExecuteNonQuery(ConnectionString, "Department_Update", UID, CompanyUID, Code, Name, divisionUID, sort, StatusFlag)
    End Function

    Public Function Department_GetByDivisionUID(CompanyUID As Integer, ByVal DivisionUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Department_GetByDivisionUID"), CompanyUID, DivisionUID)
        Return ds.Tables(0)
    End Function

    Public Function Department_Get(CompanyUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Department_Get"), CompanyUID)
        Return ds.Tables(0)
    End Function

    Public Function Department_GetByUID(ByVal pUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Department_GetByUID"), pUID)
        Return ds.Tables(0)
        End Function

    Public Function Department_GetBySearch(CompanyUID As Integer, ByVal pKey As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Department_GetBySearch"), CompanyUID, pKey)
        Return ds.Tables(0)
    End Function

    'Public Function Department_Add(CompanyUID As Integer, ByVal DepartmentCode As String, ByVal Name As String, ByVal Sort As Integer, ByVal Status As String, ByVal DeptUID As Integer) As Integer
    '    Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("Department_Add"), CompanyUID, DepartmentCode, Name, Sort, Status, DeptUID)
    'End Function

    'Public Function Department_Update(ByVal DepartmentUID As Integer, CompanyUID As Integer, ByVal DepartmentCode As String, ByVal Name As String, ByVal Sort As Integer, ByVal status As String, ByVal DeptUID As Integer) As Integer
    '    Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("Department_Update"), DepartmentUID, CompanyUID, DepartmentCode, Name, Sort, status, DeptUID)
    'End Function

    Public Function Department_Delete(ByVal DepartmentUID As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("Department_Delete"), DepartmentUID)
    End Function

#End Region
#Region "Position"
    Public Function Position_GetActive() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Position_GetActive"))
        Return ds.Tables(0)
    End Function

    Public Function Position_GetAll(ByVal CompanyUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Position_GetAll"), CompanyUID)
        Return ds.Tables(0)
    End Function

    Public Function Position_Get(ByVal CompanyUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Position_Get"), CompanyUID)
        Return ds.Tables(0)
    End Function

    Public Function Position_GetByUID(ByVal pUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Position_GetByUID"), pUID)
        Return ds.Tables(0)
        End Function
    Public Function Position_CheckDuplicate(CompanyUID As Integer, pName As String) As Boolean
        ds = SqlHelper.ExecuteDataset(ConnectionString, "Position_CheckDuplicate", CompanyUID, pName)
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
    Public Function Position_GetBySearch(ByVal CompanyUID As Integer, ByVal pKey As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Position_GetBySearch"), CompanyUID, pKey)
        Return ds.Tables(0)
    End Function

    Public Function Position_Add(ByVal PositionCode As String, ByVal Name As String, CompanyUID As Integer, ByVal Sort As Integer, ByVal Status As String) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("Position_Add"), PositionCode, Name, CompanyUID, Sort, Status)
    End Function

    Public Function Position_Update(ByVal PositionUID As Integer, ByVal PositionCode As String, ByVal Name As String, ByVal Sort As Integer, ByVal status As String) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("Position_Update"), PositionUID, PositionCode, Name, Sort, status)
    End Function

    Public Function Position_Delete(ByVal PositionUID As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("Position_Delete"), (PositionUID))
    End Function

#End Region
#Region "Dataconfig"
    Public Function DataConfig_GetByCode(ByVal pid As String) As String
            ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("DataConfig_GetByCode"), pid)
        Return DBNull2Str(ds.Tables(0).Rows(0)(0))
    End Function

        Public Function DataConfig_Add(ByVal pCode As String, ByVal pYear As String, ByVal pNo As String) As Integer
            Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("DataConfig_Add"), pCode, pYear, pNo)
        End Function

        Public Function DataConfig_Update(ByVal pCode As String, ByVal pYear As String, ByVal pNo As String) As Integer
            Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("DataConfig_Update"), pCode, pYear, pNo)
        End Function

#End Region
#Region "Runing"
    Public Function Running_Get() As DataTable
            ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Running_Get"))
            Return ds.Tables(0)
        End Function

        Public Function Running_GetByCode(ByVal pid As String, ByVal pYear As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Running_GetByCode"), pid, (pYear))
        Return ds.Tables(0)
        End Function

        Public Function Running_Add(ByVal pCode As String, ByVal pYear As Integer, ByVal pNo As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("Running_Add"), pCode, (pYear), (pNo))
    End Function

        Public Function Running_Update(ByVal pCode As String, ByVal pYear As Integer, ByVal pNo As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("Running_Update"), pCode, (pYear), (pNo))
    End Function

        Public Function Running_Delete(ByVal pCode As String, ByVal pYear As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("Running_Delete"), pCode, (pYear))
    End Function

#End Region
#Region "ReferenceValue"
    Public Function ReferenceValue_GetByDomainCode(DomainCode As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("ReferenceValue_GetByDomainCode"), DomainCode)
        Return ds.Tables(0)
    End Function

#End Region

#Region "PeriodTime"

    Public Function PeriodTime_GetAll(ByVal CompanyUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, "PeriodTime_GetAll", CompanyUID)
        Return ds.Tables(0)
    End Function
    Public Function PeriodTime_GetActive(CompanyUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, "PeriodTime_GetActive", CompanyUID)
        Return ds.Tables(0)

    End Function
    Public Function PeriodTime_GetSearch(CompanyUID As Integer, pSearch As String) As DataTable

        ds = SqlHelper.ExecuteDataset(ConnectionString, "PeriodTime_GetSearch", CompanyUID, pSearch)

        Return ds.Tables(0)


    End Function
    Public Function PeriodTime_CheckDuplicate(CompanyUID As Integer, pName As String) As Boolean
        ds = SqlHelper.ExecuteDataset(ConnectionString, "PeriodTime_CheckDuplicate", CompanyUID, pName)
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

    Public Function PeriodTime_GetByID(pid As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, "PeriodTime_GetByID", pid)
        Return ds.Tables(0)
    End Function

    Public Function PeriodTime_Add(CompanyUID As Integer, Name As String, StartDate As String, EndDate As String, StatusFlag As String)
        Return SqlHelper.ExecuteNonQuery(ConnectionString, "PeriodTime_Add", CompanyUID, Name, StartDate, EndDate, StatusFlag)
    End Function
    Public Function PeriodTime_Create(CompanyUID As Integer)
        Return SqlHelper.ExecuteNonQuery(ConnectionString, "PeriodTime_Create", CompanyUID)
    End Function

    Public Function PeriodTime_Update(UID As Integer, CompanyUID As Integer, Name As String, StartDate As String, EndDate As String, StatusFlag As String)
        Return SqlHelper.ExecuteNonQuery(ConnectionString, "PeriodTime_Update", UID, CompanyUID, Name, StartDate, EndDate, StatusFlag)
    End Function

    Public Function PeriodTime_GetByDivisionUID(CompanyUID As Integer, ByVal DivisionUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("PeriodTime_GetByDivisionUID"), CompanyUID, DivisionUID)
        Return ds.Tables(0)
    End Function

    Public Function PeriodTime_Get(CompanyUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("PeriodTime_Get"), CompanyUID)
        Return ds.Tables(0)
    End Function

    Public Function PeriodTime_GetByUID(ByVal pUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("PeriodTime_GetByUID"), pUID)
        Return ds.Tables(0)
    End Function

    Public Function PeriodTime_GetBySearch(CompanyUID As Integer, ByVal pKey As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("PeriodTime_GetBySearch"), CompanyUID, pKey)
        Return ds.Tables(0)
    End Function

    Public Function PeriodTime_Delete(ByVal PeriodTimeUID As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("PeriodTime_Delete"), PeriodTimeUID)
    End Function

#End Region

#Region "LawType"
    Public Function LawType_Get() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, "LawType_Get")
        Return ds.Tables(0)
    End Function

    Public Function LawType_Get4Select() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, "LawType_Get4Select")
        Return ds.Tables(0)
    End Function

    Public Function LawType_GetBySearch(KeySearch As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("LawType_GetBySearch"), KeySearch)
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

#Region "LawMaster"
    Public Function LawMaster_Get() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, "LawMaster_GetActive")
        Return ds.Tables(0)
    End Function

    Public Function LawMaster_Get4Select() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, "LawMaster_Get4Select")
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

#Region "BusinessType"
    Public Function BusinessType_Get() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, "BusinessType_Get")
        Return ds.Tables(0)
    End Function
    Public Function BusinessType_GetForLaw() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, "BusinessType_GetForLaw")
        Return ds.Tables(0)
    End Function
    Public Function BusinessType_Get4Select() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, "BusinessType_Get4Select")
        Return ds.Tables(0)
    End Function
    Public Function BusinessType_Get4Company() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, "BusinessType_Get4Company")
        Return ds.Tables(0)
    End Function

    Public Function BusinessType_GetBySearch(KeySearch As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("BusinessType_GetBySearch"), KeySearch)
        Return ds.Tables(0)
    End Function
    Public Function BusinessType_GetByUID(UID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("BusinessType_GetByUID"), UID)
        Return ds.Tables(0)
    End Function
    Public Function BusinessType_Delete(pID As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, "BusinessType_Delete", pID)
    End Function
    Public Function BusinessType_Save(UID As Integer, Name As String, Sort As Integer, StatusFlag As String) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, "BusinessType_Save", UID, Name, Sort, StatusFlag)
    End Function
#End Region

#Region "Ministry"
    Public Function Ministry_Get() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, "Ministry_Get")
        Return ds.Tables(0)
    End Function
    Public Function Ministry_Get4Select() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, "Ministry_Get4Select")
        Return ds.Tables(0)
    End Function
    Public Function Ministry_GetBySearch(KeySearch As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Ministry_GetBySearch"), KeySearch)
        Return ds.Tables(0)
    End Function
    Public Function Ministry_GetByUID(UID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Ministry_GetByUID"), UID)
        Return ds.Tables(0)
    End Function
    Public Function Ministry_Delete(pID As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, "Ministry_Delete", pID)
    End Function
    Public Function Ministry_Save(UID As Integer, Name As String, Sort As Integer, StatusFlag As String) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, "Ministry_Save", UID, Name, Sort, StatusFlag)
    End Function

#End Region

#Region "ActionStatus"

    Public Function ActionStatus_GetAll() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, "ActionStatus_GetAll")
        Return ds.Tables(0)
    End Function
    Public Function ActionStatus_GetActive() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, "ActionStatus_GetActive")
        Return ds.Tables(0)
    End Function

    Public Function ActionStatus_CheckDuplicate(pName As String) As Boolean
        ds = SqlHelper.ExecuteDataset(ConnectionString, "ActionStatus_CheckDuplicate", pName)
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
    Public Function ActionStatus_GetSearch(pSearch As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, "ActionStatus_GetSearch", pSearch)
        Return ds.Tables(0)
    End Function
    Public Function ActionStatus_GetByUID(pID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, "ActionStatus_GetByUID", pID)
        Return ds.Tables(0)
    End Function

    Public Function ActionStatus_Delete(pID As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, "ActionStatus_Delete", pID)
    End Function

    Public Function ActionStatus_Add(ValueCode As String, Descriptions As String, DisplayOrder As Integer, StatusFlag As String, CUser As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, "ActionStatus_Add", ValueCode, Descriptions, DisplayOrder, StatusFlag, CUser)
    End Function

    Public Function ActionStatus_Update(UID As Integer, ValueCode As String, Descriptions As String, DisplayOrder As Integer, StatusFlag As String, MUser As Integer)
        Return SqlHelper.ExecuteNonQuery(ConnectionString, "ActionStatus_Update", UID, ValueCode, Descriptions, DisplayOrder, StatusFlag, MUser)
    End Function
#End Region

#Region "Keyword"
    Public Function Keyword_Get() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, "Keyword_Get")
        Return ds.Tables(0)
    End Function
    Public Function Keyword_Get4Select() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, "Keyword_Get4Select")
        Return ds.Tables(0)
    End Function
    Public Function Keyword_GetBySearch(KeySearch As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Keyword_GetBySearch"), KeySearch)
        Return ds.Tables(0)
    End Function
    Public Function Keyword_GetByUID(UID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Keyword_GetByUID"), UID)
        Return ds.Tables(0)
    End Function
    Public Function Keyword_Delete(pID As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, "Keyword_Delete", pID)
    End Function
    Public Function Keyword_Save(UID As Integer, Name As String, Sort As Integer, StatusFlag As String) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, "Keyword_Save", UID, Name, Sort, StatusFlag)
    End Function
#End Region

#Region "FactoryType"
    Public Function FactoryType_Get() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, "FactoryType_Get")
        Return ds.Tables(0)
    End Function
    Public Function FactoryType_Get4Company() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, "FactoryType_Get4Company")
        Return ds.Tables(0)
    End Function

    Public Function FactoryType_GetForLaw() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, "FactoryType_GetForLaw")
        Return ds.Tables(0)
    End Function

    Public Function FactoryType_Get4Select() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, "FactoryType_Get4Select")
        Return ds.Tables(0)
    End Function
    Public Function FactoryType_GetBySearch(KeySearch As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("FactoryType_GetBySearch"), KeySearch)
        Return ds.Tables(0)
    End Function
    Public Function FactoryType_GetByUID(UID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("FactoryType_GetByUID"), UID)
        Return ds.Tables(0)
    End Function
    Public Function FactoryType_Delete(pID As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, "FactoryType_Delete", pID)
    End Function
    Public Function FactoryType_Save(UID As Integer, Name As String, Sort As Integer, StatusFlag As String) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, "FactoryType_Save", UID, Name, Sort, StatusFlag)
    End Function
#End Region

#Region "TemplateText"
    Public Function TemplateText_Get() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, "TemplateText_Get")
        Return ds.Tables(0)
    End Function
    Public Function TemplateText_Get4Select() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, "TemplateText_Get4Select")
        Return ds.Tables(0)
    End Function
    Public Function TemplateText_GetBySearch(KeySearch As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("TemplateText_GetBySearch"), KeySearch)
        Return ds.Tables(0)
    End Function
    Public Function TemplateText_GetByUID(UID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("TemplateText_GetByUID"), UID)
        Return ds.Tables(0)
    End Function
    Public Function TemplateText_Delete(pID As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, "TemplateText_Delete", pID)
    End Function
    Public Function TemplateText_Save(UID As Integer, Name As String) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, "TemplateText_Save", UID, Name)
    End Function
#End Region



End Class
