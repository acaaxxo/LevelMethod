Imports System.IO
Imports System.Net
Imports System.Text

Public Class Class1
    Dim request As HttpWebRequest
    Dim response As HttpWebResponse = Nothing
    Dim reader As StreamReader
    Dim name As String
    Dim desc As String
    Dim id As Integer
    Dim data As StringBuilder
    Dim byteData() As Byte
    Dim postStream As Stream = Nothing

    Public Sub New(ByVal url As String)
        Try
            request = DirectCast(WebRequest.Create(url), HttpWebRequest)
        Finally
            If Not response Is Nothing Then response.Close()
        End Try
    End Sub

    Public Sub Create(ByVal name As String, desc As String)
        request.Method = "POST"
        request.ContentType = "application/x-www-form-urlencoded"
        'request.ContentType = "application/json"

        data = New StringBuilder()
        data.Append("nama=" + WebUtility.UrlEncode(name))
        data.Append("&deskripsi=" + WebUtility.UrlEncode(desc))

        'byteData = Encoding.UTF8.GetBytes(data.ToString())
        byteData = UTF8Encoding.UTF8.GetBytes(data.ToString())
        request.ContentLength = byteData.Length
        'MsgBox(byteData.Length)


        Try
            postStream = request.GetRequestStream()
            postStream.Write(byteData, 0, byteData.Length)
        Finally
            If Not postStream Is Nothing Then postStream.Close()
        End Try

        Try
            response = DirectCast(request.GetResponse(), HttpWebResponse)
            reader = New StreamReader(response.GetResponseStream())
            Console.WriteLine(reader.ReadToEnd())
        Finally
            If Not response Is Nothing Then response.Close()
        End Try

        Console.ReadLine()

    End Sub

    Public Sub update(ByVal id As Integer, name As String, desc As String)
        request.Method = "POST"
        request.ContentType = "application/x-www-form-urlencoded"
        data = New StringBuilder()
        data.Append("id=" + WebUtility.UrlEncode(id))
        data.Append("&nama=" + WebUtility.UrlEncode(name))
        data.Append("&deskripsi=" + WebUtility.UrlEncode(desc))
        byteData = UTF8Encoding.UTF8.GetBytes(data.ToString())
        request.ContentLength = byteData.Length

        Try
            postStream = request.GetRequestStream()
            postStream.Write(byteData, 0, byteData.Length)
        Finally
            If Not postStream Is Nothing Then postStream.Close()
        End Try

        Try
            response = DirectCast(request.GetResponse(), HttpWebResponse)
            reader = New StreamReader(response.GetResponseStream())
            Console.WriteLine(reader.ReadToEnd())
        Finally
            If Not response Is Nothing Then response.Close()
        End Try

        Console.ReadLine()

    End Sub
    Public Sub delete(ByVal id As Integer)
        request.Method = "POST"
        request.ContentType = "application/x-www-form-urlencoded"
        'request.ContentType = "application/json"

        data = New StringBuilder()
        data.Append("id=" + WebUtility.UrlEncode(id))


        'byteData = Encoding.UTF8.GetBytes(data.ToString())
        byteData = UTF8Encoding.UTF8.GetBytes(data.ToString())
        request.ContentLength = byteData.Length
        'MsgBox(byteData.Length)


        Try
            postStream = request.GetRequestStream()
            postStream.Write(byteData, 0, byteData.Length)
        Finally
            If Not postStream Is Nothing Then postStream.Close()
        End Try

        Try
            response = DirectCast(request.GetResponse(), HttpWebResponse)
            reader = New StreamReader(response.GetResponseStream())
            Console.WriteLine(reader.ReadToEnd())
        Finally
            If Not response Is Nothing Then response.Close()
        End Try

        Console.ReadLine()

    End Sub
End Class
