Imports System.IO
Imports System.Globalization
Imports System.Text.RegularExpressions
Imports System.Net

Public Module modGlobal
#Region "Declaration Parameter"


    ' Public ProjectID As String
    Public isAdd As Boolean
    'Public d As String
    'Public m As String
    'Public y As String
    Public SQL As String
    'Public inRow As Integer = 0
    'Public pathPic As String = ""

    'Public UserID As Integer = 0
    'Public NameOfUser As String = ""
    'Public UserRole As String

    'Public RegName As String
    'Public RegSurname As String
    'Public RegID As Integer

    'Public RegType As String
    'Public RegCardID As String

    'Public DateFormat As IFormatProvider = New System.Globalization.CultureInfo("en-US")

    Public DateFormat_TH As IFormatProvider = New System.Globalization.CultureInfo("th-TH")

    Public dtfInfo As DateTimeFormatInfo

    'Public pnV As Boolean = False
    Public Rate_ExBed_Adult As Double = 0.0
    Public Rate_ExBed_Child As Double = 0.0

    Public bActive As Integer = 1
    Public binActive As Integer = 0

    'Public PictureUser As String = ConfigurationSettings.AppSettings("PictureUser")
    'Public DownloadPath As String = ConfigurationSettings.AppSettings("DownloadPath")
    'Public tmpUpload As String = ConfigurationSettings.AppSettings("tmpUpload")
    'Public ReportPath As String = ConfigurationSettings.AppSettings("ReportPath")
    'Public DocumentUpload As String = ConfigurationSettings.AppSettings("DocumentUpload")
    'Public DocumentRequest As String = ConfigurationSettings.AppSettings("DocumentRequest")
    'Public DocumentLocation As String = ConfigurationSettings.AppSettings("DocumentLocation")
    'Public DocumentAction As String = ConfigurationSettings.AppSettings("DocumentAction")
    'Public PictureRequest As String = ConfigurationSettings.AppSettings("PictureRequest")
    'Public CourseImage As String = ConfigurationSettings.AppSettings("CourseImage")
    'Public ElearningResource As String = ConfigurationSettings.AppSettings("ElearningResource")
    'Public ImageNews As String = ConfigurationSettings.AppSettings("ImageNews")
    'Public ImageCoverNews As String = ConfigurationSettings.AppSettings("ImageCoverNews")

    'Public ReportsName As String = ""
    Public Reportskey As String = ""
    Public FagRPT As String = ""
    Public ReportParameter() As String
    Public ReportName As String = ""
    Public ReportTitle As String = ""
    'Public FileName As String = ""
    Public SelectionFomula As String = ""
#End Region

#Region "Const_Data"
    Public Const ACTTYPE_LOG As String = "LOGIN"
    Public Const ACTTYPE_ADD As String = "ADD"
    Public Const ACTTYPE_UPD As String = "UPDATE"
    Public Const ACTTYPE_DEL As String = "DELETE"
    Public Const ACTTYPE_FND As String = "FIND"
    Public Const ACTTYPE_FGT As String = "FORGOT PASS"
    Public Const ACTTYPE_PRC As String = "PROCESS"

    'Public Const REF_PPE As String = "PPE"

    'Public Const ACTION_REL As String = "0" ' รอการประเมินผลความสอดคล้อง
    'Public Const ACTION_ASM As String = "1" ' ประเมินผลความสอดคล้องแล้ว
    'Public Const ACTION_WAIT As String = "2" 'ส่งเพื่อรอการอนุมัติ 
    'Public Const ACTION_APPROVED As String = "3" 'อนุมัติแล้ว  
    'Public Const ACTION_DONE As String = "4"  ' ดำเนินการประเมินแล้ว 
    'Public Const ACTION_REJECT As String = "5" 'ไม่อนุมัติ ส่งกลับให้ประเมินใหม่


    'Public Const LEGAL_REG As String = "1" ' ลงทะเบียน
    'Public Const LEGAL_WAIT As String = "2" 'รอการอนุมัติ 
    'Public Const LEGAL_APPROVED As String = "3" 'อนุมัติแล้ว  
    'Public Const LEGAL_DONE As String = "4"  ' ดำเนินการประเมินแล้ว 


#Region "Running Code"
    'Public Const CODE_REQ_NEW As String = "NEW"
    'Public Const CODE_REQ_RENEW As String = "REN"
    'Public Const CODE_REQ_UPD As String = "MOD"
    'Public Const CODE_REQ_CHK As String = "CHK"
    Public Const CODE_REQ As String = "REQ"
    Public Const CODE_CMP As String = "CMP"
    Public Const CODE_POST As String = "POS"

    Public Const CODE_COMPANY As String = "C"
    Public Const CODE_INVOICE As String = "I"

    'Public Const CODE_FRR As String = "FR"
    'Public Const CODE_ACCIDENT As String = "ACD"
    'Public Const CODE_BOC As String = "BO"
    'Public Const CODE_RTW As String = "RW"

    'Public Const CODE_COMPANY As String = "C"
    'Public Const CODE_HOSPITAL As String = "H"
    'Public Const CODE_POSITION As String = "J" 

#End Region

#End Region

#Region "Genaral Function"
    Public Function GetIPAddress() As String
        Dim context As System.Web.HttpContext = System.Web.HttpContext.Current
        Dim sIPAddress As String = context.Request.ServerVariables("HTTP_X_FORWARDED_FOR")
        If String.IsNullOrEmpty(sIPAddress) Then
            Return context.Request.ServerVariables("REMOTE_ADDR")
        Else
            Dim ipArray As String() = sIPAddress.Split(New [Char]() {","c})
            Return ipArray(0)
        End If
    End Function
    Public Function GetFQDN() As String
        Dim domainName As String = NetworkInformation.IPGlobalProperties.GetIPGlobalProperties().DomainName
        Dim hostName As String = Dns.GetHostName()
        Dim fqdn As String

        If Not hostName.Contains(domainName) Then
            fqdn = hostName & "." & domainName
        Else
            fqdn = hostName
        End If

        Return fqdn
    End Function
    Public Function DisplayLicenseStatus(st As String) As String
        Dim STN As String = ""
        Select Case st
            Case "X"
                STN = "ยกเลิก"
            Case "R"
                STN = "คงอยู่(อยู่ระหว่างต่ออายุ)"
            Case "A"
                STN = "คงอยู่"
            Case "N"
                STN = "ไม่สมบูรณ์(รอการตรวจสอบผู้มีหน้าที่ปฏิบัติการในใบอนุญาต)"
            Case "E"
                STN = "หมดอายุ"
        End Select
        Return STN
    End Function
    Public Function ConvertLicenseStatus(st As String) As String
        Dim STN As String = ""
        Select Case st
            Case "ยกเลิก"
                STN = "X"
            Case "คงอยู่(อยู่ระหว่างต่ออายุ)"
                STN = "R"
            Case "คงอยู่"
                STN = "A"
            Case "ไม่สมบูรณ์(รอการตรวจสอบผู้มีหน้าที่ปฏิบัติการในใบอนุญาต)"
                STN = "N"
            Case "หมดอายุ"
                STN = "E"
        End Select
        Return STN
    End Function

    Public Function chkFileExist(ByVal FileRptPath As String) As Boolean
        Dim F As New FileInfo(FileRptPath)
        Return F.Exists
    End Function

    Public Function Boolean2Decimal(pValue As Boolean) As Integer

        If pValue = True Then
            Return 1
        Else
            Return 0
        End If
    End Function

    Public Function Decimal2Boolean(pValue As Integer) As Boolean
        If pValue = 1 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function ConvertYearEN(ByVal sYear As Integer) As String
        If sYear > 2500 Then
            sYear = sYear - 543
        Else
            sYear = sYear
        End If

        Return sYear.ToString()

    End Function
    Public Function ConvertYearTH(ByVal sYear As Integer) As String
        If sYear < 2500 Then
            sYear = sYear + 543
        Else
            sYear = sYear
        End If

        Return sYear.ToString()

    End Function
    Public Function ConvertFormateDate(ByVal Adate As Date) As String
        Dim strDate(2) As String
        strDate(0) = CStr(Adate.Day)
        strDate(1) = CStr(Adate.Month)
        strDate(2) = CStr(Adate.Year)

        If strDate(0).Length < 2 Then
            strDate(0) = "0" & strDate(0)
        End If
        If strDate(1).Length < 2 Then
            strDate(1) = "0" & strDate(1)
        End If

        ConvertFormateDate = strDate(1) & "/" & strDate(0) & "/" & strDate(2)

        Return ConvertFormateDate

    End Function
    Public Function ParseDateToSQL(ByVal sDate As String) As String
        Dim str() As String
        Dim dY As Integer

        str = Split(sDate, "/")

        dY = Now.Date.Year - CInt(str(2))
        If dY < 0 Then
            dY = CInt(str(2)) - 543
        Else
            dY = str(2)
        End If
        sDate = dY & "-" & str(1) & "-" & str(0)
        Return sDate
    End Function

    Public Function ParseDateToSQL(ByVal sDate As String, ByVal sKey As String) As String
        Dim str() As String
        Dim dY As Integer

        If sKey = "-" Then
            str = Split(sDate, "-")
        ElseIf sKey = "/" Then
            str = Split(sDate, "/")
        End If

        dY = Now.Date.Year - CInt(str(2))
        If dY < 0 Then
            dY = CInt(str(2)) - 543
        Else
            dY = str(2)
        End If
        sDate = dY & "-" & str(1) & "-" & str(0)
        Return sDate
    End Function
    Public Function ConvertStringDateToDate(ByVal sDate As String) As Date
        Dim str() As String
        Dim dY As Integer
        str = Split(sDate, "/")
        dY = CInt(str(2))

        If dY > 2500 Then
            dY = dY
        Else
            dY = str(2)
        End If
        sDate = str(0) & "/" & str(1) & "/" & dY
        Return sDate
    End Function

    Public Function isStringFormatDate(ByVal sDate As String, KeyString As String) As Boolean
        Dim str() As String
        Dim Valid As Boolean = True
        str = Split(sDate, KeyString)

        If str(0) = "" Or (StrNull2Zero(str(0)) = 0 Or StrNull2Zero(str(0)) > 31) Then
            Valid = False
        End If
        If str(1) = "" Or (StrNull2Zero(str(1)) = 0 Or StrNull2Zero(str(1)) > 12) Then
            Valid = False
        End If
        If str(2) = "" Or (StrNull2Zero(str(2)) = 0 Or StrNull2Zero(str(2)) < 2500) Then
            Valid = False
        End If

        If Len(str(0)) < 2 Then
            Valid = False
        End If
        If Len(str(1)) < 2 Then
            Valid = False
        End If
        If Len(str(2)) < 4 Then
            Valid = False
        End If

        Return Valid
    End Function

    Public Function ConvertDateToString(ByVal Adate As Date) As String
        Dim strDate(2) As String
        strDate(0) = CStr(Adate.Day)
        strDate(1) = CStr(Adate.Month)
        strDate(2) = CStr(Adate.Year)

        ConvertDateToString = strDate(0) & "/" & strDate(1) & "/" & CInt(strDate(2)) + 543

        Return ConvertDateToString

    End Function

    Public Function DBNull2StrDash(ByVal str As Object) As String
        If IsDBNull(str) Then
            Return "-"
        ElseIf str = "" Then
            Return "-"
        Else
            Return CStr(str)
        End If
    End Function
    Public Function StrNull2Zero(ByVal str As String) As Integer
        If str = "" Or IsNumeric(str) = False Then
            Return 0
        Else
            If Not IsNumeric(str) Then
                Return 0
            Else
                Return CInt(str)
            End If
        End If
    End Function
    Public Function StrNull2Int(ByVal str As String) As Integer
        If str = "" Or IsNumeric(str) = False Then
            Return 0
        Else
            If Not IsNumeric(str) Then
                Return 0
            Else
                Return CInt(str)
            End If
        End If
    End Function
    Public Function StrNull2Long(ByVal str As String) As Long
        If str = "" Or IsNumeric(str) = False Then
            Return 0
        Else
            If Not IsNumeric(str) Then
                Return 0
            Else
                Return CLng(str)
            End If
        End If
    End Function

    Public Function StrNull2Double(ByVal str As String) As Double
        If str = "" Then
            Return 0
        Else
            If Not IsNumeric(str) Then
                Return 0
            Else
                Return CDbl(str)
            End If
        End If
    End Function

    Public Function StrNull2GPPVal(ByVal str As String) As Integer
        If str = "" Then
            Return -1
        ElseIf str = "-1" Then
            Return -1
        Else
            If Not IsNumeric(str) Then
                Return 0
            Else
                Return CInt(str)
            End If
        End If
    End Function
    Public Function StrNull2GPPScore(ByVal str As String) As Integer
        If str = "" Then
            Return 0
        ElseIf str = "-1" Then
            Return 0
        Else
            If Not IsNumeric(str) Then
                Return 0
            Else
                Return CInt(str)
            End If
        End If
    End Function

    Public Function Prefix2Display(ByVal str As Object) As String
        If IsDBNull(str) Then
            Return ""
        Else
            If str = "นิติบุคคล" Or str = "" Then
                Return ""
            Else
                Return CStr(str)
            End If

        End If
    End Function

    Public Function Zero2StrNull(ByVal str As Object) As String
        If IsDBNull(str) Then
            Return ""
        Else
            If str = 0 Then
                Return ""
            Else
                Return CStr(str)
            End If

        End If
    End Function

    Public Function DBNull2Str(ByVal str As Object) As String
        If IsDBNull(str) Then
            Return ""
        Else
            Return CStr(str)
        End If
    End Function
    Public Function DBNull2Zero(ByVal str As Object) As Integer
        If IsDBNull(str) Then
            Return 0
        Else
            If Not IsNumeric(str) Then
                Return 0
            Else
                Return CInt(str)
            End If
        End If
    End Function
    Public Function DBNull2Lng(ByVal str As Object) As Long
        If IsDBNull(str) Then
            Return 0
        Else
            If str.ToString() <> "" Then
                Return CInt(str)
            Else
                Return 0
            End If
        End If
    End Function
    Public Function DBNull2Dbl(ByVal str As Object) As Double
        If IsDBNull(str) Then
            Return 0
        Else
            If str.ToString() <> "" Then
                Return CDbl(str)
            Else
                Return 0
            End If
        End If
    End Function


    Public Sub UploadFile(ByVal Fileupload As Object, ByVal prmPath As String)
        Dim FileFullName As String = Fileupload.PostedFile.FileName
        Dim FileNameInfo As String = Path.GetFileName(FileFullName)
        Dim filename As String = Path.GetFileName(Fileupload.PostedFile.FileName)
        Dim objfile As FileInfo = New FileInfo(prmPath)
        If FileNameInfo <> "" Then
            Fileupload.PostedFile.SaveAs(objfile.DirectoryName & "\" & filename)
        End If
        objfile = Nothing
    End Sub




    Public Function CheckPersonalID(ByVal uid As String) As Boolean
        Dim IntID As Integer = ((CInt(uid.Substring(0, 1)) * 13) _
                    + ((CInt(uid.Substring(1, 1)) * 12) _
                    + ((CInt(uid.Substring(2, 1)) * 11) _
                    + ((CInt(uid.Substring(3, 1)) * 10) _
                    + ((CInt(uid.Substring(4, 1)) * 9) _
                    + ((CInt(uid.Substring(5, 1)) * 8) _
                    + ((CInt(uid.Substring(6, 1)) * 7) _
                    + ((CInt(uid.Substring(7, 1)) * 6) _
                    + ((CInt(uid.Substring(8, 1)) * 5) _
                    + ((CInt(uid.Substring(9, 1)) * 4) _
                    + ((CInt(uid.Substring(10, 1)) * 3) _
                    + (CInt(uid.Substring(11, 1)) * 2))))))))))))
        Dim LastID As Integer = (IntID Mod 11)
        If (LastID = 0) Then
            LastID = 1
        ElseIf (LastID = 1) Then
            LastID = 0
        Else
            LastID = (11 - LastID)
        End If
        Return (CInt(uid.Substring(12, 1)) = LastID)
    End Function

    Public Function FormatPersonalID(ByVal uid As String) As String
        Dim IDformat As String = ""
        IDformat = (uid.Substring(0, 1) + " ")
        IDformat = (IDformat _
                    + (uid.Substring(1, 1) _
                    + (uid.Substring(2, 1) _
                    + (uid.Substring(3, 1) _
                    + (uid.Substring(4, 1) + " ")))))
        IDformat = (IDformat _
                    + (uid.Substring(5, 1) _
                    + (uid.Substring(6, 1) _
                    + (uid.Substring(7, 1) _
                    + (uid.Substring(8, 1) _
                    + (uid.Substring(9, 1) + " "))))))
        IDformat = (IDformat _
                    + (uid.Substring(10, 1) _
                    + (uid.Substring(11, 1) + " ")))
        IDformat = (IDformat + uid.Substring(12, 1))
        Return IDformat
    End Function



    '#'*-*44L@!9
    Public Function ShowMenu(ByVal p As String, ByVal permission As String) As Boolean
        If permission.Contains(p) Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function toThaiNumber(ByVal num As String) As String
        Dim tmp As String = ""
        Dim i As Integer = 0

        For i = 0 To i < num.Length

            If (num.Substring(i, 1) = "0") Then
                tmp += "๐"
            ElseIf (num.Substring(i, 1) = "1") Then
                tmp += "๑"
            ElseIf (num.Substring(i, 1) = "2") Then
                tmp += "๒"
            ElseIf (num.Substring(i, 1) = "3") Then
                tmp += "๓"
            ElseIf (num.Substring(i, 1) = "4") Then
                tmp += "๔"
            ElseIf (num.Substring(i, 1) = "5") Then
                tmp += "๕"
            ElseIf (num.Substring(i, 1) = "6") Then
                tmp += "๖"
            ElseIf (num.Substring(i, 1) = "7") Then
                tmp += "๗"
            ElseIf (num.Substring(i, 1) = "8") Then
                tmp += "๘"
            ElseIf (num.Substring(i, 1) = "9") Then
                tmp += "๙"
            Else
                tmp += num.Substring(i, 1)
            End If

        Next
        Return tmp
    End Function
    Public Function ConvertBoolean2Integer(ByVal pVal As Boolean) As String
        If pVal = True Then
            Return 1
        Else
            Return 0
        End If
    End Function
    Public Function ConvertBoolean2YN(ByVal pVal As Boolean) As String
        If pVal = True Then
            Return "Y"
        Else
            Return "N"
        End If
    End Function

    Public Function ConvertBoolean2StatusFlag(ByVal pVal As Boolean) As String
        If pVal = True Then
            Return "A"
        Else
            Return "D"
        End If
    End Function

    Public Function ConvertStatusFlag2CHK(ByVal pVal As String) As Boolean
        If pVal = "A" Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Function ConvertYN2Boolean(ByVal pVal As String) As Boolean
        If pVal = "Y" Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Function ConvertRole2Boolean(ByVal pVal As String) As Boolean
        If pVal = "True" Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function ConvertDate2DBString(ByVal dt As Date) As String
        Dim y As String = ""
        Dim d As String = ""
        Dim m As String = ""
        d = dt.Day.ToString
        m = dt.Month.ToString

        While (d.Length < 2)
            d = ("0" + d)

        End While

        While (m.Length < 2)
            m = ("0" + m)

        End While

        If dt.Year < 2500 Then
            y = (dt.Year + 543).ToString
        Else
            y = dt.Year
        End If

        Return y + m + d
    End Function
    Public Function SetStrDate2DBDateFormat(ByVal dt As String) As String
        If dt <> "" Then

            Dim y As String = ""
            Dim d As String = ""
            Dim m As String = ""
            Dim iY As Integer = 0

            Dim str() As String
            str = Split(dt, "/")

            d = str(0).ToString
            m = str(1).ToString


            While (d.Length < 2)
                d = ("0" + d)
            End While

            While (m.Length < 2)
                m = ("0" + m)
            End While

            iY = StrNull2Zero(str(2))
            Do Until iY < 2100
                iY = iY - 543
            Loop
            y = iY.ToString

            Return m + "/" + d + "/" + y
        Else
            Return ""
        End If
    End Function

    Public Function ConvertStrDate2DBString(ByVal dt As String) As String
        If dt <> "" Then

            Dim y As String = ""
            Dim d As String = ""
            Dim m As String = ""

            Dim str() As String
            str = Split(dt, "/")

            d = str(0).ToString
            m = str(1).ToString


            While (d.Length < 2)
                d = ("0" + d)
            End While

            While (m.Length < 2)
                m = ("0" + m)
            End While

            If CInt(str(2)) < 2500 Then
                y = (CInt(str(2)) + 543).ToString
            Else
                y = str(2)
            End If

            Return y + m + d
        Else
            Return ""
        End If
    End Function
    Public Function ConvertTimeToString(ByVal dt As Date) As String
        Dim m As String
        Dim h As String
        Dim s As String
        h = dt.Hour.ToString("00")
        m = dt.Minute.ToString("00")
        s = dt.Second.ToString("00")

        While (m.Length < 2)
            m = ("0" + m)
        End While

        While (s.Length < 2)
            s = ("0" + s)
        End While
        Return h & m & s

    End Function
    Public Function DisplayDayTH(ByVal code As String) As String
        Dim d1 As String = ""
        Select Case code
            Case "SUN"
                d1 = "อาทิตย์"
            Case "MON"
                d1 = "จันทร์"
            Case "TUE"
                d1 = "อังคาร"
            Case "WED"
                d1 = "พุธ"
            Case "THU"
                d1 = "พฤหัสบดี"
            Case "FRI"
                d1 = "ศุกร์"
            Case "SAT"
                d1 = "เสาร์"
        End Select
        Return d1
    End Function
    Public Function DisplayFullDateTH(ByVal dt As Date) As String
        Dim y As String = ""
        Dim d1 As String = ""
        Dim d2 As String = ""
        Dim m As String = ""

        Select Case dt.DayOfWeek
            Case DayOfWeek.Sunday
                d1 = "อาทิตย์"
            Case DayOfWeek.Monday
                d1 = "จันทร์"
            Case DayOfWeek.Tuesday
                d1 = "อังคาร"
            Case DayOfWeek.Wednesday
                d1 = "พุธ"
            Case DayOfWeek.Thursday
                d1 = "พฤหัสบดี"
            Case DayOfWeek.Friday
                d1 = "ศุกร์"
            Case DayOfWeek.Saturday
                d1 = "เสาร์"

        End Select

        d2 = dt.Day.ToString

        Select Case dt.Month
            Case 1 : m = "มกราคม"
            Case 2 : m = "กุมภาพันธ์"
            Case 3 : m = "มีนาคม"
            Case 4 : m = "เมษายน"
            Case 5 : m = "พฤษภาคม"
            Case 6 : m = "มิถุนายน"
            Case 7 : m = "กรกฎาคม"
            Case 8 : m = "สิงหาคม"
            Case 9 : m = "กันยายน"
            Case 10 : m = "ตุลาคม"
            Case 11 : m = "พฤศจิกายน"
            Case 12 : m = "ธันวาคม"
        End Select

        If dt.Year < 2500 Then
            y = (dt.Year + 543).ToString
        Else
            y = dt.Year
        End If

        Return "วัน" + d1 + "ที่ " + d2 + " " + m + " พ.ศ. " + y

    End Function

    Public Function DisplayFullDateTHwithoutDOW(ByVal dt As Date) As String
        Dim y As String = ""
        Dim d2 As String = ""
        Dim m As String = ""
        d2 = dt.Day.ToString

        Select Case dt.Month
            Case 1 : m = "มกราคม"
            Case 2 : m = "กุมภาพันธ์"
            Case 3 : m = "มีนาคม"
            Case 4 : m = "เมษายน"
            Case 5 : m = "พฤษภาคม"
            Case 6 : m = "มิถุนายน"
            Case 7 : m = "กรกฎาคม"
            Case 8 : m = "สิงหาคม"
            Case 9 : m = "กันยายน"
            Case 10 : m = "ตุลาคม"
            Case 11 : m = "พฤศจิกายน"
            Case 12 : m = "ธันวาคม"
        End Select

        If dt.Year < 2500 Then
            y = (dt.Year + 543).ToString
        Else
            y = dt.Year
        End If

        Return "วันที่  " + d2 + "   เดือน  " + m + "   พ.ศ. " + y
    End Function
    Public Function DisplayDateTH(ByVal dt As Date) As String
        Dim y As String = ""
        Dim d2 As String = ""
        Dim m As String = ""
        d2 = dt.Day.ToString
        Select Case dt.Month
            Case 1 : m = "มกราคม"
            Case 2 : m = "กุมภาพันธ์"
            Case 3 : m = "มีนาคม"
            Case 4 : m = "เมษายน"
            Case 5 : m = "พฤษภาคม"
            Case 6 : m = "มิถุนายน"
            Case 7 : m = "กรกฎาคม"
            Case 8 : m = "สิงหาคม"
            Case 9 : m = "กันยายน"
            Case 10 : m = "ตุลาคม"
            Case 11 : m = "พฤศจิกายน"
            Case 12 : m = "ธันวาคม"
        End Select

        If dt.Year < 2500 Then
            y = (dt.Year + 543).ToString
        Else
            y = dt.Year
        End If

        Return d2 + " " + m + " " + y
    End Function
    Public Function DisplayLongDateNoYearTH(ByVal dt As Date) As String
        Dim y As String = ""
        Dim d2 As String = ""
        Dim m As String = ""
        d2 = dt.Day.ToString
        Select Case dt.Month
            Case 1 : m = "มกราคม"
            Case 2 : m = "กุมภาพันธ์"
            Case 3 : m = "มีนาคม"
            Case 4 : m = "เมษายน"
            Case 5 : m = "พฤษภาคม"
            Case 6 : m = "มิถุนายน"
            Case 7 : m = "กรกฎาคม"
            Case 8 : m = "สิงหาคม"
            Case 9 : m = "กันยายน"
            Case 10 : m = "ตุลาคม"
            Case 11 : m = "พฤศจิกายน"
            Case 12 : m = "ธันวาคม"
        End Select

        Return d2 + " " + m
    End Function

    Public Function DisplayLongDateTH(ByVal dt As Date) As String
        Dim y As String = ""
        Dim d2 As String = ""
        Dim m As String = ""
        d2 = dt.Day.ToString
        Select Case dt.Month
            Case 1 : m = "มกราคม"
            Case 2 : m = "กุมภาพันธ์"
            Case 3 : m = "มีนาคม"
            Case 4 : m = "เมษายน"
            Case 5 : m = "พฤษภาคม"
            Case 6 : m = "มิถุนายน"
            Case 7 : m = "กรกฎาคม"
            Case 8 : m = "สิงหาคม"
            Case 9 : m = "กันยายน"
            Case 10 : m = "ตุลาคม"
            Case 11 : m = "พฤศจิกายน"
            Case 12 : m = "ธันวาคม"
        End Select

        If dt.Year < 2100 Then
            y = (dt.Year + 543).ToString
        Else
            y = dt.Year
        End If

        Return d2 + " " + m + " " + y
    End Function

    Public Function Convert2LetterNo(ByVal dt As String) As String
        Dim y As String = ""
        Dim i As String = ""
        y = dt.Substring(0, 4)
        i = dt.Substring(4, 3)

        Return CInt(i) & "/" & y
    End Function
    Public Function ConvertStrDate2DBDate(ByVal dt As String) As String
        '25/02/2020
        If dt <> "" Then

            Dim str() As String
            str = Split(dt, "/")

            Dim dd As String = str(0)
            Dim mm As String = str(1)
            Dim yy As String = Left(str(2), 4)

            While (dd.Length < 2)
                dd = ("0" + dd)

            End While

            While (mm.Length < 2)
                mm = ("0" + mm)

            End While
            If CInt(yy) > 2500 Then
                yy = (CInt(yy) - 543).ToString
            End If

            Return yy + "-" + mm + "-" + dd
        Else
            Return ""
        End If

    End Function

    Public Function ConvertStrDate2ShortDateEN(ByVal dt As String) As String
        '25/02/2020
        If dt <> "" Then

            Dim str() As String
            str = Split(dt, "/")

            Dim dd As String = str(0)
            Dim mm As String = str(1)
            Dim yy As String = str(2)

            While (dd.Length < 2)
                dd = ("0" + dd)

            End While

            While (mm.Length < 2)
                mm = ("0" + mm)

            End While
            If CInt(yy) > 2500 Then
                yy = (CInt(yy) - 543).ToString
            End If

            Return dd + "/" + mm + "/" + yy
        Else
            Return ""
        End If

    End Function
    Public Function ConvertStrDate2ShortDateTH(ByVal dt As String) As String
        '25/02/2563
        If dt <> "" Then

            Dim str() As String
            str = Split(dt, "/")

            Dim dd As String = str(0)
            Dim mm As String = str(1)
            Dim yy As String = str(2)

            While (dd.Length < 2)
                dd = ("0" + dd)

            End While

            While (mm.Length < 2)
                mm = ("0" + mm)

            End While
            If CInt(yy) < 2500 Then
                yy = (CInt(yy) + 543).ToString
            End If

            Return dd + "/" + mm + "/" + yy
        Else
            Return ""
        End If

    End Function

    Public Function DisplayStr2DateTH(ByVal dt As String) As String
        Dim y As String = ""
        Dim d2 As String = ""
        Dim m As String = ""
        d2 = CInt(dt.Substring(6, 2)).ToString
        If (d2 = "0") Then
            d2 = ""
        Else
            d2 = d2
        End If
        m = CInt(dt.Substring(4, 2)).ToString

        Select Case m
            Case "0" : m = ""
            Case "1" : m = "มกราคม"
            Case "2" : m = "กุมภาพันธ์"
            Case "3" : m = "มีนาคม"
            Case "4" : m = "เมษายน"
            Case "5" : m = "พฤษภาคม"
            Case "6" : m = "มิถุนายน"
            Case "7" : m = "กรกฎาคม"
            Case "8" : m = "สิงหาคม"
            Case "9" : m = "กันยายน"
            Case "10" : m = "ตุลาคม"
            Case "11" : m = "พฤศจิกายน"
            Case "12" : m = "ธันวาคม"
        End Select

        y = dt.Substring(0, 4)

        Return d2 + " " + m + " " + y

    End Function
    Public Function DisplayMiniDateTH(ByVal dt As Date) As String
        Dim y As String = ""
        Dim d2 As String = ""
        Dim m As String = ""
        d2 = dt.Day.ToString

        Select Case dt.Month
            Case 1 : m = "ม.ค."
            Case 2 : m = "ก.พ."
            Case 3 : m = "มี.ค."
            Case 4 : m = "เม.ย."
            Case 5 : m = "พ.ค."
            Case 6 : m = "มิ.ย."
            Case 7 : m = "ก.ค."
            Case 8 : m = "ส.ค."
            Case 9 : m = "ก.ย."
            Case 10 : m = "ต.ค."
            Case 11 : m = "พ.ย."
            Case 12 : m = "ธ.ค."
        End Select

        If dt.Year < 2500 Then
            y = (dt.Year + 543).ToString
        Else
            y = dt.Year
        End If

        Return d2 + " " + m + " " + y

    End Function
    Public Function DisplayMiniDateNoYear(ByVal dt As Date) As String
        Dim y As String = ""
        Dim d As String = ""
        Dim m As String = ""
        d = dt.Day.ToString

        Select Case dt.Month
            Case 1 : m = "ม.ค."
            Case 2 : m = "ก.พ."
            Case 3 : m = "มี.ค."
            Case 4 : m = "เม.ย."
            Case 5 : m = "พ.ค."
            Case 6 : m = "มิ.ย."
            Case 7 : m = "ก.ค."
            Case 8 : m = "ส.ค."
            Case 9 : m = "ก.ย."
            Case 10 : m = "ต.ค."
            Case 11 : m = "พ.ย."
            Case 12 : m = "ธ.ค."
        End Select

        Return d + " " + m

    End Function

    Public Function DisplayShortDateTH(ByVal dt As Date) As String
        Dim y As String = ""
        Dim d As String = ""
        Dim m As String = ""
        d = dt.Day.ToString
        m = dt.Month.ToString

        While (d.Length < 2)
            d = ("0" + d)
        End While

        While (m.Length < 2)
            m = ("0" + m)
        End While
        If dt.Year < 2500 Then
            y = (dt.Year + 543).ToString
        Else
            y = dt.Year
        End If
        Return d + "/" + m + "/" + y
    End Function

    Public Function DisplayShortDateEN(ByVal dt As Date) As String
        Dim y As String = ""
        Dim d As String = ""
        Dim m As String = ""

        d = dt.Day.ToString
        m = dt.Month.ToString

        While (d.Length < 2)
            d = ("0" + d)

        End While

        While (m.Length < 2)
            m = ("0" + m)

        End While
        y = dt.Year.ToString
        Return (d + ("/" + (m + ("/" + y))))
    End Function

    Public Function DisplayStr2ShortDateEN(ByVal dt As String) As String
        Dim dd As String = dt.Substring(6, 2)
        Dim mm As String = dt.Substring(4, 2)
        Dim yy As String = dt.Substring(0, 4)

        While (dd.Length < 2)
            dd = ("0" + dd)

        End While

        While (mm.Length < 2)
            mm = ("0" + mm)

        End While

        Return dd + "/" + mm + "/" + yy
    End Function

    Public Function DisplayStr2ShortDateTH(ByVal dt As String) As String
        If dt <> "" Then
            Dim dd As String = dt.Substring(6, 2)
            Dim mm As String = dt.Substring(4, 2)
            Dim yy As String = dt.Substring(0, 4)

            While (dd.Length < 2)
                dd = ("0" + dd)

            End While

            While (mm.Length < 2)
                mm = ("0" + mm)

            End While
            If CInt(yy) < 2500 Then
                yy = (CInt(yy) + 543).ToString
            End If

            Return dd + "/" + mm + "/" + yy
        Else
            Return ""
        End If

    End Function

    Public Function ConvertStrDate2ShortTH(ByVal sDate As String) As String
        If sDate.Trim() <> "" Then
            Dim str() As String
            str = Split(sDate, "/")
            Dim dd As String = str(0)
            Dim mm As String = str(1)
            Dim yy As String = Left(str(2), 4)

            While (dd.Length < 2)
                dd = ("0" + dd)

            End While

            While (mm.Length < 2)
                mm = ("0" + mm)

            End While
            If CInt(yy) < 2500 Then
                yy = (CInt(yy) + 543).ToString
            End If

            Return dd + "/" + mm + "/" + yy
        Else
            Return ""
        End If

    End Function
    Public Function ConvertStrDate2ShortTH(ByVal sDate As String, ByVal sKey As String) As String
        If sDate <> "" Then
            Dim str() As String
            If sKey = "-" Then
                str = Split(sDate, "-")
            ElseIf sKey = "/" Then
                str = Split(sDate, "/")
            End If

            Dim dd As String = str(0)
            Dim mm As String = str(1)
            Dim yy As String = str(2)

            While (dd.Length < 2)
                dd = ("0" + dd)

            End While

            While (mm.Length < 2)
                mm = ("0" + mm)

            End While
            If CInt(yy) < 2500 Then
                yy = (CInt(yy) + 543).ToString
            End If

            Return dd + "/" + mm + "/" + yy
        Else
            Return ""
        End If

    End Function

    Public Function DisplayTime(ByVal dt As Date) As String
        Dim m As String
        Dim h As String
        h = dt.Hour.ToString
        m = dt.Minute.ToString

        While (m.Length < 2)
            m = ("0" + m)

        End While
        Return (h + ("." _
                    + (m + " .")))
    End Function

    Public Function DisplayPhone(ByVal s As String) As String
        If (s.Length = 9) Then
            If (s.Substring(0, 2) = "02") Then
                Return (s.Substring(0, 2) + ("-" _
                            + (s.Substring(2, 3) + ("-" + s.Substring(5, 4)))))
            Else
                Return (s.Substring(0, 3) + ("-" _
                            + (s.Substring(3, 3) + ("-" + s.Substring(6, 3)))))
            End If
        End If
        If (s.Length = 10) Then
            Return (s.Substring(0, 3) + ("-" _
                        + (s.Substring(3, 3) + ("-" + s.Substring(6, 4)))))
        End If
        Return s
    End Function

    Public Function DisplayUsername(ByVal s As String) As String
        If Not New Regex("^([0-9]{13})$").IsMatch(s) Then
            Return s
        End If
        Return (s.Substring(0, 1) + ("-" _
                    + (s.Substring(1, 4) + ("-" _
                    + (s.Substring(5, 5) + ("-" _
                    + (s.Substring(10, 2) + ("-" + s.Substring(12, 1)))))))))
    End Function

    Public Function DisplayDay(ByVal dt As Date) As String
        Dim d As String = ""
        d = dt.Day.ToString
        Return d
    End Function
    Public Function DisplayNumber2Month(ByVal pM As Integer) As String
        Dim m As String = ""
        Select Case pM
            Case 1 : m = "มกราคม"
            Case 2 : m = "กุมภาพันธ์"
            Case 3 : m = "มีนาคม"
            Case 4 : m = "เมษายน"
            Case 5 : m = "พฤษภาคม"
            Case 6 : m = "มิถุนายน"
            Case 7 : m = "กรกฎาคม"
            Case 8 : m = "สิงหาคม"
            Case 9 : m = "กันยายน"
            Case 10 : m = "ตุลาคม"
            Case 11 : m = "พฤศจิกายน"
            Case 12 : m = "ธันวาคม"
        End Select

        Return m
    End Function
    Public Function DisplayMonth(ByVal dt As Date) As String
        Dim m As String = ""
        Select Case dt.Month
            Case 1 : m = "มกราคม"
            Case 2 : m = "กุมภาพันธ์"
            Case 3 : m = "มีนาคม"
            Case 4 : m = "เมษายน"
            Case 5 : m = "พฤษภาคม"
            Case 6 : m = "มิถุนายน"
            Case 7 : m = "กรกฎาคม"
            Case 8 : m = "สิงหาคม"
            Case 9 : m = "กันยายน"
            Case 10 : m = "ตุลาคม"
            Case 11 : m = "พฤศจิกายน"
            Case 12 : m = "ธันวาคม"
        End Select

        Return m
    End Function
    Public Function DisplayStr2Day(ByVal dt As String) As String
        Dim d As String = ""
        d = Val(dt)
        Return d
    End Function

    Public Function DisplayYear(ByVal dt As Date) As String
        Dim y As String = ""

        If dt.Year < 2500 Then
            y = (dt.Year + 543).ToString
        Else
            y = dt.Year
        End If

        Return y
    End Function

    Public Function ChkNull(ByVal str As String) As String
        If (str <> "") Then
            Return (" " + str)
        Else
            Return " -"
        End If
    End Function


    Public Function TRcolor(ByVal row As Integer) As String
        Dim tr As String = ""
        If ((row Mod 2) _
                    <> 0) Then
            tr = "<tr onMouseOver=\""this.bgColor='#DDDDDD';\"" onMouseOut=\""this.bgColor='#FFFFFF';\"">"
        Else
            tr = "<tr onMouseOver=\""this.bgColor='#DDDDDD';\"" onMouseOut=\""this.bgColor='#FFFFFF';\"">"
        End If
        Return tr
    End Function





#End Region


    'ตรวจสอบว่าใน datatable มีคอลัมน์ชื่อนี้หรือไม่
    Function checkField(dtT As DataTable, ColumnName As String) As String
        If dtT.Columns(ColumnName) IsNot Nothing Then
            Return String.Concat(dtT.Rows(0)(ColumnName))
        Else
            Return ""
        End If
    End Function

End Module