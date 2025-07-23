Imports BigLion
Public Class ChangePassword
    Inherits System.Web.UI.Page

    Dim acc As New UserController
    Dim enc As New CryptographyEngine

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            pnResult.Visible = False
            pnForm.Visible = True
        End If

    End Sub

    Protected Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        If enc.DecryptString(Request.Cookies("Password").Value, True) <> txtOld.Text Then
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ตรวจสอบ','รหัสผ่านเดิมท่านไม่ถูกต้อง กรุณาลองใหม่อีกครั้ง');", True)
            Exit Sub
        End If

        If txtNew.Text = "" Or txtRe.Text = "" Then
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ตรวจสอบ','กรุณาระบุรหัสผ่านใหม่ก่อน กรุณาลองใหม่อีกครั้ง');", True)
            Exit Sub
        End If
        If txtNew.Text <> txtRe.Text Then
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType(), "MessageAlert", "openModalWarningInfo(this,'ตรวจสอบ','ท่านยืนยันรหัสผ่านใหม่ไม่ตรงกัน กรุณาลองใหม่อีกครั้ง');", True)
            Exit Sub
        End If

        acc.User_ChangePassword(Request.Cookies("UserID").Value, enc.EncryptString(txtNew.Text, True))

        acc.User_GenLogfile(Request.Cookies("UserID").Value, ACTTYPE_UPD, "Users", "Change password", "", Environment.MachineName, GetIPAddress())
        ' DisplayMessage(Me.Page, "ระบบเปลี่ยนรหัสผ่านให้ท่านใหม่เรียบร้อยแล้ว")

        pnForm.Visible = False
        pnResult.Visible = True
    End Sub
End Class