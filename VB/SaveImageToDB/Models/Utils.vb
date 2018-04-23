Imports System
Imports System.Data
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Text
Imports System.Data.OleDb
Imports System.Data.SqlClient

Public NotInheritable Class DBUtils

    Private Sub New()
    End Sub
    Private Shared AccessDBPath As String = "~/App_Data/Data.mdb"

    Public Shared Function SaveImageToDB(ByVal bytes() As Byte) As String
        Dim cmd As New OleDbCommand("INSERT INTO [Images] ([ID], [Data]) VALUES([@ID], @Data)")

        Dim id As Long = Date.Now.ToFileTime()
        cmd.Parameters.AddWithValue("@ID", id)
        cmd.Parameters.AddWithValue("@Data", bytes)

        ExecuteScalarByte(cmd)
        Return id.ToString()
    End Function

    Public Shared Function GetImageFromDB(ByVal id As String) As Byte()
        Dim cmd As New OleDbCommand(String.Format("SELECT Data FROM[Images] where id=?"))
        cmd.Parameters.Add(New OleDbParameter("id", id))
        Return DirectCast(ExecuteScalarByte(cmd), Byte())
    End Function

    ' utils
    Public Shared Function ExecuteScalarByte(ByVal cmd As OleDbCommand) As Object
        Dim conn As OleDbConnection = CreateOleDbConnection()
        cmd.Connection = conn
        Try
            conn.Open()
            Return cmd.ExecuteScalar()
        Catch e1 As Exception
            Return Nothing
        Finally
            If conn.State <> ConnectionState.Closed Then
                conn.Close()
            End If
        End Try
    End Function

    Public Shared Function CreateOleDbConnection() As OleDbConnection
        Return New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; data source=" & HttpContext.Current.Server.MapPath(AccessDBPath))
    End Function
End Class
