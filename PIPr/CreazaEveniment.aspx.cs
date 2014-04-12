using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class CreazaEveniment : System.Web.UI.Page
{
    SqlConnection sqlConnection1 = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Domanitos\Downloads\PIPv8\PIPr\App_Data\PIP.mdf;Integrated Security=True");

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void creazaEveniment(object sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand();
        LabelCreareEveniment.Text = "";

        if (numeEveniment.Text == "")
        {
            LabelCreareEveniment.Text = "Introduceti numele evenimentului";
            return;
        }
        else
            if (numeEveniment.Text.Length > 50)
            {
                LabelCreareEveniment.Text = "Denumirea evenimentului este prea lunga";
                return;
            }
        if (ziuaEveniment.Text == "")
        {
            LabelCreareEveniment.Text = "Introduceti o zi!";
            return;
        }
        if (anEveniment.Text == "")
        {
            LabelCreareEveniment.Text = " Introduceti un an!";
            return;
        }

        if (etichetaEveniment.Text == "")
        {
            LabelCreareEveniment.Text = "Introduceti etichete!";
            return;
        }
        else
            if (etichetaEveniment.Text.Length > 128)
            {
                LabelCreareEveniment.Text = "Eticheta evenimentului este prea lunga";
                return;
            }

        if (descriereEveniment.Text == "")
        {
            LabelCreareEveniment.Text = "Introduceti descrierea!";
            return;
        }
        else
            if (descriereEveniment.Text.Length > 128)
            {
                LabelCreareEveniment.Text = "Descrierea evenimentului este prea lunga";
                return;
            }

        int zi = DateTime.Now.Day, luna = DateTime.Now.Month, an = DateTime.Now.Year;

        if (Int32.TryParse(anEveniment.Text, out an) == false)
        {
            LabelCreareEveniment.Text = "Introduceti un an numar intreg";
            return;
        }
        else
        {
            if (an < DateTime.Now.Year || an > 3000)
            {
                LabelCreareEveniment.Text = "Introduceti un an numar intreg intre " + DateTime.Now.Year + " si 3000 ";
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
            LabelCreareEveniment.Text = "Introduceti o zi numar intreg";
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
                            LabelCreareEveniment.Text = "Introduceti o zi numar intreg intre 1 si 29 ";
                            return;
                        }
                    }
                    else
                        if (an % 4 == 0)
                        {
                            if (zi < 1 || zi > 29)
                            {
                                LabelCreareEveniment.Text = "Introduceti o zi numar intreg intre 1 si 29 ";
                                return;
                            }
                        }
                        else
                        {
                            if (zi < 1 || zi > 28)
                            {
                                LabelCreareEveniment.Text = "Introduceti o zi numar intreg intre 1 si 28 ";
                                return;
                            }
                        }
                }
                if (zi < 1 || zi > 30)
                {
                    LabelCreareEveniment.Text = "Introduceti o zi numar intreg intre 1 si 30 ";
                    return;
                }
            }
            else
                if (zi < 1 || zi > 31)
                {
                    LabelCreareEveniment.Text = "Introduceti o zi numar intreg intre 1 si 31 ";
                    return;
                }
        }

        DateTime data = DateTime.Now;
        string dataString = luna + "." + zi + "." + an;
        LabelCreareEveniment.Text = dataString;
        try
        {
            data = Convert.ToDateTime(dataString);
        }
        catch (Exception ex)
        {

        }

        //  int idProprietar;

        sqlConnection1.Open();
        cmd = new SqlCommand("INSERT INTO evenimente(nume, descriere, data_inceperii, etichete, oras, judet, tara, id_proprietar) VALUES('" + numeEveniment.Text.ToString() + "','" + descriereEveniment.Text.ToString() + "','" + data + "','" + etichetaEveniment.Text.ToString() + "','" + orasEveniment.Text.ToString() + "','" + judetEveniment.Text.ToString() + "','" + taraEveniment.Text.ToString() + "'," + Session["id"] + ")", sqlConnection1);
        try
        {
            cmd.ExecuteNonQuery();
            LabelCreareEveniment.Text = "Inregistrare reusita";
            numeEveniment.Text = "";
            descriereEveniment.Text = "";
            orasEveniment.Text = "";
            judetEveniment.Text = "";
            taraEveniment.Text = "";
            ziuaEveniment.Text = "";
            anEveniment.Text = "";
            etichetaEveniment.Text = "";
        }
        catch (Exception ex)
        {
            LabelCreareEveniment.Text = ex.Message;
            return;
        }
        sqlConnection1.Close();
        Button_creazaEveniment.Enabled = false;
    }


}