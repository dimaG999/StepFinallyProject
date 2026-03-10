using packstation.Entities;
using packstation.Enums;
using packstation.Repositorys;

namespace packstation.Data
{
    
        public static class DbInitializer
        {
            public static async Task SeedAdminAsync(IServiceProvider services)
            {
                using var scope = services.CreateScope();
                var userRepository = scope.ServiceProvider.GetRequiredService<IRepository<User>>();

                var users = await userRepository.GetAllAsync();

                
                if (users.Any(u => u.Role == UserRole.Admin))
                    return;

                var admin = new User
                {
                    UserName = "System",
                    UserLastName = "Administrator",
                    Email = "admin@system.com",
                    Role = UserRole.Admin,
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("Admin123!")
                };

                await userRepository.AddAsync(admin);
                await userRepository.SaveChangeAsync();
            }
        }
    }

