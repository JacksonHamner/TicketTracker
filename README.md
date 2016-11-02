# TicketTracker

Prepare a sample of your work that implements the Adapter and Façade design patterns.

I built a basic ticket tracking application for the use of internal employees.  They can submit a ticket with their basic information and it will pull their employee information, assign them a ticket number, calculate a target end date, and automatically point to the correct technicians group. This project contains no business function, it simple displays the requested Design Patterns.
Since this application contains several sub-systems that will need to be used in order to complete the ticket generation, we will want to create a façade object so the end result is cleaner and easier to understand. In this scenario one of our sub-systems will communicate with a legacy system using an adapter. 
