Imports BigLion

Public Class Dashboard2
    Inherits System.Web.UI.Page
    'Dim ctlR As New LocationController
    Dim ctlR As New ReportController
    Dim dt As New DataTable
    Public Shared hDatachart1 As String
    Public Shared hDatachart2 As String
    Public Shared hDatachart3 As String
    Public Shared hDatachart4 As String
    Public Shared hDatachart5 As String
    Public Shared hDatachart6 As String
    Public Shared hDatachart7 As String

    'Public Shared hCatebar As String
    'Public Shared hDatabar1 As String

    Dim dtType As New DataTable 'ประเภทร้านยา
    'Dim dtNHSO As New DataTable 'สปสช
    'Public dtProv As New DataTable 'จังหวัด
    'Dim dtGroup As New DataTable 'ภาค
    'Dim dtChain As New DataTable 'chain
    Public Shared catebarType2 As String
    'Public Shared catebarNHSO As String
    'Public Shared catebarGroup As String
    'Public Shared catebarChain As String

    Public Shared databarType2 As String
    'Public Shared databarNHSO As String
    'Public Shared databarGroup As String
    'Public Shared databarChain As String

    Public Shared dataLocAll As String


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsNothing(Request.Cookies("CPA")) Then
            Response.Redirect("Default")
        End If

        If Not IsPostBack Then
        End If
        '    If Not IsNothing(Request.Cookies("CPA")) Then
        'SendAlertOwner()

        dt = ctlR.RPT_Pharmacy_ByType1_ForChart()
        hDatachart1 = dt.Rows(0)(0).ToString()

        dt = ctlR.RPT_Pharmacy_ByType2_ForChart()
        hDatachart2 = dt.Rows(0)(0).ToString()

        dt = ctlR.RPT_Pharmacy_ByType3_ForChart()
        hDatachart3 = dt.Rows(0)(0).ToString()

        dt = ctlR.RPT_Pharmacy_ByType4_ForChart()
        hDatachart4 = dt.Rows(0)(0).ToString()

        dt = ctlR.RPT_Pharmacy_ByType5_ForChart()
        hDatachart5 = dt.Rows(0)(0).ToString()

        dt = ctlR.RPT_Pharmacy_ByType6_ForChart()
        hDatachart6 = dt.Rows(0)(0).ToString()

        dt = ctlR.RPT_Pharmacy_ByType7_ForChart()
        hDatachart7 = dt.Rows(0)(0).ToString()



        'JsonConvert.SerializeObject(dt, Formatting.None)

        'catebarType = ""
        'catebarNHSO = ""
        'databarType = ""
        'databarNHSO = ""

        Dim iAll, iVal As Integer
        iVal = 0
        iAll = ctlR.RPT_Pharmacy_GetCountAll

        dtType = ctlR.RPT_Pharmacy_GetCountByType

        catebarType2 = ""
        databarType2 = ""

        For i = 0 To dtType.Rows.Count - 1
            catebarType2 = catebarType2 + "'" + dtType.Rows(i)("TypeName") + "'"
            databarType2 = databarType2 + dtType.Rows(i)("LCount").ToString()

            iVal = iVal + DBNull2Zero(dtType.Rows(i)("LCount"))

            If i < dtType.Rows.Count - 1 Then
                catebarType2 = catebarType2 + ","
                databarType2 = databarType2 + ","
            End If
        Next

    End Sub
End Class