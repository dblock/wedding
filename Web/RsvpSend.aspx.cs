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
using System.Net.Mail;
using System.Text;
using System.IO;
using System.Net;

public partial class RsvpSend : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (string.IsNullOrEmpty(PreviousPage.GetEmail())) Back("E-mail is required!");
            if (string.IsNullOrEmpty(PreviousPage.GetName())) Back("Name is required!");
            labelRsvp.Text = HttpUtility.HtmlEncode(PreviousPage.GetRsvpData()).Replace("\n", "<br>");
            ViewState["querydata"] = PreviousPage.GetQueryData();
            ViewState["email"] = PreviousPage.GetEmail();
            ViewState["rsvpdata"] = PreviousPage.GetRsvpData();
        }
    }

    public void Back(string error)
    {
        Response.Redirect(string.Format("Rsvp.aspx?{0}&error={1}",
            PreviousPage.GetQueryData(), HttpUtility.UrlEncode(error)), true);
    }

    public void submit_Click(object sender, EventArgs e)
    {
        try
        {
            MailMessage message = new MailMessage();
            message.Headers.Add("x-mimeole", "Produced By Wedding 1.0");
            message.Headers.Add("Content-class", "urn:content-classes:message");
            message.Headers.Add("Content-Type", "text/plain; charset=\"ISO-8859-1\"");
            message.IsBodyHtml = false;
            Encoding iso8859 = Encoding.GetEncoding(28591);
            message.BodyEncoding = iso8859;
            message.Body = (string)ViewState["rsvpdata"];
            message.ReplyTo = new MailAddress(ConfigurationManager.AppSettings["mailReplyTo"]);
            message.From = new MailAddress(
                ConfigurationManager.AppSettings["mailReplyTo"],
                ConfigurationManager.AppSettings["mailFrom"]);
            if (!string.IsNullOrEmpty((string)ViewState["email"]))
            {
                message.CC.Add(new MailAddress((string)ViewState["email"]));
            }
            message.To.Add(new MailAddress(ConfigurationManager.AppSettings["mailReplyTo"]));
            message.Subject = "RSVP for Wedding";

            SmtpClient smtp = new SmtpClient(
                ConfigurationManager.AppSettings["mailServer"],
                int.Parse(ConfigurationManager.AppSettings["mailPort"]));

            smtp.DeliveryMethod = (SmtpDeliveryMethod)Enum.Parse(typeof(SmtpDeliveryMethod),
                ConfigurationManager.AppSettings["mailDeliveryMethod"]);

            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["mailUsername"]))
            {
                smtp.Credentials = new NetworkCredential(
                    ConfigurationManager.AppSettings["mailUsername"],
                    ConfigurationManager.AppSettings["mailPassword"]);
            }
            else
            {
                smtp.UseDefaultCredentials = true;
            }

            smtp.Send(message);

            labelRsvp.Style.Value = "font-weight: bold;";
            labelRsvp.Text = "Thank you!<br>Please contact us if you don't get an e-mail reply within 24 hours.";
            submit.Visible = false;
            modify.Visible = false;
        }
        catch (Exception ex)
        {
            submit.Visible = false;
            labelRsvp.Style.Value = "color: red; font-weight: bold;";
            labelRsvp.Text = "There was an error processing your RSVP.<br>" +
                ex.Message;
        }
    }

    public void modify_Click(object sender, EventArgs e)
    {
        Response.Redirect(string.Format("Rsvp.aspx?{0}",
            ViewState["querydata"].ToString()), true);
    }
}
