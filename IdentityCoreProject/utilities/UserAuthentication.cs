using Microsoft.AspNetCore.Authentication.Cookies;

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
            string cookie = CookieAuthenticationDefaults.AuthenticationScheme; 

            webApplicationBuilder.Services.AddAuthentication(cookie)
                .AddCookie(cookie, options =>    
                {
                    options.Cookie.Name = "AuthCookie";
                    options.LoginPath = "/Account/Login";
                    options.AccessDeniedPath= "/Account/AccessDenied";
                });

            webApplicationBuilder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminDepartment", 
                    policy =>
                    {
                        policy.RequireClaim("Admin");
                    });

                options.AddPolicy("HRDepartment",
                    policy =>
                    {
                        policy.RequireClaim("HR");
                    });


            });
        }
    }
}
