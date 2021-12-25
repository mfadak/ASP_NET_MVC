        public static OAuthAuthorizationServerOptions AuthorizationOptions { get; private set; }
        public Startup()
        {
            AuthorizationOptions = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/token"),
              
                Provider = new AuthorizeProvider(),
                
                AccessTokenExpireTimeSpan = TimeSpan.FromHours(1),
                AllowInsecureHttp = true
            };
 
        }
public void ConfigureAuth(IAppBuilder app)
{


app.UseOAuthBearerTokens(AuthorizationOptions);

}
