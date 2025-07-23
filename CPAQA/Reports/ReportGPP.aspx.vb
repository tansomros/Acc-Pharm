Imports BigLion

Public Class ReportGPP1
    Inherits System.Web.UI.Page
    Dim ctlP As New PharmacistController
    Dim ctlA As New AssessmentController
    Public dtGPP As New DataTable
    Public dtPm As New DataTable
    Public dtAs As New DataTable
    Dim dt As New DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        dt = ctlA.GPP_Assessment_GetByUID(Request("id"))

        If dt.Rows.Count > 0 Then
            With dt.Rows(0)
                lblDate.Text = DisplayDateTH(.Item("AsmDate"))

                dtAs = ctlA.RPT_Assessor(Request("id"))
                dtPm = ctlP.Pharmacist_Get(.Item("LocationUID"))
                lblPmCount.Text = StrNull2Zero(dtPm.Rows.Count)
                dtGPP = ctlA.RPT_GPP_Picture(.Item("UID"))

                lblRemark1.Text = String.Concat(.Item("Remark1"))
                lblRemark2.Text = String.Concat(.Item("Remark2"))
                lblRemark3.Text = String.Concat(.Item("Remark3"))
                lblRemark4.Text = String.Concat(.Item("Remark4"))
                lblRemark5.Text = String.Concat(.Item("Remark5"))

                lblPercentGroup1.Text = String.Concat(.Item("PercentGroup1"))
                lblPercentGroup2.Text = String.Concat(.Item("PercentGroup2"))
                lblPercentGroup3.Text = String.Concat(.Item("PercentGroup3"))
                lblPercentGroup4.Text = String.Concat(.Item("PercentGroup4"))
                lblPercentGroup5.Text = String.Concat(.Item("PercentGroup5"))

                lblPercentage.Text = ((StrNull2Double(lblPercentGroup1.Text) + StrNull2Double(lblPercentGroup2.Text) + StrNull2Double(lblPercentGroup3.Text) + StrNull2Double(lblPercentGroup4.Text) + StrNull2Double(lblPercentGroup5.Text)) / 5).ToString("#.#0")

                lblResult.Text = IIf(.Item("FinalResult") = "Y", "ผ่าน", "ไม่ผ่าน")
                lblRemark.Text = String.Concat(.Item("Remark"))

                lblPercentGroup1.ForeColor = System.Drawing.Color.Gray
                lblPercentGroup2.ForeColor = System.Drawing.Color.Gray
                lblPercentGroup3.ForeColor = System.Drawing.Color.Gray
                lblPercentGroup4.ForeColor = System.Drawing.Color.Gray
                lblPercentGroup5.ForeColor = System.Drawing.Color.Gray

                If StrNull2Double(lblPercentGroup1.Text) < 70 Or StrNull2Double(lblPercentGroup2.Text) < 70 Or StrNull2Double(lblPercentGroup3.Text) < 70 Or StrNull2Double(lblPercentGroup4.Text) < 70 Or StrNull2Double(lblPercentGroup5.Text) < 70 Or StrNull2Double(lblPercentage.Text) < 70 Then
                    lblResult.Text = "ไม่ผ่าน"
                    lblResult.ForeColor = System.Drawing.Color.Red
                End If

                If .Item("FinalResult") = "N" Then
                    lblResult.ForeColor = System.Drawing.Color.Red
                End If

                'If StrNull2Double(lblPercentGroup1.Text) < 70 Then
                '    lblPercentGroup1.ForeColor = System.Drawing.Color.Red
                '    lblResultRemark.Text = lblResultRemark.Text & "  หมวดที่ 1,"
                'End If
                'If StrNull2Double(lblPercentGroup2.Text) < 70 Then
                '    lblPercentGroup2.ForeColor = System.Drawing.Color.Red
                '    lblResultRemark.Text = lblResultRemark.Text & " หมวดที่ 2,"
                'End If
                'If StrNull2Double(lblPercentGroup3.Text) < 70 Then
                '    lblPercentGroup3.ForeColor = System.Drawing.Color.Red
                '    lblResultRemark.Text = lblResultRemark.Text & " หมวดที่ 3,"
                'End If
                'If StrNull2Double(lblPercentGroup4.Text) < 70 Then
                '    lblPercentGroup4.ForeColor = System.Drawing.Color.Red
                '    lblResultRemark.Text = lblResultRemark.Text & " หมวดที่ 4,"
                'End If
                'If StrNull2Double(lblPercentGroup5.Text) < 70 Then
                '    lblPercentGroup5.ForeColor = System.Drawing.Color.Red
                '    lblResultRemark.Text = lblResultRemark.Text & " หมวดที่ 5 "
                'End If


                LoadLocationDetail(.Item("LocationUID"))
            End With
        End If

        Dim grpGpp As String = ""

        dt = ctlA.RPT_GPP_Critical(Request("id"))
        If dt.Rows.Count > 0 Then
            For i = 0 To dt.Rows.Count - 1
                With dt.Rows(i)
                    If String.Concat(.Item("GroupID")) <> grpGpp Then
                        lblResultRemark.Text = lblResultRemark.Text & "  หมวดที่ " & .Item("GroupID") & "  ข้อ "
                        grpGpp = String.Concat(.Item("GroupID"))
                        Select Case grpGpp
                            Case 1
                                lblPercentGroup1.ForeColor = System.Drawing.Color.Red
                            Case 2
                                lblPercentGroup2.ForeColor = System.Drawing.Color.Red
                            Case 3
                                lblPercentGroup3.ForeColor = System.Drawing.Color.Red
                            Case 4
                                lblPercentGroup4.ForeColor = System.Drawing.Color.Red
                            Case 5
                                lblPercentGroup5.ForeColor = System.Drawing.Color.Red
                        End Select
                    End If
                    lblResultRemark.Text = lblResultRemark.Text & .Item("Code") & ","
                End With
            Next
        End If

        If lblResultRemark.Text.Length > 0 Then
            lblResultRemark.ForeColor = System.Drawing.Color.Red
            lblResultRemark.Text = Left(lblResultRemark.Text, lblResultRemark.Text.Length - 1)
        End If

        Dim ctlD As New DocumentController
        dt = ctlD.GPPDocument_Get(Request("id"))
        grdDocument.DataSource = dt
        grdDocument.DataBind()



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