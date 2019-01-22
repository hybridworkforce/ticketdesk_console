using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using TicketDesk.Domain;
using TicketDesk.Web.Client.Controllers;
using TicketDesk.Web.Client.Models;
using TicketDesk.Web.Identity;
using TicketDesk.Web.Identity.Model;

namespace TicketDesk.Web.Client
{
	public class TicketSystemController : ApiController
	{
		// GET api/<controller>
		//public IEnumerable<string> Get()
		//{
		//	return new string[] { "value1", "value2" };
		//}

		//// GET api/<controller>/5
		//public string Get(int id)
		//{
		//	return "value";
		//}

		// POST api/<controller>
		//public void Post([FromBody]string value)
		//{
		//}

		// PUT api/<controller>/5
		public void Put(int id, [FromBody]string value)
		{
		}

		// DELETE api/<controller>/5
		public void Delete(int id)
		{
		}

		[Route("api/Login")]
		[HttpPost]
		public HttpResponseMessage Post([FromBody]UserSignInViewModel model)
		{
			TdIdentityContext context = new TdIdentityContext();
			var userStore = new UserStore<TicketDeskUser>(context);
			var roleStore = new RoleStore<TicketDeskRole>(context);
			var userManager = new TicketDeskUserManager(userStore);
			var roleManager = new TicketDeskRoleManager(roleStore);
			IOwinContext context1 = HttpContext.Current.GetOwinContext();

			//UserSignInViewModel model = new UserSignInViewModel();
			//model.UserNameOrEmail = "megha@syonsoftware.com";
			//model.Password = "Syon_Soft";
			//model.RememberMe = false;
			HttpResponseMessage result;
			TicketDeskSignInManager signinmanager = new TicketDeskSignInManager(userManager, context1.Authentication);
			TdDomainContext domain = new TdDomainContext(null);
			UserController controller = new UserController(userManager,signinmanager,domain);
			controller.SignInApi(model,"");

			//var response = Request.CreateResponse(HttpStatusCode.Moved);
			//response.Headers.Location = new Uri("https://localhost:44373/ticket/new") ;
			//return response;
			result = Request.CreateResponse(HttpStatusCode.OK, "https://localhost:44373/ticket/new");
			return result;
			//var employee = "Megha";
			//if (employee == null)
			//{
			//	return NotFound();
			//}
			//return Ok(employee);
		}
	}
}