using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;

namespace TestWebSite
{
	public partial class Redirected : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			var redirectTest = Session["RedirectTest"] as List<Int32>;
			if (redirectTest != null && redirectTest.FirstOrDefault() != 1) {
				Session["RedirectTest"] = new List<int>();
				redirectTest = (List<int>)Session["RedirectTest"];
				redirectTest.Add(1);

				Response.Redirect("redirected.aspx");
			}
		}
	}
}