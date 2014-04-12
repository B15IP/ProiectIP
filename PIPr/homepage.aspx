<%@ Page Title="" Language="C#" MasterPageFile="~/BaraDeNavigare_MasterPage.master" AutoEventWireup="true" CodeFile="homepage.aspx.cs" Inherits="homepage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    

    <center>
            <p>

            </p>
          </br>
<asp:TextBox ID="SearchBox" runat="server" MaxLength="20" ></asp:TextBox>
            </br>
<asp:Button ID="ButtonSearch" runat="server" Text="Cauta" OnClick="ButtonSearch_Click" ToolTip="0"></asp:Button>
<asp:Button ID="ButtonSearchAscunde" runat="server" Text="Ascunde" OnClick="ButtonSearchAscunde_Click"></asp:Button>
            <br />
            <asp:Panel ID="Panelsearch" runat="server"></asp:Panel>

<asp:Button ID="ButtonEvenimenteCreate" runat="server" Text="Evenimente Create" OnClick="ButtonCreate_Click" ToolTip="0"></asp:Button>
<asp:Button ID="ButtonEvenimenteCreateAscunde" runat="server" Text="Ascunde"  OnClick="ButtonCreateAscunde_Click"></asp:Button>
            <br />
 <asp:Panel ID="Panelcreate" runat="server"></asp:Panel>
 <br />
<asp:Button ID="ButtonCreareEveniment" runat="server" Text="Creaza Eveniment" OnClick="Button_CreazaEveniment"></asp:Button>
       </center>

</asp:Content>
 
