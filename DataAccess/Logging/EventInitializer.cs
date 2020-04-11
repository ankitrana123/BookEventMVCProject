using DataAccess.DataAccessModels;
using System.Collections.Generic;
using System.Data.Entity;

namespace DataAccessLAyer
{
    public class EventInitializer : DropCreateDatabaseIfModelChanges<EventsDBEntities>
    {
        protected override void Seed(EventsDBEntities context)
        {
            var roles = new List<RoleMaster>
            {
            new RoleMaster{RoleName="Admin"},
            new RoleMaster{RoleName="User"}

            };

            roles.ForEach(s => context.RoleMasters.Add(s));
            context.SaveChanges();

            var user = new List<User>
            {
                new User{EmailId = "ankit.rana@nagarro.com", Password="sant@",FullName="Ankit Rana"}
            };
            user.ForEach(s => context.Users.Add(s));
            context.SaveChanges();

            var userRolesMapping = new List<UserRolesMapping>
            {
                new UserRolesMapping{UserId=1, RoleId=1}
            };

            userRolesMapping.ForEach(s => context.UserRolesMappings.Add(s));
            context.SaveChanges();
        }
    }
}