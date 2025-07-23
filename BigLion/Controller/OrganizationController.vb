Imports Microsoft.ApplicationBlocks.Data

Public Class OrganizationController

        Inherits BaseClass
        Public ds As New DataSet
        Public Function Organization_Get() As DataTable
            ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Organization_Get"))
            Return ds.Tables(0)
        End Function
        Public Function Organization_GetByUID(pUID As Integer) As DataTable
            ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Organization_GetByUID"), pUID)
            Return ds.Tables(0)
        End Function
        Public Function Organization_GetByCode(pCode As String) As DataTable
            ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Organization_GetByCode"), pCode)
            Return ds.Tables(0)
        End Function

        Public Function Organization_GetCodeByUID(pUID As Integer) As String
            ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Organization_GetCodeByUID"), pUID)
            If ds.Tables(0).Rows.Count > 0 Then
                Return DBNull2Str(ds.Tables(0).Rows(0)(0))
            Else
                Return ""
            End If
        End Function

    'Public Function Organization_Add(ByVal OrganizationCode As String, ByVal NameTH As String, ByVal NameEN As String, ByVal VATID As String, ByVal AddressNumber As String, ByVal Lane As String, ByVal Road As String, ByVal SubDistrict As String, ByVal District As String, ByVal Province As String, ByVal ZipCode As String, ByVal Country As String, ByVal Telephone As String, ByVal Fax As String, ByVal Email As String, ByVal Website As String, ByVal Logo As Byte(), ByVal AddressTH As String, ByVal AddressEN As String) As Integer

    '    Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("Organization_Add"), OrganizationCode, NameTH, NameEN, VATID, AddressNumber, Lane, Road, SubDistrict, District, Province, ZipCode, Country, Telephone, Fax, Email, Website, Logo, AddressTH, AddressEN)

    'End Function
    Public Function Organization_Update(ByVal OrganizationUID As Integer, ByVal OrganizationCode As String, ByVal NameTH As String, ByVal NameEN As String, ByVal Branch As String, ByVal VATID As String, ByVal AddressNumber As String, ByVal Lane As String, ByVal Road As String, ByVal SubDistrict As String, ByVal District As String, ByVal Province As String, ByVal ZipCode As String, ByVal Country As String, ByVal Telephone As String, ByVal Fax As String, ByVal Email As String, ByVal Website As String, ByVal UpdBy As Integer, ContactName As String, ContactMail As String, AddressInvoice As String) As Integer

        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("Organization_Update"), OrganizationUID, OrganizationCode, NameTH, NameEN, Branch, VATID, AddressNumber, Lane, Road, SubDistrict, District, Province, ZipCode, Country, Telephone, Fax, Email, Website, UpdBy, ContactName, ContactMail, AddressInvoice)

    End Function


    Public Function Organization_Delete(ByVal OrganizationUID As Integer) As Integer
            Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("Organization_Delete"), OrganizationUID)
        End Function
    End Class

