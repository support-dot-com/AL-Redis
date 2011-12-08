using System;
using System.Web;
using System.Web.UI;
using System.Threading;
using System.Collections.Generic;

namespace TestWebSite
{
	public partial class Default : System.Web.UI.Page
	{
        protected override void OnLoad(EventArgs e)
        {
            
            Session["LastPage"] = "Default";
            Session["UtcNow"] = DateTime.UtcNow;
            Session["BigObject"] = new ExponentiallyChunkyThing(2);

				Session["ADecimal"] = 10203040.5060706070809m;


				Session["NotExplicitlySavedRefObject"] = new ExponentiallyChunkyThing(3);
				var notExpicitlySavedRefObject = (ExponentiallyChunkyThing)Session["NotExplicitlySavedRefObject"];

				notExpicitlySavedRefObject.BigTexts = new string[] { "test" };

				var notExplicitlyGottenRefObject = new ExponentiallyChunkyThing(2);
				Session["NotExplicitlyGottenRefObject"] = notExplicitlyGottenRefObject;
				notExplicitlyGottenRefObject.BigTexts = new string[] { "test 2" };

				var redirectTest = new List<int> { 0 };
				Session["RedirectTest"] = redirectTest;

				base.OnLoad(e);
        }

	}
}

