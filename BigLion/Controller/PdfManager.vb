Imports System
Imports System.Collections.Generic
Imports System.Web
Imports System.Web.UI.Control
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports iTextSharp.text.html
Imports iTextSharp.text.html.simpleparser
Imports System.IO

Public Class PdfManager
    Public Shared Sub ExportFromGridView(ByVal gvControl As GridView, fname As String)
        Dim bf As BaseFont = BaseFont.CreateFont(HttpContext.Current.Server.MapPath("~/Fonts/THSarabunNew.ttf"), BaseFont.IDENTITY_H, BaseFont.EMBEDDED)
        Dim pdfDoc As Document = New Document(PageSize.A4.Rotate(), 30, 30, 30, 30)

        Try
            PdfWriter.GetInstance(pdfDoc, System.Web.HttpContext.Current.Response.OutputStream)
            pdfDoc.Open()
            Dim fntH As Font = New Font(bf, 12, Font.BOLD)
            Dim fnt As Font = New Font(bf, 12)

            Dim PdfTable As PdfPTable = New PdfPTable(gvControl.Columns.Count)
            Dim PdfPCell As PdfPCell = Nothing

            For column As Integer = 0 To gvControl.Columns.Count - 1
                PdfPCell = New PdfPCell(New Phrase(New Chunk(gvControl.Columns(column).HeaderText.ToString(), fntH)))
                'PdfPCell.HorizontalAlignment = HorizontalAlign.Center
                PdfTable.AddCell(PdfPCell)
            Next

            For row As Integer = 0 To gvControl.Rows.Count - 1
                For col As Integer = 0 To gvControl.Columns.Count - 1
                    PdfPCell = New PdfPCell(New Phrase(New Chunk(gvControl.Rows(row).Cells(col).Text, fnt)))
                    'PdfPCell.HorizontalAlignment = HorizontalAlign.Center
                    PdfTable.AddCell(PdfPCell)
                    'PdfPCell = New PdfPCell(New Phrase(New Chunk(gvControl.Rows(row).Cells(2).Text, fnt)))
                    'PdfTable.AddCell(PdfPCell)
                    'PdfPCell = New PdfPCell(New Phrase(New Chunk(gvControl.Rows(row).Cells(3).Text, fnt)))
                    'PdfTable.AddCell(PdfPCell)
                    'PdfPCell = New PdfPCell(New Phrase(New Chunk(gvControl.Rows(row).Cells(4).Text, fnt)))
                    'PdfTable.AddCell(PdfPCell)
                    'PdfPCell = New PdfPCell(New Phrase(New Chunk(gvControl.Rows(row).Cells(5).Text, fnt)))
                    'PdfTable.AddCell(PdfPCell)
                    'PdfPCell = New PdfPCell(New Phrase(New Chunk(gvControl.Rows(row).Cells(6).Text, fnt)))
                    'PdfTable.AddCell(PdfPCell)
                Next

            Next

            'Dim strFileName As String = HttpContext.Current.Server.MapPath(fname & ".pdf")

            pdfDoc.Add(PdfTable)
            pdfDoc.Close()
            HttpContext.Current.Response.ContentType = "application/pdf"
            HttpContext.Current.Response.AddHeader("content-disposition", "inline; filename=" & DateTime.Now.ToString("yyyyMMdd") & ".pdf")
            System.Web.HttpContext.Current.Response.Write(pdfDoc)
            HttpContext.Current.Response.Flush()
            HttpContext.Current.Response.End()

        Catch ex As Exception
            HttpContext.Current.Response.Write(ex.ToString())
        End Try
    End Sub

    Public Shared Sub ExportFromHTML(ByVal gvControl As GridView)
        Dim bf As BaseFont = BaseFont.CreateFont(HttpContext.Current.Server.MapPath("~/Fonts/THSarabunNew.ttf"), BaseFont.IDENTITY_H, BaseFont.EMBEDDED)
        Dim pdfDoc As Document = New Document(PageSize.A4.Rotate(), 10, 10, 10, 10)

        Try
            PdfWriter.GetInstance(pdfDoc, System.Web.HttpContext.Current.Response.OutputStream)
            pdfDoc.Open()
            Dim fnt As Font = New Font(bf, 11)
            Dim fnt2 As Font = New Font(bf, 11, Font.BOLD, Color.RED)


            Dim PdfTable As PdfPTable = New PdfPTable(gvControl.Columns.Count)
            Dim PdfPCell As PdfPCell = Nothing

            'For column As Integer = 0 To gvControl.Columns.Count - 1
            '    PdfPCell = New PdfPCell(New Phrase(New Chunk(gvControl.Columns(column).HeaderText.ToString(), fnt)))
            '    PdfTable.AddCell(PdfPCell)
            'Next

            For row As Integer = 0 To gvControl.Rows.Count - 1
                For col As Integer = 0 To gvControl.Columns.Count - 1
                    PdfPCell = New PdfPCell(New Phrase(New Chunk(gvControl.Rows(row).Cells(col).Text, fnt)))
                    PdfTable.AddCell(PdfPCell)
                    'PdfPCell = New PdfPCell(New Phrase(New Chunk(gvControl.Rows(row).Cells(2).Text, fnt)))
                    'PdfTable.AddCell(PdfPCell)
                    'PdfPCell = New PdfPCell(New Phrase(New Chunk(gvControl.Rows(row).Cells(3).Text, fnt)))
                    'PdfTable.AddCell(PdfPCell)
                    'PdfPCell = New PdfPCell(New Phrase(New Chunk(gvControl.Rows(row).Cells(4).Text, fnt)))
                    'PdfTable.AddCell(PdfPCell)
                    'PdfPCell = New PdfPCell(New Phrase(New Chunk(gvControl.Rows(row).Cells(5).Text, fnt)))
                    'PdfTable.AddCell(PdfPCell)
                    'PdfPCell = New PdfPCell(New Phrase(New Chunk(gvControl.Rows(row).Cells(6).Text, fnt)))
                    'PdfTable.AddCell(PdfPCell)
                Next

            Next

            pdfDoc.Add(PdfTable)
            pdfDoc.Close()
            HttpContext.Current.Response.ContentType = "application/pdf"
            HttpContext.Current.Response.AddHeader("content-disposition", "attachment; filename=" & DateTime.Now.ToString("yyyyMMdd") & ".pdf")
            System.Web.HttpContext.Current.Response.Write(pdfDoc)
            HttpContext.Current.Response.Flush()
            HttpContext.Current.Response.End()

        Catch ex As Exception
            HttpContext.Current.Response.Write(ex.ToString())
        End Try
    End Sub

    Public Shared Sub ShowPdf(ByVal strFileName As String)

        HttpContext.Current.Response.ClearContent()
        HttpContext.Current.Response.ClearHeaders()
        HttpContext.Current.Response.AddHeader("Content-Disposition", "inline;filename=" & strFileName)
        HttpContext.Current.Response.ContentType = "application/pdf"
        HttpContext.Current.Response.WriteFile(strFileName)
        HttpContext.Current.Response.Flush()
        HttpContext.Current.Response.Clear()
    End Sub
End Class
