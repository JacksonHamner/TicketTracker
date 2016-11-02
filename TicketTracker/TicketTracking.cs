using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketTracking
{
    class TicketDetails
    {

        public string ticketType { get; set; } 
        public string employeeId { get; set; } 
        public string ticketCategory { get; set; }
        public int severity { get; set; }
        public DateTime submittedDate { get; set; }
        public string ticketDescription { get; set; }
        public string ticketTitle { get; set; }

        public TicketDetails(string ticketType, string employeeId, string ticketCategory, int severity, string ticketDescription, string ticketTitle)
        {
            this.ticketType = ticketType;
            this.employeeId = employeeId;
            this.ticketCategory = ticketCategory;
            this.severity = severity;
            this.ticketDescription = ticketDescription;
            this.ticketTitle = ticketTitle;
            this.submittedDate = DateTime.Now;
        }

    }

    class TicketFacade
    {
        ITicketTracking ticketNumber = new TicketTracking();
        ISetResolutionDate resolutionDate = new SetResolutionDate();
        IEmployeeInformation employeeName = new EmployeeInformation();
        IRouteTicket ticketGroup = new RouteTicket();

        public void GenerateTicket(TicketDetails ticketDetails)
        {
            string tn = ticketNumber.GenerateTicketNumber(ticketDetails.ticketType);
            string rd = resolutionDate.calculateTargetResolutionDate(ticketDetails.submittedDate).ToString();
            string en = employeeName.getEmployeeData(ticketDetails.employeeId);
            string tg = ticketGroup.findGroup(ticketDetails.ticketCategory);



            Console.WriteLine(string.Format("Thank you, {0}, for submitting your ticket to our help desk. Your ticket number for this {1} is {2}. Your ticket was sent to {3} and we estimate your ticket will be resolved by {4}. ", en, ticketDetails.ticketType, tn, tg, rd));

        }
    }

    // GENERATE NUMBER CLASS

    public interface ITicketTracking
    {
        string GenerateTicketNumber(string TicketType);
    }

    class TicketTracking : ITicketTracking
    {
        ITicketNumberAdapter tna = new TicketNumberAdapter();
        public string GenerateTicketNumber(string TicketType)
        {
            string ticketNumber;

            if (TicketType == "request")
            {
                ticketNumber = "REQ";
            }
            else
            {
                ticketNumber = "INC";
            }

            return ticketNumber + tna.generateTicketNumber();
        }
    }


    // SET TARGET RESOLUTION DATE

    interface ISetResolutionDate
    {
        DateTime calculateTargetResolutionDate(DateTime date);
    }

    class SetResolutionDate : ISetResolutionDate
    {
        public DateTime calculateTargetResolutionDate(DateTime date)
        {
            return date.AddDays(7);
        }
    }


    // FIND EMPLOYEE BY EMPLOYEE ID

    interface IEmployeeInformation
    {
        string getEmployeeData(string employeeId);
    }

    class EmployeeInformation : IEmployeeInformation
    {
        public string getEmployeeData(string employeeId)
        {
            //use employeeId to locate employee in a database. 
            //for this example we will just set the employee to John Doe
            return "John Doe";
        }
    }


    // FIND SUPPORT GROUP FOR THIS TYPE OF TICKET
    interface IRouteTicket
    {
        string findGroup(string ticketCategory);
    }

    class RouteTicket : IRouteTicket
    {
        string group;

        public string findGroup(string ticketCategory)
        {
            switch (ticketCategory)
            {
                case "hardware":
                    group = "Desktop Support";
                    break;
                case "software":
                    group = "Applications Support";
                    break;
                case "finance":
                    group = "Billing";
                    break;
                default:
                    group = "Help Desk";
                    break;
            }

            return group;
        }
    }


    // Adapter Interface
    interface ITicketNumberAdapter
    {
        string generateTicketNumber();
    }

    // Legacy ticket tracking system. We want to continue to use its method to generating ticket numbers, but the types are incompatable with the new system
    // We will use an adapter so we can continue using this system.
    class LegacyTicketTracking 
    {
        public int CreateTicketNumber()
        {
            Random random = new Random();
            return (int)random.Next();
        }
            
    }
        
    class TicketNumberAdapter : ITicketNumberAdapter
    {
        public string generateTicketNumber()
        {
            LegacyTicketTracking ltt = new LegacyTicketTracking();
            return ltt.CreateTicketNumber().ToString();
        }
    }
    
}
