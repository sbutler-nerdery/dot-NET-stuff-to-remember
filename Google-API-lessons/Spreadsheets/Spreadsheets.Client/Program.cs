using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.GData.Spreadsheets;

namespace Spreadsheets.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            //Get credentials
            Console.Write("Enter your username:");
            var user = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Enter your password:");
            var password = Console.ReadLine();
            Console.WriteLine();

            //Set up the service
            var service = new SpreadsheetsService("my-service");
            service.setUserCredentials(user, password);
            ListFeed listFeed = null;
            SpreadsheetFeed feed = null;
            IProgress<string> p = new Progress<string>(Console.WriteLine);

            //Get list of spreadsheets
            var getSheets = Task.Run(() =>
                {
                    p.Report("Getting all your Google spreadsheets...");
                    var query = new SpreadsheetQuery();
                    feed = service.Query(query);
                });

            getSheets.Wait();

            //Show list of spreadsheets...
            foreach (SpreadsheetEntry entry in feed.Entries.OrderBy(x => x.Title.Text))
            {
                Console.WriteLine(entry.Title.Text);
            }

            Console.WriteLine("Which spreadsheet would you like to see the contents of?");
            var title = Console.ReadLine();

            //Get list of spreadsheets
            var getInfo = Task.Run(() =>
            {
                p.Report("Reading rows from spreadsheet");
                var query = new SpreadsheetQuery();
                query.Title = title;
                feed = service.Query(query);

                var spreadsheet = feed.Entries.FirstOrDefault() as SpreadsheetEntry;
                var wsFeed = spreadsheet.Worksheets;
                var worksheet = wsFeed.Entries.FirstOrDefault() as WorksheetEntry;

                //Define the URL to request the list feed of the worksheet
                var listFeedLink = worksheet.Links.FindService(GDataSpreadsheetsNameTable.ListRel, null);
                p.Report(string.Format("Spreadsheet table link: {0}", listFeedLink.HRef));

                //Rows in spreadsheet
                var listQuery = new ListQuery(listFeedLink.HRef.ToString());
                listFeed = service.Query(listQuery);

            });

            getInfo.Wait();

            //Iterate through the rows...
            foreach (ListEntry row in listFeed.Entries)
            {
                foreach (ListEntry.Custom element in row.Elements)
                {
                    Console.WriteLine(element.Value);
                }
            }

            //NOTE: google docs always treats the first row as the header row... 
            Console.WriteLine("Type a new value for the first cell in the first column:");
            var newValue = Console.ReadLine();

            Console.WriteLine("Updating row data...");
            var updateRow = (ListEntry)listFeed.Entries[0];
            ListEntry.Custom updateMe = updateRow.Elements[0];
            updateMe.Value = newValue;
            updateRow.Update();

            Console.Read();
        }
    }
}
