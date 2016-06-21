<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="quickOTPW._Default" %>
<%@ Register TagPrefix="obout" Namespace="Obout.Interface" Assembly="obout_Interface" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        function copyText()
        {
            document.getElementById("txtCopy").select();
            document.execCommand("copy");
        }
    </script>
    <div style="left:100px;top:100px;position:absolute">
        <asp:DropDownList ID="dropVersion" runat="server">
            <asp:ListItem Value="Oxygen" Text="Oxygen"></asp:ListItem>
            <asp:ListItem Value="Nitrogen" Text="Nitrogen"></asp:ListItem>
            <asp:ListItem Value="Carbon" Text="Carbon"></asp:ListItem>
        </asp:DropDownList>
        <asp:TextBox ID="txtInput" runat="server" Width="40" MaxLength="3" OnTextChanged="txtInput_TextChange" AutoPostBack="true"></asp:TextBox>
        <asp:TextBox ID="txtCopy" runat="server"></asp:TextBox>
        <p></p>
        <asp:Label ID="lblMessage" runat="server">Enter a key and press tab</asp:Label>
    </div>

</asp:Content>
