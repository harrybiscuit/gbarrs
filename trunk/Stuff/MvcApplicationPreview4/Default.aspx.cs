using System;
using System.Collections.Generic;
using System.Web.UI;

namespace MvcApplicationPreview4
{
    public partial class _Default : Page
    {
        public void Page_Load(object sender, System.EventArgs e)
        {
            Response.Redirect("~/Home");
        }
    }
}
