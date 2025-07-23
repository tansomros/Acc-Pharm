Imports Microsoft.ApplicationBlocks.Data
Imports BigLion
Imports System.Net
Public Class FDAServiceController
    Inherits BaseClass
    Public ds As New DataSet
    Private fdaService As New FDAServiceReference.WS_LICENSE_SEARCHSoapClient

    Function ConvertLicenseToNewCode(LicenseNo As String) As String
        Dim ctlM As New MasterController
        Dim NewCode As String = "U1Dขย1"
        Dim LNO As String = ""
        Dim str() As String
        LicenseNo = RTrim(LTrim(LicenseNo))
        If Mid(LicenseNo, 3, 1) <> "." And Mid(LicenseNo, 3, 1) <> " " Then
            LicenseNo = Left(LicenseNo, 2) & "." & Right(LicenseNo, Len(LicenseNo) - 2)
        End If
        LicenseNo = Replace(LicenseNo, ". ", ".")
        LicenseNo = Replace(Replace(Replace(LicenseNo, ".", "_"), " ", "_"), "/", "_") 'แทนที่ จุด เคาะวรรค / ด้วย _
        LicenseNo = Replace(LicenseNo, "__", "_")

        str = Split(LicenseNo, "_")

        LNO = Convert.ToInt32(str(1)).ToString("00000")
        NewCode = NewCode & ctlM.Province_GetID(Left(LicenseNo, 2)) & Right(LicenseNo, 2) & LNO & "C"
        Return NewCode
    End Function
    Function ConvertLicenseToCode(LicenseNo As String) As String
        Dim ctlM As New MasterController
        Dim Code As String = ""
        Dim LNO As String = ""
        Dim str() As String
        LicenseNo = RTrim(LTrim(LicenseNo))
        If Mid(LicenseNo, 3, 1) <> "." And Mid(LicenseNo, 3, 1) <> " " Then
            LicenseNo = Left(LicenseNo, 2) & "." & Right(LicenseNo, Len(LicenseNo) - 2)
        End If
        LicenseNo = Replace(LicenseNo, ". ", ".")
        LicenseNo = Replace(Replace(Replace(LicenseNo, ".", "_"), " ", "_"), "/", "_") 'แทนที่ จุด เคาะวรรค / ด้วย _
        LicenseNo = Replace(LicenseNo, "__", "_")

        str = Split(LicenseNo, "_")

        LNO = Convert.ToInt32(str(1)).ToString("00000")
        Code = Code & ctlM.Province_GetID(Left(LicenseNo, 2)) & Right(LicenseNo, 2) & LNO
        Return Code
    End Function

    Public Function GET_DRUG_LCN_INFORMATION(NewCode As String) As DataTable
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
        ds = fdaService.GET_DRUG_LCN_INFORMATION(NewCode)
        Return ds.Tables("SP_GENXML_SEARCH_DRUG_LCN")
    End Function

    Public Function GET_DRUG_PHARMACY(NewCode As String) As DataTable
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
        ds = fdaService.GET_DRUG_LCN_INFORMATION(NewCode)
        Return ds.Tables("SP_GENXML_DRUG_PHARMACY_TO")
    End Function

    Public Function GET_DRUG_LICEN(NewCode As String) As DataTable
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
        ds = fdaService.GET_DRUG_LCN_INFORMATION(NewCode)
        Return ds.Tables("SP_GENXML_DRUG_LCN_LICEN")
    End Function


    Public Function Assessment_Save(ByVal RequestUID As Long, ByVal LocationUID As Integer, ByVal MUser As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("Assessment_Save"), RequestUID, LocationUID, MUser)
    End Function

    Public Function Assessment_UpdateGPP(ByVal RequestUID As Long, ByVal LocationUID As Integer, ByVal GPP_Score As Double, ByVal GPP_TotalScore As Double, ByVal GPP_Percentage As Double, ByVal CUser As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("Assessment_UpdateGPP"), RequestUID, LocationUID, GPP_Score, GPP_TotalScore, GPP_Percentage, CUser)
    End Function
    Public Function Assessment_SaveQAScore(ByVal RequestUID As Long, ByVal LocationUID As Integer, ByVal QA_Score As Double, ByVal CUser As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("Assessment_UpdateGPP"), RequestUID, LocationUID, QA_Score, CUser)
    End Function
    Public Function Assessment_SendApprove(ByVal RequestUID As Long, ByVal LocationUID As Integer, ByVal CUser As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("Assessment_SendApprove"), RequestUID, LocationUID, CUser)
    End Function

    Public Function GPP_Assessment_GetUID(RequestUID As Integer) As Long
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("GPP_Assessment_GetUID"), RequestUID)
        If ds.Tables(0).Rows.Count > 0 Then
            Return DBNull2Lng(ds.Tables(0).Rows(0)(0))
        Else
            Return 0
        End If
    End Function

    Public Function Assessment_UpdateRemark(ByVal RequestUID As Long, ByVal LocationUID As Integer, ByVal AsmStatus As String, ByVal Comment As String, ByVal CUser As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("Assessment_UpdateRemark"), RequestUID, LocationUID, AsmStatus, Comment, CUser)
    End Function
    Public Function Assessment_Get() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Assessment_Get"))
        Return ds.Tables(0)
    End Function

    Public Function Assessment_GetByUID(Code As String, UID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Assessment_GetByUID"), Code, UID)
        Return ds.Tables(0)
    End Function
    Public Function Assessment_GetByRequestUID(ReqUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Assessment_GetByRequestUID"), ReqUID)
        Return ds.Tables(0)
    End Function

End Class
