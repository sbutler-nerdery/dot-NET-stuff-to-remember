The models and setup for this project were borrowed from this URL: http://msdn.microsoft.com/en-us/data/jj193542.aspx

To see the database get dropped and re-created, do the following:
1. Run the project once and verify that the database gets created.
2. Open Data.Model.Blog.cs and uncomment the Url property
3. Open the Data.BloggerContextInitializer and uncomment line 18
4. Open Application.Program and uncomment line 26
5. Run the project again.

--> Notice that the database is dropped and re-created with the new Url column in the Blog table.