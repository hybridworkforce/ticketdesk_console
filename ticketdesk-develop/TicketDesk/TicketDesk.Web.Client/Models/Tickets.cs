using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TicketDesk.Domain.Model;

namespace TicketDesk.Web.Client.Models
{
    public class Tickets
    {
        public int? TicketId { get; set; }

        public string TicketType { get; set; }

        public string Category { get; set; }

        public string Title { get; set; }

        public string Details { get; set; }

        public bool? IsHtml { get; set; }

        public string TagList { get; set; }

        public string CreatedBy { get; set; }

        public string CreatedDate { get; set; }

        public string Owner { get; set; }

        public string AssignedTo { get; set; }

        public TicketStatus TicketStatus { get; set; }

        public string CurrentStatusDate { get; set; }

        public string CurrentStatusSetBy { get; set; }

        public string LastUpdateBy { get; set; }

        public string LastUpdateDate { get; set; }

        public string Priority { get; set; }

        public bool? AffectsCustomer { get; set; }

        public string Version { get; set; }

        public int? ProjectId { get; set; }

        public string DueDate { get; set; }

        public int? EstimatedDuration { get; set; }

        public int? ActualDuration { get; set; }

        public string TargetDate { get; set; }

        public string ResolutionDate { get; set; }
    }
}