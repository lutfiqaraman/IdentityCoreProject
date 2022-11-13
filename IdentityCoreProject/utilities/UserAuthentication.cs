namespace IdentityCoreProject.utilities
{
    public class UserAuthentication
    {
        private readonly WebApplicationBuilder webApplicationBuilder;
        public UserAuthentication(WebApplicationBuilder WebApplicationBuilder)
        {
            webApplicationBuilder = WebApplicationBuilder;
        }

        public void AddAuthentication()
        {
            webApplicationBuilder.Services.AddAuthentication().AddCookie("AuthCookie", options =>
            {
                options.Cookie.Name = "AuthCookie";
                options.LoginPath= "/Account/Login";
            });
        }
    }
}
