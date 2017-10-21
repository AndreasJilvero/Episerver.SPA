using System.Linq;
using System.Web.Security;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;

namespace StarRepublic.Episerver.SPA.Business.Initialization
{
    [ModuleDependency(typeof(FrameworkInitialization))]
    public class SetupBetaUserInitializationModule : IInitializableModule
    {
        public void Initialize(InitializationEngine context)
        {
            var user = Membership.GetUser("admin");
            if (user == null)
            {
                user = Membership.CreateUser("admin", "store", "andreas.jilvero@starrepublic.com");
            }

            var roleNames = new[] { "WebAdmins", "WebEditors", "EPiBetaUsers", "Administrators" };
            foreach (var roleName in roleNames)
            {
                EnsureRoleExists(roleName);
            }

            var addedRoles = Roles.GetRolesForUser(user.UserName);
            var rolesToAdd = roleNames.Except(addedRoles).ToArray();
            if (rolesToAdd.Length > 0)
            {
                Roles.AddUserToRoles(user.UserName, rolesToAdd);
            }
        }

        public void Uninitialize(InitializationEngine context)
        {
        }

        private void EnsureRoleExists(string roleName)
        {
            if (!Roles.RoleExists(roleName))
            {
                Roles.CreateRole(roleName);
            }
        }
    }
}