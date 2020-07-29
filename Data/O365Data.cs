using Institutional_Knowledge_Learner_VSTO;
using Microsoft.Exchange.WebServices.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace blazor_base
{
    public class O365Data
    {
        public List<string> Subject = new List<string>();
        public List<string> Body = new List<string>();
        public List<string> Centroid = new List<string>();

        //[Required]
        //[StringLength(1, ErrorMessage = "Password was not entered or failed in transmission to server code")] 
        public string Username { get; set; }
        public string Password { get; set; }
       
        public void GetData() 
        {
            ExchangeService _service;
            try
            {
                _service = new ExchangeService
                {
                    Credentials = new WebCredentials(Username, Password)
                };
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                return;
            }
            _service.Url = new Uri("https://outlook.office365.com/EWS/Exchange.asmx");
            try
            {
                foreach (EmailMessage email in _service.FindItems(WellKnownFolderName.Inbox, new ItemView(1)))
                {
                    try
                    {
                        Subject.Add(email.Sender.ToString());
                        Body.Add(email.Body.ToString());
                    }
                    catch { }
                }
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