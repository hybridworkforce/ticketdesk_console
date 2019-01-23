using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicketDesk.Web.Client.DTOs
{
    public class NewTicketDto
    {
       

        public string TicketType { get; set; }

        public string Category { get; set; }

        public string Title { get; set; }

        public string Details { get; set; }

        public string Priority { get; set; }

        public bool? AffectsCustomer { get; set; }

    }
}