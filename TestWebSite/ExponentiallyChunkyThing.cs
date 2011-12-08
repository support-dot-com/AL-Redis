using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestWebSite
{
    [Serializable]
    public class ExponentiallyChunkyThing
    {
        public long[] Numbers { get; set; }
        public string[] BigTexts { get; set; }

		 private int howBig;
		 public int HowBig
		 {
			 get { return howBig; }
		 }

        const string ONETEXT = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        const long ONELONG = Int64.MaxValue;

        public ExponentiallyChunkyThing(int howBig)
        {
            this.howBig = howBig * howBig;

            Numbers = Enumerable.Repeat(ONELONG, howBig).ToArray();
            BigTexts = Enumerable.Repeat(ONETEXT, howBig).ToArray();
        }
    }
}