using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.GData.Client;
using Google.GData.Client.ResumableUpload;
using Google.GData.Documents;

namespace Documents.Client
{
    /// <summary>
    /// Before you run this application, make sure you actually have a google document that you can open...
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var localHtmlDocname = "docContents.htm";

            //Get credentials
            Console.Write("Enter your username:");
            var user = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Enter your password:");
            var password = Console.ReadLine();
            Console.WriteLine();

            //Set up the service
            var service = new DocumentsService("my-service");
            service.setUserCredentials(user, password);
            DocumentsFeed listFeed = null;
            AtomFeed feed = null;
            DocumentsListQuery query = null;
            IProgress<string> p = new Progress<string>(Console.WriteLine);

            //Get list of documents
            var getList = Task.Run(() =>
            {
                p.Report("Reading list of documents");
                query = new DocumentsListQuery();
                feed = service.Query(query);
            });

            getList.Wait();

            foreach (DocumentEntry entry in feed.Entries.OrderBy(x => x.Title.Text))
            {
                if (entry.IsDocument)
                    Console.WriteLine(entry.Title.Text);
            }

            Console.WriteLine("Type the name of the document you would like to open:");
            var openDocTitle = Console.ReadLine();
            string contents = string.Empty;

            //Get list of documents
            var openDoc = Task.Run(() =>
            {
                p.Report("Reading document contents");
                query.Title = openDocTitle;
                feed = service.Query(query);

                var openMe = feed.Entries[0] as DocumentEntry;
                var stream = service.Query(new Uri(openMe.Content.Src.ToString()));
                var reader = new StreamReader(stream);
                contents = reader.ReadToEnd();

                using (var fs = File.Create(localHtmlDocname))
                {
                    using (var writer = new StreamWriter(fs))
                    {
                        contents += Environment.UserName + " was here - " + DateTime.Now.ToString() + "<br/>";
                        writer.Write(contents);
                        writer.Flush();
                        writer.Close();
                    }

                    fs.Close();
                }

                //OPTIONAL: Uncomment to save changes BACK to the google doc
                /*
                openMe.MediaSource = new MediaFileSource(localHtmlDocname, "text/html");
                var uploader = new ResumableUploader();

                //Get an authenticator
                var authenticator = new ClientLoginAuthenticator("document-access-test", ServiceNames.Documents, service.Credentials);

                //Perform the upload...
                Console.WriteLine("Saving to Google Drive...");
                uploader.Update(authenticator, openMe);
                */
            });

            openDoc.Wait();
            Console.WriteLine("Opening contents of Google doc file...");
            System.Diagnostics.Process.Start(localHtmlDocname);
        }
    }
}
