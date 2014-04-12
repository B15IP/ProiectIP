<%@ Page Title="" Language="C#" MasterPageFile="BaraDeNavigare_MasterPage.master" AutoEventWireup="true" CodeFile="Eveniment.aspx.cs" Inherits="Eveniment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div>
    <br />
        <asp:Label ID="Label1" runat="server" Text="Numele evenimentului"></asp:Label>
        <br />
        <asp:Label ID="numeEvenimentLabel" runat="server" Text=""></asp:Label>
        <asp:TextBox ID="numeEveniment" runat="server"></asp:TextBox>
        <asp:Button ID="ButtonEditeazaNume" runat="server" Text="Editeaza Numele" OnClick="ButtonEditeazaNume_Click" />
        <asp:Button ID="ButtonSubmitNume" runat="server" Text="Ok" OnClick="ButtonSubmitNume_Click" />
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" Text="Proprietar"></asp:Label>
        <br />
        <asp:Label ID="proprietarLabel" runat="server" Text=""></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Ziua"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label4" runat="server" Text="Luna"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
        <asp:Label ID="Label5" runat="server" Text="Anul"></asp:Label>
        <br />
        <asp:Label ID="ziuaEvenimentLabel" runat="server" Text=""></asp:Label>
        <asp:TextBox ID="ziuaEveniment" runat="server"></asp:TextBox>
            <%-- <asp:TextBox ID="lunaEveniment" Text ="" runat="server"></asp:TextBox> --%>
        <asp:Label ID="lunaEvenimentLabel" runat="server" Text=""></asp:Label>
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
        <asp:Label ID="anEvenimentLabel" runat="server" Text=""></asp:Label>
        <asp:TextBox ID="anEveniment" runat="server"></asp:TextBox>
        <asp:Button ID="ButtonEditeazaData" runat="server" Text="Editeaza Data" OnClick="ButtonEditeazaData_Click" />
        <asp:Button ID="ButtonSubmitData" runat="server" Text="Ok" OnClick="ButtonSubmitData_Click" />
        <br />
        <br />
        <br />
        <asp:Label ID="Label6" runat="server" Text="Etichete"></asp:Label>
        <br />
        <asp:Label ID="etichetaEvenimentLabel" runat="server" Text=""></asp:Label>
        <asp:TextBox ID="etichetaEveniment" runat="server"></asp:TextBox>
        <asp:Button ID="ButtonEditeazaEtichete" runat="server" Text="Editeaza Etichetele" OnClick="ButtonEditeazaEtichete_Click" />
        <asp:Button ID="ButtonSubmitEtichete" runat="server" Text="Ok" OnClick="ButtonSubmitEtichete_Click" />
        <br />
        <br />
        <asp:Label ID="Label7" runat="server" Text="Descrierea evenimentului"></asp:Label>
        <br />
        <asp:Label ID="descriereEvenimentLabel" runat="server" Text=""></asp:Label>
        <asp:TextBox ID="descriereEveniment" runat="server"></asp:TextBox>
        <asp:Button ID="ButtonEditeazaDescriere" runat="server" Text="Editeaza Descrierea" OnClick="ButtonEditeazaDescriere_Click" />
        <asp:Button ID="ButtonSubmitDescriere" runat="server" Text="Ok" OnClick="ButtonSubmitDescriere_Click" />
        <br />
        <br />
        <asp:Label ID="Label8" runat="server" Text="Orasul"></asp:Label>
        <br />
        <asp:Label ID="orasEvenimentLabel" runat="server" Text=""></asp:Label>
        <asp:TextBox ID="orasEveniment" runat="server"></asp:TextBox>
        <asp:Button ID="ButtonEditeazaOras" runat="server" Text="Editeaza Orasul" OnClick="ButtonEditeazaOras_Click" />
        <asp:Button ID="ButtonSubmitOras" runat="server" Text="Ok" OnClick="ButtonSubmitOras_Click" />
        <br />
        <br />
        <asp:Label ID="Label9" runat="server" Text="Judetul"></asp:Label>
        <br />
        <asp:Label ID="judetEvenimentLabel" runat="server" Text=""></asp:Label>
        <asp:TextBox ID="judetEveniment" runat="server"></asp:TextBox>
        <asp:Button ID="ButtonEditeazaJudet" runat="server" Text="Editeaza Judetul" OnClick="ButtonEditeazaJudet_Click" />
        <asp:Button ID="ButtonSubmitJudet" runat="server" Text="Ok" OnClick="ButtonSubmitJudet_Click" />
        <br />
        <br />
        <asp:Label ID="Label10" runat="server" Text="Tara"></asp:Label>
        <br />
        <asp:Label ID="taraEvenimentLabel" runat="server" Text=""></asp:Label>
        <asp:TextBox ID="taraEveniment" runat="server"></asp:TextBox>
        <asp:Button ID="ButtonEditeazaTara" runat="server" Text="Editeaza Tara" OnClick="ButtonEditeazaTara_Click" />
        <asp:Button ID="ButtonSubmitTara" runat="server" Text="Ok" OnClick="ButtonSubmitTara_Click" />
        <br />
        <br />
        <asp:Label ID="MesajRaspuns" runat="server" Text=""></asp:Label>
         <br />
         <br />
         <asp:Button ID="ButtonInvitaOrganizatori" runat="server" OnClick="ButonInvitaOrganizatori_Click" Text="Lista organizatori" />
    </div>


</asp:Content>

