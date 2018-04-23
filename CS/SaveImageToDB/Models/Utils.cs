using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data.OleDb;
using System.Data.SqlClient;

public static class DBUtils {
    static string AccessDBPath = "~/App_Data/Data.mdb";

    public static string SaveImageToDB(byte[] bytes) {
        OleDbCommand cmd = new OleDbCommand("INSERT INTO [Images] ([ID], [Data]) VALUES([@ID], @Data)");

        long id = DateTime.Now.ToFileTime();
        cmd.Parameters.AddWithValue("@ID", id);
        cmd.Parameters.AddWithValue("@Data", bytes);

        ExecuteScalarByte(cmd);
        return id.ToString();
    }

    public static byte[] GetImageFromDB(string id) {
        OleDbCommand cmd = new OleDbCommand(string.Format("SELECT Data FROM[Images] where id=?"));
        cmd.Parameters.Add(new OleDbParameter("id", id));
        return (byte[])ExecuteScalarByte(cmd);
    }

    // utils
    public static object ExecuteScalarByte(OleDbCommand cmd) {
        OleDbConnection conn = CreateOleDbConnection();
        cmd.Connection = conn;
        try {
            conn.Open();
            return cmd.ExecuteScalar();
        }
        catch (Exception) {
            return null;
        }
        finally {
            if (conn.State != ConnectionState.Closed)
                conn.Close();
        }
    }

    public static OleDbConnection CreateOleDbConnection() {
        return new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; data source=" +
                                   HttpContext.Current.Server.MapPath(AccessDBPath));
    }
}
