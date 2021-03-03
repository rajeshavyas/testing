Imports System.IO
Imports System.Net

Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click




        Dim SiteName As String = "ftp://suppliers.yadavjewelry.com:21/"
        Dim FtpUserId As String = "agDiamonds"
        Dim FtpPassword As String = "hAFjpTteL7gtYsKQ"
        Dim FtpFileName As String = "texting.text"
        Dim LocalFileName As String = "D:\tmp\Stock.XLs"
        Dim FtpUploadFileName As String = "texting.text"

        Dim SpName As String



        'Create a FTP web request
        Dim ftpwebrequest As FtpWebRequest = DirectCast(WebRequest.Create(SiteName & FtpFileName), FtpWebRequest)
        'Set properties
        With ftpwebrequest
            .Credentials = New NetworkCredential(FtpUserId, FtpPassword)
            'set the method to upload
            .Method = WebRequestMethods.Ftp.UploadFile
            'upload timeout to 100 seconds
            .Timeout = "100000"
            'data transfer type
            .UseBinary = True
            'size of the file to upload
            .ContentLength = LocalFileName.Length
        End With

        Dim ufile() As Byte = File.ReadAllBytes(LocalFileName)

        Dim ftpwebstreamrequest As Stream = ftpwebrequest.GetRequestStream()
        'start streaming upload
        ftpwebstreamrequest.Write(ufile, 0, ufile.Length)
        'close and dispose file and request stream after the upload
        ftpwebstreamrequest.Close()
        ftpwebstreamrequest.Dispose()

    End Sub
End Class
