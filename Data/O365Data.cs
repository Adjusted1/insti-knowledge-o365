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

        public bool LoggedIn { get; set; } = false;

        //[Required]
        //[StringLength(1, ErrorMessage = "Password was not entered or failed in transmission to server code")] 
        public string Username { get; set; }
        public string Password { get; set; }
       
        public void GetData() 
        {
            ExchangeService _service;
            ItemView view;
            try
            {
                _service = new ExchangeService
                {
                    Credentials = new WebCredentials(Username, Password)
                };
                LoggedIn = true;
            }
            catch (Exception ex)
            {
                LoggedIn = false;
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                return;
            }
            _service.Url = new Uri("https://outlook.office365.com/EWS/Exchange.asmx");
            try
            {
                view  = new ItemView(1);
                var items = _service.FindItems(WellKnownFolderName.Inbox, view);
                foreach (var o in items.Items)
                {
                    try
                    {
                        //Subject.Add(email.Sender.ToString());
                        if (o is EmailMessage)
                        {
                            o.Load(new PropertySet(BasePropertySet.FirstClassProperties));
                            Body.Add(o.Body.Text);
                        }
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