using System;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace Emailotp
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) 
        { 
        
        }

        protected void btnSendOTP_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string mobile = txtMobile.Text.Trim();
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(mobile))
            {
                lblMessage.Text = "Enter both email and mobile number";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }

            string emailOTP = new Random().Next(100000, 999999).ToString();
            string mobileOTP = new Random().Next(100000, 999999).ToString();

            Session["EmailOTP"] = emailOTP;
            Session["MobileOTP"] = mobileOTP;

            try
            {
               
                SendEmail(email, emailOTP);

               
                SendSmsViaTwilio(mobile, mobileOTP);

                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = " OTP sent to email and phone!";
            }
            catch (Exception ex)
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = " Error: " + ex.Message;
            }
        }

        private void SendSmsViaTwilio(string mobile, string otp)
        {
            string accountSid = "ACcb2e055f776f669bde655a1a2cf8defa";    
            string authToken = "b675832c6b9d7439a632801029be5146";       
            string fromNumber = "+18158878524";         

            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                to: new PhoneNumber("+91" + mobile),     
                from: new PhoneNumber(fromNumber),
                body: $"Your OTP is: {otp}"
            );
        }

        private void SendEmail(string email, string otp)
        {
            
        }

        protected void btnVerifyOTP_Click(object sender, EventArgs e)
        {
            string enteredOTP = txtOTP.Text.Trim();
            string emailOTP = Session["EmailOTP"] as string;
            string mobileOTP = Session["MobileOTP"] as string;

            if (enteredOTP == emailOTP || enteredOTP == mobileOTP)
            {
                lblMessage.Text = " OTP verified successfully!";
                lblMessage.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblMessage.Text = " Incorrect OTP. Please try again.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}
