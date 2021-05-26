using Institutional_Knowledge_Learner_VSTO;
using Microsoft.AspNetCore.Http;
using Microsoft.Exchange.WebServices.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace blazor_base
{
    public class O365Data : MLengine
    {
        public string kStr { get; set; } = "";
        public string documents { get; set; } = "0";
        public static int k { get; set; }
        public static int _documents { get; set; }
        public List<string> Subject = new List<string>();
        public static List<string> Body = new List<string>();
        public List<string> Centroids = new List<string>();
        public bool LoggedIn { get; set; } = false;
        public string Username { get; set; }
        public string Password { get; set; }
        private bool IsReadyToML { get; set; } = false;
        private Ingestor ingestor = null;
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
                
                view  = new ItemView(k);
                var items = _service.FindItems(WellKnownFolderName.Inbox, view);
                foreach (Item _item in items)
                {
                    try
                    {
                        if (_item is EmailMessage)
                        {
                            _item.Load();
                            //_item.Load(new PropertySet(BasePropertySet.FirstClassProperties));
                            Body.Add(_item.Body.Text);
                            //Body.Add(_item.Subject);
                        }
                    }
                    catch { }
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.ToString());
            }
            IsReadyToML = true;
            DoML();
        }
        private void DoML()
        {
            if (IsReadyToML)
            {
                if (ingestor == null)
                {
                    ingestor = new Ingestor();
                    ingestor.process();
                    ingestor.StuffFolders();
                    Centroids = ingestor.documents.ToList();
                }
                else
                {
                    ingestor.process();
                    ingestor.StuffFolders();
                    Centroids = ingestor.documents.ToList();
                }
                WriteCSV();
            }
        }
        public O365Data()
        {
            this.k = Int32.Parse(kStr);
            this._documents = Int32.Parse(documents);
            async System.Threading.Tasks.Task AsyncAwaitForDataLoad()
            {
                await AsyncWaitForDataLoadComplete();
                IsReadyToML = true;                
            }
            async System.Threading.Tasks.Task AsyncWaitForDataLoadComplete()
            {   // Wait for this constructor code to verify a successfull login
                while(!LoggedIn) { }
            }
        }

        public void WriteCSV()
        {
            foreach (string s in Centroids)
            {
                File.WriteAllText("centroids.txt", s + System.Environment.NewLine);
            }
        }
      
    }
}