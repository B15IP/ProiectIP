using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class OrganizatoriEveniment : System.Web.UI.Page
{
    SqlConnection sqlConnection1 = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Domanitos\Downloads\PIPv8\PIPr\App_Data\PIP.mdf;Integrated Security=True");

    bool Proprietar = false;

    protected void Page_Load(object sender, EventArgs e)
    {
        VerificareProprietar(sender, e);
        if (Proprietar)
        {
            ButtonInvitaOrganizatori.Visible = true;

        }
    }
    private void VerificareProprietar(object sender, EventArgs e)
    {
        if (Session["nume"] != null)
        {
            int Id_curent = Convert.ToInt32(Session["Id"]);
            int Id_prop = 0;
            SqlCommand cmd = new SqlCommand();
            sqlConnection1.Open();
            cmd.Connection = sqlConnection1;

            cmd.CommandText = "select id_proprietar from evenimente where id=" + Convert.ToInt32(Session["IdEvenimentSelectat"]) + ";";
            cmd.CommandType = CommandType.Text;
            using (SqlDataReader SRD = cmd.ExecuteReader())
            {
                while (SRD.Read())
                {
                    Id_prop = SRD.GetInt32(SRD.GetOrdinal("id_proprietar"));
                }
            }
            sqlConnection1.Close();
            if (Id_prop == Id_curent)
                Proprietar = true;
        }
    }
    protected void ButtonInvitaOrganizatori_Click(object sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand();
        int utilizatorExista = 0, idUtilizatorInvitat = -1;
        if (UserNameOrganizatorInvitat.Text == "")
        {
            MesajEroare.Text = "Va rugam sa completati casuta text cu un username";
            return;
        }

        try // verificare ca exista acest username
        {
            sqlConnection1.Open();
            cmd.CommandText = "Select count(id) from utilizator where acont ='" + UserNameOrganizatorInvitat.Text + "';";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection1;

            utilizatorExista = Convert.ToInt32(cmd.ExecuteScalar());

        }
        catch (Exception ex)
        {

            MesajEroare.Text = ex.Message;
        }
        sqlConnection1.Close();

        if (utilizatorExista == 0)
        {
            MesajEroare.Text = "Utilizator nu exista";
            return;
        }


        try // selectarea id-ului celui invitat
        {
            sqlConnection1.Open();
            cmd.CommandText = "Select id from utilizator where acont ='" + UserNameOrganizatorInvitat.Text + "';";
            cmd.CommandType = CommandType.Text;
            using (SqlDataReader SRD = cmd.ExecuteReader())
            {
                while (SRD.Read())
                {
                    idUtilizatorInvitat = SRD.GetInt32(SRD.GetOrdinal("id"));
                }
            }
        }

        catch (Exception ex)
        {

            MesajEroare.Text = ex.Message;
        }
        sqlConnection1.Close();

        utilizatorExista = 0;
        try // verificare daca exista deja aceasta invitatie - desi e verificata de cheia primara
        {
            sqlConnection1.Open();
            cmd.CommandText = "Select count(id_organizator) from organizeaza where id_eveniment =" + Session["IdEvenimentSelectat"] + " and id_organizator = " + idUtilizatorInvitat;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection1;
            // am facut economie de variabile si am folosit tot utilizatorExista
            utilizatorExista = Convert.ToInt32(cmd.ExecuteScalar());

        }
        catch (Exception ex)
        {

            MesajEroare.Text = ex.Message;
        }
        sqlConnection1.Close();
        // verific si ca nu cumva sa-si trimita lui(proprietarul) invitatie
        if (utilizatorExista != 0 || idUtilizatorInvitat == (int)Session["id"])
        {
            MesajEroare.Text = "Nu puteti trimite invitatie acestei persoane";
            return;
        }

        try // inserarea in organizeaza cu aprobat luat default false
        {
            sqlConnection1.Open();
            cmd.CommandText = "Insert into organizeaza(id_eveniment,id_organizator) values( " + Session["IdEvenimentSelectat"] + ", " + idUtilizatorInvitat + ")";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection1;

            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {

            MesajEroare.Text = ex.Message;
        }
        sqlConnection1.Close();
        LabelInvitatieTrimisa.Text = "Invitatie trimisa cu succes ";
    }
}