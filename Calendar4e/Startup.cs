using System;
using System.Threading.Tasks;
using Calendar4e.Data;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Calendar4e.Startup))]

namespace Calendar4e
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            createRolesandUsers();
        }

        private void createRolesandUsers()
        {
            TaskContext context = new TaskContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));


            // In Startup iam creating first Admin Role and creating a default Admin User     
            if (!roleManager.RoleExists("Admin"))
            {

                // first we create Admin rool    
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

                
            }

            // In Startup iam creating first Admin Role and creating a default Admin User     
            if (!roleManager.RoleExists("User"))
            {

                // first we create Admin rool    
                var role = new IdentityRole();
                role.Name = "User";
                roleManager.Create(role);


            }

        }
    }
}
