using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SpecificNews : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user_id"] == null)
        {
            Button_MakeCommentary.Visible = false;
        }
        if (Session["user_id"] == null)
        {
            TextBox_Content.Visible = false;
        }
        if (!IsPostBack)
        {
            repeaterData();
        }
        if (!IsPostBack)
        {
            repeaterComments();
        }
    }

    private void repeaterData()
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;

        cmd.CommandText = "SELECT * FROM News WHERE news_id = @news_id";

        cmd.Parameters.AddWithValue("@news_id", Request.QueryString["news_id"].ToString());

        conn.Open();
        SqlDataReader reader = cmd.ExecuteReader();
        Repeater_ViewNews.DataSource = reader;
        Repeater_ViewNews.DataBind();
    }

    private void repeaterComments()
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;

        cmd.CommandText = "SELECT * FROM Coments INNER JOIN Users ON fk_users = user_id WHERE fk_news = @fk_news";

        cmd.Parameters.AddWithValue("@fk_news", Request.QueryString["news_id"].ToString());

        conn.Open();
        SqlDataReader reader = cmd.ExecuteReader();
        Repeater_Comments.DataSource = reader;
        Repeater_Comments.DataBind();
    }

    protected void Button_MakeCommentary_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;

        cmd.CommandText = @"INSERT INTO Coments (coment_text, fk_news, fk_users) VALUES (@text, @fk_news, @fk_users)";
        cmd.Parameters.AddWithValue("@text", TextBox_Content.Text);
        cmd.Parameters.AddWithValue("@fk_news", Request.QueryString["news_id"].ToString());
        cmd.Parameters.AddWithValue("@fk_users", Convert.ToInt32(Session["user_id"]));
        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();

        Response.Redirect(Request.RawUrl);
    }

    private void BuildBreadCrumbs()
    {
        // denne side er afhængig af at have en category_id i URL
        if (Request.QueryString["news_id"] == null)
        {
            // findes den ikke, sendes brugeren tilbage til forsiden
            Response.Redirect("Default.aspx");
        }
        else
        {
            // når der er en category_id i URL, tjekkes på om den er en INT
            int category_id;
            if (int.TryParse(Request.QueryString["category_id"], out category_id))
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = @"SELECT news_id, news_title FROM News WHERE news_id = @news_id";

                cmd.Parameters.Add("@news_id", SqlDbType.Int).Value = Request.QueryString["news_id"];
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    HyperLink_BreadCrumb_Category.NavigateUrl = "Default.aspx" + reader["news_id"];
                    HyperLink_BreadCrumb_Category.Text = reader["news_title"].ToString();
                }
                conn.Close();
            }
            else
            {
                // hvis det går galt med konverteringen, sendes brugeren tilbage til forsiden
                Response.Redirect("Default.aspx");
            }
        }
    }
}