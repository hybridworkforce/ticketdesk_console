using System;

namespace TicketDesk.Web.Client.DTOs
{
    public class TokenDto
    {
        public string Token { get; set; }
        public DateTime Expires { get; set; }
    }
}