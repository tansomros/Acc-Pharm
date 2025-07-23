Imports BigLion
Imports DevExpress.Web.ASPxHtmlEditor.Internal

Public Class Setting
    Inherits System.Web.UI.Page

    Dim ctlL As New LocationController
    Dim dt As New DataTable
    Dim acc As New UserController

    Dim ctlFDA As New FDAServiceController
    Dim NewCode As String
    Dim pvncd As String
    Dim lcnno_noo As String
    Dim lcnno_not_pvnabbr As String
    Dim licen_time As String
    Dim grannm_lo As String
    Dim thanm As String
    Dim thaaddr As String
    Dim thabuilding As String
    Dim thasoi As String
    Dim tharoad As String
    Dim thamu As String
    Dim thathmblnm As String
    Dim zipcode As String
    Dim tel As String
    Dim thanm_address As String
    Dim thaamphrnm As String
    Dim thachngwtnm As String
    Dim cncnm As String
    Dim appdate As String
    Dim expyear As String
    Dim lmdfdate As String
    Dim Newcode_not As String
    Dim LICENSE_NO_SEARCH2 As String
    Dim licen As String
    Dim tharoom As String
    Dim thafloor As String
    Dim phrno As String
    Dim phrnm As String
    Dim pharmacy_name As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsNothing(Request.Cookies("CPAQA")) Then
            Response.Redirect("Default.aspx")
        End If
        If Not IsPostBack Then
            pnSuccess.Visible = False
            pnDanger.Visible = False
        End If

        'cmdDelete.Attributes.Add("onClick", "javascript:return confirm(""ต้องการลบรายการนี้ใช่หรือไม่?"");")
    End Sub
    Function checkField(tD As DataTable, ColumnName As String) As String
        If tD.Columns(ColumnName) IsNot Nothing Then
            Return String.Concat(tD.Rows(0)(ColumnName))
        Else
            Return ""
        End If
    End Function
    Function checkFieldDtt(tD As DataTable, ColumnName As String) As Integer
        If tD.Columns(ColumnName) IsNot Nothing Then
            Dim dtt As String
            If Left(tD.Rows(0)(ColumnName), 6) = "Feb 29" Then
                Dim y As String = Mid(tD.Rows(0)(ColumnName), 8, 4)
                If CInt(y) > 2500 Then
                    y = CInt(y) - 543
                End If
                dtt = y + "0229"
            Else
                dtt = ConvertDate2DBString(tD.Rows(0)(ColumnName))
            End If


            Return dtt 'y + "-" + m + "-" + d
        Else
            Return Nothing
        End If
    End Function

    Private Sub cmdRequestNewFDA_Click(sender As Object, e As EventArgs) Handles cmdRequestNewFDA.Click
        Dim dtP As New DataTable
        dt = ctlL.Location_GetForNewFDA
        If dt.Rows.Count = 0 Then
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningAlert(this,'Success','No data update.');", True)
            Exit Sub
        End If

        For i = 0 To dt.Rows.Count - 1
            With dt.Rows(i)
                If String.Concat(.Item("NewCode")) <> "" Then
                    NewCode = String.Concat(.Item("NewCode")) ' ctlFDA.ConvertLicenseToNewCode(dt.Rows(i)("LicenseNo1"))
                    dtP = ctlFDA.GET_DRUG_LCN_INFORMATION(NewCode)
                    If Not dtP Is Nothing Then
                        'lblthanm.Text = "ไม่พบเลข ขย.นี้ในฐานข้อมูล อย. กรุณาตรวจสอบ"
                        'Exit sub
                        If dtP.Rows.Count > 0 Then
                            dtP.DefaultView.Sort = "lcnno desc,lcnno desc"
                            Dim dtResult As DataTable = dtP.DefaultView.ToTable()

                            Try
                                pvncd = checkField(dtResult, "pvncd")
                                lcnno_noo = checkField(dtResult, "lcnno_noo")
                                lcnno_not_pvnabbr = checkField(dtResult, "lcnno_not_pvnabbr")
                                licen = checkField(dtResult, "licen")
                                licen_time = checkField(dtResult, "licen_time")
                                grannm_lo = checkField(dtResult, "grannm_lo")
                                thanm = checkField(dtResult, "thanm")
                                thaaddr = checkField(dtResult, "thaaddr")
                                tharoom = checkField(dtResult, "tharoom")
                                thafloor = checkField(dtResult, "thafloor")
                                thabuilding = checkField(dtResult, "thabuilding")
                                thasoi = checkField(dtResult, "thasoi")
                                tharoad = checkField(dtResult, "tharoad")
                                thamu = checkField(dtResult, "thamu")
                                thathmblnm = checkField(dtResult, "thathmblnm")
                                zipcode = checkField(dtResult, "zipcode")
                                tel = checkField(dtResult, "tel")
                                thanm_address = checkField(dtResult, "thanm_address")
                                thaamphrnm = checkField(dtResult, "thaamphrnm")
                                thachngwtnm = checkField(dtResult, "thachngwtnm")
                                cncnm = checkField(dtResult, "cncnm")
                                appdate = checkField(dtResult, "appdate")
                                expyear = checkField(dtResult, "expyear")
                                lmdfdate = checkField(dtResult, "lmdfdate")
                                Newcode_not = checkField(dtResult, "Newcode_not")
                                LICENSE_NO_SEARCH2 = checkField(dtResult, "LICENSE_NO_SEARCH2")

                                ctlL.PhamacyLicense_Save(DBNull2Zero(dt.Rows(i)("UID")), dt.Rows(i)("LicenseNo1"), NewCode, pvncd, lcnno_noo, lcnno_not_pvnabbr, licen, licen_time, grannm_lo, thanm, thaaddr, tharoom, thafloor, thabuilding, thasoi, tharoad, thamu, thathmblnm, zipcode, tel, thanm_address, thaamphrnm, thachngwtnm, cncnm, appdate, expyear, lmdfdate, Newcode_not, LICENSE_NO_SEARCH2)

                                pnDanger.Visible = False
                                pnSuccess.Visible = True
                                lblSuccess.Text = "Success."
                            Catch ex As Exception
                                pnSuccess.Visible = False
                                pnDanger.Visible = True
                                lblDanger.Text = "Warning!! " & ex.Message
                            End Try
                        End If
                    End If
                End If
            End With
        Next

        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalSuccess(this,'Success','บันทึกเรียบร้อย');", True)
    End Sub

    Private Sub cmdLicenseUpdate_Click(sender As Object, e As EventArgs) Handles cmdLicenseUpdate.Click
        Dim dtP As New DataTable
        dt = ctlL.PharmacyLicense_GetForUpdateLicen
        If dt.Rows.Count = 0 Then
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningAlert(this,'Success','No data update.');", True)
            Exit Sub
        End If

        For i = 0 To dt.Rows.Count - 1
            With dt.Rows(i)
                If String.Concat(.Item("NewCode")) <> "" Then
                    NewCode = String.Concat(.Item("NewCode"))
                    dtP = ctlFDA.GET_DRUG_PHARMACY(NewCode)
                    If Not dtP Is Nothing Then
                        'lblthanm.Text = "ไม่พบเลข ขย.นี้ในฐานข้อมูล อย. กรุณาตรวจสอบ"
                        'Exit sub
                        If dtP.Rows.Count > 0 Then
                            dtP.DefaultView.Sort = "lcnno desc,lcnno desc"
                            Dim dtResult As DataTable = dtP.DefaultView.ToTable()

                            Try
                                'pvncd = checkField(dtResult, "pvncd")
                                'lcnno_noo = checkField(dtResult, "lcnno_noo")
                                'lcnno_not_pvnabbr = checkField(dtResult, "lcnno_not_pvnabbr")
                                licen = checkField(dtResult, "licen")
                                'phrno = checkField(dtResult, "phrno")
                                'phrnm = checkField(dtResult, "phrnm")
                                'pharmacy_name = checkField(dtResult, "pharmacy_name")

                                'licen_time = checkField(dtResult, "licen_time")
                                'grannm_lo = checkField(dtResult, "grannm_lo")
                                'thanm = checkField(dtResult, "thanm")
                                'thaaddr = checkField(dtResult, "thaaddr")
                                'tharoom = checkField(dtResult, "tharoom")
                                'thafloor = checkField(dtResult, "thafloor")
                                'thabuilding = checkField(dtResult, "thabuilding")
                                'thasoi = checkField(dtResult, "thasoi")
                                'tharoad = checkField(dtResult, "tharoad")
                                'thamu = checkField(dtResult, "thamu")
                                'thathmblnm = checkField(dtResult, "thathmblnm")
                                'zipcode = checkField(dtResult, "zipcode")
                                'tel = checkField(dtResult, "tel")
                                'thanm_address = checkField(dtResult, "thanm_address")
                                'thaamphrnm = checkField(dtResult, "thaamphrnm")
                                'thachngwtnm = checkField(dtResult, "thachngwtnm")
                                'cncnm = checkField(dtResult, "cncnm")
                                'appdate = checkField(dtResult, "appdate")
                                'expyear = checkField(dtResult, "expyear")
                                'lmdfdate = checkField(dtResult, "lmdfdate")
                                'Newcode_not = checkField(dtResult, "Newcode_not")
                                'LICENSE_NO_SEARCH2 = checkField(dtResult, "LICENSE_NO_SEARCH2")

                                ctlL.PhamacyLicense_UpdateLicen(NewCode, licen)

                                pnDanger.Visible = False
                                pnSuccess.Visible = True
                                lblSuccess.Text = "Update ชื่อผู้ได้รับอนุญาต 1 Success."
                            Catch ex As Exception
                                pnSuccess.Visible = False
                                pnDanger.Visible = True
                                lblDanger.Text = "Warning!! ชื่อผู้ได้รับอนุญาต 1" & ex.Message
                            End Try
                        End If
                    End If
                End If
            End With
        Next

        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalSuccess(this,'Success','บันทึกเรียบร้อย');", True)

    End Sub
    Private Sub cmdLicenseUpdate2_Click(sender As Object, e As EventArgs) Handles cmdLicenseUpdate2.Click
        Dim dtP As New DataTable
        dt = ctlL.PharmacyLicense_GetForUpdateLicen
        If dt.Rows.Count = 0 Then
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningAlert(this,'Success','No data update.');", True)
            Exit Sub
        End If

        For i = 0 To dt.Rows.Count - 1
            With dt.Rows(i)
                If String.Concat(.Item("NewCode")) <> "" Then
                    NewCode = String.Concat(.Item("NewCode"))
                    dtP = ctlFDA.GET_DRUG_LICEN(NewCode)
                    If Not dtP Is Nothing Then
                        'lblthanm.Text = "ไม่พบเลข ขย.นี้ในฐานข้อมูล อย. กรุณาตรวจสอบ"
                        'Exit sub
                        If dtP.Rows.Count > 0 Then
                            dtP.DefaultView.Sort = "lcnno desc,lcnno desc"
                            Dim dtResult As DataTable = dtP.DefaultView.ToTable()

                            Try
                                licen = checkField(dtResult, "licen")
                                ctlL.PhamacyLicense_UpdateLicen(NewCode, licen)
                                pnDanger.Visible = False
                                pnSuccess.Visible = True
                                lblSuccess.Text = "Update ชื่อผู้ได้รับอนุญาต 2 Success."
                            Catch ex As Exception
                                pnSuccess.Visible = False
                                pnDanger.Visible = True
                                lblDanger.Text = "Warning!! ชื่อผู้ได้รับอนุญาต 2" & ex.Message
                            End Try
                        End If
                    End If
                End If
            End With
        Next

        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalSuccess(this,'Success','Update ชื่อผู้ได้รับอนุญาต 2 เรียบร้อย');", True)

    End Sub
    Private Sub cmdPharmacist_Click(sender As Object, e As EventArgs) Handles cmdPharmacist.Click
        Dim dtP As New DataTable
        dt = ctlL.PharmacyLicense_GetForUpdatePharmacist
        If dt.Rows.Count = 0 Then
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningAlert(this,'Success','No data update.');", True)
            Exit Sub
        End If

        For i = 0 To dt.Rows.Count - 1
            With dt.Rows(i)
                If String.Concat(.Item("NewCode")) <> "" Then
                    NewCode = String.Concat(.Item("NewCode"))
                    dtP = ctlFDA.GET_DRUG_PHARMACY(NewCode)
                    If Not dtP Is Nothing Then
                        'lblthanm.Text = "ไม่พบเลข ขย.นี้ในฐานข้อมูล อย. กรุณาตรวจสอบ"
                        'Exit sub
                        If dtP.Rows.Count > 0 Then
                            dtP.DefaultView.Sort = "lcnno desc,lcnno desc"
                            Dim dtResult As DataTable = dtP.DefaultView.ToTable()

                            Try
                                phrno = checkField(dtResult, "phrno")
                                phrnm = checkField(dtResult, "phrnm")
                                pharmacy_name = checkField(dtResult, "pharmacy_name")

                                ctlL.PhamacyLicense_Update(NewCode, phrno, phrnm, pharmacy_name)

                                pnDanger.Visible = False
                                pnSuccess.Visible = True
                                lblSuccess.Text = "Update ชื่อผู้มีหน้าที่ปฏิบัติการ Success."
                            Catch ex As Exception
                                pnSuccess.Visible = False
                                pnDanger.Visible = True
                                lblDanger.Text = "Warning!! " & ex.Message
                            End Try
                        End If
                    End If
                End If
            End With
        Next

        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalSuccess(this,'Success','Update ชื่อผู้มีหน้าที่ปฏิบัติการ เรียบร้อย');", True)

    End Sub

    Private Sub cmdUpdateLicenseLast_Click(sender As Object, e As EventArgs) Handles cmdUpdateLicenseLast.Click
        Dim dtP As New DataTable
        Dim LastReq As Integer
        Dim LastUpdate As Integer
        dt = ctlL.Location_GetForUpdateFDA2
        If dt.Rows.Count = 0 Then
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningAlert(this,'Success','No data update.');", True)
            Exit Sub
        End If
        LastReq = dt.Rows(0)("LastRequest")
        For i = 0 To dt.Rows.Count - 1
            With dt.Rows(i)
                If String.Concat(.Item("LicenseNo1")) <> "" Then
                    'NewCode = ctlFDA.ConvertLicenseToNewCode(dt.Rows(i)("LicenseNo1"))
                    dtP = ctlFDA.GET_DRUG_LCN_INFORMATION(NewCode)
                    If Not dtP Is Nothing Then
                        'lblthanm.Text = "ไม่พบเลข ขย.นี้ในฐานข้อมูล อย. กรุณาตรวจสอบ"
                        'Exit sub
                        If dtP.Rows.Count > 0 Then
                            If checkField(dtP, "appdate") = "" Then
                                dtP.DefaultView.Sort = "lcnno desc"
                            Else
                                dtP.DefaultView.Sort = "appdate desc,lcnno desc"
                            End If

                            Dim dtResult As DataTable = dtP.DefaultView.ToTable()

                            pvncd = checkField(dtResult, "pvncd")
                            lcnno_noo = checkField(dtResult, "lcnno_noo")
                            lcnno_not_pvnabbr = checkField(dtResult, "lcnno_not_pvnabbr")
                            licen = checkField(dtResult, "licen")
                            licen_time = checkField(dtResult, "licen_time")
                            grannm_lo = checkField(dtResult, "grannm_lo")
                            thanm = checkField(dtResult, "thanm")
                            thaaddr = checkField(dtResult, "thaaddr")
                            tharoom = checkField(dtResult, "tharoom")
                            thafloor = checkField(dtResult, "thafloor")
                            thabuilding = checkField(dtResult, "thabuilding")
                            thasoi = checkField(dtResult, "thasoi")
                            tharoad = checkField(dtResult, "tharoad")
                            thamu = checkField(dtResult, "thamu")
                            thathmblnm = checkField(dtResult, "thathmblnm")
                            zipcode = checkField(dtResult, "zipcode")
                            tel = checkField(dtResult, "tel")
                            thanm_address = checkField(dtResult, "thanm_address")
                            thaamphrnm = checkField(dtResult, "thaamphrnm")
                            thachngwtnm = checkField(dtResult, "thachngwtnm")
                            cncnm = checkField(dtResult, "cncnm")
                            appdate = checkField(dtResult, "appdate")
                            expyear = checkField(dtResult, "expyear")
                            lmdfdate = checkField(dtResult, "lmdfdate")
                            Newcode_not = checkField(dtResult, "Newcode_not")
                            LICENSE_NO_SEARCH2 = checkField(dtResult, "LICENSE_NO_SEARCH2")

                            If lmdfdate <> "" Then
                                LastUpdate = checkFieldDtt(dtResult, "lmdfdate")
                                If LastUpdate >= LastReq Then
                                    Try
                                        ctlL.PhamacyLicense_Save(DBNull2Zero(dt.Rows(i)("UID")), dt.Rows(i)("LicenseNo1"), NewCode, pvncd, lcnno_noo, lcnno_not_pvnabbr, licen, licen_time, grannm_lo, thanm, thaaddr, tharoom, thafloor, thabuilding, thasoi, tharoad, thamu, thathmblnm, zipcode, tel, thanm_address, thaamphrnm, thachngwtnm, cncnm, appdate, expyear, lmdfdate, Newcode_not, LICENSE_NO_SEARCH2)

                                        pnDanger.Visible = False
                                        pnSuccess.Visible = True
                                        lblSuccess.Text = "Success."
                                    Catch ex As Exception
                                        pnSuccess.Visible = False
                                        pnDanger.Visible = True
                                        lblDanger.Text = "Warning!! " & ex.Message
                                    End Try
                                End If
                            Else
                                ctlL.PhamacyLicense_Save(DBNull2Zero(dt.Rows(i)("UID")), dt.Rows(i)("LicenseNo1"), NewCode, pvncd, lcnno_noo, lcnno_not_pvnabbr, licen, licen_time, grannm_lo, thanm, thaaddr, tharoom, thafloor, thabuilding, thasoi, tharoad, thamu, thathmblnm, zipcode, tel, thanm_address, thaamphrnm, thachngwtnm, cncnm, appdate, expyear, lmdfdate, Newcode_not, LICENSE_NO_SEARCH2)
                            End If
                        End If
                    End If
                End If
            End With
        Next

        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalSuccess(this,'Success','บันทึกเรียบร้อย');", True)
    End Sub

    Private Sub cmdCertName_Click(sender As Object, e As EventArgs) Handles cmdCertName.Click
        ctlL.auto_UpdatePharmacyName_Certificate()
        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalSuccess(this,'Success','บันทึกเรียบร้อย');", True)
    End Sub

    Private Sub cmdUpdateNewCode_Click(sender As Object, e As EventArgs) Handles cmdUpdateNewCode.Click
        Dim LicenseNo, NewCode, Code, ProvinceID As String
        Dim ctlM As New MasterController
        dt = ctlL.Location_GetNotNewCode
        If dt.Rows.Count > 0 Then
            For i = 0 To dt.Rows.Count - 1
                'NewCode = ctlFDA.ConvertLicenseToNewCode(String.Concat(dt.Rows(i)("LicenseNo")))
                'NewCode = ctlFDA.ConvertLicenseToNewCode(String.Concat(dt.Rows(i)("LicenseNo")))

                LicenseNo = String.Concat(dt.Rows(i)("LicenseNo"))
                NewCode = "U1Dขย1"
                ProvinceID = ctlM.Province_GetID(Left(LicenseNo, 2))

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
                Code = ProvinceID & Right(LicenseNo, 2) & LNO
                NewCode = NewCode & Code & "C"

                ctlL.Location_UpdateNewCode(DBNull2Zero(dt.Rows(i)("LocationUID")), NewCode, Code)
            Next
        End If

        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalSuccess(this,'Success','บันทึกเรียบร้อย');", True)

    End Sub

End Class

