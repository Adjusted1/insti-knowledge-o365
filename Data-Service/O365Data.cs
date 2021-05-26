﻿using Institutional_Knowledge_Learner_VSTO;
using Microsoft.Exchange.WebServices.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace blazor_base
{
    public class O365Data : MLengine
    {
        public List<string> Subject = new List<string>();
        public List<string> Body = new List<string>();
        public List<string> Centroid = new List<string>();
        public bool LoggedIn { get; set; } = false;
        public string Username { get; set; }
        public string Password { get; set; }
        private bool IsReadyToML { get; set; } = false;
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
                view  = new ItemView(10);
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
                            Body.Add(_item.Subject);
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
            async System.Threading.Tasks.Task AsyncAwaitExample()
            {
                await AsyncWaitForDataLoadComplete();
                IsReadyToML = true;                
            }
            async System.Threading.Tasks.Task AsyncWaitForDataLoadComplete()
            {   // Wait for this constructor code to verify a successfull login
                while(!LoggedIn) { }
            }
        }
    }
}