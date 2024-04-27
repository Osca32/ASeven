using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASeven
{
    public partial class StaffLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
            byte[] captchaImage = client.GenerateCaptchaImage();
            imgCaptcha.ImageUrl = "data:image/jpg;base64," + Convert.ToBase64String(captchaImage);
            imgCaptcha.Visible = true;
        }

        protected void btnValidateCaptcha_Click(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {

        }
    }
}