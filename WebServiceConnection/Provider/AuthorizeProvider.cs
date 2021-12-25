public class AuthorizeProvider : OAuthAuthorizationServerProvider
   {
       public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
       {
           var check = context.OwinContext.GetUserManager<ApplicationUserManager>();
 
           ApplicationUser user = await check.FindAsync(context.UserName, context.Password);
 
           if (user == null)
           {
               context.SetError("Unauthorized", "Wrong password or username");
               return;
           }
 
           ClaimsIdentity userIdentity = await user.GenerateUserIdentityAsync(check);
           ClaimsIdentity userCookie = await user.GenerateUserIdentityAsync(check);
 
           AuthenticationProperties properties = CreateProperties(user.UserName, user.Id);
           AuthenticationTicket ticket = new AuthenticationTicket(userIdentity, properties);
           context.Validated(ticket);
           context.Request.Context.Authentication.SignIn(userCookie);
       }
 
       public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
       {
           if (context.ClientId == null)
           {
               context.Validated();
           }
           return Task.FromResult<object>(null);
       }
       public static AuthenticationProperties CreateProperties(string userName, string Id)
       {
           IDictionary<string, string> data = new Dictionary<string, string>
          {
              { "userName", userName }, { "UserId", Id }
          };
           return new AuthenticationProperties(data);
       }
 
   }
