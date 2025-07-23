Imports Microsoft.ApplicationBlocks.Data
Public Class PharmacistController
    Inherits BaseClass
    Dim ds As New DataSet
    Public Function Pharmacist_Get(id As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, "Pharmacist_Get", id)
        Return ds.Tables(0)
    End Function
    Public Function Pharmacist_GetUID(LocationUID As Integer, Name As String, License As String) As Integer
        ds = SqlHelper.ExecuteDataset(ConnectionString, "Pharmacist_GetUID", LocationUID, Name, License)
        If ds.Tables(0).Rows.Count > 0 Then
            Return DBNull2Zero(ds.Tables(0).Rows(0)(0))
        Else
            Return 0
        End If
    End Function
    Public Function Pharmacist_GetName(UID As Integer) As String
        ds = SqlHelper.ExecuteDataset(ConnectionString, "Pharmacist_GetName", UID)
        If ds.Tables(0).Rows.Count > 0 Then
            Return String.Concat(ds.Tables(0).Rows(0)(0))
        Else
            Return ""
        End If
    End Function

    Public Function PharmacistImage_Get(LocationUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, "PharmacistImage_Get", LocationUID)
        Return ds.Tables(0)
    End Function
    Public Function PharmacistTime_Get(PharmacistUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, "PharmacistTime_Get", PharmacistUID)
        Return ds.Tables(0)
    End Function
    Public Function PharmacistTime_GetByCode(LocationUID As Integer, LicenseNo As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, "PharmacistTime_GetByCode", LocationUID, LicenseNo)
        Return ds.Tables(0)
    End Function


    Public Function GetPharmacist() As DataTable
        SQL = "select * from  View_Pharmacists  order by Firstname "
        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.Text, SQL)
        Return ds.Tables(0)
    End Function

    Public Function GetPharmacistName(pCode As Integer) As String
        Dim strName As String
        SQL = "select  FirstName,LastName  from  Pharmacists  Where PharmacistID= " & pCode
        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.Text, SQL)
        strName = String.Concat(ds.Tables(0).Rows(0)(0)) & " " & String.Concat(ds.Tables(0).Rows(0)(1))
        Return strName
    End Function

    Public Function GetPharmacist_ByID(id As Integer) As DataTable
        SQL = "select * from Pharmacist where UID=" & id
        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.Text, SQL)
        Return ds.Tables(0)
    End Function

    Public Function GetPharmacist_BySearch(id As String) As DataTable
        SQL = "select * from View_Pharmacists where PharmacistID like '%" & id & "%' OR  FirstName like '%" & id & "%' OR  LocationID like '%" & id & "%' OR  LocationName like '%" & id & "%'"
        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.Text, SQL)
        Return ds.Tables(0)
    End Function

    Public Function GetPharmacist_notUserBySearch(ptype As String, pkey As String) As DataTable
        SQL = "SELECT     *  FROM    Pharmacists WHERE  (UserID is null) and PharmacistType='" & ptype & "' and  PharmacistID like '%" & pkey & "%' OR  FirstName like '%" & pkey & "%'"
        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.Text, SQL)
        Return ds.Tables(0)
    End Function


    Public Function GetPharmacist_ByLocationSearch(Lid As String, pKey As String) As DataTable
        SQL = "select * from View_Pharmacists  where  LocationID='" & Lid & "' AND (PharmacistID like '%" & pKey & "%' OR  FirstName like '%" & pKey & "%')"
        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.Text, SQL)
        Return ds.Tables(0)
    End Function

    Public Function Pharmacist_GetLocationByUserID(id As Integer) As Integer
        SQL = "select LocationID from  Pharmacists  where UserID=" & id
        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.Text, SQL)
        Return DBNull2Zero(ds.Tables(0).Rows(0)(0))
    End Function

    Public Function GetLocation_ByPharmacistID(id As Integer) As Integer
        SQL = "select LocationID  from Pharmacists where PharmacistID=" & id
        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.Text, SQL)
        Return DBNull2Zero(ds.Tables(0).Rows(0)(0))

    End Function

    Public Function Pharmacist_Add(ByVal PName As String, ByVal PLicense As String, WorkType As String, WorkTime As String, LocationID As String, UpdateBy As String) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("Pharmacist_Add"), PName, PLicense, WorkType, WorkTime, LocationID, UpdateBy)
    End Function
    Public Function PharmacistTime_Add(ByVal LocationUID As Integer, ByVal PUID As Integer, License As String, pDay As String, ByVal pStart As String, pEnd As String, Cuser As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("PharmacistTime_Add"), LocationUID, PUID, License, pDay, pStart, pEnd, Cuser)
    End Function

    Public Function Pharmacist_Update(ByVal UID As Integer, ByVal PName As String, ByVal PLicense As String, WorkType As String, WorkTime As String, LocationID As String, UpdateBy As String) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("Pharmacist_Update"), UID, PName, PLicense, WorkType, WorkTime, LocationID, UpdateBy)
    End Function

    Public Function Pharmacist_UpdateUserIDandMail(ByVal PharmacistID As Integer, userid As Integer, mail As String) As Integer

        Return SqlHelper.ExecuteNonQuery(ConnectionString, "Pharmacist_UpdateUserIDandMail", PharmacistID, userid, mail)

    End Function
    Public Function Pharmacist_UpdateImgName(ByVal PharmacistUID As Integer, ImgName As String) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, "Pharmacist_UpdateImgName", PharmacistUID, ImgName)
    End Function

    Public Function Pharmacist_Delete(ByVal pID As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, "Pharmacist_Delete", pID)
    End Function

    Public Function PharmacistTime_Delete(ByVal pID As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, "PharmacistTime_Delete", pID)
    End Function

End Class
