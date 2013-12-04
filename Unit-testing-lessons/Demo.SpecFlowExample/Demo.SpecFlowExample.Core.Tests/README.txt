In order for this to work, you will need to...

1. Install the SpecFlow extension for Visual Studio: Tools > Extensions and Updates > Search for SpecFlow online
2. Install the NuGet package for specflow: right click the Test project > right click references > manage NuGet packages > search for SpecFlow
3. Make sure that the <unitTestProvider name="MsTest" /> is in the <specFlow> section of the app.conifg file
4. Refer to http://www.specflow.org/getting-started/ for quick overview of specflow.