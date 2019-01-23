using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TicketDesk.Web.Client.DTOs
{
    public class TicketsDTO
    {
        [Required]
        public string UserID { get; set; }

        public int PageNo   { get; set; }

        public int ItemsPerPage { get; set; }

        public bool IsMy { get; set; }


    }
}