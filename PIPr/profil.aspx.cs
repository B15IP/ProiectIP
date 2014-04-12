using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class profil : System.Web.UI.Page
{
    SqlConnection sqlConnection1 = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\CNSH\Documents\Visual Studio 2012\WebSites\PIPr\App_Data\PIP.mdf;Integrated Security=True");

    protected void Page_Load(object sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand();
        sqlConnection1.Open();
        cmd.Connection = sqlConnection1;

        cmd.CommandText = "select acont,nume,prenume,email,parola from utilizator where acont='" + Session["nume"].ToString() + "';";
        cmd.CommandType = CommandType.Text;

        using (SqlDataReader SRD = cmd.ExecuteReader())
        {
            while (SRD.Read())
            {
                Labelacont.Text = SRD.GetString(SRD.GetOrdinal("acont")).ToString();
                LabelNume.Text = SRD.GetString(SRD.GetOrdinal("nume")).ToString();
                LabelPrenume.Text = SRD.GetString(SRD.GetOrdinal("prenume")).ToString();
                LabelEmail.Text = SRD.GetString(SRD.GetOrdinal("email")).ToString();
            }
        }


        sqlConnection1.Close();
    }

    protected void ButtonNume_Click(object sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand();
        sqlConnection1.Open();
        if (TextBoxNume.Visible == true)
        {
            TextBoxNume.Visible = false;
            cmd.Connection = sqlConnection1;
            cmd.CommandText = "update utilizator set nume='" + TextBoxNume.Text + "' where acont='" + Session["nume"].ToString() + "';";
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            LabelNume.Text = TextBoxNume.Text;
        }
        else
        {
            TextBoxNume.Visible = true;
            TextBoxNume.Text = LabelNume.Text;

        }
        sqlConnection1.Close();
    }
    protected void ButtonPrenume_Click(object sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand();
        sqlConnection1.Open();
        if (TextBoxPrenume.Visible == true)
        {
            TextBoxPrenume.Visible = false;
            cmd.Connection = sqlConnection1;
            cmd.CommandText = "update utilizator set prenume='" + TextBoxPrenume.Text + "' where acont='" + Session["nume"].ToString() + "';";
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            LabelPrenume.Text = TextBoxPrenume.Text;
        }
        else
        {
            TextBoxPrenume.Visible = true;
            TextBoxPrenume.Text = LabelPrenume.Text;

        }
        sqlConnection1.Close();
    }
    protected void Buttonschimbaparola(object sender, EventArgs e)
    {
        if (Panelschimbaparola.Visible == false)
            Panelschimbaparola.Visible = true;
        else Panelschimbaparola.Visible = false;
    }
    protected void Buttonschimba_Click(object sender, EventArgs e)
    {
        Labelparolaeroare.Text = "";
        SqlCommand cmd = new SqlCommand();
        sqlConnection1.Open();
        cmd.Connection = sqlConnection1;

        cmd.CommandText = "select parola from utilizator where acont='" + Session["nume"].ToString() + "';";
        cmd.CommandType = CommandType.Text;

        if (TextBoxparola.Text != cmd.ExecuteScalar().ToString())
        {
            Labelparolaeroare.Text = "Parola veche incorecta!";
            return;
        }
        if (TextBoxparolan.Text != TextBoxparolan2.Text)
        {
            Labelparolaeroare.Text = "Eroare confirmare parola noua!";
            return;
        }

        cmd.CommandText = "update utilizator set parola='" + TextBoxparolan.Text + "' where acont='" + Session["nume"].ToString() + "';";
        cmd.CommandType = CommandType.Text;
        cmd.ExecuteNonQuery();
        Labelparolaeroare.Text = "Parola modificat cu succes!";

        sqlConnection1.Close();

    }
}