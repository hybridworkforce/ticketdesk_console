using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using TicketDesk.Web.Client.DTOs;
using TicketDesk.Web.Identity;
using TicketDesk.Web.Identity.Model;

namespace TicketDesk.Web.Client.Controllers.api
{


    [RoutePrefix("api/authorize")]
    public class AuthorizeController : ApiController
    {
     //   TdIdentityContext context = new TdIdentityContext();

        //  IOwinContext context = HttpContext.Current.GetOwinContext();
        TdIdentityContext context = new TdIdentityContext();



        [HttpPost]
        public async Task<IHttpActionResult> Login(AuthorizeRequestDto model)
        {
           
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var userStore = new UserStore<TicketDeskUser>(context);

            var manager = new TicketDeskUserManager(userStore);
            TicketDeskSignInManager signinmanager = new TicketDeskSignInManager(manager, HttpContext.Current.GetOwinContext().Authentication);


           // var signinManager = manager.get.GetUserManager<TicketDeskSignInManager>();
            var user = manager.FindByEmail(model.Username);

            var validCredentials = signinmanager.UserManager.CheckPassword(user, model.Password);
            if (!validCredentials)
            {

                return Unauthorized();
                //sample code to run if user's credentials is valid and before login
                //if (!manager.IsInRole(user.Id, "Administrators"))
                //{
                //    FailureText.Text = "you need a higher permission level in order to login";
                //    return;
                //}
            }

            //then sign in
            var result = signinmanager.PasswordSignIn(model.Username, model.Password, true, shouldLockout: false);


            switch (result)
            {
                case SignInStatus.Success:


                    var dic = new Dictionary<string, Object>();
                    dic.Add("username", user.UserName);
                    dic.Add("userid", user.Id);
                    return Ok(dic);

                case SignInStatus.LockedOut:
                    return Unauthorized();
            }
            //var result = await SignInManager.PasswordSignInAsync(model.Username, model.Password, true, true);



            //if (result != SignInStatus.Success && model.Username.Contains("@"))
            //{
            //   var  user = await UserManager.FindByEmailAsync(model.Username);
            //    if (user != null)
            //    {
            //        result = await SignInManager.PasswordSignInAsync(user.UserName, model.Password, true, true);
            //    }

            //}



            //switch (result)
            //{
            //    case SignInStatus.Success:
            //        //  var token = _tokenHelper.CreateToken(authApp);
            //        return Ok(UserManager.FindByEmailAsync(model.Username));

            //    case SignInStatus.LockedOut:
            //        return Unauthorized();
            //}

            return NotFound();

        }

    }
}
