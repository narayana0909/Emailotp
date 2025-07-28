using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;


namespace WebApplication1
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnSendMessage_Click(object sender, EventArgs e)
        {
            string accountSid = "ACcb2e055f776f669bde655a1a2cf8defa";
            string authToken = "b675832c6b9d7439a632801029be5146";
            string fromNumber = "+18158878524"; // Your Twilio number

            string toNumber = txtMobile.Text.Trim();
            string messageBody = txtMessage.Text.Trim();

            if (string.IsNullOrWhiteSpace(toNumber) || string.IsNullOrWhiteSpace(messageBody))
            {
                lblMessages.ForeColor = System.Drawing.Color.Red;
                lblMessages.Text = "Please enter both mobile number and message.";
                return;
            }

            try
            {
                TwilioClient.Init(accountSid, authToken);

                var message = MessageResource.Create(
                    body: messageBody,
                    from: new PhoneNumber(fromNumber),
                    to: new PhoneNumber("+91" + toNumber) // Assuming Indian numbers
                );

                lblMessages.ForeColor = System.Drawing.Color.Green;
                lblMessages.Text = "Message sent successfully!";
            }
            catch (Exception ex)
            {
                lblMessages.ForeColor = System.Drawing.Color.Red;
                lblMessages.Text = "Failed to send message: " + ex.Message;
            }
        }
    }
}
