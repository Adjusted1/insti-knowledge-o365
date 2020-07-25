using Microsoft.Exchange.WebServices.Data;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace blazor_base
{
    public class O365Data
    {
        public int MsgNum { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public int Centroid { get; set; } // eg this msg belongs to which group/centroid?

        public O365Data()
        {
            ExchangeService _service;

            try
            {
                //Console.WriteLine("Registering Exchange connection");

                _service = new ExchangeService
                {
                    Credentials = new WebCredentials("lsweet4@solano.edu", "-----------------------")
                };
            }
            catch
            {
                //Console.WriteLine("new ExchangeService failed. Press enter to exit:");
                return;
            }

            // This is the office365 webservice URL
            _service.Url = new Uri("https://outlook.office365.com/EWS/Exchange.asmx");

            // Prepare seperate class for writing email to the database
            try
            {

                //Console.WriteLine("Reading mail");

                // Read 100 mails
                foreach (EmailMessage email in _service.FindItems(WellKnownFolderName.Inbox, new ItemView(100)))
                {
                    Subject = email.Sender.ToString();
                    //Console.WriteLine(email.Sender.ToString());
                }

                //Console.WriteLine("Exiting");
            }
            catch (Exception e)
            {
                //Console.WriteLine("An error has occured. \n:" + e.Message);
            }
        }
    }
}