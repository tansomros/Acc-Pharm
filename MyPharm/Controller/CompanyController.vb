Imports Microsoft.ApplicationBlocks.Data

Public Class CompanyController

        Inherits BaseClass
    Public ds As New DataSet

#Region "Company"

    Public Function Company_Get() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Company_Get"))
        Return ds.Tables(0)
    End Function
    Public Function Company_GetActive() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Company_GetActive"))
        Return ds.Tables(0)
    End Function

    Public Function Company_GetByUID(pUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Company_GetByUID"), pUID)
        Return ds.Tables(0)
    End Function
    Public Function Company_GetPackage(pUID As Integer) As Integer
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Company_GetPackageNo"), pUID)
        Return ds.Tables(0).Rows(0)(0)
    End Function

    Public Function Company_GetPackageDetail(pUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Company_GetPackageDetail"), pUID)
        Return ds.Tables(0)
    End Function

    Public Function PackageNo_GetByUserID(pUID As Integer) As Integer
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("PackageNo_GetByUserID"), pUID)
        Return ds.Tables(0).Rows(0)(0)
    End Function

    Public Function Company_GetUID(Code As String) As Integer
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Company_GetUID"), Code)
        If ds.Tables(0).Rows.Count > 0 Then
            Return DBNull2Zero(ds.Tables(0).Rows(0)(0))
        Else
            Return 0
        End If
    End Function

    Public Function Company_GetBySearch(pKey As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Company_GetBySearch"), pKey)
        Return ds.Tables(0)
    End Function

    Public Function Customer_GetExpireDate(CompanyUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Customer_GetExpireDate"), CompanyUID)
        Return ds.Tables(0)
    End Function


    Public Function Customer_GetForAlert() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Customer_GetForAlert"))
        Return ds.Tables(0)
    End Function

    Public Function Company_Save(ByVal CompanyUID As Integer, ByVal CompanyCode As String, ByVal NameTH As String, ByVal NameEN As String, ByVal Branch As String, ByVal VATID As String, ByVal AddressNumber As String, ByVal Lane As String, ByVal Road As String, ByVal SubDistrict As String, ByVal District As String, ByVal Province As String, ByVal ZipCode As String, ByVal Country As String, ByVal Telephone As String, ByVal Fax As String, ByVal Email As String, ByVal Website As String, Status As String, BusinessTypeUID As Integer, PhaseUID As Integer, ByVal MaxPerson As Integer, ByVal UpdBy As Integer, Employee As Integer, FactoryTypeUID As Integer, FactoryGroupUID As Integer, PackageNo As Integer, ContactName As String, ContactMail As String, AddressInvoice As String, StartDate As String, DueDate As String) As Integer

        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("Company_Save"), CompanyUID, CompanyCode, NameTH, NameEN, Branch, VATID, AddressNumber, Lane, Road, SubDistrict, District, Province, ZipCode, Country, Telephone, Fax, Email, Website, Status, BusinessTypeUID, PhaseUID, MaxPerson, Employee, FactoryTypeUID, FactoryGroupUID, PackageNo, UpdBy, ContactName, ContactMail, AddressInvoice, StartDate, DueDate)

    End Function

    Public Function Company_UpdatePayinFile(ByVal CompanyUID As Integer, ByVal Payinfile As String) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("Company_UpdatePayinFile"), CompanyUID, Payinfile)
    End Function


    Public Function Company_AddFromRegister(ByVal CompanyUID As Integer, ByVal RegisterID As Integer, ByVal NameTH As String, ByVal AddressNumber As String, ByVal Lane As String, ByVal Road As String, ByVal SubDistrict As String, ByVal District As String, ByVal Province As String, ByVal ZipCode As String, ByVal Country As String, ByVal Telephone As String, ByVal Email As String, ByVal Website As String, BusinessTypeUID As Integer, ByVal UpdBy As Integer, AddressInvoice As String) As Integer

        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("Company_AddFromRegister"), CompanyUID, RegisterID, NameTH, AddressNumber, Lane, Road, SubDistrict, District, Province, ZipCode, Country, Telephone, Email, Website, BusinessTypeUID, UpdBy, AddressInvoice)

    End Function

    Public Function Customer_UpdatePackage(ByVal CompanyUID As Integer, PackageNo As Integer, StartDate As String, DueDate As String, ByVal StatusFlag As String, ByVal ContactName As String, ByVal ContactMail As String, MUser As Integer) As Integer

        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("Customer_UpdatePackage"), CompanyUID, PackageNo, StartDate, DueDate, ContactName, ContactMail)
    End Function


    Public Function Company_CheckOverMaxLimit(CompUID As Integer) As Boolean
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Company_CheckOverMaxLimit"), CompUID)
        If ds.Tables(0).Rows(0)(0) = 0 Then
            Return False  'not over limit
        Else
            Return True ' over limit
        End If
    End Function

    Public Function Company_Delete(ByVal CompanyUID As Integer) As Integer
            Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("Company_Delete"), CompanyUID)
        End Function

    Public Function Customer_GetRemainExpire() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Customer_GetRemainExpire"))
        Return ds.Tables(0)
    End Function

#End Region
#Region "Keyword Detail"
    Public Function CompanyKeyword_Delete(ByVal CompanyUID As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("CompanyKeyword_Delete"), CompanyUID)
    End Function

    Public Function CompanyKeyword_Save(ByVal CompanyUID As Integer, ByVal CateUID As Integer, ByVal UpdBy As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("CompanyKeyword_Save"), CompanyUID, CateUID, UpdBy)
    End Function
    Public Function CompanyKeyword_Get(CompanyUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("CompanyKeyword_Get"), CompanyUID)
        Return ds.Tables(0)
    End Function

#End Region

#Region "Category Detail"
    Public Function CompanyCategoryDetail_Delete(ByVal CompanyUID As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("CompanyCategoryDetail_Delete"), CompanyUID)
    End Function

    Public Function CompanyCategoryDetail_Save(ByVal CompanyUID As Integer, ByVal CateUID As Integer, ByVal UpdBy As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("CompanyCategoryDetail_Save"), CompanyUID, CateUID, UpdBy)
    End Function
    Public Function CompanyCategoryDetail_Get(CompanyUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("CompanyCategoryDetail_Get"), CompanyUID)
        Return ds.Tables(0)
    End Function

#End Region

#Region "Invoice"
    Public Function Invoice_Get() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Invoice_Get"))
        Return ds.Tables(0)
    End Function
    Public Function Invoice_GetToday() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Invoice_GetToday"))
        Return ds.Tables(0)
    End Function
    Public Function Invoice_Add(ByVal InvoiceNo As String, ByVal InvoiceDate As String, ByVal CustomerID As Integer, ByVal InvoiceType As String, ByVal Descriptions As String, ByVal UnitPrice As Double, ByVal Vat As Double, ByVal Amount As Double, ByVal NetTotal As Double, ByVal UpdBy As Integer) As Integer

        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("Invoice_Add"), InvoiceNo, InvoiceDate, CustomerID, InvoiceType, Descriptions, UnitPrice, Vat, Amount, NetTotal, UpdBy)

    End Function
#End Region

End Class

