using Institutional_Knowledge_Learner_VSTO;
using Microsoft.AspNetCore.Http;
using Microsoft.Exchange.WebServices.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using blazor_base.Data_Service;

namespace blazor_base
{
    public class O365Data : MLengine
    {
        private Ingestor _ingestor;
        public string kStr { get; set; }
        public string documents { get; set; }
        public static int k { get; set; }
        public static int _documents { get; set; }
        public static List<string> Subject = new List<string>();
        public static List<string> Body = new List<string>();
        public List<string> Centroids = new List<string>();
        public bool LoggedIn { get; set; } = false;
        public string Username { get; set; }
        public string Password { get; set; }
        private bool IsReadyToML { get; set; } = false;
        private Ingestor ingestor = null;
        public void GetData() 
        {
            k = Int32.Parse(kStr);
            _documents = k;
            ExchangeServices.k = k;
            ExchangeServices.Login(Username, Password);
            _ingestor = new Ingestor();
            int i = 0;
            try
            {
                var items = ExchangeServices.exchange.FindItems(WellKnownFolderName.Inbox, ExchangeServices.itemView);
                foreach (Item _item in items)
                {
                    try
                    {
                        if (_item is EmailMessage)
                        {
                            _item.Load();
                            //_item.Load(new PropertySet(BasePropertySet.FirstClassProperties));
                            Subject.Add(_item.Subject);
                            _ingestor.documents[i] = _item.Subject;
                            
                            //Body.Add(_item.Subject);
                        }
                        i++;
                    }
                    catch { i++; }

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
                k = Int32.Parse(kStr);
                
                if (ingestor == null)
                {
                    ingestor = new Ingestor();
                    ingestor.process();
                    //Centroids = ingestor.documents.ToList();
                }
                else
                {
                    ingestor.process();
                    //Centroids = ingestor.documents.ToList();
                }
                WriteCSV();
            }
        }
        public O365Data()
        {
            
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