namespace PriorityQueueCollection
{
    public class CalendarEvent
    {
        public string Title { get; set; } = string.Empty;
        public string Date { get; set; }
        public string Time { get; set; }
        public CalendarEvent(string title, string date, string time)
        {
            Title = title;
            Date = date;
            Time = time;
        }
    }
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Creates the event list with event objects and their priorities
            // serves as seed data

            List<(CalendarEvent, int)> calendarEvents =
            [
                (new CalendarEvent("Dentist", "10/01/2024", "10:00"), 3),
                (new CalendarEvent("Doctor", "10/02/2024", "11:00"), 2),
                (new CalendarEvent("Meeting", "10/03/2024", "12:00"), 1),
                (new CalendarEvent("Lunch", "10/04/2024", "13:00"), 5),
                (new CalendarEvent("Dinner", "10/05/2024", "14:00"), 4)
            ];

            // Creates a priority queue and adds the List of events and priorities to the queue 
            PriorityQueue<CalendarEvent, int> calendarQueue = new(calendarEvents);
            int selection = Menu();
            string title;
            int priority;
            string time;
            while (selection != 4)
            {
                switch (selection)
                {
                    case 1: // Add 5 items
                        Console.WriteLine("CalendarEvent name: ");
                        title = Console.ReadLine();
                        Console.WriteLine("Date: ");
                        string date = Console.ReadLine();
                        Console.WriteLine("Time: ");
                        time = Console.ReadLine();
                        Console.WriteLine("CalendarEvent Priority: ");
                        priority = int.Parse(Console.ReadLine());
                        calendarQueue.Enqueue(new CalendarEvent(title, date, time), priority);
                        break;
                    case 2: // Checking the event queue for the highest priority event
                        _ = calendarQueue.TryPeek(out CalendarEvent nextEvent, out _);
                        Console.WriteLine($"Highest priority event: {nextEvent.Title}, Date {nextEvent.Date}, Time {nextEvent.Time}");
                        break;
                    case 3: // Removing highest priority (attending/completing event)
                        _ = calendarQueue.TryDequeue(out CalendarEvent completeEvent, out _);
                        Console.WriteLine($"Event completed and removed from calendar: {completeEvent.Title}, Date {completeEvent.Date}, Time {completeEvent.Time}");
                        break;
                    default:
                        Console.WriteLine("You have made an invalid selection, please try again");
                        break;
                }
                selection = Menu();
            }
            //Continue displaying the highest priority item and removing it until all items are removed.
            while (calendarQueue.Count > 0)
            {
                _ = calendarQueue.TryDequeue(out CalendarEvent completeEvent, out _);
                Console.WriteLine($"Event completed and removed from calendar: {completeEvent.Title}, Date {completeEvent.Date}, Time {completeEvent.Time}");
            }

            Console.WriteLine("Program ended.");

            static int Menu()
            {
                Console.WriteLine("Calendar Event Priority Queue");
                Console.WriteLine("1 to Add a Calendar Event\n2 to View the Highest Priority Calendar Event\n3 to Complete and Remove Event\n4 to Quit");
                int choice = int.Parse(Console.ReadLine());
                return choice;
            }

        }
    }
}