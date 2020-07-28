using Institutional_Knowledge_Learner_VSTO;
using Microsoft.Exchange.WebServices.Data;
using System;
using System.ComponentModel.DataAnnotations;
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

        //[Required]
        //[StringLength(1, ErrorMessage = "Password was not entered or failed in transmission to server code")] 
        public string Username { get; set; }
        public string Password { get; set; }
        //public static string GetPass(string Password)
        //{
        //    return Password;
        //}
        public void GetData() 
        {
            ExchangeService _service;
            try
            {
                //Console.WriteLine("Registering Exchange connection");
                _service = new ExchangeService
                {
                    Credentials = new WebCredentials(Username, Password)
                };
            }
            catch (Exception ex)
            {
                //Console.WriteLine("new ExchangeService failed. Press enter to exit:");
                System.Diagnostics.Debug.WriteLine(ex.ToString());
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
                System.Diagnostics.Debug.WriteLine(e.ToString());
            }
        }
        public O365Data()
        {
            
        }
    }
}