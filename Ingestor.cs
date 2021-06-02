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
        private void LoadDocuments(int i)
        {
            var combined = "";
            var tmpStr = "";
            try
            {
                foreach (string s in O365Data.Subject[i].Split(' '))
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
                int i = 0;
                foreach (string subj in O365Data.Subject)
                {
                        LoadDocuments(i);
                        i++;
                }
                
                MLengine ml = new MLengine();
                try
                {
                    // Apply TF*IDF to the documents and get the resulting vectors.
                    double[][] inputs = Institutional_Knowledge_Learner_VSTO.tfidf.TFIDF.Transform(documents);
                    //TFIDF.Save();
                    inputs = TFIDF.Normalize(inputs);
                    observations = inputs;
                    int[] labels = new int[O365Data.k];
                    ml.Engine(observations, O365Data.k, ref labels);
                    //tfidf.TFIDF.Save();
                    //ml.AHC(observations, k);
                    //ClearFolders();
                    DelFolders();
                    MakeFolders(labels);
                    StuffFolders(labels);
                    //EnumerateFoldersGetTopWordsPerFolder();
                }
                catch (System.Exception exc)
                {
                    ///MessageBox.Show(exc.ToString());
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
                        folder.Delete(DeleteMode.HardDelete);
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
                int i = 0;
                foreach (dynamic item in this.documents)
                {
                    if (item is object)
                    {
                        int j = labels[i];
                        string folderName = "unlabeled - " + i.ToString();
                        // Ceate an email message and identify the Exchange service.
                        EmailMessage message = new EmailMessage(ExchangeServices.exchange);

                        //// Add properties to the email message.
                        message.Subject = item.ToString();
                        

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
                            }
                        }
                        
                        message.Save();

                        // Copy the orignal message into another folder in the mailbox and store the returned item.
                        message.Copy(F.Id);

                        //message.Send();
                        #region
                        //case 0:
                        //    MAPIFolder destFolder1 = inboxFolder.Folders["clustered-0"];
                        //    Outlook.MailItem copyItem1 = item.Copy();
                        //    copyItem1.Move(destFolder1);
                        //    break;
                        //case 1:
                        //    MAPIFolder destFolder2 = inboxFolder.Folders["clustered-1"];
                        //    Outlook.MailItem copyItem2 = item.Copy();
                        //    copyItem2.Move(destFolder2);
                        //    break;
                        //case 2:
                        //    MAPIFolder destFolder3 = inboxFolder.Folders["clustered-2"];
                        //    Outlook.MailItem copyItem3 = item.Copy();
                        //    copyItem3.Move(destFolder3);
                        //    break;
                        //case 3:
                        //    MAPIFolder destFolder4 = inboxFolder.Folders["clustered-3"];
                        //    Outlook.MailItem copyItem4 = item.Copy();
                        //    copyItem4.Move(destFolder4);
                        //    break;
                        //case 4:
                        //    MAPIFolder destFolder5 = inboxFolder.Folders["clustered-4"];
                        //    Outlook.MailItem copyItem5 = item.Copy();
                        //    copyItem5.Move(destFolder5);
                        //    break;
                        //case 5:
                        //    MAPIFolder destFolder6 = inboxFolder.Folders["clustered-5"];
                        //    Outlook.MailItem copyItem6 = item.Copy();
                        //    copyItem6.Move(destFolder6);
                        //    break;
                        //case 6:
                        //    MAPIFolder destFolder7 = inboxFolder.Folders["clustered-6"];
                        //    Outlook.MailItem copyItem7 = item.Copy();
                        //    copyItem7.Move(destFolder7);
                        //    break;
                        //case 7:
                        //    MAPIFolder destFolder8 = inboxFolder.Folders["clustered-7"];
                        //    Outlook.MailItem copyItem8 = item.Copy();
                        //    copyItem8.Move(destFolder8);
                        //    break;

                        //}
                        #endregion
                        i++;
                    }

                    if (i == O365Data.k) { break; }
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
            string dummy = "noinput";
            //InputBox("Done!", "Finished, You may label your email clusters", ref dummy);
            //Outlook.Folders childFolders = null;
            //try
            //{
            //    outlookApplication = Marshal.GetActiveObject("Outlook.Application") as Outlook.Application;
            //    outlookNamespace = outlookApplication.GetNamespace("MAPI");
            //    inboxFolder = outlookNamespace.GetDefaultFolder(OlDefaultFolders.olFolderInbox);


            //    childFolders = inboxFolder.Folders;

            //    if (childFolders.Count > 0)
            //    {
            //        foreach (Outlook.Folder childFolder in childFolders)
            //        {
            //            if (childFolder.Name.Contains("clustered"))
            //            {
            //                string body = "";
            //                try
            //                {
            //                    foreach (Outlook.MailItem _item in childFolder.Items)
            //                    {
            //                        body += _item.Body;
            //                    }
            //                    string[] tmp = body.Split(' ');
            //                    foreach (string s in tmp)
            //                    {
            //                        subFolderAllWords.Add(s);
            //                    }
            //                }
            //                catch { }
            //            }
            //            //no recursion, limit to 1 level
            //            //EnumerateFoldersGetTopWordsPerFolder(childFolder, labels);
            //        }
            //    }
            //    List<string> subWords = subFolderAllWords;
            //    foreach (string s in subFolderAllWords.ToList())
            //    {
            //        foreach (string s2 in TFIDF.StopWords.stopWordsList)
            //        {
            //            if (s == s2)
            //            {
            //                subWords.Remove(s);
            //            }
            //        }
            //    }
            //    subFolderAllWords = subWords;
            //    string[] words = subFolderAllWords.ToArray();
            //    MaxOccurrence(words);
            //}
            //catch { }
            //finally
            //{

            //    ReleaseComObject(outlookApplication);
            //    ReleaseComObject(inboxFolder);
            //    ReleaseComObject(outlookNamespace);
            //    ReleaseComObject(childFolders);
            //    outlookApplication = null;
            //    inboxFolder = null;
            //    outlookNamespace = null;
            //    childFolders = null;
            //}
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
