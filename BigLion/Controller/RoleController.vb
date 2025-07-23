Imports Microsoft.ApplicationBlocks.Data

Public Class RoleController
    Inherits BaseClass
    Dim ds As New DataSet
    Public Function GetRoles() As DataTable
        SQL = "select * from Roles "

        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.Text, SQL)
        Return ds.Tables(0)
    End Function

    Public Function GetRoles_ByID(id As Integer) As DataSet
        SQL = "select * from Roles where roleid=" & id
        Return SqlHelper.ExecuteDataset(ConnectionString, CommandType.Text, SQL)
    End Function

    Public Function Roles_Add(ByVal pCode As Integer, ByVal pName As String, desc As String, ByVal pStatus As Integer) As Integer
        'SQL = "insert into Roles (roleid,rolename,ispublic) values(" & pCode & ",'" & pName & "'," & pStatus & ")"
        'Return SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, SQL)
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("Roles_Add"), pCode, pName, desc, pStatus)
    End Function

    Public Function Roles_Update(ByVal pID_old As Integer, ByVal pID_new As Integer, ByVal pName As String, desc As String, ByVal pStatus As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, "Roles_Update", pID_old, pID_new, pName, desc, pStatus)
    End Function

    Public Function Roles_Delete(ByVal pID As Integer) As Integer
        SQL = "delete from Roles where roleid =" & pID
        Return SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, SQL)
    End Function


    Public Function UserRole_chkHasRole(ByVal pUser As String, roleID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("UserRole_chkHasRole"), pUser, roleId)
        Return ds.Tables(0)
    End Function



    'Public Function Country_Get() As DataTable

    '    Dim dt As New DataTable
    '    SQL = " select  *   from  Country   order by sort"
    '    dt = ExecuteDataTable(SQL)
    '    Return dt
    'End Function

    'Public Function PaymentMedthod_Get() As DataTable
    '    Dim dt As New DataTable
    '    SQL = " select  *   from  PaymentMethod   order by itemid "
    '    dt = ExecuteDataTable(SQL)
    '    Return dt
    'End Function

    'Public Function Project_Get(ByVal pID As String) As DataTable

    '    Dim dt As New DataTable
    '    SQL = " select  *   from  TRPT_Location  where  LocationID ='" & pID & "'"
    '    dt = ExecuteDataTable(SQL)
    '    Return dt
    'End Function



End Class
