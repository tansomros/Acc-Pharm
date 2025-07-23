Imports System
Imports System.IO
Imports System.Web.UI
Imports BigLion
Public Class AsmGPP
    Inherits System.Web.UI.Page
    Dim ctlU As New UserController
    Dim ctlL As New LocationController
    Dim dt As New DataTable
    Dim ctlPs As New PharmacistController
    Dim ctlM As New MediaController
    Dim ctlA As New AssessmentController
    Dim ctlD As New DocumentController
    Private UploadDirectory As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsNothing(Request.Cookies("CPAQA")) Then
            Response.Redirect("Default.aspx")
        End If

        Response.Cache.SetExpires(DateTime.Now.AddSeconds(60))
        Response.Cache.SetCacheability(HttpCacheability.Public)
        Response.Cache.SetValidUntilExpires(True)

        If Not IsPostBack Then
            lblYear.Text = ctlA.GET_DATE_SERVER().Year
            If (ctlL.LocationAllocate_CheckPermission(StrNull2Zero(lblYear.Text), StrNull2Zero(Request.Cookies("UserID").Value))) = False Then
                Response.Redirect("ResultPage?p=NotAllow&y=" & lblYear.Text)
            End If

            pnDoc.Visible = False
            cmdReOpen.Visible = False
            cmdClose.Visible = False
            hdRequestUID.Value = 0
            hdLocationUID.Value = Request("lid")

            LoadRiskGPP()

            If Not Request("id") = Nothing Then
                LoadGPPAssessment()
            End If
            LoadLocationDetail(hdLocationUID.Value)
            UploadDirectory = Server.MapPath("~/imageUploads/" & hdLocationUID.Value & "/GPP/")
            If Not Directory.Exists(UploadDirectory) Then
                Directory.CreateDirectory(UploadDirectory)
            End If

            If Convert.ToInt32(Request.Cookies("ROLE_ID").Value) >= 5 And Convert.ToInt32(Request.Cookies("ROLE_ID").Value) <= 7 Then
                FileUpload1.Enabled = False
                cmdUpImg.Visible = False
                grdImg.Columns(3).Visible = False
                Label2.Visible = True
                Label2.Text = "ท่านไม่สามารถแก้ไขรายละเอียดได้ สามารถดูได้อย่างเดียว"
                DisableControl(False)
                cmdSave.Visible = False
                cmdClose.Visible = False
                cmdReOpen.Visible = False
                cmdAddFile.Visible = False
                txtDocumentName.Enabled = False
            End If
        End If
        cmdDelete.Attributes.Add("onClick", "javascript:return confirm(""ต้องการลบการประเมินนี้ ใช่หรือไม่?"");")
        cmdClose.Attributes.Add("onClick", "javascript:return confirm(""ต้องการปิดการประเมินนี้ ใช่หรือไม่?"");")
        cmdReOpen.Attributes.Add("onClick", "javascript:return confirm(""ต้องการเปิดการประเมินนี้อีกครั้ง ใช่หรือไม่?"");")
    End Sub
    Private Sub LoadRiskGPP()
        Dim ctlbase As New MasterController
        dt = ctlbase.ReferenceValue_GetByDomainCode("RISKGPP")
        If dt.Rows.Count > 0 Then
            With chkRisk
                .Enabled = True
                .DataSource = dt
                .DataTextField = "Descriptions"
                .DataValueField = "ValueCode"
                .DataBind()
            End With
        End If
        dt = Nothing
    End Sub
    Private Sub LoadGPPRisk(GPPUID As Integer)
        Dim dtC As New DataTable
        dtC = ctlA.GPPRisk_Get(GPPUID)
        If dtC.Rows.Count > 0 Then
            chkRisk.ClearSelection()
            For i = 0 To chkRisk.Items.Count - 1
                For n = 0 To dtC.Rows.Count - 1
                    If chkRisk.Items(i).Value = dtC.Rows(n)("RiskCode") Then
                        chkRisk.Items(i).Selected = True
                    End If
                Next
            Next
        End If
    End Sub

    Private Sub LoadLocationDetail(LID As Integer)
        Dim dtL As New DataTable
        dtL = ctlL.Location_GetByUID(LID)

        If dtL.Rows.Count > 0 Then
            With dtL.Rows(0)
                Try
                    lblLicenseNo.Text = String.Concat(.Item("LicenseNo1"))
                    lblLicenseNo.Text = String.Concat(.Item("LicenseNo1"))
                    lblLocationName.Text = String.Concat(.Item("LocationName"))
                    lblAddress.Text = String.Concat(.Item("LocationAddress"))
                    lblTel.Text = String.Concat(.Item("tel"))
                    lblAddress.Text = String.Concat(.Item("LocationAddress"))

                    lblLicenseStatus.Text = DisplayLicenseStatus(String.Concat(.Item("LicenseStatus")))
                    lblStartDate.Text = String.Concat(.Item("LicenseStartDate"))
                    lblExpireDate.Text = String.Concat(.Item("LicenseExpireDate"))
                    lblLicensee.Text = String.Concat(.Item("Licensee"))
                Catch ex As Exception

                End Try
            End With
        End If
    End Sub

    Private Sub LoadGPPAssessment()
        'If Not Request("id") = Nothing Then
        dt = ctlA.GPP_Assessment_GetByUID(Request("id"))
        'Else
        '    Exit Sub
        '    'dt = ctlA.GPP_Assessment_GetByLocation(hdLocationUID.Value)
        'End If

        If dt.Rows.Count > 0 Then
            cmdClose.Visible = True
            pnDoc.Visible = True

            hdGPPUID.Value = String.Concat(dt.Rows(0)("UID"))
            hdLocationUID.Value = String.Concat(dt.Rows(0)("LocationUID"))
            hdRequestUID.Value = String.Concat(dt.Rows(0)("RequestUID"))
            lblYear.Text = String.Concat(dt.Rows(0)("AsmYear"))
            hdTotalScore.Value = String.Concat(dt.Rows(0)("TotalScore"))
            hdNetScore.Value = String.Concat(dt.Rows(0)("FinalScore"))
            lblPercentage.Text = String.Concat(dt.Rows(0)("PercentageScore"))
            lblResult.Text = IIf(String.Concat(dt.Rows(0)("FinalResult")) = "Y", "ผ่าน", "ไม่ผ่าน")
            If String.Concat(dt.Rows(0)("FinalResult")) = "Y" Then
                lblResult.ForeColor = System.Drawing.Color.Green
            Else
                lblResult.ForeColor = System.Drawing.Color.Red
            End If
            txtRemark1.Text = String.Concat(dt.Rows(0)("Remark1"))
            txtRemark2.Text = String.Concat(dt.Rows(0)("Remark2"))
            txtRemark3.Text = String.Concat(dt.Rows(0)("Remark3"))
            txtRemark4.Text = String.Concat(dt.Rows(0)("Remark4"))
            txtRemark5.Text = String.Concat(dt.Rows(0)("Remark5"))
            txtRemark.Text = String.Concat(dt.Rows(0)("Remark"))

            txtRiskRemark.Text = String.Concat(dt.Rows(0)("RiskRemark"))


            If String.Concat(dt.Rows(0)("CloseStatus")) = "Y" Then
                cmdSave.Visible = False
                cmdClose.Visible = False
                cmdReOpen.Visible = True
                FileUpload1.Enabled = False
                cmdUpImg.Visible = False
                grdImg.Columns(3).Visible = False
                Label2.Visible = True
                Label2.Text = "สถานะปัจจุบันไม่สามารถออัพโหลดหรือแก้ไขรูปภาพได้อีก"
                DisableControl(False)
            Else

                'If String.Concat(dt.Rows(0)("isYear")) <> "Y" Then
                '    cmdSave.Visible = False
                '    cmdClose.Visible = False
                '    FileUpload1.Enabled = False
                '    cmdUpImg.Visible = False
                '    grdImg.Columns(3).Visible = False
                '    Label2.Visible = True
                '    Label2.Text = "สถานะปัจจุบันไม่สามารถออัพโหลดหรือแก้ไขรูปภาพได้อีก"
                '    DisableControl(False)
                'End If
            End If

            If DBNull2Zero(dt.Rows(0)("RequestUID")) > 0 Then
                cmdSave.Visible = False
                cmdReOpen.Visible = False
                cmdClose.Visible = False
                DisableControl(False)
            End If

            If String.Concat(dt.Rows(0)("FinalClose")) = "Y" Then
                cmdDelete.Visible = False
                cmdSave.Visible = False
                cmdClose.Visible = False
                cmdReOpen.Visible = False
                FileUpload1.Enabled = False
                cmdUpImg.Visible = False
                grdImg.Columns(3).Visible = False
                Label2.Visible = True
                Label2.Text = "สถานะปัจจุบันไม่สามารถออัพโหลดหรือแก้ไขรูปภาพได้อีก"
                DisableControl(False)
            End If

            LoadGPP_Score()
            LoadDocument()
            LoadGPPRisk(StrNull2Zero(hdGPPUID.Value))
        Else
            lblYear.Text = ctlA.GET_DATE_SERVER().Year
        End If
    End Sub
    Private Sub DisableControl(sKey As Boolean)
        optS1Q1.Enabled = sKey
        optS1Q2.Enabled = sKey
        chkS1Q2.Enabled = sKey
        optS1Q3.Enabled = sKey
        optS1Q4.Enabled = sKey
        optS1Q5.Enabled = sKey
        optS1Q6.Enabled = sKey
        optS1Q7.Enabled = sKey
        optS1Q8.Enabled = sKey
        optS1Q9.Enabled = sKey
        optS2Q1.Enabled = sKey
        chkS2Q1.Enabled = sKey
        optS2Q2.Enabled = sKey
        optS2Q3.Enabled = sKey
        optS2Q4.Enabled = sKey
        optS2Q5.Enabled = sKey
        optS2Q6.Enabled = sKey
        optS3Q1.Enabled = sKey
        optS3Q2.Enabled = sKey
        chkS3Q2.Enabled = sKey
        optS3Q3.Enabled = sKey
        optS3Q4.Enabled = sKey
        chkS3Q4.Enabled = sKey
        optS3Q5.Enabled = sKey
        chkS3Q5.Enabled = sKey
        optS4Q1.Enabled = sKey
        optS4Q2.Enabled = sKey
        optS4Q3.Enabled = sKey
        optS4Q4.Enabled = sKey
        optS4Q5.Enabled = sKey
        optS4Q6.Enabled = sKey
        optS4Q7.Enabled = sKey
        optS5Q1.Enabled = sKey
        optS5Q2.Enabled = sKey
        optS5Q3.Enabled = sKey
        optS5Q4.Enabled = sKey
        optS5Q5.Enabled = sKey
        optS5Q6.Enabled = sKey
        optS5Q7.Enabled = sKey
        chkS5Q7.Enabled = sKey
        optS5Q8.Enabled = sKey
        optS5Q9.Enabled = sKey
        optS5Q10.Enabled = sKey
        chkS5Q10.Enabled = sKey
        optS5Q11.Enabled = sKey
        chkS5Q11.Enabled = sKey
        optS5Q12.Enabled = sKey

        txtRemark1Q1.Enabled = sKey
        txtRemark1Q2.Enabled = sKey
        txtRemark1Q3.Enabled = sKey
        txtRemark1Q4.Enabled = sKey
        txtRemark1Q5.Enabled = sKey
        txtRemark1Q6.Enabled = sKey
        txtRemark1Q7.Enabled = sKey
        txtRemark1Q8.Enabled = sKey
        txtRemark1Q9.Enabled = sKey
        txtRemark2Q1.Enabled = sKey

        txtRemark2Q2.Enabled = sKey
        txtRemark2Q3.Enabled = sKey
        txtRemark2Q4.Enabled = sKey
        txtRemark2Q5.Enabled = sKey
        txtRemark2Q6.Enabled = sKey
        txtRemark3Q1.Enabled = sKey
        txtRemark3Q2.Enabled = sKey

        txtRemark3Q3.Enabled = sKey
        txtRemark3Q4.Enabled = sKey

        txtRemark3Q5.Enabled = sKey

        txtRemark4Q1.Enabled = sKey
        txtRemark4Q2.Enabled = sKey
        txtRemark4Q3.Enabled = sKey
        txtRemark4Q4.Enabled = sKey
        txtRemark4Q5.Enabled = sKey
        txtRemark4Q6.Enabled = sKey
        txtRemark4Q7.Enabled = sKey
        txtRemark5Q1.Enabled = sKey
        txtRemark5Q2.Enabled = sKey
        txtRemark5Q3.Enabled = sKey
        txtRemark5Q4.Enabled = sKey
        txtRemark5Q5.Enabled = sKey
        txtRemark5Q6.Enabled = sKey
        txtRemark5Q7.Enabled = sKey

        txtRemark5Q8.Enabled = sKey
        txtRemark5Q9.Enabled = sKey
        txtRemark5Q10.Enabled = sKey

        txtRemark5Q11.Enabled = sKey

        txtRemark5Q12.Enabled = sKey

        txtRemark.Enabled = sKey
        txtRemark1.Enabled = sKey
        txtRemark2.Enabled = sKey
        txtRemark3.Enabled = sKey
        txtRemark4.Enabled = sKey
        txtRemark5.Enabled = sKey

        txtDocumentName.Enabled = sKey
        cmdAddFile.Enabled = sKey
        FileUpload1.Enabled = sKey
        FileUpload2.Enabled = sKey
        cmdUpImg.Visible = sKey
    End Sub
    Private Sub LoadGPP_Score()
        dt = ctlA.GPP_AssessmentScore_Get(StrNull2Long(hdGPPUID.Value))
        If dt.Rows.Count > 0 Then
            For i = 0 To dt.Rows.Count - 1
                Select Case DBNull2Zero(dt.Rows(i)("ItemUID"))
                    Case 1
                        optS1Q1.SelectedValue = dt.Rows(i)("Score")
                        txtRemark1Q1.Text = String.Concat(dt.Rows(i)("Remark"))
                    Case 2
                        If DBNull2Zero(dt.Rows(i)("Score")) = -2 Then 'ไม่ตอบอะไรเลย
                            chkS1Q2.Checked = False
                            optS1Q2.ClearSelection()
                        ElseIf DBNull2Zero(dt.Rows(i)("Score")) = -1 Then 'ตอบว่าไม่มี
                            chkS1Q2.Checked = True
                            optS1Q2.ClearSelection()
                        Else 'มีคะแนน
                            chkS1Q2.Checked = False
                            optS1Q2.SelectedValue = dt.Rows(i)("Score")
                        End If
                        txtRemark1Q2.Text = String.Concat(dt.Rows(i)("Remark"))
                    Case 3
                        optS1Q3.SelectedValue = dt.Rows(i)("Score")
                        txtRemark1Q3.Text = String.Concat(dt.Rows(i)("Remark"))
                    Case 4
                        optS1Q4.SelectedValue = dt.Rows(i)("Score")
                        txtRemark1Q4.Text = String.Concat(dt.Rows(i)("Remark"))
                    Case 5
                        optS1Q5.SelectedValue = dt.Rows(i)("Score")
                        txtRemark1Q5.Text = String.Concat(dt.Rows(i)("Remark"))
                    Case 6
                        optS1Q6.SelectedValue = dt.Rows(i)("Score")
                        txtRemark1Q6.Text = String.Concat(dt.Rows(i)("Remark"))
                    Case 7
                        optS1Q7.SelectedValue = dt.Rows(i)("Score")
                        txtRemark1Q7.Text = String.Concat(dt.Rows(i)("Remark"))
                    Case 8
                        optS1Q8.SelectedValue = dt.Rows(i)("Score")
                        txtRemark1Q8.Text = String.Concat(dt.Rows(i)("Remark"))
                    Case 9
                        optS1Q9.SelectedValue = dt.Rows(i)("Score")
                        txtRemark1Q9.Text = String.Concat(dt.Rows(i)("Remark"))
                    Case 10
                        If DBNull2Zero(dt.Rows(i)("Score")) = -2 Then 'ไม่ตอบอะไรเลย
                            chkS2Q1.Checked = False
                            optS2Q1.ClearSelection()
                        ElseIf DBNull2Zero(dt.Rows(i)("Score")) = -1 Then 'ตอบว่าไม่มี
                            chkS2Q1.Checked = True
                            optS2Q1.ClearSelection()
                        Else 'มีคะแนน
                            chkS2Q1.Checked = False
                            optS2Q1.SelectedValue = dt.Rows(i)("Score")
                        End If
                        txtRemark2Q1.Text = String.Concat(dt.Rows(i)("Remark"))
                    Case 11
                        optS2Q2.SelectedValue = dt.Rows(i)("Score")
                        txtRemark2Q2.Text = String.Concat(dt.Rows(i)("Remark"))
                    Case 12
                        optS2Q3.SelectedValue = dt.Rows(i)("Score")
                        txtRemark2Q3.Text = String.Concat(dt.Rows(i)("Remark"))
                    Case 13
                        optS2Q4.SelectedValue = dt.Rows(i)("Score")
                        txtRemark2Q4.Text = String.Concat(dt.Rows(i)("Remark"))
                    Case 14
                        optS2Q5.SelectedValue = dt.Rows(i)("Score")
                        txtRemark2Q5.Text = String.Concat(dt.Rows(i)("Remark"))
                    Case 15
                        optS2Q6.SelectedValue = dt.Rows(i)("Score")
                        txtRemark2Q6.Text = String.Concat(dt.Rows(i)("Remark"))
                    Case 16
                        optS3Q1.SelectedValue = dt.Rows(i)("Score")
                        txtRemark3Q1.Text = String.Concat(dt.Rows(i)("Remark"))
                    Case 17
                        If DBNull2Zero(dt.Rows(i)("Score")) = -2 Then 'ไม่ตอบอะไรเลย
                            chkS3Q2.Checked = False
                            optS3Q2.ClearSelection()
                        ElseIf DBNull2Zero(dt.Rows(i)("Score")) = -1 Then 'ตอบว่าไม่มี
                            chkS3Q2.Checked = True
                            optS3Q2.ClearSelection()
                        Else 'มีคะแนน
                            chkS3Q2.Checked = False
                            optS3Q2.SelectedValue = dt.Rows(i)("Score")
                        End If
                        txtRemark3Q2.Text = String.Concat(dt.Rows(i)("Remark"))
                    Case 18
                        optS3Q3.SelectedValue = dt.Rows(i)("Score")
                        txtRemark3Q3.Text = String.Concat(dt.Rows(i)("Remark"))
                    Case 19
                        If DBNull2Zero(dt.Rows(i)("Score")) = -2 Then 'ไม่ตอบอะไรเลย
                            chkS3Q4.Checked = False
                            optS3Q4.ClearSelection()
                        ElseIf DBNull2Zero(dt.Rows(i)("Score")) = -1 Then 'ตอบว่าไม่มี
                            chkS3Q4.Checked = True
                            optS3Q4.ClearSelection()
                        Else 'มีคะแนน
                            chkS3Q4.Checked = False
                            optS3Q4.SelectedValue = dt.Rows(i)("Score")
                        End If
                        txtRemark3Q4.Text = String.Concat(dt.Rows(i)("Remark"))
                    Case 20
                        If DBNull2Zero(dt.Rows(i)("Score")) = -2 Then 'ไม่ตอบอะไรเลย
                            chkS3Q5.Checked = False
                            optS3Q5.ClearSelection()
                        ElseIf DBNull2Zero(dt.Rows(i)("Score")) = -1 Then 'ตอบว่าไม่มี
                            chkS3Q5.Checked = True
                            optS3Q5.ClearSelection()
                        Else 'มีคะแนน
                            chkS3Q5.Checked = False
                            optS3Q5.SelectedValue = dt.Rows(i)("Score")
                        End If
                        txtRemark3Q5.Text = String.Concat(dt.Rows(i)("Remark"))
                    Case 21
                        optS4Q1.SelectedValue = dt.Rows(i)("Score")
                        txtRemark4Q1.Text = String.Concat(dt.Rows(i)("Remark"))
                    Case 22
                        optS4Q2.SelectedValue = dt.Rows(i)("Score")
                        txtRemark4Q2.Text = String.Concat(dt.Rows(i)("Remark"))
                    Case 23
                        optS4Q3.SelectedValue = dt.Rows(i)("Score")
                        txtRemark4Q3.Text = String.Concat(dt.Rows(i)("Remark"))
                    Case 24
                        optS4Q4.SelectedValue = dt.Rows(i)("Score")
                        txtRemark4Q4.Text = String.Concat(dt.Rows(i)("Remark"))
                    Case 25
                        optS4Q5.SelectedValue = dt.Rows(i)("Score")
                        txtRemark4Q5.Text = String.Concat(dt.Rows(i)("Remark"))
                    Case 26
                        optS4Q6.SelectedValue = dt.Rows(i)("Score")
                        txtRemark4Q6.Text = String.Concat(dt.Rows(i)("Remark"))
                    Case 27
                        optS4Q7.SelectedValue = dt.Rows(i)("Score")
                        txtRemark4Q7.Text = String.Concat(dt.Rows(i)("Remark"))
                    Case 28
                        optS5Q1.SelectedValue = dt.Rows(i)("Score")
                        txtRemark5Q1.Text = String.Concat(dt.Rows(i)("Remark"))
                    Case 29
                        optS5Q2.SelectedValue = dt.Rows(i)("Score")
                        txtRemark5Q2.Text = String.Concat(dt.Rows(i)("Remark"))
                    Case 30
                        optS5Q3.SelectedValue = dt.Rows(i)("Score")
                        txtRemark5Q3.Text = String.Concat(dt.Rows(i)("Remark"))
                    Case 31
                        optS5Q4.SelectedValue = dt.Rows(i)("Score")
                        txtRemark5Q4.Text = String.Concat(dt.Rows(i)("Remark"))
                    Case 32
                        optS5Q5.SelectedValue = dt.Rows(i)("Score")
                        txtRemark5Q5.Text = String.Concat(dt.Rows(i)("Remark"))
                    Case 33
                        optS5Q6.SelectedValue = dt.Rows(i)("Score")
                        txtRemark5Q6.Text = String.Concat(dt.Rows(i)("Remark"))
                    Case 34
                        If DBNull2Zero(dt.Rows(i)("Score")) = -2 Then 'ไม่ตอบอะไรเลย
                            chkS5Q7.Checked = False
                            optS5Q7.ClearSelection()
                        ElseIf DBNull2Zero(dt.Rows(i)("Score")) = -1 Then 'ตอบว่าไม่มี
                            chkS5Q7.Checked = True
                            optS5Q7.ClearSelection()
                        Else 'มีคะแนน
                            chkS5Q7.Checked = False
                            optS5Q7.SelectedValue = dt.Rows(i)("Score")
                        End If
                        txtRemark5Q7.Text = String.Concat(dt.Rows(i)("Remark"))
                    Case 35
                        optS5Q8.SelectedValue = dt.Rows(i)("Score")
                        txtRemark5Q8.Text = String.Concat(dt.Rows(i)("Remark"))
                    Case 36
                        optS5Q9.SelectedValue = dt.Rows(i)("Score")
                        txtRemark5Q9.Text = String.Concat(dt.Rows(i)("Remark"))
                    Case 37
                        If DBNull2Zero(dt.Rows(i)("Score")) = -2 Then 'ไม่ตอบอะไรเลย
                            chkS5Q10.Checked = False
                            optS5Q10.ClearSelection()
                        ElseIf DBNull2Zero(dt.Rows(i)("Score")) = -1 Then 'ตอบว่าไม่มี
                            chkS5Q10.Checked = True
                            optS5Q10.ClearSelection()
                        Else 'มีคะแนน
                            chkS5Q10.Checked = False
                            optS5Q10.SelectedValue = dt.Rows(i)("Score")
                        End If
                        txtRemark5Q10.Text = String.Concat(dt.Rows(i)("Remark"))
                    Case 38
                        If DBNull2Zero(dt.Rows(i)("Score")) = -2 Then 'ไม่ตอบอะไรเลย
                            chkS5Q11.Checked = False
                            optS5Q11.ClearSelection()
                        ElseIf DBNull2Zero(dt.Rows(i)("Score")) = -1 Then 'ตอบว่าไม่มี
                            chkS5Q11.Checked = True
                            optS5Q11.ClearSelection()
                        Else 'มีคะแนน
                            chkS5Q11.Checked = False
                            optS5Q11.SelectedValue = dt.Rows(i)("Score")
                        End If
                        txtRemark5Q11.Text = String.Concat(dt.Rows(i)("Remark"))
                    Case 39
                        optS5Q12.SelectedValue = dt.Rows(i)("Score")
                        txtRemark5Q12.Text = String.Concat(dt.Rows(i)("Remark"))
                End Select


            Next

            CalculateScore()

        End If

    End Sub
    Private Sub CalculateScore()
        lblScoreS1Q1.Text = (StrNull2GPPScore(optS1Q1.SelectedValue) * 2).ToString()
        lblScoreS1Q2.Text = (StrNull2GPPScore(optS1Q2.SelectedValue) * 1).ToString()
        lblScoreS1Q3.Text = (StrNull2GPPScore(optS1Q3.SelectedValue) * 1).ToString()
        lblScoreS1Q4.Text = (StrNull2GPPScore(optS1Q4.SelectedValue) * 1).ToString()
        lblScoreS1Q5.Text = (StrNull2GPPScore(optS1Q5.SelectedValue) * 1).ToString()
        lblScoreS1Q6.Text = (StrNull2GPPScore(optS1Q6.SelectedValue) * 1).ToString()
        lblScoreS1Q7.Text = (StrNull2GPPScore(optS1Q7.SelectedValue) * 2).ToString()
        lblScoreS1Q8.Text = (StrNull2GPPScore(optS1Q8.SelectedValue) * 2).ToString()
        lblScoreS1Q9.Text = (StrNull2GPPScore(optS1Q9.SelectedValue) * 2).ToString()

        lblSumScoreS1.Text = StrNull2GPPScore(lblScoreS1Q1.Text) + StrNull2GPPScore(lblScoreS1Q2.Text) + StrNull2GPPScore(lblScoreS1Q3.Text) + StrNull2GPPScore(lblScoreS1Q4.Text) + StrNull2GPPScore(lblScoreS1Q5.Text) + StrNull2GPPScore(lblScoreS1Q6.Text) + StrNull2GPPScore(lblScoreS1Q7.Text) + StrNull2GPPScore(lblScoreS1Q8.Text) + StrNull2GPPScore(lblScoreS1Q9.Text)

        Dim iTotalScore1 As Integer = 26
        If chkS1Q2.Checked = True Or (chkS1Q2.Checked = False And optS1Q2.SelectedValue = "") Then
            lblScoreS1Q2.Text = "0"
            iTotalScore1 = iTotalScore1 - 2
        End If

        lblPercent1.Text = ((StrNull2GPPScore(lblSumScoreS1.Text) / iTotalScore1) * 100).ToString("#.#0")
        lblPercentGroup1.Text = lblPercent1.Text

        lblScoreS2Q1.Text = (StrNull2GPPScore(optS2Q1.SelectedValue) * 2).ToString()
        lblScoreS2Q2.Text = (StrNull2GPPScore(optS2Q2.SelectedValue) * 2).ToString()
        lblScoreS2Q3.Text = (StrNull2GPPScore(optS2Q3.SelectedValue) * 1).ToString()
        lblScoreS2Q4.Text = (StrNull2GPPScore(optS2Q4.SelectedValue) * 1).ToString()
        lblScoreS2Q5.Text = (StrNull2GPPScore(optS2Q5.SelectedValue) * 1).ToString()
        lblScoreS2Q6.Text = (StrNull2GPPScore(optS2Q6.SelectedValue) * 1).ToString()

        lblSumScoreS2.Text = StrNull2GPPScore(lblScoreS2Q1.Text) + StrNull2GPPScore(lblScoreS2Q2.Text) + StrNull2GPPScore(lblScoreS2Q3.Text) + StrNull2GPPScore(lblScoreS2Q4.Text) + StrNull2GPPScore(lblScoreS2Q5.Text) + StrNull2GPPScore(lblScoreS2Q6.Text)

        Dim iTotalScore2 As Integer = 16
        If chkS2Q1.Checked = True Or (chkS2Q1.Checked = False And optS2Q1.SelectedValue = "") Then
            lblScoreS2Q1.Text = "0"
            iTotalScore2 = iTotalScore2 - 4
        End If

        lblPercent2.Text = ((StrNull2GPPScore(lblSumScoreS2.Text) / iTotalScore2) * 100).ToString("#.#0")
        lblPercentGroup2.Text = lblPercent2.Text

        lblScoreS3Q1.Text = (StrNull2GPPScore(optS3Q1.SelectedValue) * 2).ToString()
        lblScoreS3Q2.Text = (StrNull2GPPScore(optS3Q2.SelectedValue) * 1).ToString()
        lblScoreS3Q3.Text = (StrNull2GPPScore(optS3Q3.SelectedValue) * 1).ToString()
        lblScoreS3Q4.Text = (StrNull2GPPScore(optS3Q4.SelectedValue) * 1).ToString()
        lblScoreS3Q5.Text = (StrNull2GPPScore(optS3Q5.SelectedValue) * 1).ToString()

        lblSumScoreS3.Text = StrNull2GPPScore(lblScoreS3Q1.Text) + StrNull2GPPScore(lblScoreS3Q2.Text) + StrNull2GPPScore(lblScoreS3Q3.Text) + StrNull2GPPScore(lblScoreS3Q4.Text) + StrNull2GPPScore(lblScoreS3Q5.Text)

        Dim iTotalScore3 As Integer = 12
        If chkS3Q2.Checked = True Or (chkS3Q2.Checked = False And optS3Q2.SelectedValue = "") Then
            lblScoreS3Q2.Text = "0"
            iTotalScore3 = iTotalScore3 - 2
        End If

        If chkS3Q4.Checked = True Or (chkS3Q4.Checked = False And optS3Q4.SelectedValue = "") Then
            lblScoreS3Q4.Text = "0"
            iTotalScore3 = iTotalScore3 - 2
        End If

        If chkS3Q5.Checked = True Or (chkS3Q5.Checked = False And optS3Q5.SelectedValue = "") Then
            lblScoreS3Q5.Text = "0"
            iTotalScore3 = iTotalScore3 - 2
        End If

        lblPercent3.Text = ((StrNull2GPPScore(lblSumScoreS3.Text) / iTotalScore3) * 100).ToString("#.#0")
        lblPercentGroup3.Text = lblPercent3.Text

        lblScoreS4Q1.Text = (StrNull2GPPScore(optS4Q1.SelectedValue) * 2).ToString()
        lblScoreS4Q2.Text = (StrNull2GPPScore(optS4Q2.SelectedValue) * 2).ToString()
        lblScoreS4Q3.Text = (StrNull2GPPScore(optS4Q3.SelectedValue) * 2).ToString()
        lblScoreS4Q4.Text = (StrNull2GPPScore(optS4Q4.SelectedValue) * 1).ToString()
        lblScoreS4Q5.Text = (StrNull2GPPScore(optS4Q5.SelectedValue) * 1).ToString()
        lblScoreS4Q6.Text = (StrNull2GPPScore(optS4Q6.SelectedValue) * 1).ToString()
        lblScoreS4Q7.Text = (StrNull2GPPScore(optS4Q7.SelectedValue) * 2).ToString()

        lblSumScoreS4.Text = StrNull2GPPScore(lblScoreS4Q1.Text) + StrNull2GPPScore(lblScoreS4Q2.Text) + StrNull2GPPScore(lblScoreS4Q3.Text) + StrNull2GPPScore(lblScoreS4Q4.Text) + StrNull2GPPScore(lblScoreS4Q5.Text) + StrNull2GPPScore(lblScoreS4Q6.Text) + StrNull2GPPScore(lblScoreS4Q7.Text)
        lblPercent4.Text = ((StrNull2GPPScore(lblSumScoreS4.Text) / 22) * 100).ToString("#.#0")
        lblPercentGroup4.Text = lblPercent4.Text


        lblScoreS5Q1.Text = (StrNull2GPPScore(optS5Q1.SelectedValue) * 2).ToString()
        lblScoreS5Q2.Text = (StrNull2GPPScore(optS5Q2.SelectedValue) * 2).ToString()
        lblScoreS5Q3.Text = (StrNull2GPPScore(optS5Q3.SelectedValue) * 2).ToString()
        lblScoreS5Q4.Text = (StrNull2GPPScore(optS5Q4.SelectedValue) * 2).ToString()
        lblScoreS5Q5.Text = (StrNull2GPPScore(optS5Q5.SelectedValue) * 2).ToString()
        lblScoreS5Q6.Text = (StrNull2GPPScore(optS5Q6.SelectedValue) * 2).ToString()
        lblScoreS5Q7.Text = (StrNull2GPPScore(optS5Q7.SelectedValue) * 2).ToString()
        lblScoreS5Q8.Text = (StrNull2GPPScore(optS5Q8.SelectedValue) * 1).ToString()
        lblScoreS5Q9.Text = (StrNull2GPPScore(optS5Q9.SelectedValue) * 1).ToString()
        lblScoreS5Q10.Text = (StrNull2GPPScore(optS5Q10.SelectedValue) * 1).ToString()
        lblScoreS5Q11.Text = (StrNull2GPPScore(optS5Q11.SelectedValue) * 1).ToString()
        lblScoreS5Q12.Text = (StrNull2GPPScore(optS5Q12.SelectedValue) * 1).ToString()

        lblSumScoreS5.Text = StrNull2GPPScore(lblScoreS5Q1.Text) + StrNull2GPPScore(lblScoreS5Q2.Text) + StrNull2GPPScore(lblScoreS5Q3.Text) + StrNull2GPPScore(lblScoreS5Q4.Text) + StrNull2GPPScore(lblScoreS5Q5.Text) + StrNull2GPPScore(lblScoreS5Q6.Text) + StrNull2GPPScore(lblScoreS5Q7.Text) + StrNull2GPPScore(lblScoreS5Q8.Text) + StrNull2GPPScore(lblScoreS5Q9.Text) + StrNull2GPPScore(lblScoreS5Q10.Text) + StrNull2GPPScore(lblScoreS5Q11.Text) + StrNull2GPPScore(lblScoreS5Q12.Text)

        Dim iTotalScore5 As Integer = 38
        If chkS5Q7.Checked = True Or (chkS5Q7.Checked = False And optS5Q7.SelectedValue = "") Then
            lblScoreS5Q7.Text = "0"
            iTotalScore5 = iTotalScore5 - 4
        End If
        If chkS5Q10.Checked = True Or (chkS5Q10.Checked = False And optS5Q10.SelectedValue = "") Then
            lblScoreS5Q10.Text = "0"
            iTotalScore5 = iTotalScore5 - 2
        End If
        If chkS5Q11.Checked = True Or (chkS5Q11.Checked = False And optS5Q11.SelectedValue = "") Then
            lblScoreS5Q11.Text = "0"
            iTotalScore5 = iTotalScore5 - 2
        End If

        lblPercent5.Text = ((StrNull2GPPScore(lblSumScoreS5.Text) / iTotalScore5) * 100).ToString("#.#0")
        lblPercentGroup5.Text = lblPercent5.Text

        Dim iTotalScore As Integer = 114

        If chkS1Q2.Checked = True Or (chkS1Q2.Checked = False And optS1Q2.SelectedValue = "") Then
            lblScoreS1Q2.Text = "0"
            iTotalScore = iTotalScore - 2
        End If

        If chkS2Q1.Checked = True Or (chkS2Q1.Checked = False And optS2Q1.SelectedValue = "") Then
            lblScoreS2Q1.Text = "0"
            iTotalScore = iTotalScore - 4
        End If

        If chkS3Q2.Checked = True Or (chkS3Q2.Checked = False And optS3Q2.SelectedValue = "") Then
            lblScoreS3Q2.Text = "0"
            iTotalScore = iTotalScore - 2
        End If

        If chkS3Q4.Checked = True Or (chkS3Q4.Checked = False And optS3Q4.SelectedValue = "") Then
            lblScoreS3Q4.Text = "0"
            iTotalScore = iTotalScore - 2
        End If

        If chkS3Q5.Checked = True Or (chkS3Q5.Checked = False And optS3Q5.SelectedValue = "") Then
            lblScoreS3Q5.Text = "0"
            iTotalScore = iTotalScore - 2
        End If

        If chkS5Q7.Checked = True Or (chkS5Q7.Checked = False And optS5Q7.SelectedValue = "") Then
            lblScoreS5Q7.Text = "0"
            iTotalScore = iTotalScore - 4
        End If
        If chkS5Q10.Checked = True Or (chkS5Q10.Checked = False And optS5Q10.SelectedValue = "") Then
            lblScoreS5Q10.Text = "0"
            iTotalScore = iTotalScore - 2
        End If
        If chkS5Q11.Checked = True Or (chkS5Q11.Checked = False And optS5Q11.SelectedValue = "") Then
            lblScoreS5Q11.Text = "0"
            iTotalScore = iTotalScore - 2
        End If

        hdTotalScore.Value = iTotalScore.ToString()

        hdNetScore.Value = StrNull2GPPScore(lblSumScoreS1.Text) + StrNull2GPPScore(lblSumScoreS2.Text) + StrNull2GPPScore(lblSumScoreS3.Text) + StrNull2GPPScore(lblSumScoreS4.Text) + StrNull2GPPScore(lblSumScoreS5.Text)

        lblPercentage.Text = ((StrNull2Double(lblPercent1.Text) + StrNull2Double(lblPercent2.Text) + StrNull2Double(lblPercent3.Text) + StrNull2Double(lblPercent4.Text) + StrNull2Double(lblPercent5.Text)) / 5).ToString("#.#0")


        lblResult.Text = "ผ่าน"
        lblResult.ForeColor = System.Drawing.Color.Green
        lblResultRemark.Text = ""


        If StrNull2Zero(lblScoreS1Q1.Text) <= 0 Or StrNull2Zero(lblScoreS1Q4.Text) <= 0 Or StrNull2Zero(lblScoreS1Q5.Text) <= 0 Or StrNull2Zero(lblScoreS1Q7.Text) <= 0 Or StrNull2Zero(lblScoreS1Q9.Text) <= 0 Or StrNull2Zero(lblScoreS2Q2.Text) <= 0 Or StrNull2Zero(lblScoreS2Q3.Text) <= 0 Or StrNull2Zero(lblScoreS2Q4.Text) <= 0 Or StrNull2Zero(lblScoreS2Q5.Text) <= 0 Or StrNull2Zero(lblScoreS2Q6.Text) <= 0 Or StrNull2Zero(lblScoreS4Q1.Text) <= 0 Or StrNull2Zero(lblScoreS4Q3.Text) <= 0 Or StrNull2Zero(lblScoreS5Q1.Text) <= 0 Then

            lblResult.Text = "ไม่ผ่าน"
            lblResult.ForeColor = System.Drawing.Color.Red

            lblResultRemark.Text = "ข้อ "
        End If

        If StrNull2Zero(lblScoreS1Q1.Text) <= 0 Then
                lblResultRemark.Text = lblResultRemark.Text & " 1.1,"
            End If

            If StrNull2Zero(lblScoreS1Q4.Text) <= 0 Then
                lblResultRemark.Text = lblResultRemark.Text & " 1.4,"
            End If
            If StrNull2Zero(lblScoreS1Q5.Text) <= 0 Then
                lblResultRemark.Text = lblResultRemark.Text & " 1.5,"
            End If
            If StrNull2Zero(lblScoreS1Q7.Text) <= 0 Then
                lblResultRemark.Text = lblResultRemark.Text & " 1.7,"
            End If
            If StrNull2Zero(lblScoreS1Q9.Text) <= 0 Then
                lblResultRemark.Text = lblResultRemark.Text & " 1.9,"
            End If
            If StrNull2Zero(lblScoreS2Q2.Text) <= 0 Then
                lblResultRemark.Text = lblResultRemark.Text & " 2.2,"
            End If
            If StrNull2Zero(lblScoreS2Q3.Text) <= 0 Then
                lblResultRemark.Text = lblResultRemark.Text & " 2.3,"
            End If
            If StrNull2Zero(lblScoreS2Q4.Text) <= 0 Then
                lblResultRemark.Text = lblResultRemark.Text & " 2.4,"
            End If
            If StrNull2Zero(lblScoreS2Q5.Text) <= 0 Then
                lblResultRemark.Text = lblResultRemark.Text & " 2.5,"
            End If
            If StrNull2Zero(lblScoreS2Q6.Text) <= 0 Then
                lblResultRemark.Text = lblResultRemark.Text & " 2.6,"
            End If
            If StrNull2Zero(lblScoreS4Q1.Text) <= 0 Then
                lblResultRemark.Text = lblResultRemark.Text & " 4.1,"
            End If
            If StrNull2Zero(lblScoreS4Q3.Text) <= 0 Then
                lblResultRemark.Text = lblResultRemark.Text & " 4.3,"
            End If
            If StrNull2Zero(lblScoreS5Q1.Text) <= 0 Then
            lblResultRemark.Text = lblResultRemark.Text & " 5.1,"
        End If

        lblPercentGroup1.ForeColor = System.Drawing.Color.Gray
        lblPercentGroup2.ForeColor = System.Drawing.Color.Gray
            lblPercentGroup3.ForeColor = System.Drawing.Color.Gray
            lblPercentGroup4.ForeColor = System.Drawing.Color.Gray
        lblPercentGroup5.ForeColor = System.Drawing.Color.Gray


        If StrNull2Double(lblPercentGroup1.Text) < 70 Or StrNull2Double(lblPercentGroup2.Text) < 70 Or StrNull2Double(lblPercentGroup3.Text) < 70 Or StrNull2Double(lblPercentGroup4.Text) < 70 Or StrNull2Double(lblPercentGroup5.Text) < 70 Or StrNull2Double(lblPercentage.Text) < 70 Then
            lblResult.Text = "ไม่ผ่าน"
            lblResult.ForeColor = System.Drawing.Color.Red
        End If

        If StrNull2Double(lblPercentGroup1.Text) < 70 Then
            lblPercentGroup1.ForeColor = System.Drawing.Color.Red
            lblResultRemark.Text = lblResultRemark.Text & "  หมวดที่ 1,"
        End If
        If StrNull2Double(lblPercentGroup2.Text) < 70 Then
            lblPercentGroup2.ForeColor = System.Drawing.Color.Red
            lblResultRemark.Text = lblResultRemark.Text & " หมวดที่ 2,"
        End If
        If StrNull2Double(lblPercentGroup3.Text) < 70 Then
            lblPercentGroup3.ForeColor = System.Drawing.Color.Red
            lblResultRemark.Text = lblResultRemark.Text & " หมวดที่ 3,"
        End If
        If StrNull2Double(lblPercentGroup4.Text) < 70 Then
            lblPercentGroup4.ForeColor = System.Drawing.Color.Red
            lblResultRemark.Text = lblResultRemark.Text & " หมวดที่ 4,"
        End If
        If StrNull2Double(lblPercentGroup5.Text) < 70 Then
            lblPercentGroup5.ForeColor = System.Drawing.Color.Red
            lblResultRemark.Text = lblResultRemark.Text & " หมวดที่ 5 "
        End If

        If lblResultRemark.Text.Length > 0 Then
            lblResultRemark.Text = Left(lblResultRemark.Text, lblResultRemark.Text.Length - 1)
        End If

    End Sub
    'Private Sub Assessment_Save(RequestUID As Long)
    '    Dim ctlA As New AssessmentController
    '    ctlA.Assessment_Save(RequestUID, StrNull2Zero(hdLocationUID.Value), Request.Cookies("UserID").Value)
    'End Sub
    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click

        'CalculateScore() 
        Dim NetScore, NetPercentage As Double
        'Dim FinalResult As String

        NetScore = StrNull2Double(hdNetScore.Value)
        NetPercentage = StrNull2Double(lblPercentage.Text)
        'FinalResult = ddlFinalResult.SelectedValue

        Dim AsmStatus As String
        If lblResult.Text = "ผ่าน" Then
            AsmStatus = "Y"
        Else
            AsmStatus = "N"
        End If

        'Assessment_Save(StrNull2Long(hdRequestUID.Value))

        ctlA.GPP_Assessment_Save(StrNull2Zero(hdGPPUID.Value), StrNull2Zero(hdRequestUID.Value), StrNull2Zero(lblYear.Text), StrNull2Zero(hdLocationUID.Value), StrNull2Double(hdTotalScore.Value), NetScore, NetPercentage, AsmStatus, txtRemark1.Text, txtRemark2.Text, txtRemark3.Text, txtRemark4.Text, txtRemark5.Text, txtRemark.Text, StrNull2Zero(Request.Cookies("userid").Value), StrNull2Double(lblPercentGroup1.Text), StrNull2Double(lblPercentGroup2.Text), StrNull2Double(lblPercentGroup3.Text), StrNull2Double(lblPercentGroup4.Text), StrNull2Double(lblPercentGroup5.Text), txtRiskRemark.Text)

        Dim S1Q2, S2Q1, S3Q2, S3Q4, S3Q5, S5Q7, S5Q10, S5Q11 As Double

        If chkS1Q2.Checked = True Then 'ตอบว่าไม่มี
            S1Q2 = -1
        Else
            If optS1Q2.SelectedValue = Nothing Then 'ไม่ตอบอะไรเลย
                S1Q2 = -2
            Else 'มีคะแนน
                S1Q2 = StrNull2GPPVal(optS1Q2.SelectedValue)
            End If
        End If

        If chkS2Q1.Checked = True Then 'ตอบว่าไม่มี
            S2Q1 = -1
        Else
            If optS2Q1.SelectedValue = Nothing Then 'ไม่ตอบอะไรเลย
                S2Q1 = -2
            Else 'มีคะแนน
                S2Q1 = StrNull2GPPVal(optS2Q1.SelectedValue)
            End If
        End If


        If chkS3Q2.Checked = True Then 'ตอบว่าไม่มี
            S3Q2 = -1
        Else
            If optS3Q2.SelectedValue = Nothing Then 'ไม่ตอบอะไรเลย
                S3Q2 = -2
            Else 'มีคะแนน
                S3Q2 = StrNull2GPPVal(optS3Q2.SelectedValue)
            End If
        End If

        If chkS3Q4.Checked = True Then 'ตอบว่าไม่มี
            S3Q4 = -1
        Else
            If optS3Q4.SelectedValue = Nothing Then 'ไม่ตอบอะไรเลย
                S3Q4 = -2
            Else 'มีคะแนน
                S3Q4 = StrNull2GPPVal(optS3Q4.SelectedValue)
            End If
        End If
        If chkS3Q5.Checked = True Then 'ตอบว่าไม่มี
            S3Q5 = -1
        Else
            If optS3Q5.SelectedValue = Nothing Then 'ไม่ตอบอะไรเลย
                S3Q5 = -2
            Else 'มีคะแนน
                S3Q5 = StrNull2GPPVal(optS3Q5.SelectedValue)
            End If
        End If
        If chkS5Q7.Checked = True Then 'ตอบว่าไม่มี
            S5Q7 = -1
        Else
            If optS5Q7.SelectedValue = Nothing Then 'ไม่ตอบอะไรเลย
                S5Q7 = -2
            Else 'มีคะแนน
                S5Q7 = StrNull2GPPVal(optS5Q7.SelectedValue)
            End If
        End If
        If chkS5Q10.Checked = True Then 'ตอบว่าไม่มี
            S5Q10 = -1
        Else
            If optS5Q10.SelectedValue = Nothing Then 'ไม่ตอบอะไรเลย
                S5Q10 = -2
            Else 'มีคะแนน
                S5Q10 = StrNull2GPPVal(optS5Q10.SelectedValue)
            End If
        End If
        If chkS5Q11.Checked = True Then 'ตอบว่าไม่มี
            S5Q11 = -1
        Else
            If optS5Q11.SelectedValue = Nothing Then 'ไม่ตอบอะไรเลย
                S5Q11 = -2
            Else 'มีคะแนน
                S5Q11 = StrNull2GPPVal(optS5Q11.SelectedValue)
            End If
        End If

        If StrNull2Zero(hdGPPUID.Value) = 0 Then
            hdGPPUID.Value = ctlA.GPP_Assessment_GetUID(StrNull2Zero(hdRequestUID.Value), StrNull2Zero(hdLocationUID.Value), StrNull2Zero(lblYear.Text)).ToString()
            ctlD.GPPDocument_UpdateGPPUID(StrNull2Zero(hdGPPUID.Value), StrNull2Zero(hdLocationUID.Value))
        End If

        ctlA.GPP_AssessmentScore_SavePPH(StrNull2Zero(hdGPPUID.Value), 1, StrNull2GPPVal(optS1Q1.SelectedValue), 2, StrNull2Double(lblScoreS1Q1.Text), txtRemark1Q1.Text, StrNull2Zero(Request.Cookies("userid").Value))
        ctlA.GPP_AssessmentScore_SavePPH(StrNull2Zero(hdGPPUID.Value), 2, S1Q2, 1, StrNull2Double(lblScoreS1Q2.Text), txtRemark1Q2.Text, StrNull2Zero(Request.Cookies("userid").Value))
        ctlA.GPP_AssessmentScore_SavePPH(StrNull2Zero(hdGPPUID.Value), 3, StrNull2GPPVal(optS1Q3.SelectedValue), 1, StrNull2Double(lblScoreS1Q3.Text), txtRemark1Q3.Text, StrNull2Zero(Request.Cookies("userid").Value))
        ctlA.GPP_AssessmentScore_SavePPH(StrNull2Zero(hdGPPUID.Value), 4, StrNull2GPPVal(optS1Q4.SelectedValue), 1, StrNull2Double(lblScoreS1Q4.Text), txtRemark1Q4.Text, StrNull2Zero(Request.Cookies("userid").Value))
        ctlA.GPP_AssessmentScore_SavePPH(StrNull2Zero(hdGPPUID.Value), 5, StrNull2GPPVal(optS1Q5.SelectedValue), 1, StrNull2Double(lblScoreS1Q5.Text), txtRemark1Q5.Text, StrNull2Zero(Request.Cookies("userid").Value))
        ctlA.GPP_AssessmentScore_SavePPH(StrNull2Zero(hdGPPUID.Value), 6, StrNull2GPPVal(optS1Q6.SelectedValue), 1, StrNull2Double(lblScoreS1Q6.Text), txtRemark1Q6.Text, StrNull2Zero(Request.Cookies("userid").Value))
        ctlA.GPP_AssessmentScore_SavePPH(StrNull2Zero(hdGPPUID.Value), 7, StrNull2GPPVal(optS1Q7.SelectedValue), 2, StrNull2Double(lblScoreS1Q7.Text), txtRemark1Q7.Text, StrNull2Zero(Request.Cookies("userid").Value))
        ctlA.GPP_AssessmentScore_SavePPH(StrNull2Zero(hdGPPUID.Value), 8, StrNull2GPPVal(optS1Q8.SelectedValue), 2, StrNull2Double(lblScoreS1Q8.Text), txtRemark1Q8.Text, StrNull2Zero(Request.Cookies("userid").Value))
        ctlA.GPP_AssessmentScore_SavePPH(StrNull2Zero(hdGPPUID.Value), 9, StrNull2GPPVal(optS1Q9.SelectedValue), 2, StrNull2Double(lblScoreS1Q9.Text), txtRemark1Q9.Text, StrNull2Zero(Request.Cookies("userid").Value))
        ctlA.GPP_AssessmentScore_SavePPH(StrNull2Zero(hdGPPUID.Value), 10, S2Q1, 2, StrNull2Double(lblScoreS2Q1.Text), txtRemark2Q1.Text, StrNull2Zero(Request.Cookies("userid").Value))
        'ctlA.GPP_AssessmentScore_SavePPH(StrNull2Zero(hdGPPUID.Value), 10, StrNull2GPPVal(optS2Q1.SelectedValue), 2, StrNull2Double(lblScoreS2Q1.Text), StrNull2Zero(Request.Cookies("userid").Value))
        ctlA.GPP_AssessmentScore_SavePPH(StrNull2Zero(hdGPPUID.Value), 11, StrNull2GPPVal(optS2Q2.SelectedValue), 2, StrNull2Double(lblScoreS2Q2.Text), txtRemark2Q2.Text, StrNull2Zero(Request.Cookies("userid").Value))
        ctlA.GPP_AssessmentScore_SavePPH(StrNull2Zero(hdGPPUID.Value), 12, StrNull2GPPVal(optS2Q3.SelectedValue), 1, StrNull2Double(lblScoreS2Q3.Text), txtRemark2Q3.Text, StrNull2Zero(Request.Cookies("userid").Value))
        ctlA.GPP_AssessmentScore_SavePPH(StrNull2Zero(hdGPPUID.Value), 13, StrNull2GPPVal(optS2Q4.SelectedValue), 1, StrNull2Double(lblScoreS2Q4.Text), txtRemark2Q4.Text, StrNull2Zero(Request.Cookies("userid").Value))
        ctlA.GPP_AssessmentScore_SavePPH(StrNull2Zero(hdGPPUID.Value), 14, StrNull2GPPVal(optS2Q5.SelectedValue), 1, StrNull2Double(lblScoreS2Q5.Text), txtRemark2Q5.Text, StrNull2Zero(Request.Cookies("userid").Value))
        ctlA.GPP_AssessmentScore_SavePPH(StrNull2Zero(hdGPPUID.Value), 15, StrNull2GPPVal(optS2Q6.SelectedValue), 1, StrNull2Double(lblScoreS2Q6.Text), txtRemark2Q6.Text, StrNull2Zero(Request.Cookies("userid").Value))
        ctlA.GPP_AssessmentScore_SavePPH(StrNull2Zero(hdGPPUID.Value), 16, StrNull2GPPVal(optS3Q1.SelectedValue), 2, StrNull2Double(lblScoreS3Q1.Text), txtRemark3Q1.Text, StrNull2Zero(Request.Cookies("userid").Value))

        ctlA.GPP_AssessmentScore_SavePPH(StrNull2Zero(hdGPPUID.Value), 17, S3Q2, 1, StrNull2Double(lblScoreS3Q2.Text), txtRemark3Q2.Text, StrNull2Zero(Request.Cookies("userid").Value))
        ctlA.GPP_AssessmentScore_SavePPH(StrNull2Zero(hdGPPUID.Value), 18, StrNull2GPPVal(optS3Q3.SelectedValue), 1, StrNull2Double(lblScoreS3Q3.Text), txtRemark3Q3.Text, StrNull2Zero(Request.Cookies("userid").Value))
        ctlA.GPP_AssessmentScore_SavePPH(StrNull2Zero(hdGPPUID.Value), 19, S3Q4, 1, StrNull2Double(lblScoreS3Q4.Text), txtRemark3Q4.Text, StrNull2Zero(Request.Cookies("userid").Value))
        ctlA.GPP_AssessmentScore_SavePPH(StrNull2Zero(hdGPPUID.Value), 20, S3Q5, 1, StrNull2Double(lblScoreS3Q5.Text), txtRemark3Q5.Text, StrNull2Zero(Request.Cookies("userid").Value))
        ctlA.GPP_AssessmentScore_SavePPH(StrNull2Zero(hdGPPUID.Value), 21, StrNull2GPPVal(optS4Q1.SelectedValue), 2, StrNull2Double(lblScoreS4Q1.Text), txtRemark4Q1.Text, StrNull2Zero(Request.Cookies("userid").Value))
        ctlA.GPP_AssessmentScore_SavePPH(StrNull2Zero(hdGPPUID.Value), 22, StrNull2GPPVal(optS4Q2.SelectedValue), 2, StrNull2Double(lblScoreS4Q2.Text), txtRemark4Q2.Text, StrNull2Zero(Request.Cookies("userid").Value))
        ctlA.GPP_AssessmentScore_SavePPH(StrNull2Zero(hdGPPUID.Value), 23, StrNull2GPPVal(optS4Q3.SelectedValue), 2, StrNull2Double(lblScoreS4Q3.Text), txtRemark4Q3.Text, StrNull2Zero(Request.Cookies("userid").Value))
        ctlA.GPP_AssessmentScore_SavePPH(StrNull2Zero(hdGPPUID.Value), 24, StrNull2GPPVal(optS4Q4.SelectedValue), 1, StrNull2Double(lblScoreS4Q4.Text), txtRemark4Q4.Text, StrNull2Zero(Request.Cookies("userid").Value))
        ctlA.GPP_AssessmentScore_SavePPH(StrNull2Zero(hdGPPUID.Value), 25, StrNull2GPPVal(optS4Q5.SelectedValue), 1, StrNull2Double(lblScoreS4Q5.Text), txtRemark4Q5.Text, StrNull2Zero(Request.Cookies("userid").Value))
        ctlA.GPP_AssessmentScore_SavePPH(StrNull2Zero(hdGPPUID.Value), 26, StrNull2GPPVal(optS4Q6.SelectedValue), 1, StrNull2Double(lblScoreS4Q6.Text), txtRemark4Q6.Text, StrNull2Zero(Request.Cookies("userid").Value))
        ctlA.GPP_AssessmentScore_SavePPH(StrNull2Zero(hdGPPUID.Value), 27, StrNull2GPPVal(optS4Q7.SelectedValue), 2, StrNull2Double(lblScoreS4Q7.Text), txtRemark4Q7.Text, StrNull2Zero(Request.Cookies("userid").Value))
        ctlA.GPP_AssessmentScore_SavePPH(StrNull2Zero(hdGPPUID.Value), 28, StrNull2GPPVal(optS5Q1.SelectedValue), 2, StrNull2Double(lblScoreS5Q1.Text), txtRemark5Q1.Text, StrNull2Zero(Request.Cookies("userid").Value))
        ctlA.GPP_AssessmentScore_SavePPH(StrNull2Zero(hdGPPUID.Value), 29, StrNull2GPPVal(optS5Q2.SelectedValue), 2, StrNull2Double(lblScoreS5Q2.Text), txtRemark5Q2.Text, StrNull2Zero(Request.Cookies("userid").Value))
        ctlA.GPP_AssessmentScore_SavePPH(StrNull2Zero(hdGPPUID.Value), 30, StrNull2GPPVal(optS5Q3.SelectedValue), 2, StrNull2Double(lblScoreS5Q3.Text), txtRemark5Q3.Text, StrNull2Zero(Request.Cookies("userid").Value))
        ctlA.GPP_AssessmentScore_SavePPH(StrNull2Zero(hdGPPUID.Value), 31, StrNull2GPPVal(optS5Q4.SelectedValue), 2, StrNull2Double(lblScoreS5Q4.Text), txtRemark5Q4.Text, StrNull2Zero(Request.Cookies("userid").Value))
        ctlA.GPP_AssessmentScore_SavePPH(StrNull2Zero(hdGPPUID.Value), 32, StrNull2GPPVal(optS5Q5.SelectedValue), 2, StrNull2Double(lblScoreS5Q5.Text), txtRemark5Q5.Text, StrNull2Zero(Request.Cookies("userid").Value))
        ctlA.GPP_AssessmentScore_SavePPH(StrNull2Zero(hdGPPUID.Value), 33, StrNull2GPPVal(optS5Q6.SelectedValue), 2, StrNull2Double(lblScoreS5Q6.Text), txtRemark5Q6.Text, StrNull2Zero(Request.Cookies("userid").Value))
        ctlA.GPP_AssessmentScore_SavePPH(StrNull2Zero(hdGPPUID.Value), 34, S5Q7, 2, StrNull2Double(lblScoreS5Q7.Text), txtRemark5Q7.Text, StrNull2Zero(Request.Cookies("userid").Value))
        ctlA.GPP_AssessmentScore_SavePPH(StrNull2Zero(hdGPPUID.Value), 35, StrNull2GPPVal(optS5Q8.SelectedValue), 1, StrNull2Double(lblScoreS5Q8.Text), txtRemark5Q8.Text, StrNull2Zero(Request.Cookies("userid").Value))
        ctlA.GPP_AssessmentScore_SavePPH(StrNull2Zero(hdGPPUID.Value), 36, StrNull2GPPVal(optS5Q9.SelectedValue), 1, StrNull2Double(lblScoreS5Q9.Text), txtRemark5Q9.Text, StrNull2Zero(Request.Cookies("userid").Value))
        ctlA.GPP_AssessmentScore_SavePPH(StrNull2Zero(hdGPPUID.Value), 37, S5Q10, 1, StrNull2Double(lblScoreS5Q10.Text), txtRemark5Q10.Text, StrNull2Zero(Request.Cookies("userid").Value))
        ctlA.GPP_AssessmentScore_SavePPH(StrNull2Zero(hdGPPUID.Value), 38, S5Q11, 1, StrNull2Double(lblScoreS5Q11.Text), txtRemark5Q11.Text, StrNull2Zero(Request.Cookies("userid").Value))
        ctlA.GPP_AssessmentScore_SavePPH(StrNull2Zero(hdGPPUID.Value), 39, StrNull2GPPVal(optS5Q12.SelectedValue), 1, StrNull2Double(lblScoreS5Q12.Text), txtRemark5Q12.Text, StrNull2Zero(Request.Cookies("userid").Value))


        For i = 0 To chkRisk.Items.Count - 1
            If chkRisk.Items(i).Selected Then
                ctlA.GPPRisk_Add(StrNull2Zero(hdGPPUID.Value), chkRisk.Items(i).Value, Request.Cookies("userid").Value)
            Else
                ctlA.GPPRisk_Delete(StrNull2Zero(hdGPPUID.Value), chkRisk.Items(i).Value)
            End If
        Next

        pnDoc.Visible = True

        ctlU.User_GenLogfile(Request.Cookies("UserID").Value, ACTTYPE_ADD, "GPP", "ReqID=" & hdRequestUID.Value & ";UID=" & hdGPPUID.Value, "บันทึก GPP สสจ.", Environment.MachineName, GetIPAddress())

        'If StrNull2Zero(hdGPPUID.Value) = 0 Then
        '    Response.Redirect("PharmacyGPP?m=g&done=y&lid=" & hdLocationUID.Value)
        'Else
        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalSuccess(this,'Success','บันทึกข้อมูลเรียบร้อย');", True)
        'End If

    End Sub

    Private Sub cmdBack_Click(sender As Object, e As EventArgs) Handles cmdBack.Click
        If Convert.ToInt32(Request.Cookies("ROLE_ID").Value) >= 5 And Convert.ToInt32(Request.Cookies("ROLE_ID").Value) <= 7 Then
            Response.Redirect("PharmacyGPPListAdmin?m=g")
        Else
            Response.Redirect("PharmacyGPP?m=g&lid=" & hdLocationUID.Value)
        End If
    End Sub

    Private Sub LoadImg()
        dt = ctlM.Media_GetByYear(StrNull2Zero(hdRequestUID.Value), StrNull2Zero(lblYear.Text), StrNull2Zero(hdLocationUID.Value), "G", StrNull2Long(hdAccID.Value))
        grdImg.DataSource = dt
        grdImg.DataBind()

        If dt.Rows.Count >= 4 Then
            Label2.Text = "ท่านได้อัพโหลดไฟล์ครบ 4 ไฟล์แล้ว ไม่สามารถอัพโหลดเพิ่มได้อีก"
            cmdUpImg.Enabled = False
            Label2.Visible = True
        Else
            'Label2.Visible = False
            cmdUpImg.Enabled = True
        End If

    End Sub
    Protected Sub cmdUpImg_Click(sender As Object, e As EventArgs) Handles cmdUpImg.Click
        UploadFiles(FileUpload1, StrNull2Zero(hdAccID.Value))
        LoadImg()
    End Sub
    Private Sub UploadFiles(ByVal Fileupload As Object, REFUID As Integer)
        Dim SEQNO As String
        Dim sfileName As String = ""

        UploadDirectory = Server.MapPath("imageUploads/" & hdLocationUID.Value & "/GPP/")

        If Fileupload.HasFiles Then
            For Each uploadedFile As HttpPostedFile In Fileupload.PostedFiles
                Dim fileExtname As String = Path.GetExtension(uploadedFile.FileName).ToLower()

                If fileExtname <> ".jpg" And fileExtname <> ".jpeg" And fileExtname <> ".png" Then
                    ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','ไฟล์รูปภาพต้องมีนามสกุล .jpg, .jpeg, .png เท่านั้น');", True)
                    Exit Sub
                End If
                If (Fileupload.PostedFile.ContentLength / 1024) > 1024 Then
                    ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','ไฟล์มีขนาดใหญ่เกิน 1024 Kb. ไม่สามารถอัพโหลดได้');", True)
                    Exit Sub
                End If

                If ctlM.Media_GetCount(StrNull2Zero(hdRequestUID.Value), StrNull2Zero(lblYear.Text), StrNull2Zero(hdLocationUID.Value), "G", REFUID) >= 4 Then
                    Exit Sub
                End If
                SEQNO = ctlM.Media_GetLastSEQ(StrNull2Zero(hdRequestUID.Value), StrNull2Zero(lblYear.Text), StrNull2Zero(hdLocationUID.Value), "G", REFUID)
                sfileName = "G_" & StrNull2Zero(lblYear.Text) & "_" & StrNull2Zero(hdRequestUID.Value) & "_" & REFUID & "_" & SEQNO.ToString() & fileExtname
                ' G_ปี_requestuid_topicno_seqno.jpg
                Dim objfile As FileInfo = New FileInfo("imageUploads/" & hdLocationUID.Value & "/GPP/" & sfileName)
                If objfile.Exists Then
                    objfile.Delete()
                End If
                uploadedFile.SaveAs(System.IO.Path.Combine(UploadDirectory, sfileName))
                ctlM.Media_Save(StrNull2Zero(hdRequestUID.Value), StrNull2Zero(lblYear.Text), hdLocationUID.Value, "G", REFUID, SEQNO, sfileName, Request.Cookies("UserID").Value)
            Next
        End If
    End Sub

    Private Sub grdImg_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grdImg.RowCommand
        If TypeOf e.CommandSource Is WebControls.ImageButton Then
            Dim ButtonPressed As WebControls.ImageButton = e.CommandSource
            Select Case ButtonPressed.ID
                Case "imgView"
                    PreviewPicture("", "", e.CommandArgument())
                Case "imgDelFile"
                    DeleteImage(e.CommandArgument)
                    ctlM.Media_Delete(e.CommandArgument)
                    LoadImg()
            End Select
        End If
    End Sub

    Private Sub grdImg_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles grdImg.RowDataBound
        If e.Row.RowType = ListItemType.AlternatingItem Or e.Row.RowType = ListItemType.Item Then

            Dim scriptString As String = "javascript:return confirm(""ต้องการลบ ข้อมูลนี้ ?"");"
            Dim imgD As ImageButton = e.Row.Cells(3).FindControl("imgDelFile")
            imgD.Attributes.Add("onClick", scriptString)

        End If
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#d0e8ff';")
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;")

        End If
    End Sub
    Private Sub PreviewPicture(Fname As String, Desc As String, filePath As String)
        Dim fPath As String = "imageUploads/" & hdLocationUID.Value & "/GPP/"
        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWindow(this,'" + Fname + "','" + Desc + "','" + fPath + filePath + "?v=" & ConvertDate2DBString(Now.Date) & ConvertTimeToString(Now()) & "');", True)
    End Sub

    Protected Sub optS1Q1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles optS1Q1.SelectedIndexChanged
        CalculateScore()
    End Sub
    Protected Sub optS1Q2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles optS1Q2.SelectedIndexChanged
        chkS1Q2.Checked = False
        CalculateScore()
    End Sub
    Protected Sub optS1Q3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles optS1Q3.SelectedIndexChanged
        CalculateScore()
    End Sub
    Protected Sub optS1Q4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles optS1Q4.SelectedIndexChanged
        CalculateScore()
    End Sub
    Protected Sub optS1Q5_SelectedIndexChanged(sender As Object, e As EventArgs) Handles optS1Q5.SelectedIndexChanged
        CalculateScore()
    End Sub
    Protected Sub optS1Q6_SelectedIndexChanged(sender As Object, e As EventArgs) Handles optS1Q6.SelectedIndexChanged
        CalculateScore()
    End Sub
    Protected Sub optS1Q7_SelectedIndexChanged(sender As Object, e As EventArgs) Handles optS1Q7.SelectedIndexChanged
        CalculateScore()
    End Sub
    Protected Sub optS1Q8_SelectedIndexChanged(sender As Object, e As EventArgs) Handles optS1Q8.SelectedIndexChanged
        CalculateScore()
    End Sub

    Private Sub optS1Q9_SelectedIndexChanged(sender As Object, e As EventArgs) Handles optS1Q9.SelectedIndexChanged
        CalculateScore()
    End Sub

    Private Sub optS2Q1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles optS2Q1.SelectedIndexChanged
        chkS2Q1.Checked = False
        CalculateScore()
    End Sub
    Private Sub optS2Q2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles optS2Q2.SelectedIndexChanged
        CalculateScore()
    End Sub
    Private Sub optS2Q3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles optS2Q3.SelectedIndexChanged
        CalculateScore()
    End Sub
    Private Sub optS2Q4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles optS2Q4.SelectedIndexChanged
        CalculateScore()
    End Sub
    Private Sub optS2Q5_SelectedIndexChanged(sender As Object, e As EventArgs) Handles optS2Q5.SelectedIndexChanged
        CalculateScore()
    End Sub
    Private Sub optS2Q6_SelectedIndexChanged(sender As Object, e As EventArgs) Handles optS2Q6.SelectedIndexChanged
        CalculateScore()
    End Sub
    Private Sub optS3Q1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles optS3Q1.SelectedIndexChanged
        CalculateScore()
    End Sub

    Private Sub optS3Q2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles optS3Q2.SelectedIndexChanged
        chkS3Q2.Checked = False
        CalculateScore()
    End Sub

    Private Sub optS3Q3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles optS3Q3.SelectedIndexChanged
        CalculateScore()
    End Sub

    Private Sub optS3Q4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles optS3Q4.SelectedIndexChanged
        chkS3Q4.Checked = False
        CalculateScore()
    End Sub

    Private Sub optS3Q5_SelectedIndexChanged(sender As Object, e As EventArgs) Handles optS3Q5.SelectedIndexChanged
        chkS3Q5.Checked = False
        CalculateScore()
    End Sub

    Private Sub optS4Q1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles optS4Q1.SelectedIndexChanged
        CalculateScore()
    End Sub

    Private Sub optS4Q2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles optS4Q2.SelectedIndexChanged
        CalculateScore()
    End Sub

    Private Sub optS4Q3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles optS4Q3.SelectedIndexChanged
        CalculateScore()
    End Sub

    Private Sub optS4Q4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles optS4Q4.SelectedIndexChanged
        CalculateScore()
    End Sub

    Private Sub optS4Q5_SelectedIndexChanged(sender As Object, e As EventArgs) Handles optS4Q5.SelectedIndexChanged
        CalculateScore()
    End Sub

    Private Sub optS4Q6_SelectedIndexChanged(sender As Object, e As EventArgs) Handles optS4Q6.SelectedIndexChanged
        CalculateScore()
    End Sub

    Private Sub optS4Q7_SelectedIndexChanged(sender As Object, e As EventArgs) Handles optS4Q7.SelectedIndexChanged
        CalculateScore()
    End Sub

    Private Sub optS5Q1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles optS5Q1.SelectedIndexChanged
        CalculateScore()
    End Sub
    Private Sub optS5Q2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles optS5Q2.SelectedIndexChanged
        CalculateScore()
    End Sub
    Private Sub optS5Q3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles optS5Q3.SelectedIndexChanged
        CalculateScore()
    End Sub
    Private Sub optS5Q4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles optS5Q4.SelectedIndexChanged
        CalculateScore()
    End Sub
    Private Sub optS5Q5_SelectedIndexChanged(sender As Object, e As EventArgs) Handles optS5Q5.SelectedIndexChanged
        CalculateScore()
    End Sub
    Private Sub optS5Q6_SelectedIndexChanged(sender As Object, e As EventArgs) Handles optS5Q6.SelectedIndexChanged
        CalculateScore()
    End Sub
    Private Sub optS5Q7_SelectedIndexChanged(sender As Object, e As EventArgs) Handles optS5Q7.SelectedIndexChanged
        chkS5Q7.Checked = False
        CalculateScore()
    End Sub
    Private Sub optS5Q8_SelectedIndexChanged(sender As Object, e As EventArgs) Handles optS5Q8.SelectedIndexChanged
        CalculateScore()
    End Sub
    Private Sub optS5Q9_SelectedIndexChanged(sender As Object, e As EventArgs) Handles optS5Q9.SelectedIndexChanged
        CalculateScore()
    End Sub
    Private Sub optS5Q10_SelectedIndexChanged(sender As Object, e As EventArgs) Handles optS5Q10.SelectedIndexChanged
        chkS5Q10.Checked = False
        CalculateScore()
    End Sub
    Protected Sub optS5Q11_SelectedIndexChanged(sender As Object, e As EventArgs) Handles optS5Q11.SelectedIndexChanged
        chkS5Q11.Checked = False
        CalculateScore()
    End Sub
    Protected Sub optS5Q12_SelectedIndexChanged(sender As Object, e As EventArgs) Handles optS5Q12.SelectedIndexChanged
        CalculateScore()
    End Sub
    Protected Sub imgS1Q1_Click(sender As Object, e As EventArgs) Handles imgS1Q1.Click
        Dim fPath As String = "imageUploads/" & hdLocationUID.Value & "/GPP/"
        hdAccID.Value = "1"
        lblTopic.Text = "ข้อที่ 1.1 สถานที่ขายยาแผนปัจจุบัน ต้องมีพื้นที่ขายให้คำปรึกษาและแนะนำการใช้ยา ติดต่อกันขนาดไม่น้อยกว่า 8 ตารางเมตรทั้งนี้ไม่รวมถึงพื้นที่เก็บสำรองยา โดยความยาวของด้านที่สั้นที่สุดของพื้นที่ต้องไม่น้อยกว่า 2 เมตร (Critical Defect)"
        LoadImg()
        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalUpload(this,'1');", True)
    End Sub
    Protected Sub imgS1Q2_Click(sender As Object, e As EventArgs) Handles imgS1Q2.Click
        Dim fPath As String = "imageUploads/" & hdLocationUID.Value & "/GPP/"
        hdAccID.Value = "2"
        lblTopic.Text = "ข้อที่ 1.2 หากมีพื้นที่เก็บสำรองยาเป็นการเฉพาะ ต้องมีพื้นที่เพียงพอ เก็บอย่างเป็นระเบียบ เหมาะสม และไม่วางยาสัมผัสกับพื้นโดยตรง"
        LoadImg()
        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalUpload(this,'2');", True)
    End Sub

    Protected Sub imgS1Q3_Click(sender As Object, e As EventArgs) Handles imgS1Q3.Click
        Dim fPath As String = "imageUploads/" & hdLocationUID.Value & "/GPP/"
        hdAccID.Value = "3"
        lblTopic.Text = "ข้อ 1.3 บริเวณสำหรับให้คำปรึกษาและแนะนำการใช้ยา ต้องเป็นสัดส่วนแยกออกจากส่วนบริการอื่นอย่างชัดเจน มีพื้นที่พอสำหรับการให้คำปรึกาและการจัดเก็บประวัติ รวมทั้งจัดให้มีโต๊ะเก้าอี้สำหรับเภสัชกรและผู้มารับคำปรึกษาอยู่ในบริเวณดังกล่าวพร้อมทั้งมีป้ายแสดงชัดเจน"
        LoadImg()
        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalUpload(this,'3');", True)
    End Sub
    Protected Sub imgS1Q4_Click(sender As Object, e As EventArgs) Handles imgS1Q4.Click
        Dim fPath As String = "imageUploads/" & hdLocationUID.Value & "/GPP/"
        hdAccID.Value = "4"
        lblTopic.Text = "ข้อที่ 1.4 สถานที่ขายยาต้องมีความมั่นคง มีทะเบียนบ้านที่ออกให้โดยส่วนราชการที่เกี่ยวข้องในกรณีที่เป็นอาคารชุด ต้องมีพื้นที่อนุญาตให้ประกอบกิจการไม่ใช่ที่พักอาศัย (Critical Defect)"
        LoadImg()
        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalUpload(this,'4');", True)
    End Sub
    Protected Sub imgS1Q5_Click(sender As Object, e As EventArgs) Handles imgS1Q5.Click
        Dim fPath As String = "imageUploads/" & hdLocationUID.Value & "/GPP/"
        hdAccID.Value = "5"
        lblTopic.Text = "ข้อที่ 1.5 สถานที่ขายยาต้องมีความแข็งแรงก่อสร้างด้วยวัสดุที่คงทนถาวร เป็นสัดส่วนชัดเจน (Critical Defect)"
        LoadImg()
        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalUpload(this,'5');", True)
    End Sub
    Protected Sub imgS1Q6_Click(sender As Object, e As EventArgs) Handles imgS1Q6.Click
        Dim fPath As String = "imageUploads/" & hdLocationUID.Value & "/GPP/"
        hdAccID.Value = "6"
        lblTopic.Text = "ข้อที่ 1.6 สถานที่ขายยาต้องถูกสุขลักษณะ สะอาด เป็นระเบียบเรียบร้อย มีการควบคุมป้องกันสัตว์แมลงมารบกวน ไม่มีสัตว์เลี้ยงในบริเวณขายขาย และอากาศถ่ายเทสะดวก"
        LoadImg()
        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalUpload(this,'6');", True)
    End Sub
    Protected Sub imgS1Q7_Click(sender As Object, e As EventArgs) Handles imgS1Q7.Click
        Dim fPath As String = "imageUploads/" & hdLocationUID.Value & "/GPP/"
        hdAccID.Value = "7"
        lblTopic.Text = "ข้อที่ 1.7 สถานที่ขายยาต้องมีสภาพเหมาะสมต่อการรักษาคุณภาพยา โดยในพื้นที่ขายยาและเก็บสำรองยา ต้องมีการถ่ายเทอากาศที่ดี แห้ง สามารถควบคุมอุณหภูมิให้ไม่เกิน 30 องศาเซลเซียส และสามารถป้องกันแสงแดดไม่ให้ส่องโดยตรงถึงผลิตภัณฑ์ยา (Critical Defect)"
        LoadImg()
        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalUpload(this,'7');", True)
    End Sub
    Protected Sub imgS1Q8_Click(sender As Object, e As EventArgs) Handles imgS1Q8.Click
        Dim fPath As String = "imageUploads/" & hdLocationUID.Value & "/GPP/"
        hdAccID.Value = "8"
        lblTopic.Text = "ข้อที่ 1.8 สถานที่ขายยาต้องมีแสงสว่างเพียงพอในการอ่านเอกสาร อ่านฉลากผลิตภัณฑ์ยาและป้ายแสดงต่าง ๆ ได้อย่างชัดเจน"
        LoadImg()
        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalUpload(this,'8');", True)
    End Sub
    Protected Sub imgS1Q9_Click(sender As Object, e As EventArgs) Handles imgS1Q9.Click
        Dim fPath As String = "imageUploads/" & hdLocationUID.Value & "/GPP/"
        hdAccID.Value = "9"
        lblTopic.Text = "ข้อที่ 1.9 บริเวณจัดวางยาอันตราย และยาควบคุมพิเศษในพื้นที่ของยา จะต้อง " & vbCrLf & "1.9.1 มีพื้นที่เพียงพอในการจัดวางยาแยกตามประเภทของยาและสามารถติดป้ายแสดงประเภทของยาได้ชัดเจนตามหลักวิชาการ" & vbCrLf & "1.9.2 จัดให้มีวัสดุทึบใช้ปิดบังบริเวณที่จัดวางยาอันตราย ยาควบคุมพิเศษ สำหรับปิดในเวลาที่เภสัชกรหรือผู้มีหน้าที่ปฏิบัติการไม่อยู่ปฏิบัติหน้าที่ และจัดให้มีป้ายแจ้งให้ผู้มารับบริการทราบว่าเภสัชกรหรือผู้มีหน้าที่ปฏิบัติการไม่อยู่ (Critical lDefect)"
        LoadImg()
        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalUpload(this,'9');", True)
    End Sub
    Protected Sub imgS2Q1_Click(sender As Object, e As EventArgs) Handles imgS2Q1.Click
        Dim fPath As String = "imageUploads/" & hdLocationUID.Value & "/GPP/"
        hdAccID.Value = "10"
        lblTopic.Text = "ข้อที่ 2.1 ตู้เย็น จำนวน 1 เครื่อง (เฉพาะกรณีมียาที่ต้องเก็บรักษา ในอุณหภูมิที่ต่ำกว่าอุณหภูมิห้อง) ในสภาพที่ใช้งานได้ตามมาตรฐาน มีพื้นที่เพียงพอสำหรับการจัดเก็บยาแต่ละชนิดเป็นสัดส่วนเฉพาะ ไม่ใช่เก็บของปะปนกับสิ่งของอื่น (Critical Defect)"
        LoadImg()
        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalUpload(this,'10');", True)
    End Sub
    Protected Sub imgS2Q2_Click(sender As Object, e As EventArgs) Handles imgS2Q2.Click
        Dim fPath As String = "imageUploads/" & hdLocationUID.Value & "/GPP/"
        hdAccID.Value = "11"
        lblTopic.Text = "ข้อ 2.2 ถาดนับเม็ดยาอย่างน้อย 2 ถาดในสภาพใช้งานได้ดี และกรณีต้องมีการแบ่งบรรจุยากลุ่มเพนนิซิลิน หรือยากลุ่มซัลโฟนาไมด์ หรือยากลุ่มต้านการอักเสบชนิดที่ไม่ใช่สเตียรอยด์ (NSAID) ทั้งนี้อุปกรณ์นับเม็ดยาสำหรับยาในกลุ่มเพนนิซิลิน หรือยากลุ่มซัลโฟนาไมด์ หรือยากลุ่มต้านการอักเสบชนิดที่ไม่ใช่สเตียรอยด์ (NSAID) ให้แยกใช้เด็ดขาดจากยากลุ่มอื่นๆ\(Critical Defect) "
        LoadImg()
        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalUpload(this,'11');", True)
    End Sub
    Protected Sub imgS2Q3_Click(sender As Object, e As EventArgs) Handles imgS2Q3.Click
        Dim fPath As String = "imageUploads/" & hdLocationUID.Value & "/GPP/"
        hdAccID.Value = "12"
        lblTopic.Text = "ข้อที่ 2.3 เครื่องวัดความดันโลหิต (ชนิดอัตโนมัติ) จำนวน 1 เครื่อง ในสภาพที่ใช้งานได้ตามมาตรฐาน (Critical Defect)"
        LoadImg()
        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalUpload(this,'12');", True)
    End Sub
    Protected Sub imgS2Q4_Click(sender As Object, e As EventArgs) Handles imgS2Q4.Click
        Dim fPath As String = "imageUploads/" & hdLocationUID.Value & "/GPP/"
        hdAccID.Value = "13"
        lblTopic.Text = "ข้อที่ 2.4 เครื่องชั่งน้ำหนักสำหรับผู้มารับบริการ จำนวน 1 เครื่อง ในสภาพที่ใช้งานได้ดี"
        LoadImg()
        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalUpload(this,'13');", True)
    End Sub
    Protected Sub imgS2Q5_Click(sender As Object, e As EventArgs) Handles imgS2Q5.Click
        Dim fPath As String = "imageUploads/" & hdLocationUID.Value & "/GPP/"
        hdAccID.Value = "14"
        lblTopic.Text = "ข้อที่ 2.5 มีอุปกรณ์ที่วัดส่วนสูงสำหรับผู้มารับบริการจำนวน 1 เครื่อง ในสภาพที่ใช้งานได้ดี (Critical Defect)"
        LoadImg()
        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalUpload(this,'14');", True)
    End Sub
    Protected Sub imgS2Q6_Click(sender As Object, e As EventArgs) Handles imgS2Q6.Click
        Dim fPath As String = "imageUploads/" & hdLocationUID.Value & "/GPP/"
        hdAccID.Value = "15"
        lblTopic.Text = "ข้อที่ 2.6 อุปกรณ์สำหรับดับเพลิง จำนวน 1 เครื่องในสภาพที่สามารถพร้อมใช้งานได้อย่างมีประสิทธิภาพ อยู่ในบริเวรสถานที่เก็บยา (Critical Defect)"
        LoadImg()
        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalUpload(this,'15');", True)
    End Sub
    Protected Sub imgS3Q1_Click(sender As Object, e As EventArgs) Handles imgS3Q1.Click
        Dim fPath As String = "imageUploads/" & hdLocationUID.Value & "/GPP/"
        hdAccID.Value = "16"
        lblTopic.Text = "ข้อที่ 3.1 เภสัชกรเป็นผู้มีความรู้ ความสามารถในการให้การบริการทางเภสัชกรรมชุมชน"
        LoadImg()
        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalUpload(this,'16');", True)
    End Sub
    Protected Sub imgS3Q2_Click(sender As Object, e As EventArgs) Handles imgS3Q2.Click
        Dim fPath As String = "imageUploads/" & hdLocationUID.Value & "/GPP/"
        hdAccID.Value = "17"
        lblTopic.Text = "ข้อที่ 3.2 พนักงานร้านยา ต้องมีความรู้เกี่ยวกับกฎหมายยา และงานที่ได้รับมอบหมายจนสามารถปฏิบัติงานได้ดี และผ่านการอบรมอย่างต่อเนื่องและเพียงพอ"
        LoadImg()
        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalUpload(this,'17');", True)
    End Sub
    Protected Sub imgS3Q3_Click(sender As Object, e As EventArgs) Handles imgS3Q3.Click
        Dim fPath As String = "imageUploads/" & hdLocationUID.Value & "/GPP/"
        hdAccID.Value = "18"
        lblTopic.Text = "ข้อที่ 3.3 เภสัชกรจะต้องแต่งกายด้วยเสื้อกาวน์สีขาวติดเครื่องหมายสัญลักษณ์ของสภาเภสัชกรรม และแสดงตนว่าเป็นเภสัชกร ทั้งนี้เป็นไปตามสมควรเหมาะสมแก่ฐานะและศักดิ์ศรีแห่งวิชาชีพเภสัชกรรม แสดงตนให้แตกต่างจากพนักงานร้านยาและบุคลากรอื่นภายในร้านขายยา"
        LoadImg()
        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalUpload(this,'18');", True)
    End Sub
    Protected Sub imgS3Q4_Click(sender As Object, e As EventArgs) Handles imgS3Q4.Click
        Dim fPath As String = "imageUploads/" & hdLocationUID.Value & "/GPP/"
        hdAccID.Value = "19"
        lblTopic.Text = "ข้อที่ 3.4 การแต่งกายพนักงานร้านยาและบุคลากรอื่นภายในร้านขายยา ต้องใส่สีเสื้อ ป้ายแสดงตนไม่สื่อไปในทางที่จะก่อให้เกิดความเข้าใจว่าเป็นเภสัชกร"
        LoadImg()
        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalUpload(this,'19');", True)
    End Sub
    Protected Sub imgS3Q5_Click(sender As Object, e As EventArgs) Handles imgS3Q5.Click
        Dim fPath As String = "imageUploads/" & hdLocationUID.Value & "/GPP/"
        hdAccID.Value = "20"
        lblTopic.Text = "ข้อที่ 3.5 มีการแบ่งแยกบทบาท หน้าที่ และความรับผิดชอบของเภสัชกร พนักงานร้านยา และบุคลากรอื่นภายในร้านขายยาในการให้บริการไว้อย่างชัดเจน โดยคำนึงถึงความถูกต้องตามกฎหมายว่าด้วยยาและกฎหมายว่าด้วยวิชาชีพเภสัชกรรม"
        LoadImg()
        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalUpload(this,'20');", True)
    End Sub
    Protected Sub imgS4Q1_Click(sender As Object, e As EventArgs) Handles imgS4Q1.Click
        Dim fPath As String = "imageUploads/" & hdLocationUID.Value & "/GPP/"
        hdAccID.Value = "21"
        lblTopic.Text = "ข้อที่ 4.1 ต้องมีการคัดเลือกยา และจัดหายาจากผู้ผลิต ผู้นำเข้า ผู้จำหน่ายที่ถูกต้องตามกฎหมายว่าด้วยยาและมีมาตรฐานตามหลักเกณฑ์วิธีการที่ดีในการผลิตจัดเก็บ และการขนส่ง (Critical Defect)"
        LoadImg()
        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalUpload(this,'21');", True)
    End Sub
    Protected Sub imgS4Q2_Click(sender As Object, e As EventArgs) Handles imgS4Q2.Click
        Dim fPath As String = "imageUploads/" & hdLocationUID.Value & "/GPP/"
        hdAccID.Value = "22"
        lblTopic.Text = "ข้อที่ 4.2 ต้องมีการเก็บรักษายา ภายใต้สภาวะอุณหภูมิที่เหมาะสม หลีกเลี่ยง แสงแดด เป็นไปตามหลักวิชาการเพื่อให้ยานั้นคงคุณภาพที่ดี"
        LoadImg()
        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalUpload(this,'22');", True)
    End Sub
    Protected Sub imgS4Q3_Click(sender As Object, e As EventArgs) Handles imgS4Q3.Click
        Dim fPath As String = "imageUploads/" & hdLocationUID.Value & "/GPP/"
        hdAccID.Value = "23"
        lblTopic.Text = "ข้อที่ 4.3 ต้องมีระบบตรวจสอบยาที่หมดอายุหรือเสื่อมคุณภาพที่มีประสิทธิภาพ เพื่อไม่ให้มีไว้ ณ จุดจ่ายยา (Critical Defect)"
        LoadImg()
        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalUpload(this,'23');", True)
    End Sub
    Protected Sub imgS4Q4_Click(sender As Object, e As EventArgs) Handles imgS4Q4.Click
        Dim fPath As String = "imageUploads/" & hdLocationUID.Value & "/GPP/"
        hdAccID.Value = "24"
        lblTopic.Text = "ข้อที่ 4.4 ต้องมีระบบการส่งคืนหรือทำลายยาที่หมดอายุ หรือยาเสื่อมคุณภาพให้ชัดเจน ถูกต้องตามหลักวิชาการ ไม่เป็นปัญหากับสิ่งแวดล้อม รวมถึงระบบการป้องกันการนำยาดังกล่าวไปจำหน่าย"
        LoadImg()
        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalUpload(this,'24');", True)
    End Sub
    Protected Sub imgS4Q5_Click(sender As Object, e As EventArgs) Handles imgS4Q5.Click
        Dim fPath As String = "imageUploads/" & hdLocationUID.Value & "/GPP/"
        hdAccID.Value = "25"
        lblTopic.Text = "ข้อที่ 4.5 ต้องมีระบบการตรวจสอบคุณภาพยาคืนหรือยาเปลี่ยน ก่อนกลับมาจำหน่ายโดยคำนึงถึงประสิทธิภาพของยาและความปลอดภัยของผู้ใช้ยา"
        LoadImg()
        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalUpload(this,'25');", True)
    End Sub
    Protected Sub imgS4Q6_Click(sender As Object, e As EventArgs) Handles imgS4Q6.Click
        Dim fPath As String = "imageUploads/" & hdLocationUID.Value & "/GPP/"
        hdAccID.Value = "26"
        lblTopic.Text = "ข้อที่ 4.6 ต้องจัดให้มีระบบเอกสารที่เกี่ยวกับการจัดหา จัดการคลังสินค้าและการจำหน่ายให้ถูกต้อง เป็นปัจจุบันสามารถสืบย้อนได้"
        LoadImg()
        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalUpload(this,'26');", True)
    End Sub
    Protected Sub imgS4Q7_Click(sender As Object, e As EventArgs) Handles imgS4Q7.Click
        Dim fPath As String = "imageUploads/" & hdLocationUID.Value & "/GPP/"
        hdAccID.Value = "27"
        lblTopic.Text = "ข้อที่ 4.7 ต้องเลือกภาชนะบรรจุที่เหมาะสม เพื่อป้องกันไม่ให้ยาเสื่อมสภาพก่อนเวลาอันสมควรพร้อมฉลากยา"
        LoadImg()
        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalUpload(this,'27');", True)
    End Sub
    Protected Sub imgS5Q1_Click(sender As Object, e As EventArgs) Handles imgS5Q1.Click
        Dim fPath As String = "imageUploads/" & hdLocationUID.Value & "/GPP/"
        hdAccID.Value = "28"
        lblTopic.Text = "ข้อที่ 5.1 การให้บริการทางเภสัชกรรม ตามหน้าที่ที่กฎหมายว่าด้วยยาและกฎหมายว่าด้วยวิชาชีพเภสัชกรรมต้องปฏิบัติโดยเภสัชกร 5.1.1 มีป้ายตามที่กฎหมายกำหนดและติดตั้งถูกต้อง-ป้ายสถานที่ขายยาแผนปัจจุบัน-ป้ายเภสัชกรผู้มีหน้าที่ปฏิบัติการ 5.1.2 มีใบอนุญาตตามที่กฎหมายกำหนดและติดตั้งถูกต้อง-ใบอนุญาตขายยาแผนปัจจุบัน-ใบประกอบวิชาชีพเภสัชกรรมของเภสัชกรผู้มีหน้าที่ปฏิบัติการ 5.1.3 บัญชียาประเภทต่าง ๆ (เช่ยน ขย.๕ ขย.๑๑) และบันทึกถูกต้อง (Critical Defect)"
        LoadImg()
        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalUpload(this,'28');", True)
    End Sub
    Protected Sub imgS5Q2_Click(sender As Object, e As EventArgs) Handles imgS5Q2.Click
        Dim fPath As String = "imageUploads/" & hdLocationUID.Value & "/GPP/"
        hdAccID.Value = "29"
        lblTopic.Text = "ข้อที่ 5.2 ต้องซักถามข้อมูลที่จำเป็นของผู้ที่มารับบริการ เพื่อประกอบการพิจารณาก่อนเลือกสรรยาหรือผลิตภัณฑ์สุขภาพที่มีประสิทธิภาพ ปลอดภัย เหมาะสมกับผู้ป่วยตามหลักวิชาการ สมเหตุสมผลตามมาตรฐานการประกอบวิชาชีพ"
        LoadImg()
        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalUpload(this,'29');", True)
    End Sub
    Protected Sub imgS5Q3_Click(sender As Object, e As EventArgs) Handles imgS5Q3.Click
        Dim fPath As String = "imageUploads/" & hdLocationUID.Value & "/GPP/"
        hdAccID.Value = "30"
        lblTopic.Text = "ข้อที่ 5.3 จัดให้มีฉลากบนซองบรรจุยา หรือภาชนะบรรจุยาอันตรายและยาควบคุมพิเศษที่ส่งมอบให้ผู้รับบริการโดยต้องแสดงข้อมูลอย่างน้อย ดังนี้ 5.3.1 ชื่อ ที่อยู่ของร้ายขายยาและหมายเลขโทรศัพท์ที่สามารถติดต่อได้ 5.3.2 ข้อมูลเพื่อให้ผู้รับบริการใช้ยาได้อย่างถูกต้อง เหมาะสม ปลอดภัย ติดตามได้ดังนี้ – วันที่จ่าย-ชื่อผู้รับบริการ-ชื่อยาที่เป็นชื่อสามัญทางยา หรือชื่อการค้า ความแรงจำนวนจ่าย-ข้อบ่งใช้-วิธีใช้ยาที่ชัดเจนเข้าใจง่าย-ฉลากช่วย คำแนะนำ คำเตือน หรือเอกสารให้ความรู้เพิ่มเติม (ถ้าจำเป็น) – ลายมือชื่อเภสัชกร"
        LoadImg()
        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalUpload(this,'30');", True)
    End Sub
    Protected Sub imgS5Q4_Click(sender As Object, e As EventArgs) Handles imgS5Q4.Click
        Dim fPath As String = "imageUploads/" & hdLocationUID.Value & "/GPP/"
        hdAccID.Value = "31"
        lblTopic.Text = "ข้อที่ 5.4 การส่งมอบยาอันตราย ยาควบคุมพิเศษ ให้กับผู้มารับบริการเฉพาะราย ต้องกระทำโดยเภสัชกรผู้มีหน้าที่ปฏิบัติการเท่านั้น พร้อมให้คำแนะนำตามหลักวิชาการและจรรยาบรรณ แห่งวิชาชีพ โดยต้องให้ข้อมูลดังนี้-ชื่อยา-ข้อบ่งใช้-ขนาด และวิธีการใช้-ผลข้างเคียง (side effect) (ถ้ามี) และอาการไม่พึงประสงค์จากการใช้ยา (Adverse Drug Reaction) ที่อาจเกิดขึ้น-ข้อควรระวังและข้อควรปฏิบัติในการใช้ยา-การปฏิบัติเมื่อเกิดปัญหาจากการใช้ยา)"
        LoadImg()
        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalUpload(this,'31');", True)
    End Sub
    Protected Sub imgS5Q5_Click(sender As Object, e As EventArgs) Handles imgS5Q5.Click
        Dim fPath As String = "imageUploads/" & hdLocationUID.Value & "/GPP/"
        hdAccID.Value = "32"
        lblTopic.Text = "ข้อที่ 5.5 มีกระบวนการในการป้องกันการแพ้ยาซ้ำของผู้มารับบริการที่มีประสิทธิภาพเหมาะสม"
        LoadImg()
        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalUpload(this,'32');", True)
    End Sub
    Protected Sub imgS5Q6_Click(sender As Object, e As EventArgs) Handles imgS5Q6.Click
        Dim fPath As String = "imageUploads/" & hdLocationUID.Value & "/GPP/"
        hdAccID.Value = "33"
        lblTopic.Text = "ข้อที่ 5.6 มีกระบวนการคัดกรองและส่งต่อผู้ป่วยที่เหมาะสม"
        LoadImg()
        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalUpload(this,'33');", True)
    End Sub
    Protected Sub imgS5Q7_Click(sender As Object, e As EventArgs) Handles imgS5Q7.Click
        Dim fPath As String = "imageUploads/" & hdLocationUID.Value & "/GPP/"
        hdAccID.Value = "34"
        lblTopic.Text = "ข้อที่ 5.7 กรณีที่มีการผลิตยาตามใบสั่งยาของผู้ประกอบวิชาชีพเวชกรรมหรือของผู้ประกอบโรคศิลปะที่สั่งสำหรับคนไข้เฉพาะรายหรือตามใบสั่งยาของผู้ประกอบวิชาชีพการสัตวแพทย์ สำหรับสัตว์เฉพาะรายและการแบ่งบรรจุยาในสถานที่ขายยาให้คำนึงถึงการปนเปื้อน การแพ้ยา โดยต้องจัดให้มีสถานที่ อุปกรณ์ตามที่กำหนดและเป็นไปตามมาตรฐานการประกอบวิชาชพีเภสัชกรรมด้านการผลิตยาสำหรับคนไข้เฉพาะรายของสภาเภสัชกรรม"
        LoadImg()
        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalUpload(this,'34');", True)
    End Sub
    Protected Sub imgS5Q8_Click(sender As Object, e As EventArgs) Handles imgS5Q8.Click
        Dim fPath As String = "imageUploads/" & hdLocationUID.Value & "/GPP/"
        hdAccID.Value = "35"
        lblTopic.Text = "ข้อที่ 5.8 ต้องจัดให้มีกระบวนการเฝ้าระวังอาการไม่พึงประสงค์ พฤติกรรมการใช้ยาไม่เหมาะสม ปัญหาคุณภาพยา และรายงานให้หน่วยงานที่เกี่ยวข้องทราบ"
        LoadImg()
        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalUpload(this,'35');", True)
    End Sub
    Protected Sub imgS5Q9_Click(sender As Object, e As EventArgs) Handles imgS5Q9.Click
        Dim fPath As String = "imageUploads/" & hdLocationUID.Value & "/GPP/"
        hdAccID.Value = "36"
        lblTopic.Text = "ข้อที่ 5.9 จัดให้มีแหล่งข้อมูลอ้างอิงด้านยาที่เหมาะสมเชื่อถือได้ สำหรับใช้ในการให้บริการทางเภสัชกรรมเพื่อส่งเสริมการใช้ยาอย่างถูกต้อง ปลอดภัย รวมทั้งการให้บริการเภสัชสนเทศ"
        LoadImg()
        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalUpload(this,'36');", True)
    End Sub
    Protected Sub imgS5Q10_Click(sender As Object, e As EventArgs) Handles imgS5Q10.Click
        Dim fPath As String = "imageUploads/" & hdLocationUID.Value & "/GPP/"
        hdAccID.Value = "37"
        lblTopic.Text = "ข้อที่ 5.10 การจัดวางสื่อให้ความรู้และสื่อโฆษณาสำหรับผู้มารับบริการจะต้องได้รับคำยินยอมอย่างเป็นลายลักษณ์อักษรจากเภสัชกรผู้มีหน้าที่ปฏิบัติการ และให้ถือเป็นความรับผิดชอบที่เภสัชกรผู้มีหน้าที่ปฏิบัติการจะต้องควบคุม โดยจะต้องไม่โอ้อวด ไม่บิดเบือนความจริง ไม่สร้างความเข้าใจผิดให้ผู้บริโภค และต้องผ่านการอนุญาตถูกต้องตามกฎหมาย"
        LoadImg()
        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalUpload(this,'37');", True)
    End Sub
    Protected Sub imgS5Q11_Click(sender As Object, e As EventArgs) Handles imgS5Q11.Click
        Dim fPath As String = "imageUploads/" & hdLocationUID.Value & "/GPP/"
        hdAccID.Value = "38"
        lblTopic.Text = "ข้อที่ 5.11 การดำเนินกิจกรรมด้านสุขภาพที่เกี่ยวข้องกับผู้มารับบริการในร้านยา โดยบุคลากรอื่นซึ่งมิใช่เภสัชกรหรือพนักงานร้านยา จะต้องได้รับคำยินยอมเป็นลายลักษณ์อักษรจากเภสัชกร และให้ถือเป็นความรับผิดชอบที่เภสัชกรจะต้องควบคุมกำกับการดำเนินกิจกรรมต่าง ๆ ในสถานที่ขายยาให้ถูกต้องตามกฎหมายว่าด้วยยาหรือกฎหมายอื่นที่เกี่ยวข้องกับผลิตภัณฑ์สุขภาพนั้น ๆ รวมทั้งกฎหมายว่าด้วยวิชาชีพเภสัชกรรม"
        LoadImg()
        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalUpload(this,'38');", True)
    End Sub
    Protected Sub imgS5Q12_Click(sender As Object, e As EventArgs) Handles imgS5Q12.Click
        Dim fPath As String = "imageUploads/" & hdLocationUID.Value & "/GPP/"
        hdAccID.Value = "39"
        lblTopic.Text = "ข้อที่ 5.12 ไม่จำหน่ายผลิตภัณฑ์ยาสูบและเครื่องดื่มที่มีส่วนผสมของแอลกฮอล์"
        LoadImg()
        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalUpload(this,'39');", True)
    End Sub

    'Protected Sub txtFinalScore_TextChanged(sender As Object, e As EventArgs) Handles txtFinalScore.TextChanged
    '    lblFinalPercent.Text = ((StrNull2Double(txtFinalScore.Text) * 100) / StrNull2Double(lblTotalScore.Text)).ToString("##.##")

    '    If StrNull2Zero(lblScoreS1Q1.Text) <= 0 Or StrNull2Zero(lblScoreS1Q4.Text) <= 0 Or StrNull2Zero(lblScoreS1Q5.Text) <= 0 Or StrNull2Zero(lblScoreS1Q7.Text) <= 0 Or StrNull2Zero(lblScoreS1Q9.Text) <= 0 Or StrNull2Zero(lblScoreS2Q1.Text) <= 0 Or StrNull2Zero(lblScoreS2Q2.Text) <= 0 Or StrNull2Zero(lblScoreS2Q3.Text) <= 0 Or StrNull2Zero(lblScoreS2Q4.Text) <= 0 Or StrNull2Zero(lblScoreS2Q5.Text) <= 0 Or StrNull2Zero(lblScoreS2Q6.Text) <= 0 Or StrNull2Zero(lblScoreS4Q1.Text) <= 0 Or StrNull2Zero(lblScoreS4Q3.Text) <= 0 Or StrNull2Zero(lblScoreS5Q1.Text) <= 0 Then

    '        ddlFinalResult.ForeColor = System.Drawing.Color.Red
    '        ddlFinalResult.SelectedValue = "N"
    '    Else
    '        If StrNull2Double(lblFinalPercent.Text) < 70 Then
    '            ddlFinalResult.ForeColor = System.Drawing.Color.Red
    '            ddlFinalResult.SelectedValue = "N" 
    '        Else
    '            ddlFinalResult.ForeColor = System.Drawing.Color.Green
    '            ddlFinalResult.SelectedValue = "Y"
    '        End If
    '    End If
    'End Sub
    Protected Sub chkS1Q2_CheckedChanged(sender As Object, e As EventArgs) Handles chkS1Q2.CheckedChanged
        If chkS1Q2.Checked = True Then
            optS1Q2.ClearSelection()
            CalculateScore()
        End If
    End Sub

    Private Sub chkS2Q1_CheckedChanged(sender As Object, e As EventArgs) Handles chkS2Q1.CheckedChanged
        If chkS2Q1.Checked = True Then
            optS2Q1.ClearSelection()
            CalculateScore()
        End If
    End Sub
    Protected Sub chkS3Q2_CheckedChanged(sender As Object, e As EventArgs) Handles chkS3Q2.CheckedChanged
        If chkS3Q2.Checked = True Then
            optS3Q2.ClearSelection()
            CalculateScore()
        End If
    End Sub
    Protected Sub chkS3Q4_CheckedChanged(sender As Object, e As EventArgs) Handles chkS3Q4.CheckedChanged
        If chkS3Q4.Checked = True Then
            optS3Q4.ClearSelection()
            CalculateScore()
        End If
    End Sub
    Protected Sub chkS3Q5_CheckedChanged(sender As Object, e As EventArgs) Handles chkS3Q5.CheckedChanged
        If chkS3Q5.Checked = True Then
            optS3Q5.ClearSelection()
            CalculateScore()
        End If
    End Sub
    Private Sub DeleteImage(MediaUID As Integer)
        dt = ctlM.Media_GetByID(MediaUID)
        If dt.Rows.Count > 0 Then
            Dim sPath As String = ""
            Select Case dt.Rows(0)("ImageGroup")
                Case "S", "L", "A", "M"
                    sPath = "/Locations/"
                Case "G"
                    sPath = "/GPP/"
                Case "P", "R", "Q"
                    sPath = "/QA/"
            End Select

            Dim objfile As FileInfo = New FileInfo(Server.MapPath("~/imageUploads/" & hdLocationUID.Value & sPath & dt.Rows(0)("FilePath")))
            If objfile.Exists Then
                objfile.Delete()
            End If

        End If
    End Sub

    Private Sub chkS5Q7_CheckedChanged(sender As Object, e As EventArgs) Handles chkS5Q7.CheckedChanged
        If chkS5Q7.Checked = True Then
            optS5Q7.ClearSelection()
            CalculateScore()
        End If
    End Sub

    Private Sub chkS5Q10_CheckedChanged(sender As Object, e As EventArgs) Handles chkS5Q10.CheckedChanged
        If chkS5Q10.Checked = True Then
            optS5Q10.ClearSelection()
            CalculateScore()
        End If
    End Sub

    Private Sub chkS5Q11_CheckedChanged(sender As Object, e As EventArgs) Handles chkS5Q11.CheckedChanged
        If chkS5Q11.Checked = True Then
            optS5Q11.ClearSelection()
            CalculateScore()
        End If
    End Sub

    Private Sub cmdClose_Click(sender As Object, e As EventArgs) Handles cmdClose.Click
        ctlA.GPP_Assessment_Close(hdGPPUID.Value, StrNull2Zero(Request.Cookies("userid").Value))
        ctlU.User_GenLogfile(Request.Cookies("UserID").Value, "CLOSE", "GPP", "UID=" & hdGPPUID.Value, "ปิดการประเมิน GPP สสจ.", Environment.MachineName, GetIPAddress())
        cmdSave.Visible = False
        cmdClose.Visible = False
        cmdReOpen.Visible = True
        Response.Redirect("PharmacyGPP?m=g&close=y&lid=" & hdLocationUID.Value)
    End Sub

    Private Sub cmdReOpen_Click(sender As Object, e As EventArgs) Handles cmdReOpen.Click
        ctlA.GPP_Assessment_Open(hdGPPUID.Value, StrNull2Zero(Request.Cookies("userid").Value))
        ctlU.User_GenLogfile(Request.Cookies("UserID").Value, "OPEN", "GPP", "UID=" & hdGPPUID.Value, "เปิดการประเมิน GPP อีกครั้ง สสจ.", Environment.MachineName, GetIPAddress())
        cmdSave.Visible = True
        cmdClose.Visible = True
        cmdReOpen.Visible = False
        DisableControl(True)
        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalSuccess(this,'Success','เปิดการประเมินเรียบร้อย');", True)
    End Sub

    Private Sub cmdAddFile_Click(sender As Object, e As EventArgs) Handles cmdAddFile.Click
        Dim sfileName As String = ""
        UploadDirectory = Server.MapPath("~/imageUploads/" & hdLocationUID.Value & "/GPP/")


        If Not Directory.Exists(UploadDirectory) Then
            Directory.CreateDirectory(UploadDirectory)
        End If

        If FileUpload2.HasFiles Then
            Dim fileExtname As String = Path.GetExtension(FileUpload2.FileName).ToLower()
            If fileExtname <> ".jpg" And fileExtname <> ".jpeg" And fileExtname <> ".png" And fileExtname <> ".pdf" And fileExtname <> ".docx" Then
                ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','ไฟล์รูปภาพต้องมีนามสกุล .jpg, .jpeg,.png,ไฟล์เอกสาร เท่านั้น');", True)
                Exit Sub
            End If

            If (FileUpload2.PostedFile.ContentLength / 1024) > 5120 Then
                ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ผลการตรวจสอบ','ไฟล์มีขนาดใหญ่เกิน 5,120 Kb. ไม่สามารถอัพโหลดได้');", True)
                Exit Sub
            End If

            sfileName = "GPPDocument_" & lblYear.Text & "_" & ConvertDate2DBString(Now.Date) & ConvertTimeToString(Now()) & fileExtname
            Dim objfile As FileInfo = New FileInfo(UploadDirectory & sfileName)
            If objfile.Exists Then
                objfile.Delete()
            End If
            FileUpload2.SaveAs(System.IO.Path.Combine(UploadDirectory, sfileName))
            ctlD.GPPDocument_Save(StrNull2Zero(hdGPPUID.Value), txtDocumentName.Text, StrNull2Zero(hdLocationUID.Value), sfileName, StrNull2Zero(Request.Cookies("UserID").Value))
        End If
        txtDocumentName.Text = ""
        LoadDocument()
    End Sub
    Private Sub LoadDocument()
        dt = ctlD.GPPDocument_Get(hdGPPUID.Value)
        grdDocument.DataSource = dt
        grdDocument.DataBind()
    End Sub
    Private Sub grdDocument_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grdDocument.RowCommand
        If TypeOf e.CommandSource Is WebControls.ImageButton Then
            Dim ButtonPressed As WebControls.ImageButton = e.CommandSource
            Select Case ButtonPressed.ID
                Case "imgDel"
                    DeleteDocumentFile(e.CommandArgument)
                    ctlD.Document_Delete(e.CommandArgument)
                    LoadDocument()
            End Select
        End If
    End Sub


    Private Sub grdDocument_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles grdDocument.RowDataBound
        If e.Row.RowType = ListItemType.AlternatingItem Or e.Row.RowType = ListItemType.Item Then
            Dim scriptString As String = "javascript:return confirm(""ต้องการลบ ข้อมูลนี้ ?"");"
            Dim imgD As ImageButton = e.Row.Cells(2).FindControl("imgDel")
            imgD.Attributes.Add("onClick", scriptString)

        End If
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#d0e8ff';")
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;")
        End If
    End Sub
    Private Sub DeleteDocumentFile(DocUID As Integer)
        Dim ctlM As New DocumentController
        dt = ctlM.Document_GetByID(DocUID)
        If dt.Rows.Count > 0 Then
            Dim objfile As FileInfo = New FileInfo(Server.MapPath("~/imageUploads/" & hdLocationUID.Value & "/GPP/" & dt.Rows(0)("FilePath")))
            If objfile.Exists Then
                objfile.Delete()
            End If
        End If
    End Sub

    Private Sub cmdPrint_Click(sender As Object, e As EventArgs) Handles cmdPrint.Click
        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "Report", "window.open('ReportViewer?R=gpnt&id=" & hdGPPUID.Value & "&lid=" & hdLocationUID.Value & "&RPTTYPE=PDF','_blank');", True)
        'ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "Report", "window.open('Reports/ReportGPP.aspx?id=" & hdGPPUID.Value & "&RPTTYPE=PDF','_blank');", True)
    End Sub

    Private Sub cmdDelete_Click(sender As Object, e As EventArgs) Handles cmdDelete.Click
        ctlA.GPP_Assessment_Delete(hdGPPUID.Value, StrNull2Zero(Request.Cookies("userid").Value))
        ctlU.User_GenLogfile(Request.Cookies("UserID").Value, "DEL", "GPP", "UID=" & hdGPPUID.Value, "ลบการประเมิน GPP สสจ.", Environment.MachineName, GetIPAddress())

        Response.Redirect("PharmacyGPP?m=g&del=y&lid=" & hdLocationUID.Value)
    End Sub
End Class