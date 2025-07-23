Imports Microsoft.ApplicationBlocks.Data

Public Class CustomerController
    Inherits BaseClass
    Public ds As DataSet = New DataSet

#Region "Customer"
    Public Function Customer_GetAll() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Customer_GetAll"))
        Return ds.Tables(0)
    End Function
    Public Function Customer_GetActive() As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Customer_GetActive"))
        Return ds.Tables(0)
    End Function

    Public Function Customer_GetBySearch(ByVal pKey As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Customer_GetBySearch"), pKey)
        Return ds.Tables(0)
    End Function


    Public Function Customer_GetCustomerSearch(ByVal pKey As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Customer_GetCustomerSearch"), pKey)
        Return ds.Tables(0)
    End Function

    Public Function Customer_GetByStatus(ByVal pKey As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Customer_GetByStatus"), pKey)
        Return ds.Tables(0)
    End Function

    Public Function Customer_GetByUID(ByVal pUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Customer_GetByUID"), pUID)
        Return ds.Tables(0)
    End Function
    Public Function Customer_GetByCustomerID(ByVal CustomerUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Customer_GetByCustomerUID"), CustomerUID)
        Return ds.Tables(0)
    End Function

    Public Function Customer_GetByApproverUID(ByVal ApproverUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Customer_GetByApproverUID"), ApproverUID)
        Return ds.Tables(0)
    End Function

    Public Function Customer_GetByCompanyUID(ByVal CompID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Customer_GetByCompanyUID"), CompID, "")
        Return ds.Tables(0)
    End Function

    Public Function Customer_GetByCompanyUID(ByVal CompID As String, StatusFlag As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Customer_GetByCompanyUID"), CompID, StatusFlag)
        Return ds.Tables(0)
    End Function
    Public Function Customer_GetForSelection(ByVal CompID As String, StatusFlag As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Customer_GetForSelection"), CompID, StatusFlag)
        Return ds.Tables(0)
    End Function

    Public Function Customer_GetNotUser(ByVal CompID As String, StatusFlag As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Customer_GetForSelectionByNotUser"), CompID, StatusFlag)
        Return ds.Tables(0)
    End Function


    Public Function Customer_GetPersonalHealth(ByVal EmpID As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Customer_GetPersonalHealth"), EmpID)
        Return ds.Tables(0)
    End Function

    Public Function Customer_GetActivity(ByVal EmpID As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Customer_GetPersonalActivity"), EmpID)
        Return ds.Tables(0)
    End Function

    Public Function Customer_GetPersonalSafety(ByVal EmpID As String) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("CustomerPPE_Get"), EmpID)
        Return ds.Tables(0)
    End Function


    Public Function Customer_GetNameTHByID(ByVal pUID As Integer) As String
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Customer_GetNameTHByID"), pUID)
        Return String.Concat(ds.Tables(0).Rows(0)(0))
    End Function

    Public Function Customer_GetNotUser(CompanyUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Customer_GetNotUser"), CompanyUID)
        Return ds.Tables(0)
    End Function

    Public Function Customer_GetCustomerUID(ByVal Username As String, name As String) As String
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Customer_GetCustomerUID"), Username, name)
        Return String.Concat(ds.Tables(0).Rows(0)(0))
    End Function

    Public Function Customer_Save(
           ByVal CustomerUID As Integer,
           ByVal Username As String,
           ByVal Password As String,
           ByVal FName As String,
           ByVal LName As String,
           ByVal CompanyUID As Integer,
           ByVal Tel As String,
           ByVal Email As String,
           ByVal StatusFlag As String,
           ByVal CUser As Integer) As Integer

        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("Customer_Save"),
             CustomerUID _
           , Username _
           , Password _
           , FName _
           , LName _
           , CompanyUID _
           , Tel _
           , Email _
           , StatusFlag _
           , CUser)

    End Function
    Public Function Customer_UpdateGeneralData(ByVal CustomerUID As Integer _
           , ByVal isHobby As String _
           , ByVal HobbyRemark As String _
           , ByVal isActivity As String _
           , ByVal ActivityTime As Integer _
           , ByVal ActivityFeq As Integer _
           , ByVal IsSmoking As String _
           , ByVal SmokeQTY As Integer _
           , ByVal IsBodyHurt As String _
           , ByVal BodyHurt As String _
           , ByVal IsHurtInFactory As String _
           , ByVal HurtInFactory As String _
           , ByVal IsCongenitalDisease As String _
           , ByVal DiseaseDetail As String _
           , ByVal IsErgonomicMedical As String _
           , ByVal ErgonomicMedical As String _
           , ByVal IsErgonomicAccident As String _
           , ByVal ErgonomicAccident As String _
           , ByVal IsJobAccident As String _
           , ByVal JobAccident As String, MUser As Integer _
           , ByVal Hight As Double, ByVal Weight As Double _
           , ByVal IsWorkRepeatedly As String _
      , ByVal WorkRepeatedly1 As String _
      , ByVal WorkRepeatedly2 As String _
      , ByVal IsHardLook As String _
      , ByVal IsLifting As String _
      , ByVal LiftTime As String _
      , ByVal LiftLoad As String _
      , ByVal BodyPosition As String) As Integer

        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("Customer_UpdateGeneralData"), CustomerUID _
           , isHobby _
           , HobbyRemark _
           , isActivity _
           , ActivityTime _
           , ActivityFeq _
           , IsSmoking _
           , SmokeQTY _
           , IsBodyHurt _
           , BodyHurt _
           , IsHurtInFactory _
           , HurtInFactory _
           , IsCongenitalDisease _
           , DiseaseDetail _
           , IsErgonomicMedical _
           , ErgonomicMedical _
           , IsErgonomicAccident _
           , ErgonomicAccident _
           , IsJobAccident _
           , JobAccident _
           , MUser, Hight, Weight _
           , IsWorkRepeatedly, WorkRepeatedly1, WorkRepeatedly2, IsHardLook, IsLifting, LiftTime, LiftLoad, BodyPosition)


    End Function
    Public Function CustomerROWL_Save(ByVal CustomerUID As Integer, ByVal ROWLUID As String, ByVal Score As Integer) As Integer

        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("CustomerROWL_Save"), CustomerUID, ROWLUID, Score)
    End Function
    Public Function Customer_UpdateAllergy(ByVal CustomerUID As Integer, ByVal MedicalHistory As String, ByVal Allergy As String) As Integer

        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("Customer_UpdateAllergy"), CustomerUID, MedicalHistory, Allergy)
    End Function

    Public Function Customer_Delete(ByVal pID As String) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("Customer_Delete"), pID)
    End Function
#End Region

#Region "Customer Address"

    Function Customer_SaveAddress(ByVal CustomerCode As String, ByVal AddressType As Integer, ByVal AddressNo As String, ByVal VillageNo As String, ByVal Lane As String, ByVal Road As String, ByVal SubDistrict As String, ByVal District As String, ByVal ProvinceUID As Integer, ByVal ProvinceName As String, ByVal ZipCode As String, ByVal PhoneNumber As String, ByVal MobileNumber As String) As Integer

        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("Customer_SaveAddress"), CustomerCode, AddressType, AddressNo, VillageNo, Lane, Road, SubDistrict, District, ProvinceUID, ProvinceName, ZipCode, PhoneNumber, MobileNumber)
    End Function
    Public Function Customer_GetAddress(ByVal CustomerUID As Integer, ByVal AddressType As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("Customer_GetAddress"), CustomerUID, AddressType)
        Return ds.Tables(0)
    End Function
#End Region

#Region "Job History"
    Public Function CustomerJobHistory_Save(
              ByVal JUID As Integer,
              ByVal CustomerUID As Integer,
              ByVal CompanyName As String,
              ByVal BUType As String,
              ByVal Address As String,
              ByVal tel As String,
              ByVal StartWorkDate As String,
              ByVal EndWorkDate As String,
              ByVal Position As String,
              ByVal Department As String,
              ByVal WorkType As String,
              ByVal JobDesc As String,
              ByVal isNote As String,
              ByVal UpdBy As Integer) As Integer

        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("CustomerJobHistory_Save"), JUID,
             CustomerUID _
           , CompanyName _
           , BUType _
           , Address _
           , tel _
           , StartWorkDate _
           , EndWorkDate _
           , Position _
           , Department _
           , WorkType _
           , JobDesc _
           , isNote _
           , UpdBy)


    End Function

    Public Function CustomerJobHistory_Get(ByVal pUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("CustomerJobHistory_Get"), pUID)
        Return ds.Tables(0)
    End Function
    Public Function CustomerJobHistory_GetByUID(ByVal pUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("CustomerJobHistory_GetByUID"), pUID)
        Return ds.Tables(0)
    End Function
    Public Function CustomerJobHistory_GetUID(ByVal pUID As Integer, JobCompany As String, JobPosition As String, JobWorkTime As Integer) As Integer
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("CustomerJobHistory_GetUID"), pUID, JobCompany, JobPosition, JobWorkTime)

        If ds.Tables(0).Rows.Count > 0 Then
            Return DBNull2Zero(ds.Tables(0).Rows(0)(0))
        Else
            Return 0
        End If
    End Function
    Public Function CustomerJobHistory_Delete(ByVal pUID As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("CustomerJobHistory_Delete"), pUID)

    End Function


#End Region

#Region "Risk Factor"

    Public Function CustomerRiskFactor_Get(ByVal JobHistoryUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("CustomerRisk_Get"), JobHistoryUID)
        Return ds.Tables(0)
    End Function
    Public Function CustomerRisk_Save(ByVal JobHistoryUID As Integer,
            ByVal AttributeUID As Integer, ByVal CustomerUID As Integer, ByVal DataValue As String, ByVal UpdBy As Integer) As Integer

        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("CustomerRisk_Save"), JobHistoryUID, AttributeUID,
             CustomerUID _
           , DataValue _
           , UpdBy)

    End Function
    Public Function CustomerRisk_Delete(ByVal JobHistoryUID As Integer) As Integer

        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("CustomerRisk_Delete"), JobHistoryUID)

    End Function
#End Region
#Region "PPE"

    Public Function CustomerPPE_Get(ByVal JobHistoryUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("CustomerPPE_Get"), JobHistoryUID)
        Return ds.Tables(0)
    End Function
    Public Function CustomerPPE_Save(ByVal CustomerUID As Integer, ByVal PPEUID As Integer, ByVal DataValue As String, ByVal UpdBy As Integer) As Integer

        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("CustomerPPE_Save"), PPEUID, CustomerUID _
           , DataValue _
           , UpdBy)
    End Function

    Public Function CustomerPPE_Delete(ByVal JobHistoryUID As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("CustomerPPE_Delete"), JobHistoryUID)
    End Function
#End Region


#Region "HealthHistory"
    Public Function CustomerHealthHistory_GetByCustomerUID(ByVal pUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("CustomerHealthHistory_GetByCustomerUID"), pUID)
        Return ds.Tables(0)
    End Function
    Public Function CustomerHealthHistory_Delete(ByVal CustomerUID As Integer)
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("CustomerHealthHistory_Delete"), CustomerUID)
    End Function
    Public Function CustomerHealthHistory_Save(ByVal param As String())
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("HealthHistory_Save"), param)
    End Function
    Public Function CustomerHealthHistory_Save(
           ByVal CustomerUID As Integer _
      , ByVal isCongenitalDisease As String _
      , ByVal DiseaseDetail As String _
      , ByVal isSurgery As String _
      , ByVal SurgeryDetail As String _
      , ByVal isImmunity As String _
      , ByVal ImmunityDetail As String _
      , ByVal isMedicine As String _
      , ByVal MedicineDetail As String _
      , ByVal isAllergy As String _
      , ByVal AllergyDetail As String _
      , ByVal isSmoking As String _
      , ByVal SmokeQTY As String _
      , ByVal SmokeQTYBefore As String _
      , ByVal SmokeTime As String _
      , ByVal SmokeUOM As String _
      , ByVal isAlcohol As String _
      , ByVal DrinkFrequency As String _
      , ByVal DrinkTime As String _
      , ByVal DrinkUOM As String _
      , ByVal isDrugs As String _
      , ByVal DrugsDetail As String _
      , ByVal Remark As String _
      , ByVal CUser As Integer) As Integer

        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("HealthHistory_Save"), CustomerUID, isCongenitalDisease _
      , DiseaseDetail _
      , isSurgery _
      , SurgeryDetail _
      , isImmunity _
      , ImmunityDetail _
      , isMedicine _
      , MedicineDetail _
      , isAllergy _
      , AllergyDetail _
      , isSmoking _
      , SmokeQTY _
      , SmokeQTYBefore _
      , SmokeTime _
      , SmokeUOM _
      , isAlcohol _
      , DrinkFrequency _
      , DrinkTime _
      , DrinkUOM _
      , isDrugs _
      , DrugsDetail _
      , Remark _
      , CUser)
    End Function
    Public Function HealthFamily_Add(ByVal PUID As Integer, Relation As Integer, Desc As String, Cuser As String)
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("HealthFamily_Add"), PUID, Relation, Desc, Cuser)
    End Function
    Public Function HealthFamily_Update(UID As Integer, ByVal PUID As Integer, Relation As Integer, Desc As String, Cuser As String)
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("HealthFamily_Update"), UID, PUID, Relation, Desc, Cuser)
    End Function
    Public Function HealthFamily_Delete(ByVal PUID As Integer)
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("HealthFamily_Delete"), PUID)
    End Function

    Public Function HealthFamily_GetByCustomerUID(ByVal pUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("HealthFamily_GetByCustomerUID"), pUID)
        Return ds.Tables(0)
    End Function
    Public Function HealthFamily_GetByUID(ByVal pUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("HealthFamily_GetByUID"), pUID)
        Return ds.Tables(0)
    End Function

    Public Function Vaccine_Add(ByVal PUID As Integer, VWhen As String, VaccineUID As Integer, Remark As String, Cuser As String)
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("CustomerVaccine_Add"), PUID, VWhen, VaccineUID, Remark, Cuser)
    End Function
    Public Function Vaccine_Update(ByVal PUID As Integer, Relation As Integer, Desc As String, Cuser As String)
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("CustomerVaccine_Update"), PUID, Relation, Desc, Cuser)
    End Function
    Public Function Vaccine_Delete(ByVal PUID As Integer)
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("CustomerVaccine_Delete"), PUID)
    End Function

    Public Function Vaccine_GetByCustomerUID(ByVal pUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("CustomerVaccine_GetByCustomerUID"), pUID)
        Return ds.Tables(0)
    End Function
    Public Function Vaccine_GetByUID(ByVal pUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("CustomerVaccine_GetByUID"), pUID)
        Return ds.Tables(0)
    End Function
#End Region

    Public Function CustomerROWL_Get(CustomerUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("CustomerROWL_Get"), CustomerUID)
        Return ds.Tables(0)
    End Function

    Public Function CustomerErgonomicRisk_Get(CustomerUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("CustomerErgonomicRisk_Get"), CustomerUID)
        Return ds.Tables(0)
    End Function
    Public Function CustomerErgonomicRisk_Save(ByVal CustomerUID As Integer, BodyPart As String, Side As String, Score As Integer, Freq As Integer) As Integer
        Return SqlHelper.ExecuteNonQuery(ConnectionString, GetFullyQualifiedName("CustomerErgonomicRisk_Save"), CustomerUID, BodyPart, Side, Score, Freq)
    End Function


#Region "Personal Health Risk"

    Public Function CustomerRisk_Get(Optional CompanyUID As Integer = 0) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("CustomerRisk_Get"), CompanyUID)
        Return ds.Tables(0)
    End Function

    Public Function CustomerBodyRisk_Get(CustomerUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("CustomerBodyRisk_Get"), CustomerUID)
        Return ds.Tables(0)
    End Function
    Public Function CustomerBodyRisk_GetMax(CustomerUID As Integer) As DataTable
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("CustomerBodyRisk_GetMax"), CustomerUID)
        Return ds.Tables(0)
    End Function
    Public Function CustomerErgonomic_GetMax(CustomerUID As Integer) As Integer
        ds = SqlHelper.ExecuteDataset(ConnectionString, GetFullyQualifiedName("CustomerErgonomic_GetMax"), CustomerUID)
        If ds.Tables(0).Rows.Count > 0 Then
            Return DBNull2Zero(ds.Tables(0).Rows(0)(0))
        Else
            Return 0
        End If
    End Function

#End Region

End Class