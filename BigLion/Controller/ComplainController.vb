Imports System.Security.Cryptography
Imports Microsoft.ApplicationBlocks.Data

Public Class ComplainController

    Inherits BaseClass
    Public ds As New DataSet
#Region "Problem"
    Public Function ComplainProblem_Get(ComplainUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("ComplainProblem_Get"), ComplainUID)
        Return ds.Tables(0)
    End Function
    Public Function ComplainProblem_GetForReport() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("ComplainProblem_GetForReport"))
        Return ds.Tables(0)
    End Function

    Public Function ComplainProblem_Save(ByVal ComplainUID As Integer, PUID As Integer, CUser As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("ComplainProblem_Save"), ComplainUID, PUID, CUser)
    End Function
    Public Function ComplainProblem_Delete(ByVal ComplainUID As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("ComplainProblem_Delete"), ComplainUID)
    End Function
    Public Function ComplainProblem_Delete(ByVal ComplainUID As Integer, PUID As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("ComplainProblem_DeleteByProblem"), ComplainUID, PUID)
    End Function
    Public Function ComplainProject_GetForReport() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("ComplainProject_GetForReport"))
        Return ds.Tables(0)
    End Function

#End Region
    Public Function ComplainResult_Get(ComplainUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("ComplainResult_Get"), ComplainUID)
        Return ds.Tables(0)
    End Function
    Public Function ComplainResult_Save(ByVal ComplainUID As Integer, RUID As Integer, CUser As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("ComplainResult_Save"), ComplainUID, RUID, CUser)
    End Function
    Public Function ComplainResult_Delete(ByVal ComplainUID As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("ComplainResult_Delete"), ComplainUID)
    End Function
    Public Function ComplainResult_Delete(ByVal ComplainUID As Integer, RUID As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("ComplainResult_DeleteByResult"), ComplainUID, RUID)
    End Function




    Public Function Complain_Get() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Complain_Get"))
        Return ds.Tables(0)
    End Function
    Public Function Complain_GetActive() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Complain_GetActive"))
        Return ds.Tables(0)
    End Function

    Public Function Complain_GetByUID(pUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Complain_GetByUID"), pUID)
        Return ds.Tables(0)
    End Function
    Public Function Complain_GetPackage(pUID As Integer) As Integer
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Complain_GetPackageNo"), pUID)
        Return ds.Tables(0).Rows(0)(0)
    End Function

    Public Function Complain_GetPackageDetail(pUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Complain_GetPackageDetail"), pUID)
        Return ds.Tables(0)
    End Function

    Public Function PackageNo_GetByUserID(pUID As Integer) As Integer
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("PackageNo_GetByUserID"), pUID)
        Return ds.Tables(0).Rows(0)(0)
    End Function

    Public Function Complain_GetUID(Code As String) As Integer
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Complain_GetUID"), Code)
        If ds.Tables(0).Rows.Count > 0 Then
            Return DBNull2Zero(ds.Tables(0).Rows(0)(0))
        Else
            Return 0
        End If
    End Function

    Public Function Complain_GetBySearch(StartDate As String, EndDate As String, ProblemUID As String, Status As String, pKey As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Complain_GetBySearch"), StartDate, EndDate, ProblemUID, Status, pKey)
        Return ds.Tables(0)
    End Function

    Public Function Customer_GetExpireDate(ComplainUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Customer_GetExpireDate"), ComplainUID)
        Return ds.Tables(0)
    End Function


    Public Function Customer_GetForAlert() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Customer_GetForAlert"))
        Return ds.Tables(0)
    End Function

    Public Function Complain_Save(ByVal ComplainUID As Integer, ByVal CMPNO As String, ByVal RefCode As String _
           , ByVal ComplainDate As String _
           , ByVal CMPCHN As Integer _
           , ByVal CompName As String _
           , ByVal CompTel As String _
           , ByVal CompEmail As String _
           , ByVal CompCompany As String _
           , ByVal CompProvinceID As Integer _
           , ByVal LocationUID As Integer _
           , ByVal ReceiptName As String _
           , ByVal ReceiptPosition As String _
           , ByVal ReceiptDate As String _
           , ByVal ComplaintDetail As String _
           , ByVal IsEvidence As String _
           , ByVal CMPPROB As Integer _
           , ByVal ProblemRemark As String _
           , ByVal IsSendPharm As String _
           , ByVal SendDate As String _
           , ByVal SendRemark As String _
           , ByVal CMPPROJ As Integer _
           , ByVal ProjectOther As String _
           , ByVal CompRemark As String _
           , ByVal SendSeekDate As String _
           , ByVal SeekRemark As String _
           , ByVal SeekDetail As String _
           , ByVal SummaryDate As String _
           , ByVal SubCommitteeDate As String _
           , ByVal SummaryResult As Integer _
           , ByVal ImpactLevel As Integer _
           , ByVal SummaryRemark As String _
           , ByVal CautionBy As String _
           , ByVal NHSORemark As String _
           , ByVal StopDate As String _
           , ByVal RounNo As Integer _
           , ByVal CommitteeDate As String _
           , ByVal FinalResult As Integer _
           , ByVal FinalRemark As String _
           , ByVal FinalDate As String _
           , ByVal CloseStatus As String _
           , ByVal CloseDate As String _
           , ByVal CloseUser As Integer _
           , ByVal CUser As Integer _
           , ByVal LocationName As String _
           , ByVal LocationAddress As String _
           , ByVal LocationProvinceID As Integer _
           , ByVal CloseRemark As String
           ) As Integer

        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("Complain_Save"), ComplainUID, CMPNO, RefCode _
           , ComplainDate _
           , CMPCHN _
           , CompName _
           , CompTel _
           , CompEmail _
           , CompCompany _
           , CompProvinceID _
           , LocationUID _
           , ReceiptName _
           , ReceiptPosition _
           , ReceiptDate _
           , ComplaintDetail _
           , IsEvidence _
           , CMPPROB _
           , ProblemRemark _
           , IsSendPharm _
           , SendDate _
           , SendRemark _
           , CMPPROJ _
           , ProjectOther _
           , CompRemark _
           , SendSeekDate _
           , SeekRemark _
           , SeekDetail _
           , SummaryDate _
           , SubCommitteeDate _
           , SummaryResult _
           , ImpactLevel _
           , SummaryRemark _
           , CautionBy _
           , NHSORemark _
           , StopDate _
           , RounNo _
           , CommitteeDate _
           , FinalResult _
           , FinalRemark _
           , FinalDate _
           , CloseStatus _
           , CloseDate _
           , CloseUser _
           , CUser _
           , LocationName, LocationAddress, LocationProvinceID, CloseRemark)

    End Function

    Public Function Complain_UpdatePayinFile(ByVal ComplainUID As Integer, ByVal Payinfile As String) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("Complain_UpdatePayinFile"), ComplainUID, Payinfile)
    End Function


    Public Function Complain_AddFromRegister(ByVal ComplainUID As Integer, ByVal RegisterID As Integer, ByVal NameTH As String, ByVal AddressNumber As String, ByVal Lane As String, ByVal Road As String, ByVal SubDistrict As String, ByVal District As String, ByVal Province As String, ByVal ZipCode As String, ByVal Country As String, ByVal Telephone As String, ByVal Email As String, ByVal Website As String, BusinessTypeUID As Integer, ByVal UpdBy As Integer, AddressInvoice As String) As Integer

        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("Complain_AddFromRegister"), ComplainUID, RegisterID, NameTH, AddressNumber, Lane, Road, SubDistrict, District, Province, ZipCode, Country, Telephone, Email, Website, BusinessTypeUID, UpdBy, AddressInvoice)

    End Function

    Public Function Customer_UpdatePackage(ByVal ComplainUID As Integer, PackageNo As Integer, StartDate As String, DueDate As String, ByVal StatusFlag As String, ByVal ContactName As String, ByVal ContactMail As String, MUser As Integer) As Integer

        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("Customer_UpdatePackage"), ComplainUID, PackageNo, StartDate, DueDate, ContactName, ContactMail)
    End Function


    Public Function Complain_CheckOverMaxLimit(CompUID As Integer) As Boolean
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Complain_CheckOverMaxLimit"), CompUID)
        If ds.Tables(0).Rows(0)(0) = 0 Then
            Return False  'not over limit
        Else
            Return True ' over limit
        End If
    End Function

    Public Function Complain_Delete(ByVal ComplainUID As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("Complain_Delete"), ComplainUID)
    End Function

    Public Function Customer_GetRemainExpire() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Customer_GetRemainExpire"))
        Return ds.Tables(0)
    End Function

End Class
