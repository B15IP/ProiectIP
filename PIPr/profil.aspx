<%@ Page Title="" Language="C#" MasterPageFile="~/BaraDeNavigare_MasterPage.master" AutoEventWireup="true" CodeFile="profil.aspx.cs" Inherits="profil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <asp:Panel ID="Panelprofil" runat="server" Visible="true">
            <asp:Label ID="Label1" runat="server" Text="Acont"></asp:Label>
            <asp:Label ID="Labelacont" runat="server" Text="Numeleacontului"></asp:Label>
              <br />
              <asp:Label ID="Label2" runat="server" Text="Nume"></asp:Label>
            <asp:Label ID="LabelNume" runat="server" Text="Nume"></asp:Label>
            <asp:TextBox ID="TextBoxNume" runat="server" Visible="false"></asp:TextBox>
            <asp:Button ID="ButtonNume" runat="server" OnClick="ButtonNume_Click" Text="Editeaza" />
             <br />
               <asp:Label ID="Label4" runat="server" Text="Prenume"></asp:Label>
            <asp:Label ID="LabelPrenume" runat="server" Text="Prenume"></asp:Label>
            <asp:TextBox ID="TextBoxPrenume" runat="server" Visible="false"></asp:TextBox>
            <asp:Button ID="ButtonPrenume" runat="server" OnClick="ButtonPrenume_Click" Text="Editeaza" />
             <br />
               <asp:Label ID="Label6" runat="server" Text="Email"></asp:Label>
            <asp:Label ID="LabelEmail" runat="server" Text="Email"></asp:Label>
              <br />
             <asp:LinkButton ID="LinkButton2" runat="server" OnClick="Buttonschimbaparola">Schimba parola</asp:LinkButton>
            <asp:Panel ID="Panelschimbaparola" runat="server" Visible="false">
                <asp:Label ID="Label3" runat="server" Text="Parola veche"></asp:Label>
                <asp:TextBox ID="TextBoxparola" runat="server"></asp:TextBox>
                <br />
                <asp:Label ID="Label5" runat="server" Text="Parola noua"></asp:Label>
                <asp:TextBox ID="TextBoxparolan" runat="server"></asp:TextBox>
                <br />
                <asp:Label ID="Label7" runat="server" Text="Confirmare parola noua"></asp:Label>
                <asp:TextBox ID="TextBoxparolan2" runat="server"></asp:TextBox>
                 <br />
                <asp:Button ID="Buttonschimba" runat="server" Text="Schimba" OnClick="Buttonschimba_Click" />
                <br />
                <asp:Label ID="Labelparolaeroare" runat="server" Text="" style="color:red"></asp:Label>
            </asp:Panel>
              <br />
             </asp:Panel>
</asp:Content>

