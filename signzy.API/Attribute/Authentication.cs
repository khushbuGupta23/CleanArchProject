using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace signzy.API.Attribute
{
        [AttributeUsage(validOn: AttributeTargets.Class | AttributeTargets.Method)]
        public class Authentication : System.Attribute, IAsyncActionFilter
        {
            public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
            {
                var configuration = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();
                if (!context.HttpContext.Request.Headers.TryGetValue("Authorization", out var _potentialApiKey))
                {
                    context.Result = new UnauthorizedResult();
                    return;
                }
                else
                {
                    try
                    {
                        var token = context.HttpContext.Request.Headers[HeaderNames.Authorization];
                        var tokenHandler = new JwtSecurityTokenHandler();
                        var key = Encoding.ASCII.GetBytes(configuration["JWT:Secret"]);

                        tokenHandler.ValidateToken(token.ToString().Replace("Bearer ", ""), new TokenValidationParameters
                        {
                            ValidateIssuerSigningKey = true,
                            IssuerSigningKey = new SymmetricSecurityKey(key),
                            ValidateIssuer = false,
                            ValidateAudience = false,
                            ValidateLifetime = true,
                            ClockSkew = TimeSpan.Zero
                        }, out SecurityToken validatedToken);
                        await next();
                    }
                    catch (Exception)
                    {
                        // Token validation failed
                        context.Result = new UnauthorizedResult();
                    }
                }
            }
        }
    }

