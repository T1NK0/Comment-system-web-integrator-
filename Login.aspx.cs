using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button_login_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;

        cmd.CommandText = @"SELECT * FROM Users WHERE @username = user_name AND @password = user_password";

        cmd.Parameters.AddWithValue("@username", TextBox_name.Text);
        cmd.Parameters.AddWithValue("@password", TextBox_password.Text);

        conn.Open();
         SqlDataReader reader = cmd.ExecuteReader();
         if (reader.Read())
         {
             Session["user_id"] = reader["user_id"];
         }
        conn.Close();
        Response.Redirect("Default.aspx");
    }
}