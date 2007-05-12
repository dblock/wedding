<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RsvpSend.aspx.cs" Inherits="RsvpSend"
 MasterPageFile="~/Wedding.master" Title="Daniel &amp; Misha Wedding: Rsvp" %>

<%@ PreviousPageType VirtualPath="~/Rsvp.aspx" %>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="content" runat="server">
 <h3>
  RSVP
 </h3>
 <div>
  <asp:Label ID="labelRsvp" runat="server" />
 </div>
 <div style="margin-top: 10px;">
  <asp:Button ID="submit" CssClass="button" runat="server"
   OnClick="submit_Click" Text="Confirm" />
  <asp:Button ID="modify" CssClass="button" runat="server"
   OnClick="modify_Click" Text="Modify" />
 </div>
</asp:Content>
