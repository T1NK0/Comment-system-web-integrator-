using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CreateUser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button_Opret_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;

        cmd.CommandText = @"INSERT INTO Users (user_email, user_name, user_password, user_picture) VALUES (@email, @name, @password, @picture)";
        cmd.Parameters.AddWithValue("@email", TextBox_Email.Text);
        cmd.Parameters.AddWithValue("@name", TextBox_Name.Text);
        cmd.Parameters.AddWithValue("@password", TextBox_Password.Text);

        #region image1
        string bill_sti = "intetbillede.jpg";
        if (FileUpload_ProfilePicture.HasFile)
        {
            //NewGuid danner uniq navn for billeder
            bill_sti = Guid.NewGuid() + Path.GetExtension(FileUpload_ProfilePicture.FileName);
            // Opret
            String UploadeMappe = Server.MapPath("~/images/Original/");
            String CroppedMappe = Server.MapPath("~/images/Resized/");
            String Filnavn = DateTime.Now.ToFileTime() + FileUpload_ProfilePicture.FileName;
            bill_sti = Filnavn;

            //Gem det orginale Billede
            FileUpload_ProfilePicture.SaveAs(UploadeMappe + Filnavn);

            // Definer hvordan
            ImageResizer.ResizeSettings BilledeSkalering = new ImageResizer.ResizeSettings();
            //Lav nogle nye skalerings instillinger
            BilledeSkalering = new ImageResizer.ResizeSettings();
            BilledeSkalering.Width = 50;
            BilledeSkalering.Height = 50;
            BilledeSkalering.Mode = ImageResizer.FitMode.Crop;

            //Udfør selve skaleringen
            ImageResizer.ImageBuilder.Current.Build(UploadeMappe + Filnavn, CroppedMappe + Filnavn, BilledeSkalering);

        }
        // Tildel parameter-værdierne, fra input felterne.
        cmd.Parameters.AddWithValue("@picture", bill_sti);
        #endregion

        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();

        Response.Redirect("Login.aspx");
    }
}