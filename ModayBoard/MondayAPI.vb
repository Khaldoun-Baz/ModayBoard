Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.IO
Imports System.Net
Public Class MondayAPI
    Private Const MondayApiKey As String = "eyJhbGciOiJIUzI1NiJ9.eyJ0aWQiOjEwNjg1NDg1MiwidWlkIjo4OTkzMDAsImlhZCI6IjIwMjEtMDQtMTdUMDk6NTU6MjMuMDAwWiIsInBlciI6Im1lOndyaXRlIiwiYWN0aWQiOjM2MDk2MiwicmduIjoidXNlMSJ9.hjXCoOo-8_upac84120JdfmrBfnjns0aG769F0Glr7c"
    Private Const MondayApiUrl As String = "https://api.monday.com/v2/"


	Public Async Function QueryMondayApiV2(ByVal Query As String) As Task(Of String)
		Dim dataBytes As Byte() = System.Text.Encoding.UTF8.GetBytes(Query)
		Dim request As HttpWebRequest = HttpWebRequest.Create(MondayApiUrl)
		request.ContentType = "application/json"
		request.Method = "POST"
		request.Headers.Add("Authorization", MondayApiKey)
		Using requestBody As Stream = request.GetRequestStream
			Await requestBody.WriteAsync(dataBytes, 0, dataBytes.Length)
		End Using

		Using response As HttpWebResponse = Await request.GetResponseAsync
			Using stream As Stream = response.GetResponseStream
				Using reader As StreamReader = New StreamReader(stream)
					Return Await reader.ReadToEndAsync()
				End Using
			End Using
		End Using


	End Function

End Class
