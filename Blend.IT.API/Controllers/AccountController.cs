using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Blend.IT.API.Commands.Authenticate;
using Blend.IT.API.Security;
using Blend.IT.AppService.Interfaces;
using Blend.IT.AppService.ViewModels;
using Blend.IT.CrossCutting.FluentValidator;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Threading.Tasks;

namespace Blend.IT.API.Controllers
{
    [EnableCors("Cors")]
    public class AccountController : BaseController
    {
        private UserViewModel _user { get; set; }
        private readonly TokenOptions _tokenOptions;
        private readonly IAuthenticateAppService _authenticateAppService;

        public AccountController(IOptions<TokenOptions> jwtOptions, IAuthenticateAppService authenticateAppService)
        {
            _tokenOptions = jwtOptions.Value;
            ThrowIfInvalidOptions(_tokenOptions);
            _authenticateAppService = authenticateAppService;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("api/v1/authenticate")]
        public async Task<IActionResult> Post([FromForm] AuthenticateUserCommand command)
        {
            try
            {
                if (command == null)
                    return await Response(null, new List<Notification> { new Notification("User", "Usuário ou password inválidos") });

                var contract = new AuthenticateUserCommandContract(command);

                if (contract.Contract.Invalid)
                {
                    return await Response(command, contract.Contract.Notifications);
                }

                var identity = await GetClaims(command);
                if (identity == null)
                    return await Response(null, new List<Notification> { new Notification("User", "Usuário ou password inválidos") });

                var claims = new List<Claim>()
                    {
                        new Claim(JwtRegisteredClaimNames.UniqueName, command.UserName),
                        new Claim(JwtRegisteredClaimNames.NameId, command.UserName),
                        new Claim(JwtRegisteredClaimNames.Email, _user.Email),
                        new Claim(JwtRegisteredClaimNames.Sub, command.UserName),
                        new Claim(JwtRegisteredClaimNames.Jti, await _tokenOptions.JtiGenerator()),
                        new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(_tokenOptions.IssuedAt).ToString(), ClaimValueTypes.Integer64),
                    };

                //Adiciona um ou mais perfis
                foreach (var item in identity.FindAll("Profile"))
                {
                    claims.Add(item);
                }

                var jwt = new JwtSecurityToken(
                    issuer: _tokenOptions.Issuer,
                    audience: _tokenOptions.Audience,
                    claims: claims.AsEnumerable(),
                    notBefore: _tokenOptions.NotBefore,
                    expires: _tokenOptions.Expiration,
                    signingCredentials: _tokenOptions.SigningCredentials);

                var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

                var response = new
                {
                    token = encodedJwt,
                    expires = (int)_tokenOptions.ValidFor.TotalSeconds,
                    user = new
                    {
                        id = _user.Id,
                        username = _user.UserName,
                    }
                };

                var json = JsonConvert.SerializeObject(response);
                return new OkObjectResult(json);
            }
            catch (Exception ex)
            {
                return await Response(null, new List<Notification> { new Notification("User", "Usuário ou password inválidos") });
            }
        }

        private static void ThrowIfInvalidOptions(TokenOptions options)
        {
            if (options == null) throw new ArgumentNullException(nameof(options));

            if (options.ValidFor <= TimeSpan.Zero)
                throw new ArgumentException("O período deve ser maior que zero", nameof(TokenOptions.ValidFor));

            if (options.SigningCredentials == null)
                throw new ArgumentNullException(nameof(TokenOptions.SigningCredentials));

            if (options.JtiGenerator == null)
                throw new ArgumentNullException(nameof(TokenOptions.JtiGenerator));
        }

        private static long ToUnixEpochDate(DateTime date) => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);

        private Task<ClaimsIdentity> GetClaims(AuthenticateUserCommand command)
        {
            //Authenticar o usuário
            UserViewModel userViewModel = _authenticateAppService.Authenticate(command.UserName, command.Password);

            if (userViewModel == null || userViewModel.Id <= 0)
                return Task.FromResult<ClaimsIdentity>(null);

            _user = userViewModel;

            List<Claim> claims = new List<Claim>();

            foreach (var item in _user.UserProfiles)
            {
                claims.Add(new Claim("Profile", item.ProfileName));
            }

            return Task.FromResult(new ClaimsIdentity(new GenericIdentity(_user.UserName, "Token"), claims.ToArray()));
        }
    }
}
