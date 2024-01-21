using Identity.Data;
using Identity.Modals;
using Identity.Modals.Auth;
using Identity.Repositories.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Identity.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IConfiguration _configuration;

        public AuthRepository(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext applicationDbContext, IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _applicationDbContext = applicationDbContext;
            _configuration = configuration;
        }

        public async Task<(int, string)> Registeration(RegistrationModel model, string role)
        {
            DateTime now = DateTime.Now;
            var userExists = await _userManager.FindByEmailAsync(model.User.Email);
            if (userExists != null)
                throw new Exception("User already exists");

            ApplicationUser user = new()
            {
                Email = model.User.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.User.Email,
                FirstName = model.User.FirstName,
                LastName = model.User.LastName
            };
            var createUserResult = await _userManager.CreateAsync(user, model.User.Password.ToString());

            if (!createUserResult.Succeeded)
                throw new Exception("User creation failed! Please check user details and try again.");

            if (!await _roleManager.RoleExistsAsync(role))
                await _roleManager.CreateAsync(new IdentityRole(role));

            if (await _roleManager.RoleExistsAsync(role))
                await _userManager.AddToRoleAsync(user, role);

            var usr = await _userManager.FindByEmailAsync(model.User.Email);

            model.Company.AdminIdentifire = usr.Id;
            model.Company.IsDeleted = false;
            model.Company.CreatedOn = now;
            model.Company.UpdatedOn = now;
            Company company = model.Company;
            await _applicationDbContext.Companies.AddAsync(company);
            await _applicationDbContext.SaveChangesAsync();
            await _applicationDbContext.Entry(company).ReloadAsync();

            model.User.CompanyId = company.Id;
            model.User.AuthId = usr.AuthId;
            model.User.UserIdentifier = usr.Id;
            model.User.IsDeleted = false;
            model.User.CreatedOn = now;
            model.User.UpdatedOn = now;
            User user1 = model.User;
            await _applicationDbContext.Users.AddAsync(user1);
            await _applicationDbContext.SaveChangesAsync();
            await _applicationDbContext.Entry(user1).ReloadAsync();

            return (1, "User created successfully!");
        }

        public async Task<(int, string)> Login(LoginModel model)
        {
            var user = await _userManager.FindByNameAsync(model.Email);
            if (user == null)
                return (0, "Invalid username");
            if (!await _userManager.CheckPasswordAsync(user, model.Password))
                return (0, "Invalid password");

            var userRoles = await _userManager.GetRolesAsync(user);
            var authClaims = new List<Claim>
            {
               new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
               new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
               new Claim(ClaimTypes.Name, user.FirstName),
               new Claim(ClaimTypes.Email, user.Email),
               new Claim(ClaimTypes.NameIdentifier, user.Id),
            };

            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }
            string token = GenerateToken(authClaims);
            return (1, token);
        }

        private string GenerateToken(IEnumerable<Claim> claims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWTKey:Secret"]));
            var _TokenExpiryTimeInHour = Convert.ToInt64(_configuration["JWTKey:TokenExpiryTimeInHour"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _configuration["JWTKey:ValidIssuer"],
                Audience = _configuration["JWTKey:ValidAudience"],
                Expires = DateTime.UtcNow.AddMinutes(_TokenExpiryTimeInHour),
                SigningCredentials = new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256),
                Subject = new ClaimsIdentity(claims)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
