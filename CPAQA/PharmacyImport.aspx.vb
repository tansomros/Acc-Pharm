Imports System.IO
Imports System.Data.OleDb
Imports System.Data
Imports BigLion
Imports System.Drawing

Public Class PharmacyImport
    Inherits System.Web.UI.Page
    Dim dt As New DataTable
    Dim ctlM As New MasterController
    Dim ctlE As New LocationController
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            lblResult.Visible = False
            lblAlert.Visible = False
        End If
    End Sub
    Private Function VerifyData(ByVal dtImp As DataTable) As Boolean
        Dim sError As Boolean = False

        Try
            If dtImp.Rows.Count > 0 Then

                dtImp.Columns.Add("ProvinceID")
                dtImp.Columns.Add("Error")

                For Each row As DataRow In dtImp.Rows

                    If Not Equals(row(1).ToString(), "") Then
                        row("ProvinceID") = ctlM.Province_GetIDByName(row(8).ToString())

                        If Equals(row("ProvinceID").ToString(), "00") Then
                            row("Error") = row("Error") & "[ไม่พบจังหวัด]"
                            sError = True
                        End If

                        If IsNumeric(Left(row(1).ToString(), 2)) Then
                            row("Error") = row("Error") & "[เลข ขย.ไม่ถูก]"
                            sError = True
                        End If
                        If Mid(row(1).ToString(), 3, 1) <> "." Then
                            row("Error") = row("Error") & "[เลข ขย.ไม่ถูก]"
                            sError = True
                        End If

                        If ctlE.Location_CheckDuplicate(row(1).ToString()) Then
                            row("Error") = row("Error") & "[เลข ขย.ซ้ำ]"
                            'sError = True ' อนุญาตให้ผ่าน โดยการอัพเดทแค่ IsPPHealth=Y
                        End If
                    End If

                    row.AcceptChanges()
                Next

                grdData.DataSource = dtImp
                grdData.DataBind()

                For i = 0 To grdData.Rows.Count - 1
                    grdData.Rows(i).Cells(16).ForeColor = Color.Red
                Next

                If sError = True Then
                    Return False
                Else
                    Return True
                End If
            Else
                Return False
            End If
        Catch ex As Exception
            Console.WriteLine(ex.Message)
            Return False
        End Try
    End Function

    Private Sub cmdImport_Click(sender As Object, e As EventArgs) Handles cmdImport.Click
        'If (StrNull2Zero(lblRemain.Text) <= 0) Then
        '    ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningAlert(this,'ผลการตรวจสอบ','บริษัทท่านได้เพิ่ม User ครบตามแพคเก็จแล้ว ไม่สามารถเพิ่มได้อีก');", True)
        'End If
        If (Not FileUploadFile.HasFile) Then
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningAlert(this,'ผลการตรวจสอบ','กรุณาเลือกไฟล์ Excel ก่อน');", True)
            Exit Sub
        End If
        System.Threading.Thread.Sleep(3000)
        UpdateProgress1.Visible = True

        Dim connectionString As String = ""
        Try

            lblResult.Visible = False

            Dim fileName As String = FileUploadFile.FileName
            Dim fileExtension As String = Path.GetExtension(FileUploadFile.PostedFile.FileName)
            Dim fileLocation As String = Server.MapPath("~/" + tmpUpload + "/" + fileName)

            Dim objfile As FileInfo = New FileInfo(fileLocation)
            If objfile.Exists Then
                objfile.Delete()
            End If

            FileUploadFile.SaveAs(Server.MapPath("~/" + tmpUpload + "/" + fileName))


            'Check whether file extension is xls or xslx

            If fileExtension = ".xls" Then
                connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & fileLocation & ";Extended Properties=""Excel 8.0;HDR=Yes;IMEX=2"""
            ElseIf fileExtension = ".xlsx" Then
                If (Not FileUploadFile.HasFile) Then
                    ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningAlert(this,'ผลการตรวจสอบ','กรุณาเลือกไฟล์ Excel เวอร์ชั่น .xls เท่านั้น');", True)
                    Exit Sub
                End If
                lblAlert.Text = "ตรวจสอบเวอร์ชั่นไฟล์ Excel สามารถใช้ได้เฉพาะ .xls เท่านั้น"
                lblAlert.Visible = True
                Exit Sub
                'connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & fileLocation & ";Extended Properties=""Excel 12.0;HDR=Yes;IMEX=2"""
            End If

            Dim con As New OleDbConnection(connectionString)
            Dim cmd As New OleDbCommand()
            cmd.CommandType = System.Data.CommandType.Text
            cmd.Connection = con
            Dim dAdapter As New OleDbDataAdapter(cmd)
            Dim dtExcelRecords As New DataTable()
            con.Open()
            Dim dtExcelSheetName As DataTable = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)
            Dim getExcelSheetName As String = dtExcelSheetName.Rows(0)("Table_Name").ToString()
            cmd.CommandText = "SELECT * FROM [" & getExcelSheetName & "]"
            dAdapter.SelectCommand = cmd
            dAdapter.Fill(dtExcelRecords)
            con.Close()
            Dim strCode As String = ""
            Dim k As Integer = 0
            'Dim sD, sM, sY As String

            If VerifyData(dtExcelRecords) = True Then
                For i = 0 To dtExcelRecords.Rows.Count - 1
                    'sD = ""
                    'sM = ""
                    'sY = ""

                    With dtExcelRecords.Rows(i)
                        If .Item(1).ToString <> "" Then
                            If ctlE.Location_CheckDuplicate(String.Concat(.Item(1))) Then

                                ctlE.Location_UpdateForPPH(String.Concat(.Item(1)))
                                strCode = strCode & String.Concat(.Item(1)) & ","
                            Else
                                'sD = Left(String.Concat(.Item(7)), 2)
                                'sM = Mid(String.Concat(.Item(7)), 4, 2)
                                'sY = Right(String.Concat(.Item(7)), 4)

                                ctlE.Location_SaveByImport(String.Concat(.Item(1)), String.Concat(.Item(2)), String.Concat(.Item(3)), String.Concat(.Item(4)), String.Concat(.Item(5)), String.Concat(.Item(6)), String.Concat(.Item(7)), String.Concat(.Item(15)), String.Concat(.Item(9)), String.Concat(.Item(10)), String.Concat(.Item(11)), DBNull2Zero(.Item(12)), String.Concat(.Item(13)), String.Concat(.Item(14)), Request.Cookies("userid").Value)
                                k = k + 1
                            End If
                        End If
                    End With
                Next
                'grdData.DataSource = dtExcelRecords
                'grdData.DataBind()

                Dim ctlU As New UserController
                ctlU.User_GenLogfile(Request.Cookies("UserID").Value, ACTTYPE_ADD, "Location", "import ร้านยา สสจ. : " & k & " ร้าน", "จากไฟล์ excel", Environment.MachineName, GetIPAddress())

                lblResult.Text = "ข้อมูลทั้งหมด " & k & " รายการ ถูก import เรียบร้อย" & IIf(strCode <> "", vbCrLf & " เลขที่ ขย. " & strCode & " ไม่สามารถเพิ่มได้เนื่องจากมีในฐานข้อมูลแล้ว ", "")
                lblResult.Visible = True
                lblAlert.Visible = False
                dtExcelRecords = Nothing

                If objfile.Exists Then
                    objfile.Delete()
                End If
                lblAlert.Visible = False
            Else
                lblAlert.Text = "Error! กรุณาตรวจสอบไฟล์ Excel แล้วลองใหม่อีกครั้ง"
                lblAlert.Visible = True
            End If
            UpdateProgress1.Visible = False
        Catch ex As Exception
            lblAlert.Text = "Error : " & ex.Message
            lblAlert.Visible = True
        End Try
    End Sub

    Private Sub grdData_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles grdData.RowDataBound
        If e.Row.RowType = ListItemType.AlternatingItem Or e.Row.RowType = ListItemType.Item Then
            If Len(e.Row.Cells(12).Text.Trim()) > 0 Then  'And e.Row.Cells(12).Text <> "&nbsp;"
                e.Row.BackColor = System.Drawing.Color.LightPink
            End If
        End If
    End Sub
End Class