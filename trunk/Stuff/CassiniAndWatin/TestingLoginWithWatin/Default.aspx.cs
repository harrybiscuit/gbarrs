using System;
using System.Web.UI;

namespace TestingLoginWithWatin
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) return;
            if (!string.IsNullOrEmpty(loginId.Value) && !string.IsNullOrEmpty(password.Value))
            {
                Response.Redirect("/LoggedIn.htm", true);
            }

            errorText.Text = "Login Failed";
        }
    }
}