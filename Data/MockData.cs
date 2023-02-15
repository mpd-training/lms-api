using LmsApi.Models;

namespace LmsApi.Data
{
    public static class MockData
    {
        public static void Initializer(LmsContext context)
        {
            context.Database.EnsureCreated();

            if (context.Roles.Any())
            {
                return;   // Role has been populated
            }

            var roles = new Role[]
            {
                new Role { Id = 1, RoleName = "Admin"},
                new Role { Id = 2, RoleName = "Librarian" },
                new Role { Id = 3, RoleName = "Borrower" }
            }; 

            context.Roles.AddRange(roles);

            var users = new User[]
            {
                new User { Id = 1, FirstName = "Addy" , LastName = "Andromeda", Email = "addy@test.com", RoleId = 1 },
                new User { Id = 2, FirstName = "Libby", LastName = "Brook", Email = "libbt@test.com", RoleId = 2 },
                new User { Id = 3, FirstName = "Warren", LastName = "Reed", Email = "warren@test.com", RoleId = 3 },
                new User { Id = 4, FirstName = "Minchin", LastName = "Lin", Email = "minch@test.com", RoleId = 3 }
            };

            context.Users.AddRange(users);
            context.SaveChanges();
        }
    }
}
