<%@ Page Title="" Language="C#" MasterPageFile="~/BaraDeNavigare_MasterPage.master" AutoEventWireup="true" CodeFile="CreazaEveniment.aspx.cs" Inherits="CreazaEveniment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <div>
    <br />
        <asp:Label ID="Label1" runat="server" Text="Numele evenimentului"></asp:Label>
        <br />
        <asp:TextBox ID="numeEveniment" runat="server"></asp:TextBox>
        <br />
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Ziua"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label4" runat="server" Text="Luna"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
        <asp:Label ID="Label5" runat="server" Text="Anul"></asp:Label>
        <br />
        <asp:TextBox ID="ziuaEveniment" runat="server"></asp:TextBox>
      <%-- <asp:TextBox ID="lunaEveniment" Text ="" runat="server"></asp:TextBox> --%>
        <asp:DropDownList ID="lista_luni" runat="server">
            <asp:ListItem Value="1" Text="ianuarie"/>
            <asp:ListItem Value="2" Text="februarie"/>
            <asp:ListItem Value="3" Text="martie"/>
            <asp:ListItem Value="4" Text="aprilie"/>
            <asp:ListItem Value="5" Text="mai"/>
            <asp:ListItem Value="6" Text="iunie"/>
            <asp:ListItem Value="7" Text="iulie"/>
            <asp:ListItem Value="8" Text="august"/>
            <asp:ListItem Value="9" Text="septembrie"/>
            <asp:ListItem Value="10" Text="octombrie"/>
            <asp:ListItem Value="11" Text="noiembrie"/>
            <asp:ListItem Value="12" Text="decembrie"/>
        </asp:DropDownList>
        <asp:TextBox ID="anEveniment" runat="server"></asp:TextBox>
        <br />
        <br />
        <br />
        <asp:Label ID="Label6" runat="server" Text="Etichete. ex: flashmob brasov tineri"></asp:Label>
        <br />
        <asp:TextBox ID="etichetaEveniment" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label7" runat="server" Text="Descrierea evenimentului"></asp:Label>
        <br />
        <asp:TextBox ID="descriereEveniment" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label8" runat="server" Text="Orasul"></asp:Label>
        <br />
        <asp:TextBox ID="orasEveniment" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label9" runat="server" Text="Judetul"></asp:Label>
        <br />
        <asp:TextBox ID="judetEveniment" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label10" runat="server" Text="Tara"></asp:Label>
        <br />
        <asp:TextBox ID="taraEveniment" runat="server"></asp:TextBox>
        <br />
        <br />
    
    </div>
        <p>
            <asp:Button ID="Button_creazaEveniment" runat="server" OnClick="creazaEveniment" Text="Create" />
        </p>
        <p>
            <asp:Label ID="LabelCreareEveniment" runat="server" Text=""></asp:Label>
        </p>

</asp:Content>

