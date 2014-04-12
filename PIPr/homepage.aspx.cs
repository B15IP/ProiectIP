using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

public partial class homepage : System.Web.UI.Page
{
    SqlConnection sqlConnection1 = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Domanitos\Downloads\PIPv8\PIPr\App_Data\PIP.mdf;Integrated Security=True");

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["nume"] == null)
        {
            ButtonCreareEveniment.Visible = false;
            ButtonEvenimenteCreate.Visible = false;
            ButtonEvenimenteCreateAscunde.Visible = false;

        }
        else
        {
            
            ButtonCreareEveniment.Visible = true;
            ButtonEvenimenteCreate.Visible = true;
            ButtonEvenimenteCreateAscunde.Visible = true;
           
        }
        
        if (ButtonSearch.ToolTip == "1")
            ButtonSearch_Click(sender, e);

        if (ButtonEvenimenteCreate.ToolTip == "1")
            ButtonCreate_Click(sender, e);
    }

    protected void ButtonSearch_Click(object sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = sqlConnection1;
        // cmd.CommandText = "select * from evenimente where nume = '" + SearchBox.Text + "';";
        cmd.CommandType = CommandType.Text;

        cmd.CommandText = "select * from evenimente ";

        if (SearchBox.Text != "")
        {
            String[] cuvinteSearchBox = SearchBox.Text.Split(' ');
            ArrayList cuvinteCautate = new ArrayList();
            foreach (String cuvant in cuvinteSearchBox)
            { // elimin elementele de tipul ""
                if (cuvant != "")
                {
                    cuvinteCautate.Add(cuvant);
                }
            }

            if (cuvinteCautate.Count == 0)
            { // caz special cand se introduce in search box doar spatiu
                return;
            }

            for (int pasCuvant = 0; pasCuvant < cuvinteCautate.Count; pasCuvant++)
            {

                if (pasCuvant == cuvinteCautate.Count - 1)
                {
                    if (pasCuvant == 0)
                        cmd.CommandText += " where ( etichete like '%" + cuvinteCautate[pasCuvant] + "%' )" + ";";
                    else
                        cmd.CommandText += " ( etichete like '%" + cuvinteCautate[pasCuvant] + "%' )" + ";";
                }
                else
                {
                    if (pasCuvant == 0)
                    {
                        cmd.CommandText += " where ( etichete like '%" + cuvinteCautate[pasCuvant] + "%' )" + " or ";
                    }
                    else
                    {
                        cmd.CommandText += " ( etichete like '%" + cuvinteCautate[pasCuvant] + "%' )" + " or ";
                    }

                }
            }

            //-----------------------------------
            sqlConnection1.Open();
            Label k = new Label();
            k.Text = "Rezultatele cautarii:";
            Panelsearch.Controls.Add(k);
            Panelsearch.Controls.Add(new LiteralControl("</br>"));
            using (SqlDataReader SRD = cmd.ExecuteReader())
            {
                while (SRD.Read())
                {
                    LinkButton btn = new LinkButton();
                    btn.ID = "LinkEveniment" + SRD.GetInt32(SRD.GetOrdinal("id")).ToString();
                    if (((LinkButton)FindControl(btn.ID)) == null)
                    {
                        ButtonSearch.ToolTip = "1";
                        btn.Text = SRD.GetInt32(SRD.GetOrdinal("id")).ToString();
                        btn.Click += new EventHandler(butoneveniment);
                        Panelsearch.Controls.Add(btn);
                        Panelsearch.Controls.Add(new LiteralControl("</br>"));

                        Label l = new Label();
                        l.Text = "ID: " + SRD.GetInt32(SRD.GetOrdinal("Id")).ToString();
                        Panelsearch.Controls.Add(l);
                        Panelsearch.Controls.Add(new LiteralControl("</br>"));
                        Label l2 = new Label();
                        l2.Text = "Nume: " + SRD.GetString(SRD.GetOrdinal("nume")).ToString();
                        Panelsearch.Controls.Add(l2);
                        Panelsearch.Controls.Add(new LiteralControl("</br>"));
                        Label l3 = new Label();

                        if (Convert.IsDBNull(SRD["descriere"])) l3.Text = "";
                        else l3.Text = "Descriere :" + SRD.GetString(SRD.GetOrdinal("descriere")).ToString();

                        Panelsearch.Controls.Add(l3);

                        Panelsearch.Controls.Add(new LiteralControl("</br>"));
                        Panelsearch.Controls.Add(new LiteralControl("<p></p>"));
                    }
                }
            }
            sqlConnection1.Close();
        }
    }

    protected void ButtonSearchAscunde_Click(object sender, EventArgs e)
    {
        ButtonSearch.ToolTip = "0";
        Panelsearch.Controls.Clear();
    }

    
    protected void ButtonCreate_Click(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(Session["id"]);
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = sqlConnection1;
        cmd.CommandText = "select * from evenimente where id_proprietar=" + id + ";";
        cmd.CommandType = CommandType.Text;
        sqlConnection1.Open();
        Label k = new Label();
        k.Text = "Evenimentele create:";
        Panelcreate.Controls.Add(k);
        Panelcreate.Controls.Add(new LiteralControl("</br>"));
        using (SqlDataReader SRD = cmd.ExecuteReader())
        {
            while (SRD.Read())
            {
                LinkButton btn = new LinkButton();
                btn.ID = "LinkEvenimentCreat" + SRD.GetInt32(SRD.GetOrdinal("id")).ToString();
                if (((LinkButton)FindControl(btn.ID)) == null)
                {
                    ButtonEvenimenteCreate.ToolTip = "1";
                    btn.Text = SRD.GetInt32(SRD.GetOrdinal("id")).ToString();
                    btn.Click += new EventHandler(butonevenimentcreat);
                    Panelcreate.Controls.Add(btn);
                    Panelcreate.Controls.Add(new LiteralControl("</br>"));

                    Label l = new Label();
                    l.Text = "ID: " + SRD.GetInt32(SRD.GetOrdinal("Id")).ToString();
                    Panelcreate.Controls.Add(l);
                    Panelcreate.Controls.Add(new LiteralControl("</br>"));
                    Label l2 = new Label();
                    l2.Text = "Nume: " + SRD.GetString(SRD.GetOrdinal("nume")).ToString();
                    Panelcreate.Controls.Add(l2);
                    Panelcreate.Controls.Add(new LiteralControl("</br>"));
                    Label l3 = new Label();

                    if (Convert.IsDBNull(SRD["descriere"])) l3.Text = "";
                    else l3.Text = "Descriere :" + SRD.GetString(SRD.GetOrdinal("descriere")).ToString();

                    Panelcreate.Controls.Add(l3);

                    Panelcreate.Controls.Add(new LiteralControl("</br>"));
                    Panelcreate.Controls.Add(new LiteralControl("<p></p>"));
                }
            }
        }
        sqlConnection1.Close();
    }

    protected void Button_CreazaEveniment(object sender, EventArgs e)
    {
        Response.Redirect("CreazaEveniment.aspx");
    }

    protected void ButtonCreateAscunde_Click(object sender, EventArgs e)
    {
        ButtonEvenimenteCreate.ToolTip = "0";
        Panelcreate.Controls.Clear();

    }

    protected void butoneveniment(object sender, EventArgs e)
    {
        LinkButton x = (LinkButton)sender;
        Session["IdEvenimentSelectat"] = Convert.ToInt32(x.ID.Substring(13));
        SearchBox.Text = Session["IdEvenimentSelectat"].ToString();
        Response.Redirect("Eveniment.aspx");
    }

    protected void butonevenimentcreat(object sender, EventArgs e)
    {
        LinkButton x = (LinkButton)sender;
        Session["IdEvenimentSelectat"] = Convert.ToInt32(x.ID.Substring(18));
        SearchBox.Text = Session["IdEvenimentSelectat"].ToString();
        Response.Redirect("Eveniment.aspx");
    }


}