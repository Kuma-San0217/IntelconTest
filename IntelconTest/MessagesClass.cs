using System;
using System.Data;
using System.IO;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.Services;
using System.Configuration;
using System.Text;

namespace IntelconTest
{
    public class MessagesClass
    {
        [WebMethod]
        public static string GetMessages()
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("GetMessages", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            StringBuilder sb = new StringBuilder();
            sb.Append("<h1>Messages List</h1>");
            sb.Append("<table border=1>");
            sb.Append("<tr>");
            foreach (DataColumn dc in dt.Columns)
            {
                sb.Append("<th>");
                sb.Append(dc.ColumnName.ToUpper());
                sb.Append("</th>");
            }
            sb.Append("</tr>");

            foreach (DataRow dr in dt.Rows)
            {
                sb.Append("<tr>");
                foreach(DataColumn dc in dt.Columns)
                {
                    sb.Append("<th>");
                    sb.Append(dr[dc.ColumnName].ToString());
                    sb.Append("</th>");
                }
                sb.Append("</tr>");
            }
            return sb.ToString();
        }
        [WebMethod]
        public static void AddMessage(int userID, string messageText)
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();

            SqlCommand cmd = new SqlCommand("AddMessage", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@UserID", userID));
            cmd.Parameters.Add(new SqlParameter("@MessageText", messageText));
            cmd.ExecuteReader();

            sqlConnection.Close();
        }
    }
}