<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Rsvp.aspx.cs" Inherits="Rsvp"
 MasterPageFile="~/Wedding.master" Title="Daniel &amp; Misha Wedding: RSVP" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="content" runat="server">
 <h3>
  RSVP
 </h3>
 <asp:Panel ID="p_error" CssClass="error" runat="server">
  <asp:Label ID="error" runat="server" />
 </asp:Panel> 
 <asp:UpdatePanel runat="server" ID="panelForm" UpdateMode="Conditional">
  <ContentTemplate>
   <div style="margin-bottom: 10px;">
    <div style="margin-top: 2px;">
     <ajaxToolkit:TextBoxWatermarkExtender ID="name_ex" runat="server" TargetControlID="name"
      WatermarkText="your name" WatermarkCssClass="watermark" />
     <asp:TextBox Width="250" ID="name" runat="server" />
    </div>
    <asp:Panel ID="panelGuest" runat="server" style="display:none;">
     <ajaxToolkit:TextBoxWatermarkExtender ID="guest_ex" runat="server" TargetControlID="guest"
      WatermarkText="your guest's name" WatermarkCssClass="watermark" />
     <asp:TextBox Width="250" ID="guest" runat="server" />
    </asp:Panel>
    <div style="margin-top: 2px;">
     <asp:LinkButton ID="addguest" Text="&#187; add a guest" runat="server" OnClick="addguest_Click" />
    </div>
   </div>
   <div style="margin-top: 2px;">
    <ajaxToolkit:TextBoxWatermarkExtender ID="address_ex" runat="server" TargetControlID="address"
     WatermarkText="street address" WatermarkCssClass="watermark" />
    <asp:TextBox Width="250" ID="address" runat="server" />
   </div>
   <div style="margin-top: 2px;">
    <ajaxToolkit:TextBoxWatermarkExtender ID="zip_ex" runat="server" TargetControlID="zip"
     WatermarkText="zip code" WatermarkCssClass="watermark" />
    <asp:TextBox ID="zip" runat="server" Width="80" />
    <ajaxToolkit:TextBoxWatermarkExtender ID="city_ex" runat="server" TargetControlID="city"
     WatermarkText="city" WatermarkCssClass="watermark" />
    <asp:TextBox ID="city" runat="server" Width="100" />
    <ajaxToolkit:TextBoxWatermarkExtender ID="state_ex" runat="server" TargetControlID="state"
     WatermarkText="state" WatermarkCssClass="watermark" />
    <asp:TextBox ID="state" runat="server" Width="50" />
   </div>
   <div style="margin-top: 2px;">
    <ajaxToolkit:TextBoxWatermarkExtender ID="country_ex" runat="server" TargetControlID="country"
     WatermarkText="country" WatermarkCssClass="watermark" />
    <asp:TextBox Width="250" ID="country" runat="server" />
   </div>
   <div style="margin-top: 10px;">
    <ajaxToolkit:TextBoxWatermarkExtender ID="phone_ex" runat="server" TargetControlID="phone"
     WatermarkText="home phone" WatermarkCssClass="watermark" />
    <asp:TextBox Width="250" ID="phone" runat="server" />
   </div>
   <div style="margin-top: 2px;">
    <ajaxToolkit:TextBoxWatermarkExtender ID="mobilephone_ex" runat="server" TargetControlID="mobilephone"
     WatermarkText="mobile phone" WatermarkCssClass="watermark" />
    <asp:TextBox Width="250" ID="mobilephone" runat="server" />
   </div>
   <div style="margin-top: 2px;">
    <ajaxToolkit:TextBoxWatermarkExtender ID="email_ex" runat="server" TargetControlID="email"
     WatermarkText="e-mail" WatermarkCssClass="watermark" />
    <asp:TextBox Width="250" ID="email" runat="server" />
   </div>
   <div style="margin-top: 10px;">
    <asp:CheckBox ID="attending_none" runat="server" Text="I will not be attending" 
     OnCheckedChanged="attending_CheckedChanged" AutoPostBack="true" />
   </div>
   <asp:Panel id="panelAttending" runat="server">
    <div style="margin-top: 2px;">
     <asp:CheckBox ID="attending_reception" runat="server" Text="I will be attending" 
      OnCheckedChanged="attending_CheckedChanged" AutoPostBack="true" />
     the <a href="Reception.aspx">reception</a>
    </div>
    <div style="margin-top: 2px;">
     <asp:CheckBox ID="attending_brunch" runat="server" Text="I will be attending" 
      OnCheckedChanged="attending_CheckedChanged" AutoPostBack="true" />
     the <a href="Brunch.aspx">brunch</a>
    </div>
   </asp:Panel>
   <div style="margin-top: 10px;">
    <asp:LinkButton ID="addcomments" Text="&#187; add a comment" runat="server" OnClick="addcomments_Click" />
   </div>
   <asp:Panel ID="panelComments"  style="display:none;" runat="server">
    <div style="margin-top: 2px;">
     additional comments:
    </div>
    <asp:TextBox Width="250" ID="comments" Rows="4" Columns="30" TextMode="MultiLine"
     runat="server" />
   </asp:Panel>
   <div style="margin-top: 10px;">
    <asp:Button id="submit" CssClass="button" runat="server" PostBackUrl="RsvpSend.aspx" 
     OnClick="submit_Click" Text="RSVP" />
   </div>
  </ContentTemplate>
 </asp:UpdatePanel>
</asp:Content>
