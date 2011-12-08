using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;

namespace TestWebSite
{
    public partial class Frame3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			  Thread.Sleep(500); 
			  Session["LastPage"] = "Frame3";
            Session["UtcNow"] = DateTime.UtcNow;
            Session["BigObject"] = new ExponentiallyChunkyThing(5);
        }
    }
}