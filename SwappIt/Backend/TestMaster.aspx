<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="TestMaster.aspx.cs" Inherits="Backend.TestMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="pagetitle" runat="server">
    <h3 class="page-title">
			SwappIt <small>ændret fra testmasterpage!</small>
			</h3>   
    <asp:Literal runat="server" ID="TestText" Text=""></asp:Literal>

</asp:Content>
