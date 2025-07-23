Imports Microsoft.ApplicationBlocks.Data
Public Class RegisterController
    Inherits BaseClass
    Dim ds As New DataSet

    Public Function Register_GetByType(ByVal RegisterType As Integer) As DataTable

        ds = SqlHelper.ExecuteDataset(ConnectionString, "Register_GetByType", RegisterType)
        Return ds.Tables(0)
    End Function

    Public Function Register_GetMajorByType(ByVal RegisterType As Integer) As DataTable

        ds = SqlHelper.ExecuteDataset(ConnectionString, "Register_GetMajorByType", RegisterType)
        Return ds.Tables(0)
    End Function
    Public Function Register_GetMajorEnglishByType(ByVal RegisterType As Integer) As DataTable

        ds = SqlHelper.ExecuteDataset(ConnectionString, "Register_GetMajorEnglishByType", RegisterType)
        Return ds.Tables(0)
    End Function
    Public Function Register_GetStaff(RegisterType As Integer) As DataTable

        ds = SqlHelper.ExecuteDataset(ConnectionString, "Register_GetStaff", RegisterType)
        Return ds.Tables(0)
    End Function
    Public Function Register_GetBoard(ByVal Level As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, "Register_GetBoard", Level)
        Return ds.Tables(0)
    End Function

    Public Function Register_GetLeader(RegisterType As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, "Register_GetLeader", RegisterType)
        Return ds.Tables(0)
    End Function

    Public Function Register_Get4User(ByVal RegisterType As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, "Register_Get4User", RegisterType)
        Return ds.Tables(0)
    End Function
    Public Function Location_GetByRegisterID(id As Integer) As Integer

        ds = SqlHelper.ExecuteDataset(ConnectionString, "Location_GetByRegisterID", id)
        If ds.Tables(0).Rows.Count > 0 Then
            Return DBNull2Zero(ds.Tables(0).Rows(0)(0))
        Else
            Return 0
        End If


    End Function
    Public Function Register_GetByID(ByVal RegisterID As Integer) As DataTable

        ds = SqlHelper.ExecuteDataset(ConnectionString, "Register_GetByID", RegisterID)
        Return ds.Tables(0)
    End Function
    Public Function Register_GetBySearch(ByVal RegisterType As String, Search As String) As DataTable

        ds = SqlHelper.ExecuteDataset(ConnectionString, "Register_GetBySearch", RegisterType, Search)
        Return ds.Tables(0)
    End Function
    Public Function GetRegister_ByType(id As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, "Registers_GetByType", id)
        Return ds.Tables(0)
    End Function
    Public Function GetRegister_SearchByType(ptype As String, pkey As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, "Registers_GetSearch", ptype, pkey)
        Return ds.Tables(0)
    End Function

    Public Function Register_GetRegisterID(ByVal RegisterType As Integer, EmpID As String, NameTH As String, NameEN As String) As Integer

        ds = SqlHelper.ExecuteDataset(ConnectionString, "Register_GetRegisterID", RegisterType, EmpID, NameTH, NameEN)
        If ds.Tables(0).Rows.Count > 0 Then
            If DBNull2Zero(ds.Tables(0).Rows(0)(0)) > 0 Then
                Return DBNull2Zero(ds.Tables(0).Rows(0)(0))
            Else
                Return 0
            End If
        Else
            Return 0
        End If

    End Function

    Public Function Teacher_Add(ByVal pPrefix As String, ByVal pFName As String, ByVal pLName As String, pPosID As Integer, pPosition As String, pDeptID As Integer, ByVal pDeptName As String, status As String) As Integer

        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("Teacher_Add"), pPrefix, pFName, pLName, pPosID, pPosition, pDeptID, pDeptName, status)
    End Function
    Public Function Register_Add(ByVal pPrefix As Integer, ByVal pFName As String, ByVal pLName As String, pPosition As String, pMail As String, ByVal pType As String, pLocation As Integer) As Integer

        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("Register_Add"), pPrefix, pFName, pLName, pPosition, pMail, pType, pLocation)
    End Function

    Public Function Register_Update(ByVal RegisterID As Integer, Prefix As Integer, FirstName As String, LastName As String, NickName As String, Gender As String, PositionID As Integer, PositionName As String, DeptID As Integer, DeptName As String, Email As String, Telephone As String, MobilePhone As String, Address As String, District As String, City As String, ProvinceID As Integer, ProvinceName As String, ZipCode As String, PicturePath As String, UpdateBy As String) As Integer


        Return SqlHelper.ExecuteNonQuery(ConnectionString, "Register_Update", RegisterID, Prefix, FirstName, LastName, NickName, Gender, PositionID, PositionName, DeptID, DeptName, Email, Telephone, MobilePhone, Address, District, City, ProvinceID, ProvinceName, ZipCode, PicturePath, UpdateBy)

    End Function
    Public Function Register_Save(ByVal RegisterID As Integer, ByVal PersonType As String, ByVal ContactName As String, ByVal CompanyName As String, ByVal BusinessTypeID As Integer, ByVal Tel As String, Email As String, AddressNo As String, Moo As String, Soi As String, Road As String, Subdistrict As String, District As String, ProvinceID As Integer, Zipcode As String, AddressInvoice As String, WebSite As String, isErgonomic As String, isLA As String, isIncident As String, isSafetyCulture As String) As Integer

        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("Register_Save"), RegisterID, PersonType, ContactName, CompanyName, BusinessTypeID, Tel, Email, AddressNo, Moo, Soi, Road, Subdistrict, District, ProvinceID, Zipcode, AddressInvoice, WebSite, isLA, isErgonomic, isIncident, isSafetyCulture)
    End Function

    Public Function RegisterWork_Save(ByVal RegisterID As Integer, Award As String, Course_Main As String, Course_Coordinatior As String, MUser As Integer) As Integer

        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("RegisterWork_Save"), RegisterID, Award, Course_Main, Course_Coordinatior, MUser)
    End Function
    Public Function Register_UpdateActiveStatus(ByVal RegisterID As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, "Register_UpdateActiveStatus", RegisterID)
    End Function
    Public Function Register_UpdateFileName(ByVal RegisterID As Integer, fname As String) As Integer

        Return SqlHelper.ExecuteNonQuery(ConnectionString, "Register_UpdateFileName", RegisterID, fname)

    End Function

    Public Function Register_Delete(ByVal RegisterID As Integer) As Integer

        Return SqlHelper.ExecuteNonQuery(ConnectionString, "Register_Delete", RegisterID)

    End Function
    Public Function RPT_Register_HeadingCV(ByVal lang As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, "RPT_Register_HeadingCV", lang)
        Return ds.Tables(0)
    End Function
    Public Function RPT_Register_PrintCV(ByVal RegisterID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, "RPT_Register_PrintCV", RegisterID)
        Return ds.Tables(0)
    End Function
    Public Function RPT_Register_Education(ByVal RegisterID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, "RPT_Register_Education", RegisterID)
        Return ds.Tables(0)
    End Function
    Public Function RPT_Register_Research(ByVal RegisterID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, "RPT_Register_Research", RegisterID)
        Return ds.Tables(0)
    End Function
    Public Function RPT_Register_Training(ByVal RegisterID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, "RPT_Register_Training", RegisterID)
        Return ds.Tables(0)
    End Function
    Public Function RPT_Register_Work(ByVal RegisterID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, "RPT_Register_Work", RegisterID)
        Return ds.Tables(0)
    End Function

    Public Function Teacher_UpdateSmall(ByVal RegisterID As Integer, Prefix As String, FirstName As String, LastName As String, pPosID As Integer, PositionName As String, pDeptID As Integer, DeptName As String, UpdateBy As String, status As String) As Integer

        Return SqlHelper.ExecuteNonQuery(ConnectionString, "Teacher_UpdateSmall", RegisterID, Prefix, FirstName, LastName, pPosID, PositionName, pDeptID, DeptName, UpdateBy, status)

    End Function

End Class

