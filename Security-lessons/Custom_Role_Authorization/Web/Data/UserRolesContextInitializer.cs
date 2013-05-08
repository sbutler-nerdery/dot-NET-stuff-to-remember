using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Security;
using Web.Data;
using Web.Models;
using WebMatrix.WebData;

namespace Web.Data
{
    public class UserRolesContextInitializer : DropCreateDatabaseIfModelChanges<UserRolesContext>
    {
        protected override void Seed(UserRolesContext context)
        {
            WebSecurity.InitializeDatabaseConnection(Constants.DB_CONNECTION_STRING,
                        Constants.DB_USER_TABLE_NAME,
                        Constants.DB_USER_ID_COLUMN,
                        Constants.DB_USER_NAME_COLUMN, autoCreateTables: true);

            //Insert a default admin role
            var adminRoleName = Constants.ROLES_ADMIN;
            var viewerRoleName = Constants.ROLES_VIEWER;
            var roles = new[] { adminRoleName, viewerRoleName };

            foreach (var role in roles)
            {
                if (!Roles.RoleExists(role))
                {
                    Roles.CreateRole(role);
                }                
            }

            //Insert a default admin user
            var userName = "sbutler";

            if (!WebSecurity.UserExists(userName))
            {
                WebSecurity.CreateUserAndAccount(userName, userName, 
                    new{ FirstName = "Stan", LastName = "Butler", PhoneNumber = "816.123.4567"});
            }

            //Add the user to the admin role
            if (!Roles.GetRolesForUser(userName).Contains(adminRoleName))
            {
                Roles.AddUserToRole(userName, adminRoleName);   
            }

            var bothRoles = adminRoleName + "," + viewerRoleName;
            var accountControllerPermissions = new CustomPermission[]
                {
                    //Admin only
                    new CustomPermission
                        {
                            Action = "ManageCustomPermissions", 
                            Controller = "Account",
                            RoleNames = adminRoleName                
                        },
                    new CustomPermission
                        {
                            Action = "EditCustomPermissions", 
                            Controller = "Account",
                            RoleNames = adminRoleName                
                        },
                    //All users
                    new CustomPermission
                        {
                            Action = "LogOff", 
                            Controller = "Account",
                            RoleNames = bothRoles                
                        },
                    new CustomPermission
                        {
                            Action = "Disassociate", 
                            Controller = "Account",
                            RoleNames = bothRoles                
                        },
                    new CustomPermission
                        {
                            Action = "Manage", 
                            Controller = "Account",
                            RoleNames = bothRoles                
                        },
                    new CustomPermission
                        {
                            Action = "UpdateUserInfo", 
                            Controller = "Account",
                            RoleNames = bothRoles                
                        },
                    new CustomPermission
                        {
                            Action = "RemoveExternalLogins", 
                            Controller = "Account",
                            RoleNames = bothRoles                
                        },
                    new CustomPermission
                        {
                            Action = "ManageCustomPermissions", 
                            Controller = "Account",
                            RoleNames = bothRoles                
                        }
                };

            foreach (var permission in accountControllerPermissions)
            {
                context.Permissions.Add(permission);
                context.SaveChanges();
            }
        }
    }
}