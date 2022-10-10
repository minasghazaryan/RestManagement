using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using RestManagement.DataAccess;
using RestManagement.DataAccess.Entities;
using RestManagement.Service.Interfaces;
using RestManagement.Service.ServiceModels;
using RestManagement.Service.Services.Interfaces;
using RestManagement.Shared;
using RestManagement.Shared.Config;
using RestManagement.Shared.Exceptions;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RestManagement.Service
{
    public class AccountService : BaseService, IAccountService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly AppSettings _appSettings;
        
        public AccountService
            (
                AppDbContext context,
                UserManager<AppUser> userManager,
                IOptions<AppSettings> options,
                IMapper mapper,
                ICurrentCallContext currentCallContext
            ) : base(context, mapper,currentCallContext)
        {
            _userManager = userManager;
            _appSettings = options.Value;
        }

        public async Task<string> CreateUserAsync(BaseRegisterServiceModel serviceModel)
        {
            try
            {
                var existUser = await _userManager.FindByEmailAsync(serviceModel.Email);
                if (existUser != null)
                {
                    throw new InvalidRegisterException($"User with {serviceModel.Email} already exists");
                }

                var user = _mapper.Map<AppUser>(serviceModel);
                user.CreateDate = DateTime.UtcNow;


                var result = await _userManager.CreateAsync(user, serviceModel.Password);

                if (!result.Succeeded)
                {
                    throw new InvalidRegisterException(result.GetErrorMessage());
                }

                var roleResult = await _userManager.AddToRoleAsync(user, serviceModel.Role);

                if (!result.Succeeded)
                {
                    throw new InvalidRegisterException(roleResult.GetErrorMessage());
                }
              
                return user.Id;
            }
            catch (Exception ex)
            {
                throw new InvalidRegisterException(ex, ex.Message);
            }
        }

        public async Task<LoginResponseServiceModel> LoginAsync(LoginServiceModel model)
        {
            try
            {
                var appUser = await _userManager.FindByEmailAsync(model.Email);

                if (appUser != null && await _userManager.CheckPasswordAsync(appUser, model.Password))
                {
                    return new LoginResponseServiceModel(await GenerateJwtToken(appUser));
                }

                throw new InvaliedLoginException();
            }
            catch (Exception ex)
            {
                throw new InvaliedLoginException(ex);
            }
        }

        private async Task<string> GenerateJwtToken(AppUser user)
        {
            var roles = await _userManager.GetRolesAsync(user);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim (ClaimTypes.Name,user.Email),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                }),
                Expires = DateTime.UtcNow.AddDays(_appSettings.Expires),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_appSettings.Secret)), SecurityAlgorithms.HmacSha256Signature)
            };

            foreach (var role in roles)
            {
                tokenDescriptor.Subject.AddClaim(new Claim(ClaimTypes.Role, role));
            }

            var tokenHandler = new JwtSecurityTokenHandler();

            return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
        }
    }
}
