using ITIProject.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ITIProject.Startup))]
namespace ITIProject
{
    public partial class Startup
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRoles();
        }

        public void CreateRoles()
        {
            var ManagerRole = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            IdentityRole role;
            if (!ManagerRole.RoleExists("Admins"))
            {
                role = new IdentityRole();
                role.Name = "Admins";
                ManagerRole.Create(role);
            }
            if (!ManagerRole.RoleExists("Students"))
            {
                role = new IdentityRole();
                role.Name = "Students";
                ManagerRole.Create(role);
            }
            if (!ManagerRole.RoleExists("Professors"))
            {
                role = new IdentityRole();
                role.Name = "Professors";
                ManagerRole.Create(role);
            }

            if (!ManagerRole.RoleExists("Managers"))
            {
                role = new IdentityRole();
                role.Name = "Managers";
                ManagerRole.Create(role);
            }

        }
    }
}
