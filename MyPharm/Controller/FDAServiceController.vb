Imports Microsoft.ApplicationBlocks.Data
Imports BigLion
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

    Public Function GET_DRUG_LCN_INFORMATION(NewCode As String) As DataTable
        ds = fdaService.GET_DRUG_LCN_INFORMATION(NewCode)
        Return ds.Tables("SP_GENXML_SEARCH_DRUG_LCN")
    End Function
End Class
