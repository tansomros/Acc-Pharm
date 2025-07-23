Imports System.Security.Cryptography
Imports System.Text


Public Class CryptographyEngine

    Public Function GetStringPassPhase() As String
        Return BaseClass.PassPhase.ToString()
    End Function


    Public Function EncryptString(ByVal ToEncrypt As String, ByVal useHasing As Boolean) As String

        Dim keyArray() As Byte
        Dim toEncryptArray() As Byte = UTF8Encoding.UTF8.GetBytes(ToEncrypt)

        Dim Key As String = GetStringPassPhase()

        If (useHasing) Then

            Dim hashmd5 As MD5CryptoServiceProvider = New MD5CryptoServiceProvider()

            keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(Key))

            hashmd5.Clear()


        Else

            keyArray = UTF8Encoding.UTF8.GetBytes(Key)
        End If

        Dim tDes As New TripleDESCryptoServiceProvider

        tDes.Key = keyArray
        tDes.Mode = CipherMode.ECB
        tDes.Padding = PaddingMode.PKCS7
        Dim cTransform As ICryptoTransform = tDes.CreateEncryptor()

        Dim resultArray() As Byte = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length)
        tDes.Clear()

        Return Convert.ToBase64String(resultArray, 0, resultArray.Length)

    End Function


    Public Function DecryptString(ByVal cypherString As String, ByVal useHasing As Boolean) As String

        Dim keyArray() As Byte

        Dim toDecryptArray() As Byte = Convert.FromBase64String(cypherString)


        Dim Key As String = GetStringPassPhase()

        If (useHasing) Then
            Dim hashmd As New MD5CryptoServiceProvider
            keyArray = hashmd.ComputeHash(UTF8Encoding.UTF8.GetBytes(Key))
            hashmd.Clear()
        Else
            keyArray = UTF8Encoding.UTF8.GetBytes(Key)
        End If

        Dim tDes As New TripleDESCryptoServiceProvider

        tDes.Key = keyArray
        tDes.Mode = CipherMode.ECB
        tDes.Padding = PaddingMode.PKCS7
        Dim cTransform As ICryptoTransform = tDes.CreateDecryptor()

        Try
            Dim resultArray() As Byte = cTransform.TransformFinalBlock(toDecryptArray, 0, toDecryptArray.Length)
            tDes.Clear()
            Return UTF8Encoding.UTF8.GetString(resultArray, 0, resultArray.Length)
        Catch ex As Exception
            Throw ex
        End Try

    End Function

End Class

