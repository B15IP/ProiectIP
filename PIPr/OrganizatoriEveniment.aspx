<%@ Page Title="" Language="C#" MasterPageFile="~/BaraDeNavigare_MasterPage.master" AutoEventWireup="true" CodeFile="OrganizatoriEveniment.aspx.cs" Inherits="OrganizatoriEveniment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <asp:Label ID="Label20" runat="server" Text="Introduceti username-ul utilizatorului pe care doriti sa-l invitati ca organizator al evenimentului "></asp:Label>
    <br>
    <asp:Button ID="ButtonInvitaOrganizatori" runat="server" Text="Invita organizator" BorderColor="#FF9966" BorderStyle="Dashed" style="margin-left: 159px" OnClick="ButtonInvitaOrganizatori_Click" />
        <asp:TextBox ID="UserNameOrganizatorInvitat" runat="server" style="margin-left: 43px" Width="134px"></asp:TextBox>
      <asp:Label ID="MesajEroare" runat="server"></asp:Label>
    <br />
    <br />
     <asp:Label ID="LabelInvitatieTrimisa" runat="server"></asp:Label>
</asp:Content>

