Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports System.Globalization
Imports Microsoft.ApplicationBlocks.Data
Imports System.Web.UI

Public Class BaseClass : Inherits ApplicationBaseClass

    Friend Connection As SqlConnection
    Dim ds As New DataSet

    Public strTableName As String
    Public strKeyGen As String
    Public tblField() As stcField
    Public FieldSort As String

    'Private sqlSrvDatabase As String = "rsu_pps"
    Friend Transaction As SqlTransaction
    Public intTotalField As Integer = 0

    'Public Shared sqlServer As String
    'Public Shared sqlDatabase As String
    'Public Shared sqlUsername As String
    'Public Shared sqlPassword As String
    'Public Shared sqlReport As String
    'Public Shared ReportURL As String
    Public Shared ConnectionString As String
    'Public Shared PassPhase As String

#Region "Private Members"

    Private Const ProviderType As String = "seadragon"
    Public Const ModuleQualifier As String = ""
    Public Const ObjectQualifier As String = ""
    Public Const DatabaseOwner As String = ""

    'Public Const sqlServer As String = "NBTEE"
    'Public Const sqlDatabase As String = "CPAQA"
    'Public Const sqlUsername As String = "cpaadmin"
    'Public Const sqlPassword As String = "11223344"
    'Public Const ProjectPath As String = "http://www.acc-pharm.com"
    'Public Const PassPhase As String = "CPA@THEDEV"

    'Public Const ReportServerLocation As String = "http://127.0.0.1/ReportServer"
    'Public Const ReportServerURL As String = "http://127.0.0.1/ReportServer"
    'Public Const ReportServerPath As String = "/CPAQAReports"
    'Public Const ReportServerUser As String = "Teerapol"
    'Public Const ReportServerPassword As String = "3889"

    Public Const sqlServer As String = "192.168.10.3"
    Public Const sqlDatabase As String = "CPAQA"
    Public Const sqlUsername As String = "cpaadmin"
    Public Const sqlPassword As String = "Srr@CpA#$157"  'Srr@CpA#$157
    Public Const ProjectPath As String = "http://www.acc-pharm.com"
    Public Const PassPhase As String = "CPA@THEDEV"

    Public Const ReportServerLocation As String = "http://192.168.10.3/ReportServer"
    Public Const ReportServerURL As String = "http://192.168.10.3/ReportServer"
    Public Const ReportServerPath As String = "/CPAQAReports"
    Public Const ReportServerUser As String = "administrator"
    Public Const ReportServerPassword As String = "K1g9r8H2Pmbrk"

#End Region
    Public Structure stcField
        Private _fldName As String
        Private _fldValue As String
        Private _fldType As String
        Private _fldAffect As Boolean
        Private _fldLength As Integer

        Property fldName() As String
            Get
                Return _fldName
            End Get
            Set(ByVal Value As String)
                _fldName = Value
            End Set
        End Property
        Property fldValue() As String
            Get
                Return _fldValue
            End Get
            Set(ByVal Value As String)
                _fldValue = Value
            End Set
        End Property
        Property fldType() As String
            Get
                Return _fldType
            End Get
            Set(ByVal Value As String)
                _fldType = Value
            End Set
        End Property
        Property fldAffect() As Boolean
            Get
                Return _fldAffect
            End Get
            Set(ByVal Value As Boolean)
                _fldAffect = Value
            End Set
        End Property
        Property fldLength() As Integer
            Get
                Return _fldLength
            End Get
            Set(ByVal Value As Integer)
                _fldLength = Value
            End Set
        End Property

        Public Sub New(ByVal fValue As String)
            _fldValue = fValue
        End Sub
    End Structure

    Public Shared Function GetFullyQualifiedName(ByVal name As String) As String
        Return DatabaseOwner & ObjectQualifier & ModuleQualifier & name
    End Function

    Public Sub getConnectionString()
        'sqlServer = Convert.ToString(ConfigurationSettings.AppSettings("ServerPath"))
        'sqlDatabase = Convert.ToString(ConfigurationSettings.AppSettings("DatabaseName"))
        'sqlUsername = Convert.ToString(ConfigurationSettings.AppSettings("Username"))
        'sqlPassword = Convert.ToString(ConfigurationSettings.AppSettings("Password"))
        'sqlReport = Convert.ToString(ConfigurationSettings.AppSettings("ReportPath"))
        'ReportURL = Convert.ToString(ConfigurationSettings.AppSettings("ReportURL"))
        'PassPhase = Convert.ToString(ConfigurationSettings.AppSettings("PassPhase"))

        'sqlServer = "192.168.10.3"
        'sqlDatabase = "CPAQA"
        'sqlUsername = "cpaadmin"
        'sqlPassword = "Srr@CpA#$157"
        ''sqlReport = "http://www.acc-pharm.com"
        'ReportURL = "http://192.168.1.101/ReportServer"
        'PassPhase = "CPA@THEDEV"

        ConnectionString = "Data Source=" & sqlServer & ";Database=" & sqlDatabase & ";User Id=" & sqlUsername & ";Password=" & sqlPassword & ";"

    End Sub


    Public Sub New(Optional ByVal conn As SqlClient.SqlConnection = Nothing)
        getConnectionString()

        If Not IsNothing(conn) Then
            Me.Conn = conn
        End If

    End Sub

    Public Const ScriptTimeout As Integer = 60

    ' second
    Public Const SessionTimeout As Integer = 20

    ' minute
    Public Const MAXPERPAGE As Double = 30

    ' record(s) display per page.
    Public Sub InitializePage(ByVal p As Page)
        p.Session.Timeout = SessionTimeout
        p.Server.ScriptTimeout = ScriptTimeout
    End Sub

    Public Sub CheckSession(ByVal p As Page)
        If (Not (p.Request.Cookies("CPAQA")("userid")) Is Nothing) Then
            Return
        End If
        p.Response.Redirect("default.aspx")
    End Sub

    Public Sub CheckGroup(ByVal p As Page, ByVal permission As String)
        If (Not (p.Request.Cookies("CPAQA")("UserLevel")) Is Nothing) Then
            If permission.Contains(p.Request.Cookies("CPAQA")("UserLevel").ToString) Then
                Return
            End If
        End If
        p.Request.Cookies("CPAQA")("ErrorMessage") = "<br />คุณไม่ได้รับสิทธิ์ให้ใช้งานหน้านี้"
        p.Request.Cookies("CPAQA")("SendToURL") = "default.aspx"
        p.Response.Redirect("ErrorHandler.aspx")
    End Sub

    Public Property Trans() As SqlTransaction
        Get
            Return Transaction
        End Get
        Set(ByVal Value As SqlTransaction)
            Transaction = Value
        End Set
    End Property

    Public Property Conn() As SqlConnection
        Get
            Return Connection
        End Get
        Set(ByVal Value As SqlConnection)
            Connection = Value
        End Set
    End Property

    Public ReadOnly Property getConn() As SqlConnection
        Get
            Return Connection
        End Get
        'Set(ByVal Value As SqlConnection)
        '    Connection = Value
        'End Set
    End Property

    Public Function OpenConnection(Optional ByVal constr As String = "", Optional ByVal f_ShowMsg As Boolean = True) As Boolean
        Dim ConString As String = ""
        If constr.Length = 0 Then
            ConString = "Data Source=" & sqlServer & ";Database=" & sqlDatabase & ";User Id=" & sqlUsername & ";Password=" & sqlPassword & ";"
        End If
        Try
            Connection = New SqlConnection
            If Connection.State = ConnectionState.Open Then Connection.Close()
            Connection = New SqlConnection(ConString)
            Connection.Open()
            Return True
        Catch ex As Exception
            If f_ShowMsg Then MsgBox(ex.Message, MsgBoxStyle.OkOnly)
            Return False
        End Try
    End Function

    'Public Sub Cnn()
    '    With Conn
    '        If .State = ConnectionState.Open Then .Close()
    '        .ConnectionString = ConnectionString
    '        .Open()
    '    End With
    'End Sub


    Public Function beginTrans() As Boolean
        Dim f_return As Boolean
        Try
            Transaction = Connection.BeginTransaction
            f_return = True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, "Error")
            f_return = False
        End Try
        Return f_return
    End Function

    Public Function commitTrans() As Boolean
        Dim f_return As Boolean
        Try
            Transaction.Commit()
            f_return = True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, "Error")
            f_return = False
        End Try
        Return f_return
    End Function

    Public Function rollbackTrans() As Boolean
        Dim f_return As Boolean
        Try
            Transaction.Rollback()
            f_return = True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, "Error")
            f_return = False
        End Try
        Return f_return
    End Function

    Public Sub CloseConnection()
        Try
            If Not Connection Is Nothing Then
                If Connection.State <> ConnectionState.Closed Then
                    Connection.Close()
                End If
                Connection.Dispose()
                Connection = Nothing
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Function GET_DATE_SERVER() As Date
        Dim da As SqlDataAdapter
        Dim ds As New DataSet
        Dim sqlD As String
        sqlD = "select getdate() as dateServer"
        OpenConnection()
        da = New SqlDataAdapter(sqlD, Conn)
        da.Fill(ds, "DATESERVER")
        Return ds.Tables("DATESERVER").Rows(0).Item(0)
    End Function
    Public Function GET_DATETIME_SERVER() As DateTime
        Dim da As SqlDataAdapter
        Dim ds As New DataSet
        Dim sqlD As String
        sqlD = "select getdate() as dateServer"
        OpenConnection()
        da = New SqlDataAdapter(sqlD, Conn)
        da.Fill(ds, "DATESERVER")
        Return ds.Tables("DATESERVER").Rows(0).Item(0)
        ds = Nothing
    End Function


    Public Sub setSearchField(ByVal index As Integer, Optional ByVal type As String = "normal")
        'tblField(index).fldSearchType = type
        tblField(index).fldAffect = True
    End Sub

    Public Function getTableName() As String
        Return strTableName
    End Function

    Public Sub setFieldAffectValue(ByVal blnFieldAffect As Boolean)
        Dim i As Integer
        For i = 0 To Me.intTotalField
            Me.tblField(i).fldAffect = blnFieldAffect
        Next
    End Sub

    Public Sub copyObj(ByVal sourceObj As BaseClass)
        'Dim newObj As New SFISSULT
        Dim i As Integer
        For i = 0 To (sourceObj.tblField.Length - 1)
            Me.tblField(i) = sourceObj.tblField(i)
        Next
    End Sub

#Region "Exec Database"
    Public Function getStrWhere(ByVal aField() As stcField) As String
        Dim i As Integer
        Dim strWhere As String = ""
        For i = 0 To aField.Length - 1
            If strWhere.Length > 0 Then strWhere &= " and "
            Select Case aField(i).fldType
                Case "number", "integer", "double"
                    strWhere &= aField(i).fldName & " = " & aField(i).fldValue
                Case Else
                    strWhere &= aField(i).fldName & " = '" & aField(i).fldValue & "'"
            End Select
        Next
        Return strWhere
    End Function

    Public Function ExecuteDataTable(ByVal statement As String) As DataTable
        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.Text, statement)
        Return ds.Tables(0)
    End Function

    Public Function ExecuteDataQuery(ByVal statement As String) As Integer

        Return SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, statement)

    End Function
    Public Function ExecuteStoredProcedure(ByVal commandText As String, ByVal Parameters() As String) As Int32
        Dim dt As New DataTable
        Dim returnValue As Integer
        Dim i As Integer
        Dim objAdapter As New SqlDataAdapter
        Dim sqlCmd As SqlCommand

        Try

            Conn.Open()
            sqlCmd = New SqlCommand()
            sqlCmd.Connection = Conn
            sqlCmd.CommandText = commandText
            sqlCmd.CommandTimeout = 180
            sqlCmd.CommandType = CommandType.StoredProcedure
            objAdapter.SelectCommand = sqlCmd
            SqlCommandBuilder.DeriveParameters(objAdapter.SelectCommand)

            For i = 1 To Parameters.Length
                If (objAdapter.SelectCommand.Parameters(i).Direction = ParameterDirection.Input) Or (objAdapter.SelectCommand.Parameters(i).Direction = ParameterDirection.InputOutput) Then

                    objAdapter.SelectCommand.Parameters(i).Value = Parameters(i - 1)
                End If
            Next


            sqlCmd.ExecuteNonQuery()
            returnValue = (sqlCmd.Parameters("@RETURN_VALUE").Value)


            Return returnValue

        Catch ex As SqlException

        Finally

        End Try

        Return 1

    End Function

    Public Function ExecuteQuery(ByVal sql As String) As DataTable
        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim cmd As New SqlCommand

        Try
            Me.OpenConnection()
            cmd = New SqlCommand()
            cmd.Connection = Connection
            cmd.CommandText = sql
            da = New SqlDataAdapter()
            da.SelectCommand = cmd
            da.TableMappings.Add("Table", "Table")
            da.Fill(ds)
            dt = ds.Tables("Table")

        Catch ex As Exception
            ' MessageBox.Show("Could not Execute Query : " + ex.Message)
        Finally
            Me.CloseConnection()
        End Try

        Return dt

    End Function


    Public Function ExecuteNonQuery(ByVal sql As String) As Boolean

        Dim rowsAffect As Boolean
        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim cmd As New SqlCommand

        Try
            Me.OpenConnection()
            Me.beginTrans()
            cmd = Connection.CreateCommand()
            cmd.Connection = Connection
            cmd.Transaction = Transaction
            cmd.CommandText = sql
            rowsAffect = cmd.ExecuteNonQuery()
            Me.commitTrans()

        Catch ex As Exception
            '  MessageBox.Show(ex.Message)
        Finally
            Me.CloseConnection()
        End Try

        Return rowsAffect

    End Function


    Public Function PrepareFieldLenght(ByVal Field_Value As String, ByVal Field_Length As Integer) As String
        Dim result As String = ""
        Dim tmp_value As String = ""
        If Not Field_Value Is Nothing Then
            result = Field_Value
            If Field_Length > 0 And Field_Value.Length > Field_Length Then
                Dim CountChar As Integer
                Dim str As String
                Dim i As Integer
                i = 0
                tmp_value = Field_Value.Substring(0, Field_Length)
                result = tmp_value
                For i = 0 To tmp_value.Length - 1
                    str = tmp_value.Substring(i, 1)
                    If str = "'" Then
                        CountChar += 1
                    End If
                Next
                If Not (CountChar Mod 2 = 0) Then
                    i = tmp_value.Length - 1
                    While i >= 0
                        str = tmp_value.Substring(i, 1)
                        If str = "'" Then
                            result = tmp_value.Substring(0, i)
                            Exit While
                        End If
                        i -= 1
                    End While
                End If
            End If
        End If
        Return result
    End Function

#End Region

#Region "Generate ID"
    Public Function RunningNumber_New(ByVal code As String, Optional iYear As Integer = 0) As String
        Dim dsR As New DataSet

        Dim iY As Integer

        If iYear = 0 Then
            iY = GET_DATE_SERVER.Date.Year
        Else
            iY = iYear
        End If

        Dim strY As Integer = 0
        Dim sLastNumber As String = ""
        Dim i, NumDigit As Integer
        Dim sZero, sRunning As String
        Dim isCode, isYear As Boolean
        isCode = False
        isYear = False
        NumDigit = 0
        sZero = ""
        sRunning = ""

        If iY < 2500 Then
            strY = (iY + 543).ToString.Trim
        Else
            strY = iY.ToString.Trim
        End If
        strY = Right(strY, 2)

        ds = SqlHelper.ExecuteDataset(ConnectionString, "RunningConfig_GetByCode", code)

        If ds.Tables(0).Rows.Count > 0 Then

            NumDigit = ds.Tables(0).Rows(0)("NumberDigit")
            isCode = ConvertYN2Boolean(ds.Tables(0).Rows(0)("isCode"))
            isYear = ConvertYN2Boolean(ds.Tables(0).Rows(0)("isYear"))
            If String.Concat(ds.Tables(0).Rows(0)("isYear")) = "Y" Then
                sLastNumber = CStr(RunningNumber_GetLast(code, strY) + 1)
            Else
                sLastNumber = CStr(RunningNumber_GetLast(code, 0) + 1)
            End If


            For i = 1 To NumDigit - Len(sLastNumber)
                sZero = sZero & "0"
            Next

            If isCode = True Then
                sRunning = code + "-"
            End If
            If isYear = True Then
                sRunning &= Right(strY, 2)
            End If

            Return sRunning + sZero + sLastNumber
        Else
            'RunningConfiguration_New(code, "", "Y", "Y", NumDigit, "")
            'RunningNumber_InsertNewYear(code, iY)
            Return "Not Config Running"

        End If

        'genRunningNumber = code + yCode
        'genRunningNumber = genRunningNumber + Date.Today.Month.ToString("0#")
        'genRunningNumber = genRunningNumber + Date.Today.Day.ToString("0#")
    End Function
    Public Function RunningNumber_GetLast(ByVal pCode As String, pYear As Integer) As Integer
        Dim sqlRun As String
        Dim ds As New DataSet

        'If pYear > 0 Then
        '    If pYear < 2500 Then
        '        pYear = pYear + 543
        '    End If
        'End If

        sqlRun = "select LastRunning from  Running  where Code='" & pCode & "' and  YearCode=" & pYear
        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.Text, sqlRun)

        If ds.Tables(0).Rows.Count > 0 Then
            Return DBNull2Zero(ds.Tables(0).Rows(0).Item(0))
        Else
            InsertNewToRunning(pCode, pYear)
            Return 0
        End If

        ds = Nothing

    End Function
    Private Sub InsertNewToRunning(ByVal tCode As String, yCode As Integer)
        SQL = "Insert Into  Running(Code,YearCode,LastRunning)"
        SQL &= " Values('" & tCode
        SQL &= "'," & yCode & ",1)"
        ExecuteDataQuery(SQL)
    End Sub
    Public Sub RunningNumber_Update(ByVal Code As String)
        SqlHelper.ExecuteNonQuery(ConnectionString, "Running_Update", Code)
    End Sub
    'Public Function genReciveNumber(ByVal code As String) As String
    '    Dim yCode As String
    '    yCode = GET_DATE_SERVER.ToString("dd/MM/yyyy", DateFormat_TH)
    '    yCode = Right(yCode, 4)

    '    genReciveNumber = CStr(RunningNumber(code, yCode)) + "/" + yCode

    'End Function

    'Public Function genReqNumber(ByVal code As String) As Integer
    '    Dim yCode As String
    '    yCode = ConvertDate2DBString(GET_DATE_SERVER.ToString("dd/MM/yyyy", DateFormat_TH))
    '    yCode = Left(yCode, 4)

    '    genReqNumber = RunningNumber(code, yCode)

    'End Function
#End Region

    Public Function GetMaxID(pTable As String, pField As String) As Integer
        Dim sqlRun As String
        Dim da As SqlDataAdapter

        sqlRun = "select Max(" & pField & ") + 1  from  " & GetFullyQualifiedName(pTable)

        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.Text, sqlRun)

        If ds.Tables(0).Rows.Count > 0 Then
            Return CInt(ds.Tables(0).Rows(0).Item(0))
        Else
            Return 1
        End If

        ds = Nothing
    End Function

    Public Function ConvertStatusFlag2CHK(ByVal pVal As String) As Boolean
        If pVal = "A" Then
            Return True
        Else
            Return False
        End If
    End Function


End Class

Public Class ApplicationBaseClass
    Protected adapter As SqlDataAdapter
    Protected cmd As SqlCommand
    Protected trans As SqlTransaction
    Protected _Error As String

    Property Message() As String
        Get
            Return Me._Error
        End Get
        Set(ByVal Value As String)
            Me._Error = Value
        End Set
    End Property

End Class


