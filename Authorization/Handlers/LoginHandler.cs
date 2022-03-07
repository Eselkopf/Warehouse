using Authorization.DAL;
using Authorization.Model;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Authorization.Handlers
{
    public class LoginHandler
    {
        private readonly AuthorizationContext authorizationContext;
        private readonly PasswordHandler passwordHandler;
        private const string tokenKey = "superSecretKey@345";

        public LoginHandler(AuthorizationContext authorizationContext, PasswordHandler passwordHandler)
        {
            this.authorizationContext = authorizationContext;
            this.passwordHandler = passwordHandler;
        }

        public async Task<string> Login(LoginModel user)
        {
            if (user == null)
                return null;

            var userRecord = authorizationContext.Users.FirstOrDefault(x => x.Name == user.UserName);
            if (userRecord == null)
                return null;
            if (userRecord.Password == passwordHandler.Hash(user.Password))
            {
                var secretKey = new SymmetricSecurityKey(Encoding.Default.GetBytes(tokenKey));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName)
                };

                var tokeOptions = new JwtSecurityToken(
                    issuer: "http://localhost:5000",
                    audience: "http://localhost:5000",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(5),
                    signingCredentials: signinCredentials
                );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                return tokenString;
            }
            else
            {
                return null;
            }
        }
    }
}
