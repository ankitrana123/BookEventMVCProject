using DataAccess.DataAccessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DataAccessServices
{
    public class AccountDataAccess
    {
        //Returns true or false if the user exists in the Database
        public bool UserExists(User model)
        {
             using(var context = new EventsDBEntities())
            {
                bool isValidUser = context.Users.Any(User => User.EmailId.ToLower() == 
                model.EmailId.ToLower());

                return isValidUser;
            }
        }

        //Return true if the details of the logged in user matched with the database user
        public bool Login(User model)
        {
            using(var context = new EventsDBEntities())
            {
                bool isValidUser = context.Users.Any(User => User.EmailId.ToLower() ==
                model.EmailId.ToLower() && User.Password == model.Password);

                return isValidUser;
            }
        }

        //Register the user into the database for the given details
        public int SignUp(User model)
        {
            using(var context = new EventsDBEntities())
            {
                context.Users.Add(model);
                UserRolesMapping addRole = new UserRolesMapping();
                addRole.UserId = model.UserId;
                addRole.RoleId = 2;
                context.UserRolesMappings.Add(addRole);
                context.SaveChanges();
                return model.UserId;
            }
        }
    }
}
