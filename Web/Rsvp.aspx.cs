using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Collections.Specialized;

public partial class Rsvp : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            error.Text = Request.QueryString["error"];
            p_error.Visible = !string.IsNullOrEmpty(error.Text);
            name.Text = Request.QueryString["name"];
            guest.Text = Request.QueryString["guest"];
            if (!string.IsNullOrEmpty(guest.Text)) addguest_Click(sender, e);
            address.Text = Request.QueryString["address"];
            city.Text = Request.QueryString["city"];
            country.Text = Request.QueryString["country"];
            state.Text = Request.QueryString["state"];
            zip.Text = Request.QueryString["zip"];
            phone.Text = Request.QueryString["phone"];
            mobilephone.Text = Request.QueryString["mobilephone"];
            email.Text = Request.QueryString["email"];
            comments.Text = Request.QueryString["comments"];
            if (!string.IsNullOrEmpty(comments.Text)) addcomments_Click(sender, e);
            
            bool notattending = false; 
            if (bool.TryParse(Request.QueryString["none"], out notattending))
            {
                attending_none.Checked = notattending; attending_CheckedChanged(sender, e);
            }
            
            bool reception = false;
            if (bool.TryParse(Request.QueryString["reception"], out reception))
            {
                attending_reception.Checked = reception; attending_CheckedChanged(sender, e);
            }

            bool brunch = false;
            if (bool.TryParse(Request.QueryString["brunch"], out brunch))
            {
                attending_brunch.Checked = brunch; attending_CheckedChanged(sender, e);
            }

        }
    }

    public void addguest_Click(object sender, EventArgs e)
    {
        panelGuest.Attributes["style"] = string.Empty;
        addguest.Attributes["style"] = "display: none;";
        panelForm.Update();
    }

    public void addcomments_Click(object sender, EventArgs e)
    {
        panelComments.Attributes["style"] = string.Empty;
        addcomments.Attributes["style"] = "display: none;";
        panelForm.Update();
    }

    public void submit_Click(object sender, EventArgs e)
    {
    }

    public void attending_CheckedChanged(object sender, EventArgs e)
    {
        panelAttending.Enabled = !attending_none.Checked;
        attending_none.Enabled = !(attending_reception.Checked || attending_brunch.Checked);
        panelForm.Update();
    }

    public string GetQueryData()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendFormat("name={0}", HttpUtility.UrlEncode(name.Text));
        sb.AppendFormat("&guest={0}", HttpUtility.UrlEncode(guest.Text));
        sb.AppendFormat("&none={0}", HttpUtility.UrlEncode(attending_none.Checked.ToString()));
        sb.AppendFormat("&reception={0}", HttpUtility.UrlEncode(attending_reception.Checked.ToString()));
        sb.AppendFormat("&brunch={0}", HttpUtility.UrlEncode(attending_brunch.Checked.ToString()));
        sb.AppendFormat("&address={0}", HttpUtility.UrlEncode(address.Text));
        sb.AppendFormat("&city={0}", HttpUtility.UrlEncode(city.Text));
        sb.AppendFormat("&zip={0}", HttpUtility.UrlEncode(zip.Text));
        sb.AppendFormat("&state={0}", HttpUtility.UrlEncode(state.Text));
        sb.AppendFormat("&country={0}", HttpUtility.UrlEncode(country.Text));
        sb.AppendFormat("&comments={0}", HttpUtility.UrlEncode(comments.Text));
        sb.AppendFormat("&email={0}", HttpUtility.UrlEncode(email.Text));
        sb.AppendFormat("&phone={0}", HttpUtility.UrlEncode(phone.Text));
        sb.AppendFormat("&mobilephone={0}", HttpUtility.UrlEncode(mobilephone.Text));
        return sb.ToString();
    }

    public string GetEmail()
    {
        return email.Text;
    }

    public string GetName()
    {
        return name.Text;
    }

    public string GetRsvpData()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(HttpUtility.HtmlEncode(name.Text));
        if (!string.IsNullOrEmpty(guest.Text))
        {
            sb.AppendFormat(" & {0}", guest.Text);
        }
        if (attending_none.Checked)
        {
            sb.AppendLine();
            sb.Append("will not be attending");
        }
        else
        {
            sb.AppendLine();
            if (attending_reception.Checked) sb.Append("will be attending the reception");
            if (attending_reception.Checked && attending_brunch.Checked) { sb.AppendLine(); sb.Append(" and "); }
            if (attending_brunch.Checked) sb.Append("will be attending the brunch");
        }

        sb.AppendLine();
        sb.AppendLine();
        if (!string.IsNullOrEmpty(address.Text)) sb.AppendLine(address.Text);
        if (!string.IsNullOrEmpty(city.Text)) sb.Append(city.Text);
        if (!string.IsNullOrEmpty(state.Text)) { sb.Append(" "); sb.Append(state.Text); }
        if (!string.IsNullOrEmpty(zip.Text)) { sb.Append(" "); sb.Append(zip.Text); }
        if (!string.IsNullOrEmpty(city.Text) || !string.IsNullOrEmpty(state.Text) || !string.IsNullOrEmpty(zip.Text)) sb.AppendLine();
        if (!string.IsNullOrEmpty(country.Text)) sb.AppendLine(country.Text);
        if (!string.IsNullOrEmpty(phone.Text)) sb.AppendLine(phone.Text);
        if (!string.IsNullOrEmpty(mobilephone.Text)) sb.AppendLine(mobilephone.Text);
        if (!string.IsNullOrEmpty(email.Text)) sb.AppendLine(email.Text);
        if (!string.IsNullOrEmpty(comments.Text)) { sb.AppendLine(); sb.AppendLine(comments.Text); }
        return sb.ToString();
    }
}
