using System;

public class Address
{
    private string street;
    private string city;
    private string state;
    private string postalCode;

    public Address(string street, string city, string state, string postalCode)
    {
        this.street = street;
        this.city = city;
        this.state = state;
        this.postalCode = postalCode;
    }

    public string GetFullAddress()
    {
        return $"{street}, {city}, {state}, {postalCode}";
    }
}

public class Event
{
    private string title;
    private string description;
    private string date;
    private string time;
    private Address address;

    public Event(string title, string description, string date, string time, Address address)
    {
        this.title = title;
        this.description = description;
        this.date = date;
        this.time = time;
        this.address = address;
    }

    public string GetStandardDetails()
    {
        return $"Title: {title}\nDescription: {description}\nDate: {date}\nTime: {time}\nAddress: {address.GetFullAddress()}";
    }

    public virtual string GetFullDetails()
    {
        return GetStandardDetails();
    }

    public string GetShortDescription()
    {
        return $"Type: {GetType().Name}\nTitle: {title}\nDate: {date}";
    }
}

public class Lecture : Event
{
    private string speaker;
    private int capacity;

    public Lecture(string title, string description, string date, string time, Address address, string speaker, int capacity)
        : base(title, description, date, time, address)
    {
        this.speaker = speaker;
        this.capacity = capacity;
    }

    public override string GetFullDetails()
    {
        return $"{base.GetFullDetails()}\nType: Lecture\nSpeaker: {speaker}\nCapacity: {capacity}";
    }
}

public class Reception : Event
{
    private string rsvpEmail;

    public Reception(string title, string description, string date, string time, Address address, string rsvpEmail)
        : base(title, description, date, time, address)
    {
        this.rsvpEmail = rsvpEmail;
    }

    public override string GetFullDetails()
    {
        return $"{base.GetFullDetails()}\nType: Reception\nRSVP Email: {rsvpEmail}";
    }
}

public class OutdoorGathering : Event
{
    private string weatherForecast;

    public OutdoorGathering(string title, string description, string date, string time, Address address, string weatherForecast)
        : base(title, description, date, time, address)
    {
        this.weatherForecast = weatherForecast;
    }

    public override string GetFullDetails()
    {
        return $"{base.GetFullDetails()}\nType: Outdoor Gathering\nWeather Forecast: {weatherForecast}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        Address lectureAddress = new Address("123 Main St", "Anytown", "Anystate", "12345");
        Lecture lecture = new Lecture("Tech Talk", "A talk about the latest in tech", "2024-07-20", "10:00 AM", lectureAddress, "John Doe", 100);

        Address receptionAddress = new Address("456 Elm St", "Othertown", "Otherstate", "67890");
        Reception reception = new Reception("Networking Event", "Meet and greet with professionals", "2024-07-21", "6:00 PM", receptionAddress, "rsvp@example.com");

        Address outdoorAddress = new Address("789 Oak St", "Yetanothertown", "Yetanotherstate", "11223");
        OutdoorGathering outdoorGathering = new OutdoorGathering("Summer Picnic", "A fun outdoor picnic", "2024-07-22", "12:00 PM", outdoorAddress, "Sunny, 75°F");

        Event[] events = { lecture, reception, outdoorGathering };

        foreach (Event ev in events)
        {
            Console.WriteLine(ev.GetStandardDetails());
            Console.WriteLine();
            Console.WriteLine(ev.GetFullDetails());
            Console.WriteLine();
            Console.WriteLine(ev.GetShortDescription());
            Console.WriteLine(new string('-', 20));
        }
    }
}
