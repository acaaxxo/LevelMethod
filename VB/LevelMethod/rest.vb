Imports System.IO
Imports System.Net

Public Class rest
    Dim request As HttpWebRequest
    Dim response As HttpWebResponse = Nothing
    Dim reader As StreamReader

    Public Sub New(ByVal url As String)
        Try
            request = DirectCast(WebRequest.Create(url), HttpWebRequest)
        Finally
            If Not response Is Nothing Then response.Close()
        End Try
    End Sub
    Public Sub List(ByVal type As String)
        request.Method = "GET"
        request.ContentType = type
        response = DirectCast(request.GetResponse(), HttpWebResponse)

        reader = New StreamReader(response.GetResponseStream)

        Console.WriteLine(reader.ReadToEnd())
        Console.ReadLine()

    End Sub

End Class
