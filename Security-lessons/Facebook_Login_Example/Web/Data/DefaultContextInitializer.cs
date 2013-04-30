using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Web.Data
{
    public class DefaultContextInitializer : DropCreateDatabaseIfModelChanges<DefaultContext>
    {
    }
}