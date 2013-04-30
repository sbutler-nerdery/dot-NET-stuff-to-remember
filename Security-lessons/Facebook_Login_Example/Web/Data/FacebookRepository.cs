using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Models;

namespace Web.Data
{
    public class FacebookRepository
    {
        public static string GetAccessToken()
        {
            var token = string.Empty;

            using (var context = new DefaultContext())
            {
                var tokenRow = context.FacebookApiValues.FirstOrDefault();

                if (tokenRow != null)
                    token = tokenRow.ApiValue;
            }

            return token;
        }

        public static void SetAccessToken(string token)
        {
            using (var context = new DefaultContext())
            {
                var firstRow = context.FacebookApiValues.FirstOrDefault();

                if (firstRow == null)
                    context.FacebookApiValues.Add(new FacebookApiInfo { ApiValue = token });
                else
                    firstRow.ApiValue = token;

                context.SaveChanges();
            }
        }
    }
}