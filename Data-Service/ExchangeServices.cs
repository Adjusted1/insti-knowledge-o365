using Microsoft.Exchange.WebServices.Data;
using Microsoft.Graph;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blazor_base.Data_Service
{
    public static class ExchangeServices
    {
        public static bool loggedIn { get; set; } = false;

        public static ExchangeService exchange = null;
        public static ItemView itemView = null;
        public static Mailbox mailbox = null;
        //public static int k { get; set; }
        public static void Login(string u, string p, int numdocs)
        {
            try
            {
                exchange = new ExchangeService
                {
                    Credentials = new WebCredentials(u, p)
                };
                itemView = new ItemView(numdocs);
                loggedIn = true;
            }
            catch (Exception ex)
            {
                loggedIn = false;
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                return;
            }
            try
            {
                exchange.Url = new Uri("https://outlook.office365.com/EWS/Exchange.asmx");
                mailbox = new Mailbox(exchange.Url.ToString());
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.ToString());
            }
        }
       
    }
}
