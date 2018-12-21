using Data.Models;
using Newtonsoft.Json;
using Recuiter;
using Recuiter.CustomAuthentication;
<<<<<<< HEAD
=======
using System;
>>>>>>> 75059718b33ef5185c93084f5b1fd7e59941e081
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Linq;
<<<<<<< HEAD
using System;
=======
>>>>>>> 75059718b33ef5185c93084f5b1fd7e59941e081

namespace Recruiter
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

        }
<<<<<<< HEAD

        protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
        {  
            HttpCookie authCookie = Request.Cookies["Cookie1"];  
            if (authCookie != null)  
            {  
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);

        var serializeModel = JsonConvert.DeserializeObject<CustomSerializeModel>(authTicket.UserData);

        CustomPrincipal principal = new CustomPrincipal(authTicket.Name);

        principal.UserId = serializeModel.UserId;  
                principal.FirstName = serializeModel.FirstName;  
                principal.LastName = serializeModel.LastName;  
                principal.Roles = serializeModel.RoleName.ToArray<string>();  
  
                HttpContext.Current.User = principal;  
            }

}  
=======
        protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
        {
            HttpCookie authCookie = Request.Cookies["Cookie1"];
            if (authCookie != null)
            {
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);

                var serializeModel = JsonConvert.DeserializeObject<CustomSerializeModel>(authTicket.UserData);

                CustomPrincipal principal = new CustomPrincipal(authTicket.Name);

                principal.UserId = serializeModel.UserId;
                principal.FirstName = serializeModel.FirstName;
                principal.LastName = serializeModel.LastName;
                principal.Roles = serializeModel.RoleName.ToArray<string>();

                HttpContext.Current.User = principal;
            }

        }
>>>>>>> 75059718b33ef5185c93084f5b1fd7e59941e081
    }

}
