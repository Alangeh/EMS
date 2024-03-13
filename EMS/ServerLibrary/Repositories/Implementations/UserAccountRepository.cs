using BaseLibrary.DTOs;
using BaseLibrary.Entities;
using BaseLibrary.Responses;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ServerLibrary.Data;
using ServerLibrary.Helpers;
using ServerLibrary.Repositories.Contracts;

namespace ServerLibrary.Repositories.Implementations
{
    public class UserAccountRepository(IOptions<JwtSection> config, AppDbContext appDbContext) : IUserAccount
    {
        public async Task<GeneralResponse> CreateAsync(Register user)
        {
            if(user is null)
            {
                return new GeneralResponse(false, "User does not exist");
            }
            // verify user availability
            var checkUser = await FindUserByEmail(user.Email!);

            if (checkUser != null)
            {
                return new GeneralResponse(false, "User is registered already");
            }

            // add user
            var applicationUser = await AddToDatabase(new ApplicationUser()
            {
                Fullname = user.Fullname,
                Email = user.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(user.Password)
            });

            // check, create and assign user role
            var checkAdminRole = await appDbContext.SystemRoles.FirstOrDefaultAsync(a => a.Name!.Equals(Constants.Admin));

            if (checkAdminRole == null)
            {
                var createAdminRole = await AddToDatabase(new SystemRole()
                {
                    Name = Helpers.Constants.Admin
                });
                await AddToDatabase(new UserRole()
                {
                    RoleId = createAdminRole.Id,
                    UserId = applicationUser.Id,
                });
                return new GeneralResponse(true, "Account created!");
            }

            var checkUserRole = await appDbContext.SystemRoles.FirstOrDefaultAsync(u => u.Name!.Equals(Constants.User));
            SystemRole response = new();
            if (checkUserRole == null)
            {
                response = await AddToDatabase(new SystemRole()
                {
                    Name = Constants.User
                });
                await AddToDatabase(new UserRole() 
                { 
                    RoleId = response.Id,
                    UserId = applicationUser.Id, 
                });
            } else
            {
                await AddToDatabase(new UserRole()
                {
                    RoleId = checkUserRole.Id,
                    UserId = applicationUser.Id
                });
            }
            return new GeneralResponse(true, "Account Created!");
        }
        public Task<LoginResponse> SignInAsync(Login user)
        {
            throw new NotImplementedException();
        }

        #region private methods
        private async Task<ApplicationUser> FindUserByEmail(string email)
        {
            ApplicationUser applicationUser = await appDbContext.ApplicationUsers.FirstOrDefaultAsync(e => e.Email!.ToLower()!.Equals(email!.ToLower()));
            return applicationUser;
        }
        private async Task<T> AddToDatabase<T>(T model)
        {
            var result = appDbContext.Add(model!);
            await appDbContext.SaveChangesAsync();
            return (T)result.Entity;
        }
        #endregion
    }
}
