Imports Microsoft.ApplicationBlocks.Data
Public Class SystemConfigController
    Inherits BaseClass
    Dim ds As New DataSet

    Public Function SystemConfig_Get() As DataTable
        SQL = "select * from SystemConfig order by itemID "
        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.Text, SQL)
        Return ds.Tables(0)
    End Function

    Public Function SystemConfig_GetAll(Code As String) As DataTable
        SQL = "select *  from SystemConfig where CodeConfig='" & Code & "'"
        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.Text, SQL)
        Return ds.Tables(0)
    End Function


    Public Function SystemConfig_GetByCode(id As String) As String
        SQL = "select ValueConfig  from SystemConfig where CodeConfig='" & id & "'"
        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.Text, SQL)
        If ds.Tables(0).Rows.Count > 0 Then
            Return ds.Tables(0).Rows(0)(0).ToString
        Else
            Return ""
        End If
    End Function

    Public Function DataConfig_Add(code As String, pValue As String, desc As String) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "DataConfig_Add", code, pValue, desc)
    End Function
    Public Function DataConfig_Update(code As String, pValue As String, desc As String) As Integer
        'SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "DataConfig_Update", code, pValue, desc)

        SQL = "Update SystemConfig set ValueConfig='" & pValue & "',[Description]='" & desc & "'  Where CodeConfig='" & code & "'"
        Return SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, SQL)
    End Function

    Public Function DataConfig_UpdateValue(code As String, pValue As String) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, "DataConfig_UpdateValue", code, pValue)
    End Function


End Class
 