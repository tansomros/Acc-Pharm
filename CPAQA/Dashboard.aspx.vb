Imports BigLion

Public Class Dashboard
    Inherits System.Web.UI.Page
    Dim ctlR As New ReportController
    Dim dt As New DataTable

    Dim dtType As New DataTable 'ประเภทร้านยา
    Dim dtNHSO As New DataTable 'สปสช
    Public dtProv As New DataTable 'จังหวัด
    Dim dtGroup As New DataTable 'ภาค
    Dim dtChain As New DataTable 'chain
    Public Shared catebarType As String
    Public Shared catebarNHSO As String
    Public Shared catebarGroup As String
    Public Shared catebarChain As String

    Public Shared databarType As String
    Public Shared databarNHSO As String
    Public Shared databarGroup As String
    Public Shared databarChain As String

    'Public Shared cateChart1 As String
    Public Shared Datachart1 As String

    Public Shared hCatebar As String
    Public Shared hDatabar1 As String


    Dim ctlN As New NewsController
    Public dtNew As New DataTable

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsNothing(Request.Cookies("CPAQA")) Then
            Response.Redirect("Default")
        End If

        If Not IsPostBack Then
            dtNew = ctlN.News_GetFirstPage("2")
        End If
        '    If Not IsNothing(Request.Cookies("CPA")) Then
        'SendAlertOwner()
        dtProv = ctlR.RPT_Pharmacy_GetCountByProvince

        dt = ctlR.RPT_Pharmacy_ByAccStatus_ForChart()

        Datachart1 = dt.Rows(0)(0).ToString()   'JsonConvert.SerializeObject(dt, Formatting.None)
        'cateChart1 = "ร้านยาคุณภาพ,ไม่ใช่ร้านยาคุณภาพ,ร้านยาทั้งหมด"

        dtType = ctlR.RPT_Pharmacy_GetCountByType

        catebarType = ""
        catebarNHSO = ""
        catebarGroup = ""
        catebarChain = ""

        databarType = ""
        databarNHSO = ""
        databarGroup = ""
        databarChain = ""

        For i = 0 To dtType.Rows.Count - 1
            catebarType = catebarType + "'" + dtType.Rows(i)("TypeName") + "'"
            databarType = databarType + dtType.Rows(i)("LCount").ToString()

            If i < dtType.Rows.Count - 1 Then
                catebarType = catebarType + ","
                databarType = databarType + ","
            End If
        Next


        dtNHSO = ctlR.RPT_Pharmacy_GetCountByNHSOGroup

        For i = 0 To dtNHSO.Rows.Count - 1
            catebarNHSO = catebarNHSO + "'" + dtNHSO.Rows(i)("GroupName") + "'"
            databarNHSO = databarNHSO + dtNHSO.Rows(i)("LCount").ToString()

            If i < dtNHSO.Rows.Count - 1 Then
                catebarNHSO = catebarNHSO + ","
                databarNHSO = databarNHSO + ","
            End If
        Next

        dtGroup = ctlR.RPT_Pharmacy_GetCountByProvinceGroup

        For i = 0 To dtGroup.Rows.Count - 1
            catebarGroup = catebarGroup + "'" + dtGroup.Rows(i)("ProvinceGroupName") + "'"
            databarGroup = databarGroup + dtGroup.Rows(i)("LCount").ToString()

            If i < dtGroup.Rows.Count - 1 Then
                catebarGroup = catebarGroup + ","
                databarGroup = databarGroup + ","
            End If
        Next

        dtChain = ctlR.RPT_Pharmacy_GetCountByChainGroup

        For i = 0 To dtChain.Rows.Count - 1
            catebarChain = catebarChain + "'" + dtChain.Rows(i)("ChainName") + "'"
            databarChain = databarChain + dtChain.Rows(i)("LCount").ToString()

            If i < dtChain.Rows.Count - 1 Then
                catebarChain = catebarChain + ","
                databarChain = databarChain + ","
            End If
        Next

        '    End If
        'End If
    End Sub
End Class