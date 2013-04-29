This solution demonstates how to add custom columns to the user table used by the simple membership provider. 

Please take note of the following things:
1. Global.ashx
2. Web.Filters.InitializeSimpleMembershipAttribute
3. Web.Controllers.AccountContoller.Register line 82
4. Web.ViewModel.AccountModels line 55.
5. The [Authorize] attribute decorating Web.Controllers.HomeController. This forces the system to authorize the user before they can view the page. 