using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using signzy.Application.Const;
using signzy.Application.Interfaces;
using signzy.Domain.Entities;
using signzy.Domain.Models;
using signzy.Infrastucture.Interfaces;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace signzy.Application.Services
{
    public class LoginService : BaseService, ILoginservice
    {
        public IConfiguration _configuration;

        public LoginService(IConfiguration configuration, IConnectionRepository connectionRepository) : base(configuration, connectionRepository)
        {
            _configuration = configuration;
        }

         public async Task<LoginAuth> AuthenticateAsync(string UserName, string Password)
        {
            try
            {
                Dictionary<string, string> jsonValues = new Dictionary<string, string>();
                jsonValues.Add("username", UserName);
                jsonValues.Add("password", Password);
                var client = new HttpClient();

                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri("https://preproduction.signzy.tech/api/v2/patrons/login"),
                    Headers =
                        {
                            { "Accept-Language", "en-US,en;q=0.8" },
                            { "Accept", "*/*" },
                },
                    Content = new StringContent(JsonConvert.SerializeObject(jsonValues), UnicodeEncoding.UTF8, "application/json")
                };

                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                string body = await response.Content.ReadAsStringAsync();
                var res = JsonConvert.DeserializeObject<LoginAuth>(body);
                var parameters = new DynamicParameters();
                parameters.Add(Mapping.Mapping.user, UserName);
                parameters.Add(Mapping.Mapping.pass, Password);
                parameters.Add(Mapping.Mapping.token, res.id);
                parameters.Add(Mapping.Mapping.ttl, res.ttl);
                parameters.Add(Mapping.Mapping.created, res.created);
                parameters.Add(Mapping.Mapping.userId, res.userId);
                if (response.StatusCode == HttpStatusCode.OK)
                {

                    var result = ExecuteAsync(Constants.LogIn, parameters);
                    var authClaims = new Claim[]
                      {
                       new Claim("UserName", UserName),
                       new Claim("password", Password),
                       new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                      };

                    var authSigninKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["JWT:Secret"]));
                    res.Token = new JwtSecurityTokenHandler().WriteToken(this.generateToken(authClaims, authSigninKey));
                }
                return res;
            }catch(Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        private JwtSecurityToken generateToken(Claim[] authClaims, SecurityKey authSigninKey)
        {
            return new JwtSecurityToken(
                   issuer: _configuration["JWT:ValidIssuer"],
                   audience: _configuration["JWT:ValidAudience"],
                   expires: DateTime.Now.AddMinutes(60),
                   claims: authClaims,
                   signingCredentials: new SigningCredentials(authSigninKey, SecurityAlgorithms.HmacSha256Signature)
                   );
        }
    }
}
