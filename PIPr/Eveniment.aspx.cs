using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Eveniment : System.Web.UI.Page
{
    SqlConnection sqlConnection1 = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Domanitos\Downloads\PIPv8\PIPr\App_Data\PIP.mdf;Integrated Security=True");

    bool Proprietar = false;

    protected void Page_Load(object sender, EventArgs e)
    {
        MesajRaspuns.Text = "";
        numeEveniment.Visible = false;
        descriereEveniment.Visible = false;
        ziuaEveniment.Visible = false;
        lista_luni.Visible = false;
        anEveniment.Visible = false;
        etichetaEveniment.Visible = false;
        orasEveniment.Visible = false;
        judetEveniment.Visible = false;
        taraEveniment.Visible = false;
        ButtonEditeazaNume.Visible = false;
        ButtonEditeazaEtichete.Visible = false;
        ButtonEditeazaDescriere.Visible = false;
        ButtonEditeazaData.Visible = false;
        ButtonEditeazaOras.Visible = false;
        ButtonEditeazaJudet.Visible = false;
        ButtonEditeazaTara.Visible = false;

        ButtonSubmitNume.Visible = false;
        ButtonSubmitEtichete.Visible = false;
        ButtonSubmitDescriere.Visible = false;
        ButtonSubmitData.Visible = false;
        ButtonSubmitOras.Visible = false;
        ButtonSubmitJudet.Visible = false;
        ButtonSubmitTara.Visible = false;
        VerificareProprietar(sender, e);
        if (Proprietar)
        {
            ButtonEditeazaNume.Visible = true;
            ButtonEditeazaEtichete.Visible = true;
            ButtonEditeazaDescriere.Visible = true;
            ButtonEditeazaData.Visible = true;
            ButtonEditeazaOras.Visible = true;
            ButtonEditeazaJudet.Visible = true;
            ButtonEditeazaTara.Visible = true;
        }
        UmplereInformatii(sender, e);
    }

    protected void UmplereInformatii(object sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = sqlConnection1;
        sqlConnection1.Open();
        cmd.CommandText = "select nume+' '+prenume from utilizator where id=(select id_proprietar from evenimente where id=" + Convert.ToInt32(Session["IdEvenimentSelectat"]) + ");";
        cmd.CommandType = CommandType.Text;
        proprietarLabel.Text = cmd.ExecuteScalar().ToString();
        cmd.CommandText = "select * from evenimente where id=" + Convert.ToInt32(Session["IdEvenimentSelectat"]) + ";";
        cmd.CommandType = CommandType.Text;

        using (SqlDataReader SRD = cmd.ExecuteReader())
        {
            while (SRD.Read())
            {
                numeEvenimentLabel.Text = SRD.GetString(SRD.GetOrdinal("nume"));

                if (Convert.IsDBNull(SRD["data_inceperii"]))
                {
                    ziuaEvenimentLabel.Text = "";
                    anEvenimentLabel.Text = "";
                    lunaEvenimentLabel.Text = "";
                }
                else
                {
                    ziuaEvenimentLabel.Text = (SRD.GetDateTime(SRD.GetOrdinal("data_inceperii")).Day).ToString();
                    anEvenimentLabel.Text = (SRD.GetDateTime(SRD.GetOrdinal("data_inceperii")).Year).ToString();
                    lunaEvenimentLabel.Text = (SRD.GetDateTime(SRD.GetOrdinal("data_inceperii")).Month).ToString();
                }

                etichetaEvenimentLabel.Text = SRD.GetString(SRD.GetOrdinal("etichete"));

                if (Convert.IsDBNull(SRD["descriere"]))
                {
                    descriereEvenimentLabel.Text = "Nu este stabilita.";
                }
                else
                {
                    descriereEvenimentLabel.Text = SRD.GetString(SRD.GetOrdinal("descriere"));
                }

                if (Convert.IsDBNull(SRD["oras"]))
                {
                    orasEvenimentLabel.Text = "Nu este stabilit.";
                }
                else
                {
                    orasEvenimentLabel.Text = SRD.GetString(SRD.GetOrdinal("oras"));
                }

                if (Convert.IsDBNull(SRD["judet"]))
                {
                    judetEvenimentLabel.Text = "Nu este stabilit.";
                }
                else
                {
                    judetEvenimentLabel.Text = SRD.GetString(SRD.GetOrdinal("judet"));
                }

                if (Convert.IsDBNull(SRD["tara"]))
                {
                    taraEvenimentLabel.Text = "Nu este stabilit.";
                }
                else
                {
                    taraEvenimentLabel.Text = SRD.GetString(SRD.GetOrdinal("tara"));
                }
            }
        }

        sqlConnection1.Close();
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

    protected void ButtonEditeazaNume_Click(object Sender, EventArgs e)
    {
        numeEveniment.Visible = true;
        ButtonSubmitNume.Visible = true;
        ButtonEditeazaNume.Visible = false;
        numeEveniment.Text = numeEvenimentLabel.Text;
    }

    protected void ButtonEditeazaData_Click(object Sender, EventArgs e)
    {
        ziuaEveniment.Visible = true;
        lista_luni.Visible = true;
        anEveniment.Visible = true;
        ButtonSubmitData.Visible = true;
        ButtonEditeazaData.Visible = false;
        ziuaEveniment.Text = ziuaEvenimentLabel.Text;
        anEveniment.Text = anEvenimentLabel.Text;
    }

    protected void ButtonEditeazaDescriere_Click(object Sender, EventArgs e)
    {
        descriereEveniment.Visible = true;
        ButtonSubmitDescriere.Visible = true;
        ButtonEditeazaDescriere.Visible = false;
        descriereEveniment.Text = descriereEvenimentLabel.Text;
    }

    protected void ButtonEditeazaEtichete_Click(object Sender, EventArgs e)
    {
        etichetaEveniment.Visible = true;
        ButtonSubmitEtichete.Visible = true;
        ButtonEditeazaEtichete.Visible = false;
        etichetaEveniment.Text = etichetaEvenimentLabel.Text;
    }

    protected void ButtonEditeazaOras_Click(object Sender, EventArgs e)
    {
        orasEveniment.Visible = true;
        ButtonSubmitOras.Visible = true;
        ButtonEditeazaOras.Visible = false;
        orasEveniment.Text = orasEvenimentLabel.Text;
    }

    protected void ButtonEditeazaJudet_Click(object Sender, EventArgs e)
    {
        judetEveniment.Visible = true;
        ButtonSubmitJudet.Visible = true;
        ButtonEditeazaJudet.Visible = false;
        judetEveniment.Text = judetEvenimentLabel.Text;
    }

    protected void ButtonEditeazaTara_Click(object Sender, EventArgs e)
    {
        taraEveniment.Visible = true;
        ButtonSubmitTara.Visible = true;
        ButtonEditeazaTara.Visible = false;
        taraEveniment.Text = taraEvenimentLabel.Text;
    }

    protected void ButtonSubmitNume_Click(object Sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand();
        sqlConnection1.Open();
        cmd.Connection = sqlConnection1;
        cmd.CommandText = "update evenimente set nume='" + numeEveniment.Text + "' where id=" + Convert.ToInt32(Session["IdEvenimentSelectat"]) + ";";
        cmd.CommandType = CommandType.Text;
        if (numeEveniment.Text != "")
        {
            cmd.ExecuteNonQuery();
            numeEvenimentLabel.Text = numeEveniment.Text;
            MesajRaspuns.Text = "Editare efectuata cu succes!";
        }
        else MesajRaspuns.Text = "Eroare!";
        sqlConnection1.Close();
    }

    protected void ButtonSubmitData_Click(object Sender, EventArgs e)
    {
        int zi = DateTime.Now.Day, luna = DateTime.Now.Month, an = DateTime.Now.Year;

        if (Int32.TryParse(anEveniment.Text, out an) == false)
        {
            MesajRaspuns.Text = "Introduceti un an numar intreg";
            return;
        }
        else
        {
            if (an < DateTime.Now.Year || an > 3000)
            {
                MesajRaspuns.Text = "Introduceti un an numar intreg intre " + DateTime.Now.Year + " si 3000 ";
                return;
            }
        }

        luna = lista_luni.SelectedIndex + 1;
        bool paritateLuna = false; // false e luna impara, true e luna para

        if (luna % 2 == 0)
        {
            paritateLuna = true;
        }


        if (Int32.TryParse(ziuaEveniment.Text, out zi) == false)
        {
            MesajRaspuns.Text = "Introduceti o zi numar intreg";
            return;
        }
        else
        {
            if (paritateLuna == true)
            {
                if (luna == 2)
                { // daca e februarie
                    if ((an % 100 == 0) && (an % 400 != 0))
                    { // verific daca e an bisect
                        if (zi < 1 || zi > 29)
                        {
                            MesajRaspuns.Text = "Introduceti o zi numar intreg intre 1 si 29 ";
                            return;
                        }
                    }
                    else
                        if (an % 4 == 0)
                        {
                            if (zi < 1 || zi > 29)
                            {
                                MesajRaspuns.Text = "Introduceti o zi numar intreg intre 1 si 29 ";
                                return;
                            }
                        }
                        else
                        {
                            if (zi < 1 || zi > 28)
                            {
                                MesajRaspuns.Text = "Introduceti o zi numar intreg intre 1 si 28 ";
                                return;
                            }
                        }
                }
                if (zi < 1 || zi > 30)
                {
                    MesajRaspuns.Text = "Introduceti o zi numar intreg intre 1 si 30 ";
                    return;
                }
            }
            else
                if (zi < 1 || zi > 31)
                {
                    MesajRaspuns.Text = "Introduceti o zi numar intreg intre 1 si 31 ";
                    return;
                }
        }

        DateTime data = DateTime.Now;
        string dataString = luna + "." + zi + "." + an;
        MesajRaspuns.Text = dataString;
        try
        {
            data = Convert.ToDateTime(dataString);
        }
        catch (Exception ex)
        {
            MesajRaspuns.Text += ex.Message;
        }

        SqlCommand cmd = new SqlCommand();
        sqlConnection1.Open();
        cmd.Connection = sqlConnection1;
        cmd.CommandText = "update evenimente set data_inceperii='" + data + "' where id=" + Convert.ToInt32(Session["IdEvenimentSelectat"]) + ";";
        cmd.CommandType = CommandType.Text;
        try
        {
            cmd.ExecuteNonQuery();
            ziuaEvenimentLabel.Text = zi.ToString();
            lunaEvenimentLabel.Text = luna.ToString();
            anEvenimentLabel.Text = an.ToString();
            MesajRaspuns.Text = "Editare efectuata cu succes!";
        }
        catch (Exception ex)
        {
            MesajRaspuns.Text = ex.Message;
        }
        sqlConnection1.Close();

    }

    protected void ButtonSubmitDescriere_Click(object Sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand();
        sqlConnection1.Open();
        cmd.Connection = sqlConnection1;
        cmd.CommandText = "update evenimente set descriere='" + descriereEveniment.Text + "' where id=" + Convert.ToInt32(Session["IdEvenimentSelectat"]) + ";";
        cmd.CommandType = CommandType.Text;
        if (descriereEveniment.Text != "")
        {
            cmd.ExecuteNonQuery();
            descriereEvenimentLabel.Text = descriereEveniment.Text;
            MesajRaspuns.Text = "Editare efectuata cu succes!";
        }
        else MesajRaspuns.Text = "Eroare!";
        sqlConnection1.Close();
    }

    protected void ButtonSubmitEtichete_Click(object Sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand();
        sqlConnection1.Open();
        cmd.Connection = sqlConnection1;
        cmd.CommandText = "update evenimente set etichete='" + etichetaEveniment.Text + "' where id=" + Convert.ToInt32(Session["IdEvenimentSelectat"]) + ";";
        cmd.CommandType = CommandType.Text;
        if (etichetaEveniment.Text != "")
        {
            cmd.ExecuteNonQuery();
            etichetaEvenimentLabel.Text = etichetaEveniment.Text;
            MesajRaspuns.Text = "Editare efectuata cu succes!";
        }
        else MesajRaspuns.Text = "Eroare!";
        sqlConnection1.Close();
    }

    protected void ButtonSubmitOras_Click(object Sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand();
        sqlConnection1.Open();
        cmd.Connection = sqlConnection1;
        cmd.CommandText = "update evenimente set oras='" + orasEveniment.Text + "' where id=" + Convert.ToInt32(Session["IdEvenimentSelectat"]) + ";";
        cmd.CommandType = CommandType.Text;
        if (orasEveniment.Text != "")
        {
            cmd.ExecuteNonQuery();
            orasEvenimentLabel.Text = orasEveniment.Text;
            MesajRaspuns.Text = "Editare efectuata cu succes!";
        }
        else MesajRaspuns.Text = "Eroare!";
        sqlConnection1.Close();
    }

    protected void ButtonSubmitJudet_Click(object Sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand();
        sqlConnection1.Open();
        cmd.Connection = sqlConnection1;
        cmd.CommandText = "update evenimente set judet='" + judetEveniment.Text + "' where id=" + Convert.ToInt32(Session["IdEvenimentSelectat"]) + ";";
        cmd.CommandType = CommandType.Text;
        if (judetEveniment.Text != "")
        {
            cmd.ExecuteNonQuery();
            judetEvenimentLabel.Text = judetEveniment.Text;
            MesajRaspuns.Text = "Editare efectuata cu succes!";
        }
        else MesajRaspuns.Text = "Eroare!";
        sqlConnection1.Close();
    }

    protected void ButtonSubmitTara_Click(object Sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand();
        sqlConnection1.Open();
        cmd.Connection = sqlConnection1;
        cmd.CommandText = "update evenimente set tara='" + taraEveniment.Text + "' where id=" + Convert.ToInt32(Session["IdEvenimentSelectat"]) + ";";
        cmd.CommandType = CommandType.Text;
        if (taraEveniment.Text != "")
        {
            cmd.ExecuteNonQuery();
            taraEvenimentLabel.Text = taraEveniment.Text;
            MesajRaspuns.Text = "Editare efectuata cu succes!";
        }
        else MesajRaspuns.Text = "Eroare!";
        sqlConnection1.Close();
    }


    protected void ButonInvitaOrganizatori_Click(object sender, EventArgs e)
    {
        Response.Redirect("OrganizatoriEveniment.aspx");
    }
}