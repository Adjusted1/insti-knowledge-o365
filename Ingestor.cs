using System;
using System.Runtime;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
//using Outlook = Microsoft.Office.Interop.Outlook;
//using Office = Microsoft.Office.Core;
//using System.Windows.Forms;
//using Microsoft.Office.Interop.Outlook;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using static Institutional_Knowledge_Learner_VSTO.tfidf;
using System.Drawing;
using System.Threading.Tasks;
using Institutional_Knowledge_Learner_VSTO;
using Microsoft.Exchange.WebServices;
using blazor_base.Data_Service;
using Microsoft.Exchange.WebServices.Data;

namespace blazor_base
{
    public class Ingestor : MLengine
    {

        double[][] observations = new double[O365Data.numberOfDocuments][];
        public string[] documents = new string[O365Data.numberOfDocuments];

        static List<string> subFolderAllWords = new List<string>();
        static List<string> subFolderTopWords = new List<string>();
        public Ingestor() 
        {
        }

        private static String Remove(String s)
        {
            var rs = s.Split(new[] { '"' }).ToList();
            return String.Join("\"\"", rs.Where(_ => rs.IndexOf(_) % 2 == 0));
        }
        public static string StripTagsRegex(string source)
        {
            return Regex.Replace(source, "<.*?>", string.Empty);
        }
        private void LoadDocuments(int i, string subject)
        {
            var combined = "";
            var tmpStr = "";
            try
            {
                foreach (string s in subject.Split(' '))
                {
                    tmpStr = StripTagsRegex(s);
                    combined += s + " ";
                }
                documents[i] = combined;
            }
            catch { }
            documents[i] = StripTagsRegex(O365Data.Subject[i]);
        }
        
        public void process()
        {
            try
            {
                for (int i = 0; i < O365Data.Subject.Count; i++)
                {
                    LoadDocuments(i, O365Data.Subject[i]); 
                }
                MLengine ml = new MLengine();
                try
                {
                    // Apply TF*IDF to the documents and get the resulting vectors.
                    double[][] inputs = Institutional_Knowledge_Learner_VSTO.tfidf.TFIDF.Transform(documents);
                    inputs = tfidf.TFIDF.Normalize(inputs);
                    for (int row = 0; row < inputs.GetLength(0); row++)
                    {
                        for (int column = 0; column < inputs[row].Length; column++)
                        {
                            if (Double.IsNaN(inputs[row][column]))
                            {
                                inputs[row][column] = 1.0;
                            }
                        }
                    }
                    observations = inputs;
                    int[] labels = new int[O365Data.numberOfDocuments];
                    ml.Engine(observations, O365Data.k, ref labels);
                    DelFolders();
                    MakeFolders(labels);
                    StuffFolders(labels);
                    }
                    catch (System.Exception exc)
                    {
                    }                    
                
                }
            catch (System.Exception ex)
            { /*CALL JS Alert w/err */
            }
        }
        private void DelFolders()
        {
            try
            {
                FindFoldersResults findResults = ExchangeServices.exchange.FindFolders(WellKnownFolderName.Inbox, 
                    new FolderView(int.MaxValue) { Traversal = FolderTraversal.Deep });
                foreach (Folder folder in findResults.Folders)
                {
                    if (folder.DisplayName.Contains("unlabeled"))
                    {
                        folder.Delete(DeleteMode.MoveToDeletedItems);
                    }
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.ToString());
            }
        }
        public void StuffFolders(int[] labels)
        {
            try
            {
               
                for(int i = 0; i < documents.Length; i++)
                {
                        string subj = documents[i];
                        
                   
                        int folderAssign = labels[i];
                        string folderName = "unlabeled - " + folderAssign.ToString();
                        // Ceate an email message and identify the Exchange service.
                        EmailMessage message = new EmailMessage(ExchangeServices.exchange);

                        //// Add properties to the email message.
                        message.Subject = subj.ToString();
                        

                        // set View
                        FolderView view = new FolderView(100);
                        view.PropertySet = new PropertySet(BasePropertySet.IdOnly);
                        view.PropertySet.Add(FolderSchema.DisplayName);
                        view.Traversal = FolderTraversal.Deep;

                        FindFoldersResults findFolderResults = ExchangeServices.exchange.FindFolders(WellKnownFolderName.Inbox, view);
                        Folder F = new Folder(ExchangeServices.exchange);
                        // find specific folder
                        foreach (Folder f in findFolderResults)
                        {
                            // show FolderId of the folder "Test"
                            if (f.DisplayName == folderName)
                            {
                                F = f;
                                message.Save();
                                // Copy the orignal message into another folder in the mailbox and store the returned item.
                                message.Copy(F.Id);
                            }
                            else
                            {

                            }
                        }
                }
            }
            catch (ServiceResponseException sre) { System.Diagnostics.Debug.WriteLine(sre.ToString()); }
           
        }
        private void GetTopWords(int[] labels)
        {
            //Outlook.Folder root = Application.Session.DefaultStore.GetRootFolder() as Outlook.Folder;
            EnumerateFoldersGetTopWordsPerFolder();
        }
        // Uses recursion to enumerate Outlook subfolders.
        private void EnumerateFoldersGetTopWordsPerFolder()
        {
            
        }
        static void MaxOccurrence(string[] words)
        {
            var groups = words.GroupBy(x => x);
            var largest = groups.OrderByDescending(x => x.Count()).First();
            //MessageBox.Show("The most common word is: " + largest.Key);
        }
        private void MakeFolders(int[] labels)
        {

            for (int i = 0; i < O365Data.k; i++)
            {
                try
                {
                    Folder folder = new Folder(ExchangeServices.exchange);
                    folder.DisplayName = "unlabeled - " + i.ToString();
                    folder.FolderClass = "IPF.Note";
                    folder.Save(WellKnownFolderName.Inbox);
                }
                catch (ServiceResponseException sre)
                {
                    System.Diagnostics.Debug.WriteLine(sre.ToString());
                }
            }
        }

    }
}
