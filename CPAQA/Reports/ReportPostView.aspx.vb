Imports BigLion

Public Class ReportPostView
    Inherits System.Web.UI.Page
    Dim ctlP As New PharmacistController
    Dim ctlA As New AssessmentController
    Public dtQA1 As New DataTable
    Public dtQA2 As New DataTable
    Public dtQA3 As New DataTable
    Public dtQA4 As New DataTable
    Public dtQA5 As New DataTable
    Public dtPm As New DataTable
    Public dtAs As New DataTable

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim dtP As New DataTable
        dtP = ctlA.RPT_PostAudit_GetByUID(Request("id"))

        If dtP.Rows.Count > 0 Then
            With dtP.Rows(0)
                lblDate.Text = DisplayDateTH(.Item("AsmDate"))

                dtAs = ctlA.RPT_AssessorByLocation(.Item("LocationUID"))

                dtPm = ctlP.Pharmacist_Get(.Item("LocationUID"))
                lblPmCount.Text = StrNull2Zero(dtPm.Rows.Count)
                lblAssessee.Text = String.Concat(.Item("Pharmacist"))
                lblPosition.Text = String.Concat(.Item("PositionName"))
                lblMethod.Text = String.Concat(.Item("MethodName"))


                lblQA1.Text = String.Concat(.Item("QA1Result"))
                lblQA2.Text = String.Concat(.Item("QA2Result"))
                lblQA3.Text = String.Concat(.Item("QA3Result"))
                lblQA4.Text = String.Concat(.Item("QA4Result"))
                lblQA5.Text = String.Concat(.Item("QA5Result"))

                dtQA1 = ctlA.QAStandard_Get(.Item("UID"), 1)
                dtQA2 = ctlA.QAStandard_Get(.Item("UID"), 2)
                dtQA3 = ctlA.QAStandard_Get(.Item("UID"), 3)
                dtQA4 = ctlA.QAStandard_Get(.Item("UID"), 4)
                dtQA5 = ctlA.QAStandard_Get(.Item("UID"), 5)

                lblQARemark.Text = String.Concat(.Item("QARemark"))

                If String.Concat(.Item("QAResult")) = "1" Then
                    lblQAResult.Text = "ผ่าน"
                    lblQAResult.ForeColor = System.Drawing.Color.Green
                    lblQARemark.Text = "-"
                ElseIf String.Concat(.Item("QAResult")) = "2" Then
                    lblQAResult.Text = "แก้ไข"
                    lblQAResult.ForeColor = System.Drawing.Color.Red
                ElseIf String.Concat(.Item("QAResult")) = "3" Then
                    lblQAResult.Text = "อื่นๆ"
                Else
                    lblQAResult.Text = ""
                End If

                If String.Concat(.Item("QAInformDate")) <> "" Then
                    lblQAInformDate.Text = DisplayDateTH(.Item("QAInformDate"))
                End If

                If String.Concat(.Item("QAResponseDate")) <> "" Then
                    lblQAResponseDate.Text = DisplayDateTH(.Item("QAResponseDate"))
                End If

                If String.Concat(.Item("QACloseDate")) <> "" Then
                    lblQACloseDate.Text = DisplayDateTH(.Item("QACloseDate"))
                End If


                If String.Concat(.Item("QAComplete")) = "1" Then
                    lblQAComplete.Text = "เรียบร้อย"
                    lblQAComplete.ForeColor = System.Drawing.Color.Green
                Else
                    lblQAComplete.Text = "ไม่เรียบร้อย"
                    lblQAComplete.ForeColor = System.Drawing.Color.Red
                End If


                lblCI1.Text = IIf(String.Concat(.Item("CI1")) = "Y", "ตรงตามมาตรฐาน", IIf(String.Concat(.Item("CI1")) = "N", "ไม่เป็นไปตามมาตรฐาน", ""))
                lblCI2.Text = IIf(String.Concat(.Item("CI2")) = "Y", "ตรงตามมาตรฐาน", IIf(String.Concat(.Item("CI2")) = "N", "ไม่เป็นไปตามมาตรฐาน", ""))
                lblCI3.Text = IIf(String.Concat(.Item("CI3")) = "Y", "ตรงตามมาตรฐาน", IIf(String.Concat(.Item("CI3")) = "N", "ไม่เป็นไปตามมาตรฐาน", ""))
                lblCI4.Text = IIf(String.Concat(.Item("CI4")) = "Y", "ตรงตามมาตรฐาน", IIf(String.Concat(.Item("CI4")) = "N", "ไม่เป็นไปตามมาตรฐาน", ""))
                lblCI5.Text = IIf(String.Concat(.Item("CI5")) = "Y", "ตรงตามมาตรฐาน", IIf(String.Concat(.Item("CI5")) = "N", "ไม่เป็นไปตามมาตรฐาน", ""))
                lblCI6.Text = IIf(String.Concat(.Item("CI6")) = "Y", "ตรงตามมาตรฐาน", IIf(String.Concat(.Item("CI6")) = "N", "ไม่เป็นไปตามมาตรฐาน", ""))
                lblCI7.Text = IIf(String.Concat(.Item("CI7")) = "Y", "ตรงตามมาตรฐาน", IIf(String.Concat(.Item("CI7")) = "N", "ไม่เป็นไปตามมาตรฐาน", ""))
                lblCI8.Text = IIf(String.Concat(.Item("CI8")) = "Y", "ตรงตามมาตรฐาน", IIf(String.Concat(.Item("CI8")) = "N", "ไม่เป็นไปตามมาตรฐาน", ""))
                lblCI9.Text = IIf(String.Concat(.Item("CI9")) = "Y", "ตรงตามมาตรฐาน", IIf(String.Concat(.Item("CI9")) = "N", "ไม่เป็นไปตามมาตรฐาน", ""))
                lblCI10.Text = IIf(String.Concat(.Item("CI10")) = "Y", "ตรงตามมาตรฐาน", IIf(String.Concat(.Item("CI10")) = "N", "ไม่เป็นไปตามมาตรฐาน", ""))
                lblCI11.Text = IIf(String.Concat(.Item("CI11")) = "Y", "ตรงตามมาตรฐาน", IIf(String.Concat(.Item("CI11")) = "N", "ไม่เป็นไปตามมาตรฐาน", ""))
                lblCI12.Text = IIf(String.Concat(.Item("CI12")) = "Y", "ตรงตามมาตรฐาน", IIf(String.Concat(.Item("CI12")) = "N", "ไม่เป็นไปตามมาตรฐาน", ""))
                lblCI13.Text = String.Concat(.Item("CIOther"))

                lblCI1Remark.Text = String.Concat(.Item("CI1Remark"))
                lblCI2Remark.Text = String.Concat(.Item("CI2Remark"))
                lblCI3Remark.Text = String.Concat(.Item("CI3Remark"))
                lblCI4Remark.Text = String.Concat(.Item("CI4Remark"))
                lblCI5Remark.Text = String.Concat(.Item("CI5Remark"))
                lblCI6Remark.Text = String.Concat(.Item("CI6Remark"))
                lblCI7Remark.Text = String.Concat(.Item("CI7Remark"))
                lblCI8Remark.Text = String.Concat(.Item("CI8Remark"))
                lblCI9Remark.Text = String.Concat(.Item("CI9Remark"))
                lblCI10Remark.Text = String.Concat(.Item("CI10Remark"))
                lblCI11Remark.Text = String.Concat(.Item("CI11Remark"))
                lblCI12Remark.Text = String.Concat(.Item("CI12Remark"))


                lblCIRemark.Text = String.Concat(.Item("CIRemark"))
                lblSatisfaction.Text = String.Concat(.Item("CISatisfaction"))
                If String.Concat(.Item("CIResult")) = "1" Then
                    lblCIResult.Text = "ผ่าน"
                    lblCIResult.ForeColor = System.Drawing.Color.Green
                    lblCIRemark.Text = "-"
                ElseIf String.Concat(.Item("CIResult")) = "2" Then
                    lblCIResult.Text = "แก้ไข"
                    lblCIResult.ForeColor = System.Drawing.Color.Red
                ElseIf String.Concat(.Item("CIResult")) = "3" Then
                    lblCIResult.Text = "อื่นๆ"
                Else
                    lblCIResult.Text = ""
                End If

                If String.Concat(.Item("CIInformDate")) <> "" Then
                    lblCIInformDate.Text = DisplayDateTH(.Item("CIInformDate"))
                End If

                If String.Concat(.Item("CIResponseDate")) <> "" Then
                    lblCIResponseDate.Text = DisplayDateTH(.Item("CIResponseDate"))
                End If

                If String.Concat(.Item("CICloseDate")) <> "" Then
                    lblCICloseDate.Text = DisplayDateTH(.Item("CICloseDate"))
                End If


                If String.Concat(.Item("CIComplete")) = "1" Then
                    lblCIComplete.Text = "เรียบร้อย"
                    lblCIComplete.ForeColor = System.Drawing.Color.Green
                Else
                    lblCIComplete.Text = "ไม่เรียบร้อย"
                    lblCIComplete.ForeColor = System.Drawing.Color.Red
                End If

                LoadLocationDetail(.Item("LocationUID"))
                LoadImgQAResult()
                LoadImgCIResult()
            End With
        End If
    End Sub

    Dim ctlM As New MediaController
    Dim dt As New DataTable
    Private Sub LoadImgQAResult()
        dt = ctlM.PostAuditFile_Get(Request("id"), "Q3")
        dtlImgQAResult.DataSource = dt
        dtlImgQAResult.DataBind()
    End Sub
    Private Sub LoadImgCIResult()
        dt = ctlM.PostAuditFile_Get(Request("id"), "C3")
        dtlImgCIResult.DataSource = dt
        dtlImgCIResult.DataBind()
    End Sub

    Private Sub LoadLocationDetail(LID As Integer)
        Dim dtL As New DataTable
        Dim ctlL As New LocationController
        dtL = ctlL.Location_GetByUID(LID)

        If dtL.Rows.Count > 0 Then
            With dtL.Rows(0)
                Try
                    lblLicenseNo.Text = String.Concat(.Item("LicenseNo1"))
                    lblLocationName.Text = String.Concat(.Item("LocationName"))
                    lblAddress.Text = String.Concat(.Item("LocationAddress"))
                    lblTel.Text = String.Concat(.Item("tel"))
                    lblAddress.Text = String.Concat(.Item("LocationAddress"))

                    lblAccPharm.Text = String.Concat(.Item("AccLicense"))

                    'lblLicenseStatus.Text = DisplayLicenseStatus(String.Concat(.Item("LicenseStatus")))
                    'lblStartDate.Text = String.Concat(.Item("LicenseStartDate"))
                    'lblExpireDate.Text = String.Concat(.Item("LicenseExpireDate"))
                    lblLicensee.Text = String.Concat(.Item("Licensee"))
                Catch ex As Exception

                End Try
            End With
        End If
    End Sub

End Class