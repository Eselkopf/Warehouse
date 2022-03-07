using Authorization.DAL;
using Authorization.Model;

namespace Authorization.Handlers
{
    public class RegisterHandler
    {
        private readonly AuthorizationContext authorizationContext;
        private readonly PasswordHandler passwordHandler;

        public RegisterHandler(AuthorizationContext authorizationContext, PasswordHandler passwordHandler)
        {
            this.authorizationContext = authorizationContext;
            this.passwordHandler = passwordHandler;
        }

        public async Task Register(LoginModel user)
        {
            var findUser = authorizationContext.Users.FirstOrDefault(x => x.Name == user.UserName);
            if (findUser != null)
                throw new Exception("");
            authorizationContext.Users.Add(new User 
            { 
                Name = user.UserName, 
                Password = passwordHandler.Hash(user.Password)  
            });
            authorizationContext.SaveChanges();
        }
    }
}
