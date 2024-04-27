using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASeven
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void MemberBtn_Click(object sender, EventArgs e)
        {
            if (IsStudentCookiePresent())
            {
                Response.Redirect("MemberStaffView.aspx");
            }
            else if (IsStaffCookiePresent())
            {
                Response.Redirect("MemberStaffView.aspx");
            }
            else
            {
                // Default action if no cookies are present
                Response.Redirect("LoginPage.aspx");
            }
        }

        protected void StaffBtn_Click(object sender, EventArgs e)
        {
            if (IsStudentCookiePresent())
            {
                Response.Redirect("MemberStaffView.aspx");
            }
            else if (IsStaffCookiePresent())
            {
                Response.Redirect("MemberStaffView.aspx");
            }
            else
            {
                // Default action if no cookies are present
                Response.Redirect("LoginPage.aspx");
            }
        }

        private bool IsStudentCookiePresent()
        {
            HttpCookie studentCookie = Request.Cookies["StudentAuth"];
            return studentCookie != null && !string.IsNullOrEmpty(studentCookie.Value);
        }

        private bool IsStaffCookiePresent()
        {
            HttpCookie staffCookie = Request.Cookies["StaffAuth"];
            return staffCookie != null && !string.IsNullOrEmpty(staffCookie.Value);
        }


    }
}