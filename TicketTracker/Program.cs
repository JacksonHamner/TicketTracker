using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicketTracking
{
    static class Program
    {
        static void Main()
        {
            TicketDetails ticketDetails = new TicketDetails("request", "101", "hardware", 3, "My Keyboard has stopped working", "Keyboard Problems...");
            TicketDetails ticketDetails2 = new TicketDetails("incident", "101", "software", 1, "Application needs update to run", "Application needs update");
            TicketFacade facade = new TicketFacade();
            facade.GenerateTicket(ticketDetails);
            facade.GenerateTicket(ticketDetails2);
            Console.ReadLine();
            

        }
    }
}
