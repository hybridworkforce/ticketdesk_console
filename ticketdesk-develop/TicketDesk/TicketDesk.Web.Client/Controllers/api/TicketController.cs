using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using TicketDesk.Web.Client.DTOs;
using TicketDesk.Web.Identity;
using System.Web.Http;

using RoutePrefixAttribute = System.Web.Http.RoutePrefixAttribute;
using TicketDesk.Domain;
using TicketDesk.Web.Client.Models;

namespace TicketDesk.Web.Client.Controllers.api
{
    [System.Web.Mvc.Authorize]
    [RoutePrefix("api/ticketlist")]
    public class TicketListController : ApiController
    {

        private TdDomainContext Context = new TdDomainContext();
       
        [System.Web.Http.HttpPost]
        public IHttpActionResult getMyTickets([FromBody]TicketsDTO dTO)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var lst = (from t in Context.Tickets
                       where ((dTO.IsMy ? (t.CreatedBy) : (t.AssignedTo)) == dTO.UserID)
                       orderby(t.TicketId) ascending

                       select (new Tickets()
                       { 
                           Title = t.Title,
                           CreatedBy = t.CreatedBy,
                           AssignedTo = t.AssignedTo,
                           Category = t.Category,
                           CreatedDate = t.CreatedDate.ToString(),
                           Details = t.Details,
                           IsHtml = t.IsHtml,
                           Owner = t.Owner,
                           Priority = t.Priority,
                           ProjectId = t.ProjectId,
                           TicketId = t.TicketId,
                           TagList = t.TagList,
                           TicketType = t.TicketType,
                           TicketStatus = t.TicketStatus
                         
                           

                       })).Skip(dTO.ItemsPerPage * (dTO.PageNo-1))
                .Take(dTO.ItemsPerPage).ToList();
            //var lst = Context.Tickets.Where(t => t.CreatedBy == dTO.UserID || t.AssignedTo == dTO.UserID)
            //    .OrderBy(t => t.CreatedDate)
            //    .Skip(dTO.ItemsPerPage * dTO.PageNo)
            //    .Take(dTO.ItemsPerPage).ToList();

            return Ok(lst);
        }

        //[System.Web.Http.HttpPost]
        //public IHttpActionResult getAssignTickets([FromBody]TicketsDTO dTO)
        //{
        //    if (!ModelState.IsValid) return BadRequest(ModelState);

        //    var lst = (from t in Context.Tickets
        //               where (t.AssignedTo == dTO.UserID)
        //               orderby (t.CreatedBy) ascending

        //               select (new Tickets()
        //               {
        //                   Title = t.Title,
        //                   CreatedBy = t.CreatedBy,
        //                   AssignedTo = t.AssignedTo,
        //                   Category = t.Category,
        //                   CreatedDate = t.CreatedDate.ToString(),
        //                   Details = t.Details,
        //                   IsHtml = t.IsHtml,
        //                   Owner = t.Owner,
        //                   Priority = t.Priority,
        //                   ProjectId = t.ProjectId,
        //                   TicketId = t.TicketId,
        //                   TagList = t.TagList,
        //                   TicketType = t.TicketType,
        //                   TicketStatus = t.TicketStatus



        //               })).Skip(dTO.ItemsPerPage * (dTO.PageNo - 1))
        //        .Take(dTO.ItemsPerPage).ToList();


        //    return Ok(lst);
        //}

        //[System.Web.Http.HttpPost]
        //public IHttpActionResult newTicktes()
        //{
        //    return BadRequest();
        //}

    }
}
